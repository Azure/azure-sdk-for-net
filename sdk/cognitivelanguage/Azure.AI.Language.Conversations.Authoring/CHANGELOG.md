# Release History

## 1.0.0-beta.3 (2025-12-03)

### Features Added
- Added support for service version 2025-11-15-preview.

- Added support for service version 2025-11-01.

### Breaking Changes
- Changed parameter type from `DeleteDeploymentDetails` to `ProjectResourceIds` when calling `begin_delete_deployment_from_resources`, with property name changed from `assigned_resource_ids` to `azure_resource_ids`.

- Changed function name from `list_deployment_Resources` to `list_project_resources`, change its return type from `AssignedDeploymentResource` to `AssignedProjectResource`.

- Changed function name from `begin_assign_deployment_resources` to `begin_assign_project_resources`, and its parameter type from `AssignDeploymentResourcesDetails` to `AssignProjectResourcesDetails`.

- Changed function name from `begin_unassign_deployment_resources` to `begin_unassign_project_resources`, changed its parameter type from `UnassignDeploymentResourcesDetails` to `ProjectResourceIds`.

- Changed function name from `get_assign_deployment_resources_status` to `get_assign_project_resources_status`, change its return type from `DeploymentResourcesState` to `ProjectResourcesState`.

- Changed function name from `get_unassign_deployment_resources_status` to `get_unassign_project_resources_status`, change its return type from `DeploymentResourcesState` to `ProjectResourcesState`.

- createProjectOptions. add projectName parameter

### Other Changes
- Add samples for the following functions(sync and async):
    - list_assigned_resource_deployments
    - list_project_resources
    - delete_deployment_from_resources
    - get_deployment_delete_from_resources_status

### Bugs Fixed

- Fixed diagnostic scope names in `ConversationAuthoringProject` methods.

### Other Changes

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
  - Assign Deployment Resources
  - Get Assign Deployment Resources Status
  - Unassign Deployment Resources
  - Get Unassign Deployment Resources Status

## 1.0.0-beta.1 (2025-03-04)

### Other Changes

- Initial release of Azure.AI.Language.Conversations.Authoring library.
