# Release History

## 11.8.0-beta.1 (2025-10-20)

### Features Added
- Added support for `2025-11-01-preview` service version.
- Added support for multiple facet aggregation types: `avg`, `min`, `max`, `cardinality` in `FacetResult` for enhanced analytics capabilities.
- Added support for new `KnowledgeSourceKind` types: `web`, `remoteSharePoint`, `indexedSharePoint`, `indexedOneLake`.
- Added support for `sharepoint` data source type in `SearchIndexerDataSourceType`.
- Added `product` scoring function aggregation type in `ScoringFunctionAggregation`.
- Added support for new Azure OpenAI models: `gpt-5`, `gpt-5-mini`, `gpt-5-nano` in `AzureOpenAIModelName`.
- Added enhanced runtime tracking with `runtime` property in `SearchIndexerStatus` and `indexersRuntime` property in `ServiceStatistics`.
- Added optional `purviewEnabled` property in `SearchIndex` for data governance integration.
- Added `maxCumulativeIndexerRuntimeSeconds` property in `ServiceLimits` for runtime constraints.
- Added enhanced knowledge source configuration options:
  - `sourceDataFields`, `searchFields`, `semanticConfigurationName` in `SearchIndexKnowledgeSourceParameters`
  - `isADLSGen2`, `ingestionParameters` in `AzureBlobKnowledgeSourceParameters`
- Added optional parameter `x-ms-enable-elevated-read` for document retrieval operations with elevated permissions.
- Added support for partial content responses (HTTP 206) in knowledge base operations.
- Added `error` property in `KnowledgeBaseActivityRecord` for improved error tracking.
- Added enhanced knowledge source parameters: `includeReferences`, `includeReferenceSourceData`, `alwaysQuerySource`, `rerankerThreshold` in `SearchIndexKnowledgeSourceParams`.

### Breaking Changes
- Renamed Knowledge Agent to Knowledge Base across all APIs and models:
  - All `KnowledgeAgent*` classes renamed to `KnowledgeBase*` equivalents
  - API paths changed from `/agents` to `/knowledgebases`
  - Client parameter `AgentNameParameter` replaced with `KnowledgeBaseNameParameter`
  - All agent-related activity record types updated with new naming convention
- Removed deprecated Knowledge Agent configuration models:
  - `KnowledgeAgentOutputConfiguration`
  - `KnowledgeAgentRequestLimits`
  - `KnowledgeAgentModel`
  - `KnowledgeAgentModelKind`
  - `KnowledgeAgentAzureOpenAIModel`
- Removed properties from `KnowledgeSourceReference`:
  - `includeReferences`
  - `includeReferenceSourceData`
  - `alwaysQuerySource`
  - `maxSubQueries`
  - `rerankerThreshold`
- Removed `sourceDataSelect` property from `SearchIndexKnowledgeSourceParameters`.
- Removed properties from `AzureBlobKnowledgeSourceParameters`:
  - `identity`
  - `embeddingModel`
  - `chatCompletionModel`
  - `ingestionSchedule`
  - `disableImageVerbalization`

### Bugs Fixed

### Other Changes

## 11.7.0 (2025-10-09)

### Features Added
- Added support for `2025-09-01` service version.
- Support for reranker boosted scores in search results and the ability to sort results on either reranker or reranker boosted scores in `SemanticConfiguration.RankingOrder`.
- Support for `VectorSearchCompression.RescoringOptions` to configure how vector compression handles the original vector when indexing and how vectors are used during rescoring.
- Added `SearchIndex.Description` to provide a textual description of the index.
- Support for `LexicalNormalizer` when defining `SearchIndex`, `SimpleField`, and `SearchableField` and the ability to use it when analyzing text with `SearchIndexClient.AnalyzeText`.
- Support `DocumentIntelligenceLayoutSkill` skillset skill and `OneLake` `SearchIndexerDataSourceConnection` data source.
- Support for `QueryDebugMode` in searching to retrieve detailed information about search processing. Only vector is supported for `QueryDebugMode`.

### Breaking Changes
- `VectorSearchCompression.RerankWithOriginalVectors` and `VectorSearchCompression.DefaultOversampling` don't work with
  `2025-09-01` and were replaced by `VectorSearchCompression.RescoringOptions.EnabledRescoring` and 
  `VectorSearchCompression.RescoringOptions.DefaultOversampling`. If using `2024-07-01` continue using the old properties,
  otherwise if using `2025-09-01` use the new properties in `RescoringOptions`.

