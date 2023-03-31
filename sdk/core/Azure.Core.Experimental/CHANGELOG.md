# Release History

## 0.1.0-preview.26 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Use specified `DynamicJsonNameMapping` in array and object enumerators.

### Other Changes

## 0.1.0-preview.25 (2023-03-02)

### Features Added

- Made `DynamicJson` and `MutableJsonDocument` disposable.
- Enabled enumerating over object properties in `DynamicJson` and `MutableJsonElement`.
- Made it possible to use PascalCase accessors with `DynamicJson` properties.
- Enabled checking for null to determine if property is present in `DynamicJson`.

### Breaking Changes

- Moved `MutableJsonDocument` and `MutableJsonElement` into namespace `Azure.Core.Json`.

## 0.1.0-preview.24 (2023-02-06)

### Features Added

- Added types `MutableJsonDocument` and `MutableJsonElement`.  These types have APIs similar to the BCL types `JsonDocument` and `JsonElement`, but allow the JSON content to be changed.
- Added types `DynamicJson` and `DynamicData`, which provide a dynamic layer over a data payload.  This allows schematized data to be accessed using patterns similar to those used with standard .NET types.
- Added extension method `ToDynamic()` to `BinaryData`.  This enables retrieving `DynamicJson` from the `Response.Content` property.

### Breaking Changes

- Removed `JsonData` type.

## 0.1.0-preview.23 (2022-11-08)

### Other Changes

- Added .NET 6 to the target frameworks

## 0.1.0-preview.22 (2022-04-04)

### Breaking Changes

- `MessageWithMetadata` has been moved into the `Azure.Core` package.

## 0.1.0-preview.21 (2022-03-09)

### Breaking Changes

- Rename `MessageWithMetadata` to `BinaryContent`

## 0.1.0-preview.20 (2022-02-07)

### Features Added

- `MessageWithMetadata` is now a concrete rather than abstract class.

### Breaking Changes

- `MessageWithMetadata` is now in the `Azure` namespace rather than `Azure.Messaging`.
- Changed `ContentType` property of `MessageWithMetadata` from a `string` to a `ContentType`

## 0.1.0-preview.19 (2022-01-11)

### Features Added

- Added `RequestOptions` to enable per-invocation control of the request pipeline.

### Breaking Changes

- The following types were removed:
    - `ClassifiedResponse`
    - `ExceptionFormattingResponseClassifier`
    - `ResponseExtensions`
    - `ResponsePropertiesPolicy`

## 0.1.0-preview.18 (2021-11-03)

- The following types were removed:
    - `RequestOptions`
    - `ResponseStatusOption`

## 0.1.0-preview.17 (2021-10-01)

### Breaking Changes

- The following types were removed:
    - `DynamicContent`
    - `DynamicRequest`
    - `DynamicResponse`
    - `ProtocolClientOptions`

## 0.1.0-preview.16 (2021-09-07)

### Other Changes

- Update `Azure.Core` version.

## 0.1.0-preview.15 (2021-08-18)

### Features Added

- Added support for per call response classification.

## 0.1.0-preview.14 (2021-06-30)

### New Features
- Added `ResponseError` type to represent the standard Azure error response.


## 0.1.0-preview.13 (2021-06-08)

### New Features
- Added `DateTimeRange` type to represent ISO 8601 time interval.

## 0.1.0-preview.12 (2021-05-11)

### New Features
- Added `RequestOptions`.

## 0.1.0-preview.11 (2021-03-22)

### New Features
- Improved debugging experience for `JsonData`.
- `JsonData` can be used with `JsonSerializer`

## 0.1.0-preview.10 (2021-03-09)


## 0.1.0-preview.9 (2021-02-09)

### Key Bug Fixes
- Fixed a dependency issue with `Azure.Core`, rebinding the reference to the latest released package.

## 0.1.0-preview.8 (2021-02-09)

### New Features
- Added `ProtocolClientOptions`, `DynamicRequest`, `DynamicResponse` types.

### Breaking Changes
- Methods from `SerializationExtensions` moved into `Azure.Core` package.

## 0.1.0-preview.7 (2020-10-28)

### Breaking Changes
- `JsonPatchDocument` type moved to `Azure.Core` package.

## 0.1.0-preview.6 (2020-10-06)

### Breaking Changes
- `BinaryData`: Change return type of `FromObjectAsync` from `Task<T>` to `ValueTask<T>`

## 0.1.0-preview.5 (2020-09-03)

### Added
- `JsonPatchDocument` type to represent JSON Path document.
- `BinaryData`: FromString method.
- `BinaryData`: FromBytes method taking ReadOnlySpan.
- `BinaryData`: constructor taking ReadOnlyMemory.

### Breaking Changes
- `BinaryData`: Renamed `Serialize` to `FromObject`.
- `BinaryData`: Renamed `Deserialize` to `ToObject`.
- `BinaryData`: Renamed `FromMemory` to `FromBytes`.

## 0.1.0-preview.4 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context
## 0.1.0-preview.3 (2020-08-06)

### Breaking Changes
- `ObjectSerializer`: Moved to `Azure.Core`.

## 0.1.0-preview.2 (2020-07-02)

### Breaking Changes
- `BinaryData`: Renamed `AsString` to `ToString`.
- `BinaryData`: Replaced `Create(string)` with constructor taking string.
- `BinaryData`: Renamed `Create(Stream)`/`CreateAsync(Stream)` to `FromStream`/`FromStreamAsync`.
- `BinaryData`: Renamed `Create<T>`/`CreateAsync<T>` to `FromSerializable<T>`/`FromSerializableAsync<T>`.
- `BinaryData`: Renamed `As<T>`/`AsAsync<T>` to `Deserialize<T>`/`DeserializeAsync<T>`.

## 0.1.0-preview.1 (2020-06-04)

### Added

- Added serialization primitives: `ObjectSerializer`,`JsonObjectSerializer`
- Added spatial geometry types.
- Added `BinaryData` type.
