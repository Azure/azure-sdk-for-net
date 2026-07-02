# ARM provider schema comparison: Azure.ResourceManager.Monitor.Workspaces

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 3 matching normalized patterns; 0 legacy-only; 6 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 6 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 3 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 6 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/authenticationsettings/{authenticationSettingName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/discoveryrules/{discoveryRuleName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/entities/{entityName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/relationships/{relationshipName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/signaldefinitions/{signalDefinitionName}` |

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

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/issues/{issueName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Monitor.Issue.startInvestigation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/issues/{issueName}/startInvestigation` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}` | `MonitorWorkspace` | `AzureMonitorWorkspaceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}/issues/{}` | `MonitorIssue` | `IssueResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}/metricscontainers/{}` | `MonitorMetricsContainer` | `MetricsContainerResource` |

