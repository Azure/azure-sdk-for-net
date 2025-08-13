# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0 (2025-07-23)

### Features Added

- Upgraded api-version tag from 'package-preview-2025-02-01' to 'package-2025-05-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/6fa80ad3a37a580d5c29f5612e8ea536902fce4e/specification/search/resource-manager/readme.md.
- Make `Azure.ResourceManager.Search` AOT-compatible.

## 1.3.0-beta.5 (2025-04-29)

### Features Added

- Upgraded api-version tag from 'package-preview-2025-02' to 'package-preview-2025-02-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/5c73e496040fa9fec8725b7e26f8e45864211e62/specification/search/resource-manager/readme.md.

## 1.3.0-beta.4 (2025-03-06)

### Features Added

- Upgraded api-version tag from 'package-preview-2024-03' to 'package-preview-2025-02'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2aaa7ef3c48b8f4b7cb0e1e9bbe0041eec62c92d/specification/search/resource-manager/readme.md.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.0-beta.3 (2024-05-16)

### Bugs Fixed

- Corrected casing of SkuName when using the ArmSearchModelFactory.

## 1.3.0-beta.2 (2024-04-29)

### Features Added

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.3.0-beta.1 (2024-04-17)

### Features Added

- Upgraded api-version tag from 'package-2023-11' to 'package-preview-2024-03'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/3fb73ef5a3af2c138b53e3cced182095b671a679/specification/search/resource-manager/readme.md

## 1.2.2 (2024-03-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.2.1 (2023-11-30)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0 (2023-11-01)

### Features Added

- Added support for '2023-11-01' management plane API version.
- Enabled the [semantic search](https://learn.microsoft.com/azure/search/semantic-search-overview) feature

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-03-21)

### Features Added

- Added support for '2022-09-01' management plane API version.
- Added support for enabling RBAC authentication on search services.

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-28)

This release is the first stable release of the Search Service Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `SearchService` prefix to all single / simple model names.
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

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Search` to `Azure.ResourceManager.Search`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
