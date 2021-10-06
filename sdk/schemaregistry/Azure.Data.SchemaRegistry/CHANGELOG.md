# Release History

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
