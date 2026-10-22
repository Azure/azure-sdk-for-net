# ARM resource shape comparison: Azure.ResourceManager.Quota

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 11 |
| resolveArmResources resources | 11 |
| Matching normalized resource IDs | 11 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 2 |
| Scope differences | 2 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 2 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}` | create | `Microsoft.Quota.GroupQuotasEntities.createOrUpdate /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName} [ManagementGroup, /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}, Microsoft.Management/managementGroups]` | _none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/groupQuotaLimits/{}` | scope | `kind=ManagementGroup`<br>`id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`<br>`type=Microsoft.Management/managementGroups` | `kind=Extension`<br>`id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`<br>`type=Microsoft.Management/managementGroups` |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/locationSettings/{}` | scope | `kind=ManagementGroup`<br>`id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`<br>`type=Microsoft.Management/managementGroups` | `kind=Extension`<br>`id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`<br>`type=Microsoft.Management/managementGroups` |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{}` | create | `Microsoft.Quota.GroupQuotaSubscriptionIds.createOrUpdate /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId} [ManagementGroup, /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}, Microsoft.Management/managementGroups]` | _none_ |
| `/providers/Microsoft.Management/managementGroups/{}/subscriptions/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/quotaAllocationRequests/{}` | parent | _none_ | `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` |
| `/providers/Microsoft.Management/managementGroups/{}/subscriptions/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/quotaAllocations/{}` | parent | _none_ | `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` |
