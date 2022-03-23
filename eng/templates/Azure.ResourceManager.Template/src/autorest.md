# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ProviderShortName
namespace: Azure.ResourceManager.ProviderShortName
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/ProviderNameLowercase/resource-manager/readme.md
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
tagPrefix SwaggerVersionTag

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