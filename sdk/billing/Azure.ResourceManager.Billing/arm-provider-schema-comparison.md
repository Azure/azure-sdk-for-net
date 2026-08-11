# ARM provider schema comparison: Azure.ResourceManager.Billing

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 46 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 6 matching normalized patterns differ |
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

- `/providers/Microsoft.Billing/billingAccounts/{}`
  - legacy-only: `Microsoft.Billing.BillingAccounts.billingRequestsListByBillingAccount (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingAccounts.reservationsListByBillingAccount (Action) /providers/Microsoft.Billing/billingAccounts/{}/reservations [Tenant: /providers/Microsoft.Billing/billingAccounts/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.BillingAccounts.billingRequestsListByBillingAccount (List) /providers/Microsoft.Billing/billingAccounts/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingAccounts.reservationsListByBillingAccount (List) /providers/Microsoft.Billing/billingAccounts/{}/reservations [Tenant: /providers/Microsoft.Billing/billingAccounts/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingAccounts.savingsPlansListByBillingAccount (Action) /providers/Microsoft.Billing/billingAccounts/{}/savingsPlans [Tenant: /providers/Microsoft.Billing/billingAccounts/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}`
  - legacy-only: `Microsoft.Billing.BillingProfiles.billingRequestsListByBillingProfile (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.invoicesListByBillingProfile (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoices [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.productsListByBillingProfile (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.reservationsListByBillingProfile (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/reservations [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.BillingProfiles.billingRequestsListByBillingProfile (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.invoicesListByBillingProfile (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoices [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.productsListByBillingProfile (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.BillingProfiles.reservationsListByBillingProfile (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/reservations [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}`
  - legacy-only: `Microsoft.Billing.Customers.billingRequestsListByCustomer (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.Customers.billingSubscriptionsListByCustomer (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.Customers.billingRequestsListByCustomer (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.Customers.billingSubscriptionsListByCustomer (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/customers/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}`
  - legacy-only: `Microsoft.Billing.InvoiceSections.billingRequestsListByInvoiceSection (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.InvoiceSections.billingSubscriptionsListByInvoiceSection (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.InvoiceSections.productsListByInvoiceSection (Action) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.InvoiceSections.billingRequestsListByInvoiceSection (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/billingRequests [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.InvoiceSections.billingSubscriptionsListByInvoiceSection (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.InvoiceSections.productsListByInvoiceSection (List) /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/billingProfiles/{}/invoiceSections/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Billing/billingAccounts/{}/customers/{}`
  - legacy-only: `Microsoft.Billing.CustomerOperationGroup.billingSubscriptionsListByCustomerAtBillingAccount (Action) /providers/Microsoft.Billing/billingAccounts/{}/customers/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/customers/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.CustomerOperationGroup.listByCustomer (Action) /providers/Microsoft.Billing/billingAccounts/{}/customers/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/customers/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.CustomerOperationGroup.billingSubscriptionsListByCustomerAtBillingAccount (List) /providers/Microsoft.Billing/billingAccounts/{}/customers/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/customers/{}, Microsoft.Resources/tenants]`; `Microsoft.Billing.CustomerOperationGroup.listByCustomer (List) /providers/Microsoft.Billing/billingAccounts/{}/customers/{}/products [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/customers/{}, Microsoft.Resources/tenants]`
- `/providers/Microsoft.Billing/billingAccounts/{}/enrollmentAccounts/{}`
  - legacy-only: `Microsoft.Billing.EnrollmentAccountOperationGroup.billingSubscriptionsListByEnrollmentAccount (Action) /providers/Microsoft.Billing/billingAccounts/{}/enrollmentAccounts/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/enrollmentAccounts/{}, Microsoft.Resources/tenants]`
  - resolveArmResources-only: `Microsoft.Billing.EnrollmentAccountOperationGroup.billingSubscriptionsListByEnrollmentAccount (List) /providers/Microsoft.Billing/billingAccounts/{}/enrollmentAccounts/{}/billingSubscriptions [Tenant: /providers/Microsoft.Billing/billingAccounts/{}/enrollmentAccounts/{}, Microsoft.Resources/tenants]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
