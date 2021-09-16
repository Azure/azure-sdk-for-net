# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2021-09-08)

### Features Added
- `Endpoint` is a public property in `LogsQueryClient`

### Breaking Changes
- `NamespaceCollection` renamed to `MetricNamespaceCollection`
- `QueryModelFactory` renamed to `MonitorQueryModelFactory`
- `TimeSeriesElement` renamed to `MetricTimeSeriesElement`
- `Data` renamed as `Values` in `MetricTimeSeriesElement`
- `Top` renamed to `Size` in `MetricsQueryOptions`
- Updated `GetObject` methods to be internal in `LogsTableRow`

### Bugs Fixed
- Updated `GetResult()` in `LogsBatchQueryResult` to return a `LogsBatchQueryResult`

### Other Changes
- `ServiceVersion` numbering starts at 1 instead of 0 in `LogsQueryClientOptions` and `MetricsQueryClientOptions`

## 1.0.0-beta.3 (2021-08-10)

### Breaking Changes
- `LogsQueryResult.PrimaryTable` renamed to `Table`, and `LogsQueryResult.Tables` to `AllTables`.
- `MetricQueryResult` renamed to `MetricsQueryResult`
- `GetMetricNamespaces` and `GetMetricDefinitions` return `Pageable` types.

## 1.0.0-beta.2 (2021-07-06)

### New Features

- Added support for including rendering information using the `IncludeVisualization` property.
- Added a `LogsQueryClient` constructor that uses the default Log Analytics endpoint.
- Added error information in `LogsQueryResult` and `Metric`.
- Added `dynamic` column type support.

## 1.0.0-beta.1 (2021-06-08)

- First beta release of Azure.Monitor.Query
