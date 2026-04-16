# Azure.Search.Documents SDK Architecture

## Overview

`Azure.Search.Documents` is the .NET client library for [Azure AI Search](https://learn.microsoft.com/azure/search/) (formerly Azure Cognitive Search). It supports querying search indexes, uploading/managing documents, managing indexes, indexers, skillsets, and knowledge bases.

---

## Repository Layout

```
sdk/search/Azure.Search.Documents/
├── tsp-location.yaml              # TypeSpec generation pin (repo, commit, directory)
├── CHANGELOG.md                   # Version history
├── README.md                      # Getting-started guide
├── MigrationGuide.md              # Guide for upgrading from older versions
├── TROUBLESHOOTING.md             # Common issues and diagnostics
├── metadata.json                  # Package metadata (service, SDK info)
├── assets.json                    # Test recording pointer (Azure/azure-sdk-assets)
├── Azure.Search.Documents.sln     # Solution file
├── api/                           # Public API surface snapshots (per TFM)
│   ├── Azure.Search.Documents.net10.0.cs
│   ├── Azure.Search.Documents.net8.0.cs
│   └── Azure.Search.Documents.netstandard2.0.cs
├── perf/                          # Performance benchmarks
├── samples/                       # Code samples linked from README
├── skills/                        # Copilot agent skills (repo-local AI agent docs)
├── src/                           # Library source (see below)
└── tests/                         # Unit and live tests
```

---

## Source Layout (`src/`)

The `src/` folder is split into two layers: **generated** code (never edited by hand) and **custom/handwritten** code that extends or overrides the generated layer.

```
src/
├── Generated/                     # AUTO-GENERATED — do not edit manually
│   ├── SearchClient.cs            # Generated document operations client
│   ├── SearchClient.RestClient.cs # Generated HTTP message builders
│   ├── SearchIndexClient.cs       # Generated index management client
│   ├── SearchIndexClient.RestClient.cs
│   ├── SearchIndexerClient.cs     # Generated indexer management client
│   ├── SearchIndexerClient.RestClient.cs
│   ├── KnowledgeBaseRetrievalClient.cs     # Generated knowledge base client
│   ├── KnowledgeBaseRetrievalClient.RestClient.cs
│   ├── SearchClientOptions.cs     # Generated service version configuration
│   ├── SearchModelFactory.cs      # Generated model factory (for mocking)
│   ├── DocumentsClientBuilderExtensions.cs
│   ├── CollectionResults/         # Generated pageable result types
│   ├── Internal/                  # Generator scaffolding (attributes, helpers)
│   │   ├── Argument.cs
│   │   ├── ChangeTrackingList.cs
│   │   ├── ChangeTrackingDictionary.cs
│   │   ├── CodeGenMemberAttribute.cs
│   │   ├── CodeGenSerializationAttribute.cs
│   │   ├── CodeGenSuppressAttribute.cs
│   │   ├── CodeGenTypeAttribute.cs
│   │   ├── ModelSerializationExtensions.cs
│   │   └── ...
│   └── Models/                    # AUTO-GENERATED model types (~200+ files)
│       ├── SearchIndex.cs / .Serialization.cs
│       ├── SearchIndexer.cs / .Serialization.cs
│       ├── SearchIndexerStatus.cs / .Serialization.cs
│       ├── KnowledgeBase.cs / .Serialization.cs
│       └── ...
│
├── SearchClient.cs                # CUSTOM — document query/upload entry point
├── SearchClientOptions.cs         # CUSTOM — ServiceVersion enum, version strings
├── SearchClientBuilderExtensions.cs
├── SearchAudience.cs
├── SearchFilter.cs                # CUSTOM — OData filter builder helper
├── SearchExtensions.cs
├── QueryAnswerResult.cs
├── AzureSearchDocumentsEventSource.cs   # ETW/EventSource telemetry
│
├── Internal/                      # CUSTOM — internal helpers
│   └── SyncAsyncEventHandlerExtensions.cs
│
├── Indexes/                       # CUSTOM — index & indexer management
│   ├── SearchIndexClient.cs       # Customization partial for SearchIndexClient
│   ├── SearchIndexClient.Aliases.cs
│   ├── SearchIndexClient.KnowledgeBases.cs
│   ├── SearchIndexClient.KnowledgeSources.cs
│   ├── SearchIndexerClient.cs     # Customization partial for SearchIndexerClient
│   ├── SearchIndexerClient.DataSources.cs
│   ├── SearchIndexerClient.SkillSets.cs
│   ├── FieldBuilder.cs            # Reflects over model types → SearchField list
│   ├── FieldBuilderIgnoreAttribute.cs
│   ├── ISearchFieldAttribute.cs
│   ├── SearchableFieldAttribute.cs
│   ├── SimpleFieldAttribute.cs
│   ├── VectorSearchFieldAttribute.cs
│   └── Models/                    # CUSTOM model types / partial-class overrides
│       ├── SearchIndex.cs         # Custom public constructor
│       ├── SearchIndexer.cs
│       ├── SearchIndexerDataSourceConnection.cs
│       ├── SearchField.cs / SimpleField.cs / SearchableField.cs / ComplexField.cs
│       ├── LexicalAnalyzer.cs / LexicalTokenizer.cs / TokenFilter.cs / CharFilter.cs
│       ├── SearchFieldDataType.cs
│       └── ... (many others)
│
├── KnowledgeBases/                # CUSTOM — knowledge base retrieval
│   └── KnowledgeBaseRetrievalClient.cs   # Custom constructors + Retrieve wrappers
│
├── Models/                        # CUSTOM — document operation models
│   ├── SearchModelFactory.cs      # Custom partial of the generated factory
│   ├── SearchDocument/            # Dynamic/typed document types
│   ├── SearchResult.cs / SearchResults.cs
│   ├── SearchResultsWithReflection.cs / SearchResultsWithTypeInfo.cs
│   ├── SuggestResults.cs / SearchSuggestion.cs
│   ├── AutocompleteResults.cs
│   ├── IndexDocumentsAction.cs / IndexDocumentsBatch.cs
│   ├── QueryAnswer.cs / QueryCaption.cs
│   ├── SearchContinuationToken.cs / SearchQueryType.cs
│   ├── VectorQuery.cs
│   ├── FacetResult.cs / RangeFacetResult.cs / ValueFacetResult.cs
│   └── ...
│
├── Options/                       # CUSTOM — strongly-typed options wrappers
│   ├── SearchOptions.cs
│   ├── SuggestOptions.cs
│   ├── AutocompleteOptions.cs
│   ├── GetDocumentOptions.cs
│   ├── IndexDocumentsOptions.cs
│   ├── SemanticSearchOptions.cs
│   └── VectorSearchOptions.cs
│
├── Batching/                      # CUSTOM — buffered indexing sender
│   ├── SearchIndexingBufferedSender.cs
│   ├── SearchIndexingBufferedSenderOptions.cs
│   ├── SearchIndexingPublisher.cs
│   ├── PublisherAction.cs / Publisher.cs / Publisher.Message.cs
│   ├── IndexActionEventArgs.cs / IndexActionCompletedEventArgs.cs / IndexActionFailedEventArgs.cs
│   └── ...
│
├── SearchDocument/                # CUSTOM — dynamic document type
│   ├── SearchDocument.cs          # Dictionary-backed dynamic document
│   ├── SearchDocumentConverter.cs # System.Text.Json converter
│   └── ...
│
├── Serialization/                 # CUSTOM — custom JSON converters
│   ├── JsonSerialization.cs
│   ├── SearchDateTimeConverter.cs / SearchDateTimeOffsetConverter.cs
│   ├── SearchDoubleConverter.cs
│   └── ...
│
├── Spatial/                       # CUSTOM — geo/spatial helpers
└── Utilities/                     # CUSTOM — internal helpers, extensions
    ├── Constants.cs
    ├── AsyncPageableWrapper.cs / PageableWrapper.cs
    ├── DictionaryExtensions.cs / InternalSearchExtensions.cs
    ├── Polyfill/                   # Polyfills for older target frameworks
    └── ...
```

---

## Code Generation

### TypeSpec-based generation

The `Generated/` folder is produced by the **Azure TypeSpec HTTP client emitter** from the `azure-rest-api-specs` repository. The toolchain is:

```
azure-rest-api-specs (TypeSpec spec)
    → azure-typespec-http-client-csharp emitter
        → Generated/ folder in this repo
```

**Key file**: `tsp-location.yaml` — pins the exact spec commit used for generation.

```yaml
repo: Azure/azure-rest-api-specs
commit: <SHA>                          # spec commit to generate from
directory: specification/search/data-plane/Search
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

To regenerate, use:
```powershell
# From the repo root
azsdk_package_generate_code --packagePath sdk/search/Azure.Search.Documents
```

> **Rule**: Never hand-edit files inside `src/Generated/`. All modifications must go into custom partial classes alongside the generated code, or into the TypeSpec spec upstream.

### Generated vs. Custom (partial classes)

The generator produces `partial class` types. Custom code extends them via additional partial class files **outside** `Generated/`. The split is transparent to consumers.

| Concern | Generated file | Custom file |
|---|---|---|
| `SearchClient` CRUD | `Generated/SearchClient.cs` | `SearchClient.cs` |
| `SearchIndexClient` management | `Generated/SearchIndexClient.cs` | `Indexes/SearchIndexClient.cs`, `SearchIndexClient.Aliases.cs`, etc. |
| `SearchIndexerClient` | `Generated/SearchIndexerClient.cs` | `Indexes/SearchIndexerClient.cs`, `.DataSources.cs`, `.SkillSets.cs` |
| `KnowledgeBaseRetrievalClient` | `Generated/KnowledgeBaseRetrievalClient.cs` | `KnowledgeBases/KnowledgeBaseRetrievalClient.cs` |
| `SearchModelFactory` | `Generated/SearchModelFactory.cs` | `Models/SearchModelFactory.cs` |
| `SearchClientOptions` | `Generated/SearchClientOptions.cs` | `SearchClientOptions.cs` |
| Model types | `Generated/Models/*.cs` | `Indexes/Models/*.cs`, `Models/*.cs` |

### Customization attributes

Types in `Generated/Internal/` expose attributes used to declare customization intent:

| Attribute | Purpose |
|---|---|
| `[CodeGenType("OriginalName")]` | Rename a generated type in the custom partial |
| `[CodeGenSuppress("Member", typeof(...))]` | Suppress a generated constructor or method |
| `[CodeGenMember("OriginalName")]` | Rename a generated field/property in the custom partial |

---

## Public Client Types

| Type | Namespace | Purpose |
|---|---|---|
| `SearchClient` | `Azure.Search.Documents` | Document query (search, suggest, autocomplete) and document upload/delete |
| `SearchIndexClient` | `Azure.Search.Documents.Indexes` | Create/manage indexes, synonym maps, aliases, knowledge bases, knowledge sources |
| `SearchIndexerClient` | `Azure.Search.Documents.Indexes` | Create/manage indexers, data sources, skillsets |
| `KnowledgeBaseRetrievalClient` | `Azure.Search.Documents.KnowledgeBases` | Query a knowledge base for retrieval-augmented generation (RAG) |
| `SearchIndexingBufferedSender<T>` | `Azure.Search.Documents` | Batched, retry-aware document upload sender |

---

## Service Version Management

`SearchClientOptions.cs` (custom) defines the `ServiceVersion` enum and all version-string mappings.  The generated `Generated/SearchClientOptions.cs` holds the rest of the options class.

```csharp
public enum ServiceVersion
{
    V2020_06_30 = 1,
    V2023_11_01 = 2,
    V2024_07_01 = 3,
    V2025_09_01 = 4,
    V2026_04_01 = 5,
    // new versions added here
}

internal const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;
```

Three switch expressions must be kept in sync when adding a new API version:

1. `Validate(ServiceVersion version)` — throws for invalid values  
2. `ToVersionString(ServiceVersion version)` — maps enum → API version string (e.g. `"2026-04-01"`)  
3. `ToServiceVersion(string version)` — maps API version string → enum (used by `assets.json`/recording)

> **Rule**: When adding a new `ServiceVersion` value, update all three switches and update `LatestVersion`.

---

## ApiCompat and Public API Surface

- `api/` contains public API surface snapshots generated by `eng/scripts/Export-API.ps1`.
- The project has `<ApiCompatVersion>some.version/ApiCompatVersion>`, meaning CI enforces no breaking changes from that version for GA releases.
- `ApiCompatBaseline.txt` lists known compat suppressions for the current version.

> **Rule**: Any public API change requires regenerating the `api/*.cs` files via `eng/scripts/Export-API.ps1 search`.

---

## Backwards Compatibility for Removed API Version Types

The SDK is **multi-version**: it targets the latest API version by default but supports all prior versions via the `ServiceVersion` enum. When a type is **removed** from a newer spec version:

- The generated file for that type is deleted by the generator.
- The type must be **restored manually** from git as a non-generated custom file, so older API version callers continue to compile, ONLY if ApiCompat (during compile-time) checks fail for the particular model/property.
- Restored files are placed in `src/`, not `src/Generated` but are no longer auto-generated on future runs.

---

## Model Factory (`SearchModelFactory`)

`SearchModelFactory` is a static factory used in test/mock scenarios to construct read-only model instances. It is split across two files:

| File | Role |
|---|---|
| `Generated/SearchModelFactory.cs` | Auto-generated factory methods for all generated models |
| `Models/SearchModelFactory.cs` | Custom factory methods for older/removed constructor overloads, `[EditorBrowsable(Never)]` compat overloads |

The custom file uses `[CodeGenType("DocumentsModelFactory")]` to merge with the generated partial class. Whenever generated constructor signatures change (e.g., a parameter is removed), the custom factory methods must be updated to match.

---

## SearchDocument (Dynamic Documents)

`SearchDocument` (`SearchDocument/SearchDocument.cs`) is a dictionary-backed dynamic type for working with documents when the schema is not known at compile time. It:

- Implements `IDictionary<string, object>`  
- Has a custom `System.Text.Json` converter (`SearchDocumentConverter`)
- Supports GeoJSON types via `Azure.Core.GeoJson`

---

## Buffered Indexing (`Batching/`)

`SearchIndexingBufferedSender<T>` provides intelligent batch document upload with:

- Automatic batching and flushing
- Retry for failed individual index actions  
- `IndexActionCompleted` / `IndexActionFailed` events  
- Backed by `System.Threading.Channels` for async producer/consumer flow

---

## Key Supporting Files

| File | Purpose |
|---|---|
| `tsp-location.yaml` | Pins the TypeSpec spec commit for generation |
| `src/Azure.Search.Documents.csproj` | Project definition, package metadata, shared source includes |
| `src/SearchClientOptions.cs` | `ServiceVersion` enum, version strings, `LatestVersion` constant |
| `src/SearchFilter.cs` | OData filter string builder (safe interpolation) |
| `src/Indexes/FieldBuilder.cs` | Reflects over .NET model types to produce `SearchField` definitions |
| `api/*.cs` | Public API surface snapshots — must be regenerated after any public API change |
| `ApiCompatBaseline.txt` | Suppressed API compatibility violations for the current version |
| `assets.json` | Points to the Azure SDK test recordings repo for playback tests |
| `CHANGELOG.md` | All version history; must be updated before each release |
| `metadata.json` | SDK package metadata used by release tooling |

---

## Namespaces

| Namespace | Contents |
|---|---|
| `Azure.Search.Documents` | `SearchClient`, `SearchClientOptions`, `SearchFilter`, `SearchIndexingBufferedSender<T>` |
| `Azure.Search.Documents.Indexes` | `SearchIndexClient`, `SearchIndexerClient`, `FieldBuilder`, field attributes |
| `Azure.Search.Documents.Indexes.Models` | `SearchIndex`, `SearchIndexer`, `SearchIndexerDataSourceConnection`, `SearchField`, skill types, etc. |
| `Azure.Search.Documents.Models` | `SearchDocument`, query/result models, `SearchModelFactory` |
| `Azure.Search.Documents.KnowledgeBases` | `KnowledgeBaseRetrievalClient` |
| `Azure.Search.Documents.KnowledgeBases.Models` | `KnowledgeBase`, `KnowledgeBaseRetrievalRequest/Response`, etc. |

---

## Tests

Tests live in `tests/` and follow the Azure SDK test framework (`Azure.Core.TestFramework`).  Live tests run against a real service; recorded tests play back from `assets.json`.

```
tests/
├── Batching/                  # SearchIndexingBufferedSender tests
├── DocumentOperations/        # Search / get document / suggest / autocomplete tests
├── Models/                    # Model serialization / factory tests
├── Samples/                   # Runnable code samples (also docs examples)
├── Serialization/             # SearchDocument converter tests
├── SearchClientTests.cs
├── SearchIndexClientTests.cs
├── SearchIndexerClientTests.cs
├── FieldBuilderTests.cs
└── ...
```
