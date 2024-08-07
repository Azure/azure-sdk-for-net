# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci
namespace: Azure.ResourceManager.Hci
require: https://github.com/Azure/azure-rest-api-specs/blob/07d286359f828bbc7901e86288a5d62b48ae2052/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/readme.md
#tag: package-2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
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
  HostNetwork: HciClusterHostNetwork
  InfrastructureNetwork: HciClusterInfrastructureNetwork
  Intents: HciClusterIntents
  IpPools: HciClusterIPPools
  LogCollectionRequestProperties: LogCollectionContentProperties
  NetworkController: HciClusterNetworkController
  NicDetail: HciEdgeDeviceNicDetail
  NicDetail.ip4Address: IPv4Address
  HciNicDetail.ip4Address: IPv4Address
  Observability: HciClusterObservability
  Observability.streamingDataClient: IsStreamingDataClientEnabled
  Observability.euLocation: IsEULocation
  Observability.episodicDataUpload: IsEpisodicDataUploadEnabled
  PhysicalNodes: HciClusterPhysicalNodes
  QosPolicyOverrides: HciClusterQosPolicyOverrides
  RemoteSupportRequestProperties: RemoteSupportContentProperties
  RemoteSupportNodeSettings.arcResourceId: -|arm-id
  RemoteSupportProperties.expirationTimeStamp: ExpireOn
  RemoteSupportRequestProperties.expirationTimeStamp: ExpireOn
  ReportedProperties: HciEdgeDeviceReportedProperties
  ScaleUnits: HciClusterScaleUnits
  Storage: HciClusterStorage
  StorageAdapterIPInfo: HciClusterStorageAdapterIPInfo
  StorageNetworks: HciClusterStorageNetworks
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

directive:
  - from: swagger-document
    where: $.definitions..systemData
    transform: $["x-ms-client-flatten"] = false
  - from: updateRuns.json
    where: $.definitions.UpdateRunProperties.properties
    transform: >
      $.duration['x-ms-format'] = 'string';
  - from: edgeDevices.json
    where: $.definitions
    transform: >
      $.HostNetwork.properties.intents.items['$ref'] = "./deploymentSettings.json#/definitions/Intents";
      $.HciNetworkProfile.properties.hostNetwork['$ref'] = "./deploymentSettings.json#/definitions/HostNetwork";
      $.ErrorDetail['x-ms-client-name'] = 'HciValidationFailureDetail';
      $.Extension['x-ms-client-name'] = 'HciEdgeDeviceArcExtension';
```
