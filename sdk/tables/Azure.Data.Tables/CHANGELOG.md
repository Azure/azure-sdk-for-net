# Release History

## 12.0.0-beta.7 (2021-04-06)

### Acknowledgments

Thank you to our developer community members who helped to make Azure Tables better with their contributions to this release:

- Joel Verhagen _([GitHub](https://github.com/joelverhagen))_

### Added

- Added the `TableErrorCode` type which allows comparison of the `ErrorCode` on `RequestFailedException`s thrown from client operations with a known error value.

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

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/README.md) 
and [samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/tables/Azure.Data.Tables/samples) demonstrate the new API.
