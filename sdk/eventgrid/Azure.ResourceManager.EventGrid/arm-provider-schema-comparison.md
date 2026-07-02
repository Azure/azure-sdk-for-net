# ARM provider schema comparison: Azure.ResourceManager.EventGrid

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 legacy-only and 0 resolve-only normalized resource ID patterns; 1 hierarchy difference; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 27 matching normalized patterns; 5 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | 1 difference. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 5 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 27 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 5 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{resourceName}/networkSecurityPerimeterConfigurations/{perimeterGuid}.{associationName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerNamespaces/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{resourceName}/networkSecurityPerimeterConfigurations/{perimeterGuid}.{associationName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}` |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 1 hierarchy difference.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/{}/providers/microsoft.eventgrid/eventsubscriptions/{}` | Extension, `scopeIdPattern: /{scope}` | ResourceGroup, `scopeIdPattern: /{scope}` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{domainTopicName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventGrid.EventSubscriptions.listByDomainTopic` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{topicName}/providers/Microsoft.EventGrid/eventSubscriptions` | Present. | Missing. |

#### List and action operations differences: `/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.EventGrid.EventSubscriptionOperationGroup.listByResource` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventSubscriptions` | Missing. | Present. |
| `Microsoft.EventGrid.EventSubscriptions.listByDomainTopic` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{topicName}/providers/Microsoft.EventGrid/eventSubscriptions` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 9 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 5 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.eventgrid/topictypes/{}` | `TopicType` | `TopicTypeInfo` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/domains/{}` | `EventGridDomain` | `Domain` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/namespaces/{}` | `EventGridNamespace` | `Namespace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/namespaces/{}/clientgroups/{}` | `EventGridNamespaceClientGroup` | `ClientGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/namespaces/{}/clients/{}` | `EventGridNamespaceClient` | `Client` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/namespaces/{}/permissionbindings/{}` | `EventGridNamespacePermissionBinding` | `PermissionBinding` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/namespaces/{}/topics/{}/eventsubscriptions/{}` | `NamespaceTopicEventSubscription` | `Subscription` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/partnernamespaces/{}/channels/{}` | `PartnerNamespaceChannel` | `Channel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.eventgrid/topics/{}` | `EventGridTopic` | `Topic` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.EventGrid.EventSubscriptionOperationGroup.listByResource` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventSubscriptions` | Present. | Missing. |
| `Microsoft.EventGrid.NetworkSecurityPerimeterConfigurations.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{resourceType}/{resourceName}/networkSecurityPerimeterConfigurations/{perimeterGuid}.{associationName}` | Missing. | Present. |
| `Microsoft.EventGrid.PrivateEndpointConnections.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}` | Missing. | Present. |
| `Microsoft.EventGrid.PrivateEndpointConnections.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}` | Missing. | Present. |
| `Microsoft.EventGrid.PrivateEndpointConnections.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}` | Missing. | Present. |

