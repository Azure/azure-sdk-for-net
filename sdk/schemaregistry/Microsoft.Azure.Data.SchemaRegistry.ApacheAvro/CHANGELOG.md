# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.1 (2024-03-29)

### Other changes
- Added a direct reference to `Newtonsoft.Json` v13.0.3 to hoist up the version used by `Apache.Avro`, which has known security vulnerabilities.

## 1.0.0 (2022-05-11)

### Breaking Changes

- Remove custom exception type `SchemaRegistryAvroException`.

## 1.0.0-beta.8 (2022-04-05)

### Breaking Changes

- Wrap Apache Avro exceptions with new exception type, `SchemaRegistryAvroException`.

## 1.0.0-beta.7 (2022-03-11)

### Features Added

- Added logging of cache size.
- Non-generic overloads are available for serializing and deserializing.

### Breaking Changes

- `SchemaRegistryAvroEncoder` has been renamed to `SchemaRegistryAvroSerializer`
- The `DecodeMessageData` method has been renamed to `Deserialize`.
- The `EncodeMessageData` method has been renamed to `Serialize`.
- The type `MessageWithMetadata` has been renamed to `BinaryContent`.

## 1.0.0-beta.6 (2022-02-10)

### Features Added

- Added dynamic overload for encoding messages.
- Added generic overload for decoding messages.

### Breaking Changes

- The generic method signature for encoding has changed.
- The dynamic method signature for decoding has changed.

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
