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
- [SearchModelFactory](#searchmodelfactory)
- [SearchOptions architecture](#searchoptions-architecture)
- [Custom deserialization sites](#custom-deserialization-sites)
- [SearchDocument (dynamic documents)](#searchdocument-dynamic-documents)
- [Buffered indexing](#buffered-indexing)
- [Key supporting files](#key-supporting-files)
- [Tests](#tests)

---

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
│   ├── DocumentsClientBuilderExtensions.cs
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
│   ├── SearchDocument/            # Dynamic/typed document types
│   └── ... (results, suggestions, facets, vector queries)
├── Options/                       # SearchOptions, SuggestOptions, etc.
├── Batching/                      # SearchIndexingBufferedSender<T>
├── Serialization/                 # Custom JSON converters
└── Utilities/                     # Internal helpers, polyfills
```

---

## Code Generation

Generated code comes from the Azure TypeSpec HTTP client emitter. The pin is in `tsp-location.yaml`:

```yaml
repo: Azure/azure-rest-api-specs
commit: <SHA>
directory: specification/search/data-plane/Search
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

> **Rule**: Never hand-edit files inside `src/Generated/`. Use custom partial classes or fix upstream in TypeSpec.

---

## Generated vs. Custom (Partial Classes)

The generator produces `partial class` types. Custom code extends them in files outside `Generated/`.

| Type | Generated file | Custom file(s) |
|---|---|---|
| `SearchClient` | `Generated/SearchClient.cs` | `SearchClient.cs` |
| `SearchIndexClient` | `Generated/SearchIndexClient.cs` | `Indexes/SearchIndexClient.cs`, `.Aliases.cs`, `.KnowledgeBases.cs`, `.KnowledgeSources.cs` |
| `SearchIndexerClient` | `Generated/SearchIndexerClient.cs` | `Indexes/SearchIndexerClient.cs`, `.DataSources.cs`, `.SkillSets.cs` |
| `KnowledgeBaseRetrievalClient` | `Generated/KnowledgeBaseRetrievalClient.cs` | `KnowledgeBases/KnowledgeBaseRetrievalClient.cs` |
| `SearchModelFactory` | `Generated/SearchModelFactory.cs` | `Models/SearchModelFactory.cs` |
| `SearchClientOptions` | `Generated/SearchClientOptions.cs` | `SearchClientOptions.cs` |
| Model types | `Generated/Models/*.cs` | `Indexes/Models/*.cs`, `Models/*.cs` |

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

---

## Service Version Management

`SearchClientOptions.cs` (custom) defines the `ServiceVersion` enum. Five locations must stay in sync:

```csharp
// 1. Enum member
public enum ServiceVersion
{
    V2020_06_30 = 1,
    V2023_11_01 = 2,
    V2024_07_01 = 3,
    V2025_09_01 = 4,
    V2026_04_01 = 5,
}

// 2. LatestVersion constant
internal const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;

// 3. Validate() — throws for invalid values
// 4. ToVersionString() — enum → "2026-04-01"
// 5. ToServiceVersion() — "2026-04-01" → enum (used by recordings)
```

> **Rule**: Missing a switch case causes a runtime `ArgumentOutOfRangeException`, not a compile error. Always update all five.
> For preview releases: only the latest preview version. For GA: no preview versions.

---

## ApiCompat and Public API Surface

- `api/` contains public API snapshots generated by `eng/scripts/Export-API.ps1 search`.
- `ApiCompatVersion` enforces no breaking changes from that version for GA releases.
- `ApiCompatBaseline.txt` lists known compat suppressions.

> **Rule**: Any public API change requires regenerating `api/*.cs`.

---

## Backwards Compatibility for Removed API Version Types

When the generator deletes a type that was removed from the spec:

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

| File | Role |
|---|---|
| `Generated/SearchModelFactory.cs` | Auto-generated factory methods |
| `Models/SearchModelFactory.cs` | Custom backward-compat overloads (`[EditorBrowsable(Never)]`) |

The custom file uses `[CodeGenType("DocumentsModelFactory")]`. See [customization.md](./customization.md#searchmodelfactory-customizations) for update patterns.

---

## SearchOptions Architecture

`SearchOptions` uses `[CodeGenType("SearchRequest")]` to map onto the generated flat request model, but the public API groups related properties into two sub-objects: `SemanticSearchOptions` and `VectorSearchOptions`. Private `[CodeGenMember]` redirector properties bridge between them — the generated serializer reads/writes the redirectors, which transparently delegate to the sub-objects.

### Why this matters

The generated serializer accesses properties by `[CodeGenMember]` name. If a new generated property is left as an auto-property instead of being routed through the correct sub-object, it will serialize correctly but be **invisible to users** (they'd need to set `searchOptions.QueryLanguage` instead of `searchOptions.SemanticSearch.QueryLanguage`), breaking the public API design.

### Property routing rules

| If the new generated property is... | Route it to | Mechanism |
|---|---|---|
| Related to semantic search (language, speller, answers, captions, rewrites, semantic fields, semantic config, error mode, max wait, semantic query) | `SemanticSearchOptions` | Private `[CodeGenMember]` redirector in `Options/SearchOptions.cs` → public property on `SemanticSearchOptions` |
| Related to vector/hybrid search (vector queries, filter mode, hybrid search config) | `VectorSearchOptions` | Private `[CodeGenMember]` redirector in `Options/SearchOptions.cs` → public property on `VectorSearchOptions` |
| A comma-separated string that users should see as a list | `SearchOptions` itself | Public `IList<string>` + private `[CodeGenMember]` `string` Raw accessor using `CommaJoin()`/`CommaSplit()` |
| A simple property with acceptable generated name/type | `SearchOptions` itself | No custom code needed — the generated auto-property is the public API |
| A simple property that needs renaming | `SearchOptions` itself | `[CodeGenMember("GeneratedName")]` on a public property in `Options/SearchOptions.cs` |

### Adding a property to a sub-object

All four steps are required — skipping any one creates a silent bug:

1. Add the public property to the sub-object class (`Options/SemanticSearchOptions.cs` or `Options/VectorSearchOptions.cs`).
2. Add a private redirector in `Options/SearchOptions.cs`:
   ```csharp
   [CodeGenMember("GeneratedPropertyName")]
   private PropertyType PropertyName
   {
       get { return SubObject?.PropertyName; }
       set { if (SubObject != null) { SubObject.PropertyName = value; } }
   }
   ```
3. Update the **internal constructor** in `Options/SearchOptions.cs`:
   - Add the parameter (match the generated constructor's signature).
   - Add the parameter to the null-check that decides whether to create the sub-object.
   - Assign via the redirector.
4. **Regenerate** so the generated `SearchOptions.cs` drops the auto-property (the `[CodeGenMember]` claim causes the generator to skip it).

### Two constructors — different callers

The generated and hand-written files each define an internal constructor with nearly the same parameters. They serve different call sites:

| Constructor | Called by | Key difference |
|---|---|---|
| Generated (in `Generated/Models/SearchOptions.cs`) | `DeserializeSearchOptions` in `Serialization.cs` | Has `additionalBinaryDataProperties` param; assigns flat properties directly |
| Hand-written (in `Options/SearchOptions.cs`) | `SearchContinuationToken.Deserialize` | Creates `SemanticSearchOptions`/`VectorSearchOptions` sub-objects; assigns via redirectors |

When the generated constructor gains a new parameter, the hand-written constructor must gain the same parameter and route it through the correct redirector.

### `Copy()` and continuation tokens

`Copy()` in `Options/SearchOptions.cs` transfers state between instances for continuation token support. It copies **public** properties only (`SemanticSearch`, `VectorSearch`, `Facets`, etc.). When adding a new direct public property, add it to `Copy()`.

---

## Custom Deserialization Sites

Several model types have **hand-written deserialization** that bypasses the generated `Deserialize*` methods. When the generated model constructor gains new parameters, these sites will produce build errors. **Do NOT fix them by passing `null`/`default`** — that silently drops the new data at runtime.

### Inventory

| File | Method | What it constructs | Risk |
|---|---|---|---|
| `Models/FacetResult.cs` | `DeserializeFacetResult(JsonElement, ModelReaderWriterOptions)` | `FacetResult` | Overrides the generated deserializer. New constructor params = new JSON properties to parse. |
| `Models/SearchResults.cs` | `DeserializeEnvelope(...)` facets loop | `FacetResult` (inline) | Parses facets from the search response envelope. Same constructor — same new fields. |

### Update pattern

When `FacetResult` (or any model with a custom deserializer) gains new constructor parameters:

1. **Read the generated model** (`Generated/Models/FacetResult.cs`) to identify the new properties and their types.
2. **Read the generated serialization** (`Generated/Models/FacetResult.Serialization.cs`) to identify the JSON property names and deserialization logic.
3. **Update the custom deserializer** to parse the new JSON properties and pass them to the constructor — mirror the generated deserializer's pattern.
4. **Update `SearchResults.cs`** inline facet construction to also parse and pass the new fields.
5. Do NOT use `null`/`default` as a shortcut — the data will exist in service responses and must be deserialized.

### How to detect new parameters after regen

```powershell
# Find custom files that construct model types directly (non-generated call sites)
Get-ChildItem -Path src -Filter "*.cs" -Recurse -Exclude "Generated*" |
  Select-String -Pattern "new FacetResult\(|new SearchResult\(|new SuggestResults\(" |
  Select-Object Path, LineNumber, Line
```

---

## SearchDocument (Dynamic Documents)

`SearchDocument` is a dictionary-backed dynamic type (`IDictionary<string, object>`) with a custom `System.Text.Json` converter (`SearchDocumentConverter`). Supports GeoJSON via `Azure.Core.GeoJson`.

---

## Buffered Indexing

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

---

## Tests

Tests use `Azure.Core.TestFramework`. Live tests run against a real service; recorded tests play back from `assets.json`.

```
tests/
├── Batching/               # SearchIndexingBufferedSender tests
├── DocumentOperations/     # Search, get, suggest, autocomplete
├── Models/                 # Model serialization, factory
├── Samples/                # Runnable doc examples
├── Serialization/          # SearchDocument converter
├── TypeCompleteness/       # Self-discovering reflection-based tests
├── Utilities/              # Shared test helpers
└── SearchClientTests.cs / SearchIndexClientTests.cs / ...
```

---

## Build Properties

| Property | Value |
|---|---|
| `TargetFrameworks` | `$(RequiredTargetFrameworks)` — `net10.0;net8.0;netstandard2.0` |
| `ApiCompatVersion` | Set to last GA version — enforces no binary-breaking changes |
| `DisableEnhancedAnalysis` | `true` |
| `AotCompatOptOut` | `true` |
| `AZURE_SEARCH_PREVIEW` | Defined when `<Version>` contains `beta` — gates preview API surface at compile time |
