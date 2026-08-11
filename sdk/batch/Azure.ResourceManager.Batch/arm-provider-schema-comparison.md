# ARM provider schema comparison: Azure.ResourceManager.Batch

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 8 matching normalized patterns; 0 legacy-only; 1 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 1 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 1 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Batch/batchAccounts/{}/certificates/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Batch/batchAccounts/{}`
  - legacy: `Microsoft.Batch.BatchAccountData`
  - resolveArmResources: `Microsoft.Batch.BatchAccount`


### CRUD operation differences

None.


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
