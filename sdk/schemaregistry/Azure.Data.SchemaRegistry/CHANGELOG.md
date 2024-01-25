# Release History

## 1.4.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0-beta.2 (2023-08-08)

### Features Added

- Added `SchemaRegistrySerializer` which serializes using JSON by default.

## 1.4.0-beta.1 (2023-01-12)

### Features Added

- Added support for JSON schemas. Currently only Draft 3 of JSON is supported by the service.
- Added support for custom schema formats.

## 1.3.0 (2022-10-11)

### Features Added

- Added a `GetSchema` overload that gets a schema version using its group name, schema name, and version number.

## 1.2.0 (2022-05-11)

### Features Added

- Added `GroupName` and `Name` properties to `SchemaProperties`.

## 1.1.0 (2022-01-25)

### Breaking Changes

- Remove unnecessary dependency on Apache Avro.

## 1.0.0 (2021-11-09)

### Features Added

- General availability of `Azure.Data.SchemaRegistry`.
- Added `SchemaRegistryModelFactory`.

### Breaking Changes

- Removed preview service versions.
- Renamed `Content` property of `SchemaRegistrySchema` to `Definition`.
- Renamed `name` parameter of `RegisterSchema` and `GetSchemaProperties` methods to `schemaName`.

## 1.0.0-beta.4 (2021-10-06)

### Features Added

- Added `FullyQualifiedNamespace` property to `SchemaRegistryClient`.

### Breaking Changes

- Removed caching from `SchemaRegistryClient`.
- Renamed `GetSchemaId` method to `GetSchemaProperties`.
- Renamed `endpoint` parameter to `fullyQualifiedNamespace` in constructor.
- Renamed `SerializationType` to `SchemaFormat`.
- Make all methods return `Response<T>` instead of `T`.
- Changed return type of `GetSchema` to `SchemaRegistrySchema` type.

## 1.0.0-beta.3 (2021-08-16)
- Added caching to `SchemaRegistryClient`.

## 1.0.0-beta.2 (2020-09-22)
- Fixed schema encoding issue.

## 1.0.0-beta.1 (2020-09-08)
- Added SchemaRegistryClient with 3 operations:
  - RegisterSchema
  - GetSchemaId
  - GetSchema
