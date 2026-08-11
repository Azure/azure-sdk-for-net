# ARM provider schema comparison: Azure.ResourceManager.RecoveryServicesBackup

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 12 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 12 matching normalized patterns; 0 legacy-only; 12 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 12 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupJobs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/operationsStatus/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupJobs/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupPolicies/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupstorageconfig/vaultstorageconfig/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupstorageconfig/vaultstorageconfig/operationStatus/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/privateEndpointConnections/{}/operationsStatus/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}`
  - legacy-only: `Microsoft.RecoveryServices.RecoveryPointsRecommendedForMove.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPointsRecommendedForMove [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.RecoveryServices.RecoveryPointsRecommendedForMove.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPointsRecommendedForMove [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
