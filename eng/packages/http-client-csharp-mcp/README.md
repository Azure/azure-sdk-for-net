# TypeSpec MCP tools generator prototype

`@azure-typespec/mcp-tools` generates complete MCP command adapters from existing
service TypeSpec. TypeSpec describes the service and reviewed MCP metadata, not
C# types, assembly paths, SDK statements, or a second HTTP projection.
The example remains bounded to Storage container creation; unselected APIs and
handwritten tools remain unchanged.

## TypeSpec authoring

[`storage.tsp`](emitter/test/fixtures/storage.tsp) imports the unchanged upstream
Blob Storage service and augments its actual `Storage.Blob.Container.create`
operation:

```typespec
@@tool(
  Storage.Blob.Container.create,
  "f5088334-e630-4df0-a5be-ac87787acad0",
  "storage blob container create",
  "Create Storage Blob Container"
);
@@destructive(Storage.Blob.Container.create);
@@idempotent(Storage.Blob.Container.create, false);
@@readOnly(Storage.Blob.Container.create, false);
@@openWorld(Storage.Blob.Container.create, false);
```

`@tool` takes the stable ID, command path, and optional title. An omitted title
uses the existing operation's `@summary`, then its name. The four focused safety
decorators accept an optional boolean (default `true`); omitted annotations keep
conservative HTTP defaults.

The existing `@service` supplies service ownership. There is no separate service
configuration decorator, anonymous configuration object, output namespace, type
name, handler/member reference, or DLL path in the overlay.
[`lib/main.tsp`](lib/main.tsp) contains only these five decorator declarations.
The old SDK-binding schema, providers, and `sdk-binding.tsp` are removed rather
than retained under another name.

The standard-formatted overlay is 14 lines and the entire shared TypeSpec library
is 26 lines: **40 MCP-authored TypeSpec lines including the library**, not just
the sample, versus 139 generated C# lines. Tests compare both total physical
lines and non-whitespace size, and reject additional parallel mapping fixtures.

## .NET generation conventions

The backend derives output from the operation's TypeSpec namespace, interface,
and name. `Storage.Blob.Container.create` produces these four actual files in
namespace **`Storage.Blob`**:

| Output | Responsibility |
| --- | --- |
| `ContainerCreateCommand.cs` | Complete primary-constructor `AuthenticatedCommand<TOptions,TResult>`, metadata, dispatch, serialization, safe logging, error handling, and nested positional result record. |
| `ContainerCreateOptions.cs` | Required/nullable primitive options and descriptions inferred from existing typed source. |
| `ContainerCreateJsonContext.cs` | Source-generated JSON metadata, camelCase and `WhenWritingDefault`. |
| `ContainerCreateCatalog.cs` | Stable registration, path, operation identity, and reviewed safety. |

See [the checked-in results](generator/TestProjects/Local/Storage/src/Generated).
The command does not override `ResultTypeInfo`, preserving the current
consumer's catalog/output-schema behavior.

Generated names are `<Interface><Operation>Command/Options/Catalog/JsonContext`
in PascalCase. Standalone operations use just their operation name. Every
selected operation must belong to the same existing service; nested operation
namespaces are retained. Colliding output filenames, including case-only
collisions, are errors.

The backend looks for exactly one source-interface method named
`<Operation><Interface>` or that name plus `Async`. For the example, this is the
existing `IStorageService.CreateContainer(account, container, tenant, token)`.
The interface's name/namespace are not authored in TypeSpec. Zero matches,
multiple interfaces/overloads, or both suffix variants are explicit errors,
not guessed bindings.

Roslyn infers parameter names/types/nullability, cancellation, and the result
model. The nested positional result property uses the interface name, or the
handler result model name for a standalone operation. Commands require
`Task<T>` with a nonnullable nongeneric result and exactly one final
`CancellationToken`. Primitive string/numeric/boolean options, including nullable
optional values, are supported. Generic/by-reference/`params` handlers,
unsupported types/defaults, paging, and LROs are rejected.

Option descriptions come from handler XML `<param>` documentation, then
same-named service parameters. An optional unique static source class named
`<Interface><Operation>Customization` supplies normal .NET customizations:

- Accessible string constants `Description` and `<Parameter>Description`
  override command/option descriptions.
- `static string? GetErrorMessage(Exception)` preserves service-specific human
  error guidance, falling back to the authenticated base policy on `null`.
- Optional string constant `DefaultErrorMessage` formats an Azure request
  failure using `{0}` for HTTP status and `{1}` for its message.

These existing-source conventions are optional and type/accessibility checked.
No execution statements or CLR binding configuration are moved to another
manifest. The existing service remains the policy boundary: tenant/credential
resolution, validated sovereign endpoints, private creation, properties reads,
and result shaping are not inferred from REST or reimplemented by this generator.

