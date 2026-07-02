# ARM provider schema comparison: Azure.ResourceManager.CosmosDB

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 legacy-only and 2 resolve-only normalized resource ID patterns; 2 CRUD operation differences; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 57 matching normalized patterns; 3 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 3 legacy-only normalized pattern(s), 2 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 57 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 3 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}/softDeletedSqlContainers/{containerName}` |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/backups/{backupId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/commands/{commandId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DocumentDB.ClusterResources.getBackup` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/backups/{backupId}` | Present. | Missing. |
| `Microsoft.DocumentDB.ClusterResources.getCommandAsync` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/commands/{commandId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DocumentDB.DatabaseAccounts.getReadOnlyKeys` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/readonlykeys` | Missing. | Present. |
| `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 45 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 10 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.documentdb/locations/{}` | `CosmosDBLocation` | `LocationGetResult` |
| `/subscriptions/{}/providers/microsoft.documentdb/locations/{}/restorabledatabaseaccounts/{}` | `RestorableCosmosDBAccount` | `RestorableDatabaseAccountGetResult` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/cassandraclusters/{}` | `CassandraCluster` | `ClusterResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/cassandraclusters/{}/datacenters/{}` | `CassandraDataCenter` | `DataCenterResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}` | `CosmosDBAccount` | `DatabaseAccountGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/cassandrakeyspaces/{}` | `CassandraKeyspace` | `CassandraKeyspaceGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/cassandrakeyspaces/{}/tables/{}` | `CassandraTable` | `CassandraTableGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/cassandrakeyspaces/{}/views/{}` | `CassandraView` | `CassandraViewGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/cassandraroleassignments/{}` | `CassandraRoleAssignment` | `CassandraRoleAssignmentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/cassandraroledefinitions/{}` | `CassandraRoleDefinition` | `CassandraRoleDefinitionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/chaosfaults/{}` | `ChaosFault` | `chaosFaultResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/copyjobs/{}` | `CosmosDBCopyJob` | `CopyJobGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/datatransferjobs/{}` | `DataTransferJob` | `DataTransferJobGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/graphs/{}` | `CosmosDBGraph` | `GraphResourceGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/gremlindatabases/{}` | `GremlinDatabase` | `GremlinDatabaseGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/gremlindatabases/{}/graphs/{}` | `GremlinGraph` | `GremlinGraphGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/gremlinroleassignments/{}` | `GremlinRoleAssignment` | `GremlinRoleAssignmentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/gremlinroledefinitions/{}` | `GremlinRoleDefinition` | `GremlinRoleDefinitionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongodbdatabases/{}` | `MongoDBDatabase` | `MongoDBDatabaseGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongodbdatabases/{}/collections/{}` | `MongoDBCollection` | `MongoDBCollectionGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongodbroledefinitions/{}` | `MongoDBRoleDefinition` | `MongoRoleDefinitionGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongodbuserdefinitions/{}` | `MongoDBUserDefinition` | `MongoUserDefinitionGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongomiroleassignments/{}` | `MongoMIRoleAssignment` | `MongoMIRoleAssignmentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/mongomiroledefinitions/{}` | `MongoMIRoleDefinition` | `MongoMIRoleDefinitionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/privateendpointconnections/{}` | `CosmosDBPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/privatelinkresources/{}` | `CosmosDBPrivateLinkResource` | `PrivateLinkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/services/{}` | `CosmosDBService` | `ServiceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}` | `CosmosDBSqlDatabase` | `SqlDatabaseGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}/clientencryptionkeys/{}` | `CosmosDBSqlClientEncryptionKey` | `ClientEncryptionKeyGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}/containers/{}` | `CosmosDBSqlContainer` | `SqlContainerGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}/containers/{}/storedprocedures/{}` | `CosmosDBSqlStoredProcedure` | `SqlStoredProcedureGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}/containers/{}/triggers/{}` | `CosmosDBSqlTrigger` | `SqlTriggerGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqldatabases/{}/containers/{}/userdefinedfunctions/{}` | `CosmosDBSqlUserDefinedFunction` | `SqlUserDefinedFunctionGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqlroleassignments/{}` | `CosmosDBSqlRoleAssignment` | `SqlRoleAssignmentGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/sqlroledefinitions/{}` | `CosmosDBSqlRoleDefinition` | `SqlRoleDefinitionGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/tableroleassignments/{}` | `CosmosDBTableRoleAssignment` | `TableRoleAssignmentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/tableroledefinitions/{}` | `CosmosDBTableRoleDefinition` | `TableRoleDefinitionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/tables/{}` | `CosmosDBTable` | `TableGetResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/fleets/{}` | `CosmosDBFleet` | `FleetResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/fleets/{}/fleetanalytics/{}` | `FleetAnalytics` | `FleetAnalyticsResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/fleets/{}/fleetspaces/{}` | `CosmosDBFleetspace` | `FleetspaceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/fleets/{}/fleetspaces/{}/fleetspaceaccounts/{}` | `CosmosDBFleetspaceAccount` | `FleetspaceAccountResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/garnetclusters/{}` | `GarnetCluster` | `GarnetClusterResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/throughputpools/{}` | `CosmosDBThroughputPool` | `ThroughputPoolResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/throughputpools/{}/throughputpoolaccounts/{}` | `CosmosDBThroughputPoolAccount` | `ThroughputPoolAccountResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlContainers.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}/softDeletedSqlContainers/{containerName}` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlContainers.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}/softDeletedSqlContainers` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlContainers.purge` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}/softDeletedSqlContainers/{containerName}?softDeleteActionKind=PermanentDeleteResource` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlContainers.restore` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}/softDeletedSqlContainers/{containerName}?softDeleteActionKind=RestoreSoftDeletedResource` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlDatabases.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlDatabases.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlDatabases.purge` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}?softDeleteActionKind=PermanentDeleteResource` | Missing. | Present. |
| `Microsoft.DocumentDB.SoftDeletedSqlDatabases.restore` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/locations/{location}/softDeletedDatabaseAccounts/{accountName}/softDeletedSqlDatabases/{databaseName}?softDeleteActionKind=RestoreSoftDeletedResource` | Missing. | Present. |

