# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-10-18)

### Other Changes
Stable release.

## 1.0.0-beta.3 (2024-06-15)

### Features Added
Add TokenCredential support and associated test case.

## 1.0.0-beta.2 (2024-02-14)

### Breaking Changes
The imageContent parameter for the Analyze(BinaryData imageData, ...) method has been renamed to imageData.
The imageContent parameter for the Analyze(Uri imageUri, ...) method has been renamed to imageUri

## 1.0.0-beta.1 (2024-01-09)

Initial release of Image Analysis SDK. Uses the generally available [Computer Vision REST API (2023-10-01)](https://eastus.dev.cognitive.microsoft.com/docs/services/Cognitive_Services_Unified_Vision_API_2023-10-01). Starting with this version, the client library is auto-generated (with some hand customization) from TypeSpec files, to better align with other Azure client libraries.

### Breaking Changes

A previous version of the Image Analysis client library (version 0.15.1-beta.1) used a preview version of the Computer Vision REST API, and was coded by hand. With this new version, all APIs have changed. Please see documentation on how to use the new APIs.
- Image Analysis with a custom model is no longer supported by the client library, as Computer Vision REST API (2023-10-01) does not yet support it. To do Image Analysis with a custom model, write code to call the `Analyze` operation on [Computer Vision REST API (2023-04-01-preview)](https://eastus.dev.cognitive.microsoft.com/docs/services/unified-vision-apis-public-preview-2023-04-01-preview/operations/61d65934cd35050c20f73ab6).
- Image Segmentation (background removal) is no longer supported by the client library, as Computer Vision REST API (2023-10-01) does not yet support it. To do Image Segmentation, write code to call the `Segment` operation on [Computer Vision REST API (2023-04-01-preview)](https://eastus.dev.cognitive.microsoft.com/docs/services/unified-vision-apis-public-preview-2023-04-01-preview/operations/63e6b6d9217d201194bbecbd).

