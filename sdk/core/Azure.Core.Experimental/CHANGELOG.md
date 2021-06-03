# Release History

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
