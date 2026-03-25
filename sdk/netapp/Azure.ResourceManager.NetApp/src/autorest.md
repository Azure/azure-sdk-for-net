# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NetApp
namespace: Azure.ResourceManager.NetApp
require: https://github.com/Azure/azure-rest-api-specs/blob/17842bc766fcf93b9e18c7c0294761173d7a8b17/specification/netapp/resource-manager/Microsoft.NetApp/NetApp/readme.md
tag: package-preview-2025-12-15-preview
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
  'ETag': 'etag'
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
  SAP: Sap
  TLS: Tls
  ZRS: Zrs


request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}: NetAppAccountBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}: NetAppVolumeBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/backupVaults/{backupVaultName}/backups/{backupName}: NetAppBackupVaultBackup

override-operation-name:
  NetAppResource_CheckFilePathAvailability: CheckNetAppFilePathAvailability
  NetAppResource_CheckNameAvailability: CheckNetAppNameAvailability
  NetAppResource_CheckQuotaAvailability: CheckNetAppQuotaAvailability
  NetAppResourceQuotaLimits_Get: GetNetAppQuotaLimit
  NetAppResourceQuotaLimits_List: GetNetAppQuotaLimits
  Volumes_ReplicationStatus: GetReplicationStatus
  VolumeGroups_ListByNetAppAccount: GetVolumeGroups
  ElasticCapacityPools_CheckVolumeFilePathAvailability: CheckElasticVolumeFilePathAvailability
  Buckets_GenerateAkvCredentials: GenerateKeyVaultCredentials

request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits/{quotaLimitName}

prepend-rp-prefix:
  - ActiveDirectoryConfig
  - ActiveDirectoryConfigProperties
  - Backup
  - BackupType
  - BackupPolicy
  - Bucket
  - BucketPermissions
  - BucketPatchPermissions
  - BucketServerProperties
  - BucketServerPatchProperties
  - Cache
  - CacheProperties
  - CacheProvisioningState
  - EndpointType
  - ElasticAccount
  - ElasticAccountProperties
  - ElasticBackup
  - ElasticBackupProperties
  - ElasticBackupPolicy
  - ElasticBackupPolicyProperties
  - ElasticBackupType
  - ElasticBackupVault
  - ElasticBackupVaultProperties
  - ElasticCapacityPool
  - ElasticCapacityPoolProperties
  - ElasticSnapshot
  - ElasticSnapshotProperties
  - ElasticSnapshotPolicy
  - ElasticSnapshotPolicyProperties
  - ElasticVolume
  - ElasticVolumeProperties
  - EntraIdConfig
  - EntraIdConfigPatch
  - LdapConfiguration
  - LdapConfigurationPatch
  - Volume
  - VolumeQuotaRule
  - RestoreStatus
  - ApplicationType
  - AvsDataStore
  - ChownMode
  - EncryptionKeySource
  - MirrorState
  - ReplicationObject
  - ReplicationSchedule
  - SecretPassword
  - SecretPasswordIdentity
  - SecretPasswordKeyVaultProperties
  - VolumeStorageToNetworkProximity
  - AccountEncryption
  - KeySource
  - KeyVaultProperties
  - KeyVaultStatus
  - RegionInfo
  - EncryptionIdentity
  - BackupVault
  - ChangeKeyVault
  - DestinationReplication
  - EncryptionTransitionRequest
  - KeyVaultPrivateEndpoint
  - ReplicationType
  - VolumeLanguage
  - ElasticEncryption
  - ManagedServiceIdentityType
  - BucketCredentialsExpiry
  - BucketGenerateCredentials
  - CacheMountTargetProperties
  - CacheLifeCycleState

