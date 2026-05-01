# Azure.Search.Documents — Architecture Reference

## Contents
- [Source layout](#source-layout)
- [Code generation](#code-generation)
- [Generated vs. custom partial classes](#generated-vs-custom-partial-classes)
- [Public client types](#public-client-types)
- [Namespaces](#namespaces)
- [Service version management](#service-version-management)
- [ApiCompat and public API surface](#apicompat-and-public-api-surface)
- [Backwards compatibility for removed API version types](#backwards-compatibility-for-removed-api-version-types)
- [Checking previous releases via git tags](#checking-previous-releases-via-git-tags)
- [Known retained types](#known-retained-types)
- [SearchOptions property wiring](#searchoptions-property-wiring)
- [SearchModelFactory](#searchmodelfactory)
- [SearchDocument (dynamic documents)](#searchdocument-dynamic-documents)
- [Buffered indexing](#buffered-indexing)
- [Key supporting files](#key-supporting-files)
- [Tests](#tests)
# Azure.Search.Documents — Architecture Reference

## Contents
- [Source layout](#source-layout)
- [Code generation](#code-generation)
- [Generated vs. custom partial classes](#generated-vs-custom-partial-classes)
- [Public client types](#public-client-types)
- [Namespaces](#namespaces)
- [Service version management](#service-version-management)
- [ApiCompat and public API surface](#apicompat-and-public-api-surface)
- [Backwards compatibility for removed API version types](#backwards-compatibility-for-removed-api-version-types)
- [Checking previous releases via git tags](#checking-previous-releases-via-git-tags)
- [Known retained types](#known-retained-types)
- [SearchOptions property wiring](#searchoptions-property-wiring)
- [SearchModelFactory](#searchmodelfactory)
- [SearchDocument (dynamic documents)](#searchdocument-dynamic-documents)
- [Buffered indexing](#buffered-indexing)
- [Key supporting files](#key-supporting-files)
- [Tests](#tests)

---

## Source Layout
## Source Layout

```
src/
├── Generated/                     # AUTO-GENERATED — do not edit
│   ├── SearchClient.cs / .RestClient.cs
│   ├── SearchIndexClient.cs / .RestClient.cs
│   ├── SearchIndexerClient.cs / .RestClient.cs
│   ├── KnowledgeBaseRetrievalClient.cs / .RestClient.cs
│   ├── SearchClientOptions.cs
│   ├── SearchModelFactory.cs
├── Generated/                     # AUTO-GENERATED — do not edit
│   ├── SearchClient.cs / .RestClient.cs
│   ├── SearchIndexClient.cs / .RestClient.cs
│   ├── SearchIndexerClient.cs / .RestClient.cs
│   ├── KnowledgeBaseRetrievalClient.cs / .RestClient.cs
│   ├── SearchClientOptions.cs
│   ├── SearchModelFactory.cs
│   ├── DocumentsClientBuilderExtensions.cs
│   ├── CollectionResults/
│   ├── Internal/              # Generator scaffolding (attributes, helpers)
│   └── Models/                # ~200+ model types (.cs + .Serialization.cs)
│   ├── CollectionResults/
│   ├── Internal/              # Generator scaffolding (attributes, helpers)
│   └── Models/                # ~200+ model types (.cs + .Serialization.cs)
│
├── SearchClient.cs                # Custom document query/upload
├── SearchClientOptions.cs         # Custom ServiceVersion enum + version strings
├── SearchFilter.cs                # OData filter builder
├── Indexes/                       # Custom index/indexer management
│   ├── SearchIndexClient.cs / .Aliases.cs / .KnowledgeBases.cs / .KnowledgeSources.cs
│   ├── SearchIndexerClient.cs / .DataSources.cs / .SkillSets.cs
│   ├── FieldBuilder.cs            # Reflects model types → SearchField list
│   └── Models/                    # Custom model partials
├── KnowledgeBases/
│   └── KnowledgeBaseRetrievalClient.cs
├── Models/
│   ├── SearchModelFactory.cs      # Custom factory overloads
├── SearchClient.cs                # Custom document query/upload
├── SearchClientOptions.cs         # Custom ServiceVersion enum + version strings
├── SearchFilter.cs                # OData filter builder
├── Indexes/                       # Custom index/indexer management
│   ├── SearchIndexClient.cs / .Aliases.cs / .KnowledgeBases.cs / .KnowledgeSources.cs
│   ├── SearchIndexerClient.cs / .DataSources.cs / .SkillSets.cs
│   ├── FieldBuilder.cs            # Reflects model types → SearchField list
│   └── Models/                    # Custom model partials
├── KnowledgeBases/
│   └── KnowledgeBaseRetrievalClient.cs
├── Models/
│   ├── SearchModelFactory.cs      # Custom factory overloads
│   ├── SearchDocument/            # Dynamic/typed document types
│   └── ... (results, suggestions, facets, vector queries)
├── Options/                       # SearchOptions, SuggestOptions, etc.
├── Batching/                      # SearchIndexingBufferedSender<T>
├── Serialization/                 # Custom JSON converters
└── Utilities/                     # Internal helpers, polyfills
│   └── ... (results, suggestions, facets, vector queries)
├── Options/                       # SearchOptions, SuggestOptions, etc.
├── Batching/                      # SearchIndexingBufferedSender<T>
├── Serialization/                 # Custom JSON converters
└── Utilities/                     # Internal helpers, polyfills
```

---

## Code Generation

Generated code comes from the Azure TypeSpec HTTP client emitter. The pin is in `tsp-location.yaml`:
Generated code comes from the Azure TypeSpec HTTP client emitter. The pin is in `tsp-location.yaml`:

```yaml
repo: Azure/azure-rest-api-specs
commit: <SHA>
commit: <SHA>
directory: specification/search/data-plane/Search
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

> **Rule**: Never hand-edit files inside `src/Generated/`. Use custom partial classes or fix upstream in TypeSpec.
> **Rule**: Never hand-edit files inside `src/Generated/`. Use custom partial classes or fix upstream in TypeSpec.

---

## Generated vs. Custom (Partial Classes)
---

## Generated vs. Custom (Partial Classes)

The generator produces `partial class` types. Custom code extends them in files outside `Generated/`.
The generator produces `partial class` types. Custom code extends them in files outside `Generated/`.

| Type | Generated file | Custom file(s) |
| Type | Generated file | Custom file(s) |
|---|---|---|
| `SearchClient` | `Generated/SearchClient.cs` | `SearchClient.cs` |
| `SearchIndexClient` | `Generated/SearchIndexClient.cs` | `Indexes/SearchIndexClient.cs`, `.Aliases.cs`, `.KnowledgeBases.cs`, `.KnowledgeSources.cs` |
| `SearchClient` | `Generated/SearchClient.cs` | `SearchClient.cs` |
| `SearchIndexClient` | `Generated/SearchIndexClient.cs` | `Indexes/SearchIndexClient.cs`, `.Aliases.cs`, `.KnowledgeBases.cs`, `.KnowledgeSources.cs` |
| `SearchIndexerClient` | `Generated/SearchIndexerClient.cs` | `Indexes/SearchIndexerClient.cs`, `.DataSources.cs`, `.SkillSets.cs` |
| `KnowledgeBaseRetrievalClient` | `Generated/KnowledgeBaseRetrievalClient.cs` | `KnowledgeBases/KnowledgeBaseRetrievalClient.cs` |
| `SearchModelFactory` | `Generated/SearchModelFactory.cs` | `Models/SearchModelFactory.cs` |
| `SearchClientOptions` | `Generated/SearchClientOptions.cs` | `SearchClientOptions.cs` |
| Model types | `Generated/Models/*.cs` | `Indexes/Models/*.cs`, `Models/*.cs` |

For customization attributes (`CodeGenType`, `CodeGenMember`, `CodeGenSuppress`), see [customization.md](./customization.md).
For customization attributes (`CodeGenType`, `CodeGenMember`, `CodeGenSuppress`), see [customization.md](./customization.md).

---

## Public Client Types

| Type | Namespace | Purpose |
|---|---|---|
| `SearchClient` | `Azure.Search.Documents` | Document query (search, suggest, autocomplete) and document upload/delete |
| `SearchIndexClient` | `Azure.Search.Documents.Indexes` | Create/manage indexes, synonym maps, aliases, knowledge bases, knowledge sources |
| `SearchIndexerClient` | `Azure.Search.Documents.Indexes` | Create/manage indexers, data sources, skillsets |
| `KnowledgeBaseRetrievalClient` | `Azure.Search.Documents.KnowledgeBases` | Query a knowledge base for RAG |
| `SearchIndexingBufferedSender<T>` | `Azure.Search.Documents` | Batched, retry-aware document upload |

---

## Namespaces

| Namespace | Contents |
|---|---|
| `Azure.Search.Documents` | `SearchClient`, `SearchClientOptions`, `SearchFilter`, `SearchIndexingBufferedSender<T>` |
| `Azure.Search.Documents.Indexes` | `SearchIndexClient`, `SearchIndexerClient`, `FieldBuilder`, field attributes |
| `Azure.Search.Documents.Indexes.Models` | `SearchIndex`, `SearchIndexer`, `SearchField`, skill types, etc. |
| `Azure.Search.Documents.Models` | `SearchDocument`, query/result models, `SearchModelFactory` |
| `Azure.Search.Documents.KnowledgeBases` | `KnowledgeBaseRetrievalClient` |
| `Azure.Search.Documents.KnowledgeBases.Models` | `KnowledgeBase`, retrieval request/response, etc. |
| `KnowledgeBaseRetrievalClient` | `Azure.Search.Documents.KnowledgeBases` | Query a knowledge base for RAG |
| `SearchIndexingBufferedSender<T>` | `Azure.Search.Documents` | Batched, retry-aware document upload |

---

## Namespaces

| Namespace | Contents |
|---|---|
| `Azure.Search.Documents` | `SearchClient`, `SearchClientOptions`, `SearchFilter`, `SearchIndexingBufferedSender<T>` |
| `Azure.Search.Documents.Indexes` | `SearchIndexClient`, `SearchIndexerClient`, `FieldBuilder`, field attributes |
| `Azure.Search.Documents.Indexes.Models` | `SearchIndex`, `SearchIndexer`, `SearchField`, skill types, etc. |
| `Azure.Search.Documents.Models` | `SearchDocument`, query/result models, `SearchModelFactory` |
| `Azure.Search.Documents.KnowledgeBases` | `KnowledgeBaseRetrievalClient` |
| `Azure.Search.Documents.KnowledgeBases.Models` | `KnowledgeBase`, retrieval request/response, etc. |

---

## Service Version Management

`SearchClientOptions.cs` (custom) defines the `ServiceVersion` enum. Six locations must stay in sync:

```csharp
// 1. Enum member
// 1. Enum member
public enum ServiceVersion
{
    V2020_06_30 = 1,
    V2023_11_01 = 2,
    V2024_07_01 = 3,
    V2025_09_01 = 4,
    V2026_04_01 = 5,
    // Preview versions are added here for beta releases and removed for GA.
    // V2026_05_01_Preview = 6,
}

// 2. LatestVersion constant — points to latest GA or preview depending on release
internal const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;

// 3. TryGetServiceVersion() — version string → enum
// 4. Validate() — throws for invalid values
// 5. ToVersionString() — enum → "2026-04-01"
// 6. ToServiceVersion() — "2026-04-01" → enum (used by recordings)
```

> **Rule**: Missing a switch case causes a runtime `ArgumentOutOfRangeException`, not a compile error. Always update all six.
> - **GA releases**: Only GA versions in the enum. Remove any preview versions and their switch arms.
> - **Preview releases**: Add the latest preview version. Keep all GA versions.

### Preview Tests (`AZURE_SEARCH_PREVIEW`)

Preview-specific tests live in dedicated files (e.g. `SearchTests.Preview.cs`) wrapped entirely in `#if AZURE_SEARCH_PREVIEW`. Main test files contain only GA versions in `[ClientTestFixture]` — no `#if` guards.

The `AZURE_SEARCH_PREVIEW` constant is defined automatically via MSBuild `<Choose>` blocks:

- **`src/Azure.Search.Documents.csproj`**: Defines `AZURE_SEARCH_PREVIEW` when `$(Version)` contains `-beta`.
- **`tests/Azure.Search.Documents.Tests.csproj`**: Reads the src csproj file content and defines `AZURE_SEARCH_PREVIEW` when the `<Version>` tag contains `-beta`.

#### Adding preview tests

Create a `*.Preview.cs` file wrapped in `#if AZURE_SEARCH_PREVIEW` with its own `[ClientTestFixture(ServiceVersion.V<preview>)]` class that tests preview-specific features:

```csharp
// SearchTests.Preview.cs
#if AZURE_SEARCH_PREVIEW
namespace Azure.Search.Documents.Tests
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public class SearchPreviewTests : SearchTestBase
    {
        public SearchPreviewTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null) { }

        // Preview-specific test methods here
    }
}
#endif
```

#### Promoting preview tests to GA

When the preview version becomes GA:
1. Remove the `#if AZURE_SEARCH_PREVIEW` / `#endif` wrapper.
2. Merge test methods into the main test class or keep as a separate file with the GA version in `[ClientTestFixture]`.
3. Remove the preview `ServiceVersion` enum value from `SearchClientOptions.cs`.

> **Rule**: Preview version references must only appear inside `#if AZURE_SEARCH_PREVIEW` blocks. Main test files use only GA versions.

---

## ApiCompat and Public API Surface

- `api/` contains public API snapshots generated by `eng/scripts/Export-API.ps1 search`.
- `ApiCompatVersion` enforces no breaking changes from that version for GA releases.
- `ApiCompatBaseline.txt` lists known compat suppressions.
- `api/` contains public API snapshots generated by `eng/scripts/Export-API.ps1 search`.
- `ApiCompatVersion` enforces no breaking changes from that version for GA releases.
- `ApiCompatBaseline.txt` lists known compat suppressions.

> **Rule**: Any public API change requires regenerating `api/*.cs`.
> **Rule**: Any public API change requires regenerating `api/*.cs`.

---

## Backwards Compatibility for Removed API Version Types

When the generator deletes a type that was removed from the spec:
When the generator deletes a type that was removed from the spec:

- **Only restore** the type if it existed in a **previous GA release**.
- Types introduced in preview-only or the current unreleased version do not need restoration.
- Restored files are placed back in `src/Generated/Models/` and are no longer auto-generated on future runs.
- **Only restore** the type if it existed in a **previous GA release**.
- Types introduced in preview-only or the current unreleased version do not need restoration.
- Restored files are placed back in `src/Generated/Models/` and are no longer auto-generated on future runs.

### Checking Previous Releases via Git Tags

Tags follow the format `Azure.Search.Documents_<version>`:

```powershell
# Find the latest GA tag (exclude -beta)
git tag -l "Azure.Search.Documents_*" | Where-Object { $_ -notmatch "beta" } | Select-Object -Last 1

# Check if a deleted type existed in that GA release
git show Azure.Search.Documents_11.7.0:sdk/search/Azure.Search.Documents/api/Azure.Search.Documents.netstandard2.0.cs | Select-String "DeletedTypeName"
```

- Type appears → restore it for backward compat.
- Type does not appear → deletion is safe.
- Same logic can be used to check beta releases, but remember a type does not need to be restored if it ONLY exists in preview/beta, but MUST be restored if it is in GA.


## SearchModelFactory

Split across two files:
### Checking Previous Releases via Git Tags

Tags follow the format `Azure.Search.Documents_<version>`:

```powershell
# Find the latest GA tag (exclude -beta)
git tag -l "Azure.Search.Documents_*" | Where-Object { $_ -notmatch "beta" } | Select-Object -Last 1

# Check if a deleted type existed in that GA release
git show Azure.Search.Documents_11.7.0:sdk/search/Azure.Search.Documents/api/Azure.Search.Documents.netstandard2.0.cs | Select-String "DeletedTypeName"
```

- Type appears → restore it for backward compat.
- Type does not appear → deletion is safe.
- Same logic can be used to check beta releases, but remember a type does not need to be restored if it ONLY exists in preview/beta, but MUST be restored if it is in GA.

---

## SearchOptions Property Wiring

`SearchOptions` is a `partial class` spanning generated and custom code. The generated half defines a flat internal constructor and JSON serialization that reference properties like `QueryLanguage`, `SemanticFields`, `HybridSearch`, etc. The custom half groups these into user-facing option objects (`SemanticSearchOptions`, `VectorSearchOptions`) for a better API experience.

### Architecture

```
Generated constructor / serialization
  │
  ├── QueryLanguage ──────► [CodeGenMember] bridge property ──► SemanticSearch.QueryLanguage
  ├── QuerySpeller ───────► [CodeGenMember] bridge property ──► SemanticSearch.QuerySpeller
  ├── QueryRewrites ──────► [CodeGenMember] bridge property ──► SemanticSearch.QueryRewrites
  ├── SemanticFields ─────► [CodeGenMember] bridge property ──► SemanticSearch.SemanticFields
  ├── SemanticQuery ──────► [CodeGenMember] bridge property ──► SemanticSearch.SemanticQuery
  ├── SemanticConfig ─────► [CodeGenMember] bridge property ──► SemanticSearch.SemanticConfigurationName
  ├── SemanticErrorMode ──► [CodeGenMember] bridge property ──► SemanticSearch.ErrorMode
  ├── QueryAnswerRaw ─────► [CodeGenMember] bridge property ──► SemanticSearch.QueryAnswer.QueryAnswerRaw
  ├── QueryCaptionRaw ────► [CodeGenMember] bridge property ──► SemanticSearch.QueryCaption.QueryCaptionRaw
  ├── VectorQueries ──────► private bridge property ──────────► VectorSearch.Queries
  ├── VectorFilterMode ───► [CodeGenMember] bridge property ──► VectorSearch.FilterMode
  └── HybridSearch ───────► [CodeGenMember] bridge property ──► VectorSearch.HybridSearch
```

Users interact with `options.SemanticSearch.QueryLanguage` etc. The generated code interacts with the flat `QueryLanguage` property. The bridge properties translate between the two.

### Adding a new generated property

When a new API version adds a property to the generated `SearchOptions`:

1. **Add a public property** on `SemanticSearchOptions` or `VectorSearchOptions` (or create a new options class if it doesn't fit either).
2. **Add a private bridge property** in `Options/SearchOptions.cs`:
   ```csharp
   [CodeGenMember("GeneratedPropertyName")]
   private PropertyType GeneratedPropertyName
   {
       get { return SemanticSearch?.PropertyName; }
       set
       {
           if (value != null)
           {
               SemanticSearch ??= new SemanticSearchOptions();
           }
           if (SemanticSearch != null)
           {
               SemanticSearch.PropertyName = value;
           }
       }
   }
   ```
3. **Regenerate** the code to ensure the properties are properly bridged. (Note: Do not regenerate code repeatedly, as this is a time consuming process)
4. The **lazy initialization** (`??= new ...()`) in the setter is critical: the generated internal constructor assigns these properties before `SemanticSearch`/`VectorSearch` are initialized. Without it, values from deserialization are silently dropped.

### Verifying correctness

After adding a wiring property, verify the following:

1. **Build `src/`** — no CS0102 (duplicate member) or CS0103 (name not found) errors.
2. **Build `tests/`** — no downstream breaks.
3. **Check the generated constructor** (`Generated/Models/SearchOptions.cs`) assigns the property. 
4. **Check the generated serialization** (`Generated/Models/SearchOptions.Serialization.cs`) reads/writes the property. Serialization uses the property getter, so your bridge getter must return the correct value.
5. **Check the `Copy` method** — since `Copy` assigns `SemanticSearch` and `VectorSearch` by reference, all bridge properties are automatically included. No update needed unless you create a new top-level options object.

### Checking for missing wiring after regeneration

Compare the generated `SearchOptions.cs` properties against the custom bridge properties:

```powershell
# Properties defined in the generated file (public auto-properties)
Select-String 'public .+ \{ get; \}' src/Generated/Models/SearchOptions.cs

# Bridge properties defined in custom code
Select-String '\[CodeGenMember\(' src/Options/SearchOptions.cs
```

Any generated public property that does NOT have a corresponding `[CodeGenMember]` bridge — and is not one of the flat properties handled directly (like `IncludeTotalCount`, `Filter`, etc.) — is a wiring gap. It means the property will exist on the generated class but won't be accessible through the user-facing `SemanticSearch`/`VectorSearch` objects.

### FacetResult and SearchResults deserialization

Similar wiring issues can occur in custom deserialization methods that override the generated ones. `FacetResult` and `SearchResults<T>` both have custom `DeserializeFacetResult` / `DeserializeEnvelope` methods in their custom partial classes. When new properties are added to the generated model (e.g., `Avg`, `Min`, `Max`, `Sum`, `Cardinality`, `Facets` on `FacetResult`), the custom deserializer must be updated to parse them — otherwise they are hardcoded to `null`.

**Checklist after adding a new property to a model with custom deserialization:**
1. Check `Generated/Models/<Type>.cs` for new properties.
2. Check the custom partial's `Deserialize*` method — does it parse the new JSON keys?
3. Check `SearchModelFactory` — does the custom factory method accept the new parameters? If not, add a new overload and mark the old one `[EditorBrowsable(Never)]`.

---

## SearchModelFactory

Split across two files:

| File | Role |
|---|---|
| `Generated/SearchModelFactory.cs` | Auto-generated factory methods |
| `Models/SearchModelFactory.cs` | Custom backward-compat overloads (`[EditorBrowsable(Never)]`) |
| `Generated/SearchModelFactory.cs` | Auto-generated factory methods |
| `Models/SearchModelFactory.cs` | Custom backward-compat overloads (`[EditorBrowsable(Never)]`) |

The custom file uses `[CodeGenType("DocumentsModelFactory")]`. See [customization.md](./customization.md#searchmodelfactory-customizations) for update patterns.
The custom file uses `[CodeGenType("DocumentsModelFactory")]`. See [customization.md](./customization.md#searchmodelfactory-customizations) for update patterns.

---

## SearchDocument (Dynamic Documents)

`SearchDocument` is a dictionary-backed dynamic type (`IDictionary<string, object>`) with a custom `System.Text.Json` converter (`SearchDocumentConverter`). Supports GeoJSON via `Azure.Core.GeoJson`.
`SearchDocument` is a dictionary-backed dynamic type (`IDictionary<string, object>`) with a custom `System.Text.Json` converter (`SearchDocumentConverter`). Supports GeoJSON via `Azure.Core.GeoJson`.

---

## Buffered Indexing
## Buffered Indexing

`SearchIndexingBufferedSender<T>` provides automatic batching, retry for failed index actions, and `IndexActionCompleted`/`IndexActionFailed` events. Backed by `System.Threading.Channels`.
`SearchIndexingBufferedSender<T>` provides automatic batching, retry for failed index actions, and `IndexActionCompleted`/`IndexActionFailed` events. Backed by `System.Threading.Channels`.

---

## Key Supporting Files

| File | Purpose |
|---|---|
| `tsp-location.yaml` | TypeSpec spec commit pin |
| `SearchClientOptions.cs` | `ServiceVersion` enum + version strings |
| `SearchFilter.cs` | OData filter string builder |
| `Indexes/FieldBuilder.cs` | Reflects .NET model types → `SearchField` definitions |
| `api/*.cs` | Public API snapshots (regenerate after public changes) |
| `ApiCompatBaseline.txt` | Known compat suppressions |
| `assets.json` | Test recording pointer |
| `CHANGELOG.md` | Version history |
| `metadata.json` | Package metadata for release tooling |
| `tsp-location.yaml` | TypeSpec spec commit pin |
| `SearchClientOptions.cs` | `ServiceVersion` enum + version strings |
| `SearchFilter.cs` | OData filter string builder |
| `Indexes/FieldBuilder.cs` | Reflects .NET model types → `SearchField` definitions |
| `api/*.cs` | Public API snapshots (regenerate after public changes) |
| `ApiCompatBaseline.txt` | Known compat suppressions |
| `assets.json` | Test recording pointer |
| `CHANGELOG.md` | Version history |
| `metadata.json` | Package metadata for release tooling |

---

## Tests

Tests use `Azure.Core.TestFramework`. Live tests run against a real service; recorded tests play back from `assets.json`.
Tests use `Azure.Core.TestFramework`. Live tests run against a real service; recorded tests play back from `assets.json`.

### Service version test matrix

The `[ClientTestFixture]` attribute is declared **only on `SearchTestBase`** with the latest GA and latest preview versions. All derived test classes inherit it automatically via NUnit attribute inheritance (`Inherited = true`). This means when a new API version is added, **only `SearchTestBase` needs to be updated**.

```csharp
// SearchTestBase.cs — single source of truth for test versions
[ClientTestFixture(
    SearchClientOptions.ServiceVersion.V2026_04_01,          // latest GA
    SearchClientOptions.ServiceVersion.V2026_05_01_Preview)] // latest preview
public abstract partial class SearchTestBase : RecordedTestBase<SearchTestEnvironment>
```

**Do NOT** add `[ClientTestFixture]` to derived classes unless they need a *different* set of versions (e.g., testing only against older versions). If a derived class declares its own `[ClientTestFixture]`, it **shadows** the base class's attribute.

### Gating tests to specific versions

Use `[ServiceVersion]` to restrict individual tests or classes to a version range:

```csharp
// Runs only on V2026_04_01 and later (skipped on older versions in the fixture)
[ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
public void TestNewFeature() { ... }

// Runs only on preview versions
[ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
public void TestPreviewOnlyFeature() { ... }

// Class-level: all tests in the class require V2026_04_01+
[ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
public partial class Sample01_HelloWorld : SearchTestBase { ... }
```

### Updating versions after regeneration

When a new `ServiceVersion` enum value is added to `SearchClientOptions`:
1. Update `SearchTestBase`'s `[ClientTestFixture]` — set the latest GA and latest preview.
2. No changes needed in derived test classes (they inherit).
3. Add `[ServiceVersion(Min = ...)]` to any tests that use features only available in the new version.

```
tests/
├── Batching/               # SearchIndexingBufferedSender tests
├── DocumentOperations/     # Search, get, suggest, autocomplete
├── Models/                 # Model serialization, factory
├── Samples/                # Runnable doc examples
├── Serialization/          # SearchDocument converter
└── SearchClientTests.cs / SearchIndexClientTests.cs / ...
├── Batching/               # SearchIndexingBufferedSender tests
├── DocumentOperations/     # Search, get, suggest, autocomplete
├── Models/                 # Model serialization, factory
├── Samples/                # Runnable doc examples
├── Serialization/          # SearchDocument converter
└── SearchClientTests.cs / SearchIndexClientTests.cs / ...
```
