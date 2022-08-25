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

rename-mapping:
  Backup: NetAppBackup
  BackupType: NetAppBackupType
  BackupPolicy: NetAppBackupPolicy
  Volume: NetAppVolume
  VolumeGroupDetails: NetAppVolumeGroup
  VolumeQuotaRule: NetAppVolumeQuotaRule
  CapacityPool.properties.coolAccess: IsCoolAccessEnabled
  QosType: CapacityPoolQosType
  ServiceLevel: NetAppFileServiceLevel
  ActiveDirectory: NetAppAccountActiveDirectory
  ActiveDirectoryStatus: NetAppAccountActiveDirectoryStatus
  Vault: NetAppVault
  BackupPolicy.properties.backupPolicyId: -|arm-id
  BackupPolicy.properties.enabled: IsEnabled
  VolumeBackups: NetAppVolumeBackupDetail
  VolumeBackups.policyEnabled: IsPolicyEnabled
  CheckAvailabilityResponse: NetAppCheckAvailabilityResult
  FilePathAvailabilityRequest: NetAppFilePathAvailabilityContent
  ResourceNameAvailabilityRequest: NetAppNameAvailabilityContent
  CheckNameResourceTypes: NetAppNameAvailabilityResourceType
  CheckQuotaNameResourceTypes: NetAppQuotaAvailabilityResourceType
  QuotaAvailabilityRequest: NetAppQuotaAvailabilityContent
  InAvailabilityReasonType: NetAppNameUnavailableReason
  Snapshot: NetAppVolumeSnapshot
  SubscriptionQuotaItem: NetAppSubscriptionQuotaItem
  SubvolumeInfo: NetAppSubvolume
  Replication: NetAppVolumeReplication
  BackupStatus: NetAppVolumeBackupStatus
  RestoreStatus: NetAppRestoreStatus
  ApplicationType: NetAppApplicationType
  AuthorizeRequest: NetAppVolumeAuthorizeReplicationContent
  AuthorizeRequest.remoteVolumeResourceId: -|arm-id
  AvsDataStore: NetAppAvsDataStore
  BreakReplicationRequest: NetAppVolumeBreakReplicationContent
  ChownMode: NetAppChownMode
  DailySchedule: SnapshotPolicyDailySchedule
  EnableSubvolumes: EnableNetAppSubvolume
  EncryptionKeySource: NetAppEncryptionKeySource
  EncryptionType: CapacityPoolEncryptionType
  ExportPolicyRule: NetAppVolumeExportPolicyRule
  HourlySchedule: SnapshotPolicyHourlySchedule
  MonthlySchedule: SnapshotPolicyMonthlySchedule
  WeeklySchedule: SnapshotPolicyWeeklySchedule
  LdapSearchScopeOpt: NetAppLdapSearchScopeConfiguration
  MirrorState: NetAppMirrorState
  RelationshipStatus: NetAppRelationshipStatus
  MountTargetProperties: NetAppVolumeMountTarget
  NetworkFeatures: NetAppNetworkFeature
  PlacementKeyValuePairs: NetAppVolumePlacementRule
  PoolChangeRequest: NetAppVolumePoolChangeContent
  ProvisioningState: NetAppProvisioningState
  ReestablishReplicationRequest: NetAppVolumeReestablishReplicationContent
  ReplicationStatus: NetAppVolumeReplicationStatus
  SecurityStyle: NetAppVolumeSecurityStyle
  SnapshotRestoreFiles: NetAppVolumeSnapshotRestoreFilesContent
  SubvolumeModel: NetAppSubvolumeMetadata
  SubvolumeModel.properties.creationTimeStamp: CreatedOn
  SubvolumeModel.properties.accessedTimeStamp: AccessedOn
  SubvolumeModel.properties.modifiedTimeStamp: ModifiedOn
  SubvolumeModel.properties.changedTimeStamp: ChangedOn
  Type: NetAppVolumeQuotaType
  VolumePatchPropertiesDataProtection: NetAppVolumePatchDataProtection
  VolumePropertiesDataProtection: NetAppVolumeDataProtection
  VolumeRevert: NetAppVolumeRevertContent
  VolumeRevert.snapshotId: -|arm-id
  ReplicationObject: NetAppReplicationObject
  ReplicationSchedule: NetAppReplicationSchedule
  VolumeBackupProperties: NetAppVolumeBackupConfiguration
  VolumeBackupProperties.backupPolicyId: -|arm-id
  VolumeBackupProperties.policyEnforced: IsPolicyEnforced
  VolumeBackupProperties.vaultId: -|arm-id
  VolumeBackupProperties.backupEnabled: IsBackupEnabled
  VolumeGroupMetaData: NetAppVolumeGroupMetadata
  VolumeStorageToNetworkProximity: NetAppVolumeStorageToNetworkProximity

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
