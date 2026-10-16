# Storage MCP generator prototype

This package owns the C# MCP tool generator and generator unit tests relocated
from [microsoft/mcp#3964](https://github.com/microsoft/mcp/pull/3964)
(source commit `53bb8567a7e31a1237b4e004e1b227eca798e2b5`).
It is a bounded prototype for the existing `storage blob container create` tool,
not a general Storage tool generator or another HTTP client.

The reviewed service manifest, TypeSpec operation projection, generated Storage
output, opt-in integration, and comparison scripts remain in `microsoft/mcp`.
The handwritten tool remains the default; generation does not enable
`UseGeneratedStorageTools`.

## Build and test

Prerequisites:

- The .NET SDK selected by this repository's `global.json` (10.0.401 or a
  compatible later feature band).
- Node.js 22.18 or later in the 22.x line and npm.
- PowerShell 7 for the MCP repository's generation/comparison scripts.

From this directory:

```powershell
npm ci
npm run build
npm test
```

`npm run build` builds
`generator\StorageMcp.Generator\src\StorageMcp.Generator.csproj` in Release and
copies the extension and its dependencies to `dist\generator`.
Build intermediates and binaries use the repository's `artifacts` directories.
The projects import repository build settings and use centrally managed NUnit,
NUnit3TestAdapter, and Microsoft.NET.Test.Sdk dependencies for tests.

The equivalent targeted test command, from the repository root, is:

```powershell
dotnet test eng\packages\http-client-csharp-mcp\generator\StorageMcp.Generator\test\StorageMcp.Generator.Tests.csproj --configuration Release
```

The generator deliberately references assemblies shipped with the pinned
`@typespec/http-client-csharp` npm package, rather than independently versioned
NuGet generator assemblies: the frontend, generator host, and extension must
agree on the provider/input model contract. Both repositories must use
`@typespec/http-client-csharp` **1.0.0-alpha.20261014.5** with TypeSpec **1.17.0**.
This package is private and has no publication/install contract.

## Consumer invocation contract

Build this package first. In the MCP repository, build the Storage project in
Debug, then compile its existing `generation\storage.tsp` with the stock C#
frontend. Configure the frontend with:

```yaml
emit:
  - "@typespec/http-client-csharp"
options:
  "@typespec/http-client-csharp":
    emitter-output-dir: "{project-root}/.."
    package-name: Azure.Mcp.Tools.Storage
    new-project: false
    save-inputs: true
    unreferenced-types-handling: keepAll
    generator-name: StorageMcpGenerator
    plugins:
      - 'C:\git\azure-sdk-for-net\eng\packages\http-client-csharp-mcp\dist\generator'
```

Replace the example plugin directory with the **absolute** path to the local
.NET checkout's `dist\generator`. Preserve the consumer's license configuration.
TypeSpec 1.17 does not interpolate variables inside the `plugins` array; a
consumer wrapper must supply the resolved path, for example through a temporary
configuration file, rather than placing a configuration parameter in that array.
Run `npx --no-install tsp compile storage.tsp` from the consumer's `generation`
directory using that configuration.

The emitter output directory is the MCP Storage tool root. The unchanged
extension expects:

| Input/output | Path relative to the Storage tool root |
| --- | --- |
| Reviewed manifest | `generation\storage.tools.json` |
| Prebuilt MCP metadata references | `src\bin\Debug\net10.0\Microsoft.Mcp.Core.dll`, `src\bin\Debug\net10.0\Azure.Mcp.Core.dll` |
| Existing command, model, SDK and customization types | Consumer source compilation and its references |
| Generated output | `src\Generated\*.cs` |

No MCP runtime/project reference is needed to build the generator or run its
unit tests. Real generation does require the consumer source and prerequisite
build: missing types or assemblies are errors, not stubbed fallbacks.

## Behavior and limits

The extension exports `StorageMcpGenerator` through MEF as a
`Microsoft.TypeSpec.Generator.CodeModelGenerator`. `StorageOutputLibrary`
selects the manifest operation from the stock frontend's input model and emits
five types using the existing `TypeProvider` APIs and C# writer:
catalog/registration and safety metadata, options, a private-container SDK
binding, a result wrapper, and an AOT-safe JSON context.

The original behavior is retained: required Account/Container options, optional
Tenant, no subscription option, reviewed safety overrides, the human description
override, `BlobContainerClient.CreateAsync(PublicAccessType.None)` with cancellation
forwarding, and a generic status-code error default. Authentication, endpoint
resolution, follow-up property reads, specialized errors, and output shaping
remain handwritten in the consumer.

The manifest requires exactly one reviewed container-create selection. Unsupported
bindings, ambiguous/missing selected operations, extra wire parameters, paging,
LROs, and unexpected generated option shapes fail explicitly. Account/container/blob
get-list composites remain handwritten. The unit tests preserve the original
manifest/selection/safety/options cases using synthetic consumer data; the real
reviewed manifest stays in the MCP repository. End-to-end regeneration and catalog
parity belong to the consumer's `Generate.ps1 -Verify` and `Compare.ps1` workflows.
