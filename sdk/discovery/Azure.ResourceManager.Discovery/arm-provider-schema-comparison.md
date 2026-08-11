# ARM provider schema comparison: Azure.ResourceManager.Discovery

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 13 matching normalized patterns; 0 legacy-only; 6 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 6 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/agents/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/dataContainers/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/dataContainers/{}/dataAssets/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/models/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/storages/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/workflows/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/supercomputers/{}/nodePools/{}`
  - resolveArmResources-only: `Microsoft.Discovery.NodePools.listBySubscription (List) /subscriptions/{}/providers/Microsoft.Discovery/supercomputers/{}/nodePools [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Discovery/workspaces/{}/projects/{}`
  - resolveArmResources-only: `Microsoft.Discovery.Projects.listBySubscription (List) /subscriptions/{}/providers/Microsoft.Discovery/workspaces/{}/projects [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
