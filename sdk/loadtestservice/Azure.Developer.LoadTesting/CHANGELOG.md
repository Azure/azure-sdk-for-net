# Release History

## 1.2.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.1 (2025-04-15)

### Features Added

- Added capabilities to support all changes present in Azure Load Testing API Version 2024-05-01-preview
- This release adds all the models for all the APIs supported by Azure Load Testing. Relevant new client method overloads are also added to work with these new methods
- Added support for the following features:
    - Support for specifying AutoStopCriteria for LoadTests
    - Support for Quick Load Tests with `RequestsPerSecond` input
    - Support for URL Tests with JSON Based Test Plans and Locust Tests using the `TestKind` field
    - Support for multi region load tests to generate load from multiple regions
    - Support for disabling Public IP Deployment for Private Load Tests using the `publicIpDisabled` field
    - Support for uploading Zipped Artifacts as test input artifacts
- Added Client Methods to work with `TestProfiles` and `TestProfileRuns`
    - Added methods `CreateOrUpdateTestProfile`, `GetTestProfile`, `DeleteTestProfile` and `GetTestProfiles` along with their async variants to work with test profiles
    - Added methods `BeginTestProfileRun`, `GetTestProfileRun`, `DeleteTestProfileRun` and `GetTestProfileRuns` along with their async variants to work with test profile runs

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
