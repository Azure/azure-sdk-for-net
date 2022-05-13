# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Servicelinker
namespace: Azure.ResourceManager.Servicelinker
require: https://github.com/Azure/azure-rest-api-specs/blob/a416080c85111fbe4e0a483a1b99f1126ca6e97c/specification/servicelinker/resource-manager/readme.md
tag: package-2022-05-01
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
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
  VNet: Vnet

```
