# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

## Code Generation Configuration

```yaml
azure-arm: true
csharp: true
library-name: CosmosDB
skip-csproj: true
namespace: Azure.ResourceManager.CosmosDB
require: https://github.com/Azure/azure-rest-api-specs/blob/5405df1424664d1c6ef9cdcda426eb85e59a02cc/specification/cosmos-db/resource-manager/readme.md
tag: package-2021-06-csharp
output-folder: Generated/
clear-output-folder: true
flatten-payloads: false
model-namespae: true
modelerfour:
  lenient-model-deduplication: true
mgmt-debug:
  suppress-list-exception: true

no-property-type-replacement: SqlDatabaseResource;MongoDBDatabaseResource;TableResource;CassandraKeyspaceResource;CassandraColumn;GremlinDatabaseResource;PrivateEndpointProperty
directive:
# Below is a workaround for ADO 6196
- remove-operation:
  - DatabaseAccounts_GetReadOnlyKeys
# rename bad model names
- rename-model:
    from: PrivateEndpointConnectionListResult
    to: PrivateEndpointConnectionList
- rename-model:
    from: NotebookWorkspaceListResult
    to: NotebookWorkspaceList
- rename-model:
    from: NotebookWorkspaceConnectionInfoResult
    to: NotebookWorkspaceConnectionInfo
- rename-model:
    from: DatabaseAccountsListResult
    to: DatabaseAccountsList
- rename-model:
    from: SqlDatabaseListResult
    to: SqlDatabaseList
- rename-model:
    from: SqlContainerListResult
    to: SqlContainerList
- rename-model:
    from: SqlStoredProcedureListResult
    to: SqlStoredProcedureList
- rename-model:
    from: SqlUserDefinedFunctionListResult
    to: SqlUserDefinedFunctionList
- rename-model:
    from: SqlTriggerListResult
    to: SqlTriggerList
- rename-model:
    from: MongoDBDatabaseListResult
    to: MongoDBDatabaseList
- rename-model:
    from: MongoDBCollectionListResult
    to: MongoDBCollectionList
- rename-model:
    from: TableListResult
    to: TableList
- rename-model:
    from: CassandraKeyspaceListResult
    to: CassandraKeyspaceList
- rename-model:
    from: CassandraTableListResult
    to: CassandraTableList
- rename-model:
    from: GremlinDatabaseListResult
    to: GremlinDatabaseList
- rename-model:
    from: GremlinGraphListResult
    to: GremlinGraphList
- rename-model:
    from: DatabaseAccountGetResults
    to: DatabaseAccount
- rename-model:
    from: ThroughputSettingsGetResults
    to: ThroughputSettings
- rename-model:
    from: ThroughputSettingsGetProperties
    to: ThroughputSettingsProperties
- rename-model:
    from: SqlDatabaseGetResults
    to: SqlDatabase
- rename-model:
    from: SqlDatabaseGetProperties
    to: SqlDatabaseProperties
- rename-model:
    from: SqlContainerGetResults
    to: SqlContainer
- rename-model:
    from: SqlContainerGetProperties
    to: SqlContainerProperties
- rename-model:
    from: SqlStoredProcedureGetResults
    to: SqlStoredProcedure
- rename-model:
    from: SqlStoredProcedureGetProperties
    to: SqlStoredProcedureProperties
- rename-model:
    from: SqlUserDefinedFunctionGetResults
    to: SqlUserDefinedFunction
- rename-model:
    from: SqlUserDefinedFunctionGetProperties
    to: SqlUserDefinedFunctionProperties
- rename-model:
    from: SqlTriggerGetResults
    to: SqlTrigger
- rename-model:
    from: SqlTriggerGetProperties
    to: SqlTriggerProperties
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
    to: DatabaseAccountProperties
- rename-model:
    from: DatabaseAccountListReadOnlyKeysResult
    to: DatabaseAccountReadOnlyKeyList
- rename-model:
    from: DatabaseAccountListKeysResult
    to: DatabaseAccountKeyList
- rename-model:
    from: DatabaseAccountListConnectionStringsResult
    to: DatabaseAccountConnectionStringList
- rename-model:
    from: OperationListResult
    to: OperationList
- rename-model:
    from: UsagesResult
    to: UsageList
- rename-model:
    from: PartitionUsagesResult
    to: PartitionUsageList
- rename-model:
    from: MetricDefinitionsListResult
    to: MetricDefinitionList
- rename-model:
    from: MetricListResult
    to: MetricList
- rename-model:
    from: PercentileMetricListResult
    to: PercentileMetricList
- rename-model:
    from: PartitionMetricListResult
    to: PartitionMetricList
- rename-model:
    from: PrivateLinkResourceListResult
    to: PrivateLinkResourceList
- rename-model:
    from: SqlRoleDefinitionGetResults
    to: SqlRoleDefinition
- rename-model:
    from: SqlRoleDefinitionListResult
    to: SqlRoleDefinitionList
- rename-model:
    from: SqlRoleAssignmentGetResults
    to: SqlRoleAssignment
- rename-model:
    from: SqlRoleAssignmentListResult
    to: SqlRoleAssignmentList
- rename-model:
    from: RestorableDatabaseAccountsListResult
    to: RestorableDatabaseAccountsList
- rename-model:
    from: RestorableDatabaseAccountGetResult
    to: RestorableDatabaseAccount
- rename-model:
    from: RestorableSqlDatabasesListResult
    to: RestorableSqlDatabasesList
- rename-model:
    from: RestorableSqlDatabaseGetResult
    to: RestorableSqlDatabase
- rename-model:
    from: RestorableSqlContainersListResult
    to: RestorableSqlContainersList
- rename-model:
    from: RestorableSqlContainerGetResult
    to: RestorableSqlContainer
- rename-model:
    from: RestorableSqlResourcesListResult
    to: RestorableSqlResourcesList
- rename-model:
    from: RestorableMongodbDatabasesListResult
    to: RestorableMongodbDatabasesList
- rename-model:
    from: RestorableMongodbDatabaseGetResult
    to: RestorableMongodbDatabase
- rename-model:
    from: RestorableMongodbCollectionsListResult
    to: RestorableMongodbCollectionsList
- rename-model:
    from: RestorableMongodbCollectionGetResult
    to: RestorableMongodbCollection
- rename-model:
    from: RestorableMongodbResourcesListResult
    to: RestorableMongodbResourcesList
# rename for CSharp naming convention
# `Usage` is used in a few places which are not specific to one type of resources, and it has a child definition `PartitionUsage`.
- rename-model:
    from: Usage
    to: BaseUsage
# same as `Metric`
- rename-model:
    from: Metric
    to: BaseMetric
# `Location` is single word and we already have a common type `Location`
- rename-model:
    from: Location
    to: DatabaseAccountLocation
# `Capability` is single word
- rename-model:
    from: Capability
    to: DatabaseAccountCapability
# `Indexes` is single word
- rename-model:
    from: Indexes
    to: PathIndexes
# `Column` is a single workd, and it's only used in CassandraSchema
- rename-model:
    from: Column
    to: CassandraColumn
# Rename for input parameters s/Parameters/Options/, per C# convention
# rename parametes for cosmos-db.json
- rename-model:
    from: DatabaseAccountCreateUpdateParameters
    to: DatabaseAccountCreateUpdateOptions
- rename-model:
    from: DatabaseAccountUpdateParameters
    to: DatabaseAccountUpdateOptions
- rename-model:
    from: DatabaseAccountRegenerateKeyParameters
    to: DatabaseAccountRegenerateKeyOptions
- rename-model:
    from: ThroughputSettingsUpdateParameters
    to: ThroughputSettingsUpdateOptions
- rename-model:
    from: SqlDatabaseCreateUpdateParameters
    to: SqlDatabaseCreateUpdateOptions
- rename-model:
    from: SqlContainerCreateUpdateParameters
    to: SqlContainerCreateUpdateOptions
- rename-model:
    from: SqlStoredProcedureCreateUpdateParameters
    to: SqlStoredProcedureCreateUpdateOptions
- rename-model:
    from: SqlUserDefinedFunctionCreateUpdateParameters
    to: SqlUserDefinedFunctionCreateUpdateOptions
- rename-model:
    from: SqlTriggerCreateUpdateParameters
    to: SqlTriggerCreateUpdateOptions
- rename-model:
    from: MongoDBDatabaseCreateUpdateParameters
    to: MongoDBDatabaseCreateUpdateOptions
- rename-model:
    from: MongoDBCollectionCreateUpdateParameters
    to: MongoDBCollectionCreateUpdateOptions
- rename-model:
    from: TableCreateUpdateParameters
    to: TableCreateUpdateOptions
- rename-model:
    from: CassandraKeyspaceCreateUpdateParameters
    to: CassandraKeyspaceCreateUpdateOptions
- rename-model:
    from: CassandraTableCreateUpdateParameters
    to: CassandraTableCreateUpdateOptions
- rename-model:
    from: GremlinDatabaseCreateUpdateParameters
    to: GremlinDatabaseCreateUpdateOptions
- rename-model:
    from: GremlinGraphCreateUpdateParameters
    to: GremlinGraphCreateUpdateOptions
# TODO: rename for notebook.json and rback.json when adding them back

# add a missing response code for long running operation. an issue was filed on swagger: https://github.com/Azure/azure-rest-api-specs/issues/16508
- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}"].put
  transform: >
    $.responses["202"] = {
        "description": "Creation of notebook workspace will complete asynchronously."
    };
```

### Tag: package-2021-06-csharp

These settings apply only when `--tag=package-2021-06-csharp` is specified on the command line. We have to remove the following files:

- `notebook.json`: that feature is offline due to security issues
- `rbac.json`: a [bug](https://github.com/Azure/azure-rest-api-specs/issues/16560) is blocking SDK

```yaml $(tag) == 'package-2021-06-csharp'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/5405df1424664d1c6ef9cdcda426eb85e59a02cc/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5405df1424664d1c6ef9cdcda426eb85e59a02cc/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5405df1424664d1c6ef9cdcda426eb85e59a02cc/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5405df1424664d1c6ef9cdcda426eb85e59a02cc/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/restorable.json
```
