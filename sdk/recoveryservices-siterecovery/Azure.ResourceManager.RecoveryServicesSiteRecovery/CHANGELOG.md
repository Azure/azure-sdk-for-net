# Release History

## 1.2.0 (2024-02-20)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Upgraded api-version tag from 'package-2023-06' to 'package-2023-08'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/39608b2c1c7b7dc06cb99abb9d733665cfce9a75/specification/recoveryservicessiterecovery/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.1

## 1.1.1 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0 (2023-09-25)

### Features Added

- Upgraded api-version tag from 'package-2023-04' to 'package-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/5dd1107d5f2be8d600325d795450e1d854fbe7e8/specification/recoveryservicessiterecovery/resource-manager/readme.md
- Changes Related to Integration of In place OS upgrade [Upgrade Windows Guideline](https://learn.microsoft.com/azure/migrate/how-to-upgrade-windows).
- Changes Releated to Implementing Monitoring Flow.

### Other Changes

- Upgraded Azure.Core from 1.33.0 to 1.35.0
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0

## 1.0.0 (2023-06-27)

This release is the first stable release of the Azure Recovery Services Site Recovery Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `SiteRecovery` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded API version to 2023-04-01.

## 1.0.0-beta.3 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.2 (2022-12-07)

### Features Added

- support for EZ-to-EZ scenarios for unplanned failover and recovery plans
- added primary and recovery extended locations to fabric job and recovery plan

### Other Changes

- Upgraded API version to 2022-10-01.

## 1.0.0-beta.1 (2022-09-25)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.RecoveryServices.SiteRecovery` to `Azure.ResourceManager.RecoveryServicesSiteRecovery`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).