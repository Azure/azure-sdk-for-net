# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Servicelinker
namespace: Azure.ResourceManager.Servicelinker
require: https://github.com/Azure/azure-rest-api-specs/blob/eb2b882ef0a4aa5956ca38cfa566fc4d7cfb3fb0/specification/servicelinker/resource-manager/readme.md
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