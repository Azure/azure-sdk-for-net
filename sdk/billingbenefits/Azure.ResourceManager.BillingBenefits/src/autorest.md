# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: BillingBenefits
namespace: Azure.ResourceManager.BillingBenefits
require: D:\GitHub\azure-rest-api-specs\specification\billingbenefits\resource-manager\readme.md
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

```
