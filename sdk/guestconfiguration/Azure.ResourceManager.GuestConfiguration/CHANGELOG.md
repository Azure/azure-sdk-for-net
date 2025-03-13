# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0 (2024-07-19)

### Features Added

- Upgraded api-version tag from 'package-2022-01-25' to 'package-2024-04-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/6dd7b1f0b4e62d1c2d78e1fa6ab3addd032d9920/specification/guestconfiguration/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.41.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.1.0 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-29)

This release is the first stable release of the Guest Configuration Management library.

### Breaking Changes

- Renamed the model `AssignmentReport` to `GuestConfigurationAssignmentReportInfo`.
- Renamed the model `ConfigurationInfo` to `GuestConfigurationInfo`.
- Renamed the model `ConfigurationParameter` to `GuestConfigurationParameter`.
- Renamed the method `GetGuestConfigurationAssignments` to `GetAllGuestConfigurationAssignmentData`.
- Corrected the extension methods `GetGuestConfigurationHcrpAssignment`, `GetGuestConfigurationHcrpAssignments`, `GetGuestConfigurationVmAssignment`, `GetGuestConfigurationVmAssignments`, `GetGuestConfigurationVmssAssignment` and `GetGuestConfigurationVmssAssignments` to make them extend from `ArmClient`.

## 1.0.0-beta.2 (2022-09-09)

### Features Added

- Added operations about the resources `GuestConfigurationHcrpAssignment` and `GuestConfigurationVmssAssignment`.

### Breaking Changes

- Renamed the resource `GuestConfigurationAssignment` to `GuestConfigurationVmAssignment`.
- Prepended `GuestConfiguration` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1.

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.GuestConfiguration` to `Azure.ResourceManager.GuestConfiguration`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
