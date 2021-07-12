# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2021-07-08)

### New Features
- `DimensionKey` now implements the `IEnumerable<KeyValuePair<string, string>>` interface. Dimension columns can now be enumerated.
- Added method `Contains` to `DimensionKey` to check whether or not a dimension column is present.
- Added a property setter to `MetricSeriesGroupDetectionCondition.SeriesGroupKey` and to `MetricSingleSeriesDetectionCondition.SeriesKey`.
- Added property `DimensionsToSplitAlert` to `AnomalyAlertConfiguration` to allow splitting an alert into multiple ones.
- Added property `MeasureType` to `MetricBoundaryCondition` to control which measure should be used when checking boundaries for alert triggering. Current supported types are `Value` and `Mean`.
- `NotificationHook.Administrators` is now a `IList` (not read-only anymore), and can be used to update the list of administrators or set it during creation.
- Added property `HookKind` to `NotificationHook`.
- Added property `CredentialKind` to `DataSourceCredentialEntity`.
- Added value `None` to `FeedbackQueryTimeMode` to indicate that no time mode is set.
- Some properties can now be set to their default value if set to null during an Update operation. For example, `DataFeedIngestionSettings.IngestionStartOffset`, or `MetricWholeSeriesDetectionCondition.SmartDetectionCondition`.
- Added new constructor to `AzureDataLakeStorageDataFeedSource` to be used with authentication types that are not `Basic`.
- Added new constructor to `SqlServerDataFeedSource` to be used with the `SqlConnectionString` authentication type.

### Breaking Changes
- Removed methods `AddDimensionColumn` and `RemoveDimensionColumn` from `DimensionKey`. In order to access elements, the new method `TryGetValue` must be used. Once the instance has been created, the columns can't be modified anymore.
- `DimensionKey` is not an `IEquatable` anymore. Equality will be calculated based on reference only.
- `DimensionKey` constructor now takes the required `dimensions` parameter.
- The whole `DatasourceCredential` API has been renamed to `DataSourceCredential`. This includes renames in methods, method parameters, and properties.
  - Renamed type `DatasourceCredential` to `DataSourceCredentialEntity`.
  - Renamed type `DataLakeGen2SharedKeyDatasourceCredential` to `DataLakeSharedKeyCredentialEntity`.
  - Renamed type `ServicePrincipalDatasourceCredential` to `ServicePrincipalCredentialEntity`.
  - Renamed type `ServicePrincipalInKeyVaultDatasourceCredential` to `ServicePrincipalInKeyVaultCredentialEntity`.
  - Renamed type `SqlConnectionStringDatasourceCredential` to `SqlConnectionStringCredentialEntity`.
