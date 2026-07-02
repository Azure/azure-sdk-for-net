# ARM provider schema comparison: Azure.ResourceManager.BotService

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 resource model differences; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 5 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 3 differences. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 5 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 3 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}` | `Microsoft.BotService.BotReplacement` | `Microsoft.BotService.Bot` | `Microsoft.BotService/botServices` | `Microsoft.BotService/botServices` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}/channels/{}` | `Microsoft.BotService.BotChannelReplacement` | `Microsoft.BotService.BotChannel` | `Microsoft.BotService/botServices/channels` | `Microsoft.BotService/botServices/channels` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}/connections/{}` | `Microsoft.BotService.ConnectionSettingReplacement` | `Microsoft.BotService.ConnectionSetting` | `Microsoft.BotService/botServices/connections` | `Microsoft.BotService/botServices/connections` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.BotService.BotChannels.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}` | Present. | Missing. |
| `Microsoft.BotService.BotChannels.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.BotService.BotChannels.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}` | Missing. | Present. |
| `Microsoft.BotService.BotChannels.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}/connections/{}` | `BotConnectionSetting` | `ConnectionSetting` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}/networksecurityperimeterconfigurations/{}` | `BotServiceNetworkSecurityPerimeterConfiguration` | `NetworkSecurityPerimeterConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.botservice/botservices/{}/privateendpointconnections/{}` | `BotServicePrivateEndpointConnection` | `PrivateEndpointConnection` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Legacy.Operations.list` | `/providers/Microsoft.BotService/operations` | Missing. | Present. |
| `Microsoft.BotService.OperationResultsOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.BotService/operationresults/{operationResultId}` | Missing. | Present. |

