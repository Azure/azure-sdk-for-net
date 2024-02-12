# Release History

## 1.3.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Enable national cloud support for US Gov and China clouds

### Other Changes

## 1.3.0-beta.2 (2023-12-05)

### Other Changes
- Internal updates to generated code.

## 1.3.0-beta.1 (2023-10-18)

### Features Added
- Added the `MetricsBatchQueryClient` client to support batch querying of metrics.
- Added `QueryBatch` and `QueryBatchAsync` methods to `MetricsBatchQueryClient`

## 1.2.0 (2023-05-22)

### Bugs Fixed
- `QueryResourceAsync<T>` method was not returning the correct value.

## 1.2.0-beta.1 (2023-05-09)
### Features Added
- Added Client Builder Extension methods for `LogsQueryClient` and `MetricsQueryClient`
- Added the `QueryResource` method to `LogsQueryClient` to allow users to query Azure resources directly without the context of a workspace.

## 1.1.0 (2022-01-25)

### Features Added
Added the following methods to `MonitorQueryModelFactory`:
- `LogsQueryResult`
- `LogsTable`
- `LogsTableRow`
- `MetricsQueryResult`
- `MetricValue`
- `MetricTimeSeriesElement`

## 1.0.1 (2021-11-09)

### Bugs Fixed
- NaN, +inf, and -inf double values can now be retrieved from `LogsQueryResult`

## 1.0.0 (2021-10-07)

### Features Added
- Added `GetMetricByName` to `MetricsQueryResult`
- Added `MetricsQueryResult` to `MonitorQueryModelFactory`
- Added `LogsQueryResult` to `MonitorQueryModelFactory`

### Breaking Changes
- `Query` renamed to `QueryWorkspace` in `LogsQueryClient`
- `Query` renamed to `QueryResource` in `MetricsQueryClient`
- `Interval` renamed to `Granularity` in `MetricsQueryResult`
- `DisplayDescription` renamed to `Description` in `MetricResult`
- `Type` renamed to `ResourceType` in `MetricResult`
- Removed `LogsQueryClientAudience` and `MetricsQueryClientAudience` types and corresponding properties on `MetricsQueryClientOptions` and `LogsQueryClientOptions`.

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
