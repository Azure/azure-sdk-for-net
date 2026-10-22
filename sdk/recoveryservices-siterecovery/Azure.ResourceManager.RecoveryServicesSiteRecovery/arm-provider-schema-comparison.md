# ARM provider schema comparison: Azure.ResourceManager.RecoveryServicesSiteRecovery

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 24 matching normalized patterns; 0 legacy-only; 1 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 1 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}/replicationProtectionContainers/{}/replicationProtectionClusters/{}/operationResults/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults/default`
  - resolveArmResources-only: `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}, Microsoft.Compute/virtualMachines]`


### Legacy-only non-resource methods

- `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`


### resolveArmResources-only non-resource methods

None.