- Renamed type `DetectionConditionsOperator` to `DetectionConditionOperator`. Also, `MetricWholeSeriesDetectionCondition.CrossConditionsOperator` has been renamed to `ConditionOperator`.
- Renamed type `MetricAnomalyAlertConfiguration` to `MetricAlertConfiguration`.
- Renamed type `MetricAnomalyAlertConfigurationsOperator` to `MetricAlertConfigurationsOperator`.
- Renamed type `DataSourceType` to `DataSourceKind`. Similarly, `GetDataFeedsFilter.SourceType` has been renamed to `SourceKind`, and `DataFeedSource.DataSourceType` has been renamed to `DataSourceKind`.
- Renamed type `AzureDataLakeStorageGen2DataFeedSource` to `AzureDataLakeStorageDataFeedSource`. Similarly, `DataSourceType.AzureDataLakeStorageGen2` has been renamed to `AzureDataLakeStorage`.
- Renamed type `FeedbackType` to `MetricFeedbackKind`. Similarly, `GetAllFeedbackOptions.FeedbackType` has been renamed to `FeedbackKind`, and `MetricFeedback.Type` to `FeedbackKind` as well.
- Renamed type `PeriodType` to `MetricPeriodType`.
- Renamed type `FeedbackDimensionFilter` to `FeedbackFilter` and moved it to the namespace `Azure.AI.MetricsAdvisor`.
- Renamed type `GetAnomaliesForDetectionConfigurationFilter` to `AnomalyFilter`.
- Renamed type `GetDataFeedsFilter` to `DataFeedFilter`, and the property `GetDataFeedsOptions.GetDataFeedsFilter` to `Filter`.
- Split the method `GetAnomalies` into two different methods: `GetAnomaliesForAlert` and `GetAnomaliesForDetectionConfiguration`.
- Split the method `GetIncidents` into two different methods: `GetIncidentsForAlert` and `GetIncidentsForDetectionConfiguration`.
- Removed the property `DimensionFilter` in `MetricFeedback`. It's now a property of type `DimensionKey` (named `DimensionKey` as well). Similarly, feedback constructors now require a `dimensionKey` parameter to be passed.
- `DataFeedIngestionSettings` constructor now takes the required `ingestionStartsOn` parameter. For this reason, the property `IngestionStartTime`, now named `IngestionStartsOn`, is not nullable anymore.
- `DataFeedMissingDataPointFillSettings` constructor now takes the required `fillType` parameter. For this reason, the property `FillType` is not nullable anymore.
- `EmailNotificationHook` constructor now takes the required `name` parameter.
- `WebNotificationHook` constructor now takes the required `name` and `endpoint` parameters.
- `MetricSeriesGroupDetectionCondition` constructor now takes the required `seriesGroupKey` parameter.
- `MetricSingleSeriesDetectionCondition` constructor now takes the required `seriesKey` parameter.
- Renamed all occurrences of `CreatedTime` to `CreatedOn` and `ModifiedTime` to `LastModified`.
- Renamed `AnomalyIncident.StartTime` to `StartedOn` and `AnomalyIncident.LastTime` to `LastDetectedOn`.
- Renamed any other occurrences of `StartTime` to `StartsOn`, and `EndTime` to `EndsOn`, including property and parameter names.
- Renamed `AlertQueryTimeMode.AnomalyTime` to `AnomalyDetectedOn`, and `FeedbackQueryTimeMode.FeedbackCreatedTime` to `FeedbackCreatedOn`.
- Renamed `DataFeedRollupSettings.AlreadyRollupIdentificationValue` to `RollupIdentificationValue`.
- In `DataFeedRollupType`, renamed `AlreadyRollup` to `AlreadyRolledUp`, `NeedRollup` to `RollupNeeded`, and `NoRollup` to `NoRollupNeeded`.
- In `DataFeed`, renamed `AdministratorsEmails` to `Administrators`, `ViewersEmails` to `Viewers`, and `CreatorEmail` to `Creator`.
- In `NotificationHook`, renamed `AdministratorsEmails` to `Administrators`, and `ExternalLink` to `ExternalUri`.
- In `MetricAnomalyFeedback`, renamed `AnomalyDetectionConfigurationId` to `DetectionConfigurationId`, and `AnomalyDetectionConfigurationSnapshot` to `DetectionConfigurationSnapshot`.
- In `ChangeThresholdCondition`, renamed `IsWithinRange` to `WithinRange`. Similarly, the constructor parameter `isWithinRange` has been renamed to `withinRange`.
- In `MetricSeriesData`, removed the `Definition` property. Now, properties `MetricId` and `SeriesKey` can be accessed directly from `MetricSeriesData`.
- In `DataPointAnomaly`, renamed property `AnomalyDetectionConfigurationId` to `DetectionConfigurationId`.
- In `DataFeedMetric`, renamed constructor parameter `metricName` to `name` only.
- In `DataFeedDimension`, renamed constructor parameter `dimensionName` to `name` only.
- In `MetricAnomalyAlertScope`, renamed static methods `GetScopeFor<...>` to `CreateScopeFor<...>`. For instance, `GetScopeForSeriesGroup` was renamed to `CreateScopeForSeriesGroup`.
- Changed signature of the `MetricAnomalyAlertScope.GetScopeForTopNGroup` method to take the parameters `top`, `period`, and `minimumTopCount` directly. For this reason, removed the public constructor of `TopNGroupScope`.
- Moved `GetAlertConfigurationsOptions`, `GetDatasourceCredentialsOptions`, and `GetDetectionConfigurationsOptions` to the `Azure.AI.MetricsAdvisor.Administration` namespace.
- Moved `DatasourceCredential`, `DataFeedSource`, `NotificationHook`, and all of their concrete child types to the `Azure.AI.MetricsAdvisor.Administration` namespace.
- Moved `MetricFeedback` and all of its concrete child types to the `Azure.AI.MetricsAdvisor` namespace.
- In `GetAllFeedbackOptions`, moved all feedback filter properties to a new nested property `Filter` of type `FeedbackFilter`.
- Changed order of parameters of `MetricsAdvisorClient.GetMetricEnrichedSeriesData`. Now, `detectionConfigurationId` appears first.
- Optional properties `FeedbackFilter.DimensionKey` and `GetAnomalyDimensionValuesOptions.DimensionToFilter` must now be manually added with setters to be used.
- Moved property `DataFeed.SourceType` to `DataFeedSource.DataSourceType`.
- In `GetAnomaliesForDetectionConfigurationFilter` (now named `AnomalyFilter`), renamed `SeriesGroupKeys` to `DimensionKeys`.
- In `GetAnomalyDimensionValuesOptions`, renamed `DimensionToFilter` to `SeriesGroupKey`.
- In `GetIncidentsForAlertOptions`, renamed `DimensionsToFilter` to `DimensionKeys`.
- In `GetMetricDimensionValuesOptions`, renamed `DimensionValueToFilter` to `DimensionValueFilter`.
- In `GetMetricSeriesDataOptions`, renamed `SeriesToFilter` to `SeriesKeys`.
- In `GetMetricSeriesDefinitionsOptions`, renamed `DimensionCombinationsToFilter` to `DimensionCombinationsFilter`.
- In `AnomalyIncident`, renamed `RootDimensionKey` to `RootSeriesKey`.
- In `FeedbackDimensionFilter` (now named `FeedbackFilter`), renamed `DimensionFilter` to `DimensionKey`.
- In `MetricsAdvisorKeyCredential`, merged `UpdateSubscriptionKey` and `UpdateApiKey` into a single method, `Update`, to make it an atomic operation.
- Removed setters from `StartTime` and `EndTime`, both in `MetricAnomalyFeedback` and in `MetricChangePointFeedback`.
- The class `NotificationHook` is now abstract.
- The class `DatasourceCredential` (now called `DataSourceCredentialEntity`) is now abstract.
- `AlertQueryTimeMode` and `FeedbackQueryTimeMode` are now regular enums.
- The enum `AuthenticationType` present in some `DataFeedSource` subtypes is now an extensible enum.
- Removed constructor `(string workspaceId, string query)` from the `LogAnalyticsDataFeedSource`.

