# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: StandbyPool
namespace: Azure.ResourceManager.StandbyPool
require: https://github.com/Azure/azure-rest-api-specs/blob/a6074b7654c388dec49c9969d0136cfeb03575c9/specification/standbypool/resource-manager/readme.md
#tag: package-preview-2023-12
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  StandbyContainerGroupPoolResource: StandbyContainerGroupPool
  StandbyVirtualMachinePoolResource: StandbyVirtualMachinePool
  StandbyVirtualMachinePoolResource.properties.attachedVirtualMachineScaleSetId: -|arm-id
  StandbyVirtualMachineResource: StandbyVirtualMachine
  StandbyVirtualMachineResource.properties.virtualMachineResourceId: -|arm-id
  VirtualMachineState: StandbyVirtualMachineState
  ContainerGroupProfile: StandbyContainerGroupProfile
  ContainerGroupProperties: StandbyContainerGroupProperties
  ContainerGroupPropertiesUpdate: StandbyContainerGroupPatchProperties
  ContainerGroupProfileUpdate: StandbyContainerGroupPatchProfile
  StandbyContainerGroupPoolElasticityProfileUpdate: StandbyContainerGroupPoolElasticityPatchProfile
  StandbyVirtualMachinePoolElasticityProfileUpdate: StandbyVirtualMachinePoolElasticityPatchProfile

prepend-rp-prefix:
  - ProvisioningState
  - RefillPolicy

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
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
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

```