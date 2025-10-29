# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Monitor
namespace: Azure.ResourceManager.Monitor
tag: package-2024-10-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - MetricDefinitions_List
  - Metrics_List
  - Baselines_List
  - MetricNamespaces_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

format-by-name-rules:
  "tenantId": "uuid"
  "ETag": "etag"
  "location": "azure-location"
  "locations": "azure-location"
  "*Uri": "Uri"
  "*Uris": "Uri"

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  Odatatype: OdataType
  AutoScale: Autoscale
  MMM: Mmm
  MM: Mm
  HH: Hh
  DD: Dd
  SS: Ss
  UDP: Udp

irregular-plural-words:
  status: status

prepend-rp-prefix:
- Action
- Recurrence
- Response
- Odatatype
- Metric
- Incident
- Enabled
- Dimension
- Schedule
- Criteria
- Source
- OperationType

override-operation-name:
  ActionGroups_GetTestNotifications: GetNotificationStatus
  ActionGroups_GetTestNotificationsAtResourceGroupLevel: GetNotificationStatus
  ActionGroups_GetTestNotificationsAtActionGroupResourceLevel: GetNotificationStatus
  ActionGroups_PostTestNotifications: CreateNotifications
  ActionGroups_CreateNotificationsAtResourceGroupLevel: CreateNotifications
  ActionGroups_CreateNotificationsAtActionGroupResourceLevel: CreateNotifications
  Baselines_List: GetMonitorMetricBaselines
  Metrics_List: GetMonitorMetrics
  Metrics_ListAtSubscriptionScope: GetMonitorMetrics
  Metrics_ListAtSubscriptionScopePost: GetMonitorMetricsWithPost
  MetricDefinitions_List: GetMonitorMetricDefinitions
  MetricNamespaces_List: GetMonitorMetricNamespaces

