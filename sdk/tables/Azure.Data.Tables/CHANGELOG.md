# Release History

## 3.0.0-beta.6 (Unreleased)

### Added

- Added TableUriBuilder
- Added a constructor to TableSasBuilder and TableAccountSasBuilder that accepts a Uri with a Sas token

## 3.0.0-beta.5 (2021-01-12)

### Fixed

- Fixed an issue which transposed the values used for EndPartitionKey and StartRowKey in the generated Sas token Uri

## 3.0.0-beta.4 (2020-12-10)

### Fixed

- Fixed an issue with custom entity model serialization of the ETag property
- Properly create secondary endpoint Uri for Azurite endpoints

## 3.0.0-beta.3 (2020-11-12)

### Added

- Added support for Upsert batch operations.
- Added support for some numeric type coercion for TableEntity properties.
- Added TryGetFailedEntityFromException method on TablesTransactionalBatch to extract the entity that caused a batch failure from a RequestFailedException.

## 3.0.0-beta.2 (2020-10-06)

### Added

- Implemented batch operations

### Changed

- `TableClient`'s `GetEntity` method now exposes the `select` query option to allow for more efficient existence checks for a table entity

## 3.0.0-beta.1 (2020-09-08)

This is the first beta of the `Azure.Data.Tables` client library. The Azure Tables client library can seamlessly target either Azure Table storage or Azure Cosmos DB table service endpoints with no code changes.

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/README.md) 
and [samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/tables/Azure.Data.Tables/samples) demonstrate the new API.
