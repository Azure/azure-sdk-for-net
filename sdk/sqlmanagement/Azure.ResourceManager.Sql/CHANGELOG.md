# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class
- Class `DeletedServerCollection`, `InstanceFailoverGroupCollection`, `SqlTimeZoneCollection`, `ServerTrustGroupCollection`, `SubscriptionUsageCollection`, `ResourceGroupLongTermRetentionBackupCollection`, `SubscriptionLongTermRetentionBackupCollection`, `ResourceGroupLongTermRetentionManagedInstanceBackupCollection` and `SubscriptionLongTermRetentionManagedInstanceBackupCollection` now implements `IEnumerable<T>` and `IAsyncEnumerable<T>`.

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`
- Constructor of `DeletedServerCollection`, `InstanceFailoverGroupCollection`, `SqlTimeZoneCollection`, `ServerTrustGroupCollection` and `SubscriptionUsageCollection` no longer accept `locationName` as their first parameter.
- Constructor of `ResourceGroupLongTermRetentionBackupCollection` and `SubscriptionLongTermRetentionBackupCollection` no longer accept `locationName`, `longTermRetentionServerName` and `longTermRetentionDatabaseName` as its first three parameters.
- Constructor of `ResourceGroupLongTermRetentionManagedInstanceBackupCollection` and `SubscriptionLongTermRetentionManagedInstanceBackupCollection` no longer accept `locationName`, `managedInstanceName` and `databaseName` as its first three parameters.
- Method `GetInstanceFailoverGroups` and `GetServerTrustGroups` in `ResourceGroupExtensions` now accepts an extra parameter `locationName`.
- Method `GetResourceGroupLongTermRetentionBackups` in `ResourceGroupExtensions` now accepts three extra parameters `locationName`, `longTermRetentionServerName` and `longTermRetentionDatabaseName`.
- Method `GetResourceGroupLongTermRetentionManagedInstanceBackups` in `ResourceGroupExtensions` now accepts three extra parameters `locationName`, `managedInstanceName` and `databaseName`.
- Method `GetDeletedServers`, `GetSqlTimeZones` and `GetSubscriptionUsages` now accepts an extra parameter `locationName`.
- Method `GetSubscriptionLongTermRetentionBackups` now accepts three extra parameters `locationName`, `longTermRetentionServerName` and `longTermRetentionDatabaseName`.
- Method `GetSubscriptionLongTermRetentionManagedInstanceBackups` now accepts three extra parameters `locationName`, `managedInstanceName` and `databaseName`.

### Bugs Fixed

- Fixed comments for `FirstPageFunc` of each pageable resource class

## 1.0.0-beta.1 (2021-12-03)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).