## 1.0.0-beta.4 (2021-06-07)

### New Features
- Added `DatasourceCredential` CRUD operations to the `MetricsAdvisorAdministrationClient`. This API provides new ways of authenticating to a `DataFeedSource`.
- Added property `Authentication` to data sources `AzureBlobDataFeedSource`, `AzureDataExplorerDataFeedSource`, `AzureDataLakeStorageGen2DataFeedSource`, and `SqlServerDataFeedSource` to specify the authentication type to use.
- Added property `DatasourceCredentialId` to data sources `AzureDataExplorerDataFeedSource`, `AzureDataLakeStorageGen2DataFeedSource`, and `SqlServerDataFeedSource` to specify the datasource credential to use for authentication.
- Added properties `Value` and `ExpectedValue` to `DataPointAnomaly` to provide more information about the anomalous data point.
- Added properties `ValueOfRootNode` and `ExpectedValueOfRootNode` to `AnomalyIncident` to provide more information about the anomalous data point at the root node of the indicent.
- Response headers that were marked as `REDACTED` in error messages and logs are now exposed by default.
- `GetDetectionConfigurations` and `GetAlertConfigurations` in the `MetricsAdvisorAdministrationClient` can now take a set of options with `Skip` and `MaxPageSize` properties to configure paging behavior.
- Added setters to models that use the Update APIs to make updating easier.
- Added property `DataFeedId` to `DataPointAnomaly` and `AnomalyIncident`.
- Added two new data feed sources: `AzureEventHubsDataFeedSource` and `LogAnalyticsDataFeedSource`.

