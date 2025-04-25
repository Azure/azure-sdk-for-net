# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0 (2024-09-10)

### Features Added

- Upgraded api-version tag from 'package-2020-06' to 'package-2024-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1aa912658531534e4e57ea613591075f7b97897c/specification/privatedns/resource-manager/readme.md.
- Added resolutionPolicy enum to VirtualNetworkLink resource. This new property can be used to set up resolution policies for virtual networks linked to privatelink zones.

### Other Changes

- Upgraded Azure.Core from 1.39.0 to 1.42.0
- Upgraded Azure.ResourceManager from 1.11.1 to 1.13.0

## 1.1.1 (2024-04-29)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

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

## 1.0.1 (2023-02-28)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-12-05)

### Breaking Changes

 - Split `RecordSet` to each `PrivateDns[RecordType]Record`
 - Rename `PrivateZone` to `PrivateDnsZone`
 - Rename `RecordSet` to `Record`
 - Renamed some properties to more comprehensive names.

### Other Changes

 - Upgraded dependent `Azure.ResourceManager` to 1.3.2
 - Upgraded dependent `Azure.Core` to 1.26.0

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.PrivateDns` to `Azure.ResourceManager.PrivateDns`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
