# ARM provider schema comparison: Azure.ResourceManager.Quota

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 hierarchy differences; 2 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 11 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 2 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 11 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 2 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/providers/microsoft.management/managementgroups/{}/subscriptions/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/quotaallocationrequests/{}` | Extension, `scopeIdPattern: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Management/managementGroups/subscriptions` | ManagementGroup, `scopeIdPattern: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Management/managementGroups/subscriptions` |
| `/providers/microsoft.management/managementgroups/{}/subscriptions/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/quotaallocations/{}` | Extension, `scopeIdPattern: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Management/managementGroups/subscriptions` | ManagementGroup, `scopeIdPattern: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Management/managementGroups/subscriptions` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Quota.GroupQuotasEntities.createOrUpdate` | `Create` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` | Present. | Missing. |
| `Microsoft.Quota.GroupQuotasEntities.update` | `Update` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` | Present. | Missing. |

#### CRUD operations differences: `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Quota.GroupQuotaSubscriptionIds.createOrUpdate` | `Create` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}` | Present. | Missing. |
| `Microsoft.Quota.GroupQuotaSubscriptionIds.update` | `Update` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Quota.GroupQuotaSubscriptionIds.createOrUpdate` | `Action` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}` | Missing. | Present. |
| `Microsoft.Quota.GroupQuotaSubscriptionIds.update` | `Action` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/subscriptions/{subscriptionId}` | Missing. | Present. |
| `Microsoft.Quota.GroupQuotasEntities.groupQuotaLimitsRequestList` | `List` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/groupQuotaRequests` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 9 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}` | `GroupQuotaEntity` | `ManagementGroupGroupQuotasEntity` |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}/groupquotarequests/{}` | `GroupQuotaRequestStatus` | `ManagementGroupSubmittedResourceRequestStatus` |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/groupquotalimits/{}` | `GroupQuotaLimitList` | `ManagementGroupsGroupQuotasResourceProvidersGroupQuotaLimits` |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/locationsettings/{}` | `GroupQuotasEnforcementStatus` | `ManagementGroupsGroupQuotasResourceProvidersLocationSettings` |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}/subscriptionrequests/{}` | `GroupQuotaSubscriptionRequestStatus` | `ManagementGroupGroupQuotaSubscriptionRequestStatus` |
| `/providers/microsoft.management/managementgroups/{}/providers/microsoft.quota/groupquotas/{}/subscriptions/{}` | `GroupQuotaSubscription` | `ManagementGroupGroupQuotaSubscriptionId` |
| `/providers/microsoft.management/managementgroups/{}/subscriptions/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/quotaallocationrequests/{}` | `QuotaAllocationRequestStatus` | `SubscriptionsGroupQuotasResourceProvidersQuotaAllocationRequests` |
| `/providers/microsoft.management/managementgroups/{}/subscriptions/{}/providers/microsoft.quota/groupquotas/{}/resourceproviders/{}/quotaallocations/{}` | `SubscriptionQuotaAllocationsList` | `SubscriptionsGroupQuotasResourceProvidersQuotaAllocations` |
| `/{}/providers/microsoft.quota/quotarequests/{}` | `QuotaRequestDetail` | `QuotaRequestDetails` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Quota.GroupQuotasEntities.createOrUpdate` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` | Missing. | Present. |
| `Microsoft.Quota.GroupQuotasEntities.update` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}` | Missing. | Present. |