### Breaking Changes
- Update methods will now return the updated entity instead of an empty response. For example, `UpdateDataFeed` now returns a `Response<DataFeed>`.
- `NotificationHook.ExternalLink` and `WebNotificationHook.Endpoint` are now of type `Uri`.
- Removed setter from `GetIncidentsForDetectionConfigurationOptions.DimensionsToFilter`. Elements can be added directly to it without user instantiation.
- Renamed all `SkipCount` listing options to `Skip`. Affected classes include `GetAlertsOptions`, `GetDataFeedsOptions`, `GetHooksOptions`, and others.
- Renamed all `TopCount` listing options to `MaxPageSize`. Affected classes include `GetAlertsOptions`, `GetDataFeedsOptions`, `GetHooksOptions`, and others.
- Removed data feed sources `ElasticsearchDataFeedSource` and `HttpRequestDataFeedSource` as they are not supported by the service anymore. A different type of data feed source must be used for data ingestion instead.
- Removed getters for secrets in data feed sources, such as `AzureBlobDataFeedSource.ConnectionString` and `InfluxDbDataFeedSource.Password`.
- Removed granularity type `DataFeedGranularityType.PerSecond` as it's not supported by the service anymore.
- Renamed method `GetDimensionValues` to `GetMetricDimensionValues` in `MetricsAdvisorClient`. The associated options type `GetDimensionValuesOptions` has been renamed as well.
- Renamed method `GetValuesOfDimensionWithAnomalies` to `GetAnomalyDimensionValues` in `MetricsAdvisorClient`. The associated options type `GetValuesOfDimensionWithAnomaliesOptions` has been renamed as well.
- In `MetricsAdvisorAdministrationClient`, Update operations such as `UpdateDataFeed` don't take the ID as a method parameter anymore. You now need to pass an instance that has been returned from another CRUD operation and has its `Id` property populated.
- In `AnomalyIncident`, renamed `DimensionKey` to `RootDimensionKey`.
- In `DataFeed`, renamed `Administrators` to `AdministratorsEmails`, `Creator` to `CreatorEmail`, and `Viewers` to `ViewersEmails`.
- In `DataFeedDimension`, renamed `DimensionName` to `Name`, and `DimensionDisplayName` to `DisplayName`.
- In `DataFeedMetric`, renamed `MetricId` to `Id`, `MetricName` to `Name`, `MetricDisplayName` to `DisplayName`, and `MetricDescription` to `Description`.
- In `DataFeedAutoRollupMethod`, renamed `RollupMethod` to `AutoRollupMethod`.
- In `IncidentRootCause`, renamed `DimensionKey` to `SeriesKey`, and `Score` to `ContributionScore`.
- In `MetricBoundaryCondition`, renamed `TriggerForMissing` to `ShouldAlertIfDataPointMissing`.
- In `MetricEnrichedSeriesData`, renamed `Values` to `MetricValues`, `ExpectedValues` to `ExpectedMetricValues`, `LowerBoundaries` to `LowerBoundaryValues`, and `UpperBoundaries` to `UpperBoundaryValues`.
- In `MetricSeriesData`, renamed `Values` to `MetricValues`.
- In `NotificationHook`, renamed `Administrators` to `AdministratorsEmails`.

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

[readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
