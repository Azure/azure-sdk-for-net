# Release History

## 1.1.3 (2025-11-13)

This is a patch release for 1.1.2.

### Features Added

- Upgraded api-version tag from 'package-preview-2023-10' to 'package-2021-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/7d5d1db0c45d6fe0934c97b6a6f9bb34112d42d1/specification/maintenance/resource-manager/readme.md.

### Bugs Fixed

- fix string format serialization of DateTimeOffset.

## 1.2.0-beta.9 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0-beta.8 (2024-04-28)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-09' to 'package-preview-2023-10'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/741b0c8c71d90525a92bc4f2e45cb189c3affccd/specification/maintenance/resource-manager/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.11.1

## 1.2.0-beta.7 (2023-12-08)

### Bugs Fixed

 - Add ApiVersion support for `ConfigurationAssignmentsRestClient` in `MockableMaintenanceResourceGroupResource` for issue #40511

## 1.2.0-beta.6 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.5 (2023-10-31)

### Features Added

- Upgraded api-version tag from 'package-2023-04' to 'package-preview-2023-09'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/13aec7f115c01ba6986ebf32488537392c0df6f5/specification/maintenance/resource-manager/readme.md

## 1.2.0-beta.4 (2023-09-15)

- Fix the string format of `StartOn` and `ExpireOn` in `MaintenanceConfigurationData` serialization.

## 1.2.0-beta.3 (2023-09-05)

### Bugs Fixed

- Fix the missing `MaintenanceConfigurationData.InstallPatches` serialization issue.

## 1.2.0-beta.2 (2023-07-24)

### Features Added

- Bump the api-version to `2023-04-01`.

### Other Changes

- Upgraded dependent Azure.Core to 1.34.0.
- Upgraded dependent Azure.ResourceManager to 1.7.0.

## 1.2.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.2 (2023-03-11)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.1.1 (2023-03-06)

### Bugs Fixed

- Fixed the serilization issue for properties `MaintenanceConfigurationData.StartOn` and `MaintenanceConfigurationData.ExpireOn`.
- Fixed the incorrect response from `MaintenanceConfigurationResource.Delete` operation.

### Other Changes

- Add test cases.

## 1.1.0 (2023-02-13)

### Features Added

- Introduced property bag for the methods with more than 5 parameters.

### Bugs Fixed

- Fixed parameter mapping in `MaintenanceApplyUpdateResource`.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-12-23)

This release is the first stable release of the Maintenance Management library.

### Features Added

- Upgraded API version to 2021-05-01.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Maintenance` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.2.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-09-22)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Maintenance` to `Azure.ResourceManager.Maintenance`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
