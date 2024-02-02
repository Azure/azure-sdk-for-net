# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2023-12-13)

This package is the first stable release of the Kubernetes Fleet management library.

## 1.0.0-beta.4 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.3 (2023-10-25)

### Features Added

- Updated to Fleet GA API version `2023-10-15`.

### Breaking Changes

- Remove preview features (hubprofile, private fleet)

## 1.0.0-beta.2 (2023-10-13)

### Features Added

- Updated to Fleet API `2023-08-15`.
- Add `FleetUpdateStrategy` support.

### Bugs Fixed

- Fix `SubnetResourceId` null check.
- Fix LRO async call issues.

## 1.0.0-beta.1 (2023-10-05)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
