# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
