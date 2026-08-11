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
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}/replicationProtectionContainers/{}/replicationProtectionClusters/{}/operationResults/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}`
  - resolveArmResources-only: `Microsoft.RecoveryServices.Fabrics.purge (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}/replicationRecoveryServicesProviders/{}`
  - resolveArmResources-only: `Microsoft.RecoveryServices.RecoveryServicesProviders.purge (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}/replicationRecoveryServicesProviders/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/replicationFabrics/{}/replicationRecoveryServicesProviders/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults/default`
  - resolveArmResources-only: `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}, Microsoft.Compute/virtualMachines]`


### Legacy-only non-resource methods

- `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.RecoveryServices/replicationEligibilityResults) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`


### resolveArmResources-only non-resource methods

- `Microsoft.RecoveryServices.OperationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/operations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
