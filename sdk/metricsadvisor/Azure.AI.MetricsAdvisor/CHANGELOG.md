# Release History

## 1.0.0-beta.2 (Unreleased)

### Breaking Changes
- In `MetricsAdvisorClient`, changed return types of sync and async methods `GetIncidentRootCauses`, `GetMetricEnrichedSeriesData`, and `GetMetricSeriesData` to pageables.
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async methods `GetAnomalyAlertConfigurations` and `GetMetricAnomalyDetectionConfigurations` to pageables.
- In `MetricsAdvisorAdministrationClient`, renamed parameter `alertConfigurationId` to `detectionConfigurationId` in sync and async `GetAnomalyAlertConfigurations` methods.
- In `MetricEnrichedSeriesData`, made elements of `ExpectedValues`, `Periods`, `IsAnomaly`, `LowerBoundaries` and `UpperBoundaries` nullables.
- Renamed `MetricDimension` to `DataFeedDimension`.
- Renamed `DataAnomaly` to `DataPointAnomaly`.
- Renamed `IncidentStatus` to `AnomalyIncidentStatus`.
- Renamed `AlertingHook`, `EmailHook`, and `WebHook` to `NotificationHook`, `EmailNotificationHook`, and `WebNotificationHook`, respectively.
- Renamed `TimeMode` to `AlertQueryTimeMode`.

## 1.0.0-beta.1 (2020-10-08)

This is the first beta of the `Azure.AI.MetricsAdvisor` client library.

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

[readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