rename-mapping:
  AutoscaleSetting: AutoscaleSettingProperties
  AutoscaleSettingResource: AutoscaleSetting
  AutoscaleSettingResource.properties.targetResourceUri: targetResourceId|arm-id
  AutoscaleSettingResource.properties.enabled: IsEnabled
  AutoscaleSettingResource.properties.name: AutoscaleSettingName
  AutoscaleSettingResource.properties.targetResourceLocation: -|azure-location
  AutoscaleSettingResourcePatch.properties.targetResourceUri: targetResourceId|arm-id
  AutoscaleSettingResourcePatch.properties.enabled: IsEnabled
  AutoscaleSettingResourcePatch.properties.name: AutoscaleSettingName
  AutoscaleSettingResourcePatch.properties.targetResourceLocation: -|azure-location
  AzureMonitorPrivateLinkScope: MonitorPrivateLinkScope
  AccessModeSettings: MonitorPrivateLinkAccessModeSettings
  AccessModeSettingsExclusion: MonitorPrivateLinkAccessModeSettingsExclusion
  AccessMode: MonitorPrivateLinkAccessMode
  ScopedResource: MonitorPrivateLinkScopedResource
  ScopedResource.properties.linkedResourceId: -|arm-id
  ActivityLogAlertActionGroup.actionGroupId: -|arm-id
  DataCollectionRuleAssociation: DataCollectionRuleAssociationProperties
  DataCollectionRuleAssociationProxyOnlyResource: DataCollectionRuleAssociation
  DataCollectionRuleAssociationProxyOnlyResource.properties.dataCollectionRuleId: -|arm-id
  DataCollectionRuleAssociationProxyOnlyResource.properties.dataCollectionEndpointId: -|arm-id
  LogProfileResource.properties.storageAccountId: -|arm-id
  LogProfileResource.properties.serviceBusRuleId: -|arm-id
  LogProfileResourcePatch.properties.storageAccountId: -|arm-id
  LogProfileResourcePatch.properties.serviceBusRuleId: -|arm-id
  ActionGroup: ActionGroupProperties
  ActionGroupResource: ActionGroup
  ActionGroupResource.properties.enabled: IsEnabled
  ActionGroupPatchBody.properties.enabled: IsEnabled
  MetricAlertResource: MetricAlert
  MetricAlertResource.properties.targetResourceType: -|resource-type
  MetricAlertResource.properties.targetResourceRegion: -|azure-location
  MetricAlertResourcePatch.properties.targetResourceType: -|resource-type
  MetricAlertResourcePatch.properties.targetResourceRegion: -|azure-location
  DiagnosticSettings: DiagnosticSettingsProperties
  DiagnosticSettingsResource: DiagnosticSettings
  DiagnosticSettingsResource.properties.workspaceId: -|arm-id
  DiagnosticSettingsResource.properties.storageAccountId: -|arm-id
  DiagnosticSettingsResource.properties.serviceBusRuleId: -|arm-id
  DiagnosticSettingsResource.properties.eventHubAuthorizationRuleId: -|arm-id
  DiagnosticSettingsResource.properties.marketplacePartnerId: -|arm-id
  ActivityLogAlert: ActivityLogAlertProperties
  ActivityLogAlertResource: ActivityLogAlert
  ActivityLogAlertResource.properties.enabled: IsEnabled
  ActivityLogAlertResourcePatch.properties.enabled: IsEnabled
  AlertRulePatchObject.properties.enabled: IsEnabled
  AlertRule: AlertRuleProperties
  AlertRuleResource: AlertRule
  AlertRuleResource.properties.name: AlertRuleName
  DataCollectionEndpoint: DataCollectionEndpointProperties
  DataCollectionEndpointResource: DataCollectionEndpoint
  DataCollectionRule: DataCollectionRuleProperties
  DataCollectionRuleResource.properties.dataCollectionEndpointId: -|arm-id
  DataCollectionRuleResource: DataCollectionRule
  DiagnosticSettingsCategory: DiagnosticSettingsCategoryProperties
  DiagnosticSettingsCategoryResource: DiagnosticSettingsCategory
  LogProfileResource: LogProfile
  LogSearchRule: LogSearchRuleProperties
  LogSearchRuleResource: LogSearchRule
  LogAnalyticsDestination.workspaceResourceId: -|arm-id
  RuleDataSource.resourceUri: resourceId|arm-id
  MetricAlertResource.properties.autoMitigate: IsAutoMitigateEnabled
  MetricAlertResource.properties.enabled: IsEnabled
  MetricAlertResourcePatch.properties.autoMitigate: IsAutoMitigateEnabled
  MetricAlertResourcePatch.properties.enabled: IsEnabled
  MetricSettings.enabled: IsEnabled
  EventData: EventDataInfo
  EventData.resourceId: -|arm-id
  PredictiveResponse: AutoscaleSettingPredicativeResult
  PredictiveResponse.targetResourceId: -|arm-id
  LogSettings.enabled: IsEnabled
  RetentionPolicy.enabled: IsEnabled
  TimeWindow.start: StartOn
  TimeWindow.end: EndOn
  AlertRuleAnyOfOrLeafCondition: ActivityLogAlertAnyOfOrLeafCondition
  RuleAction: AlertRuleAction
  RuleCondition: AlertRuleCondition
  KnownPublicNetworkAccessOptions: MonitorPublicNetworkAccess
  KnownDataCollectionEndpointProvisioningState: DataCollectionEndpointProvisioningState
  KnownDataCollectionRuleAssociationProvisioningState: DataCollectionRuleAssociationProvisioningState
  KnownDataCollectionRuleProvisioningState: DataCollectionRuleProvisioningState
  KnownDataFlowStreams: DataFlowStreams
  KnownExtensionDataSourceStreams: ExtensionDataSourceStreams
  KnownPerfCounterDataSourceStreams: PerfCounterDataSourceStreams
  KnownSyslogDataSourceFacilityNames: SyslogDataSourceFacilityNames
  KnownSyslogDataSourceLogLevels: SyslogDataSourceLogLevels
  KnownSyslogDataSourceStreams: SyslogDataSourceStreams
  KnownWindowsEventLogDataSourceStreams: WindowsEventLogDataSourceStreams
  KnownDataCollectionEndpointResourceKind: DataCollectionEndpointResourceKind
  KnownDataCollectionRuleResourceKind: DataCollectionRuleResourceKind
  ProvisioningState: MonitorProvisioningState
  LocalizableString: MonitorLocalizableString
  MetricTrigger.metricResourceUri: metricResourceId|arm-id
  MetricTrigger.metricResourceLocation: -|azure-location
  MetricTrigger.dividePerInstance: IsDividedPerInstance
  NotificationRequestBody: NotificationContent
  Context: NotificationContext
  TestNotificationDetailsResponse: NotificationStatus
  ActionDetail: NotificationActionDetail
  TimeWindow: MonitorTimeWindow
  ArmRoleReceiver: MonitorArmRoleReceiver
  AutomationRunbookReceiver: MonitorAutomationRunbookReceiver
  AutomationRunbookReceiver.automationAccountId: -|arm-id
  AutomationRunbookReceiver.webhookResourceId: -|arm-id
  AzureAppPushReceiver: MonitorAzureAppPushReceiver
  AzureFunctionReceiver: MonitorAzureFunctionReceiver
  AzureFunctionReceiver.functionAppResourceId: -|arm-id
  Source.dataSourceId: -|arm-id
  EmailReceiver: MonitorEmailReceiver
  EventHubReceiver: MonitorEventHubReceiver
  ItsmReceiver: MonitorItsmReceiver
  ItsmReceiver.region: -|azure-location
  LogicAppReceiver: MonitorLogicAppReceiver
  LogicAppReceiver.resourceId: -|arm-id
  SmsReceiver: MonitorSmsReceiver
  VoiceReceiver: MonitorVoiceReceiver
  WebhookReceiver: MonitorWebhookReceiver
  WorkspaceInfo: DataContainerWorkspace
  WorkspaceInfo.id: -|arm-id
  CategoryType: MonitorCategoryType
  EventLevel: MonitorEventLevel
  ScaleAction: MonitorScaleAction
  ScaleDirection: MonitorScaleDirection
  ScaleType: MonitorScaleType
  ScaleCapacity.minimum: -|integer
  ScaleCapacity.maximum: -|integer
  ScaleCapacity.default: -|integer
  ScaleCapacity: MonitorScaleCapacity
  ReceiverStatus: MonitorReceiverStatus
  EnableRequest: ActionGroupEnableContent
  OperationStatus: MonitorPrivateLinkScopeOperationStatus
  QueryType: MonitorSourceQueryType
  RuleDataSource.legacyResourceId: -|arm-id
  LogSearchRuleResource.properties.autoMitigate: IsAutoMitigateEnabled
  ScaleRule: AutoscaleRule
  ScaleRuleMetricDimension: AutoscaleRuleMetricDimension
  TestNotificationDetailsResponse.completedTime: -|date-time
  TestNotificationDetailsResponse.createdTime: -|date-time
  HttpRequestInfo: EventDataHttpRequestInfo
  HttpRequestInfo.clientIpAddress: -|ip-address
  MetricAlertAction.actionGroupId: -|arm-id
  WebtestLocationAvailabilityCriteria.webTestId: -|arm-id
  WebtestLocationAvailabilityCriteria.componentId: -|arm-id
  ColumnDefinition: DataColumnDefinition
  StreamDeclaration: DataStreamDeclaration
  KnownColumnDefinitionType: DataColumnDefinitionType
  KnownLogFilesDataSourceFormat: LogFilesDataSourceFormat
  KnownLogFileTextSettingsRecordStartTimestampFormat: LogFileTextSettingsRecordStartTimestampFormat
  VMInsightsOnboardingStatus.properties.resourceId: -|arm-id
  LogSearchRuleResourcePatch.properties.enabled: IsEnabled
  ScheduledQueryRuleResource: ScheduledQueryRule
  Actions: ScheduledQueryRuleActions
  DimensionOperator: MonitorDimensionOperator
  Condition: ScheduledQueryRuleCondition
  ScheduledQueryRuleResource.properties.enabled: IsEnabled
  ScheduledQueryRuleResourcePatch.properties.enabled: IsEnabled
  Kind: ScheduledQueryRuleKind
  AggregationTypeEnum: MetricCriteriaTimeAggregationType
  TimeAggregationOperator: ThresholdRuleConditionTimeAggregationType
  TimeAggregationType: MetricTriggerTimeAggregationType
  TimeAggregation: ScheduledQueryRuleTimeAggregationType
  Operator: MetricCriteriaOperator
  ComparisonOperationType: MetricTriggerComparisonOperation
  ConditionOperator: MonitorConditionOperator
  RuleResolveConfiguration: ScheduledQueryRuleResolveConfiguration
  RuleResolveConfiguration.autoResolved: IsAutoResolved
  PublicNetworkAccess: MonitorWorkspacePublicNetworkAccess
  MetadataValue: MonitorMetadataValue
  MetricValue: MonitorMetricValue
  MetricResultType: MonitorMetricResultType
  MetricUnit: MonitorMetricUnit
  SubscriptionScopeMetricsRequestBodyParameters: SubscriptionResourceGetMonitorMetricsWithPostContent
  SubscriptionScopeMetric: SubscriptionMonitorMetric
  TimeSeriesElement: MonitorTimeSeriesElement
  StorageBlobDestination.storageAccountResourceId: -|arm-id
  StorageTableDestination.storageAccountResourceId: -|arm-id
  PrivateLinkScopedResource.resourceId: -|arm-id
  PrivateLinkScopedResource: DataCollectionRulePrivateLinkScopedResourceInfo
  EventHubDataSource: DataCollectionRuleEventHubDataSource
  EventHubDestination: DataCollectionRuleEventHubDestination
  EventHubDestination.eventHubResourceId: -|arm-id
  EventHubDirectDestination: DataCollectionRuleEventHubDirectDestination
  EventHubDirectDestination.eventHubResourceId: -|arm-id
  FailoverConfigurationSpec: DataCollectionRuleBcdrFailoverConfigurationSpec
  FailoverConfigurationSpec.ActiveLocation: -|azure-location
  KnownLocationSpecProvisioningStatus: DataCollectionRuleBcdrLocationSpecProvisioningStatus
  KnownPrometheusForwarderDataSourceStreams: DataCollectionRuleKnownPrometheusForwarderDataSourceStream
  LocationSpec: DataCollectionRuleBcdrLocationSpec
  Metadata: DataCollectionRuleRelatedResourceMetadata
  Metadata.ProvisionedByResourceId: -|arm-id
  MonitoringAccountDestination.accountResourceId: -|arm-id
  StorageBlobDestination: DataCollectionRuleStorageBlobDestination
  StorageTableDestination: DataCollectionRuleStorageTableDestination
  ActionType: MonitorWorkspaceActionType
  Metrics: MonitorWorkspaceMetricProperties
  AzureMonitorWorkspace: MonitorWorkspaceResource
  AzureMonitorWorkspaceCollection: MonitorWorkspaceResourceCollection
  AzureMonitorWorkspaceData: MonitorWorkspaceResourceData
  IngestionSettings: MonitorWorkspaceIngestionSettings
  IngestionSettings.dataCollectionEndpointResourceId: -|arm-id
  IngestionSettings.dataCollectionRuleResourceId: -|arm-id
  AzureMonitorWorkspaceDefaultIngestionSettings: MonitorWorkspaceDefaultIngestionSettings
  AzureMonitorWorkspaceMetrics: MonitorWorkspaceMetrics
  AzureMonitorWorkspacePatch: MonitorWorkspaceResourcePatch
  AzureMonitorWorkspaceListResult: MonitorWorkspaceResourceListResult
  MetricDefinition: MonitorMetricDefinition
  AggregationType: MonitorAggregationType
  BaselineMetadata: MonitorBaselineMetadata
  BaselineSensitivity: MonitorBaselineSensitivity
  MetricAvailability: MonitorMetricAvailability
  MetricClass: MonitorMetricClass
  MetricNamespace: MonitorMetricNamespace
  MetricSingleDimension: MonitorMetricSingleDimension
  NamespaceClassification: MonitorNamespaceClassification
  ResultType: MonitorResultType
  SingleBaseline: MonitorSingleBaseline
  SingleMetricBaseline: MonitorSingleMetricBaseline
  TimeSeriesBaseline: MonitorTimeSeriesBaseline
  Unit: MonitorMetricUnit
  CacheConfiguration: MonitorWorkspaceLogsExporterCacheConfiguration
  ConcurrencyConfiguration: MonitorWorkspaceLogsExporterConcurrencyConfiguration
  SchemaMap: MonitorWorkspaceLogsSchemaMap
  RecordMap: MonitorWorkspaceLogsRecordMap
  ResourceMap: MonitorWorkspaceLogsResourceMap
  ScopeMap: MonitorWorkspaceLogsScopeMap
  Receiver: PipelineGroupReceiver
  ReceiverType: PipelineGroupReceiverType
  Processor: PipelineGroupProcessor
  ProcessorType: PipelineGroupProcessorType
  Exporter: PipelineGroupExporter
  ExporterType: PipelineGroupExporterType
  Service: PipelineGroupService
  Pipeline: PipelineGroupServicePipeline
  PipelineType: PipelineGroupServicePipelineType
  PersistenceConfigurations: PipelineGroupServicePersistenceConfigurations
  PersistenceConfigurationsUpdate: PipelineGroupServicePersistenceConfigurationsUpdate
  NetworkingConfiguration: PipelineGroupNetworkingConfiguration
  NetworkingRoute: PipelineGroupNetworkingRoute
  ExternalNetworkingMode: PipelineGroupExternalNetworkingMode
  JsonArrayMapper: PipelineGroupJsonArrayMapper
  JsonMapperDestinationField: PipelineGroupJsonMapperDestinationField
  JsonMapperElement: PipelineGroupJsonMapperElement
  JsonMapperSourceField: PipelineGroupJsonMapperSourceField
  ServiceUpdate: PipelineGroupServiceUpdate
  AzureResourceManagerCommonTypesExtendedLocation: Azure.ResourceManager.CommonTypes.ExtendedLocation
  AzureMonitorWorkspaceLogsApiConfig: MonitorWorkspaceLogsApiConfig
  AzureMonitorWorkspaceLogsExporter: MonitorWorkspaceLogsExporter

