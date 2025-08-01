# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataMigration
namespace: Azure.ResourceManager.DataMigration
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/86c6306649b02e542117adb46c61e8019dbd78e9/specification/datamigration/resource-manager/readme.md
#tag: package-preview-2025-03
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

rename-mapping:
  AuthenticationKeys: SqlMigrationAuthenticationKeys
  AuthType: SqlMigrationBlobAuthType
  AvailableServiceSkuCapacity: DataMigrationAvailableServiceSkuCapacity
  AvailableServiceSkuSku: DataMigrationAvailableServiceSkuDetails
  AzureActiveDirectoryApp.ignoreAzurePermissions: DoesIgnoreAzurePermissions
  AzureActiveDirectoryApp: DataMigrationAadApp
  AzureBlob: SqlMigrationBlobDetails
  ConnectionInfo: ServerConnectionInfo
  ConnectToSourceSqlServerTaskInput.collectAgentJobs: ShouldCollectAgentJobs
  ConnectToSourceSqlServerTaskInput.collectDatabases: ShouldCollectDatabases
  ConnectToSourceSqlServerTaskInput.collectLogins: ShouldCollectLogins
  ConnectToSourceSqlServerTaskInput.collectTdeCertificateInfo: ShouldCollectTdeCertificateInfo
  ConnectToSourceSqlServerTaskInput.validateSsisCatalogOnly: ShouldValidateSsisCatalogOnly
  ConnectToTargetSqlDbTaskInput.queryObjectCounts: ShouldQueryObjectCounts
  ConnectToTargetSqlDbTaskProperties.createdOn: -|date-time
  ConnectToTargetSqlMITaskInput.collectAgentJobs: ShouldCollectAgentJobs
  ConnectToTargetSqlMITaskInput.collectLogins: ShouldCollectLogins
  ConnectToTargetSqlMITaskInput.validateSsisCatalogOnly: ShouldValidateSsisCatalogOnly
  CopyProgressDetails.copyStart: CopyStartOn
  DatabaseBackupInfo.backupFinishDate: BackupFinishedOn
  DatabaseFileType: DataMigrationSqlDatabaseFileType
  DatabaseInfo: DataMigrationProjectDatabaseInfo
  DatabaseState: DataMigrationSqlDatabaseState
  DataMigrationService.properties.deleteResourcesOnStop: ShouldDeleteResourcesOnStop
  DeleteNode: DeletedIntegrationRuntimeNodeResult
  ErrorInfo: SqlMigrationErrorInfo
  ExecutionStatistics.cpuTimeMs: CpuTimeInMilliseconds
  ExecutionStatistics.elapsedTimeMs: ElapsedTimeInMilliseconds
  FileShare: DataMigrationFileShareInfo
  IntegrationRuntimeMonitoringData: IntegrationRuntimeMonitoringResult
  MigrateMySqlAzureDbForMySqlOfflineTaskInput.makeSourceServerReadOnly: ShouldMakeSourceServerReadOnly
  MigrateMySqlAzureDbForMySqlOfflineTaskOutputDatabaseLevel.lastStorageUpdate: LastStorageUpdatedOn
  MigrateMySqlAzureDbForMySqlOfflineTaskOutputMigrationLevel.lastStorageUpdate: LastStorageUpdatedOn
  MigrateMySqlAzureDbForMySqlOfflineTaskOutputTableLevel.lastStorageUpdate: LastStorageUpdatedOn
  MigrateMySqlAzureDbForMySqlSyncTaskOutputDatabaseLevel.initializationCompleted: IsInitializationCompleted
  MigrateMySqlAzureDbForMySqlSyncTaskOutputTableLevel.fullLoadEstFinishTime: FullLoadEstFinishedOn
  MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseLevel.initializationCompleted: IsInitializationCompleted
  MigrateOracleAzureDbPostgreSqlSyncTaskOutputTableLevel.fullLoadEstFinishTime: FullLoadEstFinishedOn
  MigratePostgreSqlAzureDbForPostgreSqlSyncTaskOutputDatabaseLevel.initializationCompleted: IsInitializationCompleted
  MigratePostgreSqlAzureDbForPostgreSqlSyncTaskOutputTableLevel.fullLoadEstFinishTime: FullLoadEstFinishedOn
  MigratePostgreSqlAzureDbForPostgreSqlSyncTaskProperties.createdOn: -|date-time
  MigrateSchemaSqlServerSqlDbTaskInput.startedOn: -|date-time
  MigrateSchemaSqlServerSqlDbTaskProperties.createdOn: -|date-time
  MigrateSqlServerSqlDbDatabaseInput.makeSourceDbReadOnly: ShouldMakeSourceDBReadOnly
  MigrateSqlServerSqlDbSyncTaskOutputDatabaseLevel.initializationCompleted: IsInitializationCompleted
  MigrateSqlServerSqlDbSyncTaskOutputTableLevel.fullLoadEstFinishTime: FullLoadEstFinishedOn
  MigrateSqlServerSqlDbTaskInput.startedOn: -|date-time
  MigrateSqlServerSqlDbTaskProperties.createdOn: -|date-time
  MigrateSqlServerSqlMISyncTaskProperties.createdOn: -|date-time
  MigrateSqlServerSqlMITaskInput.startedOn: -|date-time
  MigrateSqlServerSqlMITaskProperties.createdOn: -|date-time
  MigrateSyncCompleteCommandInput.commitTimeStamp: CompletedOn
  MigrationState: DataMigrationState
  MigrationStatus: DataMigrationStatus
  MigrationStatusDetails: DataMigrationStatusDetails
  MigrationValidationOptions.enableDataIntegrityValidation: IsDataIntegrityValidationEnabled
  MigrationValidationOptions.enableQueryAnalysisValidation: IsQueryAnalysisValidationEnabled
  MigrationValidationOptions.enableSchemaValidation: IsSchemaValidationEnabled
  MiSqlConnectionInfo.managedInstanceResourceId: -|arm-id
  MongoDbClusterInfo.supportsSharding: IsShardingSupported
  MongoDbCollectionInfo.supportsSharding: IsShardingSupported
  MongoDbConnectionInfo.encryptConnection: ShouldEncryptConnection
  MongoDbConnectionInfo.enforceSSL: DoesEnforceSsl
  MongoDbConnectionInfo.trustServerCertificate: ShouldTrustServerCertificate
  MongoDbDatabaseInfo.supportsSharding: IsShardingSupported
  MongoDbFinishCommandInput.immediate: ShouldStopReplicationImmediately
  MySqlConnectionInfo.encryptConnection: ShouldEncryptConnection
  NameAvailabilityRequest: DataMigrationServiceNameAvailabilityContent
  NameAvailabilityResponse.nameAvailable: IsNameAvailable
  NameAvailabilityResponse: DataMigrationServiceNameAvailabilityResult
  NameCheckFailureReason: DataMigrationServiceNameUnavailableReason
  NodeMonitoringData: IntegrationRuntimeMonitoringNode
  ObjectType: DataMigrationDatabaseObjectType
  OfflineConfiguration.offline: IsOfflineMigration
  OrphanedUserInfo: DataMigrationSqlServerOrphanedUserInfo
  PostgreSqlConnectionInfo.encryptConnection: ShouldEncryptConnection
  PostgreSqlConnectionInfo.trustServerCertificate: ShouldTrustServerCertificate
  ProjectFileProperties.lastModified: LastModifiedOn
  RegenAuthKeys: SqlMigrationRegenAuthKeys
  ResourceSku: DataMigrationSku
  ResourceSkuCapabilities: DataMigrationSkuCapabilities
  ResourceSkuCapacity: DataMigrationSkuCapacity
  ResourceSkuCosts: DataMigrationSkuCosts
  ResourceSkuRestrictions: DataMigrationSkuRestrictions
  ResourceSkuRestrictionsType: DataMigrationSkuRestrictionsType
  ScenarioSource.MySQLRDS: MySqlRds
  ScenarioSource.PostgreSQLRDS: PostgreSqlRds
  ScenarioSource.SQLRDS: SqlRds
  ServerProperties: DataMigrationMySqlServerProperties
  Severity: MigrationValidationSeverity
  SourceLocation: DataMigrationBackupSourceLocation
  SqlConnectionInfo.encryptConnection: ShouldEncryptConnection
  SqlConnectionInfo.trustServerCertificate: ShouldTrustServerCertificate
  SqlConnectionInformation.encryptConnection: ShouldEncryptConnection
  SqlConnectionInformation.trustServerCertificate: ShouldTrustServerCertificate
  SqlDbOfflineConfiguration.offline: IsOfflineMigration
  TargetLocation: DataMigrationBackupTargetLocation
  UpdateActionType: MigrationValidatioUpdateActionType
  ValidationError: MigrationValidationError
  ValidationStatus: MigrationValidationStatus
  WaitStatistics.waitTimeMs: WaitTimeInMilliseconds
  WaitStatistics: MigrationValidationWaitStatistics

