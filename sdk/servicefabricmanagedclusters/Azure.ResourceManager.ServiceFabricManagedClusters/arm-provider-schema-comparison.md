# ARM provider schema comparison: Azure.ResourceManager.ServiceFabricManagedClusters

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 6 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 6 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ServiceFabric.ManagedClusters.getFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/getFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.ManagedClusters.listFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/listFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.ManagedClusters.startFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/startFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.ManagedClusters.stopFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/stopFaultSimulation` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ServiceFabric.NodeTypes.getFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}/getFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.NodeTypes.listFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}/listFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.NodeTypes.startFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}/startFaultSimulation` | Missing. | Present. |
| `Microsoft.ServiceFabric.NodeTypes.stopFaultSimulation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}/stopFaultSimulation` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 6 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}` | `ServiceFabricManagedCluster` | `ManagedCluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}/applications/{}` | `ServiceFabricManagedApplication` | `ApplicationResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}/applications/{}/services/{}` | `ServiceFabricManagedService` | `ServiceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}/applicationtypes/{}` | `ServiceFabricManagedApplicationType` | `ApplicationTypeResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}/applicationtypes/{}/versions/{}` | `ServiceFabricManagedApplicationTypeVersion` | `ApplicationTypeVersionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.servicefabric/managedclusters/{}/nodetypes/{}` | `ServiceFabricManagedNodeType` | `NodeType` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.ServiceFabric.OperationResults.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedClusterOperationResults/{operationId}` | Missing. | Present. |
| `Microsoft.ServiceFabric.OperationStatus.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedClusterOperations/{operationId}` | Missing. | Present. |

