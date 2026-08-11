# ARM provider schema comparison: Azure.ResourceManager.Storage

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 21 matching normalized patterns; 2 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 2 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/inventoryPolicies/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/managementPolicies/default`


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/inventoryPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/managementPolicies/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}/immutabilityPolicies/default`
  - legacy-only: `Microsoft.Storage.ImmutabilityPolicies.createOrUpdateImmutabilityPolicy (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}/immutabilityPolicies/default [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}/immutabilityPolicies/default, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{}`
  - legacy-only: `Microsoft.Storage.Tables.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Storage.Tables.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}`
  - resolveArmResources-only: `Microsoft.Storage.ImmutabilityPolicies.createOrUpdateImmutabilityPolicy (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}/immutabilityPolicies/default [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/blobServices/default/containers/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default`
  - resolveArmResources-only: `Microsoft.Storage.Tables.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default, Microsoft.Resources/resourceGroups]`; `Microsoft.Storage.Tables.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default/tables/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Storage/storageAccounts/{}/tableServices/default, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
