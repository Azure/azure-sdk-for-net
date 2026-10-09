# ARM provider schema comparison: Azure.ResourceManager.Monitor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 14 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 1 legacy-only raw; 1 resolve-only raw; 2 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionEndpoints/{}`
  - legacy-only: `DataCollectionApi.DataCollectionEndpointResources.listByDataCollectionEndpoint (Action) /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionEndpoints/{}/associations [ResourceGroup: /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionEndpoints/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `DataCollectionApi.DataCollectionEndpointResources.listByDataCollectionEndpoint (List) /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionEndpoints/{}/associations [ResourceGroup: /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionEndpoints/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionRules/{}`
  - legacy-only: `DataCollectionApi.DataCollectionRuleResources.listByRule (Action) /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionRules/{}/associations [ResourceGroup: /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionRules/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `DataCollectionApi.DataCollectionRuleResources.listByRule (List) /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionRules/{}/associations [ResourceGroup: /subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/dataCollectionRules/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
