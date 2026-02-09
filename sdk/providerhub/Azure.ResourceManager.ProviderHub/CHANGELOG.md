# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2025-10-21)

### Features Added

- Upgraded api-version tag from 'package-2020-11-20' to 'package-2024-09-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/247a38a5fea02ac50132f591f3b53fec06e9377b/specification/providerhub/resource-manager/readme.md.
- Make `Azure.ResourceManager.ProviderHub` AOT-compatible.

### Other Changes

- Upgraded Azure.Core from 1.45.0 to 1.49.0
- Upgraded Azure.ResourceManager from 1.13.0 to 1.13.2
- Obsoleted property 'IList<BinaryData> ResourceAccessRoles' in type Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement

## 1.1.1 (2025-03-11)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0 (2023-04-07)

This release is the first stable release of the Provider Hub Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `ProviderHub` / `Provider` prefix to all single / simple model names.
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

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.0.0-beta.1 (2022-09-25)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ProviderHub` to `Azure.ResourceManager.ProviderHub`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
