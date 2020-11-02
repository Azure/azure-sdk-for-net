# Release History

## 1.0.0-beta.2 (Unreleased)

### New Features
- Added a public constructor to `DataFeed`.
- Added the `DataSource` property to `DataFeed`.
- All `DataSource`s now have public properties exposing the associated parameters used to get the data, such as endpoints, connection strings, and query strings.

### Breaking Changes
- In `MetricsAdvisorClient`, changed return types of sync and async `CreateMetricFeedback` methods to a `Response<string>` containing the ID of the created feedback.
- In `MetricsAdvisorClient`, changed return types of sync and async methods `GetIncidentRootCauses`, `GetMetricEnrichedSeriesData`, and `GetMetricSeriesData` to pageables.
- In `MetricsAdvisorAdministrationClient`, updated `CreateDataFeed` and `CreateDataFeedAsync` to take a whole `DataFeed` object as a parameter.
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async `Create` methods (e.g., `CreateDataFeed`) to a `Response<string>` containing the ID of the created resource.
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async methods `GetAnomalyAlertConfigurations` and `GetMetricAnomalyDetectionConfigurations` to pageables.
- In `MetricsAdvisorAdministrationClient`, renamed parameter `alertConfigurationId` to `detectionConfigurationId` in sync and async `GetAnomalyAlertConfigurations` methods.
- In `MetricEnrichedSeriesData`, made elements of `ExpectedValues`, `Periods`, `IsAnomaly`, `LowerBoundaries` and `UpperBoundaries` nullables.
- Removed `MetricsAdvisorClientOptions` and `MetricsAdvisorAdministrationOptions` and replaced both with `MetricsAdvisorClientsOptions`.
- Removed `DataFeedOptions`. All of its properties were moved directly into `DataFeed`.
- Renamed `MetricDimension` to `DataFeedDimension`.
- Renamed `DataAnomaly` to `DataPointAnomaly`.
- Renamed `IncidentStatus` to `AnomalyIncidentStatus`.
- Renamed `AlertingHook`, `EmailHook`, and `WebHook` to `NotificationHook`, `EmailNotificationHook`, and `WebNotificationHook`, respectively.
- Renamed `TimeMode` to `AlertQueryTimeMode`.
- In `ElasticsearchDataFeedSource`, renamed the constructor parameter `authHeader` to `authorizationHeader`.

### Key Bug Fixes
- Fixed a bug in `GetMetricEnrichedSeriesData` sync and async methods where a `NullReferenceException` was thrown if a returned data point had missing data.

## 1.0.0-beta.1 (2020-10-08)

This is the first beta of the `Azure.AI.MetricsAdvisor` client library.

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

[readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
