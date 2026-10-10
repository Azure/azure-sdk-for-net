# ARM provider schema comparison: Azure.ResourceManager.EventGrid

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 27 matching normalized patterns; 5 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 5 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 4 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/networkSecurityPerimeterConfigurations/{}.{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/privateEndpointConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/partnerNamespaces/{}/privateEndpointConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/topics/{}/networkSecurityPerimeterConfigurations/{}.{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/topics/{}/privateEndpointConnections/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/{}/providers/Microsoft.EventGrid/eventSubscriptions/{}`
  - resolveArmResources-only: `Microsoft.EventGrid.EventSubscriptionOperationGroup.listByResource (List) /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.EventGrid/eventSubscriptions [Extension: /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}]`; `Microsoft.EventGrid.EventSubscriptions.listByDomainTopic (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/topics/{}/providers/Microsoft.EventGrid/eventSubscriptions [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/topics/{}, Microsoft.EventGrid/domains/topics]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/topics/{}`
  - legacy-only: `Microsoft.EventGrid.EventSubscriptions.listByDomainTopic (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/topics/{}/providers/Microsoft.EventGrid/eventSubscriptions [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/domains/{}/topics/{}, Microsoft.EventGrid/domains/topics]`


### Legacy-only non-resource methods

- `Microsoft.EventGrid.EventSubscriptionOperationGroup.listByResource (/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.EventGrid/eventSubscriptions) Extension [/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}: ]`


### resolveArmResources-only non-resource methods

- `Microsoft.EventGrid.NetworkSecurityPerimeterConfigurations.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/{}/{}/networkSecurityPerimeterConfigurations/{}.{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.EventGrid.PrivateEndpointConnections.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/{}/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.EventGrid.PrivateEndpointConnections.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/{}/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.EventGrid.PrivateEndpointConnections.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventGrid/{}/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
