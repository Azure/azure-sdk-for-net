# ARM provider schema comparison: Azure.ResourceManager.Consumption

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 hierarchy difference; 1 resource model difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 4 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 1 difference. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 1 hierarchy difference.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/providers/microsoft.consumption/credits/balancesummary` | Extension, `scopeIdPattern: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}`, `scopeResourceType: Microsoft.Billing/billingAccounts/billingProfiles` | Tenant, `scopeIdPattern: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}`, `scopeResourceType: Microsoft.Billing/billingAccounts/billingProfiles` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/providers/microsoft.consumption/credits/balancesummary` | `Microsoft.Consumption.CreditSummary` | `Microsoft.Consumption.CreditSummary` | `Microsoft.Consumption/credits` | `Microsoft.Consumption/billingProfiles` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/providers/microsoft.consumption/credits/balancesummary` | `ConsumptionCreditSummary` | `ExternalChildResourceCreditSummary` |
| `/subscriptions/{}/providers/microsoft.billing/billingperiods/{}/providers/microsoft.consumption/pricesheets/default` | `PriceSheet` | `ExternalResourcePriceSheetResult` |
| `/{}/providers/microsoft.consumption/budgets/{}` | `ConsumptionBudget` | `Budget` |

