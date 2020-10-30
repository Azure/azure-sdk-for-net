# Release History

## 1.0.0 (Unreleased)

### New Features

- Regenerate protocol layer from service API version 2020-10-31
- Update service API version to use service API version 2020-10-31 by default


### Breaking changes

- Replace all Response<string> and Pageable<string> APIs with Response<T> and Pageable<T> respectively
- Rename CreateDigitalTwin, CreateRelationship and CreateEventRoute APIs to CreateOrReplaceDigitalTwin, CreateOrReplaceRelationship and CreateOrReplaceEventRoute respectively
- Renamed model type "ModelData" to "DigitalTwinsModelData" to make type less generic, and less likely to conflict with other libraries
- Renamed model type "EventRoute" to "DigitalTwinsEventRoute" to make type less generic, and less likely to conflict with other libraries
- Remove UpdateOperationsUtility and replace it with a direct dependency on JsonPatchDocument from Azure.Core
- Remove WritableProperty since service no longer returns that type
- Remove MaxItemCount parameter as an option for GetEventRoutes APIs since users are expected to provide page size in pageable type's .AsPages() method instead
- Rename DigitalTwinsModelData field "DisplayName" to "LanguageDisplayNames" for clarity
- Rename DigitalTwinsModelData field "Description" to "LanguageDescriptions" for clarity
- Flatten DigitalTwinsRequestOptions so that each API takes in ifMatch and ifNoneMatch header directly
- Rework BasicDigitalTwin and other helper classes to better match the service definitions
- Add messageId as mandatory parameter for telemetry APIs. Service API version 2020-10-31 requires this parameter.

### Fixes and improvements
- Fix bug where CreateDigitalTwin and CreateRelationship APIs always sent ifNoneMatch header with value "*" making it impossible to replace an existing entity


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
