# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.2 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0-beta.1 (2023-02-16)

### Features Added

- Added support for the class `DataLakeAnalyticsAccountCollection` overload operation `GetAll`&`GetAllAsync`
- Added support for the class `DataLakeAnalyticsStorageAccountInformationCollection` overload operation `GetAll`&`GetAllAsync`
- Added support for the class `DataLakeStoreAccountInformationCollection` overload operation `GetAll`&`GetAllAsync`
- Added support for the class `DataLakeAnalyticsExtensions` overload operation `GetAll`&`GetAllAsync`
- Added operation support to `DataLakeAnalyticsAccountCollectionGetAllOptions` & `DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions`& `DataLakeStoreAccountInformationCollectionGetAllOptions`& `SubscriptionResourceGetAccountsOptions`

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-12-05)

This package is the first stable release of the Microsoft Azure Data Lake Analytics management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `DataLakeAnalytics` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `Uri` type properties / parameters.
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the return type and parameter name of some functions.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.2.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-09-15)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.DataLake.Analytics` to `Azure.ResourceManager.DataLakeAnalytics`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
