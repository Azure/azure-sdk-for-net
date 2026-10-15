# ARM resource shape comparison: Azure.ResourceManager.Advisor

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 8 |
| resolveArmResources resources | 8 |
| Matching normalized resource IDs | 8 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 2 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/providers/Microsoft.Advisor/resiliencyReviews/{}/providers/Microsoft.Advisor/triageRecommendations/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | _none_ |
| `/subscriptions/{}/providers/Microsoft.Advisor/resiliencyReviews/{}/providers/Microsoft.Advisor/triageRecommendations/{}/providers/Microsoft.Advisor/triageResources/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | _none_ |
