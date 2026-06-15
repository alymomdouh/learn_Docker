# Console App

## Design
A simple .NET console application that demonstrates Docker containerization fundamentals. The app prints messages to the console to illustrate how a containerized .NET application executes and produces output.

## Architecture
- **Single-project** .NET console application targeting a specific .NET version
- **Minimal dependencies** — only the .NET runtime is required to build and run
- The app is packaged into a Docker image via a multi-stage Dockerfile that:
  1. Builds the project in a SDK image
  2. Copies the compiled output to a smaller runtime image

## Docker Role
- Docker **builds** the app into an isolated image with its own filesystem and .NET runtime
- Docker **runs** the app as a container, which starts the process, writes output to stdout/stderr, and then exits
- This provides a **consistent, reproducible** execution environment regardless of the host OS
