# Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Copy the entire azure-sdk-for-net repository to ensure all dependencies are available
# This includes eng/Directory.Build.Common.props which defines LtsTargetFramework
COPY . .

# Copy the local NuGet package cache for Microsoft.Agents.AI.* packages
# This avoids authentication issues with private Azure DevOps feeds
COPY --chown=root:root .nuget-cache/ /root/.nuget/packages/

# Restore dependencies for the BasicWorkflow project
# This will restore all referenced projects (AgentFramework, Core, Contracts) as well
RUN dotnet restore sdk/agentserver/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj

# Build the BasicWorkflow project and all its dependencies
RUN dotnet build sdk/agentserver/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj -c Release --no-restore

# Publish the application
RUN dotnet publish sdk/agentserver/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj -c Release --no-build -o /app

# Run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app .

# Expose the default port
EXPOSE 8088

# Set the entry point to run the BasicWorkflow application
ENTRYPOINT ["dotnet", "BasicWorkflow.dll"]
