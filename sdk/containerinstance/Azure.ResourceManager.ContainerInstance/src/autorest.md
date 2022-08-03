# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: ContainerInstance
namespace: Azure.ResourceManager.ContainerInstance
require: https://github.com/Azure/azure-rest-api-specs/blob/4716fb039c67e1bee1d5448af9ce57e4942832fe/specification/containerinstance/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
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

prepend-rp-prefix:
  - Volume
  - VolumeMount
  - Capabilities
  - CapabilitiesListResult
  - Scheme

rename-mapping:
  Container: ContainerInstance
  Logs: ContainerInstanceLogs
  Event: ContainerEvent
  AzureFileVolume.readOnly: IsReadOnly
  VolumeMount.readOnly: IsReadOnly
  CapabilitiesCapabilities: ContainerInstanceSupportedCapabilities
  ContainerProbe.timeoutSeconds: TimeoutInSeconds
  ContainerProbe.initialDelaySeconds: InitialDelayInSeconds
  ContainerProbe.periodSeconds: PeriodInSeconds
  Scheme: ContainerHttpGetScheme
  Port: ContainerGroupPort
  IpAddress.ip: -|ip-address
  IpAddress: ContainerGroupIPAddress
  GpuResource: GpuResourceInfo
  ContainerGroupPropertiesInstanceView: ContainerGroupInstanceView
  ContainerPropertiesInstanceView: ContainerInstanceView
  ContainerAttachResponse: ContainerAttachResult
  ContainerExecResponse: ContainerExecResult
  ContainerGroupSubnetId.id: -|arm-id
  InitContainerDefinition: InitContainerDefinitionContent
  LogAnalytics.workspaceResourceId: -|arm-id
```
