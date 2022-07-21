# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StoragePool
namespace: Azure.ResourceManager.StoragePool
require: https://github.com/Azure/azure-rest-api-specs/blob/068f1ecdf3abb35a6a329a7b270c45df4d9c57a4/specification/storagepool/resource-manager/readme.md
tag: package-2021-08-01
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
  'SubnetId': 'arm-id'

rename-mapping:
  IscsiLun: ManagedDiskIscsiLun
  ResourceSkuZoneDetails: StoragePoolSkuZoneDetails
  ResourceSkuRestrictions: StoragePoolSkuRestrictions
  ResourceSkuRestrictionsType: StoragePoolSkuRestrictionsType
  ResourceSkuRestrictionsReasonCode: StoragePoolSkuRestrictionsReasonCode

prepend-rp-prefix:
  - IscsiTarget

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

directive:
  - from: swagger-document
    where: "$.definitions.DiskPool.properties.sku"
    transform: >
      $["x-ms-client-flatten"] = false;
```
