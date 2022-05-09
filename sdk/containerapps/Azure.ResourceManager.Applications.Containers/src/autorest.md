# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: containerapp
namespace: Azure.ResourceManager.containerapp
require: https://github.com/Azure/azure-rest-api-specs/blob/228f16c8871629ffe1fcdebfca9a3e8b4d2ce4aa/specification/app/resource-manager/readme.md
tag: package-2022-03
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
directive:
  - from: CommonDefinitions.json
    where: '$.definitions'
    transform: >
      $.ContainerAppProbe.properties.type['x-ms-client-name'] = 'ProbeType';
```