# ARM provider schema comparison: Azure.ResourceManager.EventHubs

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 resource model differences; 1 CRUD operation difference; 3 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 13 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 2 differences. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 13 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 2 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/clusters/{}` | `Microsoft.EventHub.EventHubsCluster` | `Microsoft.EventHub.Cluster` | `Microsoft.EventHub/clusters` | `Microsoft.EventHub/clusters` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}` | `Microsoft.EventHub.EventHubsNamespace` | `Microsoft.EventHub.EHNamespace` | `Microsoft.EventHub/namespaces` | `Microsoft.EventHub/namespaces` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventHub.NetworkSecurityPerimeterConfigurations.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}/reconcile` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 3 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventHub.NetworkRuleSets.listNetworkRuleSet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventHub.NetworkRuleSets.listNetworkRuleSet` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventHub.NetworkSecurityPerimeterConfigurations.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}/reconcile` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/clusters/{}` | `EventHubsCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}` | `EventHubsNamespace` | `EHNamespace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/applicationgroups/{}` | `EventHubsApplicationGroup` | `ApplicationGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/authorizationrules/{}` | `EventHubsNamespaceAuthorizationRule` | `NamespacesAuthorizationRules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/disasterrecoveryconfigs/{}` | `EventHubsDisasterRecovery` | `ArmDisasterRecovery` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/disasterrecoveryconfigs/{}/authorizationrules/{}` | `EventHubsDisasterRecoveryAuthorizationRule` | `DisasterRecoveryConfigsAuthorizationRules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/eventhubs/{}` | `EventHub` | `Eventhub` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/eventhubs/{}/authorizationrules/{}` | `EventHubAuthorizationRule` | `EventhubsAuthorizationRules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/eventhubs/{}/consumergroups/{}` | `EventHubsConsumerGroup` | `ConsumerGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/networkrulesets/default` | `EventHubsNetworkRuleSet` | `NetworkRuleSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/networksecurityperimeterconfigurations/{}` | `EventHubsNetworkSecurityPerimeterConfiguration` | `NetworkSecurityPerimeterConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/privateendpointconnections/{}` | `EventHubsPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventhub/namespaces/{}/schemagroups/{}` | `EventHubsSchemaGroup` | `SchemaGroup` |

