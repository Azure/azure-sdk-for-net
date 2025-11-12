# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Maintenance
namespace: Azure.ResourceManager.Maintenance
require: https://github.com/Azure/azure-rest-api-specs/blob/b40ebb26621eef12eb91a11a08793f507cdd367f/specification/maintenance/resource-manager/Microsoft.Maintenance/Maintenance/readme.md
tag: package-2023-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  ConfigurationAssignment: MaintenanceConfigurationAssignmentData
  ConfigurationAssignmentFilterProperties: MaintenanceConfigurationAssignmentFilter
  ConfigurationAssignmentFilterProperties.resourceTypes: -|resource-type
  ConfigurationAssignmentFilterProperties.locations: -|azure-location
  TagOperators: VmTagOperator
  TagSettingsProperties: VmTagSettings
  ApplyUpdate.properties.resourceId: -|arm-id
  ConfigurationAssignment.properties.resourceId: -|arm-id
  Update.properties.resourceId: -|arm-id
  ConfigurationAssignment.properties.maintenanceConfigurationId: -|arm-id
  MaintenanceConfiguration.properties.maintenanceWindow.expirationDateTime: ExpireOn|date-time
  MaintenanceConfiguration.properties.maintenanceWindow.startDateTime: StartOn|date-time
  ListApplyUpdate: MaintenanceApplyUpdateListResult
  ListUpdatesResult: MaintenanceUpdateListResult
  ListMaintenanceConfigurationsResult: MaintenanceConfigurationListResult
  ListConfigurationAssignmentsResult: MaintenanceConfigurationAssignmentListResult
  Visibility: MaintenanceConfigurationVisibility
  ApplyUpdate.properties.lastUpdateTime: LastUpdatedOn
  InputPatchConfiguration: MaintenancePatchConfiguration
  InputWindowsParameters: MaintenanceWindowsPatchSettings
  InputWindowsParameters.excludeKbsRequiringReboot: IsExcludeKbsRebootRequired
  InputLinuxParameters: MaintenanceLinuxPatchSettings
  ScheduledEventApproveResponse: ScheduledEventApproveResult

prepend-rp-prefix:
  - ApplyUpdate
  - ImpactType
  - RebootOptions
  - Update
  - UpdateStatus

override-operation-name:
  ApplyUpdates_GetParent: GetApplyUpdatesByParent
  ApplyUpdates_CreateOrUpdateParent: CreateOrUpdateApplyUpdateByParent
  ConfigurationAssignments_CreateOrUpdateParent: CreateOrUpdateConfigurationAssignmentByParent
  ConfigurationAssignmentsForResourceGroup_CreateOrUpdate: CreateOrUpdateConfigurationAssignmentByResourceGroup
  ConfigurationAssignmentsForSubscriptions_CreateOrUpdate: CreateOrUpdateConfigurationAssignmentBySubscription
  ConfigurationAssignments_DeleteParent: DeleteConfigurationAssignmentByParent
  ConfigurationAssignmentsForResourceGroup_Delete: DeleteConfigurationAssignmentByResourceGroup
  ConfigurationAssignmentsForSubscriptions_Delete: DeleteConfigurationAssignmentBySubscription
  ConfigurationAssignments_GetParent: GetConfigurationAssignmentByParent
  ConfigurationAssignmentsForResourceGroup_Get: GetConfigurationAssignmentByResourceGroup
  ConfigurationAssignmentsForSubscriptions_Get: GetConfigurationAssignmentBySubscription
  ConfigurationAssignments_ListParent:  GetConfigurationAssignmentsByParent
  ConfigurationAssignmentsWithinSubscription_List: GetConfigurationAssignmentsBySubscription
  ConfigurationAssignmentsForResourceGroup_Update: UpdateConfigurationAssignmentByResourceGroup
  ConfigurationAssignmentsForSubscriptions_Update: UpdateConfigurationAssignmentBySubscription
  Updates_ListParent: GetUpdatesByParent
  MaintenanceConfigurations_Delete: DeleteEx

request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{resourceName}: MaintenancePublicConfiguration
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}: MaintenanceApplyUpdate

list-exception:
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}

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
  Sqldb: SqlDB
  SQL: Sql

directive:
  - from: Maintenance.json
    where: $.definitions
    transform: >
      $.MaintenanceWindow.properties.duration['x-ms-format'] = 'duration-constant';

  # Sevice doesn't return the the `MaintenanceConfiguration` for the delete operation, use `directive` to fix the swagger and custom code to keep backward compatibility as this lib has already GAed.
  - from: Maintenance.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}']
    transform: >
      delete $.delete.responses['200']['schema'];
```
