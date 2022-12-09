# Release History

## 1.1.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.2 (2022-11-10)

### Features Added

- Added `ConversationsClientOptions.Audience` to set the audience to use for authentication with Azure Active Directory (AAD).
- Added methods to the `ConversationAuthoringClient` to manage deployment resources:
  - `AssignDeploymentResources` and `AssignDeploymentResourcesAsync`
  - `DeleteDeploymentFromResources` and `DeleteDeploymentFromResourcesAsync`
  - `GetAssignDeploymentResourcesStatus` and `GetAssignDeploymentResourcesStatusAsync`
  - `GetAssignedResourceDeployments` and `GetAssignedResourceDeploymentsAsync`
  - `GetDeploymentDeleteFromResourcesStatus` and `GetDeploymentDeleteFromResourcesStatusAsync`
  - `GetDeploymentResources` and `GetDeploymentResourcesAsync`
  - `GetLoadSnapshotStatus` and `GetLoadSnapshotStatusAsync`
  - `GetUnassignDeploymentResourcesStatus` and `GetUnassignDeploymentResourcesStatusAsync`
  - `LoadSnapshot` and `LoadSnapshotAsync`
  - `UnassignDeploymentResources` and `UnassignDeploymentResourcesAsync`
- Added an overload to `ConversationAuthoringClient.ExportProject` and `ExportProjectAsync` to add the `trainedModelLabel` parameter.

## 1.1.0-beta.1 (2022-07-01)

### Features Added

- Added conversation summarization and personally identifiable information (PII) extraction methods to `ConversationAnalysisClient`:
  - `AnalyzeConversation` and `AnalyzeConversationAsync`
  - `CancelAnalyzeConversationJob` and `CancelAnalyzeConversationJobAsync`
  - `GetAnalyzeConversationJobStatus` and `GetAnalyzeConversationJobStatusAsync`
- Added support for service version 2022-05-15-preview.

## 1.0.0 (2022-06-27)

### Features Added

- Added `ConversationAuthoringClient` to manage authoring projects.
- Added support for Azure Active Directory (AAD) authentication.

### Breaking Changes

- `ConversationAnalysisClient.AnalyzeConversation` and `AnalyzeConversationAsync` now take a `RequestContent` and `RequestContext` for more control and flexibility.
- Removed all models. See README.md for samples to use this client library.
- Renamed `ConversationAnalysisClientOptions` to `ConversationsClientOptions`.

## 1.0.0-beta.3 (2022-04-20)

### Breaking Changes

- Some models and model properties were renamed based on the latest 2022-03-01-preview service version that was published.

## 1.0.0-beta.2 (2022-02-08)

### Breaking Changes

- `AnalyzeConversation` method now takes instance of `ConversationsProject` instead of `ProjectName` and `DeploymentName`.
- Renamed the attribute `ConfidenceScore` to `Confidence` in the following classes:
  - `AnswerSpan`
  - `ConversationEntity`
  - `ConversationIntent`
  - `KnowledgeBaseAnswer`
  - `TargetIntentResult`

### Bugs Fixed

- Made following property public `TargetIntentResult.TargetKind` instead of internal.

### Other Changes

- Added `ConversationsProject` class for holding `ProjectName` and `DeploymentName` attributes.

## 1.0.0-beta.1 (2021-11-03)

- Initial release.
