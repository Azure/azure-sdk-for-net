# ARM provider schema comparison: Azure.ResourceManager.Maps

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

No requested-axis differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 4 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching `resourceIdPattern`, the `List` and `Action` operation sets are identical.

No list/action operation differences were found for matching resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maps/accounts/{accountName}/creators/{creatorName}` | `MapsCreator` | `Creator` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maps/accounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}` | `MapsPrivateEndpointConnection` | `MapsAccountPrivateEndpointConnection` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maps/accounts/{accountName}/privateLinkResources/{privateLinkResourceName}` | `MapsPrivateLinkResource` | `PrivateLinkResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Maps.OperationResultOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.Maps/locations/{location}/operationResults/{operationId}` | Missing. | Present. |
| `Microsoft.Maps.OperationStatusOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.Maps/locations/{location}/operationStatuses/{operationId}` | Missing. | Present. |

