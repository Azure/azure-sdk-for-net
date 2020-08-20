# Release History

## 0.1.0-preview.5 (Unreleased)

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
