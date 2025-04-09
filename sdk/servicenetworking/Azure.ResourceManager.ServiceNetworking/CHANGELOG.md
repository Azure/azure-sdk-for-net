# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-03-04)

### Features Added

- Stable release for api-version `2025-01-01`. Detail available at https://github.com/Azure/azure-rest-api-specs/tree/aaa30aa706969369385454abb690e425d2e5addb/specification/servicenetworking/ServiceNetworking.Management.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.45.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.13.0

## 1.1.0-beta.1 (2025-02-06)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.
- Added CRUD Operations for Application Gateway for Containers (AGC) Security Policy.
- Bumped api-version to `2025-01-01`.

## 1.0.1 (2023-11-30)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0 (2023-11-01)

### Features Added

- Perform CRUD Operations for Application Gateway for Containers (AGC).
- Use the latest API version for (2023-11-01)

## 1.0.0-beta.2 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.1 (2023-02-13)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
