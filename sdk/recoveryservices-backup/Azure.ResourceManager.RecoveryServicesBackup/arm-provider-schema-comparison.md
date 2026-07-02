# ARM provider schema comparison: Azure.ResourceManager.RecoveryServicesBackup

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 9 resolve-only normalized resource ID patterns; 3 resource model differences; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 12 matching normalized patterns; 0 legacy-only; 9 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 3 differences. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 9 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 12 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 9 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}/operationsStatus/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupJobs/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupJobs/{jobName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupPolicies/{policyName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig/operationStatus/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/privateEndpointConnections/{privateEndpointConnectionName}/operationsStatus/{operationId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 3 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupconfig/vaultconfig` | `Microsoft.RecoveryServices.BackupResourceVaultConfigResource` | `Microsoft.RecoveryServices.BackupResourceVaultConfigResource` | `Microsoft.RecoveryServices/vaults/backupconfig` | `Microsoft.RecoveryServices/vaults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupencryptionconfigs/backupresourceencryptionconfig` | `Microsoft.RecoveryServices.BackupResourceEncryptionConfigExtendedResource` | `Microsoft.RecoveryServices.BackupResourceEncryptionConfigExtendedResource` | `Microsoft.RecoveryServices/vaults/backupEncryptionConfigs` | `Microsoft.RecoveryServices/vaults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupstorageconfig/vaultstorageconfig` | `Microsoft.RecoveryServices.BackupResourceConfigResource` | `Microsoft.RecoveryServices.BackupResourceConfigResource` | `Microsoft.RecoveryServices/vaults/backupstorageconfig` | `Microsoft.RecoveryServices/vaults` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.BackupResourceStorageConfigsNonCRR.patch` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.RecoveryPointsRecommendedForMove.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}/recoveryPointsRecommendedForMove` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 12 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 8 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupconfig/vaultconfig` | `BackupResourceVaultConfig` | `BackupResourceVaultConfigResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupencryptionconfigs/backupresourceencryptionconfig` | `BackupResourceEncryptionConfigExtended` | `BackupResourceEncryptionConfigExtendedResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupengines/{}` | `BackupEngine` | `BackupEngineBaseResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupfabrics/{}/backupprotectionintent/{}` | `BackupProtectionIntent` | `ProtectionIntentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupfabrics/{}/protectioncontainers/{}` | `BackupProtectionContainer` | `ProtectionContainerResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupfabrics/{}/protectioncontainers/{}/protecteditems/{}` | `BackupProtectedItem` | `ProtectedItemResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupfabrics/{}/protectioncontainers/{}/protecteditems/{}/recoverypoints/{}` | `BackupRecoveryPoint` | `RecoveryPointResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupjobs/{}` | `BackupJob` | `JobResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backuppolicies/{}` | `BackupProtectionPolicy` | `ProtectionPolicyResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupresourceguardproxies/{}` | `ResourceGuardProxy` | `ResourceGuardProxyBaseResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/backupstorageconfig/vaultstorageconfig` | `BackupResourceConfig` | `BackupResourceConfigResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/privateendpointconnections/{}` | `BackupPrivateEndpointConnection` | `PrivateEndpointConnectionResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.RecoveryServices.BackupOperationResults.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupOperationResults/{operationId}` | Missing. | Present. |
| `Microsoft.RecoveryServices.BackupOperationStatuses.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupOperations/{operationId}` | Missing. | Present. |
| `Microsoft.RecoveryServices.OperationOperationGroup.validate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupValidateOperation` | Missing. | Present. |
| `Microsoft.RecoveryServices.ProtectionContainerRefreshOperationResults.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/operationResults/{operationId}` | Missing. | Present. |
| `Microsoft.RecoveryServices.TieringCostOperationStatus.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupTieringCost/default/operationsStatus/{operationId}` | Missing. | Present. |
| `Microsoft.RecoveryServices.ValidateOperation.trigger` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupTriggerValidateOperation` | Missing. | Present. |
| `Microsoft.RecoveryServices.ValidateOperationResults.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupValidateOperationResults/{operationId}` | Missing. | Present. |
| `Microsoft.RecoveryServices.ValidateOperationStatuses.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupValidateOperationsStatuses/{operationId}` | Missing. | Present. |

