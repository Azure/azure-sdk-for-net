# ARM provider schema comparison: Azure.ResourceManager.DeviceRegistry

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns; 1 resource model difference; 2 CRUD operation differences; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 13 matching normalized patterns; 0 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 2 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 13 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/discoveredAssetEndpointProfiles/{discoveredAssetEndpointProfileName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/discoveredAssets/{discoveredAssetName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}/credentials/default/policies/{}` | `Missing` | `Microsoft.DeviceRegistry.PolicyV1` | `Missing` | `Microsoft.DeviceRegistry/namespaces/credentials/policies` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/schemaRegistries/{schemaRegistryName}/schemas/{schemaName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DeviceRegistry.Schemas.deleteSync` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/schemaRegistries/{schemaRegistryName}/schemas/{schemaName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/schemaRegistries/{schemaRegistryName}/schemas/{schemaName}/schemaVersions/{schemaVersionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DeviceRegistry.SchemaVersions.deleteSync` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/schemaRegistries/{schemaRegistryName}/schemas/{schemaName}/schemaVersions/{schemaVersionName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/namespaces/{namespaceName}/assets/{assetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DeviceRegistry.NamespaceAssets.executeAction` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/namespaces/{namespaceName}/assets/{assetName}/executeAction` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/namespaces/{namespaceName}/credentials/default/policies/{policyName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DeviceRegistry.PoliciesV1.listByResourceGroup` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/namespaces/{namespaceName}/credentials/default/policies` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 11 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.deviceregistry/billingcontainers/{}` | `DeviceRegistryBillingContainer` | `BillingContainer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/assetendpointprofiles/{}` | `DeviceRegistryAssetEndpointProfile` | `AssetEndpointProfile` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/assets/{}` | `DeviceRegistryAsset` | `Asset` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}` | `DeviceRegistryNamespace` | `Namespace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}/assets/{}` | `DeviceRegistryNamespaceAsset` | `NamespaceAsset` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}/devices/{}` | `DeviceRegistryNamespaceDevice` | `NamespaceDevice` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}/discoveredassets/{}` | `DeviceRegistryNamespaceDiscoveredAsset` | `NamespaceDiscoveredAsset` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/namespaces/{}/discovereddevices/{}` | `DeviceRegistryNamespaceDiscoveredDevice` | `NamespaceDiscoveredDevice` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/schemaregistries/{}` | `DeviceRegistrySchemaRegistry` | `SchemaRegistry` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/schemaregistries/{}/schemas/{}` | `DeviceRegistrySchema` | `Schema` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.deviceregistry/schemaregistries/{}/schemas/{}/schemaversions/{}` | `DeviceRegistrySchemaVersion` | `SchemaVersion` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.DeviceRegistry.OperationStatus.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DeviceRegistry/locations/{location}/operationStatuses/{operationId}` | Missing. | Present. |

