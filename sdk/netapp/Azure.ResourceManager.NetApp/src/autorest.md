# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NetApp
namespace: Azure.ResourceManager.NetApp
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/netapp/resource-manager/readme.md
tag: package-netapp-2022-03-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
  SAP: Sap
  TLS: Tls
  ZRS: Zrs

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}: NetAppAccountBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}: NetAppVolumeBackup

override-operation-name:
  NetAppResource_CheckFilePathAvailability: CheckNetAppFilePathAvailability
  NetAppResource_CheckNameAvailability: CheckNetAppNameAvailability
  NetAppResource_CheckQuotaAvailability: CheckNetAppQuotaAvailability
  NetAppResourceQuotaLimits_Get: GetNetAppQuotaLimit
  NetAppResourceQuotaLimits_List: GetNetAppQuotaLimits
  Volumes_ReplicationStatus: GetReplicationStatus
  Backups_GetStatus: GetBackupStatus
  Backups_GetVolumeRestoreStatus: GetRestoreStatus

request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits/{quotaLimitName}

prepend-rp-prefix:
  - Backup
  - BackupType
  - BackupPolicy
  - EndpointType
  - Volume
  - VolumeQuotaRule
  - Vault
  - RestoreStatus
  - ApplicationType
  - AvsDataStore
  - ChownMode
  - EncryptionKeySource
  - MirrorState
  - RelationshipStatus
  - ProvisioningState
  - ReplicationObject
  - ReplicationSchedule
  - VolumeStorageToNetworkProximity

rename-mapping:
  CapacityPool.properties.poolId: -|uuid
  Backup.properties.backupId: -|uuid
  Volume.properties.backupId: -|uuid
  BackupPatch.properties.backupId: -|uuid
  Volume.properties.snapshotId: -|uuid
  Volume.properties.fileSystemId: -|uuid
  Snapshot.properties.snapshotId: -|uuid
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
  Volume.properties.coolAccess: IsCoolAccessEnabled
  Volume.properties.keyVaultPrivateEndpointResourceId: -|arm-id
  Volume.properties.subnetId: -|arm-id
  Volume.properties.capacityPoolResourceId: -|arm-id
  Volume.properties.snapshotDirectoryVisible: IsSnapshotDirectoryVisible
  Volume.properties.kerberosEnabled: IsKerberosEnabled
  Volume.properties.smbEncryption: IsSmbEncryptionEnabled
  Volume.properties.smbContinuouslyAvailable: IsSmbContinuouslyAvailable
  Volume.properties.ldapEnabled: IsLdapEnabled
  Volume.properties.encrypted: IsEncrypted
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
  VolumeRevert.snapshotId: -|arm-id
  ReplicationObject.remoteVolumeResourceId: -|arm-id
  VolumeBackupProperties.backupPolicyId: -|arm-id
  VolumeBackupProperties.policyEnforced: IsPolicyEnforced
  VolumeBackupProperties.vaultId: -|arm-id
  VolumeBackupProperties.backupEnabled: IsBackupEnabled
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
  Snapshot: NetAppVolumeSnapshot
  SubscriptionQuotaItem: NetAppSubscriptionQuotaItem
  SubvolumeInfo: NetAppSubvolumeInfo
  Replication: NetAppVolumeReplication
  BackupStatus: NetAppVolumeBackupStatus
  BackupStatus.healthy: IsHealthy
  RestoreStatus.healthy: IsHealthy
  AuthorizeRequest: NetAppVolumeAuthorizeReplicationContent
  BreakReplicationRequest: NetAppVolumeBreakReplicationContent
  DailySchedule: SnapshotPolicyDailySchedule
  EnableSubvolumes: EnableNetAppSubvolume
  EncryptionType: CapacityPoolEncryptionType
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
  SecurityStyle: NetAppVolumeSecurityStyle
  SnapshotRestoreFiles: NetAppVolumeSnapshotRestoreFilesContent
  SubvolumeModel: NetAppSubvolumeMetadata
  Type: NetAppVolumeQuotaType
  VolumePatchPropertiesDataProtection: NetAppVolumePatchDataProtection
  VolumePropertiesDataProtection: NetAppVolumeDataProtection
  VolumeRevert: NetAppVolumeRevertContent
  VolumeBackupProperties: NetAppVolumeBackupConfiguration
  VolumeGroupMetaData: NetAppVolumeGroupMetadata

directive:
# remove this operation because the Snapshots_Update defines an empty object
  - remove-operation: Snapshots_Update
# the list method of volumeGroup `VolumeGroups_ListByNetAppAccount` is returning a model `VolumeGroup` which is very similar to `VolumeGroupDetails` (with one property missing)
# but this breaks our convention about List method. Here we override the return schema of list method
  - from: swagger-document
    where: $.definitions.volumeGroupList.properties.value.items["$ref"]
    transform: return "#/definitions/volumeGroupDetails"
# rename the volumeGroup to something else to avoid model name collision because we are using VolumeGroupDetails everywhere in the SDK and it is renamed to VolumeGroup
# this type will never be generated.
  - from: swagger-document
    where: $.definitions.volumeGroup
    transform: $["x-ms-client-name"] = "DummyVolumeGroup"
# we have yet another two identical (almost) models volumeGroupVolumeProperties and VolumeGroupDetails. Here we take VolumeGroupDetails because it contains more
  - from: swagger-document
    where: $.definitions.volumeGroupProperties.properties.volumes.items["$ref"]
    transform: return "#/definitions/volumeGroupDetails"
```
