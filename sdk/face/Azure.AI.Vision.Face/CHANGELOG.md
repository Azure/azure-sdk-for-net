# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2024-05-27)

This is the first preview Azure AI Face client library that follows the [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).
This library replaces the package [Microsoft.Azure.CognitiveServices.Vision.Face](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.Face).

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/samples/README.md) demonstrate the new API.

- This library supports only the Azure AI Face v1.1-preview.1 API.
- The namespace/package name for Azure AI Face has changed from `Microsoft.Azure.CognitiveServices.Vision.Face` to `Azure.AI.Vision.Face`.
- Three client design:
  - `FaceClient` to perform core Face functions such as face detection, verification, finding similar faces and grouping faces.
  - `FaceSessionClient` to interact with sessions which is used for Liveness detection.

### Features Added

- Added support for Liveness detection.
