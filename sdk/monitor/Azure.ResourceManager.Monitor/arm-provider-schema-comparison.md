# ARM provider schema comparison: Azure.ResourceManager.Monitor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 1 resolve-only resource ID patterns; 3 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 12 matching patterns; 2 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only pattern(s), 1 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 12 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{groupName}`<br>`/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{privateLinkResourceName}` |

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

**Differences:** 3 list/action operation differences.

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `DataCollectionApi.DataCollectionEndpointResources.listByDataCollectionEndpoint` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}/associations` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `DataCollectionApi.DataCollectionRuleResources.listByRule` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}/associations` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `MetricAlertApi.MetricAlertResources.list` | `List` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}/status` | Different. | Different. |
| `MetricAlertApi.MetricAlertResources.listByName` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}/status/{statusName}` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 11 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 3 non-resource method difference(s) were found.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Insights/logprofiles/{logProfileName}` | `LogProfile` | `LogProfileResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/actionGroups/{actionGroupName}` | `ActionGroup` | `ActionGroupResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/activityLogAlerts/{activityLogAlertName}` | `ActivityLogAlert` | `ActivityLogAlertResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/autoscalesettings/{autoscaleSettingName}` | `AutoscaleSetting` | `AutoscaleSettingResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}` | `DataCollectionEndpoint` | `DataCollectionEndpointResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}` | `DataCollectionRule` | `DataCollectionRuleResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/metricAlerts/{ruleName}` | `MetricAlert` | `MetricAlertResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}` | `MonitorPrivateLinkScope` | `AzureMonitorPrivateLinkScope` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateEndpointConnections/{privateEndpointConnectionName}` | `MonitorPrivateEndpointConnection` | `AzureMonitorPrivateLinkScopePrivateEndpointConnection` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/scopedResources/{name}` | `MonitorPrivateLinkScopedResource` | `ScopedResource` |
| `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/scheduledQueryRules/{ruleName}` | `ScheduledQueryRule` | `ScheduledQueryRuleResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.createOrUpdate` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.get` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |
| `ServiceDiagnosticsSettingsApi.ServiceDiagnosticSettingsResources.update` | `/{resourceUri}/providers/microsoft.insights/diagnosticSettings/service` | Missing. | Present. |

