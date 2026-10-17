# TypeSpec MCP tools generator prototype

`@azure-typespec/mcp-tools` generates complete MCP command adapters from existing
service TypeSpec and a small MCP-specific overlay. It does not require an SDK
call sequence, CLR option/result types, or a second HTTP definition in that
overlay. The initial example remains bounded to Storage container creation;
unselected APIs and handwritten tools remain unchanged.

## What is generated

The checked-in [`storage.tsp`](emitter/test/fixtures/storage.tsp) imports the
existing Blob Storage service and selects its actual
`Storage.Blob.Container.create` operation using `@@command`.

The operation supplies service identity/documentation and conservative HTTP
safety defaults. The overlay supplies the stable MCP ID/path/title, a typed
existing service handler, reviewed safety, and small description/error-policy
overrides. The generator uses Roslyn to infer the handler's parameter names,
primitive types, requiredness, cancellation token, and return model.

For this example the handler is the consumer's existing
`IStorageService.CreateContainer(account, container, tenant, cancellationToken)`.
It already implements authentication, sovereign-cloud endpoint validation,
private-container SDK creation, the subsequent properties read, and result
shaping. None of that workflow is newly handwritten for generation, duplicated
in TypeSpec, or guessed from the REST create response.

Four actual outputs are checked in under
[`generator/TestProjects/Local/Storage/src/Generated`](generator/TestProjects/Local/Storage/src/Generated):

| Output | Responsibility |
| --- | --- |
| `ContainerCreateCommand.cs` | Complete primary-constructor `AuthenticatedCommand<TOptions,TResult>`: metadata, injected logger/service, `ExecuteAsync`, argument/cancellation forwarding, serialization, logging, error policy/base exception handling, and nested result record. |
| `ContainerCreateOptions.cs` | Required `Account`/`Container` strings and optional nullable `Tenant`, inferred from the handler; MCP option attributes and descriptions. |
| `ContainerCreateJsonContext.cs` | Source-generated JSON metadata for the nested result, camelCase and `WhenWritingDefault`. |
| `ContainerCreateCatalog.cs` | Stable registration/path/operation identity and reviewed safety metadata. |

The command is no longer handwritten. Authentication and SDK workflows remain
in the existing service, and unusual human error messages remain in a small
optional static customization helper. The generated adapter calls that helper,
then the existing base error handling; it does not swallow failures or return
success-shaped defaults. It does not override `ResultTypeInfo`, preserving the
consumer's existing catalog/output-schema behavior.

## Build, run, and regenerate

Prerequisites:

- The .NET SDK selected by the repository's `global.json` (10.0.401 or a
  compatible installed SDK).
- Node.js 22.18 or later in the 22.x line, and npm.
- PowerShell 7 for regeneration and consumer scripts.

From this package directory:

```powershell
npm ci
npm run build
npm test
npm run lint
npm run prettier
```

Run the standalone Storage end-to-end tests:

```powershell
npm run test:storage
```

These require neither an MCP checkout nor Azure credentials. They compile the
real pinned service plus the compact overlay with the real compiler/emitter/
backend, then compile and execute the complete generated command against
explicit MCP/service test doubles. Assertions cover registration and command
metadata, inferred required/nullable options, handler arguments and cancellation,
JSON serialization/deserialization, positional-result constructor/deconstruction/
init semantics, error customization/default/base handling, and safe logging.
Two unrelated service commands also exercise XML-documentation inference without
Storage mappings. The original SDK-binding example remains a separate regression
test.

The service source is an unchanged, pinned five-file import closure from
`Azure/azure-rest-api-specs` commit
`ae348cc71f54a61f5d17472052cfef279a23db6b`, including client customizations.
See [source provenance](emitter/test/fixtures/specification/README.md). It is
existing service input, not extra MCP configuration or a rewritten projection.
In particular, the real operation has a container-scoped server URL, not the
old prototype's fabricated `/{container}` REST signature. The published Blob
.NET SDK still uses Swagger/AutoRest; this example does not claim otherwise.

Compiling the unchanged full service input with the pinned libraries produces
41 unsuppressed upstream TCGC `conflict-access-override` warnings, with no
service/compiler errors. The fixture preserves these warnings rather than
modifying the service definitions or suppressing diagnostics.

Normal tests generate fresh output, compare exact inventory/raw bytes with the
checked-in results, and never modify snapshots. Regenerate intentionally with:

```powershell
npm run generate:storage
```

`eng\scripts\Generate.ps1` builds the package and enables snapshot updates only
for that invocation. Output is copied only after generated code compiles and
executes successfully. Commit those diffs; never edit generated C# manually.
The local doubles test generated-command contracts, not live Azure or the real
SDK/MCP host. Real consumer tests and full catalog comparisons are separate.

## Compact authoring contract

[`lib/main.tsp`](lib/main.tsp) defines shared decorators, not a service.
Import an existing service, augment its namespace with `@@mcpService`, and
augment exactly the operations to expose with `@@command`.

`@mcpService` needs the generated output namespace and optional output-relative
metadata assembly references. Optional `composites` records paths/reasons for
operations that intentionally remain handwritten.

