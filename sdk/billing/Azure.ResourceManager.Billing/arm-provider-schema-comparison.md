# ARM provider schema comparison: Azure.ResourceManager.Billing

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 46 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 5 differences. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 46 | Matching resource ID patterns are compared in the following sections. |
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

**Differences:** 5 list/action operation differences.

#### List/action operation differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.BillingAccounts.billingRequestsListByBillingAccount` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.BillingAccounts.reservationsListByBillingAccount` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/reservations` | Different. | Different. |
| `Microsoft.Billing.BillingAccounts.savingsPlansListByBillingAccount` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/savingsPlans` | Missing. | Present. |

#### List/action operation differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.BillingProfiles.billingRequestsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.invoicesListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoices` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.productsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/products` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.reservationsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/reservations` | Different. | Different. |

#### List/action operation differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.Customers.billingRequestsListByCustomer` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.Customers.createOrUpdateByCustomer` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/policies/default` | Present. | Missing. |

#### List/action operation differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.InvoiceSections.billingRequestsListByInvoiceSection` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.InvoiceSections.productsListByInvoiceSection` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/products` | Different. | Different. |

#### List/action operation differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.CustomerOperationGroup.listByCustomer` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}/products` | Different. | Different. |
| `Microsoft.Billing.Customers.createOrUpdateByCustomer` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/policies/default` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}` | `BillingAgreement` | `Agreement` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/associatedTenants/{associatedTenantName}` | `BillingAssociatedTenant` | `AssociatedTenant` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/transfers/{transferName}` | `PartnerTransferDetail` | `PartnerTransferDetails` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}` | `BillingInvoiceSection` | `InvoiceSection` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/transfers/{transferName}` | `BillingTransferDetail` | `TransferDetails` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/paymentMethodLinks/{paymentMethodName}` | `BillingPaymentMethodLink` | `BillingProfilesPaymentMethodLinks` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptionAliases/{aliasName}` | `BillingSubscriptionAlias` | `BillingAccountsBillingSubscriptionAliases` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/departments/{departmentName}` | `BillingDepartment` | `Department` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/products/{productName}` | `BillingProduct` | `Product` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/reservationOrders/{reservationOrderId}` | `BillingReservationOrder` | `ReservationOrder` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/reservationOrders/{reservationOrderId}/reservations/{reservationId}` | `BillingReservation` | `Reservation` |
| `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/savingsPlanOrders/{savingsPlanOrderId}/savingsPlans/{savingsPlanId}` | `BillingSavingsPlanModel` | `SavingsPlanModel` |
| `/providers/Microsoft.Billing/transfers/{transferName}` | `RecipientTransferDetail` | `RecipientTransferDetails` |

