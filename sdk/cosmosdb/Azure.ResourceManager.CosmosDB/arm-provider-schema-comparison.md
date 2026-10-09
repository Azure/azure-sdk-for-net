# ARM provider schema comparison: Azure.ResourceManager.CosmosDB

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 3 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 46 matching normalized patterns; 0 legacy-only; 3 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 3 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/backups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/cassandraClusters/{}/commands/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/cassandraKeyspaces/{}/views/{}/throughputSettings/default`


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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}`
  - resolveArmResources-only: `Microsoft.DocumentDB.NotebookWorkspaces.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}/notebookWorkspaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DocumentDB/databaseAccounts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
