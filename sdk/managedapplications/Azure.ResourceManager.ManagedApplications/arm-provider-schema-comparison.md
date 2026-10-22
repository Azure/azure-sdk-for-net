# ARM provider schema comparison: Azure.ResourceManager.ManagedApplications

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 4 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 4 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 24 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}?disambiguation_dummy`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/jitRequests/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.Solutions.ApplicationDefinitionListOperationGroup.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitionListOperationGroup.listBySubscription (/subscriptions/{}/providers/Microsoft.Solutions/applicationDefinitions) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Solutions.ApplicationDefinitionOpsById.createOrUpdateById (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}?disambiguation_dummy) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitionOpsById.deleteById (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}?disambiguation_dummy) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitionOpsById.getById (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}?disambiguation_dummy) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitionOpsById.updateById (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}?disambiguation_dummy) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitions.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitions.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitions.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.ApplicationDefinitions.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applicationDefinitions/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.listAllowedUpgradePlans (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}/listAllowedUpgradePlans) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.listBySubscription (/subscriptions/{}/providers/Microsoft.Solutions/applications) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Solutions.Applications.listTokens (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}/listTokens) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.refreshPermissions (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}/refreshPermissions) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.Applications.updateAccess (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/applications/{}/updateAccess) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.JitRequestDefinitions.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/jitRequests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.JitRequestDefinitions.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/jitRequests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.JitRequestDefinitions.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/jitRequests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Solutions.JitRequestDefinitions.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Solutions/jitRequests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
