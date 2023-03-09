# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: Maintenance
namespace: Azure.ResourceManager.Maintenance
# default tag is a preview version
require: D:\DS\azure-rest-api-specs-pr\specification\maintenance\resource-manager\readme.md
tag: package-2023-04
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

rename-mapping:
  ApplyUpdate: MaintenanceApplyUpdate
  Update: MaintenanceUpdate
  ImpactType: MaintenanceImpactType
  ConfigurationAssignment: MaintenanceConfigurationAssignment
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
  UpdateStatus: MaintenanceUpdateStatus
  Visibility: MaintenanceConfigurationVisibility
  ApplyUpdate.properties.lastUpdateTime: LastUpdatedOn

override-operation-name:
  ApplyUpdates_GetParent: GetApplyUpdatesByParent
  ApplyUpdates_CreateOrUpdateParent: CreateOrUpdateApplyUpdateByParent
  ConfigurationAssignments_CreateOrUpdateParent: CreateOrUpdateConfigurationAssignmentByParent
  ConfigurationAssignments_DeleteParent: DeleteConfigurationAssignmentByParent
  ConfigurationAssignments_ListParent:  GetConfigurationAssignmentsByParent
  Updates_ListParent: GetUpdatesByParent
  MaintenanceConfigurations_Delete: DeleteEx

request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{resourceName}: MaintenancePublicConfiguration
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}: MaintenanceApplyUpdate
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}: MaintenanceNestedResourceConfigurationAssignment
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}: MaintenanceResourceConfigurationAssignment
  /subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}: MaintenanceSubscriptionConfigurationAssignment
  /subscriptions/{subscriptionId}/providers/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}: MaintenanceResourceGroupConfigurationAssignment

list-exception:
  - /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
  - /subscriptions/{subscriptionId}/providers/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}

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
