# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridContainerService
namespace: Azure.ResourceManager.HybridContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/8e674dd2a88ae73868c6fa7593a0ba4371e45991/specification/hybridaks/resource-manager/readme.md
tag: package-2024-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - HybridContainerService_ListOrchestrators
  - HybridContainerService_ListVMSkus
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  AddonPhase: ProvisionedClusterAddonPhase
  AddonStatusProfile: ProvisionedClusterAddonStatusProfile
  AgentPool.properties.osSKU: OSSku
  AgentPoolProfile.osSKU: OSSku
  AgentPoolProvisioningStatusOperationStatus: AgentPoolOperationStatus
  AgentPoolProvisioningStatusOperationStatusError: AgentPoolOperationError
  AzureHybridBenefit: ProvisionedClusterAzureHybridBenefit
  CloudProviderProfile: ProvisionedClusterCloudProviderProfile
  CloudProviderProfileInfraNetworkProfile: ProvisionedClusterInfraNetworkProfile
  ControlPlaneEndpointProfileControlPlaneEndpoint: ProvisionedClusterControlPlaneEndpoint
  ControlPlaneProfile: ProvisionedClusterControlPlaneProfile
  CredentialResult: HybridContainerServiceCredential
  LinuxProfilePropertiesSsh: LinuxSshConfiguration
  LinuxProfilePropertiesSshPublicKeysItem: LinuxSshPublicKey
  ListCredentialResponse: HybridContainerServiceCredentialListResult
  ListCredentialResponseError: HybridContainerServiceCredentialListError
  NetworkPolicy: ProvisionedClusterNetworkPolicy
  NetworkProfile: ProvisionedClusterNetworkProfile
  NetworkProfileLoadBalancerProfile: ProvisionedClusterLoadBalancerProfile
  Ossku: HybridContainerServiceOSSku
  ProvisionedClusterPropertiesStatus: ProvisionedClusterStatus
  ProvisionedClusterPropertiesStatusOperationStatus: ProvisionedClusterOperationStatus
  ProvisionedClusterPropertiesStatusOperationStatusError: ProvisionedClusterOperationError
  VirtualNetworkPropertiesInfraVnetProfile: InfraVnetProfile
  VirtualNetworkPropertiesInfraVnetProfileHci: HciInfraVnetProfile
  VirtualNetworkPropertiesInfraVnetProfileVmware: VMwareInfraVnetProfile
  VirtualNetworkPropertiesStatus: HybridContainerServiceNetworkStatus
  VirtualNetworkPropertiesStatusOperationStatusError: HybridContainerServiceNetworkOperationError
  VirtualNetworkPropertiesVipPoolItem: KubernetesVirtualIPItem
  VirtualNetworkPropertiesVmipPoolItem: VirtualMachineIPItem
  VmSkuProfile: HybridContainerServiceVmSku
  StorageProfileSmbCSIDriver.enabled: IsSmbCsiDriverEnabled
  StorageProfileNfsCSIDriver.enabled: IsNfsCsiDriverEnabled

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

prepend-rp-prefix:
  - AgentPoolProfile
  - AgentPool
  - Expander
  - ExtendedLocation
  - ExtendedLocationTypes
  - NamedAgentPoolProfile
  - VirtualNetwork
  - VirtualNetworkProperties
  - OsType
  - ProvisioningState
  - ResourceProvisioningState
  - VmSkuProperties
  - VmSkuCapabilities

directive:
  - from: provisionedClusterInstances.json
    where: $.definitions
    transform: >
      $.VmSkuProfile.properties.properties['x-ms-client-flatten'] = true;
      $.agentPoolProvisioningStatus['x-ms-client-name'] = 'HybridaksAgentPoolProvisioningStatus';
  - from: virtualNetworks.json
    where: $.definitions
    transform: >
      $.virtualNetwork.properties.extendedLocation = {
        "$ref": "./provisionedClusterInstances.json#/definitions/ExtendedLocation"
      };
```
