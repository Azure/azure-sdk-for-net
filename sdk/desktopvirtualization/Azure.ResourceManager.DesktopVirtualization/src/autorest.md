# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DesktopVirtualization
namespace: Azure.ResourceManager.DesktopVirtualization
require: https://github.com/Azure/azure-rest-api-specs/blob/a416080c85111fbe4e0a483a1b99f1126ca6e97c/specification/desktopvirtualization/resource-manager/readme.md
tag: package-2021-07
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
      from: Application
      to: VirtualApplication
  - rename-model:
      from: ApplicationGroup
      to: VirtualApplicationGroup
  - rename-model:
      from: Desktop
      to: VirtualDesktop
  - rename-model:
      from: DesktopGroup
      to: VirtualDesktopGroup
  - rename-model:
      from: Workspace
      to: VirtualWorkspace
  - from: swagger-document
    where: "$.definitions.MigrationRequestProperties.properties.operation"
    transform: >
      $["x-ms-enum"]["name"] = "MigrationOperation"
  - from: swagger-document
    where: "$.definitions.SessionHostProperties.properties.status"
    transform: >
      $["x-ms-enum"]["name"] = "SessionHostStatus"
```
