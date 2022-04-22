# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (2022-01-13)

### Features Added

- Updated the caching of schemas to use a 128 LRU cache.

### Breaking Changes

- Replaced `SchemaRegistryAvroObjectSerializer` with `SchemaRegistryAvroEncoder`. When using the encoder, the schema Id will be stored in the ContentType of `EventData`, rather than in the Body of the `EventData`.

## 1.0.0-beta.4 (2021-11-11)

### Features Added

- Updated dependency on `Azure.Data.SchemaRegistry`.

## 1.0.0-beta.3 (2021-10-06)

### Features Added

- Added caching of schemas.
- Updated dependency on `Azure.Data.SchemaRegistry`.

## 1.0.0-beta.2 (2021-08-17)
- Updated dependency on `Azure.Data.SchemaRegistry`.

## 1.0.0-beta.1 (2020-09-08)
- Added SchemaRegistryAvroObjectSerializer
  - Derives from ObjectSerializer
  - Works with 2 Avro types:
    - SpecificRecord
    - GenericRecord
