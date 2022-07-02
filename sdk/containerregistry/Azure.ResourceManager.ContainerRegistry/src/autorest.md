# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ContainerRegistry
namespace: Azure.ResourceManager.ContainerRegistry
require: https://github.com/Azure/azure-rest-api-specs/blob/b9b91929c304f8fb44002267b6c98d9fb9dde014/specification/containerregistry/resource-manager/readme.md
tag: package-2021-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

 

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
  Etag: ETag

directive:
  - rename-operation:
      from: Registries_GetBuildSourceUploadUrl
      to: Build_GetBuildSourceUploadUrl
  - rename-operation:
      from: Registries_ScheduleRun
      to: Build_ScheduleRun

```