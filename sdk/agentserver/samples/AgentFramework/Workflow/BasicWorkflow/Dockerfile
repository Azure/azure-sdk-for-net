# Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Copy the entire agentserver directory to ensure all ProjectReference dependencies are available
COPY . .

# Restore dependencies for the BasicWorkflow project
# This will restore all referenced projects (AgentFramework, Core, Contracts) as well
RUN dotnet restore samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj

# Build the BasicWorkflow project and all its dependencies
RUN dotnet build samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj -c Release --no-restore

# Publish the application
RUN dotnet publish samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj -c Release --no-build -o /app

# Run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app .

# Expose the default port
EXPOSE 8088

# Set the entry point to run the BasicWorkflow application
ENTRYPOINT ["dotnet", "BasicWorkflow.dll"]
