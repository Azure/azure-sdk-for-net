# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.ConnectedVMwarevSphere
require: https://github.com/Azure/azure-rest-api-specs/blob/b8932418d4fd4940849e8722cc90e2b7bf1f8fda/specification/connectedvmware/resource-manager/readme.md
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

rename-mapping:
  Cluster: VMwareCluster
  ClustersList: VMwareClusterListResult
  Datastore: VMwareDatastore
  DatastoresList: VMwareDatastoreListResult
  DiskMode: VMwareDiskMode
  DiskType: VMwareDiskType
  FirmwareType: VMwareFirmwareType
  GuestAgent: VmInstanceGuestAgent
  GuestAgentList: VmInstanceGuestAgentListResult
  GuestCredential: VmInstanceGuestCredential
  HardwareProfile: VmInstanceHardwareProfile
  Host: VMwareHost
  HostsList: VMwareHostListResult
  InfrastructureProfile: VCenterInfrastructureProfile
  InventoryItem: VCenterInventoryItem
  InventoryItemsList: VCenterInventoryItemListResult
  InventoryType: VCenterInventoryType
  NetworkInterface: VMwareNetworkInterface
  NetworkInterfaceUpdate: VMwareNetworkInterfaceUpdate
  NetworkProfile: VMwareNetworkProfile
  NetworkProfileUpdate: VMwareNetworkProfileUpdate
  NICType: VMwareNicType
  OsType: VMwareOsType
  ProvisioningAction: GuestAgentProvisioningAction
  ProvisioningState: VMwareResourceProvisioningState
  ResourcePatch: VMwareResourcePatchContent
  ResourcePool: VMwareResourcePool
  ResourcePoolsList: VMwareResourcePoolListResult
  ResourceStatus: VMwareResourceStatus
  StorageProfile: VMwareStorageProfile
  VCenter: VMwareVCenter
  VCentersList: VMwareVCenterListResult
  VirtualDisk: VMwareVirtualDisk
  VirtualDiskUpdate: VMwareVirtualDiskUpdate
  VirtualMachineInstance: VMwareVmInstance
  VirtualMachineInstancesList: VMwareVmInstanceListResult
  VirtualMachineTemplate: VMwareVmTemplate
  VirtualMachineTemplatesList: VMwareVmTemplateListResult
  VirtualNetwork: VMwareVirtualNetwork
  VirtualNetworksList: VMwareVirtualNetworkListResult
  WindowsConfiguration: VMwareVmWindowsConfiguration
  WindowsConfiguration.autoLogon: isAutoLogon
```
