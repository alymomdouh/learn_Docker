# LearnDocker.Api

## Docker Commands

| Command | Description |
|---------|-------------|
| `docker build -t learn-docker-api .` | Build the Docker image from the Dockerfile and tag it as `learn-docker-api` |
| `docker build -t learn-docker-api --build-arg ENV=Local .` | Build the image with a build argument to set the environment to `Local` |
| `docker run -d -p 8081:443 --name my-api learn-docker-api` | Run the container in detached mode, map host port 8081 to container port 443, and name it `my-api` |
| `docker run -d -p 8081:443 -e ASPNETCORE_ENVIRONMENT=Local --name my-api learn-docker-api` | Run the container with an environment variable override for the ASP.NET environment |
| `docker stop my-api` | Stop the running container named `my-api` |
| `docker rm my-api` | Remove the stopped container named `my-api` |
| `docker ps` | List running containers (shows health status) |
| `docker inspect my-api` | View detailed metadata about the container (including health check logs) |

## Docker Compose Commands

| Command | Description |
|---------|-------------|
| `docker-compose up -d` | Start all services (API + remote Neon DB) in detached mode using `docker-compose.yml` |
| `docker-compose -f docker-compose.yml -f docker-compose.local.yml up -d` | Start services with local PostgreSQL override — merges both compose files, the local one adds a `db` service and overrides the connection string |
| `docker-compose down` | Stop and remove containers, networks, and default resources created by `up` (volumes are kept) |
| `docker-compose down -v` | Same as above, but also removes named volumes (e.g., `pgdata`) — database data is deleted |

## Other Common Docker Commands

| Command | Description |
|---------|-------------|
| `docker images` | List all downloaded/built Docker images |
| `docker rmi <image>` | Remove a Docker image by name or ID |
| `docker pull <image>` | Download an image from Docker Hub (e.g., `docker pull postgres:16`) |
| `docker ps -a` | List all containers, including stopped ones |
| `docker logs <container>` | View logs from a running or stopped container |
| `docker logs -f <container>` | Follow (stream) logs live from a container |
| `docker exec -it <container> <cmd>` | Run a command inside a running container (e.g., `docker exec -it my-api bash`) |
| `docker exec -it <container> sh` | Open an interactive shell inside a container (useful for debugging) |
| `docker container prune` | Remove all stopped containers |
| `docker image prune` | Remove unused (dangling) images |
| `docker system prune -a` | Remove all unused containers, images, networks, and cache (caution: destructive) |
| `docker network ls` | List all Docker networks |
| `docker volume ls` | List all Docker volumes |
| `docker volume prune` | Remove all unused volumes |
| `docker cp <src> <container>:<dest>` | Copy files from host to container |
| `docker cp <container>:<src> <dest>` | Copy files from container to host |
| `docker start <container>` | Start an existing stopped container |
| `docker restart <container>` | Restart a running container |
| `docker stats` | Show live resource usage (CPU, memory, network) for running containers |
| `docker login` | Log in to Docker Hub or a private registry |
| `docker push <image>` | Push an image to a Docker registry |