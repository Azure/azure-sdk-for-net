# Release History

## 1.6.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.5.1 (2025-07-28)

### Features Added

- Make `Azure.ResourceManager.Redis` AOT-compatible

## 1.5.0 (2024-12-18)

### Features Added

  - Exposed `JsonModelWriteCore` for model serialization procedure.
  - Adds support for choosing ZonalAllocationPolicy for your Azure Cache for Redis instance.

## 1.4.0 (2024-07-11)

### Features Added
  - Adds support for Disabling Access Keys Authentication for your Azure Cache for Redis instance

## 1.3.3 (2024-05-07)

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.3.2 (2024-04-29)

### Features Added

- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.3.1 (2024-03-23)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.3.0 (2024-01-23)

### Other Changes

- Mark prerelease Azure.ResourceManager.Redis 1.3.0-beta.1 for release

## 1.3.0-beta.1 (2023-12-15)

### Features Added
  - Adds support for using Microsoft Entra token-based authentication for your Azure Cache for Redis instance
  - Adds support to choose an update channel
  - Adds support the flush data operation to delete or flush all data in your cache

## 1.2.1 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0 (2023-06-24)

### Features Added

- Enable Persistence(aof/rdb) on storage account in a different subscription than the cache via Managed Identity Auth Type. RedisConfiguration has a new property storage-subscription-id.

### Bugs Fixed

- Updated validation to ensure access to storage account while enabling persistence.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2022-11-10)

### Features Added

- ExportRdbContent has a new property PreferredDataArchiveAuthMethod.
- ImportRdbContent has a new property PreferredDataArchiveAuthMethod.
- RedisLinkedServerWithPropertyCreateOrUpdateContent has a new property GeoReplicatedPrimaryHostName.
- RedisLinkedServerWithPropertyCreateOrUpdateContent has a new property PrimaryHostName.
- RedisLinkedServerWithPropertyData has a new property GeoReplicatedPrimaryHostName.
- RedisLinkedServerWithPropertyData has a new property PrimaryHostName.

### Bugs Fixed

- Deleting a linked server is now a long-running operation.
- Updating a cache is now a long-running operation.

### Other Changes

- Upgraded API version to 2022-06-01.

## 1.0.2 (2022-10-01)

### Bugs Fixed

- Fixed the serialization issue of `RedisCommonConfiguration.IsAofBackupEnabled` and `RedisCommonConfiguration.IsRdbBackupEnabled`.

## 1.0.1 (2022-09-27)

### Bugs Fixed

- Fixed the serialization issue of `RedisCommonConfiguration.RdbBackupMaxSnapshotCount`.

## 1.0.0 (2022-08-29)

This package is the first stable release of the Redis Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Redis` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Redis` to `Azure.ResourceManager.Redis`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
