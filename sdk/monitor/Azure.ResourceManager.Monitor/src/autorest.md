# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Monitor
namespace: Azure.ResourceManager.Monitor
require: https://github.com/Azure/azure-rest-api-specs/blob/3f3b51edf8fd0eb65004df390d6ee98e0e23c53d/specification/monitor/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
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

irregular-plural-words:
  status: status

prepend-rp-prefix:
- Action
- Recurrence
- Response
- OdataType
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
  ActionType: MonitorWorkspaceActionType
  Metrics: MetricProperties
  AzureMonitorWorkspaceResource: MonitorWorkspaceResource
  AzureMonitorWorkspaceResourceCollection: MonitorWorkspaceResourceCollection
  AzureMonitorWorkspaceResourceData: MonitorWorkspaceResourceData
  AzureMonitorWorkspaceDefaultIngestionSettings: MonitorWorkspaceDefaultIngestionSettings
  AzureMonitorWorkspaceMetrics: MonitorWorkspaceMetrics
  AzureMonitorWorkspaceResourcePatch: MonitorWorkspaceResourcePatch


directive:
  # remove operation method supported by core lib
  - remove-operation: MonitorOperations_List
  # fixing the format since rename-mapping has bugs on this
  - from: swagger-document
    where: $.definitions.ActionDetail.properties.SendTime
    transform: $['format'] = 'date-time';
  # nullable issue resolution
  - from: swagger-document
    where: $.definitions.ActivityLogAlert.properties.actions
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.MetricAlertProperties.properties.criteria
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.MetricTrigger.properties.dimensions
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.AutoscaleSetting.properties.notifications
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.LogProfileProperties.properties.storageAccountId
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.LogProfileProperties.properties.serviceBusRuleId
    transform: $['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions.AutoscaleSetting.properties.predictiveAutoscalePolicy
    transform: $['x-nullable'] = true;
  # duplicate schema resolution
  - from: activityLogAlerts_API.json
    where: $.definitions.AzureResource
    transform: $['x-ms-client-name'] = 'ActivityLogAlertsResource'
  - from: activityLogAlerts_API.json
    where: $.definitions.ActionGroup
    transform: $['x-ms-client-name'] = 'ActivityLogAlertActionGroup'
  - from: activityLogAlerts_API.json
    where: $.definitions.ErrorResponse
    transform: $['x-ms-client-name'] = 'ActivityLogAlertErrorResponse'
  - from: scheduledQueryRule_API.json
    where: $.definitions.Resource
    transform: $['x-ms-client-name'] = 'ScheduledQueryRuleResource'
  - from: autoscale_API.json
    where: $.definitions.Resource
    transform: $['x-ms-client-name'] = 'AutoScaleResource'
  - from: types.json
    where: $.definitions.Resource
    transform: $['x-ms-client-name'] = 'CommonResource'
  - from: types.json
    where: $.definitions.ProxyResource
    transform: $['x-ms-client-name'] = 'CommonProxyResource'
  # in order to let the ResponseError replace the ErrorResponseCommon in monitor, we need to add a target property to it
  - from: swagger-document
    where: $.definitions.ErrorResponseCommon.properties
    transform: >
      $['target'] = {
        'readOnly': true,
        'type': 'string'
      }
  # remove unnecessary property for resources in action groups
  - from: scheduledQueryRule_API.json
    where: $.definitions.Resource.properties
    transform: >
      $['kind'] = undefined;
  # The value of days are DayOfWeek
  - from: autoscale_API.json
    where: $.definitions
    transform: >
      $.RecurrentSchedule.properties.days.items = {
              'type': 'string',
              'enum': [
                  'Sunday',
                  'Monday',
                  'Tuesday',
                  'Wednesday',
                  'Thursday',
                  'Friday',
                  'Saturday'
                ],
              'x-ms-enum': {
                  'name': 'MonitorDayOfWeek',
                  'modelAsString': true
                }
            };
```
