# Release History

## 1.2.0-beta.4 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.3 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-09-29)

### Features Added

- Upgraded api-version tag from 'package-2022-10' to 'package-preview-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/3eb9ec8e9c8f717c6b461c4c0f49a4662fb948fd/specification/machinelearningservices/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.32.0 to 1.35.0
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0

## 1.2.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.1 (2023-05-05)

### Bugs Fixed

- Fixed [the issue](https://github.com/Azure/azure-sdk-for-net/issues/35000) that after introduced options bag, the operation behaves differently and always put an empty array into the query parameters.

## 1.1.0 (2023-02-16)

### Features Added

- Introduced property bag for the methods with more than 5 parameters.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2023-01-16)

### Breaking Changes

- Various renaming of resources and models to polish the API.

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

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
