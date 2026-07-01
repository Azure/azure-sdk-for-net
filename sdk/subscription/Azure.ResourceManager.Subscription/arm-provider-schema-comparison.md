# ARM provider schema comparison: Azure.ResourceManager.Subscription

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 4 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List/action operation differences: `/providers/Microsoft.Subscription/policies/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Subscription.GetTenantPolicyResponses.listPolicyForTenant` | `List` | `/providers/Microsoft.Subscription/policies` | Missing. | Present. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Subscription/changeTenantRequest/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Subscription.TargetDirectoryResults.listTargetDirectory` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Subscription/changeTenantRequest` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Subscription/policies/default` | `BillingAccountPolicy` | `ExternalResourceBillingAccountPoliciesResponse` |
| `/providers/Microsoft.Subscription/aliases/{aliasName}` | `SubscriptionAlias` | `SubscriptionAliasResponse` |
| `/providers/Microsoft.Subscription/policies/default` | `TenantPolicy` | `GetTenantPolicyResponse` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Subscription.SubscriptionOperationOperationGroup.get` | `/providers/Microsoft.Subscription/subscriptionOperations/{operationId}` | Missing. | Present. |

