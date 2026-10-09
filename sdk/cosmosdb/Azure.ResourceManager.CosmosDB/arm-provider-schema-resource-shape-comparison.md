# ARM resource shape comparison: Azure.ResourceManager.CosmosDB

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 46 |
| resolveArmResources resources | 49 |
| Matching normalized resource IDs | 46 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 3 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 2 |

## Legacy-only resources

None.

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/backups/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/backups/{backupId}`<br>resourceType=`Microsoft.DocumentDB/cassandraClusters/backups`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/commands/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/commands/{commandId}`<br>resourceType=`Microsoft.DocumentDB/cassandraClusters/commands`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/cassandraKeyspaces/{}/views/{}/throughputSettings/default` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/cassandraKeyspaces/{keyspaceName}/views/{viewName}/throughputSettings/default`<br>resourceType=`Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/views/throughputSettings`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/cassandraKeyspaces/{keyspaceName}/views/{viewName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}` | create | `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}, Microsoft.Resources/resourceGroups]` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{}` | create | `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/notebookWorkspaces/{notebookWorkspaceName}, Microsoft.Resources/resourceGroups]` | _none_ |
