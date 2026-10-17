# TypeSpec MCP tools generator prototype

`@azure-typespec/mcp-tools` generates reviewed MCP tool scaffolding from
TypeSpec HTTP operations. The schema, decorators, emitter, C# generator, and
generator tests live here. A checked-in Storage projection provides local
end-to-end validation; real service integration remains in the consuming MCP
repository.

The generator is service-neutral: service namespaces, command identities,
options, safety overrides, SDK calls, and result types are TypeSpec metadata,
not hardcoded Storage behavior. The initial consumer is the bounded
`storage blob container create` example from
[microsoft/mcp#3964](https://github.com/microsoft/mcp/pull/3964)
(original commit `53bb8567a7e31a1237b4e004e1b227eca798e2b5`).
This is not automatic coverage of every Azure API shape. Unsupported mappings
fail explicitly, and generation does not opt a consumer into generated tools.
Handwritten tools remain the default.

## Build and test

Prerequisites:

- The .NET SDK selected by the repository's `global.json` (10.0.401 or a
  compatible installed SDK).
- Node.js 22.18 or later in the 22.x line, and npm.
- PowerShell 7 for the MCP consumer's generation/comparison scripts.

From this directory:

```powershell
npm ci
npm run build
npm test
npm run lint
npm run prettier
```

Like the other C# emitter packages, TypeScript source lives under
`emitter\src`, with separate `index.ts`, `emitter.ts`, `options.ts`, and
`lib\lib.ts` entry points. Strict TypeScript compilation writes the public
entry point to `dist\emitter\index.js`. `build:emitter` and `build:generator`
build the two layers; `test:emitter` runs Vitest and `test:generator` runs the
NUnit solution. ESLint and Prettier use the same conventions as the neighboring
emitter packages.

The backend project is
`generator\Microsoft.TypeSpec.Generator.Mcp\src\Microsoft.TypeSpec.Generator.Mcp.csproj`.
Its MEF export is `McpGenerator`; its plugin is
`dist\generator\Microsoft.TypeSpec.Generator.Mcp.dll`.
The emitter selects that generator through the standard
`emitter-extension-path` contract. The build stages the pinned stock generator
host, its runtime configuration and dependencies, and the MCP extension in
`dist\generator`, like the neighboring emitter packages. Build intermediates use the
repository's `artifacts` directories and tests use centrally managed NUnit
dependencies. No MCP runtime project reference is required to build or test
this package.

The equivalent test command from the repository root is:

```powershell
dotnet test eng\packages\http-client-csharp-mcp\generator\Microsoft.TypeSpec.Generator.Mcp\test\Microsoft.TypeSpec.Generator.Mcp.Tests.csproj --configuration Release
```

The frontend, generator host, and extension must agree on the input/provider
contract: dependencies are pinned to `@typespec/http-client-csharp`
**1.0.0-alpha.20261014.5**, TypeSpec **1.17.0**, and
`@azure-tools/typespec-client-generator-core` **0.73.0**.
The backend references the generator assemblies in that npm package, not
independently versioned NuGet assemblies. This private prototype has no
publication/install contract.

## Run the checked-in Storage example

The service input is
[`emitter/test/fixtures/storage.tsp`](emitter/test/fixtures/storage.tsp), not
`lib/main.tsp`. It contains the complete reviewed container-create projection,
the selected `@tool` mapping, and the deliberately unselected get operation.
The shared `lib/main.tsp` only defines the schema/decorators used by that input.

From this package directory:

```powershell
npm ci
npm run build
npm run test:storage
```

This runs
[`StorageGenerationTests.cs`](generator/Microsoft.TypeSpec.Generator.Mcp/test/StorageGenerationTests.cs)
entirely from this repository, without an MCP checkout or Azure credentials.
The test:

1. Creates isolated temporary consumer projects and builds the two metadata
   assemblies referenced by the checked-in projection.
2. Compiles `storage.tsp` using the real pinned compiler, this built emitter,
   and the C# backend. It requires exactly the five expected generated files.
