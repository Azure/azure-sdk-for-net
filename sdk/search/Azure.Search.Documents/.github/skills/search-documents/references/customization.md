# Azure.Search.Documents — Customization Reference

## Contents
- [TypeSpec vs. C# decision table](#when-to-customize-in-typespec-vs-c)
- [TypeSpec client.tsp decorator reference](#typespec-clienttsp-decorator-reference)
- [C# customization attributes](#c-customization-attributes)
- [Common C# patterns](#common-c-patterns)
- [Service version customizations](#service-version-customizations)
- [SearchModelFactory customizations](#searchmodelfactory-customizations)
- [Identifying what needs updating after regeneration](#identifying-what-needs-updating-after-regeneration)
- [Efficient update patterns](#efficient-update-patterns)

**Related:** [architecture.md](./architecture.md) — source layout, generated-vs-custom file mapping, backward compat rules

---

## When to Customize in TypeSpec vs. C#

| Change | Where |
|---|---|
| Rename type/property/operation for all languages | TypeSpec `client.tsp` → `@@clientName` ([renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/)) |
| Change access (public → internal) for all languages | TypeSpec `client.tsp` → `@@access` ([methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)) |
| Control model usage (input/output/both) | TypeSpec `client.tsp` → `@@usage` ([methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)) |
| Toggle protocol/convenience method generation | TypeSpec `client.tsp` → `@@protocolAPI` / `@@convenientAPI` ([methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)) |
| Restructure client hierarchy (split/merge clients) | TypeSpec `client.tsp` → `@client` / `@operationGroup` ([clients](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/)) |
| Move operations between clients | TypeSpec `client.tsp` → `@@clientLocation` ([clients](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/)) |
| Add/remove/reorder method parameters | TypeSpec `client.tsp` → `@@override` + transform fns ([methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)) |
| Elevate parameter to client-level init | TypeSpec `client.tsp` → `@@clientInitialization` ([clients](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/)) |
| HEAD → boolean response | TypeSpec `client.tsp` → `@responseAsBool` ([methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)) |
| Override client documentation | TypeSpec `client.tsp` → `@clientDoc` ([types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/)) |
| Move model to different namespace | TypeSpec `client.tsp` → `@@clientNamespace` ([types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/)) |
| Extend API version enum beyond spec | TypeSpec `client.tsp` → `@@clientApiVersions` ([versioning](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/10versioning/)) |
| Force/disable paging behavior | TypeSpec `client.tsp` → `@markAsPageable` / `@disablePageable` ([paging](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/05pagingoperations/)) |
| Force LRO behavior | TypeSpec `client.tsp` → `@markAsLro` ([LRO](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/06longrunningoperations/)) |
| Multi-layer discriminator hierarchy | TypeSpec `client.tsp` → `@hierarchyBuilding` ([hierarchy](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/11hierarchybuilding/)) |
| Reference external type from another package | TypeSpec `client.tsp` → `@alternateType` ([types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/)) |
| Pass language-specific emitter options | TypeSpec `client.tsp` → `@clientOption` ([options](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/12clientoptions/)) |
| Language-specific convenience constructor | C# customization |
| Wrap raw string as typed value (`Uri`, `ETag`, `IList<string>`) | C# customization |
| Suppress a generated constructor to replace it | C# `[CodeGenSuppress]` |
| Add semantic helpers (`FieldBuilder`, `SearchFilter`) | C# only |
| Backward compat for removed type | C# (restore deleted file — see [architecture.md](./architecture.md#backwards-compatibility-for-removed-api-version-types)) |

> **Rule**: Prefer TypeSpec `client.tsp` when the change applies cross-language. Use C# customization only for language-specific behavior or things TypeSpec decorators cannot express.

---

## TypeSpec client.tsp Decorator Reference

All `client.tsp` customizations use augment decorators (`@@`) in a file alongside `main.tsp`. Import `@azure-tools/typespec-client-generator-core` and `using Azure.ClientGenerator.Core;`.

> Full docs with C#-specific examples: [How to generate client libraries](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/00howtogen/)

### Clients — restructuring the client tree

| Decorator | Purpose | Docs |
|---|---|---|
| `@client` | Define a custom client (replaces default hierarchy) | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@operationGroup` | Group operations into a sub-client | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@@clientLocation` | Move an operation to a different client/sub-client | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@@clientName` | Rename a client | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@@clientNamespace` | Move a client to a different SDK namespace | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@@clientInitialization` | Elevate params to client ctor; control sub-client init | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |
| `@paramAlias` | Rename an elevated client init parameter | [03client](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/) |

### Methods — controlling generated operations

| Decorator | Purpose | Docs |
|---|---|---|
| `@@convenientAPI(op, bool)` | Toggle convenience method generation | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@@protocolAPI(op, bool)` | Toggle protocol method generation | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@@access(op, "internal")` | Make a method internal/private | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@@usage(model, Usage.input\|output)` | Force a model's usage direction | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@@override(op, customOp)` | Replace method signature (params, return type) | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@responseAsBool` | HEAD ops return `bool` (2xx→true, 404→false) | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |
| `@@clientLocation(param, op)` | Move a parameter from client to operation level | [04method](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/) |

#### `@@override` transformation functions (experimental, chainable)

| Function | Purpose |
|---|---|
| `replaceParameter(op, "name", NewModel.prop)` | Make param required, change type, etc. |
| `removeParameter(op, "name")` | Remove an optional parameter |
| `addParameter(op, NewModel.prop)` | Add a new parameter |
| `reorderParameters(op, #["c","a","b"])` | Reorder method parameters |

Chain via aliases: `alias step1 = replaceParameter(...); alias step2 = removeParameter(step1, ...); @@override(op, step2);`

Scope to one language: `@@override(op, customOp, "csharp");`

### Renaming — types, properties, operations, parameters

| Decorator | Purpose | Docs |
|---|---|---|
| `@@clientName(Type, "NewName")` | Rename model/enum/union for all languages | [09renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/) |
| `@@clientName(Type, "NewName", "csharp")` | Rename for C# only | [09renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/) |
| `@@clientName(Type.prop, "newProp")` | Rename a property | [09renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/) |
| `@@clientName(op, "NewOp")` | Rename an operation | [09renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/) |
| `@@clientName(op::parameters.p, "newP")` | Rename an operation parameter | [09renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/) |

> If the name comes from `@@clientName`, emitters do **not** apply language casing rules (e.g., PascalCase for C#).

### Types — models, enums, documentation

| Decorator | Purpose | Docs |
|---|---|---|
| `@@clientNamespace(Model, "New.Namespace")` | Move model/enum to a different SDK namespace | [08types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/) |
| `@clientDoc("...", DocumentationMode.replace)` | Override doc comment for SDK consumers | [08types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/) |
| `@alternateType({...}, "csharp")` | Use an external package type instead of generated | [08types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/) |
| `@clientDefaultValue(value)` | Legacy: set client default for property/param | [08types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/) |
| `@flattenProperty` | Legacy: flatten nested model properties | [08types](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/08types/) |
| `@hierarchyBuilding(ParentModel)` | Legacy: multi-level discriminator inheritance | [11hierarchy](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/11hierarchybuilding/) |

### Versioning

| Decorator | Purpose | Docs |
|---|---|---|
| `@@clientApiVersions(Service, ExtendedEnum)` | Extend API version enum beyond spec | [10versioning](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/10versioning/) |
| `@apiVersion` | Override which param is the API version param | [10versioning](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/10versioning/) |

### Paging & LRO

| Decorator | Purpose | Docs |
|---|---|---|
| `@markAsPageable` | Force operation to be treated as pageable | [05paging](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/05pagingoperations/) |
| `@disablePageable` | Prevent auto-detected paging behavior | [05paging](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/05pagingoperations/) |
| `@nextLinkVerb("POST")` | Use POST instead of GET for next-page requests | [05paging](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/05pagingoperations/) |
| `@markAsLro` | Force operation to be treated as long-running | [06LRO](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/06longrunningoperations/) |

### Emitter options

| Decorator | Purpose | Docs |
|---|---|---|
| `@clientOption("name", value, "csharp")` | Pass arbitrary key-value to a specific emitter | [12options](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/12clientoptions/) |

---

## C# Customization Attributes

All attributes are in `Generated/Internal/` and imported via:
```csharp
using Microsoft.TypeSpec.Generator.Customizations;
```

### `[CodeGenType("OriginalName")]`
Maps a custom class name to the generated type.

```csharp
[CodeGenType("DocumentsClientOptions")]
public partial class SearchClientOptions : ClientOptions { }
```

SDK usages: `SearchClientOptions.cs` (`DocumentsClientOptions` → `SearchClientOptions`), `SearchModelFactory.cs` (`DocumentsModelFactory` → `SearchModelFactory`).

### `[CodeGenMember("OriginalPropertyName")]`
Renames a generated property/field in the custom partial.

```csharp
[CodeGenMember("ETag")]
private string _etag;
public ETag? ETag
{
    get => _etag is null ? (ETag?)null : new ETag(_etag);
    set => _etag = value?.ToString();
}
```

SDK usages:

| File | Original → Custom | Why |
|---|---|---|
| `SearchField.cs` | `Searchable` → `IsSearchable` | Idiomatic naming |
| `SearchIndex.cs` | `ETag` → `_etag` → `ETag?` | Typed `Azure.ETag` wrapper |
| `SynonymMap.cs` | `Synonyms` → `SynonymsList` | Split newline string → list |
| `SearchResourceEncryptionKey.cs` | `VaultUri` → `_vaultUri` → `Uri` | Typed `Uri` |
| `VectorQuery.cs` | `Fields` → `FieldsRaw` | Comma-joined string → `IList<string>` |
| `SearchClientOptions.cs` | `Version` → `RawVersion` | Custom enum wraps raw string |
| `IndexingParameters.cs` | `Configuration` → strongly typed | Typed configuration |

### `[CodeGenSuppress("MemberName", typeof(Arg1))]`
Removes a generated constructor or method.

```csharp
[CodeGenSuppress(nameof(SearchIndexerDataSourceConnection),
    typeof(string), typeof(SearchIndexerDataSourceType),
    typeof(DataSourceCredentials), typeof(SearchIndexerDataContainer))]
public partial class SearchIndexerDataSourceConnection { ... }
```

SDK usages:

| File | Suppressed | Reason |
|---|---|---|
| `SearchIndexerDataSourceConnection.cs` | Generated 4-arg ctor | Replaced with user-friendly `connectionString` ctor |
| `SearchResourceEncryptionKey.cs` | Generated `(string, string)` ctor | Replaced with `(Uri, string, string)` ctor |
| `SearchModelFactory.cs` | `IndexDocumentsResult(IReadOnlyList<IndexingResult>)` | Custom overload with additional params |

---

## Common C# Patterns

### 1. Rename a type
Create a partial class with `[CodeGenType("OriginalName")]`.

### 2. Rename a property
Add `[CodeGenMember("OldName")]` to the new property declaration in the custom partial.

### 3. Replace a constructor
Use `[CodeGenSuppress]` to drop the generated ctor, then define a custom one.

### 4. Add an extra constructor
Define in the custom partial without suppressing anything.

### 5. Change a property type
Declare with `[CodeGenMember]` and provide a private backing field with conversion logic.

### 6. Make a property internal
Redefine with `internal` in the custom partial.

### 7. Make a type internal
Redefine with `internal` in the custom partial.

### 8. Change a doc comment
Redefine the member with new XML doc in the custom partial.

### 9. Rename an enum
Redefine entire enum with `[CodeGenType("OriginalName")]` (enums can't be `partial`).

### 10. Rename an enum member
Redefine entire enum, mark renamed member with `[CodeGenMember("OriginalMember")]`.

### 11. Convert closed enum → extensible struct
Define an empty `partial struct` with the same name.

### 12. Replace a generated method
Define method with same name/params in the custom partial.

### 13. Add forwarding convenience overloads
Use `[ForwardsClientCalls]` annotation.

### 14. Backward compat: keep a deleted type
See [architecture.md](./architecture.md#backwards-compatibility-for-removed-api-version-types) for the decision tree and git-tag verification process.

---

## Service Version Customizations

`SearchClientOptions.cs` defines the `ServiceVersion` enum. See [architecture.md](./architecture.md#service-version-management) for the five locations that must stay in sync.

### Adding a new API version
1. Add enum member.
2. Update `LatestVersion`.
3. Update all three switch expressions: `Validate`, `ToVersionString`, `ToServiceVersion`.

### Removing an API version (rare)
Remove enum member and all three switch arms. This is a **breaking change** requiring `ApiCompatBaseline.txt` suppression or major version bump.

---

## SearchModelFactory Customizations

`Models/SearchModelFactory.cs` is the custom partial. Uses `[CodeGenType("DocumentsModelFactory")]`.

**When to edit:**
- Generated factory method signature changed (parameters added/removed) → add `[EditorBrowsable(EditorBrowsableState.Never)]` overload forwarding to new signature.
- Model removed from generated code → restore factory method manually.
- New custom factory method needed for a type without a generated one.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
public static IndexerExecutionResult IndexerExecutionResult(
    IndexerExecutionStatus status, string errorMessage, ...)
{
    return IndexerExecutionResult(status, errorMessage, ..., default, default);
}
```

---

## Identifying What Needs Updating After Regeneration

| Generator action | What to check |
|---|---|
| Added parameter to generated ctor | Custom code calling `new ModelType(...)` — update argument list |
| Removed property from model | Custom partials referencing it — remove references |
| Deleted model file | Check backward compat rules in [architecture.md](./architecture.md#backwards-compatibility-for-removed-api-version-types) |
| Renamed member | Update `[CodeGenMember("...")]` attribute |
| Changed client method signature | Update custom partial that wraps/overrides it |

### Finding impacted files

```powershell
# Build to surface compile errors (errors in src/ outside Generated/ = files to fix)
dotnet build src/Azure.Search.Documents.csproj

# Show deleted files
git diff --diff-filter=D --name-only HEAD -- src/Generated/

# Find custom files referencing a moved/removed member
Select-String -Path src/**/*.cs -Pattern "OldMemberName" -Exclude "Generated/**" -Recurse

# Audit all CodeGenMember references
Select-String -Path src/**/*.cs -Pattern "CodeGenMember" -Recurse
```

---

## Efficient Update Patterns

### Constructor gains a new parameter
Build will identify call sites. Add new parameter(s) at the end (usually `default`). Keep old factory overloads with `[EditorBrowsable(Never)]`.

### Constructor loses a parameter
Build will identify call sites. Remove the argument. Set deleted property after construction if needed.

### Property renamed in spec
Update `[CodeGenMember("OldName")]` → `[CodeGenMember("NewName")]`.

### Removing a customization
If the generated name/type now matches the public API, delete the `[CodeGenMember]` declaration. Verify `api/*.cs` doesn't change unexpectedly.
