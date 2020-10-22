# Release History

## 1.0.0 (Unreleased)

- Regenerate protocol layer from service API version 2020-10-31
- Update service API version to use service API version 2020-10-31 by default
- Add optional parameters for TraceParent and TraceState to all service request APIs to support distributed tracing
- Renamed model type "ModelData" to "DigitalTwinsModelData" to make type less generic, and less likely to conflict with other libraries
- Renamed model type "RequestOptions" to "DigitalTwinsRequestOptions" to make type less generic, and less likely to conflict with other libraries

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
