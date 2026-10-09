# ARM resource shape comparison: Azure.ResourceManager.Support

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 12 |
| resolveArmResources resources | 12 |
| Matching normalized resource IDs | 12 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 3 |
| Scope differences | 3 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/providers/Microsoft.Support/fileWorkspaces/{}/files/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}` | `id=/providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}` |
| `/subscriptions/{}/providers/Microsoft.Support/fileWorkspaces/{}/files/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/Microsoft.Support/supportTickets/{}/chatTranscripts/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}` | `id=/providers/Microsoft.Support/supportTickets/{supportTicketName}` |
| `/subscriptions/{}/providers/Microsoft.Support/supportTickets/{}/chatTranscripts/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/Microsoft.Support/supportTickets/{}/communications/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}` | `id=/providers/Microsoft.Support/supportTickets/{supportTicketName}` |
| `/subscriptions/{}/providers/Microsoft.Support/supportTickets/{}/communications/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
