# Getting Started with the TypeSpec C# Generator

Welcome to the TypeSpec C# Generator project! This guide will help SDK developers understand the generator ecosystem and get started with generating .NET libraries from TypeSpec definitions.

## Table of Contents

- [Overview](#overview)
- [Generator Variants](#generator-variants)
- [Key Concepts](#key-concepts)
- [Generating a Library](#generating-a-library)
- [Resources](#resources)
- [Getting Help](#getting-help)
- [Quick Reference](#quick-reference)

## Overview

The TypeSpec C# Generator (also known as Microsoft TypeSpec Generator or MTG) is a tool that generates .NET client libraries from TypeSpec service definitions. This replaces the legacy AutoRest-based code generation pipeline and provides improved type safety, better API design, and enhanced maintainability.

## Generator Variants

There are three variants of the C# emitter, each serving different scenarios:

### 1. Unbranded Emitter (`@typespec/http-client-csharp`)

- **Purpose**: Generates unbranded HTTP client libraries
- **Repository**: [microsoft/typespec](https://github.com/microsoft/typespec/tree/main/packages/http-client-csharp)
- **Use Case**: Non-Azure services or generic HTTP APIs
- **Package.json Artifact**: `eng/http-client-csharp-emitter-package.json`

### 2. Azure Data Plane Emitter (`@azure-typespec/http-client-csharp`)

- **Purpose**: Generates Azure-branded data plane client libraries
- **Repository**: [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/packages/http-client-csharp)
- **Use Case**: Azure data plane services (e.g., Azure Storage, Cognitive Services)
- **Package.json Artifact**: `eng/azure-typespec-http-client-csharp-emitter-package.json`

### 3. Azure Management Plane Emitter (`@azure-typespec/http-client-csharp-mgmt`)

- **Purpose**: Generates Azure Resource Manager (ARM) client libraries
- **Repository**: [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/packages/http-client-csharp-mgmt)
- **Use Case**: Azure management plane services (ARM resources)
- **Package.json Artifact**: `eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`

## Key Concepts

### tsp-client

**tsp-client** is the orchestration tool that partners and build pipelines use to invoke the TypeSpec compiler and emitters.

- **Repository**: [Azure/azure-sdk-tools](https://github.com/Azure/azure-sdk-tools/tree/main/tools/tsp-client)
- **Key Behavior**: Expects a corresponding `package.json` file to install the correct emitter and compile TypeSpec definitions
- **Integration**: Automatically invoked by the .NET SDK build system when generating code

### Configuration Files

#### tspconfig.yaml

Defines the TypeSpec compilation settings and emitter configuration.

**Required Configuration for .NET Generation:**
```yaml
options:
  "@azure-typespec/http-client-csharp":
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
    namespace: Azure.Data.AppConfiguration
    model-namespace: false
```

**Key Options:**
- `emitter-output-dir`: Directory where generated code will be placed
- `namespace`: The .NET namespace for the generated client
- `model-namespace`: Whether to use a separate namespace for models (typically `false`)

#### tsp-location.yaml

Maps the library to its TypeSpec specification and emitter configuration.

**Key Properties:**
- `directory`: Path to the TypeSpec specification (typically in azure-rest-api-specs repo)
- `commit`: Git commit SHA of the spec version to use
- `repo`: Repository containing the TypeSpec specification
- `emitterPackageJsonPath`: Path to the emitter package.json artifact

**Example:**
```yaml
directory: specification/cognitiveservices/OpenAI.Inference
commit: abc123def456
repo: Azure/azure-rest-api-specs
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

#### Library .csproj Configuration

To exclude legacy AutoRest dependencies, add:

```xml
<PropertyGroup>
  <IncludeAutorestDependency>false</IncludeAutorestDependency>
</PropertyGroup>
```

> **Note**: Currently defaults to `true` for backward compatibility. Track [Issue #53148](https://github.com/Azure/azure-sdk-for-net/issues/53148) for the planned default change.

## Generating a Library

Follow these steps to generate or regenerate a .NET library from TypeSpec:

### Prerequisites

- .NET SDK installed
- Access to the TypeSpec specification (typically in azure-rest-api-specs)

### Step-by-Step Process

#### 1. Verify tspconfig.yaml Configuration

Ensure your library's `tspconfig.yaml` has the appropriate emitter options configured:

```yaml
options:
  "@azure-typespec/http-client-csharp":
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
    namespace: Azure.YourService.YourClient
    model-namespace: false
```

Replace `Azure.YourService.YourClient` with your actual .NET namespace.

#### 2. Configure tsp-location.yaml

Set the `emitterPackageJsonPath` to the appropriate artifact:

- For Azure data plane: `eng/azure-typespec-http-client-csharp-emitter-package.json`
- For Azure management plane: `eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`
- For unbranded: `eng/http-client-csharp-emitter-package.json`

**Example:**
```yaml
emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-emitter-package.json"
```

#### 3. Update .csproj File

Add the following property to exclude AutoRest dependencies:

```xml
<IncludeAutorestDependency>false</IncludeAutorestDependency>
```

#### 4. Update Spec Version (if needed)

If the TypeSpec specification has been updated, modify the `commit` field in `tsp-location.yaml` to point to the latest commit SHA:

```yaml
commit: <new-commit-sha>
```

#### 5. Run Code Generation

From the library root directory (e.g., `sdk/openai/Azure.AI.OpenAI/`), execute:

```bash
dotnet build /t:GenerateCode
```

**What Happens:**
1. tsp-client is automatically invoked by the build system
2. The correct emitter is installed based on the package.json artifact
3. TypeSpec compilation runs and generates the client code
4. Generated files are placed in the appropriate directories

#### 6. Review Generated Code

- Check the generated files for correctness
- Verify that API signatures match expectations
- Run tests to ensure functionality

#### 7. Handle Generation Errors

If errors occur during generation:

1. **Analyze the Error**: Determine if it's a TypeSpec definition issue or a generator bug
2. **Client.tsp Fixes**: Some issues can be resolved by customizing `client.tsp` (client customizations)
3. **Generator Bugs**: If a generator fix is required, log a bug in the appropriate repository:
   - Unbranded: [microsoft/typespec](https://github.com/microsoft/typespec/issues)
   - Azure branded: [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net/issues)

## Resources

### Documentation

- **MTG Contributing Guide**: [microsoft/typespec CONTRIBUTING.md](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/CONTRIBUTING.md)
- **Library Migration Inventory**: [Library_Inventory.md](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/GeneratorMigration/Library_Inventory.md)
- **TypeSpec Documentation**: [TypeSpec Official Docs](https://typespec.io/)

### Repositories

- **Unbranded Emitter**: [microsoft/typespec](https://github.com/microsoft/typespec/tree/main/packages/http-client-csharp)
- **Azure Data Plane Emitter**: [Azure/azure-sdk-for-net (http-client-csharp)](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/packages/http-client-csharp)
- **Azure Management Emitter**: [Azure/azure-sdk-for-net (http-client-csharp-mgmt)](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/packages/http-client-csharp-mgmt)
- **tsp-client Tool**: [Azure/azure-sdk-tools](https://github.com/Azure/azure-sdk-tools/tree/main/tools/tsp-client)

## Getting Help

### Support Channels

- **Teams Channel**: Code Generation - .NET
- **GitHub Issues**: File issues in the appropriate repository
  - Generator bugs: Use the repository corresponding to your emitter variant
---

## Quick Reference

### Command Cheat Sheet

```bash
# Generate code for a library
dotnet build /t:GenerateCode
```

### Configuration Quick Check

✅ **Before generating code, verify:**

- [ ] `tspconfig.yaml` has the correct emitter options configured (namespace, emitter-output-dir, etc.)
- [ ] `tsp-location.yaml` has the correct `emitterPackageJsonPath`
- [ ] `.csproj` has `<IncludeAutorestDependency>false</IncludeAutorestDependency>`
- [ ] `tsp-location.yaml` has the correct spec `commit` SHA (if updating)

---

**Welcome to the team! Happy generating! 🚀**
