# ARM provider schema comparison: Azure.ResourceManager.Resources.Policy

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 11 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching normalized patterns; 0 legacy-only; 11 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 11 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/{}/providers/Microsoft.Authorization/policyEnrollments/{}`
- `/providers/Microsoft.Authorization/policyDefinitions/{}`
- `/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}`
- `/providers/Microsoft.Authorization/policySetDefinitions/{}`
- `/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policyDefinitions/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policySetDefinitions/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/variables/{}`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/variables/{}/values/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/{}/providers/Microsoft.Authorization/policyAssignments/{}`
  - resolveArmResources-only: `Microsoft.Authorization.PolicyAssignments.listForResource (List) /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/providers/Microsoft.Authorization/policyAssignments [Extension: /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}]`
- `/{}/providers/Microsoft.Authorization/policyExemptions/{}`
  - resolveArmResources-only: `Microsoft.Authorization.PolicyExemptions.listForResource (List) /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/providers/Microsoft.Authorization/policyExemptions [Extension: /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
