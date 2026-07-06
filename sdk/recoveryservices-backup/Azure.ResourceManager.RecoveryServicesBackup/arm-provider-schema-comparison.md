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

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 15 |
| Found in Bicep reference | 11 |
| Found in package API version | 0 |
| Found only outside package API versions | 11 |
| Not found in Bicep reference | 4 |

**Result:** Operation-status types that are not found in Bicep are likely false resources. Operation-result types that exist in Bicep currently appear only in `2026-05-01`, outside this package's API-version set, so they are not legacy misses for the current package. Singleton child resource types exist in Bicep; the `resolveArmResources` parent-type collapse remains a singleton parsing bug.

### Found only outside package API versions

These are real ARM resource types, but they do not overlap the API versions generated by this package. They usually point to version/projection differences rather than legacy detector misses.

| Side | Resource type | Bicep API versions | Package API versions | Resource schema API versions |
| --- | --- | --- | --- | --- |
| Legacy resourceType for same path | [Microsoft.RecoveryServices/vaults/backupconfig](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backupconfig?pivots=deployment-language-bicep) | `2020-06-01`, `2024-04-01`, `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` |
| resolveArmResources resourceType for same path | [Microsoft.RecoveryServices/vaults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults?pivots=deployment-language-bicep) | `2020-06-01`, `2022-10-01`, `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` |
| Legacy resourceType for same path | [Microsoft.RecoveryServices/vaults/backupEncryptionConfigs](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backupencryptionconfigs?pivots=deployment-language-bicep) | `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` |
| resolveArmResources only | [Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/operationResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backupfabrics/protectioncontainers/operationresults?pivots=deployment-language-bicep) | `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | None |
| resolveArmResources only | [Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/operationResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backupfabrics/protectioncontainers/protecteditems/operationresults?pivots=deployment-language-bicep) | `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | None |
| resolveArmResources only | [Microsoft.RecoveryServices/vaults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults?pivots=deployment-language-bicep) | `2020-06-01`, `2022-10-01`, `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | None |
| resolveArmResources only | [Microsoft.RecoveryServices/vaults/backupPolicies/operationResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backuppolicies/operationresults?pivots=deployment-language-bicep) | `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | None |
| Legacy resourceType for same path | [Microsoft.RecoveryServices/vaults/backupstorageconfig](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/backupstorageconfig?pivots=deployment-language-bicep) | `2020-06-01`, `2022-10-01`, `2023-02-01`, `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` |
| resolveArmResources only | [Microsoft.RecoveryServices/vaults/operationResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.recoveryservices/vaults/operationresults?pivots=deployment-language-bicep) | `2026-05-01` | `2025-02-01`, `2025-08-01`, `2026-01-01`, `2026-01-31-preview` | None |

### Not found in Bicep reference

These are problematic false-resource candidates. They may be incorrect TypeSpec modeling or a `resolveArmResources` bug. If a resource is newly introduced, the Bicep reference might also not have published that API version yet; check the resource schema API versions.

| Side | Resource type | Resource schema API versions | Notes |
| --- | --- | --- | --- |
| resolveArmResources only | `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/operationsStatus` | None | Not found in Bicep reference; likely false resource or docs missing for this API version |
| resolveArmResources only | `Microsoft.RecoveryServices/vaults/backupJobs/operationResults` | None | Not found in Bicep reference; likely false resource or docs missing for this API version |
| resolveArmResources only | `Microsoft.RecoveryServices/vaults/operationStatus` | None | Not found in Bicep reference; likely false resource or docs missing for this API version |
| resolveArmResources only | `Microsoft.RecoveryServices/vaults/privateEndpointConnections/operationsStatus` | None | Not found in Bicep reference; likely false resource or docs missing for this API version |
