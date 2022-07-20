# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ContainerService
namespace: Azure.ResourceManager.ContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/b9b91929c304f8fb44002267b6c98d9fb9dde014/specification/containerservice/resource-manager/readme.md
tag: package-2022-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/locations/{location}/osOptions/default: osOptions/default

rename-mapping:
  ManagedClusterPodIdentityProvisioningError.error: 'ErrorDetail'
  Code: ManagedClusterStateCode
  Format: KubeConfigFormat
  Expander: AutoScaleExpander
  KubeletConfig.containerLogMaxSizeMB: ContainerLogMaxSizeInMB
  LinuxOSConfig.swapFileSizeMB: SwapFileSizeInMB

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ResourceType': 'resource-type'
  '*ResourceId': 'arm-id'
  'nodePublicIPPrefixID': 'arm-id'

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
  SSD: Ssd
  GPU: Gpu
  SKU: Sku
  AAD: Aad
  TrustedCa: TrustedCA
  CBLMariner: CblMariner
  API: Api
  OCI: Oci

directive:
  - from: managedClusters.json
    where: $.definitions.AgentPoolAvailableVersionsProperties.properties.agentPoolVersions.items
    transform: >
      $['x-ms-client-name'] = 'AgentPoolAvailableVersion';
      $.properties.default['x-ms-client-name'] = 'IsDefault';
  - from: managedClusters.json
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.osDiskSizeGB
    transform: >
      $['x-ms-client-name'] = 'OSDiskSizeInGB';
  - from: managedClusters.json
    where: $.definitions.ContainerServiceMasterProfile.properties.osDiskSizeGB
    transform: >
      $['x-ms-client-name'] = 'OSDiskSizeInGB';
  - from: managedClusters.json
    where: $.definitions
    transform: >
      $.OSSKU['x-ms-enum'].name = 'OSSku';
```
