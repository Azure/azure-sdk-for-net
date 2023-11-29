# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RecoveryServicesBackup
namespace: Azure.ResourceManager.RecoveryServicesBackup
# tag: package-2023-01
require: https://github.com/Azure/azure-rest-api-specs/blob/80c21c17b4a7aa57f637ee594f7cfd653255a7e0/specification/recoveryservicesbackup/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
  AzureVmWorkloadSAPAseDatabaseProtectedItem: VmWorkloadSapAseDatabaseProtectedItem
  AzureVmWorkloadSAPAseDatabaseWorkloadItem: VmWorkloadSapAseDatabaseWorkloadItem
  AzureVmWorkloadSAPAseSystemProtectableItem: VmWorkloadSapAseSystemProtectableItem
  AzureVmWorkloadSAPAseSystemWorkloadItem: VmWorkloadSapAseSystemWorkloadItem
  AzureVmWorkloadSAPHanaDatabaseProtectableItem: VmWorkloadSapHanaDatabaseProtectableItem
  AzureVmWorkloadSAPHanaDatabaseProtectedItem: VmWorkloadSapHanaDatabaseProtectedItem
  AzureVmWorkloadSAPHanaDatabaseWorkloadItem: VmWorkloadSapHanaDatabaseWorkloadItem
  AzureVmWorkloadSAPHanaDBInstance: VmWorkloadSapHanaDBInstance
  AzureVmWorkloadSAPHanaDBInstanceProtectedItem: VmWorkloadSapHanaDBInstanceProtectedItem
  AzureVmWorkloadSAPHanaHSR: VmWorkloadSapHanaHsr
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
  ErrorDetail: BackupErrorDetail
  ExtendedProperties: IaasVmBackupExtendedProperties
  FabricName: BackupFabricName
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
  RecoveryPointProperties.expiryTime: ExpireOn
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
  TargetDiskNetworkAccessOption: BackupTargetDiskNetworkAccessOption
  TargetDiskNetworkAccessSettings: BackupTargetDiskNetworkAccessSettings
  TargetDiskNetworkAccessSettings.targetDiskAccessId: -|arm-id

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
  - from: bms.json
    where: $.definitions
    transform: >
      $.TieringPolicy.properties.duration['x-ms-client-name'] = 'durationValue';
      $.AzureIaaSVMJobExtendedInfo.properties.estimatedRemainingDuration['x-ms-client-name'] = 'estimatedRemainingDurationValue';
      $.BMSBackupSummariesQueryObject.properties.type['x-ms-client-name'] = 'BackupManagementType';
      $.BMSBackupSummariesQueryObject.properties.type['x-ms-enum']['name'] = 'BackupManagementType';
      $.RecoveryPointRehydrationInfo.properties.rehydrationRetentionDuration['format'] = 'duration';
  - from: bms.json
    where: $.parameters
    transform: >
      $.AzureRegion['x-ms-format'] = 'azure-location';
      $.AzureRegion['x-ms-client-name'] = 'location';
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
    where: $.paths['/Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig']
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
  # Here the format date-time isn't specified in swagger, hence adding it explicitly 
  - from: bms.json
    where: $.definitions.RecoveryPointProperties.properties.expiryTime
    transform: >
      $["format"] = "date-time";
  # TODO: Remove this workaround once we have the swagger issue fixed
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}']
    transform: >
      $.put['x-ms-long-running-operation'] = true;
  - from: bms.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}']
    transform: >
      $.put['x-ms-long-running-operation'] = true;
```
