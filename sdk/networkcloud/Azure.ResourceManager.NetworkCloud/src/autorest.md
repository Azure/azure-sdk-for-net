# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/ed9bde6a3db71b84fdba076ba0546213bcce56ee/specification/networkcloud/resource-manager/readme.md
#tag: package-2023-07-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#  show-serialized-names: true

# 'tenantId': 'uuid' cannot be used globally as it break our list clusters API where tenantId sometimes is an empty string
format-by-name-rules:
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  AgentOptions: NetworkCloudAgentConfiguration
  BareMetalMachine.properties.associatedResourceIds: -|arm-id
  BareMetalMachine.properties.clusterId: -|arm-id
  BareMetalMachine.properties.rackId: -|arm-id
  BareMetalMachine.properties.oamIpv4Address: -|ip-address
  BareMetalMachineConfigurationData: BareMetalMachineConfiguration
  BareMetalMachineKeySet.properties.expiration: ExpireOn
  BareMetalMachineKeySet.properties.jumpHostsAllowed: -|ip-address
  BareMetalMachineKeySet.properties.lastValidation: LastValidatedOn
  BareMetalMachineKeySetPatchParameters.properties.expiration: ExpireOn
  BareMetalMachineKeySetPatchParameters.properties.jumpHostsAllowed: -|ip-address
  BmcKeySet.properties.expiration: ExpireOn
  BmcKeySet.properties.lastValidation: LastValidatedOn
  BmcKeySetPatchParameters.properties.expiration: ExpireOn
  BootstrapProtocol.PXE: Pxe
  Cluster.properties.analyticsWorkspaceId: -|arm-id
  Cluster.properties.clusterManagerId: -|arm-id
  Cluster.properties.networkFabricId: -|arm-id
  Cluster.properties.supportExpiryDate: SupportExpireOn|date-time
  Cluster.properties.workloadResourceIds: -|arm-id
  ClusterAvailableUpgradeVersion.supportExpiryDate: SupportExpireOn|date-time
  ClusterManager.properties.analyticsWorkspaceId: -|arm-id
  ClusterManager.properties.fabricControllerId: -|arm-id
  CloudServicesNetwork.properties.clusterId: -|arm-id
  CloudServicesNetwork.properties.associatedResourceIds: -|arm-id
  CloudServicesNetwork.properties.virtualMachinesAssociatedIds: -|arm-id
  CloudServicesNetwork.properties.hybridAksClustersAssociatedIds: -|arm-id
  Console: NetworkCloudVirtualMachineConsole
  Console.properties.expiration: ExpireOn
  Console.properties.privateLinkServiceId: -|arm-id
  Console.properties.virtualMachineAccessId: -|uuid
  ConsolePatchParameters.properties.expiration: ExpireOn
  ImageRepositoryCredentials.registryUrl: registryUriString
  KubernetesCluster.properties.attachedNetworkIds: -|arm-id
  KubernetesCluster.properties.clusterId: -|arm-id
  KubernetesCluster.properties.connectedClusterId: -|arm-id
  L2Network.properties.associatedResourceIds: -|arm-id
  L2Network.properties.clusterId: -|arm-id
  L2Network.properties.hybridAksClustersAssociatedIds: -|arm-id
  L2Network.properties.l2IsolationDomainId: -|arm-id
  L2Network.properties.virtualMachinesAssociatedIds: -|arm-id
  L2NetworkAttachmentConfiguration.networkId: -|arm-id
  L3Network.properties.associatedResourceIds: -|arm-id
  L3Network.properties.clusterId: -|arm-id
  L3Network.properties.hybridAksClustersAssociatedIds: -|arm-id
  L3Network.properties.l3IsolationDomainId: -|arm-id
  L3Network.properties.virtualMachinesAssociatedIds: -|arm-id
  L3NetworkAttachmentConfiguration.networkId: -|arm-id
  NetworkConfiguration: KubernetesClusterNetworkConfiguration
  NetworkConfiguration.cloudServicesNetworkId: -|arm-id
  NetworkConfiguration.cniNetworkId: -|arm-id
  NetworkConfiguration.dnsServiceIp: -|ip-address
  OsDisk.diskSizeGB: DiskSizeInGB
  Rack.properties.clusterId: -|arm-id
  Rack.properties.rackSkuId: -|arm-id
  RackDefinition.networkRackId: -|arm-id
  RackDefinition.rackSkuId: -|arm-id
  StorageAppliance.properties.clusterId: -|arm-id
  StorageAppliance.properties.managementIpv4Address: -|ip-address
  StorageAppliance.properties.rackId: -|arm-id
  StorageApplianceConfigurationData: StorageApplianceConfiguration
  StorageProfile.volumeAttachments: -|arm-id
  TrunkedNetwork.properties.clusterId: -|arm-id
  TrunkedNetwork.properties.hybridAksClustersAssociatedIds: -|arm-id
  TrunkedNetwork.properties.virtualMachinesAssociatedIds: -|arm-id
  TrunkedNetwork.properties.isolationDomainIds: -|arm-id
  TrunkedNetworkAttachmentConfiguration.networkId: -|arm-id
  VirtualMachine.properties.bareMetalMachineId: -|arm-id
  VirtualMachine.properties.clusterId: -|arm-id
  VirtualMachine.properties.volumes: -|arm-id
  VirtualMachine.properties.memorySizeGB: MemorySizeInGB
  VirtualMachinePlacementHint.resourceId: -|arm-id
  Volume.properties.sizeMiB: SizeInMiB

models-to-treat-empty-string-as-null:
  - NetworkCloudClusterManagerData

prepend-rp-prefix:
  - AadConfiguration
  - AgentPool
  - AgentPoolMode
  - BareMetalMachine
  - BareMetalMachineKeySet
  - BmcKeySet
  - CloudServicesNetwork
  - Cluster
  - ClusterManager
  - ClusterMetricsConfiguration
  - KubernetesCluster
  - L2Network
  - L3Network
  - NetworkInterface
  - Nic
  - OsDisk
  - Rack
  - RackDefinition
  - RackSku
  - SshPublicKey
  - StorageAppliance
  - StorageProfile
  - TrunkedNetwork
  - VirtualMachine
  - Volume
  - OperationStatusResult

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

directive:
  - from: networkcloud.json
    where: $.definitions
    transform:
      $.ClusterAvailableUpgradeVersion.properties.expectedDuration['x-ms-format'] = 'duration';
  # The `password` is not required as it return null from service side
  - from: networkcloud.json
    where: $.definitions
    transform:
      $.AdministrativeCredentials.required =  [ 'username' ];
      $.ImageRepositoryCredentials.required = [
        'username',
        'registryUrl'
      ];
      $.ServicePrincipalInformation.required = [
        'tenantId',
        'principalId',
        'applicationId'
      ];
  # `delete` transformations are to remove APIs/methods that result in Access Denied for end users.
  - remove-operation: BareMetalMachines_CreateOrUpdate
  - remove-operation: BareMetalMachines_Delete
  - remove-operation: Racks_CreateOrUpdate
  - remove-operation: Racks_Delete
  - remove-operation: StorageAppliances_CreateOrUpdate
  - remove-operation: StorageAppliances_Delete

```
