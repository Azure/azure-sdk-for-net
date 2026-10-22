# ARM resource shape comparison: Azure.ResourceManager.Authorization

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 27 |
| resolveArmResources resources | 28 |
| Matching normalized resource IDs | 26 |
| Legacy-only normalized resource IDs | 1 |
| resolveArmResources-only normalized resource IDs | 1 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 2 |
| Scope differences | 3 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/providers/Microsoft.Authorization/providerOperations/{}` | resourceId=`/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}`<br>resourceType=`Microsoft.Authorization/providerOperations`<br>parent=_none_<br>scope=`kind=Tenant`; `type=Microsoft.Resources/tenants`<br>Read=`Microsoft.ProviderOperations.ProviderOperationsMetadataOperationGroup.get /providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace} [Tenant, /providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}, Microsoft.Resources/tenants]`<br>Create=_none_ |

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/{}` | resourceId=`/{denyAssignmentId}`<br>resourceType=`/`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `type=Microsoft.Resources/tenants`<br>Read=`Microsoft.DenyAssignment.DenyAssignments.getById /{denyAssignmentId} [Tenant, /{denyAssignmentId}, Microsoft.Resources/tenants]`<br>Create=_none_<hr>resourceId=`/{roleAssignmentId}`<br>resourceType=`/`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `type=Microsoft.Resources/tenants`<br>Read=`Microsoft.RoleAssignment.RoleAssignmentsByIdOperations.getById /{roleAssignmentId} [Tenant, /{denyAssignmentId}, Microsoft.Resources/tenants]`<br>Create=`Microsoft.RoleAssignment.RoleAssignmentsByIdOperations.createById /{roleAssignmentId} [Tenant, /{denyAssignmentId}, Microsoft.Resources/tenants]` |

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}` | parent | _none_ | `id=/{scope}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{scheduleDefinitionId}` |
| `/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}` | scope | `kind=Tenant`<br>`type=Microsoft.Resources/tenants` | `kind=Extension`<br>`type=Microsoft.Resources/tenants` |
| `/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}/decisions/{}` | scope | `kind=Tenant`<br>`type=Microsoft.Resources/tenants` | `kind=Extension`<br>`type=Microsoft.Resources/tenants` |
| `/subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{scheduleDefinitionId}` | `id=/{scope}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{scheduleDefinitionId}` |
| `/subscriptions/{}/providers/Microsoft.Authorization/accessReviewScheduleDefinitions/{}/instances/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Extension`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
