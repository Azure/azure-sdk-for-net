# ARM provider schema comparison: Azure.ResourceManager.EventHubs

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 2 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 2 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventHub/clusters/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventHub/namespaces/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventHub/namespaces/{}/networkRuleSets/default`
  - resolveArmResources-only: `Microsoft.EventHub.NetworkRuleSets.listNetworkRuleSet (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventHub/namespaces/{}/networkRuleSets [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.EventHub/namespaces/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
