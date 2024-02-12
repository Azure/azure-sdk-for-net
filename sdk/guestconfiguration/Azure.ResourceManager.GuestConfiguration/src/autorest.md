# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: GuestConfiguration
namespace: Azure.ResourceManager.GuestConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/58a1320584b1d26bf7dab969a2593cd22b39caec/specification/guestconfiguration/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - GuestConfigurationAssignments_SubscriptionList # skip this because this operation is replaced by customization code
  - GuestConfigurationAssignments_RGList # skip this because this operation is replaced by customization code
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}: GuestConfigurationVmAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}: GuestConfigurationHcrpAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}: GuestConfigurationVmssAssignment

parameterized-scopes:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}

override-operation-name:
  GuestConfigurationAssignments_SubscriptionList: GetGuestConfigurationAssignments
  GuestConfigurationAssignments_RGList: GetGuestConfigurationAssignments
  GuestConfigurationAssignmentReports_List: GetReports
  GuestConfigurationHCRPAssignmentReports_List: GetReports
  GuestConfigurationAssignmentReportsVMSS_List: GetReports
  GuestConfigurationAssignmentReports_Get: GetReport
  GuestConfigurationHCRPAssignmentReports_Get: GetReport
  GuestConfigurationAssignmentReportsVMSS_Get: GetReport

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
  HCRP: Hcrp
  DSC: Dsc

rename-mapping:
  AssignmentInfo: GuestConfigurationAssignmentInfo
  AssignmentReport.id: -|arm-id
  AssignmentReport.reportId: -|uuid
  ComplianceStatus: AssignedGuestConfigurationMachineComplianceStatus
  Type: GuestConfigurationAssignmentReportType
  AssignmentReportResource: AssignmentReportResourceInfo
  AssignmentReportResource.resourceId: AssignmentResourceSettingName
  VMInfo: GuestConfigurationVmInfo
  VMInfo.id: -|arm-id
  VMInfo.uuid: -|uuid
  VmssvmInfo: GuestConfigurationVmssVmInfo
  VmssvmInfo.lastComplianceChecked: LastComplianceCheckedOn
  VmssvmInfo.latestReportId: -|uuid
  VmssvmInfo.vmId: -|uuid
  VmssvmInfo.vmResourceId: -|arm-id
  AssignmentReportDetails: GuestConfigurationAssignmentReportDetails
  AssignmentReportDetails.jobId: -|uuid
  ConfigurationSetting: LcmConfigurationSetting
  ConfigurationSetting.allowModuleOverwrite: IsModuleOverwriteAllowed
  ConfigurationSetting.configurationModeFrequencyMins: ConfigurationModeFrequencyInMins
  ConfigurationSetting.refreshFrequencyMins: RefreshFrequencyInMins
  ConfigurationMode: LcmConfigurationMode
  GuestConfigurationAssignmentProperties.lastComplianceStatusChecked: LastComplianceStatusCheckedOn
  GuestConfigurationAssignmentProperties.latestReportId: -|arm-id
  ProvisioningState: GuestConfigurationProvisioningState
  GuestConfigurationAssignmentReport.id: -|arm-id
  GuestConfigurationAssignmentReportProperties.reportId: -|uuid
  AssignmentType: GuestConfigurationAssignmentType
  AssignmentReport: GuestConfigurationAssignmentReportInfo
  ConfigurationInfo: GuestConfigurationInfo
  ConfigurationParameter: GuestConfigurationParameter
  GuestConfigurationNavigation.configurationParameter: ConfigurationParameters
  GuestConfigurationNavigation.configurationProtectedParameter: ConfigurationProtectedParameters

directive:
  - from: guestconfiguration.json
    where: $.definitions
    transform: >
      $.GuestConfigurationNavigation.properties.configurationSetting['x-nullable'] = true;
      $.GuestConfigurationNavigation.properties.assignmentType['x-nullable'] = true;
      $.GuestConfigurationNavigation.properties.kind['x-nullable'] = true;
      $.GuestConfigurationAssignmentProperties.properties.vmssVMList['x-nullable'] = true;
  - from: guestconfiguration.json
    where: $.definitions
    transform: >
      $.Resource = {
          "description": "The core properties of guest configuration resources",
          "properties": {
            "id": {
              "type": "string",
              "readOnly": true,
              "x-ms-format": "arm-id",
              "description": "ARM resource id of the guest configuration assignment."
            },
            "name": {
              "type": "string",
              "readOnly": false,
              "description": "Name of the guest configuration assignment."
            },
            "location": {
              "type": "string",
              "readOnly": false,
              "x-ms-fromat": "azure-location",
              "description": "Region where the VM is located."
            },
            "type": {
              "readOnly": true,
              "type": "string",
              "x-ms-format": "resource-type",
              "description": "The type of the resource."
            },
            "systemData": {
              "readOnly": true,
              "type": "object",
              "description": "Azure Resource Manager metadata containing createdBy and modifiedBy information.",
              "$ref": "../../../../../common-types/resource-management/v2/types.json#/definitions/systemData"
            }
          },
          "x-ms-azure-resource": true,
          "x-ms-client-name": "GuestConfigurationResourceData"
        }
      $.GuestConfigurationAssignment.allOf[0]['$ref'] = '#/definitions/Resource';
      delete $.GuestConfigurationAssignment.systemData;
    reason: Use directive to re-define the GuestConfigurationResourceData model and ensure GuestConfigurationAssignment inherits from it.
```
