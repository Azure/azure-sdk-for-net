# How `dotnet build /t:GenerateCode` Works

This document describes the end-to-end code generation pipeline triggered by `dotnet build /t:GenerateCode` for the `Azure.ResourceManager.DesktopVirtualization` SDK package (and TypeSpec-based management plane packages in general).

## **Overview**

```
dotnet build /t:GenerateCode
  │
  ├── MSBuild resolves the GenerateCode target from eng/CodeGeneration.targets
  │
  ├── [1] InstallTspClient ── npm ci (installs tsp-client CLI)
  ├── [2] BuildPlugin ─────── dotnet build (builds C# post-processing plugin)
  └── [3] GenerateCode ─────── tsp-client update (syncs specs + compiles TypeSpec → C#)
           │
           ├── SYNC:  fetch TypeSpec specs from azure-rest-api-specs repo → TempTypeSpecFiles/
           └── GENERATE: compile .tsp files with emitter → src/Generated/*.cs
```

## MSBuild Target Resolution

When you run `dotnet build /t:GenerateCode` from the `src/` directory, MSBuild walks the `Directory.Build.props` / `Directory.Build.targets` import chain:

1. **`src/Azure.ResourceManager.DesktopVirtualization.csproj`** — the project file (has no GenerateCode-specific content).

2. **`Directory.Build.props`** (package root) — imports the parent `Directory.Build.props`.

3. **Repo-root `Directory.Build.props`** — detects that the package name starts with `Azure.ResourceManager`, sets `IsMgmtLibrary=true` and `IsClientLibrary=true`, imports `eng/Directory.Build.Common.props`.

4. **`eng/Directory.Build.Common.targets`** — because `IncludeAutorestDependency` is **not** set to `true` for this TypeSpec-based project, it imports:

   ```xml
   <Import Project="CodeGeneration.targets" Condition="'$(IncludeAutorestDependency)' != 'true'" />
   ```

5. **`eng/CodeGeneration.targets`** — this is where the `GenerateCode` target (and its dependencies) are defined.

## `eng/CodeGeneration.targets` in Detail

This file defines three MSBuild targets and several properties. Here is the complete logic:

### Property Setup

```xml
<!-- Detects tsp-location.yaml one level up from the src/ project directory -->
<TypeSpecInput Condition="Exists('$(MSBuildProjectDirectory)/../tsp-location.yaml')
    and $(MSBuildProjectDirectory.EndsWith('src'))">
  $(MSBuildProjectDirectory)/../tsp-location.yaml
</TypeSpecInput>

<!-- Path to the tsp-client CLI installation directory -->
<_TspClientDir>$(MSBuildThisFileDirectory)common/tsp-client</_TspClientDir>

<!-- Command to generate only (no spec sync) -->
<_TypeSpecProjectGenerateCommand>
  npm exec --prefix $(_TspClientDir) --no -- tsp-client generate --no-prompt --output-dir <package-dir>
</_TypeSpecProjectGenerateCommand>

<!-- Command to sync specs AND generate -->
<_TypeSpecProjectSyncAndGenerateCommand>
  npm exec --prefix $(_TspClientDir) --no -- tsp-client update --no-prompt --output-dir <package-dir>
</_TypeSpecProjectSyncAndGenerateCommand>
```

Optional flags are appended based on MSBuild properties:

| MSBuild Property | Flag | Purpose |
|---|---|---|
| `SaveInputs=true` | `--save-inputs` | Saves intermediate inputs (e.g., `tspCodeModel.json`) |
| `Trace=true` | `--trace ... --debug` | Enables detailed tracing for emitters |
| `TypespecAdditionalOptions` | `--emitter-options "..."` | Passes extra options to the emitter |
| `LocalSpecRepo=<path>` | `--local-spec-repo <path>` | Uses a local spec repo instead of fetching from GitHub |
| `GenerateTestProject` | appended to `TypespecAdditionalOptions` | Generates a test project scaffold |

### Target 1: `InstallTspClient`

```xml
<Target Name="InstallTspClient" Condition="'$(TypeSpecInput)' != '' AND '$(SkipTspClientInstall)' != 'true'">
  <Exec Command="npm ci --prefix $(_TspClientDir)" />
</Target>
```

Runs `npm ci` in `eng/common/tsp-client/` to install `@azure-tools/typespec-client-generator-cli` (version **0.31.0** per `eng/common/tsp-client/package.json`). This CLI tool (`tsp-client`) orchestrates spec syncing and TypeSpec compilation.

### Target 2: `BuildPlugin`

```xml
<Target Name="BuildPlugin" Condition="'$(TypeSpecInput)' != '' AND '$(SkipBuildPlugin)' != 'true'">
  <Exec Command="dotnet build $(MSBuildThisFileDirectory)packages/plugins/client/Client.Plugin/" />
</Target>
```

