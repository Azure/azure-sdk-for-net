# Release History

## 11.4.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
