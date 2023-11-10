# Release History

## 11.5.0 (2023-11-10)

### Features Added
- Added support for [Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch.md).
- Added support for [Semantic Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample08_SemanticSearch.md).
- Added support for [`PiiDetectionSkill`](https://learn.microsoft.com/azure/search/cognitive-search-skill-pii-detection). It allows you extracts personal information from an input text and gives you the option of masking it using the Text Analytics API.
- Added new languages for `OcrSkill` and `ImageAnalysisSkill` as we have upgraded them to use Cognitive Services Computer Vision v3.2, which now includes support for additional languages. Refer to the language lists [here](https://docs.microsoft.com/azure/cognitive-services/computer-vision/language-support).
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
- Added new languages for `OcrSkill` and `ImageAnalysisSkill` as we have upgraded them to use Cognitive Services Computer Vision v3.2 which supports a lot more languages for both APIs. Language lists can be found [here](https://docs.microsoft.com/azure/cognitive-services/computer-vision/language-support).

### Bugs Fixed
- Fixed user-assigned identity type names ([#29813](https://github.com/Azure/azure-sdk-for-net/issues/29813)).

## 11.5.0-beta.1 (2022-09-06)

### Features Added
- All features from the 11.4.x betas that weren't included in [11.4.0](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/CHANGELOG.md#1140-2022-09-06).

## 11.4.0 (2022-09-06)

### Features Added
- Support for [Azure Active Directory](https://docs.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `SearchClient`, `SearchIndexClient` or a `SearchIndexerClient`. For example, you can get started with `new SearchClient(endpoint, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md). For more details see [how to use role-based authentication in Azure Cognitive Search](https://docs.microsoft.com/azure/search/search-security-rbac?tabs=config-svc-portal%2Crbac-portal).
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
- Added support for [Lexical normalizers](https://docs.microsoft.com/azure/search/search-normalizers#normalizers) in `SimpleField` and `SearchableField`.
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
- Added `Unk` as an `OcrSkillLanguage` value. The values are used to set the default language code for the [OCR cognitive skill](https://docs.microsoft.com/azure/search/cognitive-search-skill-ocr).
- Support for [`AzureMachineLearningSkill`](https://docs.microsoft.com/azure/search/cognitive-search-aml-skill). The AML skill allows you to extend AI enrichment with a custom [Azure Machine Learning](https://docs.microsoft.com/azure/machine-learning/overview-what-is-azure-machine-learning) (AML) model. Once an AML model is [trained and deployed](https://docs.microsoft.com/azure/machine-learning/concept-azure-machine-learning-architecture#workspace), an AML skill integrates it into AI enrichment.

## 11.4.0-beta.5 (2021-11-09)

### Features Added
- Added support for [Semantic Search](https://docs.microsoft.com/azure/search/semantic-search-overview). `SearchOptions` now support specifying `SemanticSettings` to influence the search behavior.

### Breaking Changes
- Renamed `IndexerStateHighWaterMark` to `IndexerChangeTrackingState`.
- Renamed the property `HighWaterMark` to `ChangeTrackingState` in `IndexerState`.

## 11.4.0-beta.4 (2021-10-05)

### Features Added
- Added APIs to [reset documents](https://docs.microsoft.com/azure/search/search-howto-run-reset-indexers#reset-docs-preview) and [skills](https://docs.microsoft.com/azure/search/search-howto-run-reset-indexers#reset-skills-preview).

### Breaking Changes
- Renamed `QueryAnswer` to `QueryAnswerType` in `SearchOptions`.
- Renamed `QueryCaption` to `QueryCaptionType` in `SearchOptions`.
- Renamed `QuerySpeller` to `QuerySpellerType` in `SearchOptions`.
- Renamed `QueryCaptionHighlight` to `QueryCaptionHighlightEnabled` in `SearchOptions`.

## 11.4.0-beta.3 (2021-09-07)

### Features Added
- Support for [Lexical normalizers](https://docs.microsoft.com/azure/search/search-normalizers#normalizers) in [text analysers](https://docs.microsoft.com/rest/api/searchservice/test-analyzer) via `AnalyzeTextOptions`.

## 11.4.0-beta.2 (2021-08-10)

### Features Added
- Support for [Azure Active Directory](https://docs.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `SearchClient`, `SearchIndexClient` or a `SearchIndexerClient`. For example, you can get started with `new SearchClient(endpoint, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md). For more details see [how to use role-based authentication in Azure Cognitive Search](https://docs.microsoft.com/azure/search/search-security-rbac?tabs=config-svc-portal%2Crbac-portal).

### Bugs Fixed
- Enhanced the documentation of some `SearchOptions` properties by adding links to REST docs - https://github.com/Azure/azure-sdk-for-net/issues/22808

## 11.4.0-beta.1 (2021-07-06)

### Features Added
- Support for additional/enhanced skills - [EntityLinkingSkill](https://docs.microsoft.com/azure/search/cognitive-search-skill-entity-linking-v3), [EntityRecognitionSkill](https://docs.microsoft.com/azure/search/cognitive-search-skill-entity-recognition-v3), [PiiDetectionSkill](https://docs.microsoft.com/azure/search/cognitive-search-skill-pii-detection), [SentimentSkill](https://docs.microsoft.com/azure/search/cognitive-search-skill-sentiment-v3)
- Use managed identities in Azure Active Directory with [SearchIndexerDataIdentity](https://docs.microsoft.com/azure/search/search-howto-managed-identities-data-sources)

## 11.3.0 (2021-06-08)

### Added
- Adds stable features and bug fixes from the [11.3.0-beta.1](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Search.Documents_11.3.0-beta.1/sdk/search/Azure.Search.Documents/CHANGELOG.md#1130-beta1-2021-04-06) and [11.3.0-beta.2](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Search.Documents_11.3.0-beta.2/sdk/search/Azure.Search.Documents/CHANGELOG.md#1130-beta2-2021-05-11) releases. Preview service features not generally available yet, like Semantic Search and Normalizers, are not included in this GA release.

## 11.3.0-beta.2 (2021-05-11)

### Added
- Added support for [Semantic Search](https://docs.microsoft.com/azure/search/semantic-search-overview).

## 11.3.0-beta.1 (2021-04-06)

### Added
- Added support for [`Azure.Core.GeoJson`](https://docs.microsoft.com/dotnet/api/azure.core.geojson) types in `SearchDocument`, `SearchFilter` and `FieldBuilder`.
- Added [`EventSource`](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource) based logging. Event source name is **Azure-Search-Documents**. Current set of events are focused on tuning batch sizes for [`SearchIndexingBufferedSender`](https://docs.microsoft.com/dotnet/api/azure.search.documents.searchindexingbufferedsender-1).
- Added [`CustomEntityLookupSkill`](https://docs.microsoft.com/azure/search/cognitive-search-skill-custom-entity-lookup) and [`DocumentExtractionSkill`](https://docs.microsoft.com/azure/search/cognitive-search-skill-document-extraction). Added `DefaultCountryHint` in [`LanguageDetectionSkill`](https://docs.microsoft.com/azure/search/cognitive-search-skill-language-detection).
- Added [`LexicalNormalizer`](https://docs.microsoft.com/azure/search/search-normalizers#predefined-normalizers) to include predefined set of normalizers. See [here](https://docs.microsoft.com/azure/search/search-normalizers) for more details on search normalizers. Added `Normalizer` as a [`SearchField`](https://docs.microsoft.com/dotnet/api/azure.search.documents.indexes.models.searchfield) in an index definition.
- Added support for Azure Data Lake Storage Gen2 - [`AdlsGen2`](https://docs.microsoft.com/azure/storage/blobs/data-lake-storage-introduction) in [`SearchIndexerDataSourceType`](https://docs.microsoft.com/dotnet/api/azure.search.documents.indexes.models.searchindexerdatasourcetype).

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

[net-guidelines-collection-properties]: https://docs.microsoft.com/dotnet/standard/design-guidelines/guidelines-for-collections#collection-properties-and-return-values
