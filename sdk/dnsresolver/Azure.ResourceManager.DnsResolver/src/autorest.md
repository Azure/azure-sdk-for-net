# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/a416080c85111fbe4e0a483a1b99f1126ca6e97c/specification/dnsresolver/resource-manager/readme.md
library-name: dnsresolver
namespace: Azure.ResourceManager.DnsResolver
clear-output-folder: true
skip-csproj: true
output-folder: Generated/

rename-rules:
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
