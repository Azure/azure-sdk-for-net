# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ScVmm
namespace: Azure.ResourceManager.ScVmm
require: https://github.com/Azure/azure-rest-api-specs/blob/1f0722d117a66ec48674c9644f786972d57a29b5/specification/scvmm/resource-manager/readme.md
#tag: package-2023-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  QoS: Qos

rename-mapping:
  AvailabilitySetListItem: ScVmmAvailabilitySetItem
  Force: ScVmmForceDeletion
  VirtualMachineCreateCheckpoint: VirtualMachineCreateCheckpointContent
  VirtualMachineDeleteCheckpoint: VirtualMachineDeleteCheckpointContent
  VirtualMachineRestoreCheckpoint: VirtualMachineRestoreCheckpointContent
  VMMServer: ScVmmServer
  VmInstanceHybridIdentityMetadata: ScVmmHybridIdentityMetadata

prepend-rp-prefix:
  - AvailabilitySet
  - Checkpoint
  - Cloud
  - CloudCapacity
  - ExtendedLocation
  - GuestAgent
  - GuestCredential
  - HardwareProfile
  - HardwareProfileUpdate
  - HttpProxyConfiguration
  - InfrastructureProfile
  - InfrastructureProfileUpdate
  - InventoryItem
  - InventoryItemDetails
  - InventoryItemProperties
  - InventoryType
  - NetworkInterface
  - NetworkInterfaceUpdate
  - NetworkProfile
  - NetworkProfileUpdate
  - OsType
  - ProvisioningAction
  - ProvisioningState
  - ResourcePatch
  - StorageProfile
  - StorageProfileUpdate
  - StorageQoSPolicy
  - StorageQoSPolicyDetails
  - VirtualDisk
  - VirtualDiskUpdate
  - VirtualNetwork
  - VirtualMachineInstance
  - VirtualMachineTemplate

directive:
  - from: swagger-document
    where: $.definitions.InventoryItem.properties.properties
    transform: $["x-ms-client-flatten"] = false;
```
