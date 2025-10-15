# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.1 (2025-10-15)

### Features Added

- Added `WirePath` attribute for all models' properties.

## 1.4.0 (2025-05-10)

### Features Added

- Upgraded version to 2025-03-01
- Added support for captcha

## 1.3.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.0 (2024-05-06)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Update api version to 2024-02-01
- Add log-scrubbing support for waf
- Add GroupBy support for waf custom rule
- Add AnomalyScoringValue for RuleMatchActionType
- Add JSChallengeValue for RuleMatchActionType

## 1.2.0 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-16)

### Features Added

- Introduced property bag for the methods with more than 5 parameters.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-29)

This release is the first stable release of the Front Door Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `FrontDoor` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `Uri` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.
- Optimized the class `RouteConfiguration` to abstract class and changed its constructor from public to protected.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.FrontDoor` to `Azure.ResourceManager.FrontDoor`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
