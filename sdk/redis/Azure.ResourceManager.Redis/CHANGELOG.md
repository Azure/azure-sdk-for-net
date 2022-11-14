# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
