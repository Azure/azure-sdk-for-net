# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2022-07-12)

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

- Resource/Collection/Data `DataVersionBaseResource` `DataVersionBaseCollection` and `DataVersionBaseData` renamed to `DataVersionResource` `DataVersionCollection` and `DataVersionData`.
- Base type of `MachineLearningComputeData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `MachineLearningPrivateEndpointConnectionData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `MachineLearningWorkspaceData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `MachineLearningPrivateLinkResource` changed to `Azure.ResourceManager.Models.TrackedResourceData`.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.1 (2022-05-25)

### General New Features

- Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
- HTTP pipeline with custom policies
- Better error-handling
- Support uniform telemetry across all languages

Azure management client SDK for Azure resource provider MachineLearningServices.
This is the first beta preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).
