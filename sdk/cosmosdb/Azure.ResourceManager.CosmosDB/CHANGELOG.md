# Release History

## 1.4.0-beta.6 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Add support for 'restoreWithTtlDisabled' in RestoreParameter to disable ttl on restored account
- Adds support for PerRegionPerPartitionAutoscale feature.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0-beta.5 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.4.0-beta.4 (2023-10-30)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-03-15' to 'package-preview-2023-09'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/35215554aef59a30fa709e4b058931101a5ef26b/specification/cosmos-db/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.34.0 to 1.35.0

## 1.4.0-beta.3 (2023-07-31)

### Features Added

 - Updated Microsoft.DocumentDB RP API version to `2023-03-15-preview`
 - Adds support for Database partition merge operation.
 - Adds support for Materialized view in Collections.

## 1.4.0-beta.2 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Bugs Fixed

- Fixed an issue that `System.UriFormatException` is thrown when `Uri` type field is empty during serialization of `CosmosDBAccountData`.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.4.0-beta.1 (2023-04-28)

### Features Added

- Updated Microsoft.DocumentDB RP API version to `2022-11-15-preview`
- Added support for restoring deleted table and gremlin resources within the same account
- Added support for cross region restore
- Added support for enabling burst capacity of the CosmosDB account

## 1.3.0 (2023-04-11)

### Features Added

- Updated Microsoft.DocumentDB RP API version to `2022-11-15`
- Added table and gremlin restorable apis
- Added CosmosDBMinimalTlsVersion property

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.2.1 (2023-02-13)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.2.0 (2022-11-29)

### Features Added

- Upgraded API version to 2022-08-15.
- Added MongoDB RBAC APIs.

## 1.1.0 (2022-10-27)

### Features Added

- Upgraded API version to 2022-05-15.

## 1.0.1 (2022-09-13)

### Breaking Changes

- Changed the constructor of `CosmosDBAccountBackupPolicy` from public to protected

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0 (2022-07-21)

This package is the first stable release of the Azure Cosmos DB management library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `CosmosDB` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.5 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it's only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.4 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously doesn't have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.3 (2022-01-30)

### Features Added

- Bump API version to `2021-08-01`

### Breaking Changes

- `waitForCompletion` is now a required parameter and moved to the first parameter in LRO operations

## 1.0.0-beta.2 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class
- Class `RestorableDatabaseAccountCollection` now implements `IEnumerable<T>` and `IAsyncEnumerable<T>`

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`
- Constructor of `RestorableDatabaseAccountCollection` no longer accepts `location` as its first parameter.
- Method `GetRestorableDatabaseAccounts` in `SubscriptionExtensions` now accepts an extra parameter `location`.

### Bugs Fixed

- Fixed comments for `FirstPageFunc` of each pageable resource class

## 1.0.0-beta.1 (2021-12-07)

### Breaking Changes

New design of track 2 initial commit.

#### Package Name

The package name has been changed from `Microsoft.Azure.Management.CosmosDB` to `Azure.ResourceManager.CosmosDB`

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
