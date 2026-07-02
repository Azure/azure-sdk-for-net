# ARM provider schema comparison: Azure.ResourceManager.NetApp

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 9 resolve-only normalized resource ID patterns; 1 CRUD operation difference; 3 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 17 matching normalized patterns; 0 legacy-only; 9 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 9 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 17 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 9 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/activeDirectoryConfigs/{activeDirectoryConfigName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticBackupPolicies/{backupPolicyName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticBackupVaults/{backupVaultName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticBackupVaults/{backupVaultName}/elasticBackups/{backupName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticCapacityPools/{poolName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticCapacityPools/{poolName}/elasticVolumes/{volumeName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticCapacityPools/{poolName}/elasticVolumes/{volumeName}/elasticSnapshots/{snapshotName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/elasticAccounts/{accountName}/elasticSnapshotPolicies/{snapshotPolicyName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetApp.NetAppAccounts.updatePrevious` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 3 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetApp.NetAppAccounts.refreshLdapBindPassword` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/refreshLdapBindPassword` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/caches/{cacheName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetApp.Caches.listByCapacityPools` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/caches` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetApp.Volumes.listGetGroupIdListForLdapUser20250601` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/getGroupIdListForLdapUser` | Missing. | Present. |
| `Microsoft.NetApp.Volumes.oldlistReplications` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/oldlistReplications` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 12 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.netapp/locations/{}/quotalimits/{}` | `NetAppSubscriptionQuotaItem` | `QuotaItem` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/backuppolicies/{}` | `NetAppBackupPolicy` | `BackupPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/backupvaults/{}` | `NetAppBackupVault` | `BackupVault` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/backupvaults/{}/backups/{}` | `NetAppBackupVaultBackup` | `Backup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/caches/{}` | `NetAppCache` | `Cache` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/volumes/{}` | `NetAppVolume` | `Volume` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/volumes/{}/buckets/{}` | `NetAppBucket` | `Bucket` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/volumes/{}/snapshots/{}` | `NetAppVolumeSnapshot` | `Snapshot` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/volumes/{}/subvolumes/{}` | `NetAppSubvolumeInfo` | `SubvolumeInfo` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/capacitypools/{}/volumes/{}/volumequotarules/{}` | `NetAppVolumeQuotaRule` | `VolumeQuotaRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/quotalimits/{}` | `NetAppResourceQuotaLimitsAccount` | `NetAppAccountsQuotaLimits` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.netapp/netappaccounts/{}/volumegroups/{}` | `NetAppVolumeGroup` | `VolumeGroupDetails` |

