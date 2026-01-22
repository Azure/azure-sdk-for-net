# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ContainerService
namespace: Azure.ResourceManager.ContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/49c01c8ca5ac61de4e4f238d76a77b3e0fd7ac2d/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/readme.md
#tag: package-2025-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

mgmt-debug:
  show-serialized-names: true

rename-mapping:
  ManagedClusterPodIdentityProvisioningError.error: 'ErrorDetail'
  Code: ContainerServiceStateCode
  Format: KubeConfigFormat
  Expander: AutoScaleExpander
  KubeletConfig.containerLogMaxSizeMB: ContainerLogMaxSizeInMB
  LinuxOSConfig.swapFileSizeMB: SwapFileSizeInMB
  ManagedClusterAADProfile.managed: IsManagedAadEnabled
  ManagedClusterAADProfile.enableAzureRBAC: IsAzureRbacEnabled
  ConnectionStatus: ContainerServicePrivateLinkServiceConnectionStatus
  CredentialResults: ManagedClusterCredentials
  CredentialResult: ManagedClusterCredential
  LicenseType: WindowsVmLicenseType
  ManagedClusterPropertiesAutoScalerProfile: ManagedClusterAutoScalerProfile
  Snapshot: AgentPoolSnapshot
  SnapshotListResult: AgentPoolSnapshotListResult
  PrivateLinkResource: ContainerServicePrivateLinkResourceData
  ManagedClusterAddonProfile.enabled: IsEnabled
  ManagedClusterPodIdentityProfile.enabled: IsEnabled
  WindowsGmsaProfile.enabled: IsEnabled
  TimeSpan.start: StartOn
  TimeSpan.end: EndOn
  KubeletConfig.failSwapOn: FailStartWithSwapOn
  ManagedClusterStorageProfileDiskCSIDriver.enabled: IsEnabled
  ManagedClusterStorageProfileFileCSIDriver.enabled: IsEnabled
  ManagedClusterStorageProfileSnapshotController.enabled: IsEnabled
  ManagedClusterStorageProfileBlobCSIDriver.enabled: IsEnabled
  KubeletConfig.cpuCfsQuota: IsCpuCfsQuotaEnabled
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  RunCommandRequest: ManagedClusterRunCommandContent
  RunCommandResult: ManagedClusterRunCommandResult
  UserAssignedIdentity.objectId: -|uuid
  UserAssignedIdentity.clientId: -|uuid
  ManagedClusterAADProfile.serverAppID: -|uuid
  ManagedClusterAADProfile.clientAppID: -|uuid
  ManagedClusterSecurityProfileDefenderSecurityMonitoring.enabled: IsSecurityMonitoringEnabled
  AzureKeyVaultKms: ManagedClusterSecurityProfileKeyVaultKms
  AzureKeyVaultKms.enabled: IsEnabled
  KeyVaultNetworkAccessTypes: ManagedClusterKeyVaultNetworkAccessType
  ManagedClusterOidcIssuerProfile.enabled: IsEnabled
  ManagedClusterOidcIssuerProfile.issuerURL: IssuerUriInfo
  AbsoluteMonthlySchedule: ContainerServiceMaintenanceAbsoluteMonthlySchedule
  RelativeMonthlySchedule: ContainerServiceMaintenanceRelativeMonthlySchedule
  Type: ContainerServiceMaintenanceRelativeMonthlyScheduleWeekIndex
  Schedule: ContainerServiceMaintenanceSchedule
  WeeklySchedule: ContainerServiceMaintenanceWeeklySchedule
  BackendPoolType: ManagedClusterLoadBalancerBackendPoolType
  ManagedClusterAzureMonitorProfileKubeStateMetrics: ManagedClusterMonitorProfileKubeStateMetrics
  ManagedClusterAzureMonitorProfileMetrics: ManagedClusterMonitorProfileMetrics
  ManagedClusterAzureMonitorProfileMetrics.enabled: IsEnabled
  ManagedClusterSecurityProfileImageCleaner.enabled: IsEnabled
  ManagedClusterWorkloadAutoScalerProfileVerticalPodAutoscaler: ManagedClusterVerticalPodAutoscaler
  ManagedClusterWorkloadAutoScalerProfileVerticalPodAutoscaler.enabled: IsVpaEnabled
  NodeOSUpgradeChannel: ManagedClusterNodeOSUpgradeChannel
  PortRange: AgentPoolNetworkPortRange
  Protocol: AgentPoolNetworkPortProtocol
  AgentPool.properties.capacityReservationGroupID: -|arm-id
  ManagedClusterAgentPoolProfileProperties.capacityReservationGroupID: -|arm-id
  MaintenanceWindow.startDate: -|string
  ManagedCluster.identity: ClusterIdentity
  DelegatedResource: ManagedClusterDelegatedIdentity
  ManagedCluster.properties.resourceUID: ResourceID|arm-id
  IstioEgressGateway.enabled: IsEnabled
  IstioIngressGateway.enabled: IsEnabled
  ManagedClusterWorkloadAutoScalerProfileKeda.enabled: IsKedaEnabled
  ManagedClusterSecurityProfileWorkloadIdentity.enabled: IsWorkloadIdentityEnabled
  AgentPoolWindowsProfile.disableOutboundNat: IsOutboundNatDisabled
  ManagedNamespace: ManagedClusterNamespace
  NamespaceProperties: ManagedClusterNamespaceProperties
  AdoptionPolicy: NamespaceAdoptionPolicy
  AdvancedNetworking: ManagedClusterAdvancedNetworking
  AdvancedNetworking.enabled: IsEnabled
  AdvancedNetworkingSecurity: ManagedClusterAdvancedNetworkingSecurity
  AdvancedNetworkPolicies: ManagedClusterAdvancedNetworkPolicy
  AdvancedNetworkingObservability.enabled: IsObservabilityEnabled
  AgentPoolDeleteMachinesParameter: AgentPoolDeleteMachinesContent
  AgentPoolSecurityProfile.enableVTPM: IsVtpmEnabled
  AgentPoolSecurityProfile.enableSecureBoot: IsSecureBootEnabled
  AgentPoolSSHAccess: AgentPoolSshAccess
  ManagedClusterStaticEgressGatewayProfile.enabled: IsStaticEgressGatewayAddonEnabled
  DeletePolicy: NamespaceDeletePolicy
  GPUProfile: AgentPoolGpuProfile
  GPUDriver: AgentPoolGpuDriver
  NamespaceProvisioningState: ManagedClusterNamespaceProvisioningState
  NetworkPolicies: NamespaceNetworkPolicies
  PolicyRule: NamespaceNetworkPolicyRule
  ResourceQuota: NamespaceResourceQuota
  RestrictionLevel:  ManagedClusterNodeResourceGroupRestrictionLevel
  VirtualMachineNodes: AgentPoolVirtualMachineNodes
  ManagedClusterAIToolchainOperatorProfile.enabled: IsAIToolchainOperatorEnabled
  ManagedClusterCostAnalysis.enabled: IsCostAnalysisEnabled
  AdvancedNetworkingSecurity.enabled: IsEnabled
  ManagedClusterIngressProfileWebAppRouting.enabled: IsEnabled
  ContainerServiceNetworkProfile.ipFamilies: NetworkIPFamilies
  AgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem: AgentPoolAvailableVersion
  AgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem.default: IsDefault
  ManagedClusterAgentPoolProfileProperties.osDiskSizeGB: OSDiskSizeInGB
  Ossku: ContainerServiceOSSku
  MaintenanceConfiguration.properties.timeInWeek: TimesInWeek
  MaintenanceConfiguration.properties.notAllowedTime: NotAllowedTimes
  PrivateLinkResource.id: -|arm-id
  ManagedClusterPropertiesAutoScalerProfile.scan-interval: ScanIntervalInSeconds
  ManagedClusterWindowsProfile.enableCSIProxy: IsCsiProxyEnabled
  ManagedClusterAADProfile.adminGroupObjectIDs: -|uuid
  IPFamily: ContainerServiceIPFamily
  AgentPool.properties.osDiskSizeGB: OSDiskSizeInGB

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ResourceType': 'resource-type'
  '*ResourceId': 'arm-id'
  'NodePublicIPPrefixId': 'arm-id'
  '*SubnetId': 'arm-id'
  'ProximityPlacementGroupId': 'arm-id'
  'DiskEncryptionSetId': 'arm-id'
  'PrivateLinkServiceId': 'arm-id'
  'PrincipalId': 'uuid'
  'IPAddress': 'ip-address'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  Iptables: IPTables
  Ipvs: IPVS
  ID: Id
  IDs: Ids
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
  URL: Url
  URLs: Urls
  Etag: ETag|etag
  SSD: Ssd
  GPU: Gpu
  SKU: Sku
  AAD: Aad
  TrustedCa: TrustedCA
  CBLMariner: CblMariner
  API: Api
  OCI: Oci
  CSI: Csi
  MIG1G: Mig1G
  MIG2G: Mig2G
  MIG3G: Mig3G
  MIG4G: Mig4G
  MIG7G: Mig7G
  Tcpkeepalive: TcpKeepalive
  TCP: Tcp
  UDP: Udp

