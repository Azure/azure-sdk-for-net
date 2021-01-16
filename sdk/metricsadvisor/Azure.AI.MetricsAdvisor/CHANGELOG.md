# Release History

## 1.0.0-beta.3 (Unreleased)

### Key Bug Fixes
- Fixed a bug in which setting `WebNotificationHook.CertificatePassword` would actually set the property `Username` instead.
- Fixed a bug in which an `ArgumentNullException` was thrown when getting a `DataFeed` from the service as a Viewer.

## 1.0.0-beta.2 (2020-11-10)

### New Features
- Added new sync and async `GetIncidentRootCauses` overloads to `MetricsAdvisorClient` to list root causes for a given `AnomalyIncident` instance.
- Added a public constructor to `DataFeed`.
- Added the `DataSource` property to `DataFeed`.
- All `DataSource`s now have public properties exposing the associated parameters used to get the data, such as endpoints, connection strings, and query strings.

### Breaking Changes
- Moved all `Options` types (e.g., `GetAlertsOptions`) from `Azure.AI.MetricsAdvisor.Models` to the `Azure.AI.MetricsAdvisor` namespace.
- Moved `TimeMode`, `FeedbackQueryTimeMode`, `GetAnomaliesForDetectionConfigurationFilter`, and `GetDataFeedsFilter` from `Azure.AI.MetricsAdvisor.Models` to the `Azure.AI.MetricsAdvisor` namespace.
- In `MetricsAdvisorClient`, renamed `GetAnomaliesForDetectionConfiguration` and `GetAnomaliesForAlert` sync and async methods to `GetAnomalies`.
- In `MetricsAdvisorClient`, renamed `GetIncidentsForDetectionConfiguration` and `GetIncidentsForAlert` sync and async methods to `GetIncidents`.
- In `MetricsAdvisorClient`, renamed sync and async `CreateMetricFeedback` methods to `AddFeedback`.
- In `MetricsAdvisorClient`, renamed sync and async `GetMetricFeedback` methods to `GetFeedback`.
- In `MetricsAdvisorClient`, renamed sync and async `GetMetricFeedbacks` methods to `GetAllFeedback`.
- In `MetricsAdvisorClient`, renamed sync and async `GetMetricDimensionValues` methods to `GetDimensionValues`.
- In `MetricsAdvisorClient`, changed return types of sync and async `CreateMetricFeedback` methods to a `Response<string>` containing the ID of the created feedback.
- In `MetricsAdvisorClient`, changed return types of sync and async methods `GetIncidentRootCauses`, `GetMetricEnrichedSeriesData`, and `GetMetricSeriesData` to pageables.
- In `MetricsAdvisorClient`, updated sync and async `GetIncidentsForDetectionConfiguration` methods to always populate the `DetectionConfigurationId` of returned incidents.
- In `MetricsAdvisorAdministrationClient`, renamed the sync and async `AnomalyAlertConfiguration` CRUD methods, removing the `Anomaly` word from their names (e.g., `GetAnomalyAlertConfiguration` became `GetAlertConfiguration`).
- In `MetricsAdvisorAdministrationClient`, renamed the sync and async `MetricAnomalyDetectionConfiguration` CRUD methods, removing the `MetricAnomaly` term from their names (e.g., `GetMetricAnomalyDetectionConfiguration` became `GetDetectionConfiguration`).
- In `MetricsAdvisorAdministrationClient`, updated `CreateDataFeed` and `CreateDataFeedAsync` to take a whole `DataFeed` object as a parameter.
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async `Create` methods (e.g., `CreateDataFeed`) to a `Response<string>` containing the ID of the created resource.
- In `MetricsAdvisorAdministrationClient`, changed return types of sync and async methods `GetAnomalyAlertConfigurations` and `GetMetricAnomalyDetectionConfigurations` to pageables.
- In `MetricsAdvisorAdministrationClient`, renamed parameter `alertConfigurationId` to `detectionConfigurationId` in sync and async `GetAnomalyAlertConfigurations` methods.
- Updated `DataFeed.MetricIds` to a `Dictionary<string, string>` that maps a metric name to its ID.
- In `DataFeedIngestionStatus`, made `Timestamp` and `Status` non-nullables.
- In `MetricEnrichedSeriesData`, made elements of `ExpectedValues`, `Periods`, `IsAnomaly`, `LowerBoundaries` and `UpperBoundaries` nullables.
- Made `AnomalyIncident.Status` non-nullable.
- Made `EnrichmentStatus.Timestamp` non-nullable.
- Removed `MetricsAdvisorClientOptions` and `MetricsAdvisorAdministrationOptions` and replaced both with `MetricsAdvisorClientsOptions`.
- Removed `DataFeedOptions`. All of its properties were moved directly into `DataFeed`.
- Renamed `GetMetricFeedbacksOptions` to `GetAllFeedbackOptions`.
- Renamed `GetMetricDimensionValuesOptions` to `GetDimensionValuesOptions`.
- Renamed `MetricDimension` to `DataFeedDimension`.
- Renamed `DataAnomaly` to `DataPointAnomaly`.
- Renamed `IncidentStatus` to `AnomalyIncidentStatus`.
- Renamed `AlertingHook`, `EmailHook`, and `WebHook` to `NotificationHook`, `EmailNotificationHook`, and `WebNotificationHook`, respectively.
- Renamed `TimeMode` to `AlertQueryTimeMode`.
- In `DataFeedGranularityType`, renamed `Minutely` and `Secondly` to `PerMinute` and `PerSecond`, respectively.
- In `ElasticsearchDataFeedSource`, renamed the constructor parameter `authHeader` to `authorizationHeader`.

### Key Bug Fixes
- Fixed a bug in sync and async `GetMetricEnrichedSeriesData` methods where a `NullReferenceException` was thrown if a returned data point had missing data.
- Fixed a bug in sync and async `UpdateDataFeed` methods where a `RequestFailedException` was thrown if a data feed without custom `DataFeedMissingDataPointFillType` was updated.
- Fixed a bug in sync and async `UpdateAlertConfiguration` methods where a `RequestFailedException` was thrown if a configuration with only one `MetricAnomalyAlertConfiguration` was updated.

## 1.0.0-beta.1 (2020-10-08)

This is the first beta of the `Azure.AI.MetricsAdvisor` client library.

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

[readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
