# ARM provider schema comparison: Azure.ResourceManager.PolicyInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 5 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 3 matching normalized patterns; 0 legacy-only; 5 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 5 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/providers/{}/managementGroups/{}/providers/Microsoft.PolicyInsights/remediations/{}`
- `/subscriptions/{}/providers/Microsoft.PolicyInsights/attestations/{}`
- `/subscriptions/{}/providers/Microsoft.PolicyInsights/remediations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.PolicyInsights/attestations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.PolicyInsights/remediations/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/providers/Microsoft.PolicyInsights/policyMetadata/{}`
  - resolveArmResources-only: `PolicyInsightsApi.PolicyMetadataNonResourceOperationGroup.list (List) /providers/Microsoft.PolicyInsights/policyMetadata [Tenant: , Microsoft.Resources/tenants]`


### Legacy-only non-resource methods

- `PolicyInsightsApi.PolicyMetadataNonResourceOperationGroup.list (/providers/Microsoft.PolicyInsights/policyMetadata) Tenant`


### resolveArmResources-only non-resource methods

None.
