# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RecoveryServicesBackup
namespace: Azure.ResourceManager.RecoveryServicesBackup
# tag: package-2025-02
require: https://github.com/Azure/azure-rest-api-specs/blob/8960d93f363955d7dc079a90248e6addd30afd31/specification/recoveryservicesbackup/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

models-to-treat-empty-string-as-null:
  - IaasComputeVmProtectedItem

rename-mapping:
  Job: BackupGenericJob
  JobResource: BackupJob
  JobResourceList: BackupJobListResult
  BackupEngineBase: BackupGenericEngine
  BackupEngineBaseResource: BackupEngine
  BackupResourceConfig: BackupResourceConfigProperties
  BackupResourceConfigResource: BackupResourceConfig
  BackupResourceEncryptionConfigExtended: BackupResourceEncryptionConfigExtendedProperties
  BackupResourceEncryptionConfigExtendedResource: BackupResourceEncryptionConfigExtended
  BackupResourceVaultConfig: BackupResourceVaultConfigProperties
  BackupResourceVaultConfigResource: BackupResourceVaultConfig
  PrivateEndpointConnection: BackupPrivateEndpointConnectionProperties
  PrivateEndpointConnectionResource: BackupPrivateEndpointConnection
  ProtectedItem: BackupGenericProtectedItem
  ProtectedItemResource: BackupProtectedItem
  ProtectionContainer: BackupGenericProtectionContainer
  ProtectionContainerResource: BackupProtectionContainer
  ProtectionIntent: BackupGenericProtectionIntent
  ProtectionIntentResource: BackupProtectionIntent
  ProtectionPolicy: BackupGenericProtectionPolicy
  ProtectionPolicyResource: BackupProtectionPolicy
  RecoveryPoint: BackupGenericRecoveryPoint
  RecoveryPointResource: BackupRecoveryPoint
  ResourceGuardProxyBase: ResourceGuardProxyProperties
  ResourceGuardProxyBaseResource: ResourceGuardProxy
  AzureBackupGoalFeatureSupportRequest: BackupGoalFeatureSupportContent
  AzureBackupServerContainer: BackupServerContainer
  AzureBackupServerEngine: BackupServerEngine
  AzureFileShareBackupRequest: FileShareBackupContent
  AzureFileShareProtectableItem: FileShareProtectableItem
  AzureFileshareProtectedItem: FileshareProtectedItem
  AzureFileshareProtectedItemExtendedInfo: FileshareProtectedItemExtendedInfo
  AzureFileShareProtectionPolicy: FileShareProtectionPolicy
  AzureFileShareProvisionILRRequest: FileShareProvisionIlrContent
  AzureFileShareRecoveryPoint: FileShareRecoveryPoint
  AzureFileShareRestoreRequest: FileShareRestoreContent
  AzureFileShareType: BackupFileShareType
  AzureIaaSClassicComputeVMContainer: IaasClassicComputeVmContainer
  AzureIaaSClassicComputeVMProtectableItem: IaasClassicComputeVmProtectableItem
  AzureIaaSClassicComputeVMProtectedItem: IaasClassicComputeVmProtectedItem
  AzureIaaSComputeVMContainer: IaasComputeVmContainer
  AzureIaaSComputeVMProtectableItem: IaasComputeVmProtectableItem
  AzureIaaSComputeVMProtectedItem: IaasComputeVmProtectedItem
  AzureIaaSVMErrorInfo: IaasVmErrorInfo
  AzureIaaSVMHealthDetails: IaasVmHealthDetails
  AzureIaaSVMJob: IaasVmBackupJob
  AzureIaaSVMJobExtendedInfo: IaasVmBackupJobExtendedInfo
  AzureIaaSVMJobTaskDetails: IaasVmBackupJobTaskDetails
  AzureIaaSVMJobV2: IaasVmBackupJobV2
  AzureIaaSVMProtectedItem: IaasVmProtectedItem
  AzureIaaSVMProtectedItemExtendedInfo: IaasVmProtectedItemExtendedInfo
  AzureIaaSVMProtectionPolicy: IaasVmProtectionPolicy
  AzureRecoveryServiceVaultProtectionIntent: RecoveryServiceVaultProtectionIntent
  AzureResourceProtectionIntent: ResourceProtectionIntent
  AzureSqlagWorkloadContainerProtectionContainer: SqlAvailabilityGroupWorkloadProtectionContainer
  AzureSqlContainer: SqlContainer
  AzureSqlProtectedItem: SqlProtectedItem
  AzureSqlProtectedItemExtendedInfo: SqlProtectedItemExtendedInfo
  AzureSqlProtectionPolicy: SqlProtectionPolicy
  AzureStorageContainer: StorageContainer
  AzureStorageErrorInfo: StorageErrorInfo
  AzureStorageJob: StorageBackupJob
  AzureStorageJobExtendedInfo: StorageBackupJobExtendedInfo
  AzureStorageJobTaskDetails: StorageBackupJobTaskDetails
  AzureStorageProtectableContainer: StorageProtectableContainer
  AzureVMAppContainerProtectableContainer: VmAppContainerProtectableContainer
  AzureVMAppContainerProtectionContainer: VmAppContainerProtectionContainer
  AzureVMResourceFeatureSupportRequest: VmResourceFeatureSupportContent
  AzureVMResourceFeatureSupportResponse: VmResourceFeatureSupportResult
  AzureVmWorkloadItem: VmWorkloadItem
  AzureVmWorkloadProtectableItem: VmWorkloadProtectableItem
  AzureVmWorkloadProtectedItem: VmWorkloadProtectedItem
  AzureVmWorkloadProtectedItemExtendedInfo: VmWorkloadProtectedItemExtendedInfo
  AzureVmWorkloadProtectionPolicy: VmWorkloadProtectionPolicy
  AzureVmWorkloadSAPAseDatabaseProtectableItem: VmWorkloadSapAseDatabaseProtectableItem
  AzureVmWorkloadSAPAseDatabaseProtectedItem: VmWorkloadSapAseDatabaseProtectedItem
  AzureVmWorkloadSAPAseDatabaseWorkloadItem: VmWorkloadSapAseDatabaseWorkloadItem
  AzureVmWorkloadSAPAseSystemProtectableItem: VmWorkloadSapAseSystemProtectableItem
  AzureVmWorkloadSAPAseSystemWorkloadItem: VmWorkloadSapAseSystemWorkloadItem
  AzureVmWorkloadSAPHanaDatabaseProtectableItem: VmWorkloadSapHanaDatabaseProtectableItem
  AzureVmWorkloadSAPHanaDatabaseProtectedItem: VmWorkloadSapHanaDatabaseProtectedItem
  AzureVmWorkloadSAPHanaDatabaseWorkloadItem: VmWorkloadSapHanaDatabaseWorkloadItem
  AzureVmWorkloadSAPHanaDBInstance: VmWorkloadSapHanaDBInstance
  AzureVmWorkloadSAPHanaDBInstanceProtectedItem: VmWorkloadSapHanaDBInstanceProtectedItem
  AzureVmWorkloadSAPHanaHSRProtectableItem: VmWorkloadSapHanaHsrProtectableItem
  AzureVmWorkloadSAPHanaSystemProtectableItem: VmWorkloadSapHanaSystemProtectableItem
  AzureVmWorkloadSAPHanaSystemWorkloadItem: VmWorkloadSapHanaSystemWorkloadItem
  AzureVmWorkloadSQLAvailabilityGroupProtectableItem: VmWorkloadSqlAvailabilityGroupProtectableItem
  AzureVmWorkloadSQLDatabaseProtectableItem: VmWorkloadSqlDatabaseProtectableItem
  AzureVmWorkloadSQLDatabaseProtectedItem: VmWorkloadSqlDatabaseProtectedItem
  AzureVmWorkloadSQLDatabaseWorkloadItem: VmWorkloadSqlDatabaseWorkloadItem
  AzureVmWorkloadSQLInstanceProtectableItem: VmWorkloadSqlInstanceProtectableItem
  AzureVmWorkloadSQLInstanceWorkloadItem: VmWorkloadSqlInstanceWorkloadItem
  AzureWorkloadAutoProtectionIntent: WorkloadAutoProtectionIntent
  AzureWorkloadBackupRequest: WorkloadBackupContent
  AzureWorkloadContainer: WorkloadContainer
  AzureWorkloadContainerAutoProtectionIntent: WorkloadContainerAutoProtectionIntent
  AzureWorkloadContainerExtendedInfo: WorkloadContainerExtendedInfo
  AzureWorkloadErrorInfo: WorkloadErrorInfo
  AzureWorkloadJob: WorkloadBackupJob
  AzureWorkloadJobExtendedInfo: WorkloadBackupJobExtendedInfo
  AzureWorkloadJobTaskDetails: WorkloadBackupJobTaskDetails
  AzureWorkloadPointInTimeRecoveryPoint: WorkloadPointInTimeRecoveryPoint
  AzureWorkloadPointInTimeRestoreRequest: WorkloadPointInTimeRestoreContent
  AzureWorkloadSAPHanaPointInTimeRecoveryPoint: WorkloadSapHanaPointInTimeRecoveryPoint
  AzureWorkloadRecoveryPoint: WorkloadRecoveryPoint
  AzureWorkloadRestoreRequest: WorkloadRestoreContent
  AzureWorkloadSAPHanaPointInTimeRestoreRequest: WorkloadSapHanaPointInTimeRestoreContent
  AzureWorkloadSAPHanaPointInTimeRestoreWithRehydrateRequest: WorkloadSapHanaPointInTimeRestoreWithRehydrateContent
  AzureWorkloadSAPHanaRecoveryPoint: WorkloadSapHanaRecoveryPoint
  AzureWorkloadSAPHanaRestoreRequest: WorkloadSapHanaRestoreContent
  AzureWorkloadSAPHanaRestoreWithRehydrateRequest: WorkloadSapHanaRestoreWithRehydrateContent
  AzureWorkloadSQLAutoProtectionIntent: WorkloadSqlAutoProtectionIntent
  AzureWorkloadSQLPointInTimeRecoveryPoint: WorkloadSqlPointInTimeRecoveryPoint
  AzureWorkloadSQLPointInTimeRestoreRequest: WorkloadSqlPointInTimeRestoreContent
  AzureWorkloadSQLPointInTimeRestoreWithRehydrateRequest: WorkloadSqlPointInTimeRestoreWithRehydrateContent
  AzureWorkloadSQLRecoveryPoint: WorkloadSqlRecoveryPoint
  AzureWorkloadSQLRecoveryPointExtendedInfo: WorkloadSqlRecoveryPointExtendedInfo
  AzureWorkloadSQLRestoreRequest: WorkloadSqlRestoreContent
  AzureWorkloadSQLRestoreWithRehydrateRequest: WorkloadSqlRestoreWithRehydrateContent
  AzureWorkloadSAPAsePointInTimeRecoveryPoint: WorkloadSapAsePointInTimeRecoveryPoint
  AzureWorkloadSAPAsePointInTimeRestoreRequest: WorkloadSapAsePointInTimeRestoreContent
  AzureWorkloadSAPAseRecoveryPoint: WorkloadSapAseRecoveryPoint
  AzureWorkloadSAPAseRestoreRequest: WorkloadSapAseRestoreContent
  BackupRequest: BackupContent
  BackupRequestResource: TriggerBackupContent
  BackupStatusResponse: BackupStatusResult
  CreateMode: BackupCreateMode
  DataSourceType: BackupDataSourceType
  DailySchedule: BackupDailySchedule
  Day: BackupDay
  DayOfWeek: BackupDayOfWeek
  DedupState: VaultDedupState
  EncryptionAtRestType: BackupEncryptionAtRestType
  EncryptionDetails: VmEncryptionDetails
  ExtendedProperties: IaasVmBackupExtendedProperties
  FabricName: BackupFabricName
  FetchTieringCostInfoForRehydrationRequest: FetchTieringCostInfoForRehydrationContent
  FetchTieringCostSavingsInfoForPolicyRequest: FetchTieringCostSavingsInfoForPolicyContent
  FetchTieringCostSavingsInfoForProtectedItemRequest: FetchTieringCostSavingsInfoForProtectedItemContent
  FetchTieringCostSavingsInfoForVaultRequest: FetchTieringCostSavingsInfoForVaultContent
  HealthStatus: IaasVmProtectedItemHealthStatus
  ProtectedItemHealthStatus: VmWorkloadProtectedItemHealthStatus
  HourlySchedule: BackupHourlySchedule
  ILRRequest: IlrContent
  ILRRequestResource: ProvisionIlrConnectionContent
  ListRecoveryPointsRecommendedForMoveRequest: RecoveryPointsRecommendedForMoveContent
  MonthOfYear: BackupMonthOfYear
  NameInfo: BackupNameInfo
  OperationType: WorkloadOperationType
  OverwriteOptions: RestoreOverwriteOptions
  PolicyType: SubProtectionPolicyType
  PreValidateEnableBackupResponse: PreValidateEnableBackupResult
  Settings: BackupCommonSettings
  SupportStatus: VmResourceFeatureSupportStatus
  StorageType: BackupStorageType
  UnlockDeleteResponse: UnlockDeleteResult
  UsagesUnit: BackupUsagesUnit
  ValidationStatus: BackupValidationStatus
  WeekOfMonth: BackupWeekOfMonth
  WeeklySchedule: BackupWeeklySchedule
  WorkloadType: BackupWorkloadType
  XcoolState: VaultXcoolState
  BackupResourceConfig.crossRegionRestoreFlag: EnableCrossRegionRestore
  DpmContainer.upgradeAvailable: IsUpgradeAvailable
  DPMProtectedItemExtendedInfo.protected: IsProtected
  AzureIaaSVMProtectedItemExtendedInfo.policyInconsistent: IsPolicyInconsistent
  IaasVMRestoreRequest.createNewCloudService: DoesCreateNewCloudService
  IaasVMRestoreRequest.restoreWithManagedDisks: DoesRestoreWithManagedDisks
  EncryptionDetails.encryptionEnabled: IsEncryptionEnabled
  AzureVmWorkloadProtectionPolicy.makePolicyConsistent: DoesMakePolicyConsistent
  TriggerDataMoveRequest.pauseGC: DoesPauseGC
  ProtectedItem.sourceResourceId: -|arm-id
  ProtectedItem.policyId: -|arm-id
  ProtectedItem.lastRecoveryPoint: LastRecoverOn
  ProtectionIntent.sourceResourceId: -|arm-id
  ProtectionIntent.itemId: -|arm-id
  ProtectionIntent.policyId: -|arm-id
  BackupStatusRequest.resourceId: -|arm-id
  BackupStatusResponse.vaultId: -|arm-id
  BEKDetails.secretVaultId: -|arm-id
  ContainerIdentityInfo.aadTenantId: -|uuid
  AzureFileShareBackupRequest.recoveryPointExpiryTimeInUTC: RecoveryPointExpireOn
  AzureFileShareRestoreRequest.sourceResourceId: -|arm-id
  IaasVMBackupRequest.recoveryPointExpiryTimeInUTC: RecoveryPointExpireOn
  IaaSVMContainer.virtualMachineId: -|arm-id
  IaasVmilrRegistrationRequest: IaasVmIlrRegistrationContent
  IaasVmilrRegistrationRequest.virtualMachineId: -|arm-id
  IaaSVMProtectableItem.virtualMachineId: -|arm-id
  AzureIaaSVMProtectedItem.virtualMachineId: -|arm-id
  IaasVMRestoreRequest.sourceResourceId: -|arm-id
  IaasVMRestoreRequest.targetVirtualMachineId: -|arm-id
  IaasVMRestoreRequest.targetResourceGroupId: -|arm-id
  IaasVMRestoreRequest.storageAccountId: -|arm-id
  IaasVMRestoreRequest.virtualNetworkId: -|arm-id
  IaasVMRestoreRequest.subnetId: -|arm-id
  IaasVMRestoreRequest.targetDomainNameId: -|arm-id
  IaasVMRestoreRequest.region: -|azure-location
  IdentityBasedRestoreDetails.targetStorageAccountId: -|arm-id
  IdentityInfo.managedIdentityResourceId: -|arm-id
  KEKDetails.keyVaultId: -|arm-id
  PrepareDataMoveRequest.targetResourceId: -|arm-id
  PreValidateEnableBackupRequest.resourceId: -|arm-id
  PreValidateEnableBackupRequest.vaultId: -|arm-id
  ResourceGuardProxyBase.resourceGuardResourceId: -|arm-id
  ResourceGuardProxyBase.lastUpdatedTime: LastUpdatedOn|datetime
  AzureStorageContainer.sourceResourceId: -|arm-id
  TargetAFSRestoreInfo.targetResourceId: -|arm-id
  TriggerDataMoveRequest.sourceResourceId: -|arm-id
  TriggerDataMoveRequest.sourceContainerArmIds: -|arm-id
  TriggerDataMoveRequest.sourceRegion: -|azure-location
  EncryptionDetails.kekVaultId: -|arm-id
  EncryptionDetails.secretKeyVaultId: -|arm-id
  SupportStatus.DefaultOFF: DefaultOff
  SupportStatus.DefaultON: DefaultOn
  AzureWorkloadBackupRequest.recoveryPointExpiryTimeInUTC: RecoveryPointExpireOn
  AzureWorkloadContainer.sourceResourceId: -|arm-id
  AzureWorkloadRecoveryPoint.recoveryPointTimeInUTC: RecoveryPointCreatedOn
  AzureWorkloadRestoreRequest.sourceResourceId: -|arm-id
  AzureWorkloadRestoreRequest.targetVirtualMachineId: -|arm-id
  AzureWorkloadSQLRecoveryPointExtendedInfo.dataDirectoryTimeInUTC: DataDirectoryInfoCapturedOn
  ProtectedItem.deferredDeleteTimeInUTC: DeferredDeletedOn
  AzureFileShareProvisionILRRequest.sourceResourceId: -|arm-id
  PrepareDataMoveRequest.sourceContainerArmIds: -|arm-id
  UnlockDeleteResponse.unlockDeleteExpiryTime: UnlockDeleteExpireOn|datetime
  PrepareDataMoveRequest.targetRegion: -|azure-location
  BackupResourceEncryptionConfigExtended.userAssignedIdentity: -|arm-id
  RestoreRequest: RestoreContent
  RestoreRequestResource: TriggerRestoreContent
  RecoveryPointProperties.expiryTime: ExpireOn|datetime
  DataSourceType.SQLDataBase: SqlDatabase
  BackupItemType.SQLDataBase: SqlDatabase
  WorkloadType.SQLDataBase: SqlDatabase
  WorkloadItemType.SQLDataBase: SqlDatabase
  IaasVMBackupRequest: IaasVmBackupContent
  IaasVMRestoreRequest: IaasVmRestoreContent
  IaasVMRestoreWithRehydrationRequest: IaasVmRestoreWithRehydrationContent
  ResourceGuardOperationDetail.defaultResourceRequest: DefaultResourceId|arm-id
  InquiryInfo: WorkloadContainerInquiryInfo
  ProvisioningState: BackupPrivateEndpointConnectionProvisioningState
  ProtectionState: BackupProtectionState
  ProtectionStatus: BackupProtectionStatus
  AzureFileshareProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  AzureIaaSVMProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  AzureSqlProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  AzureVmWorkloadProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  DPMProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  DPMProtectedItemExtendedInfo.onPremiseOldestRecoveryPoint: OnPremiseOldestRecoverOn
  DPMProtectedItemExtendedInfo.onPremiseLatestRecoveryPoint: OnPremiseLatestRecoverOn
  MabFileFolderProtectedItemExtendedInfo.oldestRecoveryPoint: OldestRecoverOn
  AzureIaaSVMProtectionPolicy.instantRpRetentionRangeInDays: InstantRPRetentionRangeInDays
  AzureVmWorkloadItem.subinquireditemcount: SubInquiredItemCount
  AzureVmWorkloadProtectableItem.subinquireditemcount: SubInquiredItemCount
  AzureVmWorkloadProtectableItem.subprotectableitemcount: SubProtectableItemCount
  AzureVmWorkloadProtectableItem.prebackupvalidation: PreBackupValidation
  StorageTypeState: BackupStorageTypeState
  RetentionPolicy: BackupRetentionPolicy
  SchedulePolicy: BackupSchedulePolicy
  TieringPolicy: BackupTieringPolicy
  CopyOptions: FileShareCopyOption
  RecoveryType: FileShareRecoveryType
  RestoreRequestType: FileShareRestoreType
  SecurityPinBase: SecurityPinContent
  VaultJob: VaultBackupJob
  VaultJobErrorInfo: VaultBackupJobErrorInfo
  VaultJobExtendedInfo: VaultBackupJobExtendedInfo
  MabJob: MabBackupJob
  MabJobExtendedInfo: MabBackupJobExtendedInfo
  MabJobTaskDetails: MabBackupJobTaskDetails
  DpmJob: DpmBackupJob
  DpmJobExtendedInfo: DpmBackupJobExtendedInfo
  DpmJobTaskDetails: DpmBackupJobTaskDetails
  IdentityInfo: BackupIdentityInfo
  SecuredVMDetails.securedVMOsDiskEncryptionSetId: -|arm-id
  SnapshotRestoreParameters: SnapshotRestoreContent
  TargetDiskNetworkAccessOption: BackupTargetDiskNetworkAccessOption
  TargetDiskNetworkAccessSettings: BackupTargetDiskNetworkAccessSettings
  TargetDiskNetworkAccessSettings.targetDiskAccessId: -|arm-id
  AzureIaaSVMJobExtendedInfo.estimatedRemainingDuration: estimatedRemainingDurationValue
  ClientDiscoveryForLogSpecification.blobDuration: -|duration
  TieringPolicy.duration: durationValue
  RecoveryPointRehydrationInfo.rehydrationRetentionDuration: -|duration
  BMSBackupSummariesQueryObject.type: BackupManagementType

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'SubscriptionIdParameter': 'object'

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
  ETag: ETag|eTag
  IaaSVM: IaasVm
  Iaasvm: IaasVm
  Sqldb: SqlDB
  SQLAG: SqlAvailabilityGroup
  Sqlag: SqlAvailabilityGroup
  MAB: Mab
  DPM: Dpm
  Issqlcompression: IsSqlCompression
  ILR: Ilr
  SQL: Sql
  BEK: Bek
  KEK: Kek
  KPI: Kpi
  AFS: Afs
  SAP: Sap
  SqlDb: SqlDB
  PIN: Pin

