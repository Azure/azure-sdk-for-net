# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2025-06-20)

### Other Changes

- Updating .NET runtime dependencies to the 8.x line, the Azure extensions to 1.12.0, and the latest dependencies for the Functions host.

## 1.3.3 (2025-03-14)

### Other Changes

- Updating .NET runtime dependencies to the 6.x line, the Azure extensions to 1.8.0, and the latest dependencies for the Functions host.

## 1.3.2 (2024-06-13)

### Other Changes

- To mitigate a vulnerability, updating the transitive dependency for `Azure.Identity` to v1.11.4 via version bump to `Microsoft.Extensions.Azure`. 

## 1.3.1 (2024-04-17)

### Other Changes

- To mitigate a [disclosure vulnerability](https://github.com/advisories/GHSA-wvxc-855f-jvrv), updating the transitive dependency for `Azure.Identity` to v1.11.1 via version bump to `Microsoft.Extensions.Azure`. 

## 1.2.1 (2023-11-13)

### Other Changes

- Bump dependency on `Microsoft.Extensions.Azure` to prevent transitive dependency on deprecated version of `Azure.Identity`.

## 1.2.0 (2023-08-10)

### Features Added

- Support for binding to library types is now generally available.

## 1.2.0-beta.1 (2023-05-23)

### Features Added

- Added support for deferred binding to enable binding to library types in the .NET isolated worker.

## 1.1.0 (2023-03-08)

### Bugs Fixed

- Custom defined entity models that implement `ITableEntity` explicitly will now be serialized properly ([#26514](https://github.com/Azure/azure-sdk-for-net/issues/26514))

- Added support for parsing JSON bytes to `TableEntity` to support out-of-process language workers.

## 1.0.0 (2022-04-11)

### Breaking Changes

- The `AddAzureTables` extension method has been renamed to `AddTables`.

## 1.0.0-beta.2 (2022-03-10)

### Bugs Fixed

- Use value comparison for byte arrays when upserting.

## 1.0.0-beta.1 (2022-01-11)

This is the first beta of the `Microsoft.Azure.WebJobs.Extensions.Tables` client library.
