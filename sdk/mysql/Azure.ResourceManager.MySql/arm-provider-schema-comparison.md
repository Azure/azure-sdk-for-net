# ARM provider schema comparison: Azure.ResourceManager.MySql

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 0 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 1 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 3 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/fabricMirroringSettings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/privateLinkResources/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{}`
  - legacy-only: `Microsoft.DBforMySQL.LongRunningBackup.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.DBforMySQL.LongRunningBackup.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}`
  - legacy-only: `Microsoft.DBforMySQL.Replicas.listByServer (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/replicas [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.DBforMySQL.LongRunningBackup.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/backupsV2/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DBforMySQL.Replicas.listByServer (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}/replicas [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DBforMySQL/flexibleServers/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.DBforMySQL.OperationProgress.get (/subscriptions/{}/providers/Microsoft.DBforMySQL/locations/{}/operationProgress/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.DBforMySQL.OperationResults.get (/subscriptions/{}/providers/Microsoft.DBforMySQL/locations/{}/operationResults/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.DBforMySQL.Operations.list (/providers/Microsoft.DBforMySQL/operations) Tenant`
