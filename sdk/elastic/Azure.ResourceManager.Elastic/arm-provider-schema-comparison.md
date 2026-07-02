# ARM provider schema comparison: Azure.ResourceManager.Elastic

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 4 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 4 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching normalized resource ID patterns are compared in the following sections. |
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

**Differences:** 4 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Elastic.ElasticMonitorResources.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}` | Present. | Missing. |
| `Microsoft.Elastic.ElasticMonitorResources.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/monitoredSubscriptions/{configurationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Elastic.MonitoredSubscriptions.createorUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/monitoredSubscriptions/{configurationName}` | Present. | Missing. |
| `Microsoft.Elastic.MonitoredSubscriptions.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/monitoredSubscriptions/{configurationName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/openAIIntegrations/{integrationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Elastic.OpenAIIntegrationRPModels.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/openAIIntegrations/{integrationName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/tagRules/{ruleSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Elastic.TagRules.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/tagRules/{ruleSetName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Elastic.MonitoredSubscriptions.createorUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/monitoredSubscriptions/{configurationName}` | Missing. | Present. |
| `Microsoft.Elastic.MonitoredSubscriptions.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/monitoredSubscriptions/{configurationName}` | Missing. | Present. |
| `Microsoft.Elastic.OpenAIIntegrationRPModels.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/openAIIntegrations/{integrationName}` | Missing. | Present. |
| `Microsoft.Elastic.TagRules.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}/tagRules/{ruleSetName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 4 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 3 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.elastic/monitors/{}` | `ElasticMonitor` | `ElasticMonitorResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.elastic/monitors/{}/monitoredsubscriptions/{}` | `ElasticMonitoredSubscription` | `MonitoredSubscriptionProperties` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.elastic/monitors/{}/openaiintegrations/{}` | `ElasticOpenAIIntegration` | `OpenAIIntegrationRPModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.elastic/monitors/{}/tagrules/{}` | `ElasticTagRule` | `MonitoringTagRules` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Legacy.Operations.list` | `/providers/Microsoft.Elastic/operations` | Missing. | Present. |
| `Microsoft.Elastic.ElasticMonitorResources.create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}` | Missing. | Present. |
| `Microsoft.Elastic.ElasticMonitorResources.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}` | Missing. | Present. |