prepend-rp-prefix:
  - AuthenticationType
  - AvailableServiceSku
  - BackupConfiguration
  - BackupFileInfo
  - BackupFileStatus
  - BackupMode
  - BackupSetInfo
  - BackupType
  - BlobShare
  - CommandProperties
  - CommandState
  - CommandType
  - DatabaseBackupInfo
  - DatabaseCompatLevel
  - DatabaseFileInfo
  - DatabaseTable
  - FileStorageInfo
  - LoginType
  - MiSqlConnectionInfo
  - MongoDbCancelCommand
  - MongoDbClusterInfo
  - MongoDbClusterType
  - MongoDbCollectionInfo
  - MongoDbCollectionProgress
  - MongoDbCollectionSettings
  - MongoDbCommandInput
  - MongoDbConnectionInfo
  - MongoDbDatabaseInfo
  - MongoDbDatabaseProgress
  - MongoDbDatabaseSettings
  - MongoDbError
  - MongoDbErrorType
  - MongoDbFinishCommand
  - MongoDbFinishCommandInput
  - MongoDbMigrationProgress
  - MongoDbMigrationSettings
  - MongoDbMigrationState
  - MongoDbObjectInfo
  - MongoDbProgress
  - MongoDbProgressResultType
  - MongoDbReplication
  - MongoDbRestartCommand
  - MongoDbShardKeyField
  - MongoDbShardKeyInfo
  - MongoDbShardKeyOrder
  - MongoDbShardKeySetting
  - MongoDbThrottlingSettings
  - MySqlConnectionInfo
  - MySqlTargetPlatformType
  - ODataError
  - OfflineConfiguration
  - OracleConnectionInfo
  - OracleOCIDriverInfo
  - PostgreSqlConnectionInfo
  - ProjectFileProperties
  - Project
  - ProjectFile
  - ProjectProvisioningState
  - ProjectSourcePlatform
  - ProjectTargetPlatform
  - ProjectTask
  - ProjectTaskProperties
  - ProvisioningState
  - Quota
  - QuotaName
  - ReportableException
  - ScenarioSource
  - ScenarioTarget
  - ServiceProvisioningState
  - ServiceScalability
  - ServiceSku
  - SqlBackupFileInfo
  - SqlBackupSetInfo
  - SqlConnectionInfo
  - SqlConnectionInformation
  - SqlDbMigrationStatusDetails
  - SqlDbOfflineConfiguration
  - SqlFileShare
  - SqlSourcePlatform
  - SsisStoreType
  - TaskState
  - TaskType

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
  SQL: Sql
  Sqldb: SqlDB
  Sqldw: SqlDW
  Sqlmi: SqlMI
  Db: DB|db
  Mi: MI|mi
  OCI: Oci

