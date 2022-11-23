# Release History

## 1.0.0-beta.2 (2022-12-01)

### Features Added
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricNamespaces`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDefinitions`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetrics`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateAppComponents`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListAppComponents`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateServerMetricsConfig`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.GetServerMetricsConfig`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestScriptValidationStatus`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestRunStatus`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricNamespacesAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDefinitionsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateAppComponentsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListAppComponentsAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.CreateOrUpdateServerMetricsConfigAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.GetServerMetricsConfigAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestScriptValidationStatusAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.BeginTestRunStatusAsync`
- Method Addded `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestRunClient.ListMetricDimensionValues`

### Breaking Changes
- Renamed sublcient from `TestRunClinet` to `LoadTestRunClient`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteLoadTest` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteTest`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetLoadTest` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetTest`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListLoadTest` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListTest`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetLoadTestSearches` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListLoadTests`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAllTestFiles` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListTestFiles`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAppComponent` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListAppComponents`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerMetrics` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListServerMetricsConfig`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.CreateAndUpdateTest` to `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.CreateOrUpdateTestRun`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunSearches` to `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.ListTestRuns`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteLoadTestAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteTestAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetLoadTestAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetTestAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListLoadTestAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListTestAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetLoadTestSearchesAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListLoadTestsAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAllTestFilesAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListTestFilesAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAppComponentAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListAppComponentsAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerMetricsAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListServerMetricsConfigAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.CreateAndUpdateTestAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.CreateOrUpdateTestRunAsync`
- Renamed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunSearchesAsync` to `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.ListTestRunsAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunClientMetrics`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunClientMetricsAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunClientMetricsFilters`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.TestRunClient.GetTestRunClientMetricsFiltersAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteAppComponent`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteAppComponentAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAppComponentByName`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetAppComponentByNameAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerMetricsByName`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerMetricsByNameAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteServerMetrics`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.DeleteServerMetricsAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerDefaultMetrics`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.GetServerDefaultMetricsAsync`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListSupportedResourceType`
- Removed `Azure.Developer.LoadTesting.LoadTestingClient.LoadTestAdministrationClient.ListSupportedResourceTypeAsync`

### Other Changes
- README Updated 

## 1.0.0-beta.1 (2022-10-25)

### Features Added
- Initial preview release features added for Azure Loadtesting SDK