## 11.7.0-beta.7 (2025-09-05)

### Features Added
- Added support for Knowledge Agent knowledge sources.
- Added support for Knowledge Agent answer synthesis.
- Added `VectorFilterMode.StrictPostFilter`.

### Breaking Changes
- Dropped support for Knowledge Agent target index. Use knowledge sources instead.
- Moved `QueryDebugMode` from `SemanticSearchOptions` to `SearchOptions` as it is no longer tied only to semantic queries.

## 11.7.0-beta.6 (2025-08-11)

### Features Added
- Enable the new model serialization using System.ClientModel, refer to this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added new AOT-compatible overloads for `Search<T>` and `SearchAsync<T>` that take `JsonTypeInfo<T>`.

## 11.7.0-beta.5 (2025-06-17)

### Bugs Fixed
- Fixed a failure in the search response when the service returned a 206(Partial Content) status code.

## 11.6.1 (2025-06-17)

### Bugs Fixed
- Added support for HTTP status code 206 (Partial Content) in the `Search` method to handle partial results returned by the service.

## 11.7.0-beta.4 (2025-05-14)

### Features Added
- Added new `KnowledgeAgent` resource APIs in `SearchIndexClient` and introduced `KnowledgeAgentRetrievalClient` for managing and querying KnowledgeAgents, enabling multi-index grounding for agentic retrieval.
- Added a method overload for search query to include the `QuerySourceAuthorization` parameter to enforce per-user filtering in queries.
- Added `Resync` method in `SearchIndexerClient` to resync selective options from the data source to be re-ingested by the indexer.
- Added `PermissionFilter` to `SearchField`, `SimpleField`, and `SimpleFieldAttribute`, indicating whether the field should be used as a permission filter.
- Added `PermissionFilterOption` to `SearchIndex`, indicating whether permission filtering is enabled for the index.
- Added `RerankerBoostedScore` to `SemanticSearchResult` and updated `SemanticConfiguration` with a new `RankingOrder` property.
- Introduced new skill `ChatCompletionSkill` that integrates with Azure AI Foundry.
- Enhanced `DocumentIntelligenceLayoutSkill` with new properties: `ChunkingProperties`, `ExtractionOptions`, and `OutputFormat`.
- Added `IndexerPermissionOptions` to `SearchIndexerDataSourceConnection` to support ingestion of various types of permission data.
- Introduced sub-field vector support (multi-vectors) via `VectorQuery.Fields`, and added new query option `VectorQuery.PerDocumentVectorLimit`.

## 11.7.0-beta.3 (2025-03-25)

