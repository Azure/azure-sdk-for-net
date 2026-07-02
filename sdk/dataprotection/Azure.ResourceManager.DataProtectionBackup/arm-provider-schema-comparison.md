# ARM provider schema comparison: Azure.ResourceManager.DataProtectionBackup

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 3 resolve-only normalized resource ID patterns; 6 hierarchy differences; 1 CRUD operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching normalized patterns; 0 legacy-only; 3 resolve-only. |
| Hierarchy for matching patterns | 6 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 3 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 9 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 3 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/operationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/operationStatus/{operationId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 6 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupinstances/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupinstances/{}/recoverypoints/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backuppolicies/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupresourceguardproxies/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/deletedbackupinstances/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DataProtection.BackupVaultResources.exportJobsOperationResultGet` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupJobs/operations/{operationId}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 8 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 4 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.dataprotection/locations/{}/deletedvaults/{}` | `DataProtectionDeletedBackupVault` | `DeletedBackupVaultResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}` | `DataProtectionBackupVault` | `BackupVaults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupinstances/{}` | `DataProtectionBackupInstance` | `BackupVaultsBackupInstances` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupinstances/{}/recoverypoints/{}` | `DataProtectionBackupRecoveryPoint` | `AzureBackupRecoveryPointResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backupjobs/{}` | `DataProtectionBackupJob` | `AzureBackupJobResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/backuppolicies/{}` | `DataProtectionBackupPolicy` | `BaseBackupPolicyResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/backupvaults/{}/deletedbackupinstances/{}` | `DeletedDataProtectionBackupInstance` | `DeletedBackupInstanceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dataprotection/resourceguards/{}` | `ResourceGuard` | `ResourceGuardResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Operations.list` | `/providers/Microsoft.DataProtection/operations` | Missing. | Present. |
| `Microsoft.DataProtection.OperationResultOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DataProtection/locations/{location}/operationResults/{operationId}` | Missing. | Present. |
| `Microsoft.DataProtection.OperationStatusOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DataProtection/locations/{location}/operationStatus/{operationId}` | Missing. | Present. |
| `Microsoft.DataProtection.OperationStatusResourceGroupContextOperationGroup.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/operationStatus/{operationId}` | Missing. | Present. |