suppress-abstract-base-class:
- MetricAlertCriteria
- MultiMetricCriteria

directive:
  # remove operations because they are covered in resourcemanager we no longer need to generate them here, and they are causing duplicate schemas
  - remove-operation: Operations_List
  - remove-operation: MonitorOperations_List
  # fixing the format since rename-mapping has bugs on this
  - from: swagger-document
    where: $.definitions.ActionDetail.properties.SendTime
    transform: $["format"] = "date-time";
  # nullable issue resolution
  - from: swagger-document
    where: $.definitions.ActivityLogAlert.properties.actions
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.MetricAlertProperties.properties.criteria
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.MetricTrigger.properties.dimensions
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AutoscaleSetting.properties.notifications
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.LogProfileProperties.properties.storageAccountId
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.LogProfileProperties.properties.serviceBusRuleId
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AutoscaleSetting.properties.predictiveAutoscalePolicy
    transform: $["x-nullable"] = true;
  # duplicate schema resolution
  - from: v1/commonMonitoringTypes.json
    where: $.definitions.LocalizableString
    transform: >
      $.properties.value.description = "the invariant value.";
      $.properties.localizedValue.description = "the locale specific value.";
  - from: v2/commonMonitoringTypes.json
    where: $.definitions.LocalizableString
    transform: >
      $.properties.value.description = "the invariant value.";
      $.properties.localizedValue.description = "the locale specific value.";
  - from: actionGroups_API.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "ActionGroupsErrorResponse"
  - from: activityLogAlerts_API.json
    where: $.definitions.AzureResource
    transform: $["x-ms-client-name"] = "ActivityLogAlertsResource"
  - from: activityLogAlerts_API.json
    where: $.definitions.ActionGroup
    transform: $["x-ms-client-name"] = "ActivityLogAlertActionGroup"
  - from: activityLogAlerts_API.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "ActivityLogAlertErrorResponse"
  - from: scheduledQueryRule_API.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "ScheduledQueryRuleResource"
  - from: autoscale_API.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "AutoScaleResource"
  - from: commonMonitoringTypes.json
    where: $.definitions.ErrorContract
    transform: $["x-ms-client-name"] = "CommonErrorContract"
  - from: v2/types.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "CommonResource"
  - from: v3/types.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "CommonResourceV3"
  - from: v2/types.json
    where: $.definitions.ProxyResource
    transform: $["x-ms-client-name"] = "CommonProxyResource"
  - from: v1/types.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "CommonErrorResponse"
  - from: v2/types.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "CommonErrorResponseV2"
  - from: v3/types.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "CommonErrorResponseV3"
  - from: v4/types.json
    where: $.definitions.ErrorResponse
    transform: $["x-ms-client-name"] = "CommonErrorResponseV4"
  - from: v1/types.json
    where: $.definitions.ErrorDetail
    transform: $["x-ms-client-name"] = "CommonErrorDetail"
  - from: v2/types.json
    where: $.definitions.ErrorDetail
    transform: $["x-ms-client-name"] = "CommonErrorDetailV2"
  - from: v3/types.json
    where: $.definitions.ErrorDetail
    transform: $["x-ms-client-name"] = "CommonErrorDetailV3"
  - from: v2/types.json
    where: $.definitions.TrackedResource
    transform: $["x-ms-client-name"] = "CommonTrackedResource"
  - from: v3/types.json
    where: $.definitions.TrackedResource
    transform: $["x-ms-client-name"] = "CommonTrackedResourceV3"
  - from: v4/privatelinks.json
    where: $.definitions.PrivateEndpoint
    transform: $["x-ms-client-name"] = "MonitorWorkspacePrivateEndpoint"
  - from: v4/privatelinks.json
    where: $.definitions.PrivateEndpointConnection
    transform: $["x-ms-client-name"] = "MonitorWorkspacePrivateEndpointConnection"
  - from: v4/privatelinks.json
    where: $.definitions.PrivateEndpointConnectionProperties
    transform: $["x-ms-client-name"] = "MonitorWorkspacePrivateEndpointConnectionProperties"
  - from: v4/types.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "CommonResourceV4"
  # reinforce ProvisioningState's readonly status
  - from: swagger-document
    where: $.definitions.PrivateEndpointConnectionProperties.properties.provisioningState
    transform: $["readOnly"] = true
  # in order to let the ResponseError replace the ErrorResponseCommon in monitor, we need to add a target property to it
  - from: swagger-document
    where: $.definitions.ErrorResponseCommon.properties
    transform: >
      $["target"] = {
        "readOnly": true,
        "type": "string"
      }
  # remove unnecessary property for resources in action groups
  - from: scheduledQueryRule_API.json
    where: $.definitions.Resource.properties
    transform: >
      $["kind"] = undefined;
  # The value of days are DayOfWeek
  - from: autoscale_API.json
    where: $.definitions
    transform: >
      $.RecurrentSchedule.properties.days.items = {
              "type": "string",
              "enum": [
                  "Sunday",
                  "Monday",
                  "Tuesday",
                  "Wednesday",
                  "Thursday",
                  "Friday",
                  "Saturday"
                ],
              "x-ms-enum": {
                  "name": "MonitorDayOfWeek",
                  "modelAsString": true
                }
            };
  - from: azuremonitor.json
    where: $.definitions.AzureMonitorWorkspace.properties
    transform: >
      $.defaultIngestionSettings = {
          "description": "The Data Collection Rule and Endpoint used for ingestion by default.",
          "allOf": [
            {
              "$ref": "#/definitions/IngestionSettings"
            }
          ],
          "readOnly": true,
          "x-ms-mutability": [
            "read"
          ]
        };
      $.metrics = {
          "description": "Properties related to the metrics container in the Azure Monitor Workspace",
          "allOf": [
            {
              "$ref": "#/definitions/Metrics"
            }
          ],
          "readOnly": true,
          "x-ms-mutability": [
            "read"
          ]
        };
  # 2024-10-01-preview and later versions of pipeline group APIs are defined in pipelineGroups.json
  # Removing older ones from azuremonitor.json to avoid conflicts
  - from: azuremonitor.json
    remove-operation-match: /.*pipelineGroups.*/i
