# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Fixed diagnostic scope names in `TextAuthoringProject` and `TextAuthoringTrainedModel` methods.

### Other Changes

## 1.0.0-beta.2 (2025-07-24)

### Features Added

- Added import feature for raw json string.
- Added support for Custom Text Authoring API Versions
  - 2025-05-15-preview

### Bugs Fixed

- Merged TextAuthoringUnassignDeploymentResourcesState and TextAuthoringAssignDeploymentResourcesState into one class TextAuthoringDeploymentResourcesState
- Fixed "azureOpenAI" to "AzureOpenAI" for DataGenerationConnectionInfoKind

### Other Changes

- Added tests and samples for some legacy features.
  - Get Deployment
  - Assign Deployment Resources
  - Get Assign Deployment Resources Status
  - Unassign Deployment Resources
  - Get Unassign Deployment Resources Status

## 1.0.0-beta.1 (2025-03-04)

### Other Changes

- Initial release of Azure.AI.Language.Text.Authoring library.
