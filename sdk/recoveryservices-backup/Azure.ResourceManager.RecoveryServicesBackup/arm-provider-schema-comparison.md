# ARM provider schema comparison: Azure.ResourceManager.RecoveryServicesBackup

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 15 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 12 matching normalized patterns; 0 legacy-only; 15 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 15 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 1 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 8 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/operationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupJobs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/backupValidateOperationResults/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupCrossTenantVaultMappings/{}/vaultCredentials/{}/operationResults/{}`
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupstorageconfig/vaultstorageconfig`
  - resolveArmResources-only: `Microsoft.RecoveryServices.BackupResourceStorageConfigsNonCRR.patch (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupstorageconfig/vaultstorageconfig [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupstorageconfig/vaultstorageconfig, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}`
  - legacy-only: `Microsoft.RecoveryServices.RecoveryPointsRecommendedForMove.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPointsRecommendedForMove [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.RecoveryServices.RecoveryPointsRecommendedForMove.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}/recoveryPointsRecommendedForMove [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/protectionContainers/{}/protectedItems/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.RecoveryServices.BackupOperationResults.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupOperationResults/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.BackupOperationStatuses.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupOperations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.OperationOperationGroup.validate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupValidateOperation) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.ProtectionContainerRefreshOperationResults.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupFabrics/{}/operationResults/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.TieringCostOperationStatus.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupTieringCost/default/operationsStatus/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.ValidateOperation.trigger (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupTriggerValidateOperation) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.ValidateOperationResults.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupValidateOperationResults/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.RecoveryServices.ValidateOperationStatuses.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.RecoveryServices/vaults/{}/backupValidateOperationsStatuses/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
