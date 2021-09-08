# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CosmosDB
skip-csproj: true
namespace: Azure.ResourceManager.CosmosDB
require: https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cosmos-db/resource-manager/readme.md
tag: package-2021-06-csharp
output-folder: Generated/
clear-output-folder: true
flatten-payloads: false
model-namespae: true
modelerfour:
    lenient-model-deduplication: true

no-property-type-replacement: SqlDatabaseResource;MongoDBDatabaseResource;TableResource;CassandraKeyspaceResource;Column;GremlinDatabaseResource;PrivateEndpointProperty
operation-group-to-resource:
    DatabaseAccounts: DatabaseAccount # why we have error?
    SqlContainers: SqlContainer
    SqlStoredProcedures: SqlStoredProcedure
    SqlUserDefinedFunctions: SqlUserDefinedFunction
    SqlTriggers: SqlTrigger
    SqlRoleDefinitions: SqlRoleDefinition
    SqlRoleAssignments: SqlRoleAssignment
    MongoDBResources: MongoDBDatabase
    MongoDBCollections: MongoDBCollection
    TableResources: Table
    CassandraResources: CassandraKeyspace
    CassandraTables: CassandraTable
    GremlinResources: GremlinDatabase
    GremlinGraphs: GremlinGraph
    NotebookWorkspaces: NotebookWorkspace
# above need more investigation
    RegionMetrics: NonResource
    DatabaseMetrics: NonResource
    DatabaseUsages: NonResource
    DatabaseMetricDefintions: NonResource
    DatabaseCollectionMetrics: NonResource
    DatabaseCollectionUsages: NonResource
    DatabaseCollectionMetricDefintions: NonResource
    RegionDatabaseCollectionMetrics: NonResource
    PercentileSourceTargetMetrics: NonResource
    PercentileTargetMetrics: NonResource
    PercentileMetrics: NonResource
    RegionDatabaseCollectionPartitionMetrics: NonResource
    DatabaseCollectionPartitionMetrics: NonResource
    DatabaseCollectionPartitionUsages: NonResource
    DatabaseCollectionPartitionKeyRangeIdMetrics: NonResource
    RegionDatabaseCollectionPartitionKeyRangeIdMetrics: NonResource
    SqlDatabases: SqlDatabase
    # privateLinkResources.json
    PrivateLinkResources: PrivateLinkResource
    # restorable.json
    RestorableDatabaseAccounts: RestorableDatabaseAccount
operation-group-to-resource-type:
    RegionMetrics: Microsoft.DocumentDB/databaseAccounts
    DatabaseMetrics: Microsoft.DocumentDB/databaseAccounts/databases/metrics
    DatabaseUsages: Microsoft.DocumentDB/databaseAccounts/databases/usages
    DatabaseMetricDefinitions: Microsoft.DocumentDB/databaseAccounts/databases/metricDefinitions
    DatabaseCollectionMetrics: Microsoft.DocumentDB/databaseAccounts/databases/collection/metrics
    DatabaseCollectionUsages: Microsoft.DocumentDB/databaseAccounts/databases/collection/usages
    DatabaseCollectionMetricDefinitions: Microsoft.DocumentDB/databaseAccounts/databases/collection/metricDefinitions
    RegionDatabaseCollectionMetrics: Microsoft.DocumentDB/databaseAccounts/region/databases/collection/metrics
    PercentileSourceTargetMetrics: Microsoft.DocumentDB/databaseAccounts/sourceRegion/targetRegion/percentile/metrics
    PercentileTargetMetrics: Microsoft.DocumentDB/databaseAccounts/targetRegion/percentile/metrics
    PercentileMetrics: Microsoft.DocumentDB/databaseAccounts/percentile/metrics
    RegionDatabaseCollectionPartitionMetrics: Microsoft.DocumentDB/databaseAccounts/region/databases/collections/partitions/metrics
    DatabaseCollectionPartitionMetrics: Microsoft.DocumentDB/databaseAccounts/databases/collections/partitions/metrics
    DatabaseCollectionPartitionUsages: Microsoft.DocumentDB/databaseAccounts/databases/collections/partitions/usages
    DatabaseCollectionPartitionKeyRangeIdMetrics: Microsoft.DocumentDB/databaseAccounts/databases/collections/partitionKeyRangeId/metrics
    RegionDatabaseCollectionPartitionKeyRangeIdMetrics: Microsoft.DocumentDB/databaseAccounts/region/databases/collections/partitionKeyRangeId/metrics
    # privateLinkResources.json
    PrivateLinkResources: Microsoft.DocumentDB/databaseAccounts/privateLinkResources
    # restorable.json
    RestorableDatabaseAccounts: Microsoft.DocumentDB/locations/restorableDatabaseAccounts
    RestorableSqlDatabases: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlDatabases
    RestorableSqlContainers: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlContainers
    RestorableSqlResources: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlResources
    RestorableMongodbDatabases: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableMongodbDatabases
    RestorableMongodbCollections: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableMongodbDatabases
    RestorableMongodbResources: Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableMongodbResources
