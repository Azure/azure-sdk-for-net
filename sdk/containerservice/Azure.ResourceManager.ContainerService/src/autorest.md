# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ContainerService
namespace: Azure.ResourceManager.ContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/b9b91929c304f8fb44002267b6c98d9fb9dde014/specification/containerservice/resource-manager/readme.md
tag: package-2022-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/locations/{location}/osOptions/default: osOptions/default

rename-mapping:
  ManagedClusterPodIdentityProvisioningError.error: 'ErrorDetail'
  Code: ManagedClusterStateCode
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
  ManagedClusterSecurityProfileAzureDefender.enabled: IsEnabled
  WindowsGmsaProfile.enabled: IsEnabled
  TimeSpan.start: StartOn
  TimeSpan.end: EndOn

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

override-operation-name:
  ResolvePrivateLinkServiceId_POST: ResolvePrivateLinkServiceId
  AgentPools_GetAvailableAgentPoolVersions: GetAvailableAgentPoolVersions

prepend-rp-prefix:
  - TimeSpan
  - TimeInWeek
  - WeekDay

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
# This caused bugs of duplicate names with single property flatten
#   - from: managedClusters.json
#     where: $.definitions..enabled
#     transform: >
#       $['x-ms-client-name'] = 'IsEnabled';
```