| `@command` field | Purpose |
| --- | --- |
| `id`, `path`, `title` | Stable tool GUID, space-separated command path, and display title. |
| `commandType` | Qualified generated class name ending in `Command`. Other output names are derived from this name. |
| `handler` | Existing nongeneric interface and unique public instance method (`type`/`member`). |
| `resultName` | Name of the property wrapping the handler result, such as `Container`; its CLR type is inferred. |
| `options` | Optional descriptions keyed by handler parameter name. Types and requiredness are not authored. Descriptions otherwise come from handler XML documentation or same-named service parameters. |
| `description`, `errorPolicy` | Optional existing string constant and static `string? Method(Exception)` policy. |
| `errorMessage` | Optional default Azure request-failure format with status/detail placeholders. Non-HTTP failures still use the authenticated base policy. |
| `safety` | Reviewed overrides; omitted flags retain conservative HTTP defaults. |

Commands use the MCP framework's data-plane `AuthenticatedCommand` profile.
They require a nongeneric `Task<T>` result model and exactly one final
`CancellationToken`. Options support primitive CLR strings/numbers/booleans,
including nullable optional values; non-null optional defaults, overloads,
generic/by-reference/`params` handlers, unsupported parameter/result types,
unresolved customizations, paging, and LROs are explicitly rejected.
This is not automatic conversion of every service API or discovery of SDK
workflows. The handler is an explicit reviewed policy boundary.

Selecting an original service operation does not opt inherited client-interface
aliases or other operations into MCP. The backend requires an exact unique
operation match. Missing/duplicate identities and output names are errors.
Only selected command declarations are excluded from the **in-memory**
customization compilation, preventing existing handwritten implementations
from suppressing their generated replacements. No input files are hidden,
moved, or changed by the generator.

The consumer must exclude the handwritten command from its actual build only
when opting into the generated replacement. Generation never changes feature
switches or enables generated tools. Preserve handwritten-by-default behavior.

The original low-level `@tool` schema is retained for compatibility and its
SDK-binding regression tests. That older path emits five scaffolding files and
requires explicit wire/options/call mappings. It is not the recommended
complete-command authoring surface or the Storage example.

## External-checkout invocation

Build this package and the consumer's baseline source/metadata assemblies first.
Missing handler/framework types are errors, not stubbed fallbacks. The consumer
supplies the .NET checkout at runtime; no machine-specific import or npm file
dependency is checked in.

Preserve the consumer's full C# emitter configuration/license settings, replace
`emit` with the absolute external package root, and use the stable options key:

```yaml
emit:
  - 'C:\git\azure-sdk-for-net\eng\packages\http-client-csharp-mcp'
options:
  "@azure-typespec/mcp-tools":
    emitter-output-dir: 'C:\git\mcp\tools\Azure.Mcp.Tools.Storage'
    package-name: Azure.Mcp.Tools.Storage
    new-project: false
```

Use the external package's pinned compiler, not consumer-local `npx tsp`.
Scope `TYPESPEC_SKIP_COMPILER_RESOLVE=1` to compilation and dynamically import
`lib\main.tsp`:

```powershell
& node (Join-Path $generatorRoot 'node_modules\@typespec\compiler\cmd\tsp.js') `
    compile .\storage.tsp --config .\resolved-tspconfig.yaml `
    --import (Join-Path $generatorRoot 'lib\main.tsp')
```

For external source imports, copy the overlay and unchanged pinned service
closure into an isolated `temp\consumer-<GUID>` source workspace under this
package. Set `emitter-output-dir` explicitly to the real consumer tool root.
Relative service imports then resolve this package's single pinned library
installation. Clean the temporary source workspace in `finally`. This requires
no upstream import rewrites, module-resolution hooks, or symlinks.

Equal versions in two physical TypeSpec installations can still create
incompatible typekit registries. Merely invoking the external compiler without
isolating imported libraries is insufficient. Avoid partial YAML `extends`
overrides that discard inherited options. Consumer verification must move old
output aside, require a fresh exact inventory, compare raw bytes, and restore
the old output on failure; stale files are not generation evidence.

The real MCP consumer remains a separate unpublished local branch, not a
directory provided by this .NET PR.

## Implementation

This package follows neighboring C# emitter conventions: strict TypeScript in
`emitter\src`, split emitter/generator build/test scripts, ESLint, Prettier,
Vitest, and a C# generator solution. `lib\main.tsp` loads the built
`dist\emitter\index.js`. The thin frontend delegates HTTP model construction to
stock `@typespec/http-client-csharp`.

The MEF backend is `McpGenerator` in
`generator\Microsoft.TypeSpec.Generator.Mcp\src`.
The standard `emitter-extension-path` contract uses the pinned generator host,
dependencies/runtime and `Microsoft.TypeSpec.Generator.Mcp.dll` staged under
`dist\generator`. TypeProviders generate commands/options/catalog/JSON context;
narrow Roslyn syntax adapters add required/nullable properties, primary
constructors, and nested records unsupported by the shared SDK writer.

Frontend/backend contracts are pinned to `@typespec/http-client-csharp`
**1.0.0-alpha.20261014.5**, TypeSpec **1.17.0**, and
`@azure-tools/typespec-client-generator-core` **0.73.0**. This private prototype
has no publication/install contract or MCP runtime dependency.

`tspMcpCodeModel.json` is private generated frontend/backend transport, not a
hand-authored manifest. The emitter deletes it in `finally`, including on
backend failure, unless `save-inputs: true` retains it for diagnostics. Stock
frontend input files follow the same policy.
