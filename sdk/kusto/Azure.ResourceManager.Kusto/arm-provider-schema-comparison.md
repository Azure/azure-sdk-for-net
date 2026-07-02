# ARM provider schema comparison: Azure.ResourceManager.Kusto

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns; 3 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching normalized patterns; 2 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 9 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections/{dataConnectionName}` |
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

**Differences:** 3 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Kusto.DataConnections.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections/{dataConnectionName}` | Missing. | Present. |
| `Microsoft.Kusto.DataConnections.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections/{dataConnectionName}` | Missing. | Present. |
| `Microsoft.Kusto.DataConnections.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections/{dataConnectionName}` | Missing. | Present. |
| `Microsoft.Kusto.DataConnections.listByDatabase` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections` | Missing. | Present. |
| `Microsoft.Kusto.DataConnections.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnections/{dataConnectionName}` | Missing. | Present. |
| `Microsoft.Kusto.Databases.addPrincipals` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/addPrincipals` | Missing. | Present. |
| `Microsoft.Kusto.Databases.checkNameAvailability` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/checkPrincipalAssignmentNameAvailability` | Missing. | Present. |
| `Microsoft.Kusto.Databases.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}` | Missing. | Present. |
| `Microsoft.Kusto.Databases.dataConnectionValidation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/dataConnectionValidation` | Missing. | Present. |
| `Microsoft.Kusto.Databases.dataConnectionsCheckNameAvailability` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/checkNameAvailability` | Missing. | Present. |
| `Microsoft.Kusto.Databases.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}` | Missing. | Present. |
| `Microsoft.Kusto.Databases.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}` | Missing. | Present. |
| `Microsoft.Kusto.Databases.inviteFollower` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/inviteFollower` | Missing. | Present. |
| `Microsoft.Kusto.Databases.listByCluster` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases` | Missing. | Present. |
| `Microsoft.Kusto.Databases.listPrincipals` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/listPrincipals` | Missing. | Present. |
| `Microsoft.Kusto.Databases.removePrincipals` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/removePrincipals` | Missing. | Present. |
| `Microsoft.Kusto.Databases.scriptsCheckNameAvailability` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/scriptsCheckNameAvailability` | Missing. | Present. |
| `Microsoft.Kusto.Databases.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/principalAssignments/{principalAssignmentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Kusto.DatabasePrincipalAssignments.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/principalAssignments` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/scripts/{scriptName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Kusto.Scripts.listByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}/scripts` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 8 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}` | `KustoCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/attacheddatabaseconfigurations/{}` | `KustoAttachedDatabaseConfiguration` | `AttachedDatabaseConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/databases/{}/principalassignments/{}` | `KustoDatabasePrincipalAssignment` | `DatabasePrincipalAssignment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/databases/{}/scripts/{}` | `KustoScript` | `Script` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/managedprivateendpoints/{}` | `KustoManagedPrivateEndpoint` | `ManagedPrivateEndpoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/principalassignments/{}` | `KustoClusterPrincipalAssignment` | `ClusterPrincipalAssignment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/privateendpointconnections/{}` | `KustoPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.kusto/clusters/{}/privatelinkresources/{}` | `KustoPrivateLinkResource` | `PrivateLinkResource` |