operation-group-to-parent:
    RestorableDatabaseAccounts: Microsoft.DocumentDB/locations
directive:
# cosmos-db.json
- rename-operation:
    from: DatabaseAccountRegion_ListMetrics
    to: RegionMetrics_List
- rename-operation:
    from: Database_ListMetrics
    to: DatabaseMetrics_List
- rename-operation:
    from: Database_ListUsages
    to: DatabaseUsages_List
- rename-operation:
    from: Database_ListMetricDefinitions
    to: DatabaseMetricDefinitions_List
- rename-operation:
    from: Collection_ListMetrics
    to: DatabaseCollectionMetrics_List
- rename-operation:
    from: Collection_ListUsages
    to: DatabaseCollectionUsages_List
- rename-operation:
    from: Collection_ListMetricDefinitions
    to: DatabaseCollectionMetricDefinitions_List
- rename-operation:
    from: CollectionRegion_ListMetrics
    to: RegionDatabaseCollectionMetrics_List
- rename-operation:
    from: PercentileSourceTarget_ListMetrics
    to: PercentileSourceTargetMetrics_List
- rename-operation:
    from: PercentileTarget_ListMetrics
    to: PercentileTargetMetrics_List
- rename-operation:
    from: Percentile_ListMetrics
    to: PercentileMetrics_List
- rename-operation:
    from: CollectionPartitionRegion_ListMetrics
    to: RegionDatabaseCollectionPartitionMetrics_List
- rename-operation:
    from: CollectionPartition_ListMetrics
    to: DatabaseCollectionPartitionMetrics_List
- rename-operation:
    from: CollectionPartition_ListUsages
    to: DatabaseCollectionPartitionUsages_List
- rename-operation:
    from: PartitionKeyRangeId_ListMetrics
    to: DatabaseCollectionPartitionKeyRangeIdMetrics_List
- rename-operation:
    from: PartitionKeyRangeIdRegion_ListMetrics
    to: RegionDatabaseCollectionPartitionKeyRangeIdMetrics_List
# Below is a workaround for ADO 6196
- remove-operation:
  - DatabaseAccounts_GetReadOnlyKeys
# Rename for MongoDBResources
- rename-operation:
    from: MongoDBResources_ListMongoDBCollections
    to: MongoDBCollections_List
- rename-operation:
    from: MongoDBResources_GetMongoDBCollection
    to: MongoDBCollections_Get
- rename-operation:
    from: MongoDBResources_CreateUpdateMongoDBCollection
    to: MongoDBCollections_CreateUpdate
- rename-operation:
    from: MongoDBResources_DeleteMongoDBCollection
    to: MongoDBCollections_Delete
- rename-operation:
    from: MongoDBResources_GetMongoDBCollectionThroughput
    to: MongoDBCollections_GetThroughput
- rename-operation:
    from: MongoDBResources_UpdateMongoDBCollectionThroughput
    to: MongoDBCollections_UpdateThroughput
- rename-operation:
    from: MongoDBResources_MigrateMongoDBCollectionToAutoscale
    to: MongoDBCollections_MigrateToAutoscale
- rename-operation:
    from: MongoDBResources_MigrateMongoDBCollectionToManualThroughput
    to: MongoDBCollections_MigrateToManualThroughput
# Rename for CassandraTables
- rename-operation:
    from: CassandraResources_ListCassandraTables
    to: CassandraTables_List
- rename-operation:
    from: CassandraResources_GetCassandraTable
    to: CassandraTables_Get
- rename-operation:
    from: CassandraResources_CreateUpdateCassandraTable
    to: CassandraTables_CreateUpdate
