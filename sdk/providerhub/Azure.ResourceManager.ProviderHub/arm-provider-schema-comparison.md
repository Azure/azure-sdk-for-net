# ARM provider schema comparison: Azure.ResourceManager.ProviderHub

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 12 matching normalized patterns; 0 legacy-only; 1 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 1 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}/operations/default`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}`
  - legacy-only: `Microsoft.ProviderHub.OperationsPutContents.createOrUpdate (Action) /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}/operations/default [Subscription: /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}, Microsoft.Resources/subscriptions]`; `Microsoft.ProviderHub.OperationsPutContents.delete (Action) /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}/operations/default [Subscription: /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}, Microsoft.Resources/subscriptions]`; `Microsoft.ProviderHub.OperationsPutContents.listByProviderRegistration (Action) /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}/operations/default [Subscription: /subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}, Microsoft.Resources/subscriptions]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
