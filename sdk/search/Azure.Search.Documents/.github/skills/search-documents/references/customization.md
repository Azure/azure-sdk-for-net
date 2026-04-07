# Azure.Search.Documents — Customization Guide

This document covers how to apply, update, and remove customizations on top of the TypeSpec-generated code in `Azure.Search.Documents`. It is intended as the primary reference when generated code must be modified to meet the SDK's public API contract.

**Related docs:**
- [architecture.md](./architecture.md) — full source layout and code generation workflow  
- [TypeSpec Customization Reference](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md) — upstream attribute documentation
- [Client Typespec Renaming](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/09renaming/)
- [Client Typespec Basic Methods](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/04method/)

---

## When to Customize vs. When to Fix Upstream

Before adding a C# customization, consider whether the change belongs upstream:

| Change | Where it belongs |
|---|---|
| Rename a type or property for all languages | TypeSpec `client.tsp` using `@@clientName` |
| Change access (public → internal) for all languages | TypeSpec `client.tsp` using `@@access` |
| Add a convenience parameter or constructor | C# customization (language-specific) |
| Wrap a raw string property as a typed value (e.g., `Uri`, `ETag`) | C# customization |
| Suppress a generated constructor to replace it | C# customization |
| Add semantic helpers (e.g., `FieldBuilder`, `SearchFilter`) | C# customization (no spec equivalent) |
| Add multi-version backward compat for a removed type | C# customization (keep deleted file) |
| Update existing customizations, e.g., ctors, helpers, overloads | C# customization

Use C# customizations when TypeSpec cannot express the desired behavior, or when the behavior is C#-specific.

---

## Customization Mechanics

The generator emits `partial class` types. Every generated type can be extended or overridden by adding additional partial class files **outside** `Generated/`. Three attributes (all in `Generated/Internal/`) control how the generator treats these custom files:

```csharp
using Microsoft.TypeSpec.Generator.Customizations;
```

### `[CodeGenType("OriginalName")]`
Maps a custom class name (or namespace) to the generated type. Causes the generator to emit the type under the new name/namespace.

```csharp
// Renames DocumentsClientOptions → SearchClientOptions
[CodeGenType("DocumentsClientOptions")]
public partial class SearchClientOptions : ClientOptions { }
```

Real usage in the SDK:
- `SearchClientOptions.cs` — renames `DocumentsClientOptions` → `SearchClientOptions`
- `Models/SearchModelFactory.cs` — renames `DocumentsModelFactory` → `SearchModelFactory`

---

### `[CodeGenMember("OriginalPropertyName")]`
Renames a generated property or field in the custom partial. The generated code removes the original member and relies on the custom declaration instead.

```csharp
// Exposes raw string "_etag" as typed ETag? property
[CodeGenMember("ETag")]
private string _etag;

public ETag? ETag
{
    get => _etag is null ? (ETag?)null : new ETag(_etag);
    set => _etag = value?.ToString();
}
```

Real usages in the SDK:

| File | Original name | Custom name / type | Why |
|---|---|---|---|
| `SearchField.cs` | `Searchable` | `IsSearchable` (bool?) | Idiomatic naming convention |
| `SearchField.cs` | `Filterable` | `IsFilterable` (bool?) | ditto |
| `SearchIndex.cs` | `Fields` → `_fields` | `IList<SearchField> Fields` | Force private backing field so getter can throw on null |
| `SearchIndex.cs` | `ETag` → `_etag` | `ETag?` wrapper | Expose `Azure.ETag` instead of raw string |
| `SynonymMap.cs` | `Synonyms` → `SynonymsList` | `IList<string>` | Split newline-delimited string into list |
| `SynonymMap.cs` | `ETag` → `_etag` | `ETag?` wrapper | Same as above |
| `SearchAlias.cs` | `ETag` → `_etag` | read-only `ETag?` wrapper | ETag is immutable on alias |
| `SearchResourceEncryptionKey.cs` | `VaultUri` → `_vaultUri` | `Uri VaultUri` | Expose `Uri` instead of raw string |
| `SearchResourceEncryptionKey.cs` | `KeyVaultKeyName` | `KeyName` | Shorter, idiomatic name |
| `SearchIndexerDataSourceConnection.cs` | `ETag` → `_etag` | `ETag?` wrapper | ditto |
| `IndexingParameters.cs` | `Configuration` | `IndexingParametersConfiguration` | Strongly-typed configuration over raw dictionary |
| `VectorQuery.cs` | `Fields` → `FieldsRaw` | `IList<string> Fields` | Expose list, join on serialization |
| `SearchClientOptions.cs` | `Version` (generated string) | `RawVersion` | Custom enum wraps the raw string |

