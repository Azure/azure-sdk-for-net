# Foundry hosted-agent runtime image for the TravelAgent sample.
#
# This Dockerfile is *runtime-only*: it expects `dotnet publish` to have already
# produced a `publish/` directory beside it (see scripts/deploy-foundry-agent.ps1
# or `dotnet publish -c Release -o publish` from this directory).
#
# Keeping publish on the host (instead of inside a multi-stage build) avoids
# pulling the entire azure-sdk-for-net repo into the build context, which is
# required by the sample's ProjectReferences to sibling SDK packages.
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

# Pre-published application binaries (built by the deploy script / `dotnet publish`).
COPY publish/ .

# Optimization configuration tree (baseline + any candidate folders).
# Loaded at runtime by OptimizationConfigLoader; OPTIMIZATION_CANDIDATE_ID
# controls which folder layers on top of baseline.
COPY .agent_configs/ ./.agent_configs/

# Default Foundry hosted-agent listen port. Override with AGENT_HOST_PORT if needed.
ENV ASPNETCORE_URLS=http://+:8088
EXPOSE 8088

ENTRYPOINT ["dotnet", "Azure.AI.AgentServer.Optimization.Configuration.Samples.dll"]
