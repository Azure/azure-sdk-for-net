# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: ContainerInstance
namespace: Azure.ResourceManager.ContainerInstance
require: https://github.com/Azure/azure-rest-api-specs/blob/ff8bf88e72989f38431cecc8a2c2a7d6cff59d17/specification/containerinstance/resource-manager/readme.md
#tag: package-preview-2024-11
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
  'etag': 'etag'
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
  TCP: Tcp
  UDP: Udp
  Noreuse: NoReuse

override-operation-name:
  Location_ListCachedImages: GetCachedImagesWithLocation
  Location_ListCapabilities: GetCapabilitiesWithLocation
  Location_ListUsage: GetUsagesWithLocation
  Containers_ExecuteCommand: ExecuteContainerCommand
  Containers_ListLogs: GetContainerLogs

# If the model is generally used across the RP or we need to avoid duplication, prepend the RP name.
# If the model is used by a single container instance, simply use Container prefix in the rename-mapping section as it's simpler and consistent with the original pattern in swagger.
prepend-rp-prefix:
  - UsageListResult
  - UsageName
  - OperatingSystemTypes
  - AzureFileVolume
  - GitRepoVolume
  - Container

rename-mapping:
  Logs: ContainerLogs
  Event: ContainerEvent
  AzureFileVolume.readOnly: IsReadOnly
  VolumeMount.readOnly: IsReadOnly
  CapabilitiesCapabilities: ContainerSupportedCapabilities
  ContainerProbe.timeoutSeconds: TimeoutInSeconds
  ContainerProbe.initialDelaySeconds: InitialDelayInSeconds
  ContainerProbe.periodSeconds: PeriodInSeconds
  Scheme: ContainerHttpGetScheme
  Port: ContainerGroupPort
  IpAddress.ip: -|ip-address
  IpAddress: ContainerGroupIPAddress
  GpuResource: ContainerGpuResourceInfo
  ContainerGroupPropertiesInstanceView: ContainerGroupInstanceView
  ContainerPropertiesInstanceView: ContainerInstanceView
  ContainerAttachResponse: ContainerAttachResult
  ContainerExecResponse: ContainerExecResult
  ContainerGroupSubnetId.id: -|arm-id
  InitContainerDefinition: InitContainerDefinitionContent
  LogAnalytics.workspaceResourceId: -|arm-id
  ResourceRequests: ContainerResourceRequestsContent
  DnsConfiguration: ContainerGroupDnsConfiguration
  EncryptionProperties: ContainerGroupEncryptionProperties
  HttpHeader: ContainerHttpHeader
  ImageRegistryCredential: ContainerGroupImageRegistryCredential
  Volume: ContainerVolume
  VolumeMount: ContainerVolumeMount
  Capabilities: ContainerCapabilities
  CapabilitiesListResult: ContainerCapabilitiesListResult
  ResourceLimits: ContainerResourceLimits
  ResourceRequirements: ContainerResourceRequirements
  EnvironmentVariable: ContainerEnvironmentVariable
  GpuSku: ContainerGpuSku
  LogAnalytics: ContainerGroupLogAnalytics
  LogAnalyticsLogType: ContainerGroupLogAnalyticsLogType
  SecurityContextDefinition: ContainerSecurityContextDefinition
  SecurityContextCapabilitiesDefinition: ContainerSecurityContextCapabilitiesDefinition
  SecurityContextDefinition.privileged: IsPrivileged
  ContainerGroupProperties.properties.osType: ContainerGroupOsType
  ContainerGroupProperties.properties.provisioningState: ContainerGroupProvisioningState
  UpdateProfile: NGroupUpdateProfile
  UpdateProfileRollingUpdateProfile: NGroupRollingUpdateProfile
  SecretReference: ContainerGroupSecretReference
  NetworkProfile: ContainerGroupNetworkProfile
  ElasticProfile: ContainerGroupElasticProfile
  PlacementProfile: ContainerGroupPlacementProfile
  FileShare: ContainerGroupFileShare
  FileShareProperties: ContainerGroupFileShareProperties
  IdentityAcls: ContainerGroupIdentityAccessControlLevels
  IdentityAccessLevel: ContainerGroupIdentityAccessLevel
  IdentityAccessControl: ContainerGroupIdentityAccessControl
  NGroupCGPropertyVolume: NGroupContainerGroupPropertyVolume
  NGroupCGPropertyContainer: NGroupContainerGroupPropertyContainer

directive:
  # The list operation is expected to return the same data as the resource. However, starting from version 2024-05-01-preview, a new model was introduced for this list operation that caused a breaking change. This directive is used to mitigate the issue.
  - from: containerInstance.json
    where: $.definitions
    transform: >
      $.ContainerGroupProperties.properties.properties.properties.provisioningState['enum'] = [
              "NotSpecified",
              "Accepted",
              "Pending",
              "Updating",
              "Creating",
              "Repairing",
              "Unhealthy",
              "Failed",
              "Canceled",
              "Succeeded",
              "Deleting",
              "NotAccessible",
              "PreProvisioned"
            ];
      $.ContainerGroupProperties.properties.properties.properties.provisioningState['x-ms-enum'] = {
              "name": "ContainerGroupProvisioningState",
              "modelAsString": true
            };
      $.ContainerGroupListResult.properties.value.items['$ref'] = "#/definitions/ContainerGroup";
  # As Lro the 'Delete' operations should not return 200, however the service returns. This directive is used to mitigate the issue.
  - from: containerInstance.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroupProfiles/{containerGroupProfileName}']
    transform: >
      $.delete.responses['200'] = {
            "description": "OK"
          };
  - from: containerInstance.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/ngroups/{ngroupsName}']
    transform: >
      $.delete.responses['200'] = {
            "description": "OK"
          };
```