rename-mapping:
  AzureKeyVaultDetails: NetAppKeyVaultDetails
  AzureKeyVaultDetails.certificateAkvDetails: CertificateKeyVaultDetails
  AzureKeyVaultDetails.credentialsAkvDetails: CredentialsKeyVaultDetails
  Bucket.properties.akvDetails: KeyVaultDetails
  BucketPatch.properties.akvDetails: KeyVaultDetails
  EntraIdConfig.entraIdAkvConfig: EntraIdKeyVaultConfig
  EntraIdConfigPatch.entraIdAkvConfig: EntraIdKeyVaultConfig
  CapacityPool.properties.poolId: -|uuid
  FilePathAvailabilityRequest.subnetId: -|arm-id
  MountTargetProperties.mountTargetId: -|uuid
  MountTargetProperties.fileSystemId: -|uuid
  MountTargetProperties.ipAddress: -|ip-address
  ActiveDirectory.kdcIP: -|ip-address
  ReplicationSchedule._10minutely: TenMinutely
  EndpointType.src: Source
  EndpointType.dst: Destination
  ExportPolicyRule.cifs: AllowCifsProtocol
  ExportPolicyRule.unixReadOnly: IsUnixReadOnly
  ExportPolicyRule.unixReadWrite: IsUnixReadWrite
  ExportPolicyRule.kerberos5ReadOnly: IsKerberos5ReadOnly
  ExportPolicyRule.kerberos5ReadWrite: IsKerberos5ReadWrite
  ExportPolicyRule.kerberos5iReadOnly: IsKerberos5iReadOnly
  ExportPolicyRule.kerberos5iReadWrite: IsKerberos5iReadWrite
  ExportPolicyRule.kerberos5pReadOnly: IsKerberos5pReadOnly
  ExportPolicyRule.kerberos5pReadWrite: IsKerberos5pReadWrite
  ExportPolicyRule.nfsv3: AllowNfsV3Protocol
  ExportPolicyRule.nfsv41: AllowNfsV41Protocol
  Volume.properties.fileSystemId: -|uuid
  Volume.properties.networkSiblingSetId: -|uuid
  Volume.properties.coolAccess: IsCoolAccessEnabled
  Volume.properties.keyVaultPrivateEndpointResourceId: -|arm-id
  Volume.properties.subnetId: -|arm-id
  Volume.properties.capacityPoolResourceId: -|arm-id
  Volume.properties.proximityPlacementGroup: ProximityPlacementGroupId|arm-id
  Volume.properties.snapshotDirectoryVisible: IsSnapshotDirectoryVisible
  Volume.properties.kerberosEnabled: IsKerberosEnabled
  Volume.properties.smbEncryption: IsSmbEncryptionEnabled
  Volume.properties.smbContinuouslyAvailable: IsSmbContinuouslyAvailable
  Volume.properties.ldapEnabled: IsLdapEnabled
  Volume.properties.encrypted: IsEncrypted
  Volume.properties.dataStoreResourceId: -|arm-id
  Volume.properties.originatingResourceId: -|arm-id
  VolumePatch.properties.snapshotDirectoryVisible: IsSnapshotDirectoryVisible
  VolumeGroupVolumeProperties.properties.proximityPlacementGroup: ProximityPlacementGroupId|arm-id
  VolumeGroupVolumeProperties.properties.coolAccess: IsCoolAccessEnabled
  VolumeGroupVolumeProperties.properties.snapshotDirectoryVisible: IsSnapshotDirectoryVisible
  VolumeGroupVolumeProperties.properties.kerberosEnabled: IsKerberosEnabled
  VolumeGroupVolumeProperties.properties.smbEncryption: IsSmbEncryptionEnabled
  VolumeGroupVolumeProperties.properties.smbContinuouslyAvailable: IsSmbContinuouslyAvailable
  VolumeGroupVolumeProperties.properties.ldapEnabled: IsLdapEnabled
  VolumeGroupVolumeProperties.properties.encrypted: IsEncrypted
  VolumeGroupVolumeProperties.properties.originatingResourceId: -|arm-id
  VolumeGroupVolumeProperties.id: -|arm-id
  VolumeGroupVolumeProperties.type: ResourceType|resource-type
  VolumeGroupVolumeProperties: NetAppVolumeGroupVolume
  SnapshotPolicy.properties.enabled: IsEnabled
  SnapshotPolicyPatch.properties.enabled: IsEnabled
  ActiveDirectory.aesEncryption: IsAesEncryptionEnabled
  ActiveDirectory.ldapSigning: IsLdapSigningEnabled
  ActiveDirectory.ldapOverTLS: IsLdapOverTlsEnabled
  BackupPolicyPatch.properties.enabled: IsEnabled
  VolumePatch.properties.coolAccess: IsCoolAccessEnabled
  ReplicationStatus.healthy: IsHealthy
  VolumeSnapshotProperties.snapshotPolicyId: -|arm-id
  PoolChangeRequest.newPoolResourceId: -|arm-id
  ReestablishReplicationRequest.sourceVolumeId: -|arm-id
  Replication.remoteVolumeResourceId: -|arm-id
  CapacityPool.properties.coolAccess: IsCoolAccessEnabled
  CapacityPoolPatch.properties.coolAccess: IsCoolAccessEnabled
  BackupPolicy.properties.backupPolicyId: -|arm-id
  VolumeBackups.policyEnabled: IsPolicyEnabled
  AuthorizeRequest.remoteVolumeResourceId: -|arm-id
  SubvolumeModel.properties.creationTimeStamp: CreatedOn
  SubvolumeModel.properties.accessedTimeStamp: AccessedOn
  SubvolumeModel.properties.modifiedTimeStamp: ModifiedOn
  SubvolumeModel.properties.changedTimeStamp: ChangedOn
  ReplicationObject.remoteVolumeResourceId: -|arm-id
  VolumeBackupProperties.backupPolicyId: -|arm-id
  VolumeBackupProperties.policyEnforced: IsPolicyEnforced
  VolumeBackupProperties.backupVaultId: -|arm-id
  VolumeGroupDetails: NetAppVolumeGroup
  QosType: CapacityPoolQosType
  ServiceLevel: NetAppFileServiceLevel
  ActiveDirectory: NetAppAccountActiveDirectory
  ActiveDirectoryStatus: NetAppAccountActiveDirectoryStatus
  BackupPolicy.properties.enabled: IsEnabled
  VolumeBackups: NetAppVolumeBackupDetail
  CheckAvailabilityResponse: NetAppCheckAvailabilityResult
  FilePathAvailabilityRequest: NetAppFilePathAvailabilityContent
  ResourceNameAvailabilityRequest: NetAppNameAvailabilityContent
  CheckNameResourceTypes: NetAppNameAvailabilityResourceType
  CheckQuotaNameResourceTypes: NetAppQuotaAvailabilityResourceType
  QuotaAvailabilityRequest: NetAppQuotaAvailabilityContent
  InAvailabilityReasonType: NetAppNameUnavailableReason
  Exclude: ExcludeReplicationsFilter
  Snapshot: NetAppVolumeSnapshot
  QuotaItem: NetAppSubscriptionQuotaItem
  SubvolumeInfo: NetAppSubvolumeInfo
  Replication: NetAppVolumeReplication
  BackupStatus: NetAppVolumeBackupStatus
  BackupStatus.healthy: IsHealthy
  RestoreStatus.healthy: IsHealthy
  AuthorizeRequest: NetAppVolumeAuthorizeReplicationContent
  BreakReplicationRequest: NetAppVolumeBreakReplicationContent
  DailySchedule: SnapshotPolicyDailySchedule
  EnableSubvolumes: EnableNetAppSubvolume
  ExportPolicyRule: NetAppVolumeExportPolicyRule
  HourlySchedule: SnapshotPolicyHourlySchedule
  MonthlySchedule: SnapshotPolicyMonthlySchedule
  WeeklySchedule: SnapshotPolicyWeeklySchedule
  LdapSearchScopeOpt: NetAppLdapSearchScopeConfiguration
  MountTargetProperties: NetAppVolumeMountTarget
  NetworkFeatures: NetAppNetworkFeature
  PlacementKeyValuePairs: NetAppVolumePlacementRule
  PoolChangeRequest: NetAppVolumePoolChangeContent
  ReestablishReplicationRequest: NetAppVolumeReestablishReplicationContent
  ReplicationStatus: NetAppVolumeReplicationStatus
  PoolPropertiesEncryptionType: CapacityPoolEncryptionType
  CapacityPool.properties.customThroughputMibps: CustomThroughputMibpsInt
  CapacityPoolPatch.properties.customThroughputMibps: CustomThroughputMibpsInt
  BackupStatus.relationshipStatus: VolumeBackupRelationshipStatus
  RestoreStatus.relationshipStatus: VolumeRestoreRelationshipStatus
  ReplicationStatus.relationshipStatus: VolumeReplicationRelationshipStatus
  NetAppProvisioningState: NetAppVolumeQuotaRuleProvisioningState
  VolumeQuotaRule.properties.provisioningState: VolumeQuotaRuleProvisioningState
  VolumeQuotaRulePatch.properties.provisioningState: VolumeQuotaRuleProvisioningState
  SecurityStyle: NetAppVolumeSecurityStyle
  SnapshotRestoreFiles: NetAppVolumeSnapshotRestoreFilesContent
  SubvolumeModel: NetAppSubvolumeMetadata
  QuotaType: NetAppVolumeQuotaType
  VolumePatchPropertiesDataProtection: NetAppVolumePatchDataProtection
  VolumePropertiesDataProtection: NetAppVolumeDataProtection
  VolumeRevert: NetAppVolumeRevertContent
  VolumeBackupProperties: NetAppVolumeBackupConfiguration
  VolumeGroupMetaData: NetAppVolumeGroupMetadata
  VolumeGroup: NetAppVolumeGroupResult
  RegionInfoAvailabilityZoneMappingsItem: AvailabilityZoneMapping
  VolumeRelocationProperties.readyToBeFinalized: IsReadyToBeFinalized
  VolumeRelocationProperties.relocationRequested: IsRelocationRequested
  BreakFileLocksRequest.clientIp: -|ip-address
  BreakFileLocksRequest: NetAppVolumeBreakFileLocksContent
  BackupRestoreFiles.destinationVolumeId: -|arm-id
  BackupRestoreFiles: NetAppVolumeBackupBackupRestoreFilesContent
  VolumeRelocationProperties: NetAppVolumeRelocationProperties
  FileAccessLogs: NetAppFileAccessLog
  GetGroupIdListForLdapUserResponse: GetGroupIdListForLdapUserResult
  BackupsMigrationRequest: BackupsMigrationContent
  Backup.properties.volumeResourceId: -|arm-id
  Backup.properties.backupPolicyResourceId: BackupPolicyArmResourceId
  KeyVaultProperties.keyVaultResourceId: keyVaultArmResourceId
  ClusterPeerCommandResponse: ClusterPeerCommandResult
  SvmPeerCommandResponse: SvmPeerCommandResult
  Volume.properties.snapshotId: -|string
  VolumeRevert.snapshotId: -|string
  Volume.properties.backupId: -|string
  BackupsMigrationRequest.backupVaultId: -|string
  ListQuotaReportResponse: NetAppVolumeQuotaReportListResult
  QuotaReport: NetAppVolumeQuotaReport
  GetKeyVaultStatusResponse: NetAppKeyVaultStatusResult
  UsageResult : NetAppUsageResult
  UsageName: NetAppUsageName
  ElasticResourceAvailabilityStatus: NetAppElasticResourceAvailabilityState
  CheckElasticVolumeFilePathAvailabilityRequest: ElasticVolumeFilePathAvailabilityContent
  CheckElasticResourceAvailabilityResponse: ElasticResourceAvailabilityResult
  CheckElasticResourceAvailabilityStatus: ElasticResourceAvailabilityStatus
  CheckElasticResourceAvailabilityReason: ElasticResourceAvailabilityReason
  BreakthroughMode: NetAppBreakthroughMode
  CertificateAkvDetails: CertificateKeyVaultDetails
  CifsChangeNotifyState: NetAppCifsChangeNotifyState
  CredentialsAkvDetails: CredentialsKeyVaultDetails
  CredentialsStatus: NetAppCredentialsStatus
  DayOfWeek: NetAppDayOfWeek
  EnableWriteBackState: NetAppEnableWriteBackState
  EncryptionState: NetAppEncryptionState
  EntraIdAkvConfig: EntraIdKeyVaultConfig
  EntraIdAkvConfigPatch: EntraIdKeyVaultConfigPatch
  ExternalReplicationSetupStatus: NetAppExternalReplicationSetupStatus
  FileSystemUser: NetAppFileSystemUser
  GlobalFileLockingState: NetAppGlobalFileLockingState
  KerberosState: NetAppKerberosState
  LargeVolumeType: NetAppLargeVolumeType
  LdapServerType: NetAppLdapServerType
  LdapState: NetAppLdapState
  NfsUser: NetAppNfsUser
  OnCertificateConflictAction: NetAppOnCertificateConflictAction
  OriginClusterInformation: NetAppOriginClusterInformation
  PeeringPassphrases: NetAppPeeringPassphrases
  PolicyStatus: NetAppPolicyStatus
  SmbEncryptionState: NetAppSmbEncryptionState
  SmbSettings: NetAppSmbSettings
  SnapshotDirectoryVisibility: NetAppSnapshotDirectoryVisibility
  SnapshotUsage: NetAppSnapshotUsage
  VolumeSize: NetAppBackupVolumeSize
  BucketGenerateCredentials.keyPairExpiry: KeyPairExpiresOn
  ChangeZoneRequest: ElasticCapacityPoolChangeZoneContent
  ElasticProtocolType: NetAppElasticProtocolType
  ElasticProtocolType.NFSv3: Nfsv3
  ElasticProtocolType.NFSv4: Nfsv4
  ElasticProtocolType.SMB: Smb
  ProtocolTypes: NetAppProtocolType
  ProtocolTypes.NFSv3: Nfsv3
  ProtocolTypes.NFSv4: Nfsv4
  ProtocolTypes.SMB: Smb
  SecretPasswordUpdate: NetAppSecretPasswordPatch
  LdapConfiguration.ldapOverTLS: IsLdapOverTlsEnabled
  LdapConfigurationPatch.ldapOverTLS: IsLdapOverTlsEnabled

models-to-treat-empty-string-as-null:
- VolumeSnapshotProperties

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/volumeGroups/{volumeGroupName}

directive:
  # remove this operation because the Snapshots_Update defines an empty object-
  - remove-operation: Snapshots_Update

```
