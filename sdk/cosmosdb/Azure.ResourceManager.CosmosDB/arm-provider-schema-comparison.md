# ARM provider schema comparison: Azure.ResourceManager.CosmosDB

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 13 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 46 matching normalized patterns; 0 legacy-only; 13 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 13 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 11 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 13 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/backups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/commands/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/cassandraKeyspaces/{}/views/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/cassandraKeyspaces/{}/views/{}/throughputSettings/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/chaosFaults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/copyJobs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/dataTransferJobs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/graphs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/networkSecurityPerimeterConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/fleets/{}/fleetAnalytics/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/garnetClusters/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/throughputPools/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/throughputPools/{}/throughputPoolAccounts/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}`
  - legacy-only: `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{}`
  - legacy-only: `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/providers/Microsoft.DocumentDB/locations/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.listByLocation (Action) /subscriptions/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts [Subscription: /subscriptions/{}/providers/Microsoft.DocumentDB/locations/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.ClusterResources.invokeCommandAsync (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/invokeCommandAsync [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.ClusterResources.listBackups (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/backups [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.ClusterResources.listCommand (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/commands [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.DatabaseAccounts.getReadOnlyKeys (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/readonlykeys [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.MongoDBDatabaseGetResultsOperationGroup.mongoDBDatabasePartitionMerge (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/partitionMerge [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.MongoDBCollectionGetResultsOperationGroup.listMongoDBCollectionPartitionMerge (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/partitionMerge [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/throughputSettings/default`
  - resolveArmResources-only: `Microsoft.DocumentDB.MongoDBResourcesThroughputSettingsGetResultsOperationGroup.mongoDBContainerRedistributeThroughput (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/throughputSettings/default/redistributeThroughput [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.MongoDBResourcesThroughputSettingsGetResultsOperationGroup.mongoDBContainerRetrieveThroughputDistribution (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/throughputSettings/default/retrieveThroughputDistribution [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/collections/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/throughputSettings/default`
  - resolveArmResources-only: `Microsoft.DocumentDB.MongoDBResources.mongoDBDatabaseRedistributeThroughput (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/throughputSettings/default/redistributeThroughput [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.MongoDBResources.mongoDBDatabaseRetrieveThroughputDistribution (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/throughputSettings/default/retrieveThroughputDistribution [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/mongodbDatabases/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.SqlResources.sqlDatabasePartitionMerge (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/partitionMerge [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.SqlContainerGetResultsOperationGroup.listSqlContainerPartitionMerge (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/partitionMerge [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/throughputSettings/default`
  - resolveArmResources-only: `Microsoft.DocumentDB.SqlResourcesThroughputSettingsGetResultsOperationGroup.sqlContainerRedistributeThroughput (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/throughputSettings/default/redistributeThroughput [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.SqlResourcesThroughputSettingsGetResultsOperationGroup.sqlContainerRetrieveThroughputDistribution (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/throughputSettings/default/retrieveThroughputDistribution [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/containers/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/throughputSettings/default`
  - resolveArmResources-only: `Microsoft.DocumentDB.ThroughputSettingsGetResultsOperationGroup.sqlDatabaseRedistributeThroughput (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/throughputSettings/default/redistributeThroughput [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`; `Microsoft.DocumentDB.ThroughputSettingsGetResultsOperationGroup.sqlDatabaseRetrieveThroughputDistribution (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/throughputSettings/default/retrieveThroughputDistribution [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/sqlDatabases/{}/throughputSettings/default, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.listByResourceGroupAndLocation (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.purge (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}?softDeleteActionKind=PermanentDeleteResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedDatabaseAccounts.restore (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}?softDeleteActionKind=RestoreSoftDeletedResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlContainers.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}/softDeletedSqlContainers/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlContainers.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}/softDeletedSqlContainers) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlContainers.purge (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}/softDeletedSqlContainers/{}?softDeleteActionKind=PermanentDeleteResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlContainers.restore (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}/softDeletedSqlContainers/{}?softDeleteActionKind=RestoreSoftDeletedResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlDatabases.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlDatabases.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlDatabases.purge (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}?softDeleteActionKind=PermanentDeleteResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.DocumentDB.SoftDeletedSqlDatabases.restore (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/locations/{}/softDeletedDatabaseAccounts/{}/softDeletedSqlDatabases/{}?softDeleteActionKind=RestoreSoftDeletedResource) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
