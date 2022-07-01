# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Monitor
namespace: Azure.ResourceManager.Monitor
require: https://github.com/Azure/azure-rest-api-specs/blob/35f8a4df47aedc1ce185c854595cba6b83fa6c71/specification/monitor/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ResourceId': 'arm-id'
  'TargetResourceId': 'arm-id'
  'TargetResourceLocation': 'azure-location'
  'StorageAccountId': 'arm-id'
  'ServiceBusRuleId': 'arm-id'
  'EventHubAuthorizationRuleId': 'arm-id'
  'WorkspaceResourceId': 'arm-id'
  'MetricResourceId': 'arm-id'
  'MetricResourceLocation': 'azure-location'

rename-rules:
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Etag: ETag
  Odatatype: OdataType

prepend-rp-prefix:
- Action
- Recurrence
- Operator
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
  ActionGroups_GetTestNotifications: GetActionGroupTestNotifications

rename-mapping:
  MetricTrigger.metricResourceUri: metricResourceId
  AutoscaleSetting: AutoscaleSettingProperties
  AutoscaleSettingResource: AutoscaleSetting
  AutoscaleSettingResource.properties.targetResourceUri: targetResourceId
  AutoscaleSettingResource.properties.enabled: IsEnabled
  AutoscaleSettingResource.properties.name: AutoscaleSettingName
  AutoscaleSettingResourcePatch.properties.targetResourceUri: targetResourceId
  AutoscaleSettingResourcePatch.properties.enabled: IsEnabled
  AutoscaleSettingResourcePatch.properties.name: AutoscaleSettingName
  AzureMonitorPrivateLinkScope: PrivateLinkScope
  ScopedResource: PrivateLinkScopedResource
  DataCollectionRuleAssociation: DataCollectionRuleAssociationProperties
  DataCollectionRuleAssociationProxyOnlyResource: DataCollectionRuleAssociation
  ActionGroup: ActionGroupProperties
  ActionGroupResource: ActionGroup
  ActionGroupResource.properties.enabled: IsEnabled
  MetricAlertResource: MetricAlert
  DiagnosticSettings: DiagnosticSettingsProperties
  DiagnosticSettingsResource: DiagnosticSettings
  ActivityLogAlert: ActivityLogAlertProperties
  ActivityLogAlertResource: ActivityLogAlert
  ActivityLogAlertResource.properties.enabled: IsEnabled
  ActivityLogAlertResourcePatch.properties.enabled: IsEnabled
  AlertRule: AlertRuleProperties
  AlertRuleResource: AlertRule
  AlertRuleResource.properties.name: AlertRuleName
  DataCollectionEndpoint: DataCollectionEndpointProperties
  DataCollectionEndpointResource: DataCollectionEndpoint
  DataCollectionRule: DataCollectionRuleProperties
  DataCollectionRuleResource: DataCollectionRule
  DiagnosticSettingsCategory: DiagnosticSettingsCategoryProperties
  DiagnosticSettingsCategoryResource: DiagnosticSettingsCategory
  LogProfileResource: LogProfile
  LogSearchRule: LogSearchRuleProperties
  LogSearchRuleResource: LogSearchRule
  RuleDataSource.resourceUri: resourceId
  RuleMetricDataSource.resourceUri: resourceId
  RuleManagementEventDataSource.resourceUri: resourceId
  LogSearchRule.autoMitigate: IsAutoMitigate
  MetricAlertResource.properties.autoMitigate: IsAutoMitigate
  MetricAlertResource.properties.enabled: IsEnabled
  MetricAlertResourcePatch.properties.autoMitigate: IsAutoMitigate
  MetricAlertResourcePatch.properties.enabled: IsEnabled
  MetricSettings.enabled: IsEnabled
  EventData: EventDataInfo
  LogSettings.enabled: IsEnabled
  RetentionPolicy.enabled: IsEnabled
  TimeWindow.start: StartOn
  TimeWindow.end: EndOn
  
directive:
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
    where: $.definitions.Resource.properties.type
    transform: $["x-nullable"] = true
  # duplicate schema resolution
  - from: activityLogAlerts_API.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "ActivityLogAlertsResource"
  - from: scheduledQueryRule_API.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "ScheduledQueryRuleResource"
  # some format changes
  - from: swagger-document
    where: $.definitions.DiagnosticSettings.properties.workspaceId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.ScopedResourceProperties.properties.linkedResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.ActivityLogAlertActionGroup.properties.actionGroupId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.AutomationRunbookReceiver.properties.automationAccountId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.AutomationRunbookReceiver.properties.webhookResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.AzureFunctionReceiver.properties.functionAppResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.MetricAlertAction.properties.actionGroupId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.Source.properties.dataSourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.WebtestLocationAvailabilityCriteria.properties.webTestId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.WebtestLocationAvailabilityCriteria.properties.componentId
    transform: $["x-ms-format"] = "arm-id"
  - from: swagger-document
    where: $.definitions.WorkspaceInfo.properties.id
    transform: $["x-ms-format"] = "arm-id"
  # in order to let the ResponseError replace the ErrorResponseCommon in monitor, we need to add a target property to it
  - from: swagger-document
    where: $.definitions.ErrorResponseCommon.properties
    transform: >
      $["target"] = {
        "readOnly": true,
        "type": "string"
      }
```
