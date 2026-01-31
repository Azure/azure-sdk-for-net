# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

## Code Generation Configuration

```yaml
azure-arm: true
csharp: true
library-name: CosmosDB
namespace: Azure.ResourceManager.CosmosDB
require: https://github.com/Azure/azure-rest-api-specs/blob/60bcde388a845febb60fc2bda17983ca59af219a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/readme.md
tag: package-2025-10-15
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
  AccountKeyMetadata.generationTime: GeneratedOn
  AuthenticationMethod: CassandraAuthenticationMethod
  AutoReplicate: CassandraAutoReplicateForm
  AutoscaleSettingsResource: AutoscaleSettingsResourceInfo
  AutoUpgradePolicyResource: AutoUpgradePolicyResourceInfo
  AzureConnectionType: ServiceConnectionType
  BackupPolicy: CosmosDBAccountBackupPolicy
  BackupResource: CassandraClusterBackupResourceInfo
  BackupSchedule: CassandraClusterBackupSchedule
  BackupState: CassandraClusterBackupState
  BackupStorageRedundancy: CosmosDBBackupStorageRedundancy
  Capacity: CosmosDBAccountCapacity
  CassandraKeyspacePropertiesOptions: CassandraKeyspacePropertiesConfig
  CassandraKeyspacePropertiesResource: ExtendedCassandraKeyspaceResourceInfo
  CassandraKeyspaceResource: CassandraKeyspaceResourceInfo
  CassandraKeyspaceResource.id: KeyspaceName
  CassandraTablePropertiesOptions: CassandraTablePropertiesConfig
  CassandraTablePropertiesResource: ExtendedCassandraTableResourceInfo
  CassandraTableResource: CassandraTableResourceInfo
  CassandraTableResource.id: TableName
  Certificate: CassandraCertificate
  CheckNameAvailabilityReason: CosmosDBNameUnavailableReason
  CheckNameAvailabilityRequest: CheckCosmosDBNameAvailabilityContent
  CheckNameAvailabilityResponse: CheckCosmosDBNameAvailabilityResponse
  ClientEncryptionIncludedPath: CosmosDBClientEncryptionIncludedPath
  ClientEncryptionKeyGetPropertiesResource: CosmosDBSqlClientEncryptionKeyProperties
  ClientEncryptionKeyGetResults: CosmosDBSqlClientEncryptionKey
  ClientEncryptionKeyResource: CosmosDBSqlClientEncryptionKeyResourceInfo
  ClientEncryptionPolicy: CosmosDBClientEncryptionPolicy
  ClusterKey: CassandraClusterKey
  ClusterResource: CassandraCluster
  ClusterResourceProperties: CassandraClusterProperties
  ClusterResourceProperties.cassandraAuditLoggingEnabled: IsCassandraAuditLoggingEnabled
  ClusterResourceProperties.deallocated : IsDeallocated
  ClusterResourceProperties.privateLinkResourceId: -|arm-id
  ClusterResourceProperties.repairEnabled: IsRepairEnabled
  ClusterType: CassandraClusterType
  CommandOutput: CassandraCommandOutput
  CommandPostBody: CassandraCommandPostBody
  CommandPostBody.readwrite: AllowWrite
  CommandPublicResource: CassandraClusterCommand
  CommandStatus: CassandraClusterCommandStatus
  ConnectionError: CassandraConnectionError
  ConnectionState: CassandraConnectionState
  ContainerPartitionKey.systemKey: IsSystemKey
  CorsPolicy: CosmosDBAccountCorsPolicy
  CosmosDBAccount.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  CosmosDBAccount.properties.enableFreeTier: IsFreeTierEnabled
  CosmosDBSqlContainerPropertiesOptions: CosmosDBSqlContainerPropertiesConfig
  CosmosDBSqlContainerPropertiesResource: ExtendedCosmosDBSqlContainerResourceInfo
  CosmosDBSqlDatabasePropertiesOptions: CosmosDBSqlDatabasePropertiesConfig
  CosmosDBSqlDatabasePropertiesResource: ExtendedCosmosDBSqlDatabaseResourceInfo
  CosmosDBSqlStoredProcedurePropertiesResource: ExtendedCosmosDBSqlStoredProcedureResourceInfo
  CosmosDBSqlTriggerPropertiesResource: ExtendedCosmosDBSqlTriggerResourceInfo
  CosmosDBSqlUserDefinedFunctionPropertiesResource: ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo
  CreateMode: CosmosDBAccountCreateMode
  CreateUpdateOptions: CosmosDBCreateUpdateConfig
  DatabaseAccountConnectionString: CosmosDBAccountConnectionString
  DatabaseAccountCreateUpdateParameters.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  DatabaseAccountCreateUpdateParameters.properties.enableFreeTier: IsFreeTierEnabled
  DatabaseAccountKind: CosmosDBAccountKind
  DatabaseAccountOfferType: CosmosDBAccountOfferType
  DatabaseAccountUpdateParameters.properties.enableAnalyticalStorage: IsAnalyticalStorageEnabled
  DatabaseAccountUpdateParameters.properties.enableFreeTier: IsFreeTierEnabled
  DatabaseRestoreResource: DatabaseRestoreResourceInfo
  DataCenterResource: CassandraDataCenter
  DataCenterResourceProperties: CassandraDataCenterProperties
  DataCenterResourceProperties.availabilityZone: DoesSupportAvailabilityZone
  DataTransferRegionalServiceResource: DataTransferRegionalService
  DataTransferServiceResourceProperties: DataTransferServiceProperties
  DistanceFunction: VectorDistanceFunction
  FleetResource: CosmosDBFleet
  FleetspaceAccountPropertiesGlobalDatabaseAccountProperties: CosmosDBFleetspaceAccountConfiguration
  FleetspaceAccountPropertiesGlobalDatabaseAccountProperties.armLocation: -|azure-location
  FleetspaceAccountPropertiesGlobalDatabaseAccountProperties.resourceId: -|arm-id
  FleetspaceAccountResource: CosmosDBFleetspaceAccount
  FleetspacePropertiesFleetspaceApiKind: CosmosDBFleetspaceApiKind
  FleetspacePropertiesServiceTier: CosmosDBFleetspaceServiceTier
  FleetspacePropertiesThroughputPoolConfiguration: CosmosDBFleetspaceThroughputPoolConfiguration
  FleetspaceResource: CosmosDBFleetspace
  FleetspaceResource.properties.dataRegions: -|azure-location
  GraphAPIComputeRegionalServiceResource: GraphApiComputeRegionalService
  GraphAPIComputeServiceResourceProperties: GraphApiComputeServiceProperties
  GremlinDatabasePropertiesOptions: GremlinDatabasePropertiesConfig
  GremlinDatabasePropertiesResource: ExtendedGremlinDatabaseResourceInfo
  GremlinDatabaseResource: GremlinDatabaseResourceInfo
  GremlinDatabaseResource.id: DatabaseName
  GremlinDatabaseRestoreResource: GremlinDatabaseRestoreResourceInfo
  GremlinGraphPropertiesOptions: GremlinGraphPropertiesConfig
  GremlinGraphPropertiesResource: ExtendedGremlinGraphResourceInfo
  GremlinGraphResource: GremlinGraphResourceInfo
  GremlinGraphResource.id: GraphName
  IndexingPolicy.automatic: IsAutomatic
  IpAddressOrRange: CosmosDBIPAddressOrRange
  KeyKind: CosmosDBAccountKeyKind
  ListClusters: CassandraClusterListResult
  ListDataCenters: CassandraDataCenterListResult
  LocationProperties.supportsAvailabilityZone: DoesSupportAvailabilityZone
  ManagedCassandraProvisioningState: CassandraProvisioningState
  ManagedCassandraReaperStatus: CassandraReaperStatus
  ManagedCassandraReaperStatus.healthy: IsHealthy
  MaterializedViewsBuilderRegionalServiceResource: MaterializedViewsBuilderRegionalService
  MaterializedViewsBuilderServiceResourceProperties: MaterializedViewsBuilderServiceProperties
  MinimalTlsVersion: CosmosDBMinimalTlsVersion
  MongoDBCollectionPropertiesOptions: MongoDBCollectionPropertiesConfig
  MongoDBCollectionPropertiesResource: ExtendedMongoDBCollectionResourceInfo
  MongoDBCollectionResource: MongoDBCollectionResourceInfo
  MongoDBCollectionResource.id: CollectionName
  MongoDBDatabasePropertiesOptions: MongoDBDatabasePropertiesConfig
  MongoDBDatabasePropertiesResource: ExtendedMongoDBDatabaseResourceInfo
  MongoDBDatabaseResource: MongoDBDatabaseResourceInfo
  MongoDBDatabaseResource.id: DatabaseName
  MongoIndex: MongoDBIndex
  MongoIndexOptions: MongoDBIndexConfig
  MongoIndexOptions.unique: IsUnique
  MongoRoleDefinitionGetResults: MongoDBRoleDefinition
  MongoRoleDefinitionGetResults.properties.type: RoleDefinitionType
  MongoRoleDefinitionListResult: MongoDBRoleDefinitionListResult
  MongoRoleDefinitionType: MongoDBRoleDefinitionType
  MongoUserDefinitionGetResults: MongoDBUserDefinition
  MongoUserDefinitionListResult: MongoDBUserDefinitionListResult
  NodeGroupProperties.diskSizeGB: DiskSizeInGB
  NodeState: CassandraNodeState
  OptionsResource: CosmosDBBaseConfig
  PrimaryAggregationType: CosmosDBMetricPrimaryAggregationType
  Privilege: MongoDBPrivilege
  PrivilegeResource: MongoDBPrivilegeResourceInfo
  PrivilegeResource.db: DBName
  RegionalServiceResource: CosmosDBRegionalService
  RestorableGremlinDatabasePropertiesResource: ExtendedRestorableGremlinDatabaseResourceInfo
  RestorableGremlinDatabasePropertiesResource.ownerId: DatabaseName
  RestorableGremlinDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableGremlinGraphPropertiesResource: ExtendedRestorableGremlinGraphResourceInfo
  RestorableGremlinGraphPropertiesResource.ownerId: GraphName
  RestorableGremlinGraphPropertiesResource.ownerResourceId: GraphId
  RestorableGremlinResourcesGetResult : RestorableGremlinResourceData
  RestorableLocationResource: RestorableLocationResourceInfo
  RestorableMongodbCollectionGetResult: RestorableMongoDBCollection
  RestorableMongodbCollectionPropertiesResource: ExtendedRestorableMongoDBCollectionResourceInfo
  RestorableMongodbCollectionPropertiesResource.ownerId: CollectionName
  RestorableMongodbCollectionPropertiesResource.ownerResourceId: CollectionId
  RestorableMongodbDatabasePropertiesResource: ExtendedRestorableMongoDBDatabaseResourceInfo
  RestorableMongodbDatabasePropertiesResource.ownerId: DatabaseName
  RestorableMongodbDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableMongodbResourcesGetResult: RestorableMongoDBResourceData
  RestorableSqlContainerPropertiesResource: ExtendedRestorableSqlContainerResourceInfo
  RestorableSqlContainerPropertiesResource.ownerId: ContainerName
  RestorableSqlContainerPropertiesResource.ownerResourceId: ContainerId
  RestorableSqlDatabasePropertiesResource: ExtendedRestorableSqlDatabaseResourceInfo
  RestorableSqlDatabasePropertiesResource.ownerId: DatabaseName
  RestorableSqlDatabasePropertiesResource.ownerResourceId: DatabaseId
  RestorableSqlResourcesGetResult: RestorableSqlResourceData
  RestorableTablePropertiesResource: ExtendedRestorableTableResourceInfo
  RestorableTablePropertiesResource.ownerId: TableName
  RestorableTablePropertiesResource.ownerResourceId: TableId
  RestorableTableResourcesGetResult: RestorableTableResourceData
  RestoreMode: CosmosDBAccountRestoreMode
  RestoreParameters: CosmosDBAccountRestoreParameters
  RestoreParametersBase.restoreWithTtlDisabled: IsRestoreWithTtlDisabled
  Role: MongoDBRole
  Role.db: DBName
  RoleDefinitionType: CosmosDBSqlRoleDefinitionType
  SeedNode: CassandraDataCenterSeedNode
  ServiceResource: CosmosDBService
  ServiceResourceCreateUpdateParameters: CosmosDBServiceCreateUpdateParameters
  ServiceResourceListResult: CosmosDBServiceListResult
  ServiceResourceProperties: CosmosDBServiceProperties
  ServiceSize: CosmosDBServiceSize
  ServiceStatus: CosmosDBServiceStatus
  ServiceType: CosmosDBServiceType
  SqlContainerListResult: CosmosDBSqlContainerListResult
  SqlContainerResource: CosmosDBSqlContainerResourceInfo
  SqlContainerResource.id: containerName
  SqlDatabaseListResult: CosmosDBSqlDatabaseListResult
  SqlDatabaseResource: CosmosDBSqlDatabaseResourceInfo
  SqlDatabaseResource.id: DatabaseName
  SqlDedicatedGatewayRegionalServiceResource: SqlDedicatedGatewayRegionalService
  SqlDedicatedGatewayServiceResourceProperties: SqlDedicatedGatewayServiceProperties
  SqlStoredProcedureListResult: CosmosDBSqlStoredProcedureListResult
  SqlStoredProcedureResource: CosmosDBSqlStoredProcedureResourceInfo
  SqlStoredProcedureResource.id: StoredProcedureName
  SqlTriggerListResult: CosmosDBSqlTriggerListResult
  SqlTriggerResource: CosmosDBSqlTriggerResourceInfo
  SqlTriggerResource.id: TriggerName
  SqlUserDefinedFunctionListResult: CosmosDBSqlUserDefinedFunctionListResult
  SqlUserDefinedFunctionResource: CosmosDBSqlUserDefinedFunctionResourceInfo
  SqlUserDefinedFunctionResource.id: FunctionName
  TableListResult: CosmosDBTableListResult
  TableResource: CosmosDBTableResourceInfo
  TableResource.id: TableName
  TableRoleAssignmentResource: CosmosDBTableRoleAssignment
  TableRoleAssignmentResource.properties.roleDefinitionId: -|arm-id
  TableRoleAssignmentResource.properties.scope: -|arm-id
  TableRoleDefinitionResource: CosmosDBTableRoleDefinition
  TableRoleDefinitionResource.properties.id: PathId
  TableRoleDefinitionResource.properties.type: RoleDefinitionType
  ThroughputBucketResource: CosmosDBThroughputBucket
  ThroughputPolicyResource: ThroughputPolicyResourceInfo
  ThroughputPoolAccountResource: CosmosDBThroughputPoolAccount
  ThroughputPoolAccountResource.properties.accountLocation: -|azure-location
  ThroughputPoolAccountResource.properties.accountResourceIdentifier: -|arm-id
  ThroughputPoolResource: CosmosDBThroughputPool
  ThroughputSettingsPropertiesResource: ExtendedThroughputSettingsResourceInfo
  ThroughputSettingsResource: ThroughputSettingsResourceInfo
  TriggerOperation: CosmosDBSqlTriggerOperation
  TriggerType: CosmosDBSqlTriggerType
  UnitType: CosmosDBMetricUnitType
  Usage: CosmosDBBaseUsage
  VectorDataType: CosmosDBVectorDataType
  VectorEmbedding: CosmosDBVectorEmbedding
  VectorIndex: CosmosDBVectorIndex
  VectorIndexType: CosmosDBVectorIndexType
  VectorIndexType.diskANN: DiskAnn

prepend-rp-prefix:
- ApiType
- BackupInformation
- ChaosFaultResource
- CompositePath
- ConnectionString
- ContainerPartitionKey
- DataType
- ExcludedPath
- FailoverPolicies
- FailoverPolicy
- FirewallRule
- IncludedPath
- IndexingMode
- IndexingPolicy
- IndexKind
- LocationListResult
- LocationProperties
- MetricAvailability
- MetricDefinition
- MetricDefinitionsListResult
- MetricListResult
- MetricName
- MetricValue
- OperationType
- PartitionKind
- PercentileMetric
- ProvisioningState
- PublicNetworkAccess
- ServerVersion
- SpatialType
- Status
- Type
- UniqueKey
- UniqueKeyPolicy
- UsagesResult
- VirtualNetworkRule

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
- from: cosmos-db.json
  where: $.definitions
  transform: >
    $.ErrorResponse['x-ms-client-name'] = 'CosmosDBErrorResult';
# Managed Cassandra
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
- from: managedCassandra.json
  where: $.definitions
  transform: >
    $.CommandPublicResource.properties.cassandraStopStart["x-ms-client-name"] = "shouldStopCassandraBeforeStart";
    $.CommandPublicResource.properties.readWrite["x-ms-client-name"] = "isReadWrite";
- from: chaosFault.json
  where: $.definitions
  transform: >
    $.chaosFaultProperties.properties.action['x-ms-client-name'] = "CosmosDBChaosFaultSupportedActions";
    $.chaosFaultProperties.properties.action['x-ms-enum']['name'] = "CosmosDBChaosFaultSupportedActions";
- from: rbac.json
  where: $.definitions
  transform: >
    $.Permission['x-ms-client-name'] = "CosmosDBSqlRolePermission";
- from: tablerbac.json
  where: $.definitions
  transform: >
    $.Permission['x-ms-client-name'] = "CosmosDBTableRolePermission";

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