---

### `[CodeGenSuppress("MemberName", typeof(Arg1), typeof(Arg2))]`
Removes a generated constructor or method so a custom replacement can be provided. Applied at the class level.

```csharp
// Removes the generated (string name, SearchIndexerDataSourceType, DataSourceCredentials, SearchIndexerDataContainer) ctor
[CodeGenSuppress(nameof(SearchIndexerDataSourceConnection),
    typeof(string), typeof(SearchIndexerDataSourceType),
    typeof(DataSourceCredentials), typeof(SearchIndexerDataContainer))]
public partial class SearchIndexerDataSourceConnection { ... }
```

Real usages in the SDK:

| File | Suppressed member | Reason |
|---|---|---|
| `SearchIndexerDataSourceConnection.cs` | Generated 4-arg ctor | Replaced with user-friendly ctor taking `connectionString` instead of `DataSourceCredentials` |
| `SearchResourceEncryptionKey.cs` | Generated `(string, string)` ctor | Replaced with `(Uri vaultUri, string keyName, string keyVersion)` ctor |
| `Models/SearchModelFactory.cs` | `IndexDocumentsResult(IReadOnlyList<IndexingResult>)` | Replaced with custom overload that accepts additional params |

---

## Common Customization Patterns

### 1. Rename a type

Create a new file with the desired class name in the correct namespace, apply `[CodeGenType]`.

```csharp
// File: SearchClientOptions.cs
[CodeGenType("DocumentsClientOptions")]
public partial class SearchClientOptions : ClientOptions { }
```

The generator renames the emitted class; the original `Generated/SearchClientOptions.cs` will use `SearchClientOptions` as the class name.

---

### 2. Rename a property / field

Create a partial class, declare the new property with `[CodeGenMember("OldName")]`. The generator removes the original property declaration and uses the custom one for serialization.

```csharp
// File: SearchField.cs
public partial class SearchField
{
    [CodeGenMember("Searchable")]
    public bool? IsSearchable { get; set; }
}
```

> **Constraint:** You can only remap types where the underlying JSON representation is the same (string↔TimeSpan, float↔int, string↔enum, string↔Uri). You cannot remap string↔bool.

---

### 3. Replace a generated constructor

Use `[CodeGenSuppress]` to drop the generated ctor, then define a custom one in the same partial class.

```csharp
[CodeGenSuppress(nameof(SearchIndexerDataSourceConnection),
    typeof(string), typeof(SearchIndexerDataSourceType),
    typeof(DataSourceCredentials), typeof(SearchIndexerDataContainer))]
public partial class SearchIndexerDataSourceConnection
{
    public SearchIndexerDataSourceConnection(
        string name,
        SearchIndexerDataSourceType type,
        string connectionString,
        SearchIndexerDataContainer container)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ...
    }
}
```

---

### 4. Add an extra constructor

Simply define the additional constructor in the partial class without suppressing anything.

```csharp
// File: SearchIndex.cs
public partial class SearchIndex
{
    public SearchIndex(string name) : this(name, new List<SearchField>()) { }
}
```

---

### 5. Change a property type (type remapping)

Declare the property with the new type in the custom partial. The serializer code will be regenerated to use the new type.

```csharp
// Expose VaultUri as Uri instead of string
[CodeGenMember("VaultUri")]
private string _vaultUri;

public Uri VaultUri
{
    get => new Uri(_vaultUri);
    private set => _vaultUri = value.AbsoluteUri;
}
```

For lists: expose a materialized `IList<T>` and a private `[CodeGenMember]` property that joins/splits for the wire format:

