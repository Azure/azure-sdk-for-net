# ARM provider schema comparison: Azure.ResourceManager.AppConfiguration

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 0 resolve-only normalized resource ID patterns; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 6 matching normalized patterns; 1 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 1 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 6 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/snapshots/{snapshotName}` |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AppConfiguration.ConfigurationStoresOperationGroup.listDeleted` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/deletedConfigurationStores` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AppConfiguration.Snapshots.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/snapshots/{snapshotName}` | Missing. | Present. |
| `Microsoft.AppConfiguration.Snapshots.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/snapshots/{snapshotName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 6 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.appconfiguration/locations/{}/deletedconfigurationstores/{}` | `DeletedAppConfigurationStore` | `DeletedConfigurationStore` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.appconfiguration/configurationstores/{}` | `AppConfigurationStore` | `ConfigurationStore` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.appconfiguration/configurationstores/{}/keyvalues/{}` | `AppConfigurationKeyValue` | `KeyValue` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.appconfiguration/configurationstores/{}/privateendpointconnections/{}` | `AppConfigurationPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.appconfiguration/configurationstores/{}/privatelinkresources/{}` | `AppConfigurationPrivateLinkResource` | `PrivateLinkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.appconfiguration/configurationstores/{}/replicas/{}` | `AppConfigurationReplica` | `Replica` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.AppConfiguration.ConfigurationStoresOperationGroup.listDeleted` | `/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/deletedConfigurationStores` | Present. | Missing. |

