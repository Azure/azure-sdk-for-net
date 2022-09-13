# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AlertsManagement
namespace: Azure.ResourceManager.AlertsManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/0077b4a8c5071d3ab33fd9f9ba013581c9a66b8f/specification/alertsmanagement/resource-manager/readme.md
tag: package-2021-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  AlertModification.modifiedAt: modifiedOn|datetime
  AlertProcessingRuleProperties.enabled: IsEnabled
  AlertsSortByFields.startDateTime: StartOn
  AlertsSortByFields.lastModifiedDateTime: LastModifiedOn
  AlertsSummaryGroup.groupedby: GroupedBy
  AlertsSummaryGroupItem.groupedby: GroupedBy
  Essentials.startDateTime: StartOn|datetime
  Essentials.lastModifiedUserName: lastModifiedBy
  PatchObject.properties.enabled: IsEnabled
  SmartGroup.properties.lastModifiedUserName: lastModifiedBy
  SmartGroupModificationItem.modifiedAt: modifiedOn|datetime
  Recurrence.startTime: startOn
  Recurrence.endTime: endOn
  Schedule.effectiveFrom: -|datetime
  Schedule.effectiveUntil: -|datetime
  TimeRange.1h: OneHour
  TimeRange.1d: OneDay
  TimeRange.7d: SevenDays
  TimeRange.30d: ThirtyDays 
  AlertModificationEvent: ServiceAlertModificationEvent
  AlertModificationItem: ServiceAlertModificationItemInfo
  Severity: ServiceAlertSeverity
  Identifier: RetrievedInformationIdentifier
  TimeRange: TimeRangeFilter
  DaysOfWeek: AlertsManagementDayOfWeek
  MonitorService: MonitorServiceSourceForAlert
  MonthlyRecurrence: AlertProcessingRuleMonthlyRecurrence
  WeeklyRecurrence:  AlertProcessingRuleWeeklyRecurrence
  SortOrder: AlertsManagementQuerySortOrder
  Action: AlertProcessingAction
  ActionType: AlertProcessingActionType
  Alert: ServiceAlert
  AlertsList: ServiceAlertListResult
  AlertState: ServiceAlertState
  ActionStatus: ServiceAlertActionStatus
  Essentials: ServiceAlertEssentials
  SignalType: ServiceAlertSignalType
  Condition: AlertProcessingRuleCondition
  Field: AlertProcessingRuleField
  Operator: AlertProcessingRuleOperator
  SmartGroupModificationItem: SmartGroupModificationItemInfo
  Schedule: AlertProcessingRuleSchedule
  Recurrence: AlertProcessingRuleRecurrence
  AlertsMetaData: ServiceAlertMetadata
  AlertsMetaDataProperties: ServiceAlertMetadataProperties
  AlertModification: ServiceAlertModification
  AlertsSortByFields: ListServiceAlertsSortByField
  AlertsSummary: ServiceAlertSummary
  AlertsSummaryGroupByField: GetServiceAlertSummaryGroupByField
  AlertsSummaryGroupItem: ServiceAlertSummaryGroupItemInfo
  MetadataIdentifier: ServiceAlertMetadataIdentifier
  AlertModificationProperties: ServiceAlertModificationProperties
  AlertProcessingRuleProperties: ServiceAlertProcessingRuleProperties
  AlertProperties: ServiceAlertProperties
  AlertsSummaryGroup: ServiceAlertSummaryGroup

format-by-name-rules:
  'tenantId': 'uuid'
  'alertId': 'uuid'
  'smartGroupId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'actionGroupIds': 'arm-id'

override-operation-name:
  Alerts_MetaData: GetServiceAlertMetadata
  Alerts_GetSummary: GetServiceAlertSummary

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
  SCOM: Scom

directive:
  - from: SmartGroups.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'SmartGroupErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'SmartGroupErrorResponseBody';
      $.smartGroupProperties.properties.smartGroupState['x-ms-enum']['name'] = 'SmartGroupState';
  - from: AlertProcessingRules.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertProcessingRuleErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertProcessingRuleErrorResponseBody';
      $.Recurrence.properties.startTime['format'] = 'time';
      $.Recurrence.properties.endTime['format'] = 'time';
  - from: AlertsManagement.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertsManagementErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertsManagementErrorResponseBody';
  - from: SmartGroups.json
    where: $.parameters
    transform: >
      $.smartGroupId['format'] = 'uuid';
  - from: AlertsManagement.json
    where: $.parameters
    transform: >
      $.alertId['format'] = 'uuid';
```
