# Release History

## 1.0.1 (2023-02-17)

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

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
