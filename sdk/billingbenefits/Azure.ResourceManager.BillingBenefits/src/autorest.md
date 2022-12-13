# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: BillingBenefits
namespace: Azure.ResourceManager.BillingBenefits
require: https://github.com/Azure/azure-rest-api-specs/blob/bab95d5636c7d47cc5584ea8dadb21199d229ca7/specification/billingbenefits/resource-manager/readme.md
tag: package-2022-11-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-singleton-resource:
  /providers/Microsoft.BillingBenefits/savingsPlanOrderAliases/{savingsPlanOrderAliasName}: savingsPlanOrderAliases
  /providers/Microsoft.BillingBenefits/reservationOrderAliases/{reservationOrderAliasName}: reservationOrderAliases

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

rename-mapping:
  ReservationOrderAliasResponse: ReservationOrderAliasModel
  ReservationOrderAliasRequestPropertiesReservedResourceProperties: ReservationOrderAliasRequestReservedResourceProperties
  ReservationOrderAliasResponsePropertiesReservedResourceProperties: ReservationOrderAliasResponseReservedResourceProperties
directive:
  - from: billingbenefits.json
    where: $.parameters
    transform: >
      $.ExpandParameter['x-ms-parameter-location'] = 'method';
  - remove-operation: Operation_List

```