### Features Added
- Added support for the `GetIndexStatsSummary` API in `SearchIndexClient`.
- Added extension methods to get `SearchClient`, `SearchIndexClient` and `SearchIndexerClient` using [AIProjectClient](https://learn.microsoft.com/dotnet/api/azure.ai.projects.aiprojectclient?view=azure-dotnet-preview).

## 11.7.0-beta.2 (2024-11-25)

### Features Added
- `FacetResults` is now a recursive data structure to support hierarchical aggregation and facet filtering.
- `QueryAnswer` now supports a `MaxCharLength` option to limit the character length of the answer.
- `QueryCaption` now supports a `MaxCharLength` option to limit the character length of the caption.
- `VectorizableTextQuery` now supports a `QueryRewrites` option to specify the number query rewrites the service will generate.
- `SemanticSearchOptions` now supports a `QueryRewrites` option to specify the number query rewrites the service will generate.
- `VectorSearchCompression` now supports configuring the `RescoringOptions`.
- `IndexingParametersConfiguration` now supports two additional options for `MarkdownParsingSubmode` and `MarkdownHeaderDepth`.
- Added a new skill: `DocumentIntelligenceLayoutSkill` that extracts content and layout information (as markdown), via Azure AI Services, from files within the enrichment pipeline.
- Added 2 subtypes of `CognitiveServiceAccounts`: `AzureCognitiveServiceAccount` and `AzureCognitiveServiceAccountKey`.

### Bugs Fixed
- Fixed a bug in the `SearchResult.DocumentDebugInfo` property by changing its type from `IReadOnlyList<DocumentDebugInfo>` to `DocumentDebugInfo`. ([#46958](https://github.com/Azure/azure-sdk-for-net/issues/46958))

## 11.7.0-beta.1 (2024-09-24)

### Features Added
- Added support for `VectorSearchCompression.TruncationDimension`, which allows specifying the number of dimensions to truncate vectors to.
- Added support for `VectorQuery.FilterOverride`, which allows vector queries to override the broader `SearchOptions.Filter`, enabling more specific configurations for vector queries.
- `SplitSkill` now supports tokenization.
- `DocumentDebugInfo` is extended with vector scores for the results.

## 11.6.0 (2024-07-17)

### Features Added
- Added support for `2024-07-01` service version.
- `SemanticSearchOptions` now supports `SemanticQuery`, which allows for specifying a semantic query that is only used
  for semantic reranking.
- `VectorQuery` now supports `Oversampling` and `Weight`, which allows for specifying richer configurations on how
  vector queries affect search results.
- Added support for `VectorizableTextQuery`, which allows for passing a text-based query that is vectorized service-side
  by `VectorSearchVectorizer`s configured on the index so that vectorization doesn't need to happen before querying.
- Added support for "bring your own endpoint" with `VectorSearchVectorizer`, with implementations `AzureOpenAIVectorizer`
  and `WebApiVectorizer`. This enables the service to use a user-provided configuration for vectorizing text, rather 
  than requiring all client-side calls to vectorize before querying, allowing for easier standardization of vectorization.
- Added support for compression with `VectorSearchCompression`, with implementations `BinaryQuantizationCompression`
  and `ScalarQuantizationCompression`. This allows for reducing the size of vectors in the index, which can reduce
  storage costs and improve querying performance.
- Added support for `VectorEncodingFormat`, which allows for specifying the encoding format of the vector data.
- Added support for `AzureOpenAIEmbeddingSkill`, which is a skill that uses the Azure OpenAI service to create text 
  embeddings during indexing.
- Added support for index projections with `SearchIndexerIndexProjection`, which allows for specifying how indexed 
  documents are projected in the index (or indexes).
- Added support for "narrow" types in `SearchFieldDataType`. This allows for specifying smaller types for vector fields
  to reduce storage costs and improve querying performance.
- Added support for `SearchIndexerDataIdentity`, which allows for specifying the identity for the data source for the 
  indexer.
- `SearchField` and `SearchableField` now support `IsStored` and `VectorEncodingFormat` configurations. `IsStored` allows
  for specifying behaviors on how the index will retain vector data (enabling the ability to reduce storage costs), and
  `VectorEncodingFormat` allows for specifying the encoding format of the vector data.
- `OcrSkill` now supports `LineEnding`, which allows for specifying the line ending character used by the OCR skill.
- `SplitSkill` now supports `MaximumPagesToTake` and `PageOverlapLength`, which allows for specifying how the split
  skill behaves when splitting documents into pages.
- `SearchServiceLimits` now supports `MaxStoragePerIndexInBytes`, which shows the maximum storage allowed per index.

### Breaking Changes

- All service concepts that have been in preview but not included in the `2024-07-01` GA have been removed. This
  includes concepts such as index aliases, normalizers, Azure Machine Learning skills, hybrid search, and more.

## 11.6.0-beta.4 (2024-05-06)

### Features Added
- Added support for new embedding models `text-embedding-3-small` and `text-embedding-3-large`, as part of our existing `AzureOpenAIVectorizer` and `AzureOpenAIEmbeddingSkill` features. 
- Added support for `AIServicesVisionVectorizer` and `VisionVectorizeSkill` to generate embeddings for an image or text using the Azure AI Services Vision Vectorize API.
- Added support for `AzureMachineLearningVectorizer`, allowing users to specify an Azure Machine Learning endpoint deployed via the Azure AI Foundry Model Catalog to generate vector embeddings of query strings.
- Added support for `byte` to `SearchFieldDataType`.

## 11.6.0-beta.3 (2024-03-05)

### Features Added
- Added the `VectorSearch.Compressions` property, which can be utilized to configure options specific to the compression method used during indexing or querying.
- Added the `SearchField.IsStored`, `VectorSearchField.IsStored`, and `VectorSearchFieldAttribute.IsStored` property. It represent an immutable value indicating whether the field will be persisted separately on disk to be returned in a search result. This property is applicable only for vector fields.
- Added support for `sbyte` and `int16` to `SearchFieldDataType`.

## 11.6.0-beta.2 (2024-02-05)

### Features Added
- Publicly exposed HttpPipeline for all search clients.

### Bugs Fixed
- Removed the unintentional addition of the abstract keyword to the `KnowledgeStoreProjectionSelector` and `KnowledgeStoreStorageProjectionSelector` types.

## 11.6.0-beta.1 (2024-01-17)

### Features Added
- Added all the new types and updated the names as defined in the GA version [11.5.0](https://www.nuget.org/packages/Azure.Search.Documents/11.5.0).

## 11.5.1 (2023-11-28)

### Bugs Fixed
- Fix paging issue for semantic and vector search ([#40137](https://github.com/Azure/azure-sdk-for-net/issues/40137)).

## 11.5.0 (2023-11-10)

### Features Added
- Added support for [Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch.md).
- Added support for [Semantic Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample08_SemanticSearch.md).
- Added support for [`PiiDetectionSkill`](https://learn.microsoft.com/azure/search/cognitive-search-skill-pii-detection). It allows you extracts personal information from an input text and gives you the option of masking it using the Text Analytics API.
- Added new languages for `OcrSkill` and `ImageAnalysisSkill` as we have upgraded them to use Cognitive Services Computer Vision v3.2, which now includes support for additional languages. Refer to the language lists [here](https://learn.microsoft.com/azure/cognitive-services/computer-vision/language-support).
- Added new languages for ` SplitSkill`. Language lists can be found [here](https://learn.microsoft.com/azure/search/cognitive-search-skill-textsplit#skill-parameters).
- Deprecated `SentimentSkill.SkillVersion.V1` and `EntityRecognitionSkill.SkillVersion.V1`; use `SentimentSkill.SkillVersion.V3` and `EntityRecognitionSkill.SkillVersion.V3` instead.

## 11.5.0-beta.5 (2023-10-09)

### Features Added
- Added support for `VectorSearch.Vectorizers`, which contains configuration options for vectorizing text vector queries, and `VectorSearch.Profiles`, which define combinations of configurations to use with vector search.
- Added the `VectorSearchAlgorithmConfiguration` base type, containing configuration options specific to the algorithm used during indexing and/or querying. Derived classes include `ExhaustiveKnnVectorSearchAlgorithmConfiguration` and `HnswVectorSearchAlgorithmConfiguration`.
- Added the `SearchOptions.VectorQueries` base type, which is used for the query parameters for vector and hybrid search queries. Derived classes include `VectorizableTextQuery` and `RawVectorQuery`. With `RawVectorQuery`, users can pass raw vector values for vector search, while `VectorizableTextQuery` allows the passing of text values to be vectorized for vector search.
- Added `SearchOptions.VectorFilterMode`, determining whether filters are applied before or after vector search is executed.
- Added `SearchOptions.SemanticQuery`, which enables the setting of a dedicated search query for semantic reranking, semantic captions, and semantic answers.
- Added support for `AzureOpenAIEmbeddingSkill`, which enables the generation of vector embeddings for given text inputs using the Azure Open AI service.
- Added `SearchIndexStatistics.VectorIndexSize`, which reports the amount of memory consumed by vectors in the index.
- Added `KnowledgeStore.Parameters`, which defines a dictionary of knowledge store-specific configuration properties.
- Added `SearchIndexerSkillset.IndexProjections`, which specifies additional projections to secondary search indexes.

### Breaking Changes
- In `SearchOptions`, the `IList<SearchQueryVector> Vectors` property has been removed in favor of the abstract base type `IList<VectorQuery> VectorQueries`.
- In `SearchField`, the `vectorSearchConfiguration` property has been removed in favor of the new `VectorSearchProfile` property.
- In `VectorSearch`, `AlgorithmConfigurations` has been renamed to `Algorithms`.

## 11.5.0-beta.4 (2023-08-07)

### Features Added
- Added the ability to perform multiple vectors query searches.
- Added support for vector queries over multiple fields.

## 11.5.0-beta.3 (2023-07-11)

### Features Added
- Added support for [Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch.md).

### Bugs Fixed
- Fixed issue with `QueryCaptionsType.None` in semantic search, resolving an invalid response to the service ([#37164](https://github.com/Azure/azure-sdk-for-net/issues/37164)).

## 11.5.0-beta.2 (2022-10-11)

### Features Added
- Added new languages for `OcrSkill` and `ImageAnalysisSkill` as we have upgraded them to use Cognitive Services Computer Vision v3.2 which supports a lot more languages for both APIs. Language lists can be found [here](https://learn.microsoft.com/azure/cognitive-services/computer-vision/language-support).

### Bugs Fixed
- Fixed user-assigned identity type names ([#29813](https://github.com/Azure/azure-sdk-for-net/issues/29813)).

## 11.5.0-beta.1 (2022-09-06)

### Features Added
- All features from the 11.4.x betas that weren't included in [11.4.0](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/CHANGELOG.md#1140-2022-09-06).

## 11.4.0 (2022-09-06)

### Features Added
- Support for [Azure Active Directory](https://learn.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `SearchClient`, `SearchIndexClient` or a `SearchIndexerClient`. For example, you can get started with `new SearchClient(endpoint, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md). For more details see [how to use role-based authentication in Azure Cognitive Search](https://learn.microsoft.com/azure/search/search-security-rbac?tabs=config-svc-portal%2Crbac-portal).
- Added multi-cloud support via `SearchClientOptions.Audience` to allow users to select the Azure cloud where the resource is located ([#30306](https://github.com/Azure/azure-sdk-for-net/issues/30306)).

### Bugs Fixed
- Enhanced the documentation of some `SearchOptions` properties by adding links to REST docs - https://github.com/Azure/azure-sdk-for-net/issues/22808
- Fixed issue where `SearchOptions.SessionId` property was not passed to the service ([#27549](https://github.com/Azure/azure-sdk-for-net/issues/27549))

### Other Changes
- Added [Troubleshooting Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/TROUBLESHOOTING.md).

### Note 
- This GA release includes AAD with multi-cloud support and all the bug fixes since the last [11.3.0](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/CHANGELOG.md#1130-2021-06-08) GA release. Other preview features and breaking changes from the [11.4.0-beta.1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/CHANGELOG.md#1140-beta1-2021-07-06) to [11.4.0-beta.9](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/CHANGELOG.md#1140-beta9-2022-08-08) releases are not included in this GA release.

## 11.4.0-beta.9 (2022-08-08)

### Features Added
- Added support for [Lexical normalizers](https://learn.microsoft.com/azure/search/search-normalizers#normalizers) in `SimpleField` and `SearchableField`.
- Added multi-cloud support via `SearchClientOptions.Audience` to allow users to select the Azure cloud where the resource is located ([#30306](https://github.com/Azure/azure-sdk-for-net/issues/30306)).

## 11.4.0-beta.8 (2022-07-07)

### Bugs Fixed
- Fixed issue where `SearchOptions.SessionId` property was not passed to the service ([#27549](https://github.com/Azure/azure-sdk-for-net/issues/27549))

### Other Changes
- Added [Troubleshooting Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/TROUBLESHOOTING.md).

## 11.4.0-beta.7 (2022-03-08)

### Features Added
- Added support to create, update and delete aliases via the `SearchIndexClient`.

## 11.4.0-beta.6 (2022-02-08)

### Features Added
- Added `Unk` as an `OcrSkillLanguage` value. The values are used to set the default language code for the [OCR cognitive skill](https://learn.microsoft.com/azure/search/cognitive-search-skill-ocr).
- Support for [`AzureMachineLearningSkill`](https://learn.microsoft.com/azure/search/cognitive-search-aml-skill). The AML skill allows you to extend AI enrichment with a custom [Azure Machine Learning](https://learn.microsoft.com/azure/machine-learning/overview-what-is-azure-machine-learning) (AML) model. Once an AML model is [trained and deployed](https://learn.microsoft.com/azure/machine-learning/concept-azure-machine-learning-architecture#workspace), an AML skill integrates it into AI enrichment.

## 11.4.0-beta.5 (2021-11-09)

### Features Added
- Added support for [Semantic Search](https://learn.microsoft.com/azure/search/semantic-search-overview). `SearchOptions` now support specifying `SemanticSettings` to influence the search behavior.

### Breaking Changes
- Renamed `IndexerStateHighWaterMark` to `IndexerChangeTrackingState`.
- Renamed the property `HighWaterMark` to `ChangeTrackingState` in `IndexerState`.

## 11.4.0-beta.4 (2021-10-05)

### Features Added
- Added APIs to [reset documents](https://learn.microsoft.com/azure/search/search-howto-run-reset-indexers#reset-docs-preview) and [skills](https://learn.microsoft.com/azure/search/search-howto-run-reset-indexers#reset-skills-preview).

### Breaking Changes
- Renamed `QueryAnswer` to `QueryAnswerType` in `SearchOptions`.
- Renamed `QueryCaption` to `QueryCaptionType` in `SearchOptions`.
- Renamed `QuerySpeller` to `QuerySpellerType` in `SearchOptions`.
- Renamed `QueryCaptionHighlight` to `QueryCaptionHighlightEnabled` in `SearchOptions`.

## 11.4.0-beta.3 (2021-09-07)

### Features Added
- Support for [Lexical normalizers](https://learn.microsoft.com/azure/search/search-normalizers#normalizers) in [text analysers](https://learn.microsoft.com/rest/api/searchservice/test-analyzer) via `AnalyzeTextOptions`.

## 11.4.0-beta.2 (2021-08-10)

### Features Added
- Support for [Azure Active Directory](https://learn.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `SearchClient`, `SearchIndexClient` or a `SearchIndexerClient`. For example, you can get started with `new SearchClient(endpoint, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md). For more details see [how to use role-based authentication in Azure Cognitive Search](https://learn.microsoft.com/azure/search/search-security-rbac?tabs=config-svc-portal%2Crbac-portal).

### Bugs Fixed
- Enhanced the documentation of some `SearchOptions` properties by adding links to REST docs - https://github.com/Azure/azure-sdk-for-net/issues/22808

## 11.4.0-beta.1 (2021-07-06)

### Features Added
- Support for additional/enhanced skills - [EntityLinkingSkill](https://learn.microsoft.com/azure/search/cognitive-search-skill-entity-linking-v3), [EntityRecognitionSkill](https://learn.microsoft.com/azure/search/cognitive-search-skill-entity-recognition-v3), [PiiDetectionSkill](https://learn.microsoft.com/azure/search/cognitive-search-skill-pii-detection), [SentimentSkill](https://learn.microsoft.com/azure/search/cognitive-search-skill-sentiment-v3)
- Use managed identities in Azure Active Directory with [SearchIndexerDataIdentity](https://learn.microsoft.com/azure/search/search-howto-managed-identities-data-sources)

## 11.3.0 (2021-06-08)

### Added
- Adds stable features and bug fixes from the [11.3.0-beta.1](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Search.Documents_11.3.0-beta.1/sdk/search/Azure.Search.Documents/CHANGELOG.md#1130-beta1-2021-04-06) and [11.3.0-beta.2](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Search.Documents_11.3.0-beta.2/sdk/search/Azure.Search.Documents/CHANGELOG.md#1130-beta2-2021-05-11) releases. Preview service features not generally available yet, like Semantic Search and Normalizers, are not included in this GA release.

## 11.3.0-beta.2 (2021-05-11)

### Added
- Added support for [Semantic Search](https://learn.microsoft.com/azure/search/semantic-search-overview).

## 11.3.0-beta.1 (2021-04-06)

### Added
- Added support for [`Azure.Core.GeoJson`](https://learn.microsoft.com/dotnet/api/azure.core.geojson) types in `SearchDocument`, `SearchFilter` and `FieldBuilder`.
- Added [`EventSource`](https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource) based logging. Event source name is **Azure-Search-Documents**. Current set of events are focused on tuning batch sizes for [`SearchIndexingBufferedSender`](https://learn.microsoft.com/dotnet/api/azure.search.documents.searchindexingbufferedsender-1).
- Added [`CustomEntityLookupSkill`](https://learn.microsoft.com/azure/search/cognitive-search-skill-custom-entity-lookup) and [`DocumentExtractionSkill`](https://learn.microsoft.com/azure/search/cognitive-search-skill-document-extraction). Added `DefaultCountryHint` in [`LanguageDetectionSkill`](https://learn.microsoft.com/azure/search/cognitive-search-skill-language-detection).
- Added [`LexicalNormalizer`](https://learn.microsoft.com/azure/search/search-normalizers#predefined-normalizers) to include predefined set of normalizers. See [here](https://learn.microsoft.com/azure/search/search-normalizers) for more details on search normalizers. Added `Normalizer` as a [`SearchField`](https://learn.microsoft.com/dotnet/api/azure.search.documents.indexes.models.searchfield) in an index definition.
- Added support for Azure Data Lake Storage Gen2 - [`AdlsGen2`](https://learn.microsoft.com/azure/storage/blobs/data-lake-storage-introduction) in [`SearchIndexerDataSourceType`](https://learn.microsoft.com/dotnet/api/azure.search.documents.indexes.models.searchindexerdatasourcetype).

## 11.2.0 (2021-02-10)

### Added

- Added setters for `MaxLength` and `MinLength` in `LengthTokenFilter`.
- Added a public constructor for `SearchIndexingBufferedSender<T>`.
- Added `IndexActionEventArgs<T>` to track indexing actions.
- Added `IndexActionCompletedEventArgs<T>` to track the completion of an indexing action.
- Added `IndexActionFailedEventArgs<T>` to track the failure of an indexing action.
- All changes from the 11.2.0-beta.2 and 11.2.0-beta.1 releases listed below.

### Breaking Changes

- Renamed `SearchIndexingBufferedSenderOptions<T>.MaxRetries` to `SearchIndexingBufferedSenderOptions<T>.MaxRetriesPerIndexAction`.
- Renamed `SearchIndexingBufferedSenderOptions<T>.MaxRetryDelay` to `SearchIndexingBufferedSenderOptions<T>.MaxThrottlingDelay`.
- Renamed `SearchIndexingBufferedSenderOptions<T>.RetryDelay` to `SearchIndexingBufferedSenderOptions<T>.ThrottlingDelay`.
- Removed the helper method `SearchClient.CreateIndexingBufferedSender<T>()`. Instead, callers are expected to use the public constructor of `SearchIndexingBufferedSender<T>`.

## 11.2.0-beta.2 (2020-11-10)

### Added

- Added `EncryptionKey` to `SearchIndexer`, `SearchIndexerDataSourceConnection`, and `SearchIndexerSkillset`.
- Added configuration options to tune the performance of `SearchIndexingBufferedSender<T>`.

### Fixed

- Fixed issue calling `SearchIndexClient.GetIndexNames` that threw an exception ([#15590](https://github.com/Azure/azure-sdk-for-net/issues/15590))
- Fixed issue where `ScoringProfile.FunctionAggregation` did not correctly handle null values ([#16570](https://github.com/Azure/azure-sdk-for-net/issues/16570))
- Fixed overly permissive date parsing on facets ([#16412](https://github.com/Azure/azure-sdk-for-net/issues/16412))

## 11.2.0-beta.1 (2020-10-09)

### Added

- Add `SearchIndexingBufferedSender<T>` to make indexing lots of documents fast and easy.
- Add support to `FieldBuilder` to define search fields for `Microsoft.Spatial` types without an explicit assembly dependency.
- Add support to `SearchFilter` to encode geometric types from `Microsoft.Spatial` without an explicit assembly dependency.
- Add `IndexingParameters.IndexingParametersConfiguration` property to define well-known properties supported by Azure Cognitive Search.

### Fixed

- Support deserializing null values during deserialization of skills ([#15108](https://github.com/Azure/azure-sdk-for-net/issues/15108))
- Fixed issues preventing mocking clients or initializing all models.

## 11.1.1 (2020-08-18)

### Fixed

- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 11.1.0 (2020-08-11)

### Added

- Added `SearchClientOptions.Serializer` to set which `ObjectSerializer` to use for serialization.
- Added `FieldBuilder` to easily create `SearchIndex` fields from a model type.

### Removed

- Removed `$select` from the query parameters logged by default.  You can add it back via `SearchClientOptions.Diagnostics.LoggedQueryParameters("$select");` if desired.

## 11.0.0 (2020-07-07)

### Changed

- Changed version to 11.0.0.
- Removed preview version `SearchClientOptions.ServiceVersion.V2019_05_06_Preview`
  and added version `SearchClientOptions.ServiceVersion.V2020_06_30`.

### Removed

- Removed `Azure.Core.Experimental` reference and features until they're moved
  into `Azure.Core`.
- Removed `SearchServiceCounters.SkillsetCounter`.
- Removed `new SearchOptions(string continuationToken)` overload.

## 1.0.0-preview.4 (2020-06-09)

### Added

- Referencing `Azure.Core.Experimental` which brings new spatial types and custom serializers.
- Added `SearchClientBuilderExtensions` to integrate with ASP.NET Core.
- Added `SearchModelFactory` to mock output model types.

### Breaking Changes

- Made collection- and dictionary-type properties read-only, i.e. has only get-accessors, based on [.NET Guidelines][net-guidelines-collection-properties].
- Moved models for managing indexes, indexers, and skillsets to `Azure.Search.Documents.Indexes.Models`.
- Removed the `SynonymMap.Format` property since only the "solr" format is supported currently.
- Renamed `AnalyzeRequest` to `AnalyzeTextOptions`, and overloaded constructors with required parameters.
- Renamed `AnalyzeTextOptions.Analyzer` to `AnalyzeTextOptions.AnalyzerName`.
- Renamed `AnalyzeTextOptions.Tokenizer` to `AnalyzeTextOptions.TokenizerName`.
- Renamed `CustomAnalyzer.Tokenizer` to `CustomAnalyzer.TokenizerName`.
- Renamed `SearchIndexerDataSource` to `SearchIndexerDataSourceConnection`.
- Renamed `Autocompletion` to `AutocompleteItem`.
- Renamed methods on `SearchIndexerClient` matching "\*DataSource" to "\*DataSourceConnection".
- Split `SearchServiceClient` into `SearchIndexClient` for managing indexes, and `SearchIndexerClient` for managing indexers, both of which are now in `Azure.Search.Documents.Indexes`.
- `SearchClient.IndexDocuments` now throws an `AggregateException` wrapping all the `RequestFailedException`s in the batch.
- Removed `dynamic` support from `SearchDocument` for the time being.

## 1.0.0-preview.3 (2020-05-05)

### Breaking Changes

- Renamed `SearchIndexClient` to `SearchClient`.
- Removed constructor from `SynonymMap` with `IEnumerable<string>` parameter.
- `SearchServiceClient.GetIndexes` and `SearchServiceClient.GetIndexesAsync` now return `Pageable<SearchIndex>` and `AsyncPageable<SearchIndex>` respectively.
- Replaced `MatchConditions` parameters with `bool onlyIfUnchanged` parameters that require a model with an `ETag` property.
- `ETag` properties have been redefined from `string` to `Azure.ETag?` consistent with other packages.
- Renamed `Analyzer` to `LexicalAnalyzer`.
- Renamed `AnalyzerName` to `LexicalAnalyzerName`.
- Removed `AzureActiveDirectoryApplicationCredentials` and moved its `ApplicationId` and `ApplicationSecret` properties to `SearchResourceEncryptionKey`.
- Renamed `DataContainer` to `SearchIndexerDataContainer`.
- Renamed `DataSource` to `SearchIndexerDataSource`.
- Removed `DataSourceCredentials` and moved its `ConnectionString` property to `SearchIndexerDataSource`.
- Renamed `DataSourceType` to `SearchIndexerDataSourceType`.
- Renamed `DataType` to `SearchFieldDataType`.
- Renamed `EncryptionKey` to `SearchResourceEncryptionKey`.
- Renamed `EncryptionKey.KeyVaultUri` to `SearchResourceEncryptionKey.VaultUri`.
- Renamed `EncryptionKey.KeyVaultKeyName` to `SearchResourceEncryptionKey.KeyName`.
- Renamed `EncryptionKey.KeyVaultKeyVersion` to `SearchResourceEncryptionKey.KeyVersion`.
- Renamed `Field` to `SearchField`.
- Renamed `FieldBase` to `SearchFieldTemplate`.
- Renamed `Index` to `SearchIndex`.
- Renamed `Indexer` to `SearchIndexer`.
- Renamed `IndexerExecutionInfo` to `SearchIndexerStatus`.
- Renamed `IndexerLimits` to `SearchIndexerLimits`.
- Renamed `ItemError` to `SearchIndexerError`.
- Renamed `ItemWarning` to `SearchIndexerWarning`.
- Renamed `LengthTokenFilter.Min` to `LengthTokenFilter.MinLength`.
- Renamed `LengthTokenFilter.Max` to `LengthTokenFilter.MaxLength`.
- Renamed `RegexFlags` to `RegexFlag` following .NET naming guidelines.
- Renamed `Skill` to `SearchIndexerSkill`.
- Renamed `Skillset` to `SearchIndexerSkillset`.
- Renamed `StandardAnalyzer` to `LuceneStandardAnalyzer`.
- Renamed `StandardTokenizer` to `LuceneStandardTokenizer`.
- Renamed `StandardTokenizerV2` to `LuceneStandardTokenizerV2`.
- Renamed `TokenInfo` to `AnalyzedTokenInfo`.
- Renamed `Tokenizer` to `LexicalTokenizer`.
- Renamed `TokenizerName` to `LexicalTokenizerName`.

## 1.0.0-preview.2 (2020-04-06)

### Added

- Added models and methods to `SearchServiceClient` to create and manage indexes.
- Added support for continuation tokens to resume server-side paging.

### Breaking Changes

- Renamed to Azure.Search.Documents (assembly, namespace, and package)
- Replaced SearchApiKeyCredential with AzureKeyCredential
- Renamed `SearchServiceClient.GetStatistics` and `SearchServiceClient.GetStatisticsAsync` to `SearchServiceClient.GetServiceStatistics` and `SearchServiceClient.GetServiceStatisticsAsync`

## 11.0.0-preview.1 (2020-03-13)

- Initial preview of the Azure.Search client library enabling you to query
  and update documents in search indexes.
