# ARM provider schema comparison: Azure.ResourceManager.DataProtectionBackup

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 3 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching normalized patterns; 0 legacy-only; 3 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 3 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 4 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DataProtection/backupVaults/{}/backupInstances/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DataProtection/backupVaults/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DataProtection/backupVaults/{}/operationStatus/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Azure.ResourceManager.Operations.list (/providers/Microsoft.DataProtection/operations) Tenant`
- `Microsoft.DataProtection.OperationResultOperationGroup.get (/subscriptions/{}/providers/Microsoft.DataProtection/locations/{}/operationResults/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.DataProtection.OperationStatusOperationGroup.get (/subscriptions/{}/providers/Microsoft.DataProtection/locations/{}/operationStatus/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.DataProtection.OperationStatusResourceGroupContextOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DataProtection/operationStatus/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
