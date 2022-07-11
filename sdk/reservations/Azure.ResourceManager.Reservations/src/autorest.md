# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Reservations
namespace: Azure.ResourceManager.Reservations
require: https://github.com/Azure/azure-rest-api-specs/blob/42f123a0ca6cd5f8f01f3463ecb47999fdbf3a18/specification/reservations/resource-manager/readme.md
tag: package-2022-03
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
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
  - from: quota.json
    where: $.definitions
    transform: >
      $.QuotaRequestProperties.properties.value['x-ms-client-name'] = 'QuotaRequestValue';
      $.ResourceTypesName['x-ms-enum']['name'] = 'ResourceTypeName';
      $.QuotaProperties.properties.name['x-ms-client-name'] = 'ResourceName';
      $.QuotaProperties.properties.resourceType['x-ms-client-name'] = 'ResourceTypeName';
  - from: reservations.json
    where: $.definitions
    transform: >
      delete $.Location;
      $.ReservationResponse.properties.etag['x-ms-client-name'] = 'version';
      $.ReservationOrderResponse.properties.etag['x-ms-client-name'] = 'version';
      $.PurchaseRequest['x-ms-client-name'] = 'PurchaseRequestContent';
      $.Price['x-ms-client-name'] = 'PurchasePrice';
      $.Catalog.properties.resourceType['x-ms-client-name'] = 'reservedResourceType';
      $.Catalog.properties.name['x-ms-client-name'] = 'SkuName';
      $.Catalog['x-ms-client-name'] = 'ReservationCatalog';
```
