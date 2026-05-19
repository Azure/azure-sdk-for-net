# Release History

## 2.0.0-beta.1 (Unreleased)

### Breaking Changes

- Migrated from AutoRest/Swagger to TypeSpec-based code generation. This is a major rebuild of the public API surface:
  - Many resource and model types have been renamed to follow current ARM .NET design guidelines (for example, the `Operation` model has been renamed to `BillingOperationInfo`).
  - The `BillingAccountCollectionGetAllOptions` and related parameter-options classes have been removed; the corresponding collection `GetAll` overloads now take individual filter parameters that match the underlying ARM contract.
  - Several wrapper resources whose ARM paths are shared across multiple scopes (for example `BillingRoleAssignment`, `BillingRoleDefinition`, `Customer`, `EnrollmentAccount`, `Invoice`, `PaymentMethod`, `BillingSubscription`) are now generated per parent scope. Use the new scope-specific accessors (for example `GetBillingAccountBillingRoleAssignments`, `GetBillingProfileBillingRoleAssignments`).
  - Resource long-running operations (`Update`, `Delete`, `CreateOrUpdate`) now use canonical `ArmOperation`/`ArmOperation<T>` return types throughout.
  - Several enumerations and models have been renamed for non-ambiguity (for example `ReservationPurchaseRequestPropertiesReservedResourceProperties.InstanceFlexibility` is now exposed as `ReservedInstanceFlexibility` to avoid a clash with the directly flattened property).
- The `SubscriptionRenewalTermDetails.TermDuration` property is now `string` (ISO8601 duration format), matching the underlying spec and the sibling `BillingSubscriptionData.TermDuration` / `BillingSubscriptionProperties.TermDuration` properties. Previously it was incorrectly exposed as `TimeSpan?` by the legacy generator.

### Other Changes

- Underlying generator switched to the `@azure-typespec/http-client-csharp-mgmt` emitter; generation is driven by `tsp-location.yaml` and the TypeSpec spec under `specification/billing/resource-manager/Microsoft.Billing/Billing`.

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
