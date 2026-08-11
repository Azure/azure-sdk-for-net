# ARM provider schema comparison: Azure.ResourceManager.Authorization

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 26 matching normalized patterns; 1 legacy-only; 1 resolve-only |
| Raw resource ID patterns | 1 legacy-only raw; 2 resolve-only raw; 1 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 5 matching normalized patterns differ |
| Non-resource methods | 10 legacy-only; 2 resolve-only |


### Legacy-only normalized resource ID patterns

- `/providers/Microsoft.Authorization/providerOperations/{}`


### resolveArmResources-only normalized resource ID patterns

- `/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}`
  - legacy-only: `Microsoft.AttributeNamespaces.ScopeAccessReviewInstances.scopeAccessReviewInstanceDecisionsList (Action) /{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}/decisions [Extension: /{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}]`
  - resolveArmResources-only: `Microsoft.AttributeNamespaces.ScopeAccessReviewInstances.scopeAccessReviewInstanceDecisionsList (List) /{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}/decisions [Extension: /{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}]`
- `/{}/providers/Microsoft.Authorization/denyAssignments/{}`
  - resolveArmResources-only: `Microsoft.DenyAssignment.DenyAssignments.listForResource (List) /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/providers/Microsoft.Authorization/denyAssignments [Extension: /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}]`
- `/{}/providers/Microsoft.Authorization/roleAssignments/{}`
  - resolveArmResources-only: `Microsoft.RoleAssignment.RoleAssignments.listForResource (List) /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.Authorization/roleAssignments [Extension: /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}]`
- `/subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}`
  - resolveArmResources-only: `Microsoft.AttributeNamespaces.ScopeAccessReviewScheduleDefinitions.listForMyApproval (List) /providers/Microsoft.Authorization/accessReviewScheduleDefinitions [Tenant: , Microsoft.Resources/tenants]`
- `/subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}`
  - legacy-only: `Microsoft.AttributeNamespaces.AccessReviewInstances.accessReviewInstanceDecisionsList (Action) /subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}/decisions [Subscription: /subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `Microsoft.AttributeNamespaces.AccessReviewInstances.accessReviewInstanceDecisionsList (List) /subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}/decisions [Subscription: /subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}, Microsoft.Resources/subscriptions]`


### Legacy-only non-resource methods

- `Microsoft.AttributeNamespaces.ScopeAccessReviewScheduleDefinitions.listForMyApproval (/providers/Microsoft.Authorization/accessReviewScheduleDefinitions) Tenant`
- `Microsoft.Authorization.EligibleChildResourcesOperationGroup.get (/{}/providers/Microsoft.Authorization/eligibleChildResources) Extension [/{}: ]`
- `Microsoft.DenyAssignment.DenyAssignments.getById (/{}) Tenant`
- `Microsoft.DenyAssignment.DenyAssignments.listForResource (/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/providers/Microsoft.Authorization/denyAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}: ]`
- `Microsoft.RoleAssignment.RoleAssignments.listForResource (/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.Authorization/roleAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}: ]`
- `Microsoft.RoleAssignment.RoleAssignmentsByIdOperations.createById (/{}) Tenant`
- `Microsoft.RoleAssignment.RoleAssignmentsByIdOperations.deleteById (/{}) Tenant`
- `Microsoft.RoleAssignment.RoleAssignmentsByIdOperations.getById (/{}) Tenant`
- `Microsoft.RoleManagementAlerts.AlertOperationOperationGroup.get (/{}/providers/Microsoft.Authorization/roleManagementAlertOperations/{}) Extension [/{}: ]`
- `Microsoft.RoleManagementAlerts.AlertsOperationGroup.refreshAll (/{}/providers/Microsoft.Authorization/roleManagementAlerts/refresh) Extension [/{}: ]`


### resolveArmResources-only non-resource methods

- `Microsoft.ProviderOperations.ProviderOperationsMetadataOperationGroup.get (/providers/Microsoft.Authorization/providerOperations/{}) Tenant`
- `Microsoft.ProviderOperations.ProviderOperationsMetadataOperationGroup.list (/providers/Microsoft.Authorization/providerOperations) Tenant`
