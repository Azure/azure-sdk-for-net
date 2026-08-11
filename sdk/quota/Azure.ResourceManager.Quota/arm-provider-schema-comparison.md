# ARM provider schema comparison: Azure.ResourceManager.Quota

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 0 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 2 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/providers/{}/locations/{}/providers/Microsoft.Quota/incomingQuotaTransfers/{}`
- `/subscriptions/{}/providers/{}/locations/{}/providers/Microsoft.Quota/quotaTransfers/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}`
  - legacy-only: `Microsoft.Quota.GroupQuotasEntities.createOrUpdate (Create) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`; `Microsoft.Quota.GroupQuotasEntities.update (Update) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`
- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{}`
  - legacy-only: `Microsoft.Quota.GroupQuotaSubscriptionIds.createOrUpdate (Create) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{}, Microsoft.Management/managementGroups]`; `Microsoft.Quota.GroupQuotaSubscriptionIds.update (Update) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{}, Microsoft.Management/managementGroups]`


### List/action operation differences

- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}`
  - legacy-only: `Microsoft.Quota.GroupQuotasEntities.groupQuotaLimitsRequestList (Action) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/groupQuotaRequests [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`
  - resolveArmResources-only: `Microsoft.Quota.GroupQuotasEntities.groupQuotaLimitsRequestList (List) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/resourceProviders/{}/groupQuotaRequests [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`; `Microsoft.Quota.GroupQuotaSubscriptionIds.createOrUpdate (Action) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`; `Microsoft.Quota.GroupQuotaSubscriptionIds.update (Action) /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}/subscriptions/{} [ManagementGroup: /providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}, Microsoft.Management/managementGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.Quota.GroupQuotasEntities.createOrUpdate (/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}) ManagementGroup [/providers/Microsoft.Management/managementGroups/{}: Microsoft.Management/managementGroups]`
- `Microsoft.Quota.GroupQuotasEntities.update (/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Quota/groupQuotas/{}) ManagementGroup [/providers/Microsoft.Management/managementGroups/{}: Microsoft.Management/managementGroups]`
