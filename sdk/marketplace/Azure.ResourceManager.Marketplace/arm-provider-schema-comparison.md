# ARM provider schema comparison: Azure.ResourceManager.Marketplace

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 5 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 3 matching normalized patterns differ |
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

- `/providers/Microsoft.Marketplace/privateStores/{}`
  - resolveArmResources-only: `Microsoft.Marketplace.PrivateStoreCollectionOperationGroup.post (Action) /providers/Microsoft.Marketplace/privateStores/{}/collections/{} [Tenant: /providers/Microsoft.Marketplace/privateStores/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Marketplace/privateStores/{}/collections/{}`
  - legacy-only: `Microsoft.Marketplace.PrivateStoreCollectionOperationGroup.post (Action) /providers/Microsoft.Marketplace/privateStores/{}/collections/{} [Tenant: /providers/Microsoft.Marketplace/privateStores/{}/collections/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Marketplace.PrivateStoreCollectionOfferOperationGroup.post (Action) /providers/Microsoft.Marketplace/privateStores/{}/collections/{}/offers/{} [Tenant: /providers/Microsoft.Marketplace/privateStores/{}/collections/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Marketplace/privateStores/{}/collections/{}/offers/{}`
  - legacy-only: `Microsoft.Marketplace.PrivateStoreCollectionOfferOperationGroup.post (Action) /providers/Microsoft.Marketplace/privateStores/{}/collections/{}/offers/{} [Tenant: /providers/Microsoft.Marketplace/privateStores/{}/collections/{}/offers/{}, Microsoft.Resources/tenants]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
