# Release History

## 2.1.0-preview (2020-11-10)
### Added
- Added support to train a new iteration using another iteration as the starting point.
- Added more information about exportable models.

## 2.0.0
### Added
- Added support to import and export projects.
- Added support to train on a subset of training tags.
- Added support to add, update, and retrieve metadata (key/value string pairs) on images
- Added support for VNET scenarios to securely retrieve artifacts by calling GetArtifact

### Changed
- Updated CustomVisionTrainingClient to take in a credentials class for use with different types of authentication credentials. The client now use an ApiKeyServiceClientCredentials instead of passing in an ApiKey.

## 1.0.0
### Added
- Advanced training option to set a budget to train longer for improved iteration performance.
- Additional export options targetting Vision AI Dev Kit and Docker ARM for Raspberry Pi.

## 0.13.0-preview
### Added
- Added ONNX 1.2 as an export option
- Added negative tag support.

### Changed
- The API client name was changed from TrainingAPI to CustomVisionTrainingClient, in keeping with other Azure SDKs.
- The way the Azure region is specfied has changed.  Specifically, the AzureRegion property was dropped in favor of an Endpoint property.  If you were previously specifying an AzureRegion value, you should now specify Endpoint='https://{AzureRegion}.api.cognitive.microsoft.com' instead. This change ensures better global coverage.

## 0.12.0-preview
### Added
- Support customizing service endpoints.

## 0.10.0-preview
This is a preview release of the Cognitive Services Custom Vision Training SDK.
