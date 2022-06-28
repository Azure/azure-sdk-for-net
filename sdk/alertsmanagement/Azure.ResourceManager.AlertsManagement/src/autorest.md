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

 

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
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
  SCOM: Scom

directive:
  - from: SmartGroups.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'SmartGroupErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'SmartGroupErrorResponseBody';
      $.smartGroupModification.properties.properties['x-ms-client-flatten'] = true;
      $.smartGroupModificationItem.properties.modifiedAt['format'] = 'date-time';
      $.smartGroupModificationItem['x-ms-client-name'] = 'smartGroupModificationItemData';
      $.smartGroup.properties.properties['x-ms-client-flatten'] = true;
      $.smartGroupProperties.properties.smartGroupState['x-ms-enum']['name'] = 'SmartGroupState';
      $.smartGroupProperties.properties.severity['x-ms-enum']['name'] = 'ServiceAlertSeverity';
      $.smartGroupProperties.properties.startDateTime['x-ms-client-name'] = 'startedOn';
      $.smartGroupProperties.properties.lastModifiedUserName['x-ms-client-name'] = 'lastModifiedBy';
  - from: AlertProcessingRules.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertProcessingRuleErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertProcessingRuleErrorResponseBody';
      $.Condition.properties.field['x-ms-enum']['name'] = 'AlertProcessingRuleField';
      $.Condition.properties.operator['x-ms-enum']['name'] = 'AlertProcessingRuleOperator';
      $.Condition['x-ms-client-name'] = 'AlertProcessingRuleCondition';
      $.Conditions['x-ms-client-name'] = 'AlertProcessingRuleConditions';
      $.Schedule.properties.effectiveFrom['format'] = 'date-time';
      $.Schedule.properties.effectiveUntil['format'] = 'date-time';
      $.Schedule['x-ms-client-name'] = 'AlertProcessingRuleSchedule';
      $.Recurrence.properties.startTime['format'] = 'date-time';
      $.Recurrence.properties.endTime['format'] = 'date-time';
      $.Recurrence['x-ms-client-name'] = 'AlertProcessingRuleRecurrence';
      $.AlertProcessingRule.properties.properties['x-ms-client-flatten'] = true;
      $.Action.properties.actionType['x-ms-enum']['name'] = 'AlertProcessingRuleActionType';
      $.Action['x-ms-client-name'] = 'AlertProcessingRuleAction';
      $.PatchProperties.properties.enabled['x-ms-client-name'] = 'IsEnabled';
  - from: AlertsManagement.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertsManagementErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertsManagementErrorResponseBody';
      $.alert.properties.properties['x-ms-client-flatten'] = true;
      $.alert['x-ms-client-name'] = 'ServiceAlert';
      $.alertsList['x-ms-client-name'] = 'ServiceAlertList';
      $.actionStatus['x-ms-client-name'] = 'ServiceAlertActionStatus';
      $.essentials.properties.severity['x-ms-enum']['name'] = 'ServiceAlertSeverity';
      $.essentials.properties.signalType['x-ms-enum']['name'] = 'ServiceAlertSignalType';
      $.essentials.properties.startDateTime['x-ms-client-name'] = 'startedOn';
      $.essentials.properties.lastModifiedUserName['x-ms-client-name'] = 'lastModifiedBy';
      $.essentials['x-ms-client-name'] = 'ServiceAlertEssentials';
      $.alertModification.properties.properties['x-ms-client-flatten'] = true;
      $.alertModification['x-ms-client-name'] = 'ServiceAlertModification';
      $.alertModificationItem.properties.modifiedAt['format'] = 'date-time';
      $.alertModificationItem.properties.modificationEvent['x-ms-enum']['name'] = 'ServiceAlertModificationEvent';
      $.alertModificationItem['x-ms-client-name'] = 'ServiceAlertModificationItemData';
      $.alertsSummary.properties.properties['x-ms-client-flatten'] = true;
      $.alertsSummary['x-ms-client-name'] = 'ServiceAlertsSummary';
      $.alertsSummaryGroup.properties.groupedby['x-ms-client-name'] = 'GroupedBy';
      $.alertsSummaryGroupItem.properties.groupedby['x-ms-client-name'] = 'GroupedBy';
      $.alertsSummaryGroupItem['x-ms-client-name'] = 'ServiceAlertsSummaryGroupItemData';
      $.alertsMetaData['x-ms-client-name'] = 'ServiceAlertsMetaData';
      $.alertsMetaDataProperties.properties.metadataIdentifier['x-ms-enum']['name'] = 'ServiceAlertMetadataIdentifier';
      $.alertsMetaDataProperties['x-ms-client-name'] = 'ServiceAlertsMetaDataProperties';
#      $.essentials.properties.alertState['x-ms-enum']['name'] = 'ServiceAlertState';
#      $.essentials.properties.monitorCondition['x-ms-enum']['name'] = 'ServiceAlertMonitorCondition';
  - from: SmartGroups.json
    where: $.parameters
    transform: >
      $.severity['x-ms-enum']['name'] = 'ServiceAlertSeverity';
      $.timeRange['x-ms-enum']['name'] = 'TimeRangeFilter';
#      $.newState['x-ms-enum']['name'] = 'ServiceAlertState';
#      $.smartGroupState['x-ms-enum']['name'] = 'ServiceAlertState';
#      $.monitorCondition['x-ms-enum']['name'] = 'ServiceAlertMonitorCondition';
  - from: AlertsManagement.json
    where: $.parameters
    transform: >
      $.severity['x-ms-enum']['name'] = 'ServiceAlertSeverity';
      $.timeRange['x-ms-enum']['name'] = 'TimeRangeFilter';
      $.identifier['x-ms-enum']['name'] = 'InformationIdentifier';
#      $.alertState['x-ms-enum']['name'] = 'ServiceAlertState';
#      $.newState['x-ms-enum']['name'] = 'ServiceAlertState';
#      $.monitorCondition['x-ms-enum']['name'] = 'ServiceAlertMonitorCondition';
```