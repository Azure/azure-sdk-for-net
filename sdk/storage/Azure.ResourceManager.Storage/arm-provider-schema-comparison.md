# ARM provider schema comparison: Azure.ResourceManager.Storage

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 3 resolve-only normalized resource ID patterns; 2 CRUD operation differences; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 21 matching normalized patterns; 2 legacy-only; 3 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only normalized pattern(s), 3 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 21 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/default`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/default` |
| `resolveArmResources` only | 3 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/advancedPlatformMetrics/{advancedPlatformMetricsRuleType}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Storage.ImmutabilityPolicies.createOrUpdateImmutabilityPolicy` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Storage.Tables.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}` | Present. | Missing. |
| `Microsoft.Storage.Tables.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Storage.ImmutabilityPolicies.createOrUpdateImmutabilityPolicy` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Storage.Tables.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}` | Missing. | Present. |
| `Microsoft.Storage.Tables.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 8 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/blobservices/default` | `BlobService` | `BlobServiceProperties` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/connectors/{}` | `StorageConnector` | `Connector` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/datashares/{}` | `StorageDataShare` | `DataShare` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/fileservices/default` | `FileService` | `FileServiceProperties` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/localusers/{}` | `StorageAccountLocalUser` | `LocalUser` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/privateendpointconnections/{}` | `StoragePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/queueservices/default` | `QueueService` | `QueueServiceProperties` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.storage/storageaccounts/{}/tableservices/default` | `TableService` | `TableServiceProperties` |

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 5 |
| Found in Bicep reference | 5 |
| Found in package API version | 2 |
| Found only outside package API versions | 3 |
| Not found in Bicep reference | 0 |

**Result:** `inventoryPolicies` and `managementPolicies` are singleton resources in this package's API versions. Bicep shows fixed name `default`, matching the legacy paths. `resolveArmResources` uses parameterized names for those two resources, which does not match Bicep. `advancedPlatformMetrics` is a real ARM resource but appears only in `2026-04-01`, outside this package's generated API versions (`2025-06-01`, `2025-08-01`), so it is a version/projection mismatch rather than a current legacy miss.

For operation differences, `immutabilityPolicies/default` and `tableServices/default/tables/{tableName}` are real resources in the package API versions, but `resolveArmResources` classifies their create/update operations as actions on the parent. These likely need separate operation-classification review.

| Side | Resource type | Path shape | Bicep API versions | Resource schema API versions |
| --- | --- | --- | --- | --- |
| Legacy only | [Microsoft.Storage/storageAccounts/inventoryPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.storage/storageaccounts/inventorypolicies?pivots=deployment-language-bicep) | `default` singleton, matches Bicep `name: 'default'` | `2026-04-01`, `2025-08-01`, `2025-06-01`, `2025-01-01`, `2024-01-01`, `2023-05-01`, `2023-04-01`, `2023-01-01`, `2022-09-01`, `2022-05-01`, `2021-09-01`, `2021-08-01`, `2021-06-01`, `2021-04-01`, `2021-02-01`, `2021-01-01`, `2020-08-01-preview`, `2019-06-01` | `2025-06-01`, `2025-08-01` |
| `resolveArmResources` only | [Microsoft.Storage/storageAccounts/inventoryPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.storage/storageaccounts/inventorypolicies?pivots=deployment-language-bicep) | parameterized `{blobInventoryPolicyName}`, does not match Bicep singleton name | `2026-04-01`, `2025-08-01`, `2025-06-01`, `2025-01-01`, `2024-01-01`, `2023-05-01`, `2023-04-01`, `2023-01-01`, `2022-09-01`, `2022-05-01`, `2021-09-01`, `2021-08-01`, `2021-06-01`, `2021-04-01`, `2021-02-01`, `2021-01-01`, `2020-08-01-preview`, `2019-06-01` | `2025-06-01`, `2025-08-01` |
| Legacy only | [Microsoft.Storage/storageAccounts/managementPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.storage/storageaccounts/managementpolicies?pivots=deployment-language-bicep) | `default` singleton, matches Bicep `name: 'default'` | `2026-04-01`, `2025-08-01`, `2025-06-01`, `2025-01-01`, `2024-01-01`, `2023-05-01`, `2023-04-01`, `2023-01-01`, `2022-09-01`, `2022-05-01`, `2021-09-01`, `2021-08-01`, `2021-06-01`, `2021-04-01`, `2021-02-01`, `2021-01-01`, `2020-08-01-preview`, `2019-06-01`, `2019-04-01`, `2018-11-01`, `2018-03-01-preview` | `2025-06-01`, `2025-08-01` |
| `resolveArmResources` only | [Microsoft.Storage/storageAccounts/managementPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.storage/storageaccounts/managementpolicies?pivots=deployment-language-bicep) | parameterized `{managementPolicyName}`, does not match Bicep singleton name | `2026-04-01`, `2025-08-01`, `2025-06-01`, `2025-01-01`, `2024-01-01`, `2023-05-01`, `2023-04-01`, `2023-01-01`, `2022-09-01`, `2022-05-01`, `2021-09-01`, `2021-08-01`, `2021-06-01`, `2021-04-01`, `2021-02-01`, `2021-01-01`, `2020-08-01-preview`, `2019-06-01`, `2019-04-01`, `2018-11-01`, `2018-03-01-preview` | `2025-06-01`, `2025-08-01` |
| `resolveArmResources` only | [Microsoft.Storage/storageAccounts/advancedPlatformMetrics](https://learn.microsoft.com/en-us/azure/templates/microsoft.storage/storageaccounts/advancedplatformmetrics?pivots=deployment-language-bicep) | outside package version | `2026-04-01` | None |
