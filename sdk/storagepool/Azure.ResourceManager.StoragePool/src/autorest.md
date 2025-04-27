# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StoragePool
namespace: Azure.ResourceManager.StoragePool
require: https://github.com/Azure/azure-rest-api-specs/blob/068f1ecdf3abb35a6a329a7b270c45df4d9c57a4/specification/storagepool/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'SubnetId': 'arm-id'
  'IPAddress': 'ip-address'
  'managedDiskAzureResourceId': 'arm-id'

rename-mapping:
  Acl: DiskPoolIscsiTargetPortalGroupAcl
  EndpointDependency: OutboundEndpointDependency
  EndpointDetail: OutboundEndpointDetail
  EndpointDetail.latency: LatencyInMs
  IscsiLun: ManagedDiskIscsiLun
  IscsiTarget: DiskPoolIscsiTarget
  IscsiTargetList: DiskPoolIscsiTargetList
  IscsiTargetAclMode: DiskPoolIscsiTargetAclMode
  OperationalStatus: StoragePoolOperationalStatus
  OutboundEnvironmentEndpoint: StoragePoolOutboundEnvironment
  OutboundEnvironmentEndpointList: StoragePoolOutboundEnvironmentList
  ProvisioningStates: DiskPoolIscsiTargetProvisioningState
  ResourceSkuCapability: StoragePoolSkuCapability
  ResourceSkuInfo: StoragePoolSkuInfo
  ResourceSkuListResult: StoragePoolSkuListResult
  ResourceSkuLocationInfo: StoragePoolSkuLocationInfo
  ResourceSkuRestrictions: StoragePoolSkuRestrictions
  ResourceSkuRestrictionsType: StoragePoolSkuRestrictionsType
  ResourceSkuRestrictionInfo: StoragePoolSkuRestrictionInfo
  ResourceSkuRestrictionsReasonCode: StoragePoolSkuRestrictionsReasonCode
  ResourceSkuZoneDetails: StoragePoolSkuZoneDetails

# prepend-rp-prefix:

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

directive:
  - from: swagger-document
    where: "$.definitions.DiskPool.properties.sku"
    transform: >
      $["x-ms-client-flatten"] = false;
```
