# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: fluidrelay
namespace: Azure.ResourceManager.fluidrelay
require: https://github.com/Noelin/azure-rest-api-specs/blob/5acbddd09204e6ae0490fe199eab31f1d9700def/specification/fluidrelay/resource-manager/readme.md
tag: package-2022-02-15
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
 

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

```