# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: ArcScVmm
namespace: Azure.ResourceManager.ArcScVmm
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/ba936cf8f3b4720dc025837281241fdc903f7e4d/specification/scvmm/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VMM: Vmm
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

no-property-type-replacement:
- VirtualMachineDeleteCheckpoint
- VirtualMachineRestoreCheckpoint

directive:
  - rename-model:
      from: AvailabilitySet
      to: ScVmmAvailabilitySet
  - rename-model:
      from: Cloud
      to: ScVmmCloud
  - rename-model:
      from: VirtualMachine
      to: ScVmmVirtualMachine
  - rename-model:
      from: VirtualMachineTemplate
      to: ScVmmVirtualMachineTemplate
  - rename-model:
      from: VirtualNetwork
      to: ScVmmVirtualNetwork
  - rename-model:
      from: VMMServer
      to: ScVmmServer
```
