# Release History

## 1.0.0-preview.5 (Unreleased)


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
