# Release History

## 12.12.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed an issue where `TimeSpan` properties in strongly typed table entities were not being deserialized.
- Fixed an issue when deserializing strongly typed table entities with enum properties. Enum values that aren't defined in the enum type are now skipped during deserialization of the table entity.

### Other Changes

## 12.11.0 (2025-05-06)

### Features Added

- Added support for specifying the token credential's Microsoft Entra audience when creating a client.

## 12.10.0 (2025-01-14)

### Breaking Changes

- Calling `TableClient.Query`, `TableClient.QueryAsync`, or `TableClient.CreateQueryFilter` with a filter expression that uses `string.Equals` or `string.Compare` with a `StringComparison` parameter will now throw an exception. This is because the Azure Table service does not support these methods in query filters. Previously the `StringComparison` argument was silently ignored, which can lead to subtle bugs in client code. The new behavior can be overridden by either setting an AppContext switch named "Azure.Data.Tables.DisableThrowOnStringComparisonFilter" to `true` or by setting the environment variable "AZURE_DATA_TABLES_DISABLE_THROWONSTRINGCOMPARISONFILTER" to "true". Note: AppContext switches can also be configured via configuration like below:

```xml
<ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Data.Tables.DisableThrowOnStringComparisonFilter" Value="true" />
</ItemGroup>
  ```


### Other Changes
- Improved the performance of `TableServiceClient.GetTableClient()`

## 12.9.1 (2024-09-17)

### Bugs Fixed
- Fixed an issue that prevented use of stored access policy based SaS Uris by adding a parameterless constructor to `TableSasBuilder`. The resulting builder can then be modified to include the stored access policy identifier or any other details.

### Other Changes
- Cosmos Table endpoints now support Entra ID authentication.

## 12.9.0 (2024-07-22)

### Features Added
- Overload the `DeleteEntity` method to allow an `ITableEntity` object as parameter.

### Bugs Fixed
- Fixed an issue where custom models decorated with the `DataMemberAttribute` that didn't explicitly set a name caused the query filter to be malformed.

### Other Changes
- Reduce List allocations when uploading batches to table storage

## 12.8.3 (2024-02-06)

