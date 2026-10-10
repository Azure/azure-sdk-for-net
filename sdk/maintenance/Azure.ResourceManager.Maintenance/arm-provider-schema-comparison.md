# ARM provider schema comparison: Azure.ResourceManager.Maintenance

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 8 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/{}/providers/Microsoft.Maintenance/applyUpdates/{}`
  - resolveArmResources-only: `Microsoft.Maintenance.ApplyUpdateOperationGroup.list (List) /subscriptions/{}/providers/Microsoft.Maintenance/applyUpdates [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`


### Legacy-only non-resource methods

- `Microsoft.Maintenance.ApplyUpdateOperationGroup.list (/subscriptions/{}/providers/Microsoft.Maintenance/applyUpdates) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`


### resolveArmResources-only non-resource methods

None.
