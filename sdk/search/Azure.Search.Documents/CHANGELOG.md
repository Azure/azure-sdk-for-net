# Release History

## 11.2.0-beta.3 (Unreleased)


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
