# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: scvmm
namespace: Azure.ResourceManager.scvmm
require: https://github.com/Azure/azure-rest-api-specs/blob/ba936cf8f3b4720dc025837281241fdc903f7e4d/specification/scvmm/resource-manager/readme.md
tag: package-2020-06-05-preview
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
  VMM: Vmm
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
