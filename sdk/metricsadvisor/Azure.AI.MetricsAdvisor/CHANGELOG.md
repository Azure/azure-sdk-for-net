# Release History

## 1.0.0-beta.2 (Unreleased)

### New Features
- Added a public constructor to `DataFeed`.
- Added the `DataSource` property to `DataFeed`.
- Added a public setter to `DataFeed.Options`.

### Breaking Changes
- In `MetricsAdvisorClient`, renamed `CreateMetricFeedback` sync and async methods to `AddMetricFeedback`.
- In `MetricsAdvisorClient`, renamed `GetMetricFeedbacks` sync and async methods to `GetAllMetricFeedback`.
- In `MetricsAdvisorClient`, renamed `GetMetricDimensionValues` sync and async methods to `GetDimensionValues`.
- In `MetricsAdvisorClient`, changed return types of sync and async methods `GetIncidentRootCauses`, `GetMetricEnrichedSeriesData`, and `GetMetricSeriesData` to pageables.
- In `MetricsAdvisorAdministrationClient`, updated `CreateDataFeed` and `CreateDataFeedAsync` to take a whole `DataFeed` object as a parameter.
- In `MetricsAdvisorAdministrationClient`, renamed the sync and async `AnomalyAlertConfiguration` CRUD methods, removing the `Anomaly` word from their names (e.g., `GetAnomalyAlertConfiguration` became `GetAlertConfiguration`).
- In `MetricsAdvisorAdministrationClient`, renamed the sync and async `MetricAnomalyDetectionConfiguration` CRUD methods, removing the `MetricAnomaly` term from their names (e.g., `GetMetricAnomalyDetectionConfiguration` became `GetDetectionConfiguration`).
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async methods `GetAnomalyAlertConfigurations` and `GetMetricAnomalyDetectionConfigurations` to pageables.
- In `MetricsAdvisorAdministrationClient`, renamed parameter `alertConfigurationId` to `detectionConfigurationId` in sync and async `GetAnomalyAlertConfigurations` methods.
- In `MetricEnrichedSeriesData`, made elements of `ExpectedValues`, `Periods`, `IsAnomaly`, `LowerBoundaries` and `UpperBoundaries` nullables.
- Removed `MetricsAdvisorClientOptions` and `MetricsAdvisorAdministrationOptions` and replaced both with `MetricsAdvisorClientsOptions`.
- Renamed `GetMetricFeedbacksOptions` to `GetAllMetricFeedbackOptions`.
- Renamed `GetMetricDimensionValuesOptions` to `GetDimensionValuesOptions`.
- Renamed `MetricDimension` to `DataFeedDimension`.
- Renamed `DataAnomaly` to `DataPointAnomaly`.
- Renamed `IncidentStatus` to `AnomalyIncidentStatus`.
- Renamed `AlertingHook`, `EmailHook`, and `WebHook` to `NotificationHook`, `EmailNotificationHook`, and `WebNotificationHook`, respectively.
- Renamed `TimeMode` to `AlertQueryTimeMode`.

### Key Bug Fixes
- Fixed a bug in `GetMetricEnrichedSeriesData` sync and async methods where a `NullReferenceException` was thrown if a returned data point had missing data.

## 1.0.0-beta.1 (2020-10-08)

This is the first beta of the `Azure.AI.MetricsAdvisor` client library.

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

[readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
