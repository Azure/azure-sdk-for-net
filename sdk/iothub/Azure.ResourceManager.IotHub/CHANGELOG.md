# Release History

## 1.2.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.1 (2024-10-15)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.1 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0 (2023-09-18)

### Features Added

- Upgraded api-version tag from 'package-2021-07-02' to 'package-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/624dbc769880e5676ae8bb20d3c82ebd1783c64a/specification/iothub/resource-manager/readme.md

### Other Changes

- Obsoleted property 'BinaryData Thumbprint' in type Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties
- Obsoleted property 'BinaryData Thumbprint' in type Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce

## 1.1.0-beta.2 (2023-09-04)

### Features Added

- Upgraded api-version tag from 'package-2021-07-02' to 'package-preview-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1df6d6f671dc5059016fbc2c0a624e01f0b2972c/specification/iothub/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.32.0 to 1.34.0
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0

## 1.1.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Added `IotHubCertificateProperties.ThumbprintString`, `IotHubCertificatePropertiesWithNonce.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `IotHubCertificateProperties.Thumbprint`, `IotHubCertificatePropertiesWithNonce.Thumbprint` have been hidden but are still available.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-08-29)

This release is the first stable release of the IotHub Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `IotHub` prefix to all single / simple model names.
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

The package name has been changed from `Microsoft.Azure.Management.IotHub` to `Azure.ResourceManager.IotHub`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
