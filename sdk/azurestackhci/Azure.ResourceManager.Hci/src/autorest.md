# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci
namespace: Azure.ResourceManager.Hci
require: https://github.com/Azure/azure-rest-api-specs/blob/afb290a389f8ee1d3a7612e703f31817d6c8ff15/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/readme.md
#tag: package-preview-2025-11-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

override-operation-name:
  Offers_ListByCluster: GetHciClusterOffers
  KubernetesVersions_ListBySubscriptionLocationResource: GetHciKubernetesVersionsByLocation

format-by-name-rules:
  '*TenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ClientId': 'uuid'
  '*ApplicationObjectId': 'uuid'
  '*ServicePrincipalObjectId': 'uuid'

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
  SMB: Smb|smb

prepend-rp-prefix:
  - Cluster
  - ProvisioningState
  - ClusterDesiredProperties
  - ClusterNode
  - ClusterReportedProperties
  - AvailabilityType
  - HealthState
  - ManagedServiceIdentityType
  - OfferList
  - PackageVersionInfo
  - PrecheckResult
  - PrecheckResultTags
  - PublisherList
  - SkuList
  - SkuMappings
  - UpdateList
  - StatusLevelTypes

rename-mapping:
  Extension: ArcExtension
  Extension.properties.extensionParameters.autoUpgradeMinorVersion: ShouldAutoUpgradeMinorVersion
  Extension.properties.extensionParameters.type: ArcExtensionType
  ExtensionInstanceView: ArcExtensionInstanceView
  ExtensionInstanceViewStatus: ArcExtensionInstanceViewStatus
  ExtensionManagedBy: ArcExtensionManagedBy
  ExtensionUpgradeParameters: ArcExtensionUpgradeContent
  Status: HciClusterStatus
  ClusterReportedProperties.clusterId: -|uuid
  Cluster.properties.cloudId: -|uuid
  ArcIdentityResponse: ArcIdentityResult
  ClusterIdentityResponse: HciClusterIdentityResult
  ClusterReportedProperties.lastUpdated: LastUpdatedOn
  ClusterList: HciClusterListResult
  DiagnosticLevel: HciClusterDiagnosticLevel
  ExtensionAggregateState: ArcExtensionAggregateState
  ExtensionList: ArcExtensionListResult
  ImdsAttestation: ImdsAttestationState
  PasswordCredential: ArcPasswordCredential
  UploadCertificateRequest: HciClusterCertificateContent
  RawCertificateData: HciClusterRawCertificate
  PerNodeState: PerNodeArcState
  RebootRequirement: HciNodeRebootRequirement
  Severity: UpdateSeverity
  State: HciUpdateState
  Step: HciUpdateStep
  ClusterPatch.identity.type: ManagedServiceIdentityType
  ExtensionPatchParameters: ArcExtensionPatchContent
  ExtensionPatchParameters.enableAutomaticUpgrade: IsAutomaticUpgradeEnabled
  DeploymentSetting: HciClusterDeploymentSetting
  DeploymentSetting.properties.arcNodeResourceIds: -|arm-id
  OperationType: HciClusterOperationType
  DeploymentConfiguration: HciClusterDeploymentConfiguration
  HciEdgeDevice: HciArcEnabledEdgeDevice
  HciEdgeDeviceProperties: HciArcEnabledEdgeDeviceProperties
  EdgeDeviceProperties: HciEdgeDeviceProperties
  EdgeDevice: HciEdgeDevice
  SecuritySetting: HciClusterSecuritySetting
  AccessLevel: HciClusterAccessLevel
  ComplianceAssignmentType: HciClusterComplianceAssignmentType
  ComplianceStatus: HciClusterComplianceStatus
  ConnectivityStatus: HciClusterConnectivityStatus
  DefaultExtensionDetails: ArcDefaultExtensionDetails
  DeploymentCluster: HciDeploymentCluster
  DeploymentData: HciClusterDeploymentInfo
  DeploymentMode: EceDeploymentMode
  DeploymentSecuritySettings: HciClusterDeploymentSecuritySettings
  DeploymentSecuritySettings.hvciProtection: IsHvciProtectionEnabled
  DeploymentSecuritySettings.drtmProtection: IsDrtmProtectionEnabled
  DeploymentSecuritySettings.driftControlEnforced: IsDriftControlEnforced
  DeploymentSecuritySettings.credentialGuardEnforced: IsCredentialGuardEnforced
  DeploymentSecuritySettings.smbSigningEnforced: IsSmbSigningEnforced
  DeploymentSecuritySettings.smbClusterEncryption: IsSmbClusterEncryptionEnabled
  DeploymentSecuritySettings.sideChannelMitigationEnforced: IsSideChannelMitigationEnforced
  DeploymentSecuritySettings.bitlockerBootVolume: IsBitlockerBootVolumeEnabled
  DeploymentSecuritySettings.bitlockerDataVolumes: AreBitlockerDataVolumesEnabled
  DeploymentSecuritySettings.wdacEnforced: IsWdacEnforced
  DeploymentStep: HciClusterDeploymentStep
  DeploymentStep.startTimeUtc: StartOn
  DeploymentStep.endTimeUtc: EndOn
  DeviceConfiguration: HciEdgeDeviceConfiguration
  DeviceState: HciEdgeDeviceState
  EceSecrets.AzureStackLCMUserCredential: AzureStackLcmUserCredential
  EceSecrets.DefaultARBApplication: DefaultArbApplication
  InfrastructureNetwork: DeploymentSettingInfrastructureNetwork
  IpPools: DeploymentSettingIPPools
  LogCollectionRequestProperties: LogCollectionContentProperties
  NetworkController: DeploymentSettingNetworkController
  NicDetail: HciEdgeDeviceNicDetail
  NicDetail.ip4Address: IPv4Address
  HciNicDetail.ip4Address: IPv4Address
  Observability: DeploymentSettingObservability
  Observability.streamingDataClient: IsStreamingDataClientEnabled
  Observability.euLocation: IsEULocation
  Observability.episodicDataUpload: IsEpisodicDataUploadEnabled
  PhysicalNodes: DeploymentSettingPhysicalNodes
  QosPolicyOverrides: DeploymentSettingQosPolicyOverrides
  RemoteSupportRequestProperties: RemoteSupportContentProperties
  RemoteSupportNodeSettings.arcResourceId: -|arm-id
  RemoteSupportProperties.expirationTimeStamp: ExpireOn
  RemoteSupportRequestProperties.expirationTimeStamp: ExpireOn
  ReportedProperties: HciEdgeDeviceReportedProperties
  ScaleUnits: DeploymentSettingScaleUnits
  Storage: DeploymentSettingStorage
  SwitchDetail: HciEdgeDeviceSwitchDetail
  SwitchExtension: HciEdgeSwitchExtension
  SwitchExtension.extensionEnabled: IsExtensionEnabled
  ValidateRequest: HciEdgeDeviceValidateContent
  ValidateRequest.edgeDeviceIds: -|arm-id
  ValidateResponse: HciEdgeDeviceValidateResult
  Offer: HciClusterOffer
  Publisher: HciClusterPublisher
  Update: HciClusterUpdate
  UpdatePrerequisite: HciClusterUpdatePrerequisite
  UpdateRun: HciClusterUpdateRun
  UpdateSummaries: HciClusterUpdateSummary
  UpdateSummariesPropertiesState: HciClusterUpdateState
  PackageVersionInfo.lastUpdated: LastUpdatedOn
  SecurityComplianceStatus.lastUpdated: LastUpdatedOn
  SoftwareAssuranceProperties.lastUpdated: LastUpdatedOn
  UpdateSummaries.properties.lastUpdated: LastUpdatedOn
  UpdateSummaries.properties.lastChecked: LastCheckedOn
  UpdateRun.properties.progress.lastUpdatedTimeUtc: LastCompletedOn
  UpdateRun.properties.progress.startTimeUtc: StartOn
  UpdateRun.properties.progress.endTimeUtc: EndOn
  Step.lastUpdatedTimeUtc: LastUpdatedOn
  Step.startTimeUtc: StartOn
  Step.endTimeUtc: EndOn
  DeviceKind: HciEdgeDeviceKind
  ExtensionProfile: HciEdgeDeviceExtensionProfile
  PerNodeExtensionState.instanceView: ExtensionInstanceView
  KubernetesVersion: HciLocationKubernetesVersion
  SupportStatus: HciClusterSupportStatus
  SecretsType: HciSecretsLocationType
  RdmaCapability: HciNicRdmaCapability
  PlatformPayload: HciPlatformPayload
  OsImage: HciOSImage
  OsImageProperties: HciOSImageProperties
  JobStatus: HciEdgeDeviceJobStatus
  IdentityProvider: HciDeploymentIdentityProvider
  HardwareClass: HciClusterHardwareClass
  DnsZones: HciNetworkDnsZones
  DnsServerConfig: HciNetworkDnsServerConfig
  ContentPayload: HciUpdateContentPayload
  ClusterPattern: HciClusterPattern
  AssemblyInfo: HciDeploymentAssemblyInfo
  AssemblyInfoPayload: HciDeploymentAssemblyInfoPayload
  EdgeDeviceJob: HciEdgeDeviceJobKind
  PlatformUpdate: HciPlatformUpdate
  UpdateContent: HciUpdateContent
  ValidatedSolutionRecipe: HciValidatedSolutionRecipe
  ChangeRingRequestProperties: HciChangeRingContentProperties
  DeviceLogCollectionStatus: HciDeviceLogCollectionJobStatus
  LocalAvailabilityZones: HciClusterLocalAvailabilityZones
  LogCollectionJobSession: HciLogCollectionJobSessionDetails
  LogCollectionReportedProperties: HciLogCollectionReportedProperties
  PlatformUpdateDetails: HciPlatformUpdateDetails
  RemoteSupportAccessLevel: HciRemoteSupportAccessLevel
  RemoteSupportJobNodeSettings: HciRemoteSupportJobNodeSettings
  RemoteSupportJobReportedProperties: HciRemoteSupportJobReportedProperties
  RemoteSupportSession: HciRemoteSupportSession
  SecretsLocationDetails: HciSecretsLocationDetails
  SecretsLocationsChangeRequest: HciSecretsLocationsChangeContent
  ArcConnectivityProperties: HciArcConnectivityProperties

directive:
  - from: hci.json
    where: $.definitions.UpdateRunProperties.properties
    transform: >
      $.duration['x-ms-format'] = 'string';
  - from: hci.json
    where: $.definitions.UpdateRunPropertiesState
    transform: >
      delete $.readOnly;
  # Add missing value to Status enum
  - from: hci.json
    where: $.definitions.Status
    transform: >
      $.enum.push("Succeeded", "Failed", "InProgress");
      $['x-ms-enum'].values.push(
        {
          "name": "Succeeded",
          "value": "Succeeded", 
          "description": "The operation completed successfully."
        },
        {
          "name": "Failed",
          "value": "Failed",
          "description": "The operation failed."
        },
        {
          "name": "InProgress", 
          "value": "InProgress",
          "description": "The operation is currently in progress."
        }
      );

```  