```csharp
// VectorQuery.cs — expose Fields as IList<string>, send as comma-joined string
public IList<string> Fields { get; internal set; } = new List<string>();

[CodeGenMember("Fields")]
internal string FieldsRaw
{
    get => Fields.CommaJoin();
    set => Fields = InternalSearchExtensions.CommaSplit(value);
}
```

---

### 6. Make a model property internal

Simply redefine the property in the custom partial with `internal` accessor — the generator removes the public declaration.

```csharp
public partial class Model
{
    internal string SomeProperty { get; }
}
```

---

### 7. Make a whole type internal

Redefine the class with `internal` in the custom partial.

```csharp
internal partial class DataSourceCredentials { }
```

---

### 8. Change a doc comment

Redefine the member with the new XML doc in the custom partial. The generated declaration is suppressed automatically.

```csharp
public partial class SearchField
{
    /// <summary>
    /// Gets or sets a value indicating whether the field is full-text searchable...
    /// </summary>
    [CodeGenMember("Searchable")]
    public bool? IsSearchable { get; set; }
}
```

---

### 9. Rename an enum

Because enums cannot be `partial`, redefine the entire enum under a new name with `[CodeGenType]`. All member values must be copied.

```csharp
[CodeGenType("OriginalEnumName")]
public enum NewEnumName
{
    Value1,
    Value2,
}
```

---

### 10. Rename an enum member

