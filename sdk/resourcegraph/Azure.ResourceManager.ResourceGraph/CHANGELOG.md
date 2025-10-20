# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-10-17)

### Features Added

- Upgraded api-version tag from 'package-preview-2021-06' to 'package-2024-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1bd335533d57d11a33d41be9b5841e6986ec3567/specification/resourcegraph/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.28.0 to 1.49.0
- Upgraded Azure.ResourceManager from 1.4.0 to 1.13.2

## 1.1.0-beta.4 (2025-07-30)

### Features Added

- Make `Azure.ResourceManager.ResourceGraph` AOT-compatible

## 1.1.0-beta.3 (2025-03-11)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Set MaxDepth to 256 for json serialization options to handle json with more depth in https://github.com/Azure/azure-sdk-for-net/issues/48260

## 1.1.0-beta.2 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-12-26)

This release is the first stable release of the Resource Graph Management library.

### Breaking Changes

Polishing since last public beta release:
- Corrected the format of all `Guid` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.2.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ResourceGraph` to `Azure.ResourceManager.ResourceGraph`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
