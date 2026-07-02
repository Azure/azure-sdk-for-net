# ARM provider schema comparison: Azure.ResourceManager.ContainerService

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 20 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 20 | Matching normalized resource ID patterns are compared in the following sections. |
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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ContainerService.ManagedClusters.operationStatusResultGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/operations/{operationId}` | Missing. | Present. |
| `Microsoft.ContainerService.ManagedClusters.operationStatusResultList` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/operations` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ContainerService.AgentPools.getByAgentPool` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}/operations/{operationId}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 15 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.containerservice/locations/{}/guardrailsversions/{}` | `ContainerServiceGuardrailsAvailableVersion` | `GuardrailsAvailableVersion` |
| `/subscriptions/{}/providers/microsoft.containerservice/locations/{}/safeguardsversions/{}` | `ContainerServiceSafeguardsAvailableVersion` | `SafeguardsAvailableVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/maintenancewindows/{}` | `MaintenanceWindow` | `MaintenanceWindowResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}` | `ContainerServiceManagedCluster` | `ManagedCluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/agentpools/{}` | `ContainerServiceAgentPool` | `AgentPool` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/agentpools/{}/machines/{}` | `ContainerServiceMachine` | `Machine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/identitybindings/{}` | `ManagedClusterIdentityBinding` | `IdentityBinding` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/jwtauthenticators/{}` | `ManagedClusterJwtAuthenticator` | `JWTAuthenticator` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/loadbalancers/{}` | `ManagedClusterLoadBalancer` | `LoadBalancer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/maintenanceconfigurations/{}` | `ContainerServiceMaintenanceConfiguration` | `MaintenanceConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/managednamespaces/{}` | `ManagedClusterNamespace` | `ManagedNamespace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/meshmemberships/{}` | `ManagedClusterMeshMembership` | `MeshMembership` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/privateendpointconnections/{}` | `ContainerServicePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/managedclusters/{}/trustedaccessrolebindings/{}` | `ContainerServiceTrustedAccessRoleBinding` | `TrustedAccessRoleBinding` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.containerservice/snapshots/{}` | `AgentPoolSnapshot` | `Snapshot` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.ContainerService.Operations.list` | `/providers/Microsoft.ContainerService/operations` | Missing. | Present. |