override-operation-name:
  ResolvePrivateLinkServiceId_Post: ResolvePrivateLinkServiceId
  AgentPools_GetAvailableAgentPoolVersions: GetAvailableAgentPoolVersions

prepend-rp-prefix:
  - TimeSpan
  - TimeInWeek
  - WeekDay
  - OSType
  - OSDiskType
  - UserAssignedIdentity
  - AgentPool
  - MaintenanceConfiguration
  - MaintenanceConfigurationListResult
  - ManagedCluster
  - AgentPoolListResult
  - PublicNetworkAccess
  - CreationData
  - EndpointDependency
  - EndpointDetail
  - LoadBalancerSku
  - NetworkMode
  - NetworkPlugin
  - NetworkPolicy
  - OutboundEnvironmentEndpoint
  - OutboundType
  - PrivateLinkResourcesListResult
  - TagsObject
  - PowerState
  - DateSpan
  - IPTag
  - MaintenanceWindow
  - NetworkPluginMode
  - TrustedAccessRole
  - TrustedAccessRoleBinding
  - TrustedAccessRoleRule
  - TrustedAccessRoleBindingProvisioningState
  - Machine
  - MachineProperties
  - ArtifactSource
  - MachineIpAddress

directive:
  - from: managedClusters.json
    where: $.definitions
    transform: >
      $.ManagedClusterPoolUpgradeProfile.properties.upgrades['readonly'] = true;
```
