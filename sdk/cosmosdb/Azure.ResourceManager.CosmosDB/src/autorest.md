# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

## Code Generation Configuration

```yaml
azure-arm: true
csharp: true
library-name: CosmosDB
namespace: Azure.ResourceManager.CosmosDB
require: https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/readme.md
tag: package-2021-10-csharp
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
model-namespae: true

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
no-property-type-replacement: CosmosDBSqlDatabaseResourceInfo;MongoDBDatabaseResourceInfo;CosmosTableResourceInfo;CassandraKeyspaceResourceInfo;CassandraColumn;GremlinDatabaseResourceInfo;PrivateEndpointProperty

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'principalId': 'uuid'
  '*SubnetId': 'arm-id'
  'networkAclBypassResourceIds': 'arm-id'

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
  Mongodb: MongoDB
override-operation-name:
  RestorableMongodbDatabases_List: GetRestorableMongoDBDatabases
  RestorableMongodbCollections_List: GetRestorableMongoDBCollections
  RestorableMongodbResources_List: GetRestorableMongoDBResources
rename-mapping:
  SqlRoleDefinitionResource: CosmosDBSqlRoleDefinitionResourceInfo
  CassandraKeyspacePropertiesOptions: CassandraKeyspacePropertiesConfig
  CassandraTablePropertiesOptions: CassandraTablePropertiesConfig
  CosmosTablePropertiesOptions: CosmosTablePropertiesConfig
  CreateUpdateOptions: CosmosDBCreateUpdateConfig
  GremlinDatabasePropertiesOptions: GremlinDatabasePropertiesConfig
  GremlinGraphPropertiesOptions: GremlinGraphPropertiesConfig
  MongoDBCollectionPropertiesOptions: MongoDBCollectionPropertiesConfig
  MongoDBDatabasePropertiesOptions: MongoDBDatabasePropertiesConfig
  MongoIndexOptions: MongoIndexConfig
  CosmosDBSqlContainerPropertiesOptions: CosmosDBSqlContainerPropertiesConfig
  CosmosDBSqlDatabasePropertiesOptions: CosmosDBSqlDatabasePropertiesConfig
  CosmosDBSqlDatabasePropertiesResource: ExtendedCosmosDBSqlDatabaseResourceInfo
  AutoscaleSettingsResource: AutoscaleSettingsResourceInfo
  CassandraKeyspacePropertiesResource: ExtendedCassandraKeyspaceResourceInfo
  CassandraKeyspaceResource: CassandraKeyspaceResourceInfo
  CassandraTablePropertiesResource: ExtendedCassandraTableResourceInfo
  CassandraTableResource: CassandraTableResourceInfo
  CosmosTablePropertiesResource: ExtendedCosmosTableResourceInfo
  DatabaseRestoreResource: DatabaseRestoreResourceInfo
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
  CosmosDBSqlContainerPropertiesResource: ExtendedCosmosDBSqlContainerResourceInfo
  SqlContainerResource: CosmosDBSqlContainerResourceInfo
  SqlDatabaseResource: CosmosDBSqlDatabaseResourceInfo
  SqlStoredProcedurePropertiesResource: ExtendedCosmosDBSqlStoredProcedureResourceInfo
  SqlStoredProcedureResource: CosmosDBSqlStoredProcedureResourceInfo
  SqlTriggerResource: CosmosDBSqlTriggerResourceInfo
  CosmosDBSqlTriggerPropertiesResource: ExtendedCosmosDBSqlTriggerResourceInfo
  SqlUserDefinedFunctionPropertiesResource: ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo
  SqlUserDefinedFunctionResource: CosmosDBSqlUserDefinedFunctionResourceInfo
  TableResource: CosmosTableResourceInfo
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
  TableListResult: CosmosTableListResult
  TriggerOperation: CosmosDBSqlTriggerOperation
  TriggerType: CosmosDBSqlTriggerType
  UnitType: CosmosDBMetricUnitType
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
- IPAddressOrRange
- DataType
- IndexingPolicy
- ExcludedPath
- IncludedPath
- IndexingMode
- IndexKind
- ApiType
- UsagesResult
- VirtualNetworkRule
directive:
- from: cosmos-db.json
  where: $.definitions.MetricDefinition.properties.resourceUri
  transform: >
    $["x-ms-client-name"] = "ResourceId";
    $["x-ms-format"] = "arm-id";
# Below is a workaround for ADO 6196
- remove-operation:
  - DatabaseAccounts_GetReadOnlyKeys
# rename bad model names
- rename-model:
    from: NotebookWorkspaceConnectionInfoResult
    to: NotebookWorkspaceConnectionInfo
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
    to: CosmosTable
- rename-model:
    from: TableGetProperties
    to: CosmosTableProperties
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
# This API is returning a collection wrapping by the model 'DatabaseAccountListConnectionStringsResult', adding this directive so that the content could be automatically flattened
- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/listConnectionStrings"].post
  transform: >
    $["x-ms-pageable"] = {
          "nextLinkName": null,
          "itemName": "connectionStrings"
        }
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
# rename for CSharp naming convention
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
    to: TableCreateUpdateData
- rename-model:
    from: CassandraKeyspaceCreateUpdateParameters
    to: CassandraKeyspaceCreateUpdateData
- rename-model:
    from: CassandraTableCreateUpdateParameters
    to: CassandraTableCreateUpdateData
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
# TODO: rename for notebook.json when adding it back

# add a missing response code for long running operation. an issue was filed on swagger: https://github.com/Azure/azure-rest-api-specs/issues/16508
- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}"].put
  transform: >
    $.responses["202"] = {
        "description": "Creation of notebook workspace will complete asynchronously."
    };
- from: swagger-document
  where: $.definitions..creationTime
  transform: >
    $['x-ms-client-name'] = 'CreatedOn';
- from: swagger-document
  where: $.definitions..deletionTime
  transform: >
    $['x-ms-client-name'] = 'DeletedOn';
- from: rbac.json
  where: $.definitions.SqlRoleDefinitionResource
  transform: >
    $.properties.type['x-ms-client-name'] = 'RoleDefinitionType';
- from: managedCassandra.json
  where: $.definitions.CassandraClusterPublicStatus
  transform: >
    $.properties.dataCenters.items.properties.nodes.items['x-ms-client-name'] = 'CassandraClusterDataCenterNodeItem';
- from: swagger-document
  where: $.definitions.._ts
  transform: >
    $['x-ms-client-name'] = 'Timestamp';
- from: privateEndpointConnection.json
  where: $.definitions.PrivateEndpointProperty
  transform: >
    $.properties.id['x-ms-format'] = 'arm-id';
- from: rbac.json
  where: $.definitions.SqlRoleAssignmentResource
  transform: >
    $.properties.roleDefinitionId['x-ms-format'] = 'arm-id';
- from: restorable.json
  where: $.definitions.ContinuousBackupInformation
  transform: >
    $.properties.latestRestorableTimestamp['format'] = 'date-time';
```

### Tag: package-2021-10-csharp

These settings apply only when `--tag=package-2021-10-csharp` is specified on the command line. We have to remove the following files:

- `notebook.json`: that feature is offline due to security issues

```yaml $(tag) == 'package-2021-10-csharp'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/restorable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/managedCassandra.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8a2a6226c3ac5a882f065a66daeaf5acef334273/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-10-15/rbac.json
```
