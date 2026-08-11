# ARM provider schema comparison: Azure.ResourceManager.Kusto

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching normalized patterns; 2 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 2 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 3 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}`
  - resolveArmResources-only: `Microsoft.Kusto.Databases.addPrincipals (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/addPrincipals [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.checkNameAvailability (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/checkPrincipalAssignmentNameAvailability [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.dataConnectionsCheckNameAvailability (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/checkNameAvailability [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.dataConnectionValidation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnectionValidation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.inviteFollower (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/inviteFollower [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.listByCluster (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.listPrincipals (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/listPrincipals [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.removePrincipals (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/removePrincipals [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.scriptsCheckNameAvailability (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/scriptsCheckNameAvailability [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.Databases.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.DataConnections.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.DataConnections.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.DataConnections.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.DataConnections.listByDatabase (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Kusto.DataConnections.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/dataConnections/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/principalAssignments/{}`
  - legacy-only: `Microsoft.Kusto.DatabasePrincipalAssignments.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/principalAssignments [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.Kusto.DatabasePrincipalAssignments.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/principalAssignments [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/scripts/{}`
  - legacy-only: `Microsoft.Kusto.Scripts.listByDatabase (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/scripts [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.Kusto.Scripts.listByDatabase (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}/databases/{}/scripts [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Kusto/clusters/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