```

## Tag: package-2024-10-01-preview

Creating this tag to exclude some preview operations that do not exist in our previous stable version of monitor releases.

These settings apply only when `--tag=package-2024-10-01-preview` is specified on the command line.

```yaml $(tag) == 'package-2024-10-01-preview'
title: MonitorManagementClient
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-10-01/autoscale_API.json
# - https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json # we do not need to support this
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/alertRulesIncidents_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/2491b616cde43277fae339604f03f59412e016aa/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/alertRules_API.json # we should not change this commit because APIs in this file has been deprecated and removed in https://github.com/Azure/azure-rest-api-specs/pull/30787
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/logProfiles_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-05-01-preview/diagnosticsSettings_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-05-01-preview/diagnosticsSettingsCategories_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2024-10-01-preview/actionGroups_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/activityLogs_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/eventCategories_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/tenantActivityLogs_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2021-05-01/metrics_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2019-03-01/metricBaselines_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-03-01/metricAlert_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/19b9fa28a4ac7e156245fad3ee9700e253ee4d2b/specification/monitor/resource-manager/Microsoft.Insights/preview/2024-03-01-preview/metricAlert_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-15/scheduledQueryRule_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2018-11-27-preview/vmInsightsOnboarding_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-07-01-preview/privateLinkScopes_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2020-10-01/activityLogAlerts_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionEndpoints_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRuleAssociations_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRules_API.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Monitor/preview/2023-10-01-preview/azuremonitor.json
- https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Monitor/PipelineGroups/preview/2024-10-01-preview/pipelineGroups.json
# - https://github.com/Azure/azure-rest-api-specs/blob/a9b9241e0d2909e29aa22efb33f55491cbd160de/specification/monitor/resource-manager/Microsoft.Monitor/stable/2023-04-03/operations_API.json # we do not need to support this
```
