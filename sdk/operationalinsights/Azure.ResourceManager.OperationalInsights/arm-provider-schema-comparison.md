# ARM provider schema comparison: Azure.ResourceManager.OperationalInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 2 resolve-only normalized resource ID patterns; 1 CRUD operation difference; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 1 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 1 legacy-only normalized pattern(s), 2 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 11 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources/{dataSourceName}` |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/operations/{purgeId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.OperationalInsights.Workspaces.gatewaysDelete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/gateways/{gatewayId}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.OperationalInsights.LogAnalyticsQueryPacks.search` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}/queries/search` | Different. | Different. |
| `Microsoft.OperationalInsights.QueryPacksOperationGroup.createOrUpdateWithoutName` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.OperationalInsights.DataSources.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources/{dataSourceName}` | Missing. | Present. |
| `Microsoft.OperationalInsights.DataSources.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources/{dataSourceName}` | Missing. | Present. |
| `Microsoft.OperationalInsights.DataSources.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources/{dataSourceName}` | Missing. | Present. |
| `Microsoft.OperationalInsights.DataSources.listByWorkspace` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources` | Missing. | Present. |
| `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.getNSP` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}` | Present. | Missing. |
| `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.listNSP` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/networkSecurityPerimeterConfigurations` | Present. | Missing. |
| `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.reconcileNSP` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterConfigurationName}/reconcile` | Present. | Missing. |
| `Microsoft.OperationalInsights.Workspaces.gatewaysDelete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/gateways/{gatewayId}` | Present. | Missing. |
| `Microsoft.OperationalInsights.Workspaces.getPurgeStatus` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/operations/{purgeId}` | Present. | Missing. |
| `Microsoft.OperationalInsights.Workspaces.schemaGet` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/schema` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 9 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/clusters/{}` | `OperationalInsightsCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/querypacks/{}/queries/{}` | `LogAnalyticsQuery` | `LogAnalyticsQueryPackQuery` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}` | `OperationalInsightsWorkspace` | `Workspace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/dataexports/{}` | `OperationalInsightsDataExport` | `DataExport` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/linkedservices/{}` | `OperationalInsightsLinkedService` | `LinkedService` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/linkedstorageaccounts/{}` | `OperationalInsightsLinkedStorageAccounts` | `WorkspacesLinkedStorageAccounts` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/savedsearches/{}` | `OperationalInsightsSavedSearch` | `SavedSearch` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/summarylogs/{}` | `OperationalInsightsSummaryLogs` | `WorkspacesSummaryLogs` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/tables/{}` | `OperationalInsightsTable` | `WorkspacesTables` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.OperationalInsights.QueryPacksOperationGroup.createOrUpdateWithoutName` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks` | Present. | Missing. |

