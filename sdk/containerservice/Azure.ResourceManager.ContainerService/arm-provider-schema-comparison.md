# ARM provider schema comparison: Azure.ResourceManager.ContainerService

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 21 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}`
  - resolveArmResources-only: `Microsoft.ContainerService.ManagedClusters.operationStatusResultGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}/operations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ContainerService.ManagedClusters.operationStatusResultList (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}/operations [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}/agentPools/{}`
  - resolveArmResources-only: `Microsoft.ContainerService.AgentPools.getByAgentPool (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}/agentPools/{}/operations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerService/managedClusters/{}/agentPools/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.ContainerService.Operations.list (/providers/Microsoft.ContainerService/operations) Tenant`