3. Compiles and executes the generated C# against explicit test doubles for the
   existing Storage SDK and MCP framework contracts. Runtime assertions cover
   private-container creation, cancellation forwarding, command registration,
   identity/description/safety, required options, and JSON serialization.
4. Compares the fresh output inventory and raw bytes against the checked-in
   results under
   [`generator/TestProjects/Local/Storage/src/Generated`](generator/TestProjects/Local/Storage/src/Generated).
5. Deletes the temporary workspace after the test.

The five checked-in C# files are actual generator output, not handwritten
examples. Normal tests verify them without modifying them. To intentionally
regenerate the checked-in results after changing the projection or generator,
run (requires PowerShell 7):

```powershell
npm run generate:storage
```

This invokes `eng\scripts\Generate.ps1`, builds the package, generates into an
isolated temporary consumer, and compiles and executes the generated code before
copying its exact bytes into the checked-in output directory. Commit the
resulting diffs; do not edit generated files manually.

The doubles test generated-code contracts, not the real Storage SDK, real MCP
host, or Azure service behavior. Fresh byte-for-byte output verification and
real consumer runtime/catalog checks remain separate MCP integration checks.
No command class or authentication workflow is generated by this example.

## Author MCP metadata in TypeSpec

[`lib/main.tsp`](lib/main.tsp) is the authoritative schema.
`@mcpService` decorates one service namespace and `@tool` decorates each selected
HTTP operation within it. Operations in different interfaces/subnamespaces can
share an output library; unselected operations do not become tools.

```typespec
using TypeSpec.Http;
using Azure.Mcp;

@service(#{ title: "Reviewed service tools" })
@server("{endpoint}", "The service endpoint.", { endpoint: url })
@mcpService(#{
  outputNamespace: "Example.Generated",
  metadataReferences: #[],
  composites: #[
    #{ path: "example resource list", reason: "Handwritten composition." }
  ],
})
namespace ExampleService;
```

Each operation's `@tool(#{ ... })` supplies the following typed configuration.
See the complete runnable, two-service example in
[`GenerationTests.cs`](generator/Microsoft.TypeSpec.Generator.Mcp/test/GenerationTests.cs)
and its metadata in
[`ManifestFixtures.cs`](generator/Microsoft.TypeSpec.Generator.Mcp/test/ManifestFixtures.cs).

| Configuration | Purpose |
| --- | --- |
| `id`, `group`, `name`, `title`, `commandType` | Stable tool GUID, command path, title, and existing command class. |
| `types` | Five distinct generated class names: catalog, options, binding, result, JSON context. |
| `wire` | Reviewed HTTP method, path, URI template, and typed constant parameters, checked against the frontend model. |
| `options` | Primitive option types, requiredness, source parameter names, and explicit descriptions for ambient options. |
| `binding` | Typed SDK parameters, explicit instance-call sequence, primitive/static-member arguments, awaited calls, and return variable. |
| `result` | Explicit result properties and existing CLR types. |
| `safety` | Reviewed destructive, idempotent, read-only, and open-world overrides; omitted flags retain conservative HTTP defaults. |
| `descriptionOverride`, `errorMessage` | Optional existing description constant and required status/detail error format. |

Operation identities are derived from their TypeSpec namespace, interface, and
operation names. Do not author an `operationId`, a JSON manifest, or a
service-specific generator subclass. Adding a service within the supported
mapping subset requires TypeSpec metadata and existing consumer types, not
generator changes.

## External-checkout invocation

The consumer supplies the .NET checkout as a runtime parameter and builds this
package first. It also builds its own source and required metadata assemblies
before generation. Missing types or references are errors, not stubbed
fallbacks. `metadataReferences` are paths relative to the emitter output root;
the consumer must include the assemblies that its existing MCP types require.

The consumer wrapper preserves its complete existing YAML configuration,
replaces `emit` with the **absolute package directory** from that checkout, and
puts the preserved C# options under the stable key
`@azure-typespec/mcp-tools`:

