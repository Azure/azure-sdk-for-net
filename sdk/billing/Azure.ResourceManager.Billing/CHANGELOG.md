# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

- Added strongly-typed `Guid?` properties alongside the existing GA `[Obsolete] string` aliases:
  - `BillingSubscriptionData.SubscriptionBeneficiaryTenantId` (Guid?) – supersedes `BeneficiaryTenantId`.
  - `BillingSubscriptionData.SubscriptionCustomerId` (string) – supersedes `CustomerId`.
  - `BillingSubscriptionAliasData.SubscriptionAliasBeneficiaryTenantId` (Guid?) – supersedes `BeneficiaryTenantId`.
  - `BillingSubscriptionAliasData.SubscriptionAliasCustomerId` (string) – supersedes `CustomerId`.

### Other Changes

- Migrated `Azure.ResourceManager.Billing` management-plane generation from AutoRest to TypeSpec via the `@azure-typespec/http-client-csharp-mgmt` emitter. Generation is now driven by `tsp-location.yaml` and the TypeSpec spec under `specification/billing/resource-manager/Microsoft.Billing/Billing`. The 1.2.2 GA public API surface is preserved via partial-class shims under `src/Custom/`; `ApiCompat` against 1.2.2 passes with zero warnings.
- The `[WirePath]` attribute on a few flattened properties (`BillingReservationData.Aggregates` / `.Trend`, `BillingSubscriptionData` / `BillingSubscriptionAliasData` / `BillingSubscriptionPatch` enrollment-account fields, `BillingReservationPatch.PurchaseProperties`, `ReservationPurchaseRequest.InstanceFlexibilityPropertiesReservedResourcePropertiesInstanceFlexibility`) now reflects the deeper wire path used by the 2024-04-01 API (e.g. `properties.utilization.aggregates`). The C# property names and runtime values are unchanged; only diagnostics that surface the wire path are affected.
- `BillingAccountResource.GetByBillingAccountSavingsPlan` / `GetByBillingAccountSavingsPlanAsync` have been removed because the 2024-04-01 `SavingsPlanModelList is Page<SavingsPlanModel>` envelope is rejected by the management-plane emitter. Callers should iterate `BillingAccountResource.GetBillingSavingsPlanModels().GetAllAsync(...)` (the `BillingSavingsPlanModelCollection.GetAll` overload) instead.
- Temporary generator-bug workarounds shipped in this beta (each tracked by an open issue; the corresponding `src/Custom/` shim will be removed once the upstream fix ships):
  - [#58747](https://github.com/Azure/azure-sdk-for-net/issues/58747) – `[CodeGenSuppress]` for `AddTag` / `SetTags` / `RemoveTag` on `BillingTransferDetailResource` and `PartnerTransferDetailResource` (tag-helper boilerplate is emitted against a PUT operation whose request body is not the resource data type).
  - [#59539](https://github.com/Azure/azure-sdk-for-net/issues/59539) – `[CodeGenSuppress]` plus hand-written `BillingAccountResource.CancelPaymentTerms` / `CancelPaymentTermsAsync`, because the generator emits `DateTimeOffset.ToRequestContent(...)` which does not exist.
  - [#59540](https://github.com/Azure/azure-sdk-for-net/issues/59540) – `[CodeGenSuppress]` plus hand-written `BillingProfileResource.GetProducts` / `GetProductsAsync`, because the shared `ProductsGetProductsCollectionResultOfT` constructor demands an `invoiceSectionName` argument the billing-profile call site cannot supply.
  - [#59545](https://github.com/Azure/azure-sdk-for-net/issues/59545) – `[CodeGenSuppress("Tags")]` plus a redeclared `Tags` property on `BillingAccountPatch`, `BillingProductPatch`, `BillingSubscriptionPatch`, and `BillingTransactionData`, because `enable-wire-path-attribute: true` emits a duplicate `[WirePath("tags")]` attribute.

## 1.2.2 (2026-04-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.53.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.14.0`.

## 1.2.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

Added detection for empty string in the return value of createdByPrincipalTenantId in BillingRoleAssignmentProperties. Issue at https://github.com/Azure/azure-sdk-for-net/issues/47341.

## 1.2.0 (2024-09-13)

### Features Added

- Upgraded api-version tag from 'package-2020-05' to 'package-2024-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/7dc76b4edb665c8f9e0c7b7c0aaf2f34f8b25833/specification/billing/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Added experimental Bicep serialization.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.42.0.
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0.

## 1.1.0 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-25)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-11-04)

This package is the first stable release of the Microsoft Azure Billing management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Billing` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Billing` to `Azure.ResourceManager.Billing`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