override-operation-name:
  BackupStatus_Get: GetBackupStatus
  DeletedProtectionContainers_List: GetSoftDeletedProtectionContainers
  RecoveryPointsRecommendedForMove_List: GetRecoveryPointsRecommendedForMove
  BackupProtectionIntent_List: GetBackupProtectionIntents
  BackupProtectedItems_List: GetBackupProtectedItems
  BackupProtectionContainers_List: GetBackupProtectionContainers
  SecurityPINs_Get: GetSecurityPin
  BMSPrepareDataMove: PrepareDataMove
  BMSTriggerDataMove: TriggerDataMove

list-exception:
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/backupProtectionIntent/{intentObjectName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/privateEndpointConnections/{privateEndpointConnectionName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupconfig/vaultconfig
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig

directive:
  - remove-operation: Operation_Validate
  - remove-operation: ValidateOperation_Trigger
  - remove-operation: PrivateEndpoint_GetOperationStatus
  - remove-operation: GetOperationStatus
  - remove-operation: BMSPrepareDataMoveOperationResult_Get
  - remove-operation: ProtectedItemOperationResults_Get
  - remove-operation: ProtectionPolicyOperationResults_Get
  - remove-operation: JobOperationResults_Get
  - remove-operation: ExportJobsOperationResults_Get
  - remove-operation: ValidateOperationResults_Get
  - remove-operation: ValidateOperationStatuses_Get
  - remove-operation: ProtectionContainerRefreshOperationResults_Get
  - remove-operation: ProtectionContainerOperationResults_Get
  - remove-operation: ProtectedItemOperationStatuses_Get
  - remove-operation: BackupOperationResults_Get
  - remove-operation: BackupOperationStatuses_Get
  - remove-operation: ProtectionPolicyOperationStatuses_Get
  - remove-operation: TieringCostOperationStatus_Get
  # Autorest.CSharp can't find `nextLink` from parent (allOf), so here workaround.
  # Issues filed here: https://github.com/Azure/autorest.csharp/issues/2740.
  - from: bms.json
    where: $.definitions
    transform: >
      delete $.ProtectionIntentResourceList.allOf;
      $.ProtectionIntentResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.RecoveryPointResourceList.allOf;
      $.RecoveryPointResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectionPolicyResourceList.allOf;
      $.ProtectionPolicyResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.JobResourceList.allOf;
      $.JobResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectedItemResourceList.allOf;
      $.ProtectedItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.BackupEngineBaseResourceList.allOf;
      $.BackupEngineBaseResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectableContainerResourceList.allOf;
      $.ProtectableContainerResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.WorkloadItemResourceList.allOf;
      $.WorkloadItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.WorkloadProtectableItemResourceList.allOf;
      $.WorkloadProtectableItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectionContainerResourceList.allOf;
      $.ProtectionContainerResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.RecoveryPointResourceList.allOf;
      $.RecoveryPointResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ResourceGuardProxyBaseResourceList.allOf;
      $.ResourceGuardProxyBaseResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
  # Here the PATCH operation doesn't return the resource data, so the generated code of `AddTag` operation is not correct.
  # Issue filed here: https://github.com/Azure/autorest.csharp/issues/2741.
  # This directive just pass the build, but the operation may still not work.
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig']
    transform: >
      $.patch.responses['200'] = {
            'description': 'OK',
            'schema': {
              '$ref': '#/definitions/BackupResourceConfigResource'
            }
          };
  # The operation group should of list method be same as other method
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupResourceGuardProxies']
    transform: >
      $.get['operationId'] = 'ResourceGuardProxy_List';
  # TODO: Remove this workaround once we have the swagger issue fixed
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}']
    transform: >
      $.put['x-ms-long-running-operation'] = true;
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}']
    transform: >
      $.put['x-ms-long-running-operation'] = true;
  - from: bms.json
    where: $.definitions.RecoveryPointTierStatus
    transform: >
      $['x-ms-enum']['modelAsString'] = false;
  # Here the parameter format isn't specified in swagger, hence adding it explicitly
  - from: bms.json
    where: $.paths..parameters[?(@.name == 'azureRegion')]
    transform: >
      $["x-ms-format"] = 'azure-location';
      $['x-ms-client-name'] = 'location';
  # Rename ErrorDetail to BackupErrorDetail. (FYI: not working in rename-mapping section)
  - from: bms.json
    where: $.definitions
    transform: >
      $.ErrorDetail['x-ms-client-name'] = 'BackupErrorDetail';

```