Redefine the entire enum (enums can't be partial), marking the renamed member with `[CodeGenMember("OriginalMember")]`. Only the renamed member needs the attribute.

```csharp
public enum Colors
{
    Red,
    Green,
    [CodeGenMember("Blue")]
    SkyBlue,
}
```

---

### 11. Convert a closed enum to an extensible enum

Define an empty `partial struct` with the same name.

```csharp
public partial struct Colors { }
```

The generator produces a readonly struct with static factory members.

---

### 12. Replace an entire generated member

Define the member in the custom partial with the same name and parameters. The generator suppresses the generated version.

```csharp
// Custom implementation replaces generated method
public partial class SearchClient
{
    public virtual Response<SearchResults<T>> Search<T>(
        string searchText,
        SearchOptions options = null,
        CancellationToken cancellationToken = default)
    {
        // fully custom implementation
    }
}
```

---

### 13. Add forwarding convenience overloads

Add methods that accept a model object directly and forward to the generated method, annotated with `[ForwardsClientCalls]`.

```csharp
// SearchIndexClient.Aliases.cs
[ForwardsClientCalls]
public virtual Response<SearchAlias> CreateOrUpdateAlias(
    SearchAlias alias,
    bool onlyIfUnchanged = false,
    CancellationToken cancellationToken = default) =>
    CreateOrUpdateAlias(
        alias.Name,
        alias,
        onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null,
        cancellationToken);
```

---

### 14. Backward compat: keep a type deleted by regen

When a new API version removes a type that existed in earlier versions, the generator deletes the `Generated/Models/TypeName.cs` file. The type must be preserved for callers using older `ServiceVersion` values.

**Process:**
1. After regeneration, use `git status` or `git diff --name-only` to identify deleted files.
2. Use `git checkout HEAD -- path/to/DeletedType.cs` to restore the file from the previous commit.
3. The restored file remains in `Generated/Models/` but is **not overwritten** by future regeneration (it won't appear in the spec anymore).
4. Do not add a new `ServiceVersion`-based `#if` guard unless the type needs to be conditionally excluded — simple restoration is sufficient.

Examples of retained types in the SDK:
- `HybridSearch.cs`, `HybridCountAndFacetMode.cs`
- `IndexerRuntime.cs`
- `QueryLanguage.cs`, `QuerySpellerType.cs`, `QueryRewritesType.cs`
- `SemanticQueryRewritesResultType.cs`, `KnowledgeRetrievalOutputMode.cs`
- `QueryRewritesDebugInfo.cs`, `QueryRewritesValuesDebugInfo.cs`

---

## Service Version Customizations

`SearchClientOptions.cs` is the only custom file that defines the `ServiceVersion` enum. The generator emits the rest of the options class in `Generated/SearchClientOptions.cs`.

### Adding a new API version

1. Add a new enum member in `SearchClientOptions.cs`:
   ```csharp
   V2026_04_01 = 6,
   ```
2. Update `LatestVersion`:
   ```csharp
   internal const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;
   ```
3. Update **all three** switch expressions in `InternalSearchExtensions` (same file):
   - `Validate` — add the new case
   - `ToVersionString` — map enum → `"2026-04-01"`
   - `ToServiceVersion` — map `"2026-04-01"` → enum

> **Rule**: All three switches must always be in sync. Missing a case causes a runtime `ArgumentOutOfRangeException`.

### Removing an API version (rare)

Remove the enum member and all three switch arms. Carefully audit callers. This is a **breaking change** and requires `ApiCompatBaseline.txt` suppression or a major version bump.

---

## `SearchModelFactory` Customizations

`Models/SearchModelFactory.cs` is the custom partial for the factory. The generated `Generated/SearchModelFactory.cs` contains auto-generated factory methods for every model.

### When to edit the custom factory

- A generated factory method's signature changes (parameters added/removed): update the custom overload with `[EditorBrowsable(EditorBrowsableState.Never)]` to keep backward compat.
- A model is removed from the generated code: the factory method is also removed; restore it manually in the custom factory file.
- A completely new custom factory method is needed for a type that doesn't have a generated one.

### Pattern for backward-compat factory overloads

```csharp
// Keep the old factory signature when the generated one gains new required params
[EditorBrowsable(EditorBrowsableState.Never)]
public static IndexerExecutionResult IndexerExecutionResult(
    IndexerExecutionStatus status,
    string errorMessage,
    ...)
{
    return IndexerExecutionResult(status, errorMessage, ..., default, default);
}
```

---

## Identifying What Needs Updating After Regeneration

After running `azsdk_package_generate_code`, a regeneration may:

| Generator action | What to check |
|---|---|
| Added a new parameter to a generated internal ctor | Custom partial classes that call `new ModelType(...)` — update argument list |
| Removed a property from a generated model | Custom partial classes that reference the property — remove references |
| Deleted a generated model file | Restore via git if needed for backward compat; update `SearchModelFactory.cs` |
| Renamed a generated member | Update `[CodeGenMember("...")]` attribute if the original name changed |
| Changed a method signature on a generated client | Update any custom partial that wraps or overrides the same method |
| Added new error types or status codes | Usually nothing needed unless custom code handles them |

### Efficient workflow for finding all impacted custom files

```powershell
# 1. Build to surface all compile errors
cd sdk/search/Azure.Search.Documents
dotnet build src/Azure.Search.Documents.csproj

# 2. Group errors by file
# Errors in src/Generated/ = ignore (auto-generated)
# Errors in src/ outside Generated/ = the custom files to fix

# 3. For deleted types — find what the generator removed
git diff --name-only HEAD  # shows modified files
git diff --diff-filter=D --name-only HEAD  # shows deleted files only

# 4. Restore deleted backward-compat types
git checkout HEAD -- src/Generated/Models/DeletedType.cs
```

### Efficient find patterns for stale customization references

```powershell
# Find all custom files referencing a moved/removed generated member
Select-String -Path src\**\*.cs -Pattern "OldMemberName" -Exclude "Generated\**" -Recurse

# Find all custom factory overloads that need signature updates
Select-String -Path src\Models\SearchModelFactory.cs -Pattern "public static"

# Show all CodeGenMember references (to audit after a regen)
Select-String -Path src\**\*.cs -Pattern "CodeGenMember" -Recurse
```

---

## Efficient Patterns for Updating Customizations

### When a generated constructor gains a new parameter

Generated internal constructors gain new parameters as properties are added to the spec. Custom code that calls `new ModelType(a, b, c)` must be updated.

**Strategy:**
1. Build — the compiler will identify every call site.
2. Add the new parameter(s) at the end of the argument list (usually `default` or `null` is appropriate for new optional properties in custom code).
3. In `SearchModelFactory.cs`, keep old factory overloads with `[EditorBrowsable(Never)]` and forward to the updated signature.

### When a generated constructor loses a parameter

Parameters removed from generated internal ctors leave dangling arguments in custom call sites.

**Strategy:**
1. Build — the compiler identifies every call site.
2. Remove the argument. If the deleted parameter represented a concept that still needs to be set, find the corresponding property and set it after construction.

### When a property is renamed in the spec (via TypeSpec `@@clientName`)

The generator renames the property. Any `[CodeGenMember("OldName")]` attribute referencing it must be updated to `[CodeGenMember("NewName")]`.

**Strategy:**
```powershell
# Identify all CodeGenMember usages to audit
Select-String -Path src\**\*.cs -Pattern '\[CodeGenMember\(' -Recurse
```

Update the attribute argument to match the new generated name.

### When a type is renamed in the spec (via TypeSpec `@@clientName`)

The generator renames the class. Any `[CodeGenType("OldName")]` attribute pointing to it must be updated.

### When removing a customization entirely

If a property is now correctly named/typed in the generator, you can delete the `[CodeGenMember]` declaration from the custom partial. The generator will re-emit the member in `Generated/` on the next regen.

**Checklist before removing a customization:**
- [ ] Does the generated name/type match what the public API surface currently exposes?  
- [ ] Are there any callers in custom code that use the old name?  
- [ ] Does the `api/*.cs` snapshot need to be regenerated after the change?  
- [ ] Does the `ApiCompatBaseline.txt` need updating?

---

## Serialization Customizations

### Custom serialized JSON key name

Use `[CodeGenSerialization(nameof(Property), "jsonKeyName")]` on the class.

```csharp
[CodeGenSerialization(nameof(Name), "catName")]
public partial class Cat { }
```

### Custom serialization/deserialization logic

Use `SerializationValueHook` and `DeserializationValueHook` on `[CodeGenSerialization]`:

```csharp
[CodeGenSerialization(nameof(Name),
    SerializationValueHook = nameof(WriteNameValue),
    DeserializationValueHook = nameof(ReadNameValue))]
public partial class Cat
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void WriteNameValue(Utf8JsonWriter writer) =>
        writer.WriteStringValue(Name.ToUpper());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ReadNameValue(JsonProperty prop, ref string value) =>
        value = prop.Value.GetString()?.ToLower();
}
```

### Replace entire serialization method

Define `void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)` or `internal static T DeserializeT(JsonElement)` in the custom partial. The generator omits these methods from the generated file.

---

## File Placement Rules

| Custom file type | Where to place it |
|---|---|
| Partial class extending a generated client | Next to or in subdirectory of the generated file (`Indexes/SearchIndexClient.cs`) |
| Partial class extending a generated model | `Indexes/Models/` or `Models/` depending on its namespace |
| Backward-compat retained type (formerly generated) | Stay in `Generated/Models/` — do not move it |
| New type with no generated equivalent | In the appropriate namespace folder: `Indexes/`, `Models/`, `KnowledgeBases/`, etc. |
| Semantic helpers (FieldBuilder, SearchFilter) | In the appropriate namespace folder (`Indexes/FieldBuilder.cs`, root `SearchFilter.cs`) |

---

## Quick-Reference Checklist: After a Regeneration

```
[ ] dotnet build — resolve all compile errors in src/ (outside Generated/)
[ ] Check git diff --diff-filter=D for deleted generated files
[ ]   → Restore backward-compat types from git
[ ]   → Remove corresponding factory overloads in SearchModelFactory.cs that can't compile
[ ]   → Add [EditorBrowsable(Never)] shims in SearchModelFactory.cs for removed types
[ ] Update SearchClientOptions.cs if a new ServiceVersion was introduced:
[ ]   → Add enum member
[ ]   → Update LatestVersion
[ ]   → Update all three switch expressions (Validate, ToVersionString, ToServiceVersion)
[ ] Update public API snapshots: eng/scripts/Export-API.ps1 search
[ ] Update ApiCompatBaseline.txt if needed (new suppressions for intentional breaks)
[ ] Run tests: dotnet test (playback mode)
[ ] Review CHANGELOG.md entry
```