```yaml
emit:
  - 'C:\git\azure-sdk-for-net\eng\packages\http-client-csharp-mcp'
options:
  "@azure-typespec/mcp-tools":
    emitter-output-dir: "{project-root}/.."
    package-name: Example.Mcp.Tools
    new-project: false
    save-inputs: true
```

Preserve the consumer's license and other stock frontend settings. The emitter
forces the generic plugin and `unreferenced-types-handling: keepAll` because MCP
registration/options are externally consumed roots, not REST client dependencies.
Use the package root, not the compiled JavaScript file, as the
emitter/configuration key. An `extends`
configuration that overrides just part of the old emitter options can lose
settings; preserve the complete parsed configuration instead.

Use the **external package's compiler**, not the consumer's local `npx tsp`.
Import `lib\main.tsp` dynamically; do not put a machine-specific import or npm
file dependency in authored source. The library owns its pinned HTTP import,
so the consumer projection uses `TypeSpec.Http` without importing a second,
consumer-local `@typespec/http`. Additional TypeSpec libraries must likewise
come from the same compiler/dependency tree: equal versions in two installations
can still produce incompatible typekit registries.

Example from the consumer generation directory, with `$generatorRoot` set to
the absolute external package directory:

```powershell
$previous = $env:TYPESPEC_SKIP_COMPILER_RESOLVE
try {
    $env:TYPESPEC_SKIP_COMPILER_RESOLVE = '1'
    & node (Join-Path $generatorRoot 'node_modules\@typespec\compiler\cmd\tsp.js') `
        compile .\service.tsp --config .\resolved-tspconfig.yaml `
        --import (Join-Path $generatorRoot 'lib\main.tsp')
    if ($LASTEXITCODE -ne 0) {
        throw 'MCP tool generation failed.'
    }
}
finally {
    $env:TYPESPEC_SKIP_COMPILER_RESOLVE = $previous
}
```

The environment flag prevents TypeSpec's runner from redirecting back to the
consumer's nearest compiler. Keep its lifetime scoped to compilation.

## Output, lifecycle, and limits

The TypeSpec emitter validates metadata and delegates HTTP model construction
to the stock C# frontend. It writes `tspMcpCodeModel.json` at the emitter output
root solely as private transport for the C# backend. The emitter creates this
reserved generated file and deletes it in `finally`, including on backend
failure, unless `save-inputs: true` retains it for diagnostics. It is not
hand-authored configuration and should not be committed. Stock frontend input
files follow the same `save-inputs` policy.

For each selected operation, the backend uses existing `TypeProvider` APIs and
the C# writer to produce five files under `src\Generated`: catalog/registration
and safety metadata, options, an existing-SDK binding, a result wrapper, and an
AOT-safe JSON context. It does not generate another HTTP client or change
consumer registration/feature switches.

Supported inputs are explicitly mapped primitive method parameters
(`string`, `bool`, `int`, `long`, `float`, `double`, `decimal`) and reviewed
wire constants. Bindings support qualified, nongeneric existing CLR types,
primitive arguments including explicit null, static members, named arguments,
and typed local results. Every awaited SDK call must forward a supplied
cancellation token. SDK members and argument compatibility are ultimately
checked by compiling the generated consumer; authoring metadata does not
prove that an SDK method exists.

Ambiguous/missing selections, mismatched wire shapes or constant types, extra
parameters, unsupported parameter/type mappings, duplicate identities/output
names, paging, LROs, and unexpected generated option syntax fail explicitly.
Generic CLR type expressions, arbitrary expression snippets, automatic
authentication/endpoint resolution, and inferred SDK workflows are not supported.
Those workflows and composite tools stay handwritten.

Tests exercise two service-shaped tools, generated C# compilation, consumer-local
compiler/HTTP isolation, schema diagnostics, internal transport/null handling,
typed constant rejection, safety, and options rewriting. The consumer's own
`Generate.ps1 -Verify` must separately move aside old output, require fresh
files, and compare inventory/raw hashes so stale files cannot masquerade as
successful generation. The initial Storage example must retain its existing
five files byte-for-byte and its handwritten-by-default behavior.
