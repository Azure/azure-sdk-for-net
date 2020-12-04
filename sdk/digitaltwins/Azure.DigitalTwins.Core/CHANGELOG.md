# Release History

## 1.3.0-beta.1 (Unreleased)


## 1.2.0 (2020-11-16)

### New Features

- Added `DigitalTwinsModelFactory` to allow for the creation of certain model objects to enable mocking them for unit tests.

### Breaking changes

- None

### Fixes and improvements

- None

## 1.0.1 (2020-11-04)

### Fixes and improvements

- Improved deserialization and error reporting for `BasicDigitalTwin` for `DigitalTwinMetadata`.
- Removed logic to determine authorization scope based on digital twins instance URI.

## 1.0.0 (2020-10-30)

### New Features

- Regenerated protocol layer from service API version 2020-10-31.
- Updated service API version to use service API version 2020-10-31 by default.

### Breaking changes

Note that these breaking changes are only breaking changes from the **preview** version of this library.

- Replaced all `Response<string>` and `Pageable<string>` APIs with `Response<T>` and `Pageable<T>` respectively.
- Renamed `CreateDigitalTwin`, `CreateRelationship` and `CreateEventRoute` APIs to `CreateOrReplaceDigitalTwin`, `CreateOrReplaceRelationship` and `CreateOrReplaceEventRoute` respectively.
- Renamed model type `ModelData` to `DigitalTwinsModelData` to make type less generic, and less likely to conflict with other libraries.
- Renamed model type `EventRoute` to `DigitalTwinsEventRoute` to make type less generic, and less likely to conflict with other libraries.
- `EventRoute` (now `DigitalTwinsEventRoute`) object ctor now requires filter.
- Removed `UpdateOperationsUtility` and replace it with a direct dependency on [JsonPatchDocument](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/JsonPatchDocument.cs) from Azure.Core.
- Removed `WritableProperty` since service no longer returns that type.
- Removed `MaxItemCount` parameter as an option for `GetEventRoutes` APIs since users are expected to provide page size in pageable type's .AsPages() method instead.
- Removed Serialization namespace, moving its contents to the base Azure.DigitalTwins.Core namespace.
- Renamed `DigitalTwinsModelData` field `DisplayName` to `LanguageDisplayNames` for clarity.
- Renamed `DigitalTwinsModelData` field `Description` to `LanguageDescriptions` for clarity.
- Renamed `DigitalTwinsModelData` field `model` to `dtdlModel`.
- Flattened `DigitalTwinsRequestOptions` so that each API takes in `ifMatch` and `ifNoneMatch` header directly.
- Reworked `BasicDigitalTwin` and other helper classes to better match the service definitions. This includes renaming `CustomProperties` to `Contents`.
- Added `messageId` as mandatory parameter for telemetry APIs. Service API version 2020-10-31 requires this parameter.
- Renamed `CreateModels` API parameter `models` to `dtdtlModels` for clarity.
- Reworked `GetModels` APIs to take options bundle rather than take individual options.

### Fixes and improvements

- Fixed bug where `CreateDigitalTwin` and `CreateRelationship` APIs always sent ifNoneMatch header with value "*" making it impossible to replace an existing entity.
- Fixed authentication scope for ADT instances that don't match the public cloud domain name pattern.

## 1.0.0-preview.3 (2020-07-13)

### Breaking changes

- Type definitions in Azure.DigitalTwins.Core.Models namespace moved to Azure.DigitalTwins.Core.
- `CreateModelsAsync` and `CreateModels` APIs now return `Response<ModelData[]>` instead of `Response<IReadOnlyList<ModelData>>`.

## 1.0.0-preview.2

### New features

- Official public preview of [Azure.DigitalTwins.Core SDK](https://www.nuget.org/packages/Azure.DigitalTwins.Core)
- [Azure Digital Twins Public Repo](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core)
- [Azure Digital Twins Samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples)

## 1.0.0-preview.1 (Unreleased)

### New features

- Initial preview of Azure.DigitalTwins.Core SDK

### Breaking changes

- N/A

### Added

- N/A

### Fixes and improvements

- N/A