### Bugs Fixed
- `TableEntity` string properties will correctly handle type coercion from `DateTime` and `DateTimeOffset` types. ([#40775](https://github.com/Azure/azure-sdk-for-net/issues/40775))
- Fixed an error handling bug that could result in an `ArgumentNullException` when calling `CreateIfNotExistsAsync`. ([#41463](https://github.com/Azure/azure-sdk-for-net/issues/41463))

## 12.8.2 (2023-11-13)

### Acknowledgments

Thank you to our developer community members who helped to make Azure Tables better with their contributions to this release:

- metjuperry _([GitHub](https://github.com/metjuperry))_

### Bugs Fixed

- Fixed an issue where custom models decorated with the `DataMemberAttribute` were not properly considered in query filters (A community contribution, courtesy of _[metjuperry]_ ([#38884](https://github.com/Azure/azure-sdk-for-net/issues/38884))

### Other Changes
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.8.1 (2023-08-15)

### Bugs Fixed
- Fixed the URL returned by `TableClient.Uri` when connecting to Azurite

## 12.8.0 (2023-02-08)

### Bugs Fixed
- Fixed an issue where LINQ predicates containing New expressions, such as `ent => ent.TimeStamp > new DateTimeOffset(...)`, threw an exception.

### Other Changes
- `TableClient.CreateIfNotExists` / `TableClient.CreateIfNotExistsAsync` documentation corrected (methods do not return `null` if the table already exists)
- `TableClient` and `TableServiceClient` constructors that take SAS credentials no longer throw if the URI scheme is not https if it is a loopback host
- Removed the `new()` constraint from methods on `TableClient`

## 12.7.1 (2022-12-06)

### Bugs Fixed
- Removed client side validation which prevented `GetEntity` and `GetEntityAsync` from getting an entity with an empty string as its RowKey or PartitionKey value. ([#32447](https://github.com/Azure/azure-sdk-for-net/issues/32447))

## 12.7.0 (2022-11-08)

### Features Added
- Added a `Uri` property to `TableClient` and `TableServiceClient`

### Breaking Changes
- `TableClient.GetEntityIfExists` now returns `NullableResponse<T>` which has a `HasValue` property which returns false when the entity did not exist. Accessing the `Value` property in this case will throw an exception.

### Bugs Fixed
- Fixed a OData filter issue with implicit boolean comparisons (for example expressions such as `ent => ent.BooleanProperty`) when calling `TableClient.QueryAsync(Expression<Func<T, bool>> filter, ...)`. ([#30185](https://github.com/Azure/azure-sdk-for-net/issues/30185))
- Fixed an issue where `PartitionKey` and `RowKey` parameter values containing single quote characters are not automatically escaped on `DeleteEntity` calls. The new behavior can be overridden by either setting an AppContext switch named "Azure.Data.Tables.DisableEscapeSingleQuotesOnDeleteEntity" to `true` or by setting the environment variable "AZURE_DATA_TABLES_DISABLE_ESCAPESINGLEQUOTESONDELETEENTITY" to "true". Note: AppContext switches can also be configured via configuration like below:

```xml
<ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Data.Tables.DisableEscapeSingleQuotesOnDeleteEntity" Value="true" />
</ItemGroup>
  ```

### Other Changes
- Custom defined entity models that implement `ITableEntity` explicitly will now be serialized properly ([#26514](https://github.com/Azure/azure-sdk-for-net/issues/26514))

## 12.7.0-beta.1 (2022-09-06)

### Features Added
- Added `TableClient.GetEntityIfExists` which will not throw or log an error to telemetry if the specified entity does not exist in the table.

### Bugs Fixed
- `TableClient.CreateIfNotExists` and `TableServiceClient.CreateTableIfNotExists` no longer log an error or exception to telemetry when the table already exists (response status 409). ([#28084](https://github.com/Azure/azure-sdk-for-net/issues/28084))
- `TableClient.CreateIfNotExists` and `TableServiceClient.CreateTableIfNotExists` no longer return null when the table already exists. ([#27821](https://github.com/Azure/azure-sdk-for-net/issues/27821))

## 12.6.1 (2022-07-07)

### Bugs Fixed
- Fixed a formatting issue with string based filter queries for Binary properties created via `CreateQueryFilter(System.FormattableString filter)`. ([#29256](https://github.com/Azure/azure-sdk-for-net/issues/29256))

## 12.6.0 (2022-06-07)

### Bugs Fixed
- Fixed an issue that caused `TableEntity.GetBinaryData` to return incorrectly formatted data for binary entity properties. ([#29029](https://github.com/Azure/azure-sdk-for-net/issues/29029))

## 12.6.0-beta.1 (2022-05-10)

### Features Added
- TenantId can now be discovered through the service OAuth challenge response, when using a TokenCredential for authorization against a Storage Table Service.
- A new property is now available on the `TableClientOptions` called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt an OAuth challenge containing the tenantId of the resource. This tenantId will then be used by the TokenCredential.
- Diagnostics logging no longer redacts the following query parameters: '$format', '$filter', '$top', '$select'

## 12.5.0 (2022-03-10)

### Bugs Fixed
- Fixed an issue that caused authenticate failures when using a SAS token with a table name that contains upper-case characters. ([#26791](https://github.com/Azure/azure-sdk-for-net/issues/26791))

## 12.4.0 (2022-01-12)

### Bugs Fixed
- Fixed a an issue when using `TableEntity.GetDateTime` that resulted in an `InvalidOperationException` exception. ([#25323](https://github.com/Azure/azure-sdk-for-net/issues/25323))
- `TableClient.GenerateSasUri(...)` does not throw if the client was constructed via `TableServiceClient.GetTableClient(string tableName)` ([#25881](https://github.com/Azure/azure-sdk-for-net/issues/25881))
- `TableClient.GenerateSasUri(...)` now generates a Uri with the table name in the path. ([#26155](https://github.com/Azure/azure-sdk-for-net/issues/26155))
- `TableClient` and `TableServiceClient` constructors taking a connection string now properly parse Cosmos emulator connection strings. ([#26326](https://github.com/Azure/azure-sdk-for-net/issues/26326))
## 12.3.0 (2021-11-09)

### Bugs Fixed
- Table entities now support UInt64 (ulong) properties. ([#24750](https://github.com/Azure/azure-sdk-for-net/issues/24750))
- Fixed an issue where `PartitionKey` and `RoKey` property values containing single quote characters are not properly escaped on `GetEntity` calls. See breaking changes section for more information.

### Breaking Changes
- The fix to escape`PartitionKey` and `RoKey` property values containing single quote characters are not properly escaped on `GetEntity` calls  may causes a breaking change for deployed applications that work around the previous behavior. For these situations, the new behavior can be overridden by either setting an AppContext switch named "Azure.Data.Tables.DisableEscapeSingleQuotesOnGetEntity" to `true` or by setting the environment variable "AZURE_DATA_TABLES_DISABLE_ESCAPESINGLEQUOTESONGETENTITY" to "true". Note: AppContext switches can also be configured via configuration like below:

```xml
<ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Data.Tables.DisableEscapeSingleQuotesOnGetEntity" Value="true" />
</ItemGroup>
  ```

## 12.2.1 (2021-10-14)

### Bugs Fixed
- Handle the case where the Uri parameter to the `TableClient` constructor contains the table name. ([#24667](https://github.com/Azure/azure-sdk-for-net/issues/24667))

## 12.2.0 (2021-09-07)

### Bugs Fixed

- Properly handle `GenerateSasUri` when the client is constructed with a connection string ([#23404](https://github.com/Azure/azure-sdk-for-net/issues/23404))
- Fixed an exception when constructing the `TableClient` with a connection string where the table name is the same as the account name.

## 12.2.0-beta.1 (2021-08-10)

Thank you to our developer community members who helped to make Azure Tables better with their contributions to this release:

- Yifan Bian _([yifanbian-msft](https://github.com/yifanbian-msft))_
- David Gardiner _([flcdrg](https://github.com/flcdrg))_

### Features Added

- Added support for customization of how model properties are serialized. Decorating a model property with the `[IgnoreDataMember]` attribute will ignore it on serialization and the `[DataMember(Name = "some_new_name")]` will rename the property.
- Added an extension method to the Builder extensions that accepts just the Table Uri. (A community contribution, courtesy of _[flcdrg](https://github.com/flcdrg))_.

### Bugs Fixed

- Fixed and issue with connection string parsing for Azure Storage Emulator connection strings. (A community contribution, courtesy of _[yifanbian-msft](https://github.com/yifanbian-msft))_.


## 12.1.0 (2021-07-07)

### Features Added

- Support for Azure Active Directory (AAD) authorization has been added to `TableServiceClient` and `TableClient`. This enables use of `TokenCredential` credentials. Note: Only Azure Storage API endpoints currently support AAD authorization.

## 12.0.1 (2021-06-10)

### Key Bugs Fixed

- Fixed an issue which would result in calls to `TableClient.Delete`, `TableClient.DeleteAsync`, `TableClient.DeleteEntity`, `TableClient.DeleteEntityAsync` throwing a `NullReferenceException` if the client was constructed with the `TableClient(string connectionString, string tableName, TableClientOptions options)` constructor.

## 12.0.0 (2021-06-08)

- Added `GenerateSasUri` methods to both `TableClient` and `TableServiceClient`.

## 12.0.0-beta.8 (2021-05-11)

### Breaking Changes

- Eliminated the `TableTransactionalBatch` type and added the `TableTransactionAction` type.
   - Submitting a batch transaction is now accomplished via the `TableClient.SubmitTransaction` or `TableClient.SubmitTransactionAsync` methods which accepts
    an `IEnumerable<TableTransactionAction>`.
- `TableClient.SubmitTransaction` and `TableClient.SubmitTransactionAsync` now return `Response<IReadOnlyList<Response>>` rather than `TableBatchResponse`.
    - `TableBatchResponse.GetResponseForEntity` is no longer necessary as the responses can now be correlated directly between the `Response<IReadOnlyList<Response>>`
    and the list of `TableTransactionAction`s provided to the submit method.
 - The following renames have occurred:
    - `TableServiceClient` methods `GetTables` and `GetTablesAsync` have been renamed to `Query` and `QueryAsync`
    - `TableServiceClient` methods `GetAccessPolicy` and `GetAccessPolicyAsync` have been renamed to `GetAccessPolicies` and `GetAccessPoliciesAsync`
    - `TableClientOptions` has been renamed to `TablesClientOptions`
    - `RetentionPolicy` has been renamed to `TableRetentionPolicy`
    - `SignedIdentifier` has been renamed to `TableSignedIdentifier`

### Changed
- Failed batch transaction operations now throw `TableTransactionFailedException` which contains a `FailedTransactionActionIndex` property to indicate which
`TableTransactionAction` caused the failure.

### Added

- Added `TableOdataFilter` to assist with odata string filter quoting and escaping.

### Key Bug Fixes

- Merge operations no longer fail for Cosmos table endpoints.

## 12.0.0-beta.7 (2021-04-06)

### Acknowledgments

Thank you to our developer community members who helped to make Azure Tables better with their contributions to this release:

- Joel Verhagen _([GitHub](https://github.com/joelverhagen))_

### Added

- Added the `TableErrorCode` type which allows comparison of the `ErrorCode` on `RequestFailedException`s thrown from client operations with a known error value.
- `TableEntity` and custom entity types now support `BinaryData` properties.

### Key Bug Fixes

- Fixed handling of paging headers when Table Storage returned a `x-ms-continuation-NextPartitionKey` but no `x-ms-continuation-NextRowKey`. This was causing an HTTP 400 on the subsequent page query (A community contribution, courtesy of _[joelverhagen](https://github.com/joelverhagen)_)

### Changed

- Removed the `Timestamp` property from the serialized entity when sending it to the service as it is ignored by the service (A community contribution, courtesy of _[joelverhagen](https://github.com/joelverhagen)_)

## 12.0.0-beta.6 (2021-03-09)

### Changed

- Changed major version number to 12 to indicate this is the latest Tables package across all legacy versions and for cross language consistency.
- `TableClient` and `TableServiceClient` now accept `AzureSasCredential` for SAS token scenarios rather than requiring developers to build the URI manually.

### Key Bug Fixes

- Fixed an issue that prevented start/end row key and partition key values from being used in Sas tokens

### Added

- Added TableUriBuilder
- Added a constructor to `TableSasBuilder` and `TableAccountSasBuilder` that accepts a Uri with a Sas token

## 3.0.0-beta.5 (2021-01-12)

### Key Bug Fixes

- Fixed an issue which transposed the values used for EndPartitionKey and StartRowKey in the generated Sas token Uri

## 3.0.0-beta.4 (2020-12-10)

### Key Bug Fixes

- Fixed an issue with custom entity model serialization of the `ETag` property
- Properly create secondary endpoint Uri for Azurite endpoints

## 3.0.0-beta.3 (2020-11-12)

### Added

- Added support for Upsert batch operations.
- Added support for some numeric type coercion for `TableEntity` properties.
- Added TryGetFailedEntityFromException method on `TablesTransactionalBatch` to extract the entity that caused a batch failure from a `RequestFailedException`.

## 3.0.0-beta.2 (2020-10-06)

### Added

- Implemented batch operations

### Changed

- `TableClient`'s `GetEntity` method now exposes the `select` query option to allow for more efficient existence checks for a table entity

## 3.0.0-beta.1 (2020-09-08)

This is the first beta of the `Azure.Data.Tables` client library. The Azure Tables client library can seamlessly target either Azure Table storage or Azure Cosmos DB table service endpoints with no code changes.

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tables/Azure.Data.Tables/README.md)
and [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/tables/Azure.Data.Tables/samples) demonstrate the new API.