- rename-operation:
    from: CassandraResources_DeleteCassandraTable
    to: CassandraTables_Delete
- rename-operation:
    from: CassandraResources_GetCassandraTableThroughput
    to: CassandraTables_GetThroughput
- rename-operation:
    from: CassandraResources_UpdateCassandraTableThroughput
    to: CassandraTables_UpdateThroughput
- rename-operation:
    from: CassandraResources_MigrateCassandraTableToAutoscale
    to: CassandraTables_MigrateToAutoscale
- rename-operation:
    from: CassandraResources_MigrateCassandraTableToManualThroughput
    to: CassandraTables_MigrateToManualThroughput
# Rename for GremlinGraphs
- rename-operation:
    from: GremlinResources_ListGremlinGraphs
    to: GremlinGraphs_List
- rename-operation:
    from: GremlinResources_GetGremlinGraph
    to: GremlinGraphs_Get
- rename-operation:
    from: GremlinResources_CreateUpdateGremlinGraph
    to: GremlinGraphs_CreateUpdate
- rename-operation:
    from: GremlinResources_DeleteGremlinGraph
    to: GremlinGraphs_Delete
- rename-operation:
    from: GremlinResources_GetGremlinGraphThroughput
    to: GremlinGraphs_GetThroughput
- rename-operation:
    from: GremlinResources_UpdateGremlinGraphThroughput
    to: GremlinGraphs_UpdateThroughput
- rename-operation:
    from: GremlinResources_MigrateGremlinGraphToAutoscale
    to: GremlinGraphs_MigrateToAutoscale
- rename-operation:
    from: GremlinResources_MigrateGremlinGraphToManualThroughput
    to: GremlinGraphs_MigrateToManualThroughput
# rename bad names
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
    to: Table
- rename-model:
    from: TableGetProperties
    to: TableProperties
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
    to: Usages
- rename-model:
    from: PartitionUsagesResult
    to: PartitionUsages
- rename-model:
    from: MetricDefinitionsListResult
    to: MetricDefinitionsList
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
# add a missing response code for long running operation. an issue was filed on swagger: https://github.com/Azure/azure-rest-api-specs/issues/16508
- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}"].put
  transform: >
    $.responses["202"] = {
        "description": "Creation of notebook workspace will complete asynchronously."
    };
- from: swagger-document
  where: $.paths
  transform: >
    /* `SqlResources` is a virtual operation group which contains 7 resources, need to split it apart */
    for (var path in $) {
        var operations = $[path];
        /* definitions in cosmos-db.json */
        if (path.includes("/databaseAccounts/{accountName}/sqlDatabases")) {
            if (path.includes("containers")) {
                if (path.includes("storedProcedures")) {
                    for (var name in operations) {
                        operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlStoredProcedures");
                    }
                } else if (path.includes("userDefinedFunctions")) {
                    for (var name in operations) {
                        if (operations[name].operationId) {
                            operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlUserDefinedFunctions");
                        }
                    }
                } else if (path.includes("triggers")) {
                    for (var name in operations) {
                        if (operations[name].operationId) {
                            operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlTriggers");
                        }
                    }
                } else {
                    for (var name in operations) {
                        if (operations[name].operationId) {
                            operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlContainers");
                        }
                    }
                }
            } else {
                for (var name in operations) {
                    if (operations[name].operationId) {
                        operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlDatabases");
                    }
                }
            }
        }
        /* definitions in rbac.json */
        if (path.includes("/databaseAccounts/{accountName}/sqlRoleDefinitions")) {
            for (var name in operations) {
                operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlRoleDefinitions");
            }
        }
        if (path.includes("/databaseAccounts/{accountName}/sqlRoleAssignments")) {
            for (var name in operations) {
                operations[name].operationId = operations[name].operationId.replace("SqlResources", "SqlRoleAssignments");
            }
        }
    }
```

### Tag: package-2021-06-csharp

These settings apply only when `--tag=package-2021-06-csharp` is specified on the command line. We have to remove the following files:
- `notebook.json`: that feaure is offline due to security issues
- `rbac.json`: a [bug](https://github.com/Azure/azure-rest-api-specs/issues/16560) is blocking SDK

```yaml $(tag) == 'package-2021-06-csharp'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-06-15/restorable.json
```
