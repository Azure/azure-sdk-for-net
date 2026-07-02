# ARM provider schema comparison: Azure.ResourceManager.Billing

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 46 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 5 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 46 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 5 list/action operation differences.

#### List and action operations differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.BillingAccounts.billingRequestsListByBillingAccount` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.BillingAccounts.reservationsListByBillingAccount` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/reservations` | Different. | Different. |
| `Microsoft.Billing.BillingAccounts.savingsPlansListByBillingAccount` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/savingsPlans` | Missing. | Present. |

#### List and action operations differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.BillingProfiles.billingRequestsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.invoicesListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoices` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.productsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/products` | Different. | Different. |
| `Microsoft.Billing.BillingProfiles.reservationsListByBillingProfile` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/reservations` | Different. | Different. |

#### List and action operations differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.Customers.billingRequestsListByCustomer` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.Customers.createOrUpdateByCustomer` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/policies/default` | Present. | Missing. |

#### List and action operations differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.InvoiceSections.billingRequestsListByInvoiceSection` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/billingRequests` | Different. | Different. |
| `Microsoft.Billing.InvoiceSections.productsListByInvoiceSection` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/products` | Different. | Different. |

#### List and action operations differences: `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Billing.CustomerOperationGroup.listByCustomer` | `List` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}/products` | Different. | Different. |
| `Microsoft.Billing.Customers.createOrUpdateByCustomer` | `Action` | `/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/policies/default` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.billing/billingaccounts/{}/agreements/{}` | `BillingAgreement` | `Agreement` |
| `/providers/microsoft.billing/billingaccounts/{}/associatedtenants/{}` | `BillingAssociatedTenant` | `AssociatedTenant` |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/customers/{}/transfers/{}` | `PartnerTransferDetail` | `PartnerTransferDetails` |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/invoicesections/{}` | `BillingInvoiceSection` | `InvoiceSection` |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/invoicesections/{}/transfers/{}` | `BillingTransferDetail` | `TransferDetails` |
| `/providers/microsoft.billing/billingaccounts/{}/billingprofiles/{}/paymentmethodlinks/{}` | `BillingPaymentMethodLink` | `BillingProfilesPaymentMethodLinks` |
| `/providers/microsoft.billing/billingaccounts/{}/billingsubscriptionaliases/{}` | `BillingSubscriptionAlias` | `BillingAccountsBillingSubscriptionAliases` |
| `/providers/microsoft.billing/billingaccounts/{}/departments/{}` | `BillingDepartment` | `Department` |
| `/providers/microsoft.billing/billingaccounts/{}/products/{}` | `BillingProduct` | `Product` |
| `/providers/microsoft.billing/billingaccounts/{}/reservationorders/{}` | `BillingReservationOrder` | `ReservationOrder` |
| `/providers/microsoft.billing/billingaccounts/{}/reservationorders/{}/reservations/{}` | `BillingReservation` | `Reservation` |
| `/providers/microsoft.billing/billingaccounts/{}/savingsplanorders/{}/savingsplans/{}` | `BillingSavingsPlanModel` | `SavingsPlanModel` |
| `/providers/microsoft.billing/transfers/{}` | `RecipientTransferDetail` | `RecipientTransferDetails` |

