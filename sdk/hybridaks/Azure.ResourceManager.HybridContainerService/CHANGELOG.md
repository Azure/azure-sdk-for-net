# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-01-26)

This release is the first stable release of the Hybrid Container Service Management library.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.1.

## 1.0.0-beta.5 (2024-01-15)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-11' to 'package-2024-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/8e674dd2a88ae73868c6fa7593a0ba4371e45991/specification/hybridaks/resource-manager/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

## 1.0.0-beta.4 (2024-01-03)

### Features Added

- Upgraded api-version tag from 'package-preview-2022-09' to 'package-preview-2023-11'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/21467ecae50d3ec069557cc6841d91fd805cc3b3/specification/hybridaks/resource-manager/readme.md.

## 1.0.0-beta.3 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.2 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.1 (2023-04-07)

This is the first beta release of Azure Hybrid Container Service client library.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
