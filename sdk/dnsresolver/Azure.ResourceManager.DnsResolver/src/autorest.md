# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ccdf0b74eedb671fe038ed1a30a9be9f911ebc4f/specification/dnsresolver/resource-manager/readme.md
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
