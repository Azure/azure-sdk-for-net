# ============================================================================
# Build Stage: Compile and publish the BasicWorkflow application
# ============================================================================
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Create a custom NuGet.Config that uses public nuget.org feed instead of private Azure DevOps feed
# This avoids authentication issues during Docker build
RUN echo '<?xml version="1.0" encoding="utf-8"?>' > NuGet.Config && \
    echo '<configuration>' >> NuGet.Config && \
    echo '  <packageSources>' >> NuGet.Config && \
    echo '    <clear />' >> NuGet.Config && \
    echo '    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />' >> NuGet.Config && \
    echo '  </packageSources>' >> NuGet.Config && \
    echo '  <disabledPackageSources>' >> NuGet.Config && \
    echo '    <clear />' >> NuGet.Config && \
    echo '  </disabledPackageSources>' >> NuGet.Config && \
    echo '</configuration>' >> NuGet.Config

# Create a centralized Directory.Packages.props for the agentserver projects
# This provides explicit package versions to resolve NU1103 and NU1107 errors
RUN mkdir -p sdk/agentserver && \
    echo '<Project>' > sdk/agentserver/Directory.Packages.props && \
    echo '  <PropertyGroup>' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>' >> sdk/agentserver/Directory.Packages.props && \
    echo '  </PropertyGroup>' >> sdk/agentserver/Directory.Packages.props && \
    echo '  <ItemGroup>' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="Azure.Core" Version="1.49.0" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="Azure.AI.Projects" Version="1.0.0" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="Azure.Monitor.OpenTelemetry.AspNetCore" Version="1.2.0" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="ModelContextProtocol" Version="0.4.1-preview.1" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="Microsoft.Agents.AI" Version="1.0.0-preview.251204.1" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '    <PackageVersion Include="OpenTelemetry.Exporter.OpenTelemetryProtocol" Version="1.10.0" />' >> sdk/agentserver/Directory.Packages.props && \
    echo '  </ItemGroup>' >> sdk/agentserver/Directory.Packages.props && \
    echo '</Project>' >> sdk/agentserver/Directory.Packages.props

# Copy root-level build configuration files
# The Directory.Build.props chain requires these files from repository root
COPY Directory.Build.props ./
COPY eng/Directory.Build.Common.props eng/
COPY eng/CodeAnalysis.ruleset eng/
COPY eng/AzureSDKClient.snk eng/
COPY sdk/agentserver/Directory.Build.props sdk/agentserver/
COPY sdk/agentserver/dist/samples/Directory.Build.props sdk/agentserver/dist/samples/
COPY sdk/agentserver/dist/samples/Directory.Packages.props sdk/agentserver/dist/samples/

# Copy all source projects that BasicWorkflow depends on (UseProjectReference=true)
# These are required because BasicWorkflow uses project references, not NuGet packages

# Copy Contracts project (base dependency)
COPY sdk/agentserver/Azure.AI.AgentServer.Contracts/src/ sdk/agentserver/Azure.AI.AgentServer.Contracts/src/

# Copy Core project (depends on Contracts)
COPY sdk/agentserver/Azure.AI.AgentServer.Core/src/ sdk/agentserver/Azure.AI.AgentServer.Core/src/

# Copy AgentFramework project (depends on Core)
COPY sdk/agentserver/Azure.AI.AgentServer.AgentFramework/src/ sdk/agentserver/Azure.AI.AgentServer.AgentFramework/src/

# Copy the BasicWorkflow sample application
COPY sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/ sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/

# Restore NuGet packages for the BasicWorkflow project and all its dependencies
# Disable TreatWarningsAsErrors to allow NU1604/NU1602 warnings about missing package version lower bounds
# These warnings occur because project references don't specify explicit package version bounds
# Override TargetFrameworks to build for net8.0 only (BasicWorkflow's target)
RUN dotnet restore sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj \
    /p:TreatWarningsAsErrors=false \
    /p:TargetFrameworks=net8.0

# Build the project in Release configuration for net8.0
RUN dotnet build sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj \
    -c Release \
    --no-restore \
    /p:TargetFrameworks=net8.0

# Publish the application to /app
# NOTE: The -o /app flag overrides UseArtifactsOutput=true, ensuring predictable output location
RUN dotnet publish sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/BasicWorkflow.csproj \
    -c Release \
    --no-build \
    -o /app \
    /p:TargetFrameworks=net8.0

# ============================================================================
# Runtime Stage: Create minimal runtime image
# ============================================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app .

# Expose the port the application listens on
EXPOSE 8088

# Set the entry point to run the BasicWorkflow application
ENTRYPOINT ["dotnet", "BasicWorkflow.dll"]
