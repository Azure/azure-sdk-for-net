# Release History

## 12.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed a an issue when using `TableEntity.GetDateTime` that resulted in an `InvalidOperationException` exception. ([#25323](https://github.com/Azure/azure-sdk-for-net/issues/25323)) 

### Other Changes

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