override-operation-name:
  Services_CheckChildrenNameAvailability: CheckDataMigrationServiceNameAvailability
  Services_CheckNameAvailability: CheckDataMigrationNameAvailability

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.DataMigration/services/{serviceName}/projects/{projectName}/tasks/{taskName}: DataMigrationServiceTask

directive:
  - from: sqlmigration.json
    where: $.definitions
    transform: >
      $.DatabaseMigrationPropertiesSqlMi['x-ms-client-name'] = 'DatabaseMigrationSqlMIProperties';
      $.DatabaseMigrationPropertiesSqlVm['x-ms-client-name'] = 'DatabaseMigrationSqlVmProperties';
      $.DatabaseMigrationPropertiesSqlDb['x-ms-client-name'] = 'DatabaseMigrationSqlDBProperties';
  - remove-operation-match: /^DatabaseMigrationsMongoToCosmosDbRUMongo_.*/i
  - remove-operation-match: /^DatabaseMigrationsMongoToCosmosDbvCoreMongo_.*/i
  - remove-operation-match: /^MigrationServices_.*/i
  - remove-model: DatabaseMigrationCosmosDbMongoListResult
  - remove-model: DatabaseMigrationCosmosDbMongo
  - remove-model: DatabaseMigrationPropertiesCosmosDbMongo
```
