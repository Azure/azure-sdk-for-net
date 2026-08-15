# ARM resource shape comparison: Azure.ResourceManager.ResourceHealth

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 6 |
| resolveArmResources resources | 6 |
| Matching normalized resource IDs | 6 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 1 |
| Scope differences | 1 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}/impactedResources/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.ResourceHealth/events/{eventTrackingId}` | `id=/providers/Microsoft.ResourceHealth/events/{eventTrackingId}` |
| `/subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}/impactedResources/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