Builds the C# **Client.Plugin** project at `eng/packages/plugins/client/Client.Plugin/`. This plugin is a `GeneratorPlugin` that applies post-processing visitors to the generated code:

- `ModelFactoryRenamerVisitor` — renames model factory classes
- `NamespaceVisitor` — adjusts namespaces
- `ClientRequestIdHeaderVisitor` — adds `x-ms-client-request-id` header support
- `MultiPartFormDataVisitor` — handles multipart form data

The plugin DLL is loaded by the `ManagementClientGenerator` (the C# code generator) during the code emission phase.

### Target 3: `GenerateCode`

```xml
<Target Name="GenerateCode" Condition="'$(TypeSpecInput)' != ''"
        DependsOnTargets="InstallTspClient;BuildPlugin">
  <!-- If SkipSync=true, only generate (no spec fetch) -->
  <Exec Condition="'$(SkipSync)' == 'true'"
        Command="$(_TypeSpecProjectGenerateCommand) $(_SaveInputs) $(_TypespecAdditionalOptions) $(_Trace)"/>
  <!-- Default: sync specs from remote + generate -->
  <Exec Condition="'$(SkipSync)' != 'true'"
        Command="$(_TypeSpecProjectSyncAndGenerateCommand) $(_SaveInputs) $(_LocalSpecRepo) $(_TypespecAdditionalOptions) $(_Trace)"/>
</Target>
```

This runs the actual code generation. It has two modes:

- **Default (`SkipSync` not set):** Runs `tsp-client update` — syncs specs then generates.
- **`SkipSync=true`:** Runs `tsp-client generate` — generates from already-synced specs in `TempTypeSpecFiles/`.

## What `tsp-client update` Does

The `tsp-client` CLI (from `@azure-tools/typespec-client-generator-cli`) performs two phases:

### Phase 1: Sync (fetch TypeSpec specs)

1. Reads **`tsp-location.yaml`** in the package root:
   ```yaml
   directory: specification/desktopvirtualization/resource-manager/Microsoft.DesktopVirtualization/DesktopVirtualization
   commit: 0309d1e5a4d276478c7c6000d026d906f651d861
   repo: Azure/azure-rest-api-specs
   emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"
   ```

2. Clones/fetches the specified commit from the `Azure/azure-rest-api-specs` GitHub repository.

3. Copies the TypeSpec files (`.tsp`) from the specified `directory` into the local **`TempTypeSpecFiles/`** folder. For this package, that includes files like `main.tsp`, `HostPool.tsp`, `models.tsp`, etc.

4. Sets up `TempTypeSpecFiles/package.json` with the emitter dependencies (copied from the emitter package JSON).

> **With `--local-spec-repo`:** Instead of fetching from GitHub, it reads the TypeSpec files from a local clone of the spec repo. This is used during local development when you're modifying the spec.

### Phase 2: Generate (compile TypeSpec → C#)

1. Installs npm dependencies in `TempTypeSpecFiles/` (`npm install`), which includes the TypeSpec compiler and emitter packages.

2. Runs the **TypeSpec compiler** (`@typespec/compiler` v1.8.0) on the `main.tsp` entry point.

3. The compiler uses the **management emitter** (`@azure-typespec/http-client-csharp-mgmt` v1.0.0-alpha.20260210.5) to generate C# code. The emitter:

   a. Processes the TypeSpec AST into an SDK-oriented code model using `@azure-tools/typespec-client-generator-core`.

   b. Applies management-plane-specific transformations:
      - Resource detection and ARM resource mapping
      - Subscription ID parameter transformation
      - Property flattening via decorators

   c. Serializes the code model to **`tspCodeModel.json`** (~110K lines) — this is the intermediate representation that the C# generator consumes.

   d. Invokes the **`ManagementClientGenerator`** (a .NET process, part of the `@azure-typespec/http-client-csharp-mgmt` npm package + the built Client.Plugin). The generator:
      - Reads `tspCodeModel.json`
      - Generates C# source files (Resource classes, Data models, Collections, Serialization, etc.)
      - Applies the Client.Plugin visitors for post-processing
      - Applies `Configuration.json` settings (namespace, package name, license)
      - Writes output to **`src/Generated/`**

## Emitter Configuration

The emitter is configured through two files:

### `eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`

Defines the emitter package and all TypeSpec compiler dependencies:

```json
{
  "main": "dist/src/index.js",
  "dependencies": {
    "@azure-typespec/http-client-csharp-mgmt": "1.0.0-alpha.20260210.5"
  },
  "devDependencies": {
    "@typespec/compiler": "1.8.0",
    "@azure-tools/typespec-azure-resource-manager": "0.64.0",
    "@azure-tools/typespec-client-generator-core": "0.64.4",
    ...
  }
}
```

### `TempTypeSpecFiles/DesktopVirtualization/tspconfig.yaml`

Contains per-service emitter options (comes from the spec repo):

```yaml
options:
  "@azure-typespec/http-client-csharp-mgmt":
    emitter-output-dir: "{output-dir}/sdk/desktopvirtualization/{namespace}"
    namespace: "Azure.ResourceManager.DesktopVirtualization"
```

## Output

The final output of `dotnet build /t:GenerateCode` is the set of C# files in `src/Generated/`, including:

- **Resource classes** (`HostPoolResource.cs`, `VirtualWorkspaceResource.cs`, etc.)
- **Data models** (`HostPoolData.cs`, `SessionHostData.cs`, etc.)
- **Collection classes** (`HostPoolCollection.cs`, etc.)
- **Serialization code** (`*.Serialization.cs`)
- **Model factory** (`ArmDesktopVirtualizationModelFactory.cs`)
- **Extension methods** (`DesktopVirtualizationExtensions.cs`, `MockableDesktopVirtualization*.cs`)
- **REST operation classes** and other infrastructure

These files should **not** be manually edited. Customizations go in sibling files outside `Generated/` or in `Customize/` directories (backed up in `bak/Customize/`).

## Common Invocation Variants

```bash
# Default: sync specs from remote repo + generate
dotnet build /t:GenerateCode

# Generate from already-synced TempTypeSpecFiles (faster, no network)
dotnet build /t:GenerateCode /p:SkipSync=true

# Save intermediate inputs (tspCodeModel.json etc.) for debugging
dotnet build /t:GenerateCode /p:SaveInputs=true

# Use a local clone of azure-rest-api-specs instead of fetching from GitHub
dotnet build /t:GenerateCode /p:LocalSpecRepo=/path/to/azure-rest-api-specs

# Enable trace/debug logging from emitters
dotnet build /t:GenerateCode /p:Trace=true

# Pass additional emitter options
dotnet build /t:GenerateCode /p:TypespecAdditionalOptions="option1=value1"

# Skip rebuilding the plugin (if already built)
dotnet build /t:GenerateCode /p:SkipBuildPlugin=true

# Skip reinstalling tsp-client (if already installed)
dotnet build /t:GenerateCode /p:SkipTspClientInstall=true
```

See [local-emitter-debugging.md](local-emitter-debugging.md) for instructions on building and using a local emitter for debugging purposes.

## File Layout Reference

```
Azure.ResourceManager.DesktopVirtualization/
├── tsp-location.yaml                  # Points to spec repo, commit, and emitter package
├── Configuration.json                  # Package-level config (namespace, license)
├── tspCodeModel.json                   # Intermediate code model (generated, ~110K lines)
├── TempTypeSpecFiles/                  # Synced TypeSpec spec files
│   ├── package.json                   # Emitter package dependencies
│   └── DesktopVirtualization/         # The actual .tsp files
│       ├── main.tsp                   # Entry point
│       ├── tspconfig.yaml             # Emitter options
│       ├── models.tsp, HostPool.tsp, ...
│       └── ...
├── src/
│   ├── Azure.ResourceManager.DesktopVirtualization.csproj
│   └── Generated/                     # ← OUTPUT: all generated C# files go here
│       ├── HostPoolResource.cs
│       ├── HostPoolData.cs
│       ├── ...Serialization.cs
│       └── ...
└── bak/Customize/                     # Backup of customization files
```

## Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────────┐
│                    dotnet build /t:GenerateCode                     │
│                   (eng/CodeGeneration.targets)                      │
└─────────────┬──────────────────┬──────────────────┬─────────────────┘
              │                  │                  │
      ┌───────▼───────┐  ┌──────▼───────┐  ┌───────▼────────┐
      │ InstallTspClient│  │ BuildPlugin  │  │  GenerateCode  │
      │   npm ci       │  │ dotnet build │  │  tsp-client    │
      │   (tsp-client) │  │ (Client.Plugin)│ │  update        │
      └───────┬────────┘  └──────┬───────┘  └───────┬────────┘
              │                  │                  │
              └──────────────────┴────────┬─────────┘
                                          │
                           ┌──────────────▼──────────────┐
                           │     tsp-client update       │
                           │  (@azure-tools/typespec-     │
                           │   client-generator-cli)     │
                           └──────┬──────────────┬───────┘
                                  │              │
                        ┌─────────▼───┐   ┌──────▼──────────────┐
                        │   SYNC      │   │     GENERATE        │
                        │ Fetch .tsp  │   │ TypeSpec compiler    │
                        │ from specs  │   │ + mgmt emitter      │
                        │ repo into   │   │ + C# generator      │
                        │ TempTypeSpec│   │ + Client.Plugin      │
                        │ Files/      │   │ → src/Generated/*.cs │
                        └─────────────┘   └─────────────────────┘
```
