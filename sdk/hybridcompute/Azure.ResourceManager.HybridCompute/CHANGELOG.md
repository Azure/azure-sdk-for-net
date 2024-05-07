# Release History

## 1.0.0-beta.8 (2024-05-07)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fix format type of ESU license status

## 1.0.0-beta.7 (2024-01-03)

### Features Added

- Upgraded api-version tag to 'package-preview-2023-10'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f6278b35fb38d62aadb7a4327a876544d5d7e1e4/specification/hybridcompute/resource-manager/readme.md.
    - Added run commands for hybrid machine.

## 1.0.0-beta.6 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.5 (2023-10-17)

### Features Added

- Added install patches for hybrid machine
- Added assess patches for hybrid machine

## 1.0.0-beta.4 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.3 (2023-04-17)

### Bugs Fixed

- Fixed an issue that `System.UriFormatException` is thrown when `Uri` type field is empty during serialization of `AgentConfiguration`.

## 1.0.0-beta.2 (2023-02-17)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-09-22)

### Features Added

New design of track 2 initial commit.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
