# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.1 (2025-07-28)

### Features Added

- Make `Azure.ResourceManager.AppConfiguration` AOT-compatible. 

## 1.4.0 (2025-01-24)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-08' to 'package-2024-05-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/b72e0199fa3242d64b0b49f38e71586066a8c048/specification/appconfiguration/resource-manager/readme.md.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Other Changes

- Upgraded Azure.Core from 1.39.0 to 1.44.1
- Upgraded Azure.ResourceManager from 1.12.0 to 1.13.0

## 1.3.2 (2024-05-07)

### Features Added

- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.3.1 (2024-03-23)

### Features Added

- Added experimental Bicep serialization.

## 1.2.0 (2024-01-30)

### Features Added

- Updated AppConfiguration RP API version to `2023-03-01` (ReplicaCollection, ReplicaData and ReplicaResource)

### Other Changes

- Removed AppConfigurationKeyValueCollection.GetAll() and AppConfigurationKeyValueCollection.GetAllAsync() (They never work. You may use data plane sdk: Azure.Data.AppConfiguration.ConfigurationClient.GetConfigurationSettings() or Azure.Data.AppConfiguration.ConfigurationClient.GetConfigurationSettingsAsync() )

## 1.1.0 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-25)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0 (2022-08-29)

This release is the first stable release of the App Configuration Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `AppConfiguration` prefix to all single / simple model names.
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

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.5 (2022-07-12)

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

- Polished name and type for some models, properties, parameters.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.4 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.3 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

### Other Changes

- Refresh reference

## 1.0.0-beta.2 (2022-01-06)

### Other Changes

    - Refresh reference

## 1.0.0-beta.1 (2021-12-01)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
