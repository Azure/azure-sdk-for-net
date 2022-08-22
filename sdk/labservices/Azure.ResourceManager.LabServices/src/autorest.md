# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: LabServices
namespace: Azure.ResourceManager.LabServices
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/labservices/resource-manager/readme.md
tag: package-2022-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  LabServicesSkuCapacity: AvailableLabServicesSkuCapacity
  LabServicesSkuCapabilities: AvailableLabServicesSkuCapabilities
  LabServicesSkuCost: AvailableLabServicesSkuCost
  LabServicesSkuRestrictions: AvailableLabServicesSkuRestrictions
  PagedLabServicesSkus: AvailableLabServicesSkuList
  ScaleType: SkuCapacityScaleType

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
  - from: Skus.json
    where: $.definitions
    transform: >
      $.LabServicesSku.properties.tier['x-ms-enum']['name'] = 'AvailableLabServicesSkuTier';
      $.LabServicesSku['x-ms-client-name'] = 'AvailableLabServicesSku';
```