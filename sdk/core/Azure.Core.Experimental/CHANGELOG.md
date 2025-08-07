# Release History

## 0.1.0-preview.38 (Unreleased)

### Features Added

### Breaking Changes

- Migrated the following types to System.ClientModel for 3rd-party Authentication support: `AuthenticationTokenProvider`, `GetTokenOptions`, `AccessToken`, and `OAuth2BearerTokenAuthenticationPolicy`.

### Bugs Fixed

### Other Changes

## 0.1.0-preview.37 (2025-03-20)

### Features Added

- Added the following types for 3rd-party Authentication support: `AuthenticationTokenProvider`, `GetTokenOptions`, `AccessToken`, and `OAuth2BearerTokenAuthenticationPolicy`.

## 0.1.0-preview.36 (2024-10-03)

### Breaking Changes

- Removed the `PopTokenRequestContext` type and added the proof of possession-related properties to `TokenRequestContext` in Azure.Core ([45134](https://github.com/Azure/azure-sdk-for-net/pull/45134)).

### Other Changes

- Upgraded `System.Memory.Data` package dependency to 6.0.0 ([#46134](https://github.com/Azure/azure-sdk-for-net/pull/46134)).

## 0.1.0-preview.35 (2024-09-12)

### Breaking Changes

- Remove Protobuf support ([#44472](https://github.com/Azure/azure-sdk-for-net/pull/44472))

## 0.1.0-preview.34 (2024-06-06)

### Bugs Fixed

- Fixed a bug in the `PopTokenRequestContext` constructor that caused the `IsProofOfPossessionEnabled` property to be ignored.

## 0.1.0-preview.33 (2024-04-04)

- Added `IsProofOfPossessionEnabled` property to `PopTokenRequestContext` to support Proof of Possession tokens.

## 0.1.0-preview.32 (2024-01-11)

### Features Added

- Added types `PopTokenRequestContext`, `PopTokenAuthenticationPolicy`, and `ISupportsProofOfPossession` to support Proof of Possession tokens.

## 0.1.0-preview.31 (2023-11-10)

### Breaking Changes

- `Variant.As<T>` now allows returning `null` for reference types with no value.
- If a `Variant` is assigned a value that is a `Variant`, the left-hand `Variant` operand will now store the value that the right-hand `Variant` operand represents instead of storing the value as the `Variant` itself.

## 0.1.0-preview.30 (2023-09-07)

### Breaking Changes

- Changed default location of `cloudmachine.json` passed to `CloudMachine` constructor.
- Renamed `Azure.Value` to `Azure.Variant`.
- Added cast operators to/from string to `Variant`.
- Added `Variant.Null` and `variant.IsNull` APIs to `Variant`.
- Added `ToString` implementation to `Variant`.

## 0.1.0-preview.29 (2023-08-07)

### Features Added

- Added SchemaValidator and LruCache types for use with Azure.Data.SchemaRegistry preview library.
- Added CloudMachine and ProvisionableTemplateAttribute types for use with CloudMachine.

## 0.1.0-preview.28 (2023-07-11)

### Breaking Changes

- Removed `DynamicData` type.

## 0.1.0-preview.27 (2023-05-09)

### Features Added

- Added support for `== null` and value equality for primitives to `DynamicData`.
- Added support for `Length` property on `DynamicData` arrays.
- Made name mappings from PascalCase in C# to camelCase in JSON the default for `DynamicData`.
- Added implicit casts to primitives supported by `JsonElement` and explicit casts for supported reference types.

### Breaking Changes

- Made `MutableJsonDocument` and `MutableJsonElement` internal.
- Moved `ToDynamicFromJson()` extension method on `BinaryData` to the `Azure` namespace.
- Removed `DynamicJsonOptions`, `DynamicDataNameMapping` and the `BinaryData` extensions that took parameters of those types.
- Removed `DynamicDataProperty`.

## 0.1.0-preview.26 (2023-04-10)

### Features Added

- Added basic debugger support for DynamicData

### Breaking Changes

- Removed `DynamicJson` type, and moved its functionality into `DynamicData`.
- Sealed the `DynamicData` type.
- Renamed `DynamicJsonNameMapping` enum to `DynamicDataNameMapping`.
- Renamed `DynamicJsonProperty` to `DynamicDataProperty`.
- Renamed `ToDynamic()` extension method on `BinaryData` to `ToDynamicFromJson()`.
- Removed `DynamicJson.ArrayEnumerator` and `DynamicJson.ObjectEnumerator` types.
### Bugs Fixed

- Use root `DynamicJsonOptions` in child elements, arrays, and object enumerators.

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
