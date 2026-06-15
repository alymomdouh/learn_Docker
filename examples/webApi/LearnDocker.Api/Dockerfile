# Use .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set working directory inside the container to /src
WORKDIR /src
# Copy only the project file first to cache dependencies layer
COPY ["LearnDocker.Api.csproj", "."]
# Restore NuGet packages (cached if csproj hasn't changed)
RUN dotnet restore
# Copy the remaining source files into the container
COPY . .
# Generate a development certificate for HTTPS
RUN mkdir -p /https && dotnet dev-certs https -ep /https/aspnetapp.pfx -p password
# Build and publish the app in Release mode to /app/publish
RUN dotnet publish LearnDocker.Api.csproj -c Release -o /app/publish
# if one project ==> RUN dotnet publish -c Release -o /app/publish


# Use .NET 8 ASP.NET runtime image for the final container (smaller)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# Set working directory inside the runtime container to /app
WORKDIR /app
# EXPOSE 80 Expose port 80 for HTTP traffic

# Expose port 443 for HTTPS traffic
EXPOSE 443
# Install curl for health check
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
# Configure Kestrel to use HTTPS with the dev certificate
ENV ASPNETCORE_HTTP_PORTS=
ENV ASPNETCORE_HTTPS_PORTS=443
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
# Check every 30s that the app responds with HTTP 200 on /api/health
# we should create new endpoint in code for this manual 
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 CMD curl -k --silent --fail https://localhost:443/api/health || exit 1
# Copy the published output from the build stage into this stage
COPY --from=build /app/publish .
# Copy the dev certificate from the build stage  only for https 
COPY --from=build /https /https
# Set Neon PostgreSQL connection string for runtime
ENV ConnectionStrings__NeonConnection="Host=ep-curly-bread-aqpm5xf6.c-8.us-east-1.aws.neon.tech;Port=5432;Database=neondb;Username=neondb_owner;Password=npg_aRz2IuKo9xPA;SSL Mode=Require"
# Set the container entry point to run the application DLL
ENTRYPOINT ["dotnet", "LearnDocker.Api.dll"]

# Build the image:
#   [docker build -t learn-docker-api .]
#
# Run the container (detached, port 8081 -> 443):
#   [docker run -d -p 8081:443 --name my-api learn-docker-api]
#
# Check health status:
#   [docker ps]  (look for "healthy" under STATUS)
#   [docker inspect my-api]  (see health check logs)
#
# Stop and remove:
#   [docker stop my-api] 
#   [docker rm my-api]


#   Rebuild and run: as https

#   docker stop my-api; docker rm my-api
#   docker build -t learn-docker-api .
#   docker run -d -p 8081:443 --name my-api learn-docker-api
#   Then visit https://localhost:8081/swagger/index.html.