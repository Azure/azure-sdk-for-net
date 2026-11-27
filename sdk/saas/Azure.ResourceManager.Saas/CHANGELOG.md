# Release History

## 1.0.0-beta.1 (2026-11-30)

### Features Added

Initial beta release of the `Azure.ResourceManager.Saas` management client library targeting API version `2026-04-01`.

- Subscription-level and resource-group-level SaaS resource lifecycle management (create, get, update, delete, list).
- Tenant-level SaaS resource management (get, update, delete, list).
- Pre-purchase and update validation (`ValidatePurchase`, `ValidatePurchaseBySubscription`, `ValidateUpdate`).
- Global SaaS resource name-availability checks (`CheckSaasNameAvailability`).
- Publisher access-token retrieval (`GetAccessToken`) and subscription unsubscribe (`Unsubscribe`).
