# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/ed9bde6a3db71b84fdba076ba0546213bcce56ee/specification/networkcloud/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# 'tenantId': 'uuid' cannot be used globally as it break our list clusters API where tenantId sometimes is an empty string
format-by-name-rules:
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  ImageRepositoryCredentials.registryUrl: registryUriString
  BareMetalMachineConfigurationData: BareMetalMachineConfiguration 
  ClusterMetricsConfigurationData.collectionInterval: collectionIntervalInSeconds
  StorageApplianceConfigurationData: StorageApplianceConfiguration 
  AgentOptions: AgentConfig
  # The supportExpiryDate in cluster response does not conform to date-time format. This field will continue to be a string in the current stable api version.
  # ClusterAvailableUpgradeVersion.supportExpiryDate: -|date-time
  # ClusterAvailableVersion.supportExpiryDate: -|date-time
  ClusterData.supportExpiryDate: -|date-time 
  BareMetalMachineData.clusterId: -|arm-id
  BareMetalMachineData.machineSkuId: -|arm-id
  BareMetalMachineData.rackId: -|arm-id
  BareMetalMachineKeySetData.azureGroupId: -|arm-id
  BmcKeySetData.azureGroupId: -|arm-id
  CloudServicesNetworkData.clusterId: -|arm-id 
  CloudServicesNetworkData.hybridAksClustersAssociatedIds: -|arm-id 
  ClusterData.analyticsWorkspaceId: -|arm-id 
  ClusterData.clusterManagerId: -|arm-id 
  ClusterData.networkFabricId: -|arm-id 
  ClusterManagerData.analyticsWorkspaceId: -|arm-id 
  ClusterManagerData.fabricControllerId: -|arm-id 
  ConsoleData.virtualMachineAccessId: -|arm-id 
  KubernetesClusterData.clusterId: -|arm-id 
  KubernetesClusterData.connectedClusterId: -|arm-id 
  L2NetworkData.associatedResourceIds: -|arm-id 
  L2NetworkData.clusterId: -|arm-id 
  L2NetworkData.l2IsolationDomainId: -|arm-id 
  L3NetworkData.clusterId: -|arm-id 
  L3NetworkData.l2IsolationDomainId: -|arm-id
  RackData.clusterId: -|arm-id 
  RackData.rackSkuId: -|arm-id 
  StorageApplianceData.clusterId: -|arm-id 
  StorageApplianceData.rackId: -|arm-id 
  StorageApplianceData.storageApplianceSkuId: -|arm-id 
  TrunkedNetworkData.clusterId: -|arm-id 
  TrunkedNetworkData.isolationDomainIds: -|arm-id 
  VirtualMachineData.bareMetalMachineId: -|arm-id 
  VirtualMachineData.clusterId: -|arm-id 
  L2NetworkAttachmentConfiguration.networkId: -|arm-id 
  L3NetworkAttachmentConfiguration.networkId: -|arm-id 
  NetworkConfiguration.cloudServicesNetworkId: -|arm-id 
  NetworkConfiguration.cniNetworkId: -|arm-id 
  RackDefinition.networkRackId: -|arm-id 
  TrunkedNetworkAttachmentConfiguration.networkId: -|arm-id 
  # 'applicationId','principalId','tenantId' cannot be used globally as it break our list clusters API where tenantId,applicationId,principalId are sometimes an empty string
  # ServicePrincipalInformation.applicationId: -|uuid
  # ServicePrincipalInformation.principalId: -|uuid 
  # ServicePrincipalInformation.tenantId: -|uuid



rename-rules:
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