### Metadata and opt-in

Build the consumer baseline before generation. The backend evaluates its sole
`src\*.csproj` using `dotnet msbuild -getProperty:TargetDir` and references the
built `Microsoft.Mcp.Core.dll` and, when present, `Azure.Mcp.Core.dll` itself.
There is no target-framework/configuration-specific DLL path in TypeSpec.
Missing projects/build outputs/framework types fail explicitly. This prototype
requires an existing single-target consumer project.

Only the selected generated command declarations are excluded from the
**in-memory** customization compilation. No input source files are hidden,
moved, or edited. The consumer must exclude its handwritten implementation from
its real build only when opting into the generated replacement. Generation
does not change feature switches; handwritten remains the default.

## Build, test, and regenerate

Prerequisites are the repository-selected .NET SDK (10.0.401 or compatible),
Node.js 22.18+ in the 22.x line, npm, and PowerShell 7 for regeneration.
From this package directory:

```powershell
npm ci
npm run build
npm test
npm run lint
npm run prettier
npm run test:storage
```

Tests compile the real pinned service with the actual frontend/backend, then
compile and execute the generated command against explicit MCP/service doubles.
They cover metadata, naming, reference discovery, handler arguments/cancellation,
required/nullable options, positional-record/JSON roundtrips, registration,
safe logging, and custom/default/base error handling. Unrelated service commands,
ambiguous/unsupported mappings, compiler isolation, and transport cleanup have
separate coverage. Doubles are not live Azure or real MCP runtime validation.

Normal tests generate fresh output and compare exact inventory/raw bytes
without modifying snapshots. Intentionally regenerate with:

```powershell
npm run generate:storage
```

`eng\scripts\Generate.ps1` builds, generates, compiles, and executes before copying
the actual output to the checked-in directory. Commit generated diffs; never
edit generated C# by hand.

The five unchanged service files are the complete relative import closure from
`Azure/azure-rest-api-specs@ae348cc71f54a61f5d17472052cfef279a23db6b`, including
client customizations. See [provenance](emitter/test/fixtures/specification/README.md).
These much larger pre-existing API definitions are explicitly not counted as
new MCP authoring. SHA256 tests prevent modifying them to accommodate generation.
Their pinned compilation produces 41 unsuppressed upstream TCGC
`conflict-access-override` warnings, with no service/compiler errors.
The published Blob .NET SDK still uses Swagger/AutoRest, not this TypeSpec.

## External checkout

The real MCP consumer is a separate unpublished local branch, not a directory
supplied by this PR. Supply this checkout at runtime, build this package and the
consumer baseline, and preserve the consumer's complete C# configuration/license:

```yaml
emit:
  - 'C:\git\azure-sdk-for-net\eng\packages\http-client-csharp-mcp'
options:
  "@azure-typespec/mcp-tools":
    emitter-output-dir: 'C:\git\mcp\tools\Azure.Mcp.Tools.Storage'
    package-name: Azure.Mcp.Tools.Storage
    new-project: false
```

Invoke this package's pinned compiler with scoped
`TYPESPEC_SKIP_COMPILER_RESOLVE=1` and dynamically import `lib\main.tsp`.
Stage unchanged service imports and overlay under an isolated
`temp\consumer-<GUID>` workspace in this package, with `emitter-output-dir`
explicitly pointing to the actual consumer. Clean staging in `finally`.
This keeps one physical pinned library installation without rewriting imports,
module-resolution hooks, symlinks, or tracked machine-specific dependencies.
Equal versions in two installations can still break typekit registries.

Verification must move old output aside, require all fresh files, compare raw
inventory/bytes, and restore old output on failure. Stale files or partial YAML
`extends` overrides are not valid generation evidence.

## Implementation

The package follows neighboring emitter conventions: strict TypeScript,
standard entry points/options, split build/test scripts, ESLint/Prettier/Vitest,
and a generator solution. The frontend delegates HTTP model construction to
stock `@typespec/http-client-csharp`. The `McpGenerator` MEF extension uses
TypeProviders and narrow Roslyn syntax adapters for required/nullable options,
primary constructors, and positional records.

The standard `emitter-extension-path` stages the pinned generator host and
dependencies under `dist\generator`. Dependencies are pinned to
`@typespec/http-client-csharp` **1.0.0-alpha.20261014.5**, TypeSpec **1.17.0**,
and TCGC **0.73.0**. No MCP runtime package is linked into the generator.
This private prototype has no publication/install contract.

`tspMcpCodeModel.json` is private generated transport containing service/tool
identity, not an authored manifest. The emitter deletes it in `finally`, even
after backend failure, unless `save-inputs` retains it for diagnostics.
