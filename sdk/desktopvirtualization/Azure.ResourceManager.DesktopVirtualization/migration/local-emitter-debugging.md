# Using a Local Emitter for Debugging

When developing or debugging the emitter/generator itself (`@azure-typespec/http-client-csharp-mgmt`), you need to build it locally and point the code generation at your local build instead of the published npm package.

## Emitter Source Structure

The emitter lives at `eng/packages/http-client-csharp-mgmt/`:

```
eng/packages/http-client-csharp-mgmt/
├── package.json              # name: @azure-typespec/http-client-csharp-mgmt
├── emitter/
│   ├── src/                  # TypeScript emitter source
│   │   ├── index.ts          # entry point (exports $lib, $onEmit)
│   │   ├── emitter.ts        # main emit logic
│   │   ├── options.ts        # emitter options schema
│   │   ├── resource-detection.ts
│   │   └── ...
│   ├── tsconfig.build.json   # compiles to ../dist/emitter/
│   └── vitest.config.ts
├── generator/                # C# generator (.NET)
│   └── Azure.Generator.Management/
├── dist/
│   └── emitter/              # compiled JS output (entry: index.js)
├── node_modules/
└── eng/scripts/
    ├── RegenSdkLocal.ps1     # orchestrator for local regen
    ├── Invoke-SdkRegeneration.ps1  # per-SDK worker
    ├── Generate.ps1
    └── Generation.psm1
```

## Building the Emitter Locally

```bash
cd eng/packages/http-client-csharp-mgmt

# Install dependencies (first time only)
npm install

# Build the TypeScript emitter (compiles to dist/emitter/)
npm run build:emitter     # runs: tsc -p ./emitter/tsconfig.build.json

# Build the C# generator
npm run build:generator   # runs: dotnet build ./generator

# Or build both at once
npm run build
```

## Method A: Using `RegenSdkLocal.ps1` (Recommended)

The provided PowerShell script handles everything automatically — building, spec syncing, symlinks, and compilation:

```powershell
cd eng/packages/http-client-csharp-mgmt/eng/scripts

# Regenerate a single service
./RegenSdkLocal.ps1 -Services "DesktopVirtualization"

# Regenerate multiple services in parallel
./RegenSdkLocal.ps1 -Services "KeyVault","Compute","Network" -Parallel 8

# With debugging support (generator waits for debugger attach)
./RegenSdkLocal.ps1 -Services "DesktopVirtualization" -DebugGenerator

# Save intermediate files (tspCodeModel.json) for inspection
./RegenSdkLocal.ps1 -Services "DesktopVirtualization" -SaveInputs

# Wildcard matching
./RegenSdkLocal.ps1 -Services "Key*" -Parallel 8
```

**What `RegenSdkLocal.ps1` does internally:**

1. **Builds** the emitter (`npm run build:emitter`) and generator (`dotnet build`)
2. **Sparse-clones** the spec repo to `../sparse-spec/<projectName>` (fetches only the needed TypeSpec files)
3. **Copies** spec files into `<SDK>/TempTypeSpecFiles/`
4. **Creates a junction** from `TempTypeSpecFiles/node_modules` → `eng/packages/http-client-csharp-mgmt/node_modules` (bypasses `npm install` entirely)
5. **Runs `npx tsp compile`** with `--emit <local-mgmt-package-root>`, pointing directly at the locally-built emitter:
   ```
   npx tsp compile TempTypeSpecFiles/DesktopVirtualization/client.tsp \
     --emit eng/packages/http-client-csharp-mgmt \
     --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=<ProjectPath>"
   ```
6. **Cleans up** the junction and temporary files

## Method B: Manual `tsp compile` with Local Emitter (Bash)

For more control (e.g., on Linux where PowerShell may not be available), you can replicate the steps manually:

