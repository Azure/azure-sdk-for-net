# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: true
csharp: true
library-name: DevCenter
namespace: Azure.ResourceManager.DevCenter
require: https://github.com/Azure/azure-rest-api-specs/blob/c0ba17235b00917bf1b734b7b537bf532fe7fce0/specification/devcenter/resource-manager/readme.md
# tag: package-2023-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#   show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

prepend-rp-prefix:
  - Capability
  - CatalogListResult
  - Catalog
  - EndpointDetail
  - EnvironmentRole
  - EnvironmentType
  - Gallery
  - GitCatalog
  - HealthCheck
  - HealthCheckStatus
  - HealthStatus
  - HealthStatusDetail
  - HibernateSupport
  - Image
  - ImageListResult
  - ImageReference
  - LicenseType
  - NetworkConnection
  - OperationStatus
  - Pool
  - Project
  - ProvisioningState
  - ResourceRange
  - Schedule
  - ScheduledType
  - ScheduledFrequency
  - ScheduleEnableStatus
  - TrackedResourceUpdate
  - UsageName
  - UsageUnit
  - CatalogSyncState

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  VCPU: vCpu
  VCPUs: vCpus
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

rename-mapping:
  DevCenterSku: DevCenterSkuDetails
  Gallery.properties.galleryResourceId: -|arm-id
  AttachedNetworkConnection.properties.networkConnectionId: -|arm-id
  NetworkConnectionUpdate.properties.subnetId: -|arm-id
  NetworkConnection.properties.subnetId: -|arm-id
  Project.properties.devCenterId: -|arm-id
  ProjectUpdate.properties.devCenterId: -|arm-id
  ProjectEnvironmentType.properties.deploymentTargetId: -|arm-id
  ProjectEnvironmentTypeUpdate.properties.deploymentTargetId: -|arm-id
  ImageReference.id: -|arm-id
  OperationStatus.resourceId: -|arm-id
  DevCenterSku.resourceType: -|resource-type
  CheckNameAvailabilityRequest.type: -|resource-type
  EnvironmentTypeEnableStatus.Enabled: IsEnabled
  EnvironmentTypeEnableStatus.Disabled: IsDisabled
  HibernateSupport.Enabled: IsEnabled
  HibernateSupport.Disabled: IsDisabled
  LocalAdminStatus.Enabled: IsEnabled
  LocalAdminStatus.Disabled: IsDisabled
  ScheduleEnableStatus.Enabled: IsEnabled
  ScheduleEnableStatus.Disabled: IsDisabled
  StopOnDisconnectEnableStatus.Enabled: IsEnabled
  StopOnDisconnectEnableStatus.Disabled: IsDisabled
  AttachedNetworkConnection.properties.networkConnectionLocation: -|azure-location
  UserRoleAssignmentValue: DevCenterUserRoleAssignments
  DomainJoinType.HybridAzureADJoin: HybridAadJoin
  DomainJoinType.AzureADJoin: AadJoin
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityRequest: DevCenterNameAvailabilityContent
  CheckNameAvailabilityResponse: DevCenterNameAvailabilityResult
  CheckNameAvailabilityReason: DevCenterNameUnavailableReason
  ProjectEnvironmentType: DevCenterProjectEnvironment
  ImageVersion.properties.osDiskImageSizeInGb:  OsDiskImageSizeInGB
  ImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  ScheduleUpdateProperties.properties.type: ScheduledType
  OperationStatusResult.properties.id: -|arm-id

override-operation-name:
  OperationStatuses_Get: GetDevCenterOperationStatus
  Usages_ListByLocation: GetDevCenterUsagesByLocation
  CheckNameAvailability_Execute: CheckDevCenterNameAvailability
  Skus_ListBySubscription: GetDevCenterSkusBySubscription
  NetworkConnections_ListOutboundNetworkDependenciesEndpoints: GetOutboundEnvironmentEndpoints

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks: AttachedNetworkConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks/{attachedNetworkConnectionName}: AttachedNetworkConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/attachednetworks: ProjectAttachedNetworkConnectionCollection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/attachednetworks/{attachedNetworkConnectionName}: ProjectAttachedNetworkConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions: DevBoxDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}: DevBoxDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/devboxdefinitions: ProjectDevBoxDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/devboxdefinitions/{devBoxDefinitionName}: ProjectDevBoxDefinition

### Directive renaming "type" property of ScheduleUpdateProperties to "ScheduledType" (to avoid it being generated as TypePropertiesType)
#directive:
    #- from: swagger-document
    #  where: "$.definitions.ScheduleUpdateProperties.properties.type"
    #  transform: >
    #    $["x-ms-client-name"] = "ScheduledType";
    #- from: types.json
    #  where: $.definitions.OperationStatusResult
    #  transform: >
    #    $.properties.id['x-ms-format'] = 'arm-id';
```
