# ARM provider schema comparison: Azure.ResourceManager.HorizonDB

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 6 matching normalized patterns; 1 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 1 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}/privateEndpointConnections/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}`
  - resolveArmResources-only: `Microsoft.HorizonDb.HorizonDbPrivateEndpointConnections.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}/privateEndpointConnections/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HorizonDb.HorizonDbPrivateEndpointConnections.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}/privateEndpointConnections [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/parameterGroups/{}`
  - legacy-only: `Microsoft.HorizonDb.HorizonDbParameterGroups.listVersions (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/parameterGroups/{}/versions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/parameterGroups/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.HorizonDb.HorizonDbParameterGroups.listVersions (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/parameterGroups/{}/versions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/parameterGroups/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
