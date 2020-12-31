# Release History

## 2.0.0 (unreleased)
### Changed
- Updated CustomVisionPredictionClient to take in a credentials class for use with different types of authentication credentials. The client now use an ApiKeyServiceClientCredentials instead of passing in an ApiKey.
- TagType is now returned in the Prediction payload.

## 1.0.0
### Changed
- PredictImage and PredictImageUrl have been replaced with project type specific calls.
	- ClassifyImage and ClassifyImageUrl for image classification projects.
        - DetectImage and DetectImageUrl for object detection projects .
- Prediction methods now take a name to designate which published iteration to use. Iterations can be published using the Custom Vision Training SDK.

## 0.12.0-preview
This is a preview release of the Cognitive Services Custom Vision Prediction SDK.
### Added
- Support customizing service endpoints.

### Changed
- Update client name to match other Cognitive services naming conventions.

## 0.10.0-preview

This is a preview release of the Cognitive Services Custom Vision Prediction SDK.