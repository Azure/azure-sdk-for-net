# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.1 (2025-08-06)

### Features Added

- Make `Azure.ResourceManager.PostgreSql` AOT-compatible

## 1.3.0 (2025-06-25)

### Features Added

- Introduced `AzureResourceManagerPostgreSqlContext` to make this library AOT compatible.

### Bugs Fixed

- Fixed some deprecated properties that are incorrectly implemented in the previous version.

## 1.2.0 (2024-11-05)

This release uses GA api version 2024-08-01 for PostgreSQL flexible server.

### Features Added

- Upgraded api-version tag from 'package-flexibleserver-2023-03-01-preview' to 'package-flexibleserver-2024-08-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ce47f9b775ec53750f37def0402ecacf3f1d661b/specification/compute/resource-manager/readme.md.
    - Storage auto growth
    - IOPS scaling
    - Backup - Long Term Retention
    - Backup - On-demand
    - Geo-redundant backup encryption key - Revive Dropped
    - Server Logs
    - Migrations
    - Migration Pre-validation
    - Migration Roles
    - Private endpoint Migration
    - Private Endpoints
    - Read replicas - Switchover
    - Read replicas - Virtual Endpoints
    - Azure Defender / Threat Protection APIs
    - PG 16 support
    - PremiumV2_LRS storage type support
    - Location capabilities updates

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0-beta.6 (2024-05-07)

### Features Added

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.2.0-beta.5 (2024-03-28)

### Features Added

- Added backwards compatibility model factory methods to support features added in version 1.1.3.

## 1.2.0-beta.4 (2024-03-26)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.1.3 (2024-03-25)

### Features Added

- Added model factory.

## 1.1.2 (2024-03-25)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this document for more details.
- Added experimental Bicep serialization.
- Added GetIfExists methods.
- Added mocking types.

## 1.2.0-beta.3 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-07-18)

This release uses api version 2023-03-01-preview for PostgreSQL flexible server.

### Features Added

- Data Encryption support for Geo-backup enabled servers.
- ReviveDropped. This allows you to revive the dropped servers.
- Migration
- Performance tier scaling for Storage
- Long Term Retention Backup
- LogFiles

### Breaking Changes

- Updated response object for ExecuteLocationBasedCapabilities.
- New properties added for Storage object under PostgreSqlFlexibleServerData to support features like IOPS scaling and Storage AutoGrow. StorageSizeInGB property available under Storage.

### Bugs Fixed

- ReplicaCapacity under PostgreSqlFlexibleServerData is now marked as read-only as this cannot be updated.
- Removed unsupported IdentityType "SystemAssigned".
- Renamed KeyType for Data encryption feature from unsupported SystemAssigned to supported SystemManaged.
- Support Network object to be updated as part of PostgreSqlFlexibleServerPatch call.
- Remove unsupported ReplicationRoles GeoSyncReplica, Secondary, SyncReplica, WalReplica.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2023-02-02)

This release uses GA api version 2022-12-01 for PostgreSQL flexible server.

### Features Added

- Data encryption
- User managed identities
- Active Directory authentication
- Geo-Restore
- Read Replicas
- Same Zone HA
- Server backups
- Major version upgrade

## 1.0.0 (2022-09-05)

This release is the first stable release of the PostgreSql Management client library.

### Other Changes

- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

Polishing since last public beta release:
- Prepended `PostgreSql` prefix to all single / simple model names.
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

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.PostgreSql` to `Azure.ResourceManager.PostgreSql`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