```bash
REPO_ROOT=/home/codespace/code/sdk
MGMT_ROOT=$REPO_ROOT/eng/packages/http-client-csharp-mgmt
PROJECT_PATH=$REPO_ROOT/sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization

# 1. Build the local emitter
cd $MGMT_ROOT
npm install        # first time only
npm run build:emitter
dotnet build ./generator/Azure.Generator.Management/src

# 2. Ensure TempTypeSpecFiles exist (sync specs first)
cd $PROJECT_PATH
dotnet build src/ /t:GenerateCode /p:SaveInputs=true
# Or if you just need to sync without generating:
# (run with SkipSync=false which is default, it will sync + generate)

# 3. Symlink node_modules so TypeSpec compiler resolves from the local package
ln -sfn "$MGMT_ROOT/node_modules" TempTypeSpecFiles/node_modules

# 4. Determine the main entry file
MAIN_TSP=TempTypeSpecFiles/DesktopVirtualization/client.tsp
if [ ! -f "$MAIN_TSP" ]; then
    MAIN_TSP=TempTypeSpecFiles/DesktopVirtualization/main.tsp
fi

# 5. Run tsp compile with the local emitter
npx tsp compile "$MAIN_TSP" \
  --emit "$MGMT_ROOT" \
  --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$PROJECT_PATH" \
  --option "@azure-typespec/http-client-csharp-mgmt.save-inputs=true"

# 6. Clean up the symlink
rm TempTypeSpecFiles/node_modules
```

**Key insight:** `--emit <path>` tells the TypeSpec compiler to load the emitter from a local directory instead of a published npm package. The compiler reads `<path>/package.json` to find the entry point (`dist/emitter/index.js`).

## Method C: Modify `emitter-package.json` to Use `file:` Path

Instead of using `tsp compile` directly, you can make `tsp-client` (and thus `dotnet build /t:GenerateCode`) use the local emitter by changing the dependency to a `file:` path:

```bash
# Edit eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json
# Change:
#   "@azure-typespec/http-client-csharp-mgmt": "1.0.0-alpha.20260210.5"
# To:
#   "@azure-typespec/http-client-csharp-mgmt": "file:packages/http-client-csharp-mgmt"

# Delete the lock file so npm resolves fresh
rm eng/azure-typespec-http-client-csharp-mgmt-emitter-package-lock.json

# Now dotnet build /t:GenerateCode will use the local emitter
cd sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization
dotnet build src/ /t:GenerateCode
```

This works because `tsp-client` copies the emitter-package.json to `TempTypeSpecFiles/package.json` and runs `npm install`, which resolves `file:` paths via standard npm resolution. The path is relative to the `eng/` directory where the emitter-package.json lives.

> **Warning:** Remember to revert the changes to the emitter-package.json and restore the lock file before committing.

## Debugging the C# Generator

The emitter supports a `debug` option that causes the .NET generator process to pause and wait for a debugger to attach:

```bash
# Via tsp compile
npx tsp compile "$MAIN_TSP" \
  --emit "$MGMT_ROOT" \
  --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$PROJECT_PATH" \
  --option "@azure-typespec/http-client-csharp-mgmt.debug=true"

# Via RegenSdkLocal.ps1
./RegenSdkLocal.ps1 -Services "DesktopVirtualization" -DebugGenerator
```

When `debug=true` is set, the emitter passes `--debug` to the `dotnet` generator process invocation. The generator will print its process ID and wait for a debugger (e.g., Visual Studio, VS Code, or `dotnet-attach`) before continuing. This lets you set breakpoints in the C# generator code at `eng/packages/http-client-csharp-mgmt/generator/`.

## Debugging the TypeScript Emitter

To debug the TypeScript emitter itself, you can use Node.js debugging:

```bash
# Run tsp compile under Node.js inspector
node --inspect-brk $(which tsp) compile "$MAIN_TSP" \
  --emit "$MGMT_ROOT" \
  --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$PROJECT_PATH" \
  --option "@azure-typespec/http-client-csharp-mgmt.save-inputs=true"
```

Then attach VS Code's JavaScript debugger (or Chrome DevTools) to the Node.js process. You can set breakpoints in the emitter source files (`eng/packages/http-client-csharp-mgmt/emitter/src/*.ts`) — the TypeScript source maps should be available since the build uses `tsc`.

## Useful Emitter Options Summary

| Option | Type | Description |
|---|---|---|
| `save-inputs` | boolean | Preserves `tspCodeModel.json` and other intermediate files for inspection |
| `debug` | boolean | Generator process waits for debugger attach |
| `emitter-output-dir` | string | Override output directory for generated code |
| `enable-wire-path-attribute` | boolean | Enables `WirePathAttribute` on model properties (default: false) |
| `use-legacy-resource-detection` | boolean | Uses legacy resource detection instead of `resolveArmResources` API (default: true) |
| `generate-test-project` | boolean | Generates a test project scaffold |
| `model-namespace` | boolean | Places models in a `.Models` sub-namespace (default: true) |

Options are passed via `--option "@azure-typespec/http-client-csharp-mgmt.<option-name>=<value>"` with `tsp compile`, or via `--emitter-options "<option-name>=<value>"` with `tsp-client`.
