# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2025-12-05)

### Features Added
- Added support for service version 2025-11-15-preview.

- Added support for service version 2025-11-01.

### Breaking Changes
- Changed parameter type from `ConversationAuthoringDeleteDeploymentDetails` to `ConversationAuthoringProjectResourceIds` when calling `DeleteDeploymentFromResources`, with property name changed from `AssignedResourceIds` to `AzureResourceIds`.

- Changed function name from `GetDeploymentResources` to `GetProjectResources`, change its return type from `ConversationAuthoringAssignedDeploymentResource` to `ConversationAuthoringAssignedProjectResource`.

- Changed function name from `AssignDeploymentResources` to `AssignProjectResources`, and its parameter type from `ConversationAuthoringAssignDeploymentResourcesDetails` to `ConversationAuthoringAssignProjectResourcesDetails`.

- Changed function name from `UnassignDeploymentResources` to `UnassignProjectResources`, changed its parameter type from `ConversationAuthoringUnassignDeploymentResourcesDetails` to `ConversationAuthoringProjectResourceIds`.

- Changed function name from `GetAssignDeploymentResourcesStatus` to `GetAssignProjectResourcesStatus`, change its return type from `ConversationAuthoringDeploymentResourcesState` to `ConversationAuthoringProjectResourcesState`.

- Changed function name from `GetUnassignDeploymentResourcesStatus` to `GetUnassignProjectResourcesStatus`, change its return type from `ConversationAuthoringDeploymentResourcesState` to `ConversationAuthoringProjectResourcesState`.

- For function `CreateProject`, include `projectName` when constructing `ConversationAuthoringCreateProjectDetails`.

### Other Changes
- Add samples for the following functions(sync and async):
    - ListAssignedResourceDeployments
    - ListProjectResources
    - DeleteDeploymentFromResources
    - GetDeploymentDeleteFromResourcesStatus

### Bugs Fixed

- Fixed diagnostic scope names in `ConversationAuthoringProject` methods.

## 1.0.0-beta.2 (2025-07-24)

### Features Added

- Added import feature for raw json string.
- Added support for Conversations Authoring API Versions
  - 2025-05-15-preview
- Added `DataGenerationSettings` in `TrainingJobDetails` when training a model.
  - Added corresponding test and sample.
- Added `DataGenerationConnectionInfo` in `DeploymentResource` when deploying a model.
  - Added corresponding test and sample.
- Added `ExportedAssociatedEntityLabel` in `ConversationExportedIntent` when importing a project.
  - Added corresponding test and sample.

### Other Changes

- Added tests and samples for some legacy features.
  - Get Deployment
  - Assign Project Resources
  - Get Assign Project Resources Status
  - Unassign Project Resources
  - Get Unassign Project Resources Status

## 1.0.0-beta.1 (2025-03-04)

### Other Changes

- Initial release of Azure.AI.Language.Conversations.Authoring library.
