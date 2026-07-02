# ARM provider schema comparison: Azure.ResourceManager.ContainerInstance

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 3 matching normalized patterns; 1 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 1 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 3 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}` |
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

- 13 non-resource method difference(s) were found.

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.ContainerInstance.ContainerGroups.attach` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/attach` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.executeCommand` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/exec` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.getOutboundNetworkDependenciesEndpoints` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/outboundNetworkDependenciesEndpoints` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.listLogs` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/logs` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.restart` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.start` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.stop` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/stop` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroups.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroupsOperationGroup.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/containerGroups` | Missing. | Present. |
| `Microsoft.ContainerInstance.ContainerGroupsOperationGroup.listByResourceGroup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups` | Missing. | Present. |

