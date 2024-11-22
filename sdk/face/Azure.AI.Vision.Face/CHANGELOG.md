# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2024-10-23)

- Added support for the Large Face List and Large Person Group:
  - Added client `LargeFaceListClient` and `LargePersonGroupClient`.
  - Added operations `FindSimilarFromLargeFaceList`, `IdentifyFromLargePersonGroup` and `VerifyFromLargePersonGroup` to `FaceClient`.
  - Added models for supporting Large Face List and Large Person Group.
- Added support for latest Detect Liveness Session API:
  - Added operations `GetSessionImage` and `DetectFromSessionImage` to `FaceSessionClient`.
  - Added properties `EnableSessionImage ` and `LivenessSingleModalModel` to model `CreateLivenessSessionContent`.
  - Added model `CreateLivenessWithVerifySessionContent`.

### Breaking Changes

- Changed the parameter of `CreateLivenessWithVerifySession` from model `CreateLivenessSessionContent` to `CreateLivenessWithVerifySessionContent`.

### Bugs Fixed

- Remove `Mask` from `FaceAsttributes.Detection01`, which is not supported.

### Other Changes

- Change the default service API version to `v1.2-preview.1`.

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
