# ARM provider schema comparison: Azure.ResourceManager.RecoveryServicesSiteRecovery

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns; 2 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 24 matching normalized patterns; 0 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 24 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}/replicationProtectionContainers/{protectionContainerName}/replicationProtectionClusters/{replicationProtectionClusterName}/operationResults/{jobId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.Fabrics.purge` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}/replicationRecoveryServicesProviders/{providerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.RecoveryServicesProviders.purge` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}/replicationRecoveryServicesProviders/{providerName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/providers/Microsoft.RecoveryServices/replicationEligibilityResults/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/providers/Microsoft.RecoveryServices/replicationEligibilityResults` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachines/{}/providers/microsoft.recoveryservices/replicationeligibilityresults/default` | `ReplicationEligibilityResult` | `ReplicationEligibilityResults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationalertsettings/{}` | `SiteRecoveryAlert` | `Alert` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationevents/{}` | `SiteRecoveryEvent` | `Event` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}` | `SiteRecoveryFabric` | `Fabric` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationlogicalnetworks/{}` | `SiteRecoveryLogicalNetwork` | `LogicalNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationnetworks/{}` | `SiteRecoveryNetwork` | `Network` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationnetworks/{}/replicationnetworkmappings/{}` | `SiteRecoveryNetworkMapping` | `NetworkMapping` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationprotectioncontainers/{}` | `SiteRecoveryProtectionContainer` | `ProtectionContainer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationprotectioncontainers/{}/replicationmigrationitems/{}` | `SiteRecoveryMigrationItem` | `MigrationItem` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationprotectioncontainers/{}/replicationprotectableitems/{}` | `SiteRecoveryProtectableItem` | `ProtectableItem` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationprotectioncontainers/{}/replicationprotecteditems/{}/recoverypoints/{}` | `SiteRecoveryPoint` | `RecoveryPoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationrecoveryservicesproviders/{}` | `SiteRecoveryServicesProvider` | `RecoveryServicesProvider` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationfabrics/{}/replicationvcenters/{}` | `SiteRecoveryVCenter` | `VCenter` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationjobs/{}` | `SiteRecoveryJob` | `Job` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationpolicies/{}` | `SiteRecoveryPolicy` | `Policy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationrecoveryplans/{}` | `SiteRecoveryRecoveryPlan` | `RecoveryPlan` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/replicationvaultsettings/{}` | `SiteRecoveryVaultSetting` | `VaultSetting` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.RecoveryServices.OperationsOperationGroup.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/operations` | Missing. | Present. |
| `Microsoft.RecoveryServices.ReplicationEligibilityResultsOperationGroup.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/providers/Microsoft.RecoveryServices/replicationEligibilityResults` | Present. | Missing. |

