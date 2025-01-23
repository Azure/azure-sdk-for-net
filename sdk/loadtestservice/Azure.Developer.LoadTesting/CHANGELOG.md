# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.2 (2025-01-20)

### Other Changes
- Add NOT_VALIDATED to the list of terminal states for the file validation poller.

## 1.0.1 (2023-03-11)

### Other Changes
- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.0.0 (2023-03-07)

### Breaking Changes
- Made `Azure.Developer.LoadTesting.LoadTestAdministrationClient.UploadTestFileAsync` internal
- Made `Azure.Developer.LoadTesting.LoadTestRunClient.CreateOrUpdateTestRunAsync` internal

## 1.0.0-beta.2 (2023-01-13)

### Features Added
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricNamespaces`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDefinitions`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetrics`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateAppComponents`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListAppComponents`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateServerMetricsConfig`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.GetServerMetricsConfig`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginUploadTestFile`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestRun`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricNamespacesAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDefinitionsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateAppComponentsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListAppComponentsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateServerMetricsConfigAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.GetServerMetricsConfigAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginUploadTestFile`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestRun`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDimensionValues`

### Breaking Changes
- Changed from single client and 2 subclients pattern to two clients pattern

### Other Changes
- README Updated 

## 1.0.0-beta.1 (2022-10-25)

### Features Added
- Initial preview release features added for Azure Loadtesting SDK
