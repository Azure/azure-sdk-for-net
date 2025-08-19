# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.5 (2025-07-28)

### Features Added

- Make `Azure.ResourceManager.ContainerService` AOT-compatible

## 1.2.4 (2025-06-24)

### Bugs Fixed

- Removed `[EditorBrowsable]` and `[Obsolete]` attributes on some properties that are incorrectly hidden/deprecated in previous versions.

## 1.2.3 (2025-03-05)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.2 (2024-06-17)

### Bugs Fixed

- Fixed issue https://github.com/Azure/azure-sdk-for-net/issues/44501.

## 1.2.1 (2024-04-29)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.2.0 (2024-01-12)

### Features Added

- Upgraded api-version tag from 'package-2022-09' to 'package-2023-10'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/8e674dd2a88ae73868c6fa7593a0ba4371e45991/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

## 1.2.0-beta.3 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.2.0-beta.1 (2023-02-21)

### Features Added

- Added support for fleet resources.
- Added support for managed cluster snapshot, trusted access role binding.

### Other Changes

- Upgraded managed clusters API version to `2022-11-02-preview`.
- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2022-12-14)

### Other Changes

- Upgraded API version to 2022-09-01.
- Upgraded dependent `Azure.Core` to 1.26.0.
- Upgraded dependent `Azure.ResourceManager` to 1.3.2.

## 1.0.0 (2022-09-26)

This release is the first stable release of the Container Service Management library.

### Breaking Changes

- Changed the type of property `ClientId` in `ManagedClusterServicePrincipalProfile` from `Guid` to `string`.

### Bugs Fixed

- Fixed the interim API version issue in the LRO.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `CognitiveServices` prefix to all single / simple model names.
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

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ContainerServicer` to `Azure.ResourceManager.ContainerServicer`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
