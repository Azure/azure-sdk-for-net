# ARM resource shape comparison: Azure.ResourceManager.PolicyInsights

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 3 |
| resolveArmResources resources | 8 |
| Matching normalized resource IDs | 3 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 5 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/providers/{}/managementGroups/{}/providers/Microsoft.PolicyInsights/remediations/{}` | resourceId=`/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}`<br>resourceType=`Microsoft.PolicyInsights/remediations`<br>parent=_none_<br>scope=`kind=Extension`; `id=/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/providers/Microsoft.PolicyInsights/attestations/{}` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}`<br>resourceType=`Microsoft.PolicyInsights/attestations`<br>parent=_none_<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/providers/Microsoft.PolicyInsights/remediations/{}` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}`<br>resourceType=`Microsoft.PolicyInsights/remediations`<br>parent=_none_<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.PolicyInsights/attestations/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/attestations/{attestationName}`<br>resourceType=`Microsoft.PolicyInsights/attestations`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.PolicyInsights/remediations/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}`<br>resourceType=`Microsoft.PolicyInsights/remediations`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |

## Matched resource-shape differences

None.
