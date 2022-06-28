# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ExtendedLocation
namespace: Azure.ResourceManager.ExtendedLocation
require: https://github.com/Azure/azure-rest-api-specs/blob/ac155b972d0619a6e5bf665a863fb05ee7eeb30f/specification/extendedlocation/resource-manager/readme.md
tag: package-2021-08-31-preview
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
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

directive:
  - rename-model:
      from: Identity
      to: LocationIdentity
```
