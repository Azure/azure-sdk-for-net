# Release History

## 0.1.0-preview.7 (Unreleased)


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
