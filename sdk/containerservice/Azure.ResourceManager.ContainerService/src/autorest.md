# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ContainerService
namespace: Azure.ResourceManager.ContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/8e674dd2a88ae73868c6fa7593a0ba4371e45991/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/readme.md
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
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/locations/{location}/osOptions/default: osOptions/default

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
  # Change from ManagedServiceIdentity to ManagedClusterIdentity
  ManagedCluster.identity: ClusterIdentity
  DelegatedResource: ManagedClusterDelegatedIdentity
  ManagedCluster.properties.resourceUID: ResourceID|arm-id
  IstioEgressGateway.enabled: IsEnabled
  IstioIngressGateway.enabled: IsEnabled
  ManagedClusterWorkloadAutoScalerProfileKeda.enabled: IsKedaEnabled
  ManagedClusterSecurityProfileWorkloadIdentity.enabled: IsWorkloadIdentityEnabled

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
  - OSOptionProperty
  - OSSku
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

directive:
  - from: managedClusters.json
    where: $.definitions.AgentPoolAvailableVersionsProperties.properties.agentPoolVersions.items
    transform: >
      $['x-ms-client-name'] = 'AgentPoolAvailableVersion';
      $.properties.default['x-ms-client-name'] = 'IsDefault';
  - from: managedClusters.json
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.osDiskSizeGB
    transform: >
      $['x-ms-client-name'] = 'OSDiskSizeInGB';
  - from: managedClusters.json
    where: $.definitions.ContainerServiceMasterProfile.properties.osDiskSizeGB
    transform: >
      $['x-ms-client-name'] = 'OSDiskSizeInGB';
  - from: managedClusters.json
    where: $.definitions
    transform: >
      $.OSSKU['x-ms-enum'].name = 'OSSku';
      $.MaintenanceConfigurationProperties.properties.timeInWeek['x-ms-client-name'] = 'TimesInWeek';
      $.MaintenanceConfigurationProperties.properties.notAllowedTime['x-ms-client-name'] = 'NotAllowedTimes';
      $.PrivateLinkResource.properties.id['x-ms-format'] = 'arm-id';
      $.ManagedClusterProperties.properties.autoScalerProfile.properties['scan-interval']['x-ms-client-name'] = 'ScanIntervalInSeconds';
      $.ManagedClusterWindowsProfile.properties.enableCSIProxy['x-ms-client-name'] = 'IsCsiProxyEnabled';
      $.ManagedClusterAADProfile.properties.adminGroupObjectIDs.items.format = 'uuid';
```
