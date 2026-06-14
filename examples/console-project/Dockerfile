# Legacy .NET Framework (4.x) only works in Windows containers — it cannot run in Linux
# containers because it depends on Windows APIs. Images like
# mcr.microsoft.com/dotnet/framework/sdk:4.8 require Docker Desktop in Windows
# containers mode.
# For new projects, always use .NET (5+) or .NET 8 — they run on both Linux and Windows containers.

# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the working directory inside the container
WORKDIR /src
# Copy only the project file first (for layer caching) (dot = current WORKDIR: /src)
COPY app.csproj .
# Restore NuGet dependencies
RUN dotnet restore
# Copy the rest of the source code (first . = host/source, second . = container/destination)
COPY . .
# Build and publish the app (-c = configuration: Release, -o = output directory: /app)
RUN dotnet publish -c Release -o /app

# Use the smaller .NET Runtime image for running the app
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
# Set the working directory for the runtime stage
WORKDIR /app
# Copy the published output from the build stage
COPY --from=build /app .
# Define the command to run when the container starts
#  "app.dll"  is started project name , change it to your project name if different
ENTRYPOINT ["dotnet", "app.dll"]



# to run the container, use the following command in terminal (make sure to be in the same directory as Dockerfile):
# 1- Docker Desktop is not running. Start it first:
#   -t flag is used to tag the image with a name (e.g., "my-dotnet-app"), and the dot (.) at the end specifies the build context (the current directory).
# 2- "docker build -t my-dotnet-app ."  (this builds the image and tags it
# 3- "docker run -d -p 8080:80 --name my-running-app my-dotnet-app" 
# this runs the container in detached mode, maps port 8080 on the host to port 80 in the container, and names the container "my-running-app"
# -d or --detach runs a container in the background. The container starts, and you get your terminal prompt back immediately instead of being attached to its output.
# then 
# 4- "docker build -t my-dotnet-app ."   # Rebuild the image — Docker caches layers, so only changed steps re-run:
# 
# 5- "docker run --rm my-dotnet-app"  # This re-copies the source (COPY . .) and re-publishes. Then run a new container:
# 6- "docker build --no-cache -t my-dotnet-app ." If you want to force a full rebuild (no cache):
 