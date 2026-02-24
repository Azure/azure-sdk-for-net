# Testing Local MPG Generator Changes Against a Service SDK

This document describes how to test local changes to the Management Plane Generator (MPG) against a service SDK (e.g., `Azure.ResourceManager.Peering`) without publishing a new npm package.

## Background

The normal code generation pipeline works as follows:

1. `dotnet build /t:GenerateCode` invokes `tsp-client update/generate`
2. `tsp-client` creates a temporary `TempTypeSpecFiles/` directory and runs `npm ci` to install the emitter package (`@azure-typespec/http-client-csharp-mgmt`) from the npm registry
3. The TypeSpec compiler runs the emitter, which resolves the C# generator DLL from the **npm-installed** package's `dist/generator/` directory
4. The emitter spawns `dotnet` to run `Microsoft.TypeSpec.Generator.dll` with `-g ManagementClientGenerator`
5. `TempTypeSpecFiles/` is cleaned up after generation

**Key insight:** Because the generator DLL is loaded from the npm-installed package (not from your local `eng/packages/http-client-csharp-mgmt/dist/generator/`), simply rebuilding the generator locally and re-running `dotnet build /t:GenerateCode` will **not** pick up your changes.

## How to Test Local Generator Changes

### Step 1: Build the Generator

After making changes to the generator source code, build it:

```bash
cd eng/packages/http-client-csharp-mgmt/generator
dotnet build Azure.Generator.Management/src/Azure.Generator.Management.csproj
```

The build output is automatically copied to `eng/packages/http-client-csharp-mgmt/dist/generator/` by the `CopyForNpmPackage` MSBuild target in the `.csproj`.

### Step 2: Obtain the Code Model for the Target Service SDK

The generator requires two input files in the service SDK's root directory:
- `tspCodeModel.json` — the TypeSpec code model (produced by the TypeSpec compiler + emitter)
- `Configuration.json` — generator configuration (package name, namespace, etc.)

If these files don't already exist, generate them by running the normal pipeline with `SaveInputs=true`:

```bash
cd sdk/<service-area>/<package-name>
dotnet build /t:GenerateCode /p:SaveInputs=true src/<PackageName>.csproj
```

This runs the full pipeline (using the **published** npm generator) and preserves `tspCodeModel.json` and `Configuration.json` in the project root. These files represent the TypeSpec compilation output and are independent of the C# generator — they won't change unless the TypeSpec spec or emitter changes.

### Step 3: Run the Local Generator Directly

With the code model files in place, invoke the locally-built generator directly:

```bash
cd sdk/<service-area>/<package-name>
dotnet --roll-forward Major \
  eng/packages/http-client-csharp-mgmt/dist/generator/Microsoft.TypeSpec.Generator.dll \
  . \
  -g ManagementClientGenerator
```

**Parameters:**
| Parameter | Description |
|-----------|-------------|
| `--roll-forward Major` | Allows the DLL to run on a newer .NET runtime than it was built for |
| First positional arg (`.`) | The directory containing `tspCodeModel.json` and `Configuration.json` |
| `-g ManagementClientGenerator` | Selects the management plane generator plugin |

This regenerates all files under `src/Generated/` using your locally-built generator.

### Step 4: Verify the Output

Build the service SDK to verify the generated code compiles:

```bash
dotnet build src/<PackageName>.csproj /p:RunApiCompat=false
```

> **Note:** `/p:RunApiCompat=false` skips API compatibility checks, which are expected to fail during MPG migration work. Remove this flag when you want to validate API surface compatibility.

## Complete Example

Testing a generator fix against the Peering SDK:

```bash
# 1. Build the generator with your fix
cd eng/packages/http-client-csharp-mgmt/generator
dotnet build Azure.Generator.Management/src/Azure.Generator.Management.csproj

# 2. Get the code model (only needed once, or when the TypeSpec spec changes)
cd sdk/peering/Azure.ResourceManager.Peering
dotnet build /t:GenerateCode /p:SaveInputs=true src/Azure.ResourceManager.Peering.csproj

# 3. Regenerate using the local generator
dotnet --roll-forward Major \
  ../../../eng/packages/http-client-csharp-mgmt/dist/generator/Microsoft.TypeSpec.Generator.dll \
  . \
  -g ManagementClientGenerator

# 4. Verify compilation
dotnet build src/Azure.ResourceManager.Peering.csproj /p:RunApiCompat=false
```

## Iterating on Changes

For subsequent changes, you only need to repeat steps 1, 3, and 4. The code model files are stable as long as the TypeSpec definition hasn't changed.

```bash
# Edit generator source...
# Then:
cd eng/packages/http-client-csharp-mgmt/generator
dotnet build Azure.Generator.Management/src/Azure.Generator.Management.csproj

cd sdk/peering/Azure.ResourceManager.Peering
dotnet --roll-forward Major \
  ../../../eng/packages/http-client-csharp-mgmt/dist/generator/Microsoft.TypeSpec.Generator.dll \
  . \
  -g ManagementClientGenerator

dotnet build src/Azure.ResourceManager.Peering.csproj /p:RunApiCompat=false
```

## Testing Against the Generator's Built-in Test Project

The generator also has a built-in test project at `eng/packages/http-client-csharp-mgmt/generator/TestProjects/Local/Mgmt-TypeSpec/` which already contains a `tspCodeModel.json` and `Configuration.json`. You can use this to quickly verify your changes don't regress existing scenarios:

```bash
cd eng/packages/http-client-csharp-mgmt/generator/TestProjects/Local/Mgmt-TypeSpec
dotnet --roll-forward Major \
  ../../../dist/generator/Microsoft.TypeSpec.Generator.dll \
  . \
  -g ManagementClientGenerator

# Check for unexpected diffs
git diff -- src/
```

## Why Not Just Copy the DLL to `TempTypeSpecFiles`?

You might think of copying the locally-built DLL into the npm-installed package location. This doesn't work because:

1. `TempTypeSpecFiles/` is deleted and recreated on each `tsp-client generate` run
2. Even with `SkipSync=true`, the `tsp-client generate` command reinstalls npm dependencies, overwriting the DLL
3. The `SaveInputs=true` flag preserves the code model files but not the npm packages

The direct invocation approach (Step 3) bypasses the entire npm/TypeSpec pipeline and runs only the C# generator, which is the component you're actually changing.
