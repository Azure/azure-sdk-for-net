# Azure SDK for .NET - AI Agent Guidelines

This document provides guidelines for AI agents (e.g., GitHub Copilot, MCP-based assistants, LLM-based tools) working with the Azure SDK for .NET repository. It defines safe and effective patterns for agent interactions with this codebase, automation workflows, and development processes.

## Repository Overview

### Purpose and Scope

The Azure SDK for .NET repository contains:
- **Client Libraries**: SDKs for interacting with Azure services at application runtime
- **Management Libraries**: SDKs for provisioning and managing Azure resources
- **Code Generators**: Tools that generate Azure Data Plane and Management Plane SDKs
- **Build Infrastructure**: Common engineering systems and tooling for SDK development

### Repository Structure

```
/sdk                          # Individual Azure service SDKs
/eng/packages/http-client-csharp      # Azure Data Plane SDK generator
/eng/packages/http-client-csharp-mgmt # Azure Management Plane SDK generator
/eng                          # Build, test, and automation infrastructure
/doc                          # Documentation
```

For detailed developer instructions, see [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

## Agent Interaction Guidelines

### Supported Agent Actions

AI agents may assist with the following activities:

#### Code Development
- **Reading and Understanding Code**: Navigating source files, understanding SDK patterns, and explaining implementations
- **Code Generation Support**: Assisting with SDK code generation using AutoRest and TypeSpec
- **Test Creation**: Writing unit tests and integration tests following existing patterns
- **Bug Fixes**: Identifying and fixing issues in SDK code
- **API Review**: Preparing code for API reviews and ensuring adherence to design guidelines

#### Documentation
- **README Updates**: Improving SDK documentation and code samples
- **Code Comments**: Adding inline documentation
- **Migration Guides**: Creating guides for breaking changes

#### Automation and Workflows
- **Build Verification**: Running builds and interpreting results
- **Test Execution**: Running test suites and analyzing failures
- **PR Triage**: Summarizing changes and checking CI status
- **Issue Analysis**: Interpreting bug reports and feature requests

### Safety Boundaries

AI agents **must not**:

- **Commit Secrets**: Never commit credentials, API keys, or sensitive configuration
- **Bypass Security**: Skip security checks or modify security-critical code without human review
- **Auto-merge PRs**: Merge pull requests without proper human approval
- **Modify CI/CD Pipelines**: Change GitHub Actions workflows without explicit permission
- **Delete Test Coverage**: Remove or disable existing tests
- **Break API Compatibility**: Introduce breaking changes in GA libraries without explicit design approval

AI agents **should be cautious** when:

- Modifying generated code (prefer updating code generators instead)
- Making changes to shared infrastructure in `/eng`
- Updating package dependencies (requires dependency management approval)
- Changing public APIs (requires API review)

## Key Workflows

### Building and Testing

#### Client Libraries

```powershell
# Build a specific service
cd sdk/eventhub
dotnet build

# Run tests (skip live tests)
dotnet test --filter TestCategory!=Live

# Build and test via service.proj
dotnet build eng/service.proj /p:ServiceDirectory=eventhub
dotnet test eng/service.proj /p:ServiceDirectory=eventhub --filter TestCategory!=Live
```

#### Management Libraries

```powershell
# Build a specific management library
msbuild eng/mgmt.proj /p:scope=Compute

# Run tests
msbuild eng/mgmt.proj /t:RunTests /p:scope=Compute

# Create NuGet package
msbuild eng/mgmt.proj /t:CreateNugetPackage /p:scope=Compute
```

#### Full Repository Build

```powershell
# Build entire repository
dotnet build build.proj

# Build specific scope
dotnet build build.proj /p:Scope=servicebus
```

### Code Generation

#### Data Plane SDK Generation (AutoRest)

```powershell
# Generate code for a data plane SDK
cd sdk/<service>/<project>/src
dotnet build /t:GenerateCode
```

#### Azure Generator (TypeSpec)

```powershell
# Install dependencies
cd eng/packages/http-client-csharp
npm install

# Generate test projects
./eng/scripts/Generate.ps1
```

#### Azure Management Generator

```powershell
# Install dependencies
cd eng/packages/http-client-csharp-mgmt
npm install

# Generate test projects
./eng/scripts/Generate.ps1
```

### API Review and Public API Changes

When making public API changes:

```powershell
# Export API for review
eng/scripts/Export-API.ps1 <service-directory>

# Example
eng/scripts/Export-API.ps1 tables
```

This generates API listing files in the format: `sdk/<service>/<project>/api/<project>.<framework>.cs`

### Updating Code Snippets

```powershell
# Update snippets in markdown documentation
eng/scripts/Update-Snippets.ps1 <service-directory>

# Example
eng/scripts/Update-Snippets.ps1 keyvault
```

### SDK Release Workflows

#### Check Package Release Readiness

```powershell
# Verify package is ready for release
# Checks: API review status, changelog, package name approval, release date
CheckPackageReleaseReadiness -PackageName <package-name>
```

#### Release Package

```powershell
# Trigger release pipeline
ReleasePackage -PackageName <package-name> -Language dotnet
```

#### Prepare Release

```powershell
# Update version and changelog for release
./eng/common/scripts/Prepare-Release.ps1 <PackageName> [<ServiceDirectory>] [<ReleaseDate>]
```

## Development Prerequisites

### Required Tools

- **Visual Studio 2022** (Community or higher) with latest updates
- **.NET 9.0.102 SDK** (or higher within 9.0.* band)
- **PowerShell 7+** for scripts and code generation
- **Node.js 22.x.x** for TypeSpec and code generation
- **Git** with proper line ending configuration

### Configuration

#### Line Endings
- **Windows**: `core.autocrlf=true` (Checkout Windows-style, commit Unix-style)
- **Linux/macOS**: `core.autocrlf=input` (Checkout as-is, commit Unix-style)

#### Path Length (Windows)
Clone to short paths (e.g., `C:\git`) to avoid 260-character path limit. Paths in the repo are kept under 210 characters.

## Common Patterns and Conventions

### Package Naming

- **Client Libraries**: `Azure.<ServiceCategory>.<ServiceName>` (e.g., `Azure.Storage.Blobs`)
- **Management Libraries**: `Azure.ResourceManager.<ResourceProvider>` (e.g., `Azure.ResourceManager.Compute`)
- **Legacy Libraries**: `Microsoft.Azure.*` (previous generation)

### Target Frameworks

- **Client Libraries**: Use `$(RequiredTargetFrameworks)` from `eng/Directory.Build.Data.props`
- **Management Libraries**: Use `$(SdkTargetFx)` from `AzSdk.reference.props`

### Dependency Management

Package versions are centrally managed in `eng/Packages.Data.props`. When adding dependencies:
1. Ensure an `<Update>` reference with version exists in `Packages.Data.props`
2. Add `<Include>` reference without version in your `.csproj`
3. Contact azuresdkengsysteam@microsoft.com for version changes

### Testing Standards

- **Unit Tests**: Required for all code changes
- **Live Tests**: Should be recorded using Azure.Core.TestFramework
- **Test Categories**: Use `TestCategory!=Live` filter to skip live tests
- **Code Coverage**: Run with `/p:CollectCoverage=true`

## SDK-Specific Automation

### Continuous Integration

- **Client Libraries**: `sdk/service/ci.yml` files define CI for each service
- **Management Libraries**: `sdk/resourcemanager/ci.mgmt.yml` for management plane
- **CI Updates**: Run `eng/scripts/Update-Mgmt-CI.ps1` after adding management libraries

### API Compatibility Verification

GA libraries use ApiCompat tool to enforce API compatibility:
- Set `ApiCompatVersion` property to last GA version
- Tool automatically verifies no breaking changes on build
- Breaking changes fail CI for GA libraries

### Generated Code

- Generated code resides in `Generated/` folders
- Customizations go in `Customizations/` folders
- Use `generate.cmd` or `generate.ps1` to regenerate
- **Never manually edit generated code** - fix the generator or add customizations

### Source Link and Debugging

Libraries have source link enabled:
- Enable Microsoft Symbol Servers in Visual Studio
- Disable "Just My Code" to step into SDK code
- Useful for debugging Azure.Core and other dependencies

## Agent-Specific Tools and MCP

### MCP Server Requirements

To use MCP (Model Context Protocol) tool calls:
- **PowerShell must be installed** ([Installation Guide](https://learn.microsoft.com/powershell/scripting/install/installing-powershell))
- Restart IDE after installation to use MCP server

### Available MCP Tools

- `CheckPackageReleaseReadiness`: Verify package release readiness
- `ReleasePackage`: Trigger package release pipeline
- `azsdk_package_generate_code`: Generate SDK from TypeSpec locally
- `azsdk_package_build_code`: Build/compile SDK locally

See [eng/common/instructions/azsdk-tools/](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/instructions/azsdk-tools/) for detailed tool documentation.

## Additional Resources

### Key Documentation

- **[CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md)**: Complete contribution guide
- **[README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/README.md)**: Repository overview and getting started
- **[Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet/guidelines/)**: Design principles
- **[Versioning](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Versioning.md)**: Versioning strategy
- **[Breaking Change Rules](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md)**: Breaking change policy

### Agent Instructions

This repository includes agent-specific instructions in `.github/copilot-instructions.md` for GitHub Copilot integration. For the most current Copilot-specific guidance, refer to:

**[.github/copilot-instructions.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/copilot-instructions.md)**

### Community and Support

- **GitHub Issues**: [Report bugs or request features](https://github.com/Azure/azure-sdk-for-net/issues/new/choose)
- **Stack Overflow**: Tag questions with `azure` and `.net`
- **Gitter Chat**: [azure/azure-sdk-for-net](https://gitter.im/azure/azure-sdk-for-net)

## Security and Privacy

### Reporting Security Issues

**Never** open public GitHub issues for security vulnerabilities. Report privately to:
- **Email**: secure@microsoft.com
- **MSRC Portal**: [https://www.microsoft.com/msrc/faqs-report-an-issue](https://www.microsoft.com/msrc/faqs-report-an-issue)

### Data Collection and Telemetry

The Azure SDK collects telemetry by default:
- Disable per-client: Set `IsTelemetryEnabled=false` in client options
- Disable globally: Set environment variable `AZURE_TELEMETRY_DISABLED=true`
- See [Telemetry Guidelines](https://azure.github.io/azure-sdk/general_azurecore.html#telemetry-policy)

## Code of Conduct

This project follows the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).

For questions, contact [opencode@microsoft.com](mailto:opencode@microsoft.com).

## License

This repository is licensed under the MIT License. See [LICENSE.txt](https://github.com/Azure/azure-sdk-for-net/blob/main/LICENSE.txt).

---

**Note**: This document follows the [AGENTS.md](https://agents.md) standards for AI agent documentation in open source repositories.
