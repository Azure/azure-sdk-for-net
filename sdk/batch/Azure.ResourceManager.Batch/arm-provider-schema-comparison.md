# ARM provider schema comparison: Azure.ResourceManager.Batch

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns; 1 resource model difference; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 8 matching normalized patterns; 0 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 8 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}` | `Microsoft.Batch.BatchAccountData` | `Microsoft.Batch.BatchAccount` | `Microsoft.Batch/batchAccounts` | `Microsoft.Batch/batchAccounts` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Batch.NetworkSecurityPerimeterConfigurations.reconcileConfiguration` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}/reconcile` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Batch.NetworkSecurityPerimeterConfigurations.reconcileConfiguration` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}/reconcile` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 7 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/applications/{}` | `BatchApplication` | `Application` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/applications/{}/versions/{}` | `BatchApplicationPackage` | `ApplicationPackage` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/detectors/{}` | `BatchAccountDetector` | `DetectorResponse` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/networksecurityperimeterconfigurations/{}` | `NetworkSecurityPerimeterConfiguration` | `BatchAccountNetworkSecurityPerimeterConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/pools/{}` | `BatchAccountPool` | `Pool` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/privateendpointconnections/{}` | `BatchPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.batch/batchaccounts/{}/privatelinkresources/{}` | `BatchPrivateLinkResource` | `PrivateLinkResource` |

