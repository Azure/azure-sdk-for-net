# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-01-26)

This is the first stable release of ElasticSan client library.

### Features Added

- Supported snapshot and CMK for ElasticSan
- Supported private endpoints for ElasticSan
- Supported ElasticSan basic operations 
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.0.

## 1.0.0-beta.6 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.5 (2023-10-27)

### Features Added

- Upgraded to API version 2023-01-01
- Supported snapshot and CMK for ElasticSan

## 1.0.0-beta.4 (2023-07-31)

### Features Added

- Upgraded api-version tag from 'package-2021-11-20-preview' to 'package-preview-2022-12'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1af2861030243b06ee35172c95899f4809eedfc7/specification/elasticsan/resource-manager/readme.md
- Supported private endpoints for ElasticSan

### Other Changes

- Upgraded Azure.Core from 1.32.0 to 1.34.0
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0

## 1.0.0-beta.3 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.2 (2023-02-17)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-10-12)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
