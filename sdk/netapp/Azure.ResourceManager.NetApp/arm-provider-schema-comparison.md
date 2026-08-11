# ARM provider schema comparison: Azure.ResourceManager.NetApp

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 9 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 17 matching normalized patterns; 0 legacy-only; 9 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 9 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 1 matching normalized patterns differ |
| List/action operations | 3 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/activeDirectoryConfigs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticBackupPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticBackupVaults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticBackupVaults/{}/elasticBackups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticCapacityPools/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticCapacityPools/{}/elasticVolumes/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticCapacityPools/{}/elasticVolumes/{}/elasticSnapshots/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/elasticAccounts/{}/elasticSnapshotPolicies/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}`
  - resolveArmResources-only: `Microsoft.NetApp.NetAppAccounts.updatePrevious (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}`
  - resolveArmResources-only: `Microsoft.NetApp.NetAppAccounts.refreshLdapBindPassword (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/refreshLdapBindPassword [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/caches/{}`
  - resolveArmResources-only: `Microsoft.NetApp.Caches.listByCapacityPools (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/caches [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/volumes/{}`
  - resolveArmResources-only: `Microsoft.NetApp.Volumes.listGetGroupIdListForLdapUser20250601 (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/volumes/{}/getGroupIdListForLdapUser [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/volumes/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.NetApp.Volumes.oldlistReplications (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/volumes/{}/oldlistReplications [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetApp/netAppAccounts/{}/capacityPools/{}/volumes/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
