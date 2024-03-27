# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2023-12-27)

### Features Added

- Stable version release for API version 2023-11-01.

## 1.4.0-beta.1 (2023-12-13)

### Features Added

- Update API version to 2023-11-01
- Add property `string JobIdentifier` to class `DataProtectionOperationJobExtendedInfo`, and now since the "jobId" returned by service is not always a resource identifier, `JobResourceId` will be null when `JobIdentifier` is not parsable to a resource identifier.

## 1.3.0 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.3.0-beta.1 (2023-09-26)

### Features Added

- Added support for AKS workload.
- Added support for secure score

### Other Changes

- Add property `identityDetails` to class `DataProtectionBackupInstanceProperties`.
- Add property `RehydrationPriority ` to class `DataProtectionBackupJobProperties`.
- Add property `FeatureSettings ` to class `DataProtectionBackupVaultPatchProperties`, replace the `CrossSubscriptionRestoreState`.
- Add property `IdentityDetails  ` to class `DeletedDataProtectionBackupInstanceProperties`.

## 1.2.0 (2023-07-20)

### Features Added

- Added new resourceGuardProxy Api's.

### Breaking Changes

- Add property `JobResourceId` to class `DataProtectionOperationJobExtendedInfo`, replace the `JobId`.

## 1.2.0-beta.1 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.2 (2023-04-26)

### Breaking Changes

- Add property `ResourceUriString` to class `DataSourceInfo`, replace the `ResourceUri`.
- Add property `ResourceUriString` to class `DataSourceSetInfo`, replace the `ResourceUri`.

## 1.1.1 (2023-02-17)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2023-02-03)

### Features Added

- Added support for Immutable vaults.
- Added support for Cross Subscription Restore.
- Added support for AKS workload.
- Added support for Soft Delete.

### Other Changes

- Upgraded API version to 2023-01-01.

## 1.0.0 (2022-11-04)

This package is the first stable release of the Microsoft Azure Data Protection Backup management client library.

### Breaking Changes

Polishing since last public beta release:
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Changed API version to 2022-05-01.

## 1.0.0-beta.1 (2022-10-11)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.DataProtection.Backup` to `Azure.ResourceManager.DataProtectionBackup`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
