# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RecoveryServicesBackup
namespace: Azure.ResourceManager.RecoveryServicesBackup
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/2d9846d81852452cf10270b18329ac382a881bf7/specification/recoveryservicesbackup/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

rename-mapping:
  Job: BackupJobProperties
  JobResource: BackupJob
  BackupEngineBase: BackupEngineProperties
  BackupEngineBaseResource: BackupEngine
  BackupResourceConfig: BackupResourceConfigProperties
  BackupResourceConfigResource: BackupResourceConfig
  BackupResourceEncryptionConfigExtended: BackupResourceEncryptionConfigExtendedProperties
  BackupResourceEncryptionConfigExtendedResource: BackupResourceEncryptionConfigExtended
  BackupResourceVaultConfig: BackupResourceVaultConfigProperties
  BackupResourceVaultConfigResource: BackupResourceVaultConfig
  PrivateEndpointConnection: BackupPrivateEndpointConnectionProperties
  PrivateEndpointConnectionResource: BackupPrivateEndpointConnection
  ProtectedItem: BackupProtectedItemProperties
  ProtectedItemResource: BackupProtectedItem
  ProtectionContainer: BackupProtectionContainerProperties
  ProtectionContainerResource: BackupProtectionContainer
  ProtectionIntent: BackupProtectionIntentProperties
  ProtectionIntentResource: BackupProtectionIntent
  ProtectionPolicy: BackupProtectionPolicyProperties
  ProtectionPolicyResource: BackupProtectionPolicy
  RecoveryPoint: BackupRecoveryPointProperties
  RecoveryPointResource: BackupRecoveryPoint
  ResourceGuardProxyBase: ResourceGuardProxyProperties
  ResourceGuardProxyBaseResource: ResourceGuardProxy
  AzureBackupGoalFeatureSupportRequest: BackupGoalFeatureSupportContent
  AzureBackupServerContainer: BackupServerContainer
  AzureBackupServerEngine: BackupServerEngine
  AzureFileShareBackupRequest: FileShareBackupRequest
  AzureFileShareProtectableItem: FileShareProtectableItem
  AzureFileshareProtectedItem: FileshareProtectedItem
  AzureFileshareProtectedItemExtendedInfo: FileshareProtectedItemExtendedInfo
  AzureFileShareProtectionPolicy: FileShareProtectionPolicy
  AzureFileShareProvisionILRRequest: FileShareProvisionIlrRequest
  AzureFileShareRecoveryPoint: FileShareRecoveryPoint
  AzureFileShareRestoreRequest: FileShareRestoreRequest
  AzureFileShareType: BackupFileShareType
  AzureIaaSClassicComputeVMContainer: IaasClassicComputeVmContainer
  AzureIaaSClassicComputeVMProtectableItem: IaasClassicComputeVmProtectableItem
  AzureIaaSClassicComputeVMProtectedItem: IaasClassicComputeVmProtectedItem
  AzureIaaSComputeVMContainer: IaasComputeVmContainer
  AzureIaaSComputeVMProtectableItem: IaasComputeVmProtectableItem
  AzureIaaSComputeVMProtectedItem: IaasComputeVmProtectedItem
  AzureIaaSVMErrorInfo: IaasVmErrorInfo
  AzureIaaSVMHealthDetails: IaasVmHealthDetails
  AzureIaaSVMJob: IaasVmJob
  AzureIaaSVMJobExtendedInfo: IaasVmJobExtendedInfo
  AzureIaaSVMJobTaskDetails: IaasVmJobTaskDetails
  AzureIaaSVMJobV2: IaasVmJobV2
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
  AzureStorageJob: StorageJob
  AzureStorageJobExtendedInfo: StorageJobExtendedInfo
  AzureStorageJobTaskDetails: StorageJobTaskDetails
  AzureStorageProtectableContainer: StorageProtectableContainer
  AzureVMAppContainerProtectableContainer: VmAppContainerProtectableContainer
  AzureVMAppContainerProtectionContainer: VmAppContainerProtectionContainer
  AzureVMResourceFeatureSupportRequest: VmResourceFeatureSupportContent
  AzureVMResourceFeatureSupportResponse: VmResourceFeatureSupportResponse
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
  AzureVmWorkloadSAPHanaDBInstance: VmWorkloadSapHanaDbInstance
  AzureVmWorkloadSAPHanaDBInstanceProtectedItem: VmWorkloadSapHanaDbInstanceProtectedItem
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
  AzureWorkloadBackupRequest: WorkloadBackupRequest
  AzureWorkloadContainer: WorkloadContainer
  AzureWorkloadContainerAutoProtectionIntent: WorkloadContainerAutoProtectionIntent
  AzureWorkloadContainerExtendedInfo: WorkloadContainerExtendedInfo
  AzureWorkloadErrorInfo: WorkloadErrorInfo
  AzureWorkloadJob: WorkloadJob
  AzureWorkloadJobExtendedInfo: WorkloadJobExtendedInfo
  AzureWorkloadJobTaskDetails: WorkloadJobTaskDetails
  AzureWorkloadPointInTimeRecoveryPoint: WorkloadPointInTimeRecoveryPoint
  AzureWorkloadPointInTimeRestoreRequest: WorkloadPointInTimeRestoreRequest
  AzureWorkloadSAPHanaPointInTimeRecoveryPoint: WorkloadSapHanaPointInTimeRecoveryPoint
  AzureWorkloadRecoveryPoint: WorkloadRecoveryPoint
  AzureWorkloadRestoreRequest: WorkloadRestoreRequest
  AzureWorkloadSAPHanaPointInTimeRestoreRequest: WorkloadSapHanaPointInTimeRestoreRequest
  AzureWorkloadSAPHanaPointInTimeRestoreWithRehydrateRequest: WorkloadSapHanaPointInTimeRestoreWithRehydrateRequest
  AzureWorkloadSAPHanaRecoveryPoint: WorkloadSapHanaRecoveryPoint
  AzureWorkloadSAPHanaRestoreRequest: WorkloadSapHanaRestoreRequest
  AzureWorkloadSAPHanaRestoreWithRehydrateRequest: WorkloadSapHanaRestoreWithRehydrateRequest
  AzureWorkloadSQLAutoProtectionIntent: WorkloadSqlAutoProtectionIntent
  AzureWorkloadSQLPointInTimeRecoveryPoint: WorkloadSqlPointInTimeRecoveryPoint
  AzureWorkloadSQLPointInTimeRestoreRequest: WorkloadSqlPointInTimeRestoreRequest
  AzureWorkloadSQLPointInTimeRestoreWithRehydrateRequest: WorkloadSqlPointInTimeRestoreWithRehydrateRequest
  AzureWorkloadSQLRecoveryPoint: WorkloadSqlRecoveryPoint
  AzureWorkloadSQLRecoveryPointExtendedInfo: WorkloadSqlRecoveryPointExtendedInfo
  AzureWorkloadSQLRestoreRequest: WorkloadSqlRestoreRequest
  AzureWorkloadSQLRestoreWithRehydrateRequest: WorkloadSqlRestoreWithRehydrateRequest
  BackupRequest: BackupRequestProperties
  BackupRequestResource: BackupRequestContent
  CreateMode: BackupCreateMode
  DataSourceType: BackupDataSourceType
  Day: BackupDay
  DayOfWeek: BackupDayOfWeek
  DedupState: VaultDedupState
  EncryptionAtRestType: BackupEncryptionAtRestType
  EncryptionDetails: VmEncryptionDetails
  ErrorDetail: BackupErrorDetail
  ExtendedProperties: IaasVmBackupExtendedProperties
  FabricName: BackupFabricName
  ILRRequest: IlrRequestProperties
  ILRRequestResource: ILRRequestContent
  StorageType: BackupStorageType
  XcoolState: VaultXcoolState

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'SubscriptionIdParameter': 'object'

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
  IaaSVM: IaasVm
  Iaasvm: IaasVm
  Sqldb: SqlDB
  SQLAG: SqlAG
  Sqlag: SqlAG
  MAB: Mab
  DPM: Dpm
  Issqlcompression: IsSqlCompression
  ILR: Ilr
  SQL: Sql
  BEK: Bek
  KEK: Kek

override-operation-name:
  BackupStatus_Get: GetBackupStatus
  DeletedProtectionContainers_List: GetSoftDeletedProtectionContainers

list-exception:
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/backupProtectionIntent/{intentObjectName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupconfig/vaultconfig
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/privateEndpointConnections/{privateEndpointConnectionName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}

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
```
