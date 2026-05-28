# Release History

## 1.3.0-beta.1 (Unreleased)

### Other Changes

- Underlying generator switched to the `@azure-typespec/http-client-csharp-mgmt` emitter; generation is now driven by `tsp-location.yaml` and the TypeSpec spec under `specification/billing/resource-manager/Microsoft.Billing/Billing`.

### Breaking Changes

This beta is the first release built from TypeSpec via the management-plane csharp emitter. The change of generator surfaces a number of cosmetic and structural differences against the 1.2.2 GA API. The most common shapes:

- Resource / collection type renames where the TypeSpec model name differs from the legacy autorest-derived name (for example, payment-method aliases such as `BillingAccountPaymentMethod*`). Where the rename is driven by ARM resource detection rather than `@@clientName`, the legacy type alias cannot be restored without changing the upstream service model and is therefore retained as a breaking change for this beta.
- Property `WirePath` attribute coverage on `Properties` and `Tags` of several `*Data` types differs from the legacy auto-flattened layout. Runtime serialization is unchanged.
- A small number of operations whose paths or naming were normalized in the new spec no longer have a 1:1 GA equivalent.

The most common GA call sites have been preserved via custom partials, including:

- `BillingAccountCollection.GetAll(BillingAccountCollectionGetAllOptions, CancellationToken)` and its async counterpart (and the same shape for `BillingAssociatedTenantCollection`, `BillingInvoiceSectionCollection`, `BillingProductCollection`, `BillingProfileCollection`, `BillingRequestCollection`, `BillingSubscriptionAliasCollection`, `BillingSubscriptionCollection`).
- `BillingAccountPolicyResource.Update(...)` / `BillingProfilePolicyResource.Update(...)` back-compat shims that delegate to the new `CreateOrUpdate(...)` shape.
- `BillingTransferDetailsResource.Update(...)` / `PartnerTransferDetailsResource.Update(...)` which previously existed only in shape and now throw `NotSupportedException` to preserve binary surface.

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
