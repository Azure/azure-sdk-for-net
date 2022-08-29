# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: MarketplaceOrdering
namespace: Azure.ResourceManager.MarketplaceOrdering
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/marketplaceordering/resource-manager/readme.md
tag: package-2021-01-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
  - /subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/offerTypes/{offerType}/publishers/{publisherId}/offers/{offerId}/plans/{planId}/agreements/current

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