# Release History

## 1.0.0-beta.4 (Unreleased)


## 1.0.0-beta.3 (2021-02-09)

### New Features
- Added support for AAD authentication in `MetricsAdvisorClient` and `MetricsAdvisorAdministrationClient`.

### Breaking Changes
- The constructor of the `DataFeed` class is now parameterless. Required properties should be set via setters.
- The constructor of the `DataFeedSchema` class is now parameterless. Metrics can be added directly to `MetricColumns`.
- The constructor of the `DataFeedIngestionSettings` class is now parameterless. Required properties should be set via setters.
- The constructor of the `AnomalyDetectionConfiguration` class is now parameterless. Required properties should be set via setters.
- The constructor of the `MetricSingleSeriesDetectionCondition` class is now parameterless. Dimension columns can be added directly to `SeriesKey`.
- The constructor of the `MetricSeriesGroupDetectionCondition` class is now parameterless. Dimension columns can be added directly to `SeriesGroupKey`.
- The constructor of the `AnomalyAlertConfiguration` class is now parameterless. Required properties should be set via setters.
- The constructor of the `EmailNotificationHook` and `WebNotificationHook` are now parameterless. Required properies should be set via setters.
- In `MetricsAdvisorAdministratorClient`, changed return types of sync and async `CreateDataFeed` methods to a `Response<DataFeed>` containing the created data feed.
- In `MetricsAdvisorAdministratorClient`, changed return types of sync and async `CreateDetectionConfiguration` methods to a `Response<AnomalyDetectionConfiguration>` containing the created configuration.
- In `MetricsAdvisorAdministratorClient`, changed return types of sync and async `CreateAlertConfiguration` methods to a `Response<AnomalyAlertConfiguration>` containing the created configuration.
- In `MetricsAdvisorAdministratorClient`, changed return types of sync and async `CreateHook` methods to a `Response<NotificationHook>` containing the created hook.
- In `MetricsAdvisorClient`, changed return types of sync and async `AddMetricFeedback` methods to a `Response<MetricFeedback>` containing the added feedback.
- In `DataFeed`, added property setters to `Name`, `DataSource`, `Granularity`, `IngestionSettings`, and `Schema`.
- In `DataFeedIngestionSettings`, added a property setter to `IngestionStartTime`.
- In `AnomalyDetectionConfiguration`, added property setters to `MetricId`, `Name`, and `WholeSeriesDetectionConditions`.
- In `AnomalyAlertConfiguration`, added a property setter to `Name`.
- In `MetricAnomalyAlertSnoozeCondition`, added property setters to `AutoSnooze`, `IsOnlyForSuccessive`, and `SnoozeScope`.
- In `MetricBoundaryCondition`, added a property setter to `Direction`.
- In `SeverityCondition`, added property setters to `MaximumAlertSeverity` and `MinimumAlertSeverity`.
- In `NotificationHook`, added a property setter to `Name`.
- In `WebNotificationHook`, added a property setter to `Endpoint`.
- In `DataFeed`, removed the setters of the properties `Administrators` and `Viewers`.
- In `DataFeedSchema`, removed the setter of the property `DimensionColumns`.
- In `DataFeedRollupSettings`, removed the setter of the property `AutoRollupGroupByColumnNames`.
- In `AnomalyDetectionConfiguration`, removed the setters of the properties `SeriesDetectionConditions` and `SeriesGroupDetectionConditions`.
- In `WebNotificationHook`, removed the setter of the property `Headers`.
- In `GetAnomaliesForDetectionConfigurationFilter`, removed the setter of the property `SeriesGroupKeys`. Keys can be added directly to the property.
- In `GetMetricSeriesDefinitionsOptions`, removed the setter of the property `DimensionCombinationsToFilter`. Keys combinations can be added directly to the property.
- In `GetValuesOfDimensionWithAnomaliesOptions`, removed the setter of the property `DimensionToFilter`. Dimension columns can be added directly to the property.
- `DataFeed.SourceType` is now nullable. It will be null whenever `DataFeed.DataSource` is null.
- `DataFeed.IngestionStartTime` is now nullable.
- `MetricsAdvisorAdministrationClient.CreateDataFeed` sync and async methods now throw an `ArgumentException` if required properties are not set properly.
- `MetricsAdvisorAdministrationClient.CreateDetectionConfiguration` sync and async methods now throw an `ArgumentException` if required properties are not set properly.
- `MetricsAdvisorAdministrationClient.CreateAlertConfiguration` sync and async methods now throw an `ArgumentException` if required properties are not set properly.
- In `MetricsAdvisorKeyCredential`, renamed the parameter `key` to `subscriptionKey` in the method `UpdateSubscriptionKey`.
- In `MetricsAdvisorKeyCredential`, renamed the parameter `key` to `apiKey` in the method `UpdateApiKey`.
- In `GetMetricSeriesDataOptions`, removed the parameter `seriesToFilter` from the constructor. Keys can be added directly to `SeriesToFilter`.
- In `FeedbackDimensionFilter`, removed the parameter `dimensionFilter` from the constructor. Dimension columns can be added directly to `DimensionFilter`.

### Key Bug Fixes
- Fixed a bug in which setting `WebNotificationHook.CertificatePassword` would actually set the property `Username` instead.
- Fixed a bug in which an `ArgumentNullException` was thrown when getting a `DataFeed` from the service as a Viewer.
- Fixed a bug in which a data feed's administrators and viewers could not be set during creation.

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
