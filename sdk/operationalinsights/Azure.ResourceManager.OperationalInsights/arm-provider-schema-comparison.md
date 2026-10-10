# ARM provider schema comparison: Azure.ResourceManager.OperationalInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 1 legacy-only; 1 resolve-only |
| Raw resource ID patterns | 1 legacy-only raw; 1 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/dataSources/{}`


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/operations/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks/{}`
  - legacy-only: `Microsoft.OperationalInsights.LogAnalyticsQueryPacks.search (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks/{}/queries/search [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.OperationalInsights.LogAnalyticsQueryPacks.search (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks/{}/queries/search [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.QueryPacksOperationGroup.createOrUpdateWithoutName (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks [ResourceGroup: /subscriptions/{}/resourceGroups/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}`
  - legacy-only: `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.getNSP (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/networkSecurityPerimeterConfigurations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.listNSP (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/networkSecurityPerimeterConfigurations [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.NetworkSecurityPerimeterConfigurations.reconcileNSP (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/networkSecurityPerimeterConfigurations/{}/reconcile [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.Workspaces.getPurgeStatus (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/operations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.OperationalInsights.DataSources.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/dataSources/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.DataSources.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/dataSources/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.DataSources.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/dataSources/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.OperationalInsights.DataSources.listByWorkspace (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/dataSources [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

- `Microsoft.OperationalInsights.QueryPacksOperationGroup.createOrUpdateWithoutName (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/queryPacks) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`


### resolveArmResources-only non-resource methods

None.
