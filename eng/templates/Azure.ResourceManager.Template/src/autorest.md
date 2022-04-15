# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ProviderShortName
namespace: Azure.ResourceManager.ProviderShortName
require: https://github.com/Azure/azure-rest-api-specs/blob/256b8ec7d045dbe2daf91030b0d6b7f09c8e42d9/specification/ProviderNameMappingPrefixProviderNameMappingSuffix/resource-manager/readme.md
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