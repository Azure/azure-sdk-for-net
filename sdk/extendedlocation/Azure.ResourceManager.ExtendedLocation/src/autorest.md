# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ExtendedLocation
namespace: Azure.ResourceManager.ExtendedLocation
require: https://github.com/Azure/azure-rest-api-specs/blob/691920cda83cc0b89a8c821d0bb285100fad22b4/specification/extendedlocation/resource-manager/readme.md
tag: package-2021-08-15
output-folder: Generated/
clear-output-folder: true
modelerfour:
  flatten-payloads: false
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
