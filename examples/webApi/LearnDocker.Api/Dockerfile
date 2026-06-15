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
# Build and publish the app in Release mode to /app/publish
RUN dotnet publish LearnDocker.Api.csproj -c Release -o /app/publish
# if one project ==> RUN dotnet publish -c Release -o /app/publish


# Use .NET 8 ASP.NET runtime image for the final container (smaller)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# Set working directory inside the runtime container to /app
WORKDIR /app
# Expose port 80 for HTTP traffic
EXPOSE 80
# Install curl for health check
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
# Check every 30s that the app responds with HTTP 200 on /api/health
# we should create new endpoint in code for this manual 
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 CMD curl --silent --fail http://localhost:80/api/health || exit 1
# Copy the published output from the build stage into this stage
COPY --from=build /app/publish .
# Set Neon PostgreSQL connection string for runtime
ENV ConnectionStrings__NeonConnection="Host=ep-curly-bread-aqpm5xf6.c-8.us-east-1.aws.neon.tech;Port=5432;Database=neondb;Username=neondb_owner;Password=npg_aRz2IuKo9xPA;SSL Mode=Require"
# Set the container entry point to run the application DLL
ENTRYPOINT ["dotnet", "LearnDocker.Api.dll"]

# Build the image:
#   [docker build -t learn-docker-api .]
#
# Run the container (detached, port 8080 -> 80):
#   [docker run -d -p 8080:80 --name my-api learn-docker-api]
#
# Check health status:
#   [docker ps]  (look for "healthy" under STATUS)
#   [docker inspect my-api]  (see health check logs)
#
# Stop and remove:
#   [docker stop my-api] 
#   [docker rm my-api]
