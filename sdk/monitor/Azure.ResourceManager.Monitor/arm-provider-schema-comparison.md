# ARM provider schema comparison: Azure.ResourceManager.Monitor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 0 resolve-only normalized resource ID patterns; 3 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 13 matching normalized patterns; 1 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** 1 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 13 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 1 | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` |
| `resolveArmResources` only | 0 | None. |

### Raw resource ID variable-name differences

Raw resource ID pattern mismatches reduced after normalizing path variable names. This means at least some raw differences are only parameter-name differences such as `{name}` vs `{labName}`.

| Raw legacy-only | Raw `resolveArmResources`-only | Normalized legacy-only | Normalized `resolveArmResources`-only |
| ---: | ---: | ---: | ---: |
| 2 | 1 | 1 | 0 |

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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `DataCollectionApi.DataCollectionEndpointResources.listByDataCollectionEndpoint` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}/associations` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `DataCollectionApi.DataCollectionRuleResources.listByRule` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}/associations` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `MetricAlertApi.MetricAlertResources.list` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}/status` | Different. | Different. |
| `MetricAlertApi.MetricAlertResources.listByName` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}/status/{statusName}` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 12 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 3 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.insights/logprofiles/{}` | `LogProfile` | `LogProfileResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/actiongroups/{}` | `ActionGroup` | `ActionGroupResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/activitylogalerts/{}` | `ActivityLogAlert` | `ActivityLogAlertResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/autoscalesettings/{}` | `AutoscaleSetting` | `AutoscaleSettingResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/datacollectionendpoints/{}` | `DataCollectionEndpoint` | `DataCollectionEndpointResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/datacollectionrules/{}` | `DataCollectionRule` | `DataCollectionRuleResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/metricalerts/{}` | `MetricAlert` | `MetricAlertResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/privatelinkscopes/{}` | `MonitorPrivateLinkScope` | `AzureMonitorPrivateLinkScope` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/privatelinkscopes/{}/privateendpointconnections/{}` | `MonitorPrivateEndpointConnection` | `AzureMonitorPrivateLinkScopePrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/privatelinkscopes/{}/privatelinkresources/{}` | `MonitorPrivateLinkResource` | `AzureMonitorPrivateLinkScopePrivateLinkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/privatelinkscopes/{}/scopedresources/{}` | `MonitorPrivateLinkScopedResource` | `ScopedResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.insights/scheduledqueryrules/{}` | `ScheduledQueryRule` | `ScheduledQueryRuleResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.createOrUpdate` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.get` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.update` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |

