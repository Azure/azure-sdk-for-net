# Release History

## 1.0.0-preview.3 (Unreleased)

### Breaking Changes

- Removed constructor from `SynonymMap` with `IEnumerable<string>` parameter.
- `SearchServiceClient.GetIndexes` and `SearchServiceClient.GetIndexesAsync` now return `Pageable<SearchIndex>` and `AsyncPageable<SearchIndex>` respectively.

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
