# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

## Code Generation Configuration

```yaml
azure-arm: true
csharp: true
library-name: CosmosDB
namespace: Azure.ResourceManager.CosmosDB
require: https://github.com/Azure/azure-rest-api-specs/blob/b4506c0467cf68eeb9b0e966a3db1c9bedcd84c7/specification/cosmos-db/resource-manager/readme.md
#tag: package-preview-2024-02
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

# mgmt-debug:
#   show-serialized-names: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/cassandraKeyspaces/{keyspaceName}/throughputSettings/default: CassandraKeyspaceThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/cassandraKeyspaces/{keyspaceName}/tables/{tableName}/throughputSettings/default: CassandraTableThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/tables/{tableName}/throughputSettings/default: CosmosTableThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/gremlinDatabases/{databaseName}/throughputSettings/default: GremlinDatabaseThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/gremlinDatabases/{databaseName}/graphs/{graphName}/throughputSettings/default: GremlinGraphThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/mongodbDatabases/{databaseName}/throughputSettings/default: MongoDBDatabaseThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/mongodbDatabases/{databaseName}/collections/{collectionName}/throughputSettings/default: MongoDBCollectionThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/throughputSettings/default: CosmosDBSqlDatabaseThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/throughputSettings/default: CosmosDBSqlContainerThroughputSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/cassandraKeyspaces/{keyspaceName}/views/{viewName}/throughputSettings/default: CassandraViewThroughputSetting
operation-id-mappings:
  CassandraKeyspaceThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      keyspaceName: Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces
  CassandraTableThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      keyspaceName: Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces
      tableName: Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/tables
  CosmosTableThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      tableName: Microsoft.DocumentDB/databaseAccounts/tables
  GremlinDatabaseThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/gremlinDatabases
  GremlinGraphThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/gremlinDatabases
      graphName: Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/graphs
  MongoDBCollectionThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/mongodbDatabases
      collectionName: Microsoft.DocumentDB/databaseAccounts/mongodbDatabases/collections
  MongoDBDatabaseThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/mongodbDatabases
  CosmosDBSqlContainerThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/sqlDatabases
      containerName: Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers
  CosmosDBSqlDatabaseThroughputSetting:
      accountName: Microsoft.DocumentDB/databaseAccounts
      databaseName: Microsoft.DocumentDB/databaseAccounts/sqlDatabases

no-property-type-replacement:
- CosmosDBSqlDatabaseResourceInfo
- MongoDBDatabaseResourceInfo
- CosmosDBTableResourceInfo
- CassandraKeyspaceResourceInfo
- CassandraColumn
- GremlinDatabaseResourceInfo
- PrivateEndpointProperty

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  'dataCenterLocation': 'azure-location'
  'hostId': 'uuid'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'principalId': 'uuid'
  '*SubnetId': 'arm-id'
  'networkAclBypassResourceIds': 'arm-id'
  'partitionId': 'uuid'
  'instanceId': 'uuid'

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
  Mongodb: MongoDB
  VNet: Vnet
  API: Api
  Db: DB

override-operation-name:
  RestorableMongodbDatabases_List: GetRestorableMongoDBDatabases
  RestorableMongodbCollections_List: GetRestorableMongoDBCollections
  RestorableMongodbResources_List: GetAllRestorableMongoDBResourceData
  RestorableSqlResources_List: GetAllRestorableSqlResourceData
  MongoClusters_CheckNameAvailability: CheckMongoClusterNameAailability

rename-mapping:
  MongoRoleDefinitionGetResults: MongoDBRoleDefinition
  MongoUserDefinitionGetResults: MongoDBUserDefinition
  MongoRoleDefinitionType: MongoDBRoleDefinitionType
  Privilege: MongoDBPrivilege
  Role: MongoDBRole
  Role.db: DBName
  MongoRoleDefinitionGetResults.properties.type: RoleDefinitionType
  MongoRoleDefinitionListResult: MongoDBRoleDefinitionListResult
  MongoUserDefinitionListResult: MongoDBUserDefinitionListResult
  CassandraKeyspacePropertiesOptions: CassandraKeyspacePropertiesConfig
  CassandraTablePropertiesOptions: CassandraTablePropertiesConfig
  CreateUpdateOptions: CosmosDBCreateUpdateConfig
  GremlinDatabasePropertiesOptions: GremlinDatabasePropertiesConfig
  GremlinGraphPropertiesOptions: GremlinGraphPropertiesConfig
  MongoDBCollectionPropertiesOptions: MongoDBCollectionPropertiesConfig
  MongoDBDatabasePropertiesOptions: MongoDBDatabasePropertiesConfig
  CosmosDBSqlContainerPropertiesOptions: CosmosDBSqlContainerPropertiesConfig
  CosmosDBSqlDatabasePropertiesOptions: CosmosDBSqlDatabasePropertiesConfig
  CosmosDBSqlDatabasePropertiesResource: ExtendedCosmosDBSqlDatabaseResourceInfo
  AutoscaleSettingsResource: AutoscaleSettingsResourceInfo
  CassandraKeyspacePropertiesResource: ExtendedCassandraKeyspaceResourceInfo
  CassandraKeyspaceResource: CassandraKeyspaceResourceInfo
  CassandraTablePropertiesResource: ExtendedCassandraTableResourceInfo
  CassandraTableResource: CassandraTableResourceInfo
  ClientEncryptionKeyGetPropertiesResource: CosmosDBSqlClientEncryptionKeyProperties
  ClientEncryptionKeyResource: CosmosDBSqlClientEncryptionKeyResourceInfo
  ClientEncryptionPolicy: CosmosDBClientEncryptionPolicy
  ClientEncryptionIncludedPath: CosmosDBClientEncryptionIncludedPath
  ClientEncryptionKeyGetResults: CosmosDBSqlClientEncryptionKey
  DatabaseRestoreResource: DatabaseRestoreResourceInfo
  GremlinDatabaseRestoreResource: GremlinDatabaseRestoreResourceInfo
  GremlinDatabasePropertiesResource: ExtendedGremlinDatabaseResourceInfo
  GremlinDatabaseResource: GremlinDatabaseResourceInfo
  GremlinGraphPropertiesResource: ExtendedGremlinGraphResourceInfo
  GremlinGraphResource: GremlinGraphResourceInfo
  MongoDBCollectionPropertiesResource: ExtendedMongoDBCollectionResourceInfo
  MongoDBCollectionResource: MongoDBCollectionResourceInfo
  MongoDBDatabasePropertiesResource: ExtendedMongoDBDatabaseResourceInfo
  MongoDBDatabaseResource: MongoDBDatabaseResourceInfo
  OptionsResource: CosmosDBBaseConfig
  RestorableLocationResource: RestorableLocationResourceInfo
  RestorableMongodbCollectionPropertiesResource: ExtendedRestorableMongoDBCollectionResourceInfo
  RestorableMongodbDatabasePropertiesResource: ExtendedRestorableMongoDBDatabaseResourceInfo
  RestorableSqlContainerPropertiesResource: ExtendedRestorableSqlContainerResourceInfo
  RestorableSqlDatabasePropertiesResource: ExtendedRestorableSqlDatabaseResourceInfo
  RestorableGremlinDatabasePropertiesResource: ExtendedRestorableGremlinDatabaseResourceInfo
  RestorableGremlinGraphPropertiesResource: ExtendedRestorableGremlinGraphResourceInfo
  RestorableTablePropertiesResource: ExtendedRestorableTableResourceInfo
  CosmosDBSqlContainerPropertiesResource: ExtendedCosmosDBSqlContainerResourceInfo
  SqlContainerResource: CosmosDBSqlContainerResourceInfo
  SqlDatabaseResource: CosmosDBSqlDatabaseResourceInfo
  SqlStoredProcedureResource: CosmosDBSqlStoredProcedureResourceInfo
  SqlTriggerResource: CosmosDBSqlTriggerResourceInfo
  CosmosDBSqlTriggerPropertiesResource: ExtendedCosmosDBSqlTriggerResourceInfo
  SqlUserDefinedFunctionResource: CosmosDBSqlUserDefinedFunctionResourceInfo
  TableResource: CosmosDBTableResourceInfo
  ThroughputPolicyResource: ThroughputPolicyResourceInfo
  ThroughputSettingsPropertiesResource: ExtendedThroughputSettingsResourceInfo
  ThroughputSettingsResource: ThroughputSettingsResourceInfo
  SqlContainerListResult: CosmosDBSqlContainerListResult
  SqlDatabaseListResult: CosmosDBSqlDatabaseListResult
  SqlStoredProcedureListResult: CosmosDBSqlStoredProcedureListResult
  SqlTriggerListResult: CosmosDBSqlTriggerListResult
  SqlUserDefinedFunctionListResult: CosmosDBSqlUserDefinedFunctionListResult
  AutoUpgradePolicyResource: AutoUpgradePolicyResourceInfo
  CosmosDBSqlStoredProcedurePropertiesResource: ExtendedCosmosDBSqlStoredProcedureResourceInfo
  CosmosDBSqlUserDefinedFunctionPropertiesResource: ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo
  DatabaseAccountConnectionString: CosmosDBAccountConnectionString
  DatabaseAccountKind: CosmosDBAccountKind
  DatabaseAccountOfferType: CosmosDBAccountOfferType
  ClusterResource: CassandraCluster
  ClusterKey: CassandraClusterKey
  ClusterResourceProperties: CassandraClusterProperties
  ClusterType: CassandraClusterType
  DataCenterResource: CassandraDataCenter
  DataCenterResourceProperties: CassandraDataCenterProperties
  ListDataCenters: CassandraDataCenterListResult
  ListClusters: CassandraClusterListResult
  SeedNode: CassandraDataCenterSeedNode
  ConnectionError: CassandraConnectionError
  CommandPostBody: CassandraCommandPostBody
  CommandOutput: CassandraCommandOutput
  Certificate: CassandraCertificate
  RestorableMongodbCollectionGetResult: RestorableMongoDBCollection
  Usage: CosmosDBBaseUsage
  AuthenticationMethod: CassandraAuthenticationMethod
  BackupPolicy: CosmosDBAccountBackupPolicy
  CorsPolicy: CosmosDBAccountCorsPolicy
  Capacity: CosmosDBAccountCapacity
  ConnectionState: CassandraConnectionState
  CreateMode: CosmosDBAccountCreateMode
  KeyKind: CosmosDBAccountKeyKind
  NodeState: CassandraNodeState
  Permission: CosmosDBSqlRolePermission
  RestoreMode: CosmosDBAccountRestoreMode
  RestoreParameters: CosmosDBAccountRestoreParameters
  RoleDefinitionType: CosmosDBSqlRoleDefinitionType
  TableListResult: CosmosDBTableListResult
  TriggerOperation: CosmosDBSqlTriggerOperation
  TriggerType: CosmosDBSqlTriggerType
  UnitType: CosmosDBMetricUnitType
  ClusterResourceProperties.cassandraAuditLoggingEnabled: IsCassandraAuditLoggingEnabled
  ClusterResourceProperties.deallocated : IsDeallocated
  ClusterResourceProperties.repairEnabled: IsRepairEnabled
  CommandPostBody.readWrite: AllowWrite
  IndexingPolicy.automatic: IsAutomatic
  ManagedCassandraReaperStatus.healthy: IsHealthy
  MongoIndexOptions.unique: IsUnique
  CassandraKeyspaceResource.id: KeyspaceName
  CassandraTableResource.id: TableName
  SqlDatabaseResource.id: DatabaseName
  TableResource.id: TableName
  GremlinDatabaseResource.id: DatabaseName
  MongoDBDatabaseResource.id: DatabaseName
  SqlContainerResource.id: containerName
  SqlStoredProcedureResource.id: StoredProcedureName
  SqlTriggerResource.id: TriggerName
  SqlUserDefinedFunctionResource.id: FunctionName
  GremlinGraphResource.id: GraphName
  MongoDBCollectionResource.id: CollectionName
  RestorableMongodbCollectionPropertiesResource.ownerId: CollectionName
  RestorableMongodbCollectionPropertiesResource.ownerResourceId: CollectionId
  RestorableMongodbDatabasePropertiesResource.ownerId: DatabaseName
  RestorableMongodbDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableSqlContainerPropertiesResource.ownerId: ContainerName
  RestorableSqlContainerPropertiesResource.ownerResourceId: ContainerId
  RestorableSqlDatabasePropertiesResource.ownerId: DatabaseName
  RestorableSqlDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableGremlinDatabasePropertiesResource.ownerId: DatabaseName
  RestorableGremlinDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableGremlinGraphPropertiesResource.ownerId: GraphName
  RestorableGremlinGraphPropertiesResource.ownerResourceId: GraphId
  RestorableTablePropertiesResource.ownerId: TableName
  RestorableTablePropertiesResource.ownerResourceId: TableId
  CosmosDBAccount.properties.enableFreeTier: IsFreeTierEnabled
  CosmosDBAccount.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  ContainerPartitionKey.systemKey: IsSystemKey
  DatabaseAccountCreateUpdateParameters.properties.enableFreeTier: IsFreeTierEnabled
  DatabaseAccountCreateUpdateParameters.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  DatabaseAccountUpdateParameters.properties.enableFreeTier: IsFreeTierEnabled
  DatabaseAccountUpdateParameters.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  LocationProperties.supportsAvailabilityZone: DoesSupportAvailabilityZone
  DataCenterResourceProperties.availabilityZone: DoesSupportAvailabilityZone
  ManagedCassandraProvisioningState: CassandraProvisioningState
  ManagedCassandraReaperStatus: CassandraReaperStatus
  MongoIndex: MongoDBIndex
  MongoIndexOptions: MongoDBIndexConfig
  BackupStorageRedundancy: CosmosDBBackupStorageRedundancy
  PrimaryAggregationType: CosmosDBMetricPrimaryAggregationType
  RestorableSqlResourcesGetResult: RestorableSqlResourceData
  RestorableMongodbResourcesGetResult: RestorableMongoDBResourceData
  RestorableGremlinResourcesGetResult : RestorableGremlinResourceData
  RestorableTableResourcesGetResult: RestorableTableResourceData
  ServiceResourceProperties: CosmosDBServiceProperties
  ServiceResourceCreateUpdateParameters: CosmosDBServiceCreateUpdateParameters
  ServiceResource: CosmosDBService
  ServiceResourceListResult: CosmosDBServiceListResult
  DataTransferServiceResourceProperties: DataTransferServiceProperties
  SqlDedicatedGatewayServiceResourceProperties: SqlDedicatedGatewayServiceProperties
  GraphAPIComputeServiceResourceProperties: GraphApiComputeServiceProperties
  MaterializedViewsBuilderServiceResourceProperties: MaterializedViewsBuilderServiceProperties
  RegionalServiceResource: CosmosDBRegionalService
  SqlDedicatedGatewayRegionalServiceResource: SqlDedicatedGatewayRegionalService
  GraphAPIComputeRegionalServiceResource: GraphApiComputeRegionalService
  DataTransferRegionalServiceResource: DataTransferRegionalService
  MaterializedViewsBuilderRegionalServiceResource: MaterializedViewsBuilderRegionalService
  ServiceStatus: CosmosDBServiceStatus
  ServiceSize: CosmosDBServiceSize
  ServiceType: CosmosDBServiceType
  AccountKeyMetadata.generationTime: GeneratedOn
  PrivilegeResource: MongoDBPrivilegeResourceInfo
  PrivilegeResource.db: DBName
  MinimalTlsVersion: CosmosDBMinimalTlsVersion
  BackupResource: CassandraClusterBackupResourceInfo
  BackupSchedule: CassandraClusterBackupSchedule
  BackupState: CassandraClusterBackupState
  CheckNameAvailabilityRequest: CheckCosmosDBNameAvailabilityContent
  CheckNameAvailabilityResponse: CheckCosmosDBNameAvailabilityResponse
  CheckNameAvailabilityReason: CosmosDBNameUnavailableReason
  NodeGroupProperties.diskSizeGB: DiskSizeInGB
  IpAddressOrRange: CosmosDBIPAddressOrRange

prepend-rp-prefix:
- UniqueKey
- UniqueKeyPolicy
- ServerVersion
- OperationType
- MetricValue
- MetricName
- MetricListResult
- MetricDefinitionsListResult
- MetricDefinition
- MetricAvailability
- LocationProperties
- LocationListResult
- DataType
- IndexingPolicy
- ExcludedPath
- IncludedPath
- IndexingMode
- IndexKind
- ApiType
- UsagesResult
- VirtualNetworkRule
- FailoverPolicies
- FailoverPolicy
- BackupInformation
- CompositePath
- PartitionKind
- PercentileMetric
- PublicNetworkAccess
- SpatialType
- ContainerPartitionKey
- FirewallRule
- Status
- ProvisioningState
- Type
- ConnectionString

models-to-treat-empty-string-as-null:
  - CosmosDBAccountData

suppress-abstract-base-class:
- CosmosDBServiceProperties

directive:
# The notebook is offline due to security issues
- from: notebook.json
  where: $.paths
  transform: >
    for (var path in $)
    {
        delete $[path];
    }
- from: notebook.json
  where: $.definitions
  transform: >
    for (var def in $)
    {
        delete $[def];
    }
- from: notebook.json
  where: $.parameters
  transform: >
    for (var param in $)
    {
        delete $[param];
    }

# This API is returning a collection wrapping by the model 'DatabaseAccountListConnectionStringsResult', adding this directive so that the content could be automatically flattened
- from: swagger-document
  where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/listConnectionStrings'].post
  transform: >
    $['x-ms-pageable'] = {
          'nextLinkName': null,
          'itemName': 'connectionStrings'
        }
- from: cosmos-db.json
  where: $.definitions
  transform: >
    $.MetricDefinition.properties.resourceUri['x-ms-client-name'] = 'ResourceId';
    $.MetricDefinition.properties.resourceUri['x-ms-format'] = 'arm-id';
    $.VirtualNetworkRule.properties.id['x-ms-format'] = 'arm-id';
    $.DatabaseAccountConnectionString.properties.type['x-ms-client-name'] = 'KeyType';
# add a missing response code for long running operation. an issue was filed on swagger: https://github.com/Azure/azure-rest-api-specs/issues/16508
- from: swagger-document
  where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}'].put
  transform: >
    $.responses['202'] = {
        'description': 'Creation of notebook workspace will complete asynchronously.'
    };
- from: rbac.json
  where: $.definitions
  transform: >
    $.SqlRoleDefinitionResource.properties.type['x-ms-client-name'] = 'RoleDefinitionType';
    $.SqlRoleAssignmentResource.properties.roleDefinitionId['x-ms-format'] = 'arm-id';
- from: managedCassandra.json
  where: $.definitions
  transform: >
    $.CassandraClusterPublicStatus.properties.dataCenters.items.properties.nodes.items['x-ms-client-name'] = 'CassandraClusterDataCenterNodeItem';
- from: swagger-document
  where: $.definitions.._ts
  transform: >
    $['x-ms-client-name'] = 'Timestamp';
- from: privateEndpointConnection.json
  where: $.definitions.PrivateEndpointProperty
  transform: >
    $.properties.id['x-ms-format'] = 'arm-id';
- from: restorable.json
  where: $.definitions.ContinuousBackupInformation
  transform: >
    $.properties.latestRestorableTimestamp['format'] = 'date-time';
- from: restorable.json
  where: $.parameters
  transform: >
    $.restoreLocationParameter['x-ms-format'] = 'azure-location';
    $.instanceIdParameter['format'] = 'uuid';
- from: managedCassandra.json
  where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/invokeCommandAsync']
  transform: >
    for (var path in $)
    {
        delete $[path];
    }
- from: managedCassandra.json
  where: $.definitions.CommandPostBody
  transform: >
    $.properties.arguments['additionalProperties'] = {
        'type':'string'
    };
# Below is a workaround for ADO 6196
- remove-operation:
  - DatabaseAccounts_GetReadOnlyKeys
# rename for CSharp naming convention
- rename-model:
    from: LocationGetResult
    to: CosmosDBLocation
- rename-model:
    from: DatabaseAccountGetResults
    to: CosmosDBAccount
- rename-model:
    from: ThroughputSettingsGetResults
    to: ThroughputSettings
- rename-model:
    from: ThroughputSettingsGetProperties
    to: ThroughputSettingsProperties
- rename-model:
    from: SqlDatabaseGetResults
    to: CosmosDBSqlDatabase
- rename-model:
    from: SqlDatabaseGetProperties
    to: CosmosDBSqlDatabaseProperties
- rename-model:
    from: SqlContainerGetResults
    to: CosmosDBSqlContainer
- rename-model:
    from: SqlContainerGetProperties
    to: CosmosDBSqlContainerProperties
- rename-model:
    from: SqlStoredProcedureGetResults
    to: CosmosDBSqlStoredProcedure
- rename-model:
    from: SqlStoredProcedureGetProperties
    to: CosmosDBSqlStoredProcedureProperties
- rename-model:
    from: SqlUserDefinedFunctionGetResults
    to: CosmosDBSqlUserDefinedFunction
- rename-model:
    from: SqlUserDefinedFunctionGetProperties
    to: CosmosDBSqlUserDefinedFunctionProperties
- rename-model:
    from: SqlTriggerGetResults
    to: CosmosDBSqlTrigger
- rename-model:
    from: SqlTriggerGetProperties
    to: CosmosDBSqlTriggerProperties
- rename-model:
    from: MongoDBDatabaseGetResults
    to: MongoDBDatabase
- rename-model:
    from: MongoDBDatabaseGetProperties
    to: MongoDBDatabaseProperties
- rename-model:
    from: MongoDBCollectionGetResults
    to: MongoDBCollection
- rename-model:
    from: MongoDBCollectionGetProperties
    to: MongoDBCollectionProperties
- rename-model:
    from: TableGetResults
    to: CosmosDBTable
- rename-model:
    from: TableGetProperties
    to: CosmosDBTableProperties
- rename-model:
    from: CassandraKeyspaceGetResults
    to: CassandraKeyspace
- rename-model:
    from: CassandraKeyspaceGetProperties
    to: CassandraKeyspaceProperties
- rename-model:
    from: CassandraTableGetResults
    to: CassandraTable
- rename-model:
    from: CassandraTableGetProperties
    to: CassandraTableProperties
- rename-model:
    from: GremlinDatabaseGetResults
    to: GremlinDatabase
- rename-model:
    from: GremlinDatabaseGetProperties
    to: GremlinDatabaseProperties
- rename-model:
    from: GremlinGraphGetResults
    to: GremlinGraph
- rename-model:
    from: GremlinGraphGetProperties
    to: GremlinGraphProperties
- rename-model:
    from: DatabaseAccountGetProperties
    to: CosmosDBAccountProperties
- rename-model:
    from: DatabaseAccountListReadOnlyKeysResult
    to: CosmosDBAccountReadOnlyKeyList
- rename-model:
    from: DatabaseAccountListKeysResult
    to: CosmosDBAccountKeyList
- rename-model:
    from: SqlRoleAssignmentListResult
    to: CosmosDBSqlRoleAssignmentList
- rename-model:
    from: SqlRoleDefinitionListResult
    to: CosmosDBSqlRoleDefinitionList
- rename-model:
    from: SqlRoleDefinitionGetResults
    to: CosmosDBSqlRoleDefinition
- rename-model:
    from: SqlRoleAssignmentGetResults
    to: CosmosDBSqlRoleAssignment
- rename-model:
    from: RestorableDatabaseAccountGetResult
    to: RestorableCosmosDBAccount
- rename-model:
    from: RestorableSqlDatabaseGetResult
    to: RestorableSqlDatabase
- rename-model:
    from: RestorableSqlContainerGetResult
    to: RestorableSqlContainer
- rename-model:
    from: RestorableMongodbDatabaseGetResult
    to: RestorableMongoDBDatabase
- rename-model:
    from: RestorableGremlinDatabaseGetResult
    to: RestorableGremlinDatabase
- rename-model:
    from: RestorableGremlinGraphGetResult
    to: RestorableGremlinGraph
- rename-model:
    from: RestorableTableGetResult
    to: RestorableTable
- rename-model:
    from: KeyWrapMetadata
    to: CosmosDBKeyWrapMetadata
# same as `Metric`
- rename-model:
    from: Metric
    to: CosmosDBBaseMetric
# `Location` is single word and we already have a common type `Location`
- rename-model:
    from: Location
    to: CosmosDBAccountLocation
# `Capability` is single word
- rename-model:
    from: Capability
    to: CosmosDBAccountCapability
# `Indexes` is single word
- rename-model:
    from: Indexes
    to: CosmosDBPathIndexes
# `Column` is a single workd, and it's only used in CassandraSchema
- rename-model:
    from: Column
    to: CassandraColumn
# Rename for input parameters s/Parameters/Data/, per C# convention
# rename parametes for cosmos-db.json
- rename-model:
    from: DatabaseAccountRegenerateKeyParameters
    to: CosmosDBAccountRegenerateKeyInfo
- rename-model:
    from: ThroughputSettingsUpdateParameters
    to: ThroughputSettingsUpdateData
- rename-model:
    from: SqlDatabaseCreateUpdateParameters
    to: CosmosDBSqlDatabaseCreateUpdateData
- rename-model:
    from: SqlContainerCreateUpdateParameters
    to: CosmosDBSqlContainerCreateUpdateData
- rename-model:
    from: SqlStoredProcedureCreateUpdateParameters
    to: CosmosDBSqlStoredProcedureCreateUpdateData
- rename-model:
    from: SqlUserDefinedFunctionCreateUpdateParameters
    to: CosmosDBSqlUserDefinedFunctionCreateUpdateData
- rename-model:
    from: SqlTriggerCreateUpdateParameters
    to: CosmosDBSqlTriggerCreateUpdateData
- rename-model:
    from: MongoDBDatabaseCreateUpdateParameters
    to: MongoDBDatabaseCreateUpdateData
- rename-model:
    from: MongoDBCollectionCreateUpdateParameters
    to: MongoDBCollectionCreateUpdateData
- rename-model:
    from: TableCreateUpdateParameters
    to: CosmosDBTableCreateUpdateData
- rename-model:
    from: CassandraKeyspaceCreateUpdateParameters
    to: CassandraKeyspaceCreateUpdateData
- rename-model:
    from: GremlinDatabaseCreateUpdateParameters
    to: GremlinDatabaseCreateUpdateData
- rename-model:
    from: GremlinGraphCreateUpdateParameters
    to: GremlinGraphCreateUpdateData
- rename-model:
    from: SqlRoleAssignmentCreateUpdateParameters
    to: CosmosDBSqlRoleAssignmentCreateUpdateData
- rename-model:
    from: SqlRoleDefinitionCreateUpdateParameters
    to: CosmosDBSqlRoleDefinitionCreateUpdateData

```
