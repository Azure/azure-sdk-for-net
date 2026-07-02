# ARM provider schema comparison: Azure.ResourceManager.TrafficManager

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

7 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 7 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 7 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 0 | None. |
| Legacy only | 7 | `/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/AzureEndpoints/{endpointName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/ExternalEndpoints/{endpointName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/heatMaps/{heatMapType}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/NestedEndpoints/{endpointName}` |
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

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 15 non-resource method difference(s) were found.

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Network.Endpoints.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}` | Missing. | Present. |
| `Microsoft.Network.Endpoints.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}` | Missing. | Present. |
| `Microsoft.Network.Endpoints.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}` | Missing. | Present. |
| `Microsoft.Network.Endpoints.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}` | Missing. | Present. |
| `Microsoft.Network.HeatMapModels.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/heatMaps/{heatMapType}` | Missing. | Present. |
| `Microsoft.Network.Profiles.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.listByResourceGroup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles` | Missing. | Present. |
| `Microsoft.Network.Profiles.listBySubscription` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficmanagerprofiles` | Missing. | Present. |
| `Microsoft.Network.Profiles.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.TrafficManagerGeographicHierarchies.getDefault` | `/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default` | Missing. | Present. |
| `Microsoft.Network.UserMetricsModels.createOrUpdate` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default` | Missing. | Present. |
| `Microsoft.Network.UserMetricsModels.delete` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default` | Missing. | Present. |
| `Microsoft.Network.UserMetricsModels.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default` | Missing. | Present. |

