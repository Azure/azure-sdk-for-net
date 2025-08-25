# Release History

## 1.3.0-beta.1 (Unreleased)

### Other Changes

- Genearte SDK from typespec

## 1.2.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0 (2024-06-28)

### Features Added

- Upgraded api-version tag from 'package-2023-10' to 'package-2024-07'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/de1f3772629b6f4d3ac01548a5f6d719bfb97c9e/specification/storagemover/resource-manager/readme.md.
    - Added support for upload limit schedule

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.1.1 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0 (2023-10-30)

### Features Added

- Upgrade to API version 2023-10-01

## 1.1.0-beta.2 (2023-08-08)

### Features Added

- Upgrade to API version 2023-07-01-preview
- Added support for SMB endpoint and SMB file share endpoint.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-03-11)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.0.0 (2023-03-03)

### Other Changes

This is the first stable release of StorageMover client library.

## 1.0.0-beta.1 (2022-12-09)

### Breaking Changes

New design of track 2 initial commit.
- Corrected the format of all `uuid` type properties / parameters.
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Prepended `StorageMover` prefix to all single / simple model names
- Optimized the name of some models and functions.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
