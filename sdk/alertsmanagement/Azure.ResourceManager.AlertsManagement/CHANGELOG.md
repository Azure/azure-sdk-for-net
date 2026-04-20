# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

- Upgraded API version to 2025-05-25-preview.
- Added tenant-level alert operations via `TenantResource` extension.
- Added alert enrichments support via `GetEnrichments` operation.

### Breaking Changes

- Migrated from AutoRest/Swagger to TypeSpec-based code generation using Azure Management Generator.
- Removed `AlertProcessingRule*` types and operations (moved to separate TypeSpec project `AlertProcessingRules`).
- Removed `SmartGroup*` types and operations (deprecated in the service). Backward-compatible stubs remain with `[Obsolete]` attributes.
- `GetServiceAlerts()` extension method on `SubscriptionResource` is now `[EditorBrowsable(Never)]`; prefer `GetServiceAlerts(ResourceIdentifier)` on `ArmClient`.
- `GetServiceAlertSummary` extension methods moved from `SubscriptionResource` to `ArmClient` as `GetSummary`. The old `SubscriptionResource` extension methods remain as backward-compatible overloads.
- `GetServiceAlertResource` renamed to `GetAlertResource` on `ArmClient` extension.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to latest.

## 1.1.1 (2025-03-11)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-25)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-20)

### Features Added

- Introduced property bag for the methods with more than 5 parameters.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-19)

This release is the first stable release of the AlertsManagement Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `AlertsManagement` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.AlertsManagement` to `Azure.ResourceManager.AlertsManagement`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

