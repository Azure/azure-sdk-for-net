# ARM provider schema comparison: Azure.ResourceManager.ResourceHealth

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 6 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/providers/Microsoft.ResourceHealth/events/{}`
  - legacy-only: `Microsoft.ResourceHealth.TenantEventOperationGroup.listByTenantIdAndEventId (Action) /providers/Microsoft.ResourceHealth/events/{}/listSecurityAdvisoryImpactedResources [Tenant: /providers/Microsoft.ResourceHealth/events/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.ResourceHealth.TenantEventOperationGroup.listByTenantIdAndEventId (List) /providers/Microsoft.ResourceHealth/events/{}/listSecurityAdvisoryImpactedResources [Tenant: /providers/Microsoft.ResourceHealth/events/{}, Microsoft.Resources/tenants]`
- `/subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}`
  - legacy-only: `Microsoft.ResourceHealth.EventOperationGroup.listBySubscriptionIdAndEventId (Action) /subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}/listSecurityAdvisoryImpactedResources [Subscription: /subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `Microsoft.ResourceHealth.EventOperationGroup.listBySubscriptionIdAndEventId (List) /subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}/listSecurityAdvisoryImpactedResources [Subscription: /subscriptions/{}/providers/Microsoft.ResourceHealth/events/{}, Microsoft.Resources/subscriptions]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
