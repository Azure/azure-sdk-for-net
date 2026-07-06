# ARM provider schema comparison: Azure.ResourceManager.HDInsight

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 4 matching normalized patterns; 0 legacy-only; 6 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 6 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 6 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/applications/{applicationName}/azureasyncoperations/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/azureasyncoperations/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/configurations/{configurationName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/extensions/{extensionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/extensions/{extensionName}/azureAsyncOperations/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/scriptExecutionHistory/{scriptExecutionId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.HDInsight.ScriptActions.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/scriptActions/{scriptName}` | Missing. | Present. |
| `Microsoft.HDInsight.ScriptActions.getExecutionAsyncOperationStatus` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/executeScriptActions/azureasyncoperations/{operationId}` | Missing. | Present. |
| `Microsoft.HDInsight.VirtualMachines.getAsyncOperationStatus` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/restartHosts/azureasyncoperations/{operationId}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.HDInsight.Extensions.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/extensions/{extensionName}` | Present. | Missing. |
| `Microsoft.HDInsight.ScriptActions.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/scriptActions/{scriptName}` | Present. | Missing. |
| `Microsoft.HDInsight.ScriptExecutionHistory.promote` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/scriptExecutionHistory/{scriptExecutionId}/promote` | Present. | Missing. |
| `Microsoft.HDInsight.VirtualMachines.restartHosts` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/restartHosts` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 4 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hdinsight/clusters/{}` | `HDInsightCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hdinsight/clusters/{}/applications/{}` | `HDInsightApplication` | `Application` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hdinsight/clusters/{}/privateendpointconnections/{}` | `HDInsightPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hdinsight/clusters/{}/privatelinkresources/{}` | `HDInsightPrivateLinkResource` | `PrivateLinkResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.HDInsight.LocationsOperationGroup.getAzureAsyncOperationStatus` | `/subscriptions/{subscriptionId}/providers/Microsoft.HDInsight/locations/{location}/azureasyncoperations/{operationId}` | Missing. | Present. |

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 6 |
| Found in Bicep reference | 0 |
| Found in package API version | 0 |
| Found only outside package API versions | 0 |
| Not found in Bicep reference | 6 |

**Result:** All six `resolveArmResources`-only resource types are not found in the Bicep reference. This supports the `client.tsp` comment that these are not standalone ARM resources; they are action endpoints or sub-operations on `Cluster` that are excluded from C# with `@@scope(..., "!csharp")`.

Temporary experiment: removing `@@scope(Configurations.get, "!csharp")` and regenerating made `Microsoft.HDInsight.Configurations.get` visible to the legacy detector, but legacy classified it as an `Action` on the `Microsoft.HDInsight/clusters` resource, not as a `Microsoft.HDInsight/clusters/configurations` resource. This confirms that the legacy detector does not promote this endpoint to a resource even when it is in the C# SDK method model.

### Not found in Bicep reference

These are problematic false-resource candidates. They are likely caused by `resolveArmResources` reading the full TypeSpec program and promoting scoped-out action/status endpoints into resources.

| Side | Resource type | Resource schema API versions | Notes |
| --- | --- | --- | --- |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/applications/azureasyncoperations` | None | Scoped out for C#; not a standalone Bicep resource. |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/azureasyncoperations` | None | Scoped out for C#; not a standalone Bicep resource. |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/configurations` | None | Scoped out for C#; not a standalone Bicep resource. |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/extensions` | `2025-01-15-preview` | Scoped out for C#; not a standalone Bicep resource. |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/extensions/azureAsyncOperations` | None | Scoped out for C#; not a standalone Bicep resource. |
| `resolveArmResources` only | `Microsoft.HDInsight/clusters/scriptExecutionHistory` | None | Scoped out for C#; not a standalone Bicep resource. |
