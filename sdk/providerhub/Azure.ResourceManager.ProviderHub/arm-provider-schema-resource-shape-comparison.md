# ARM resource shape comparison: Azure.ResourceManager.ProviderHub

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 12 |
| resolveArmResources resources | 13 |
| Matching normalized resource IDs | 12 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 1 |
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
| `/subscriptions/{}/providers/Microsoft.ProviderHub/providerRegistrations/{}/operations/default` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default`<br>resourceType=`Microsoft.ProviderHub/providerRegistrations/operations`<br>parent=`id=/subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}`<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=`Microsoft.ProviderHub.OperationsPutContents.listByProviderRegistration /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default [Subscription, /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default, Microsoft.Resources/subscriptions]`<br>Create=`Microsoft.ProviderHub.OperationsPutContents.createOrUpdate /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default [Subscription, /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default, Microsoft.Resources/subscriptions]` |

## Matched resource-shape differences

None.
