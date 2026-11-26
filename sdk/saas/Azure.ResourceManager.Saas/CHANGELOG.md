# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

Initial beta release of the `Azure.ResourceManager.Saas` management client library targeting API version `2026-04-01`.

- Subscription-level and resource-group-level SaaS resource lifecycle management (create, get, update, delete, list).
- Tenant-level SaaS resource management (get, update, delete, list).
- Pre-purchase and update validation (`ValidatePurchase`, `ValidatePurchaseBySubscription`, `ValidateUpdate`).
- Global SaaS resource name-availability checks (`CheckSaasNameAvailability`).
- Publisher access-token retrieval (`GetAccessToken`) and subscription unsubscribe (`Unsubscribe`).

### Breaking Changes

### Bugs Fixed

### Other Changes