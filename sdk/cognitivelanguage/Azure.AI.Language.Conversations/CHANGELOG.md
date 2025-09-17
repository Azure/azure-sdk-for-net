# Release History

## 2.0.0-beta.4 (2025-09-18)

### Breaking Changes

- removed `AIConversation` and `ConversationalAIItem`, and reuse `TextConversation` and `TextConversationItem` for AI Conversation Analyze feature.

## 2.0.0-beta.3 (2025-06-23)

### Features Added

- Added AI Conversation Analyze feature
- Added support for analyze-conversation API Versions
  - 2025-05-15-preview

## 2.0.0-beta.2 (2025-02-03)

### Features Added

- Added three differenct type of Redaction Policy `CharacterMaskPolicyType`, `EntityMaskTypePolicyType` and `NoMaskPolicyType` for the function `AnalyzeConversations`  
- Added support for analyze-conversation API Versions
  - 2024-11-01
  - 2024-11-15-preview

### Other Changes

- Changed property `CreditCardNumberValue` to `CreditCardValue` and `PhoneNumberValue` to `PhoneValue` for class `ConversationPiiCategoryExclusions`
- Added a new `Instruction` property to class `ConversationSummarizationActionContent`

## 2.0.0-beta.1 (2024-08-01)

- Added support for service version 2024-05-01.
- Added support for service version 2024-05-15-preview.

### Features Added
- Added classes to represent all the models in the service definition.

### Breaking Changes
- Deprecated `ConversationAuthoringClient`.

## 1.1.0 (2023-06-13)

### Features Added

- Added support for service version 2023-04-01.

### Breaking Changes

The following changes are only breaking from the previous beta. They are not breaking since version 1.0.0 when those types and members did not exist.

- Removed support for service version 2022-05-15-preview.
- Removed support for service version 2022-10-01-preview.
- Removed support for "ConversationalPIITask" analysis.
- Removed support for "ConversationalSentimentTask" analysis.
- Removed `ConversationsAudience`.
- Removed `ConversationsClientOptions.Audience`.
- Removed `ConversationAuthoringClient.AssignDeploymentResources` and `AssignDeploymentResourcesAsync`.
- Removed `ConversationAuthoringClient.DeleteDeploymentFromResources` and `DeleteDeploymentFromResourcesAsync`.
- Removed `ConversationAuthoringClient.GetAssignDeploymentResourcesStatus` and `GetAssignDeploymentResourcesStatusAsync`.
- Removed `ConversationAuthoringClient.GetAssignedResourceDeployments` and `GetAssignedResourceDeploymentsAsync`.
- Removed `ConversationAuthoringClient.GetDeploymentDeleteFromResourcesStatus` and `GetDeploymentDeleteFromResourcesStatusAsync`.
- Removed `ConversationAuthoringClient.GetDeploymentResources` and `GetDeploymentResourcesAsync`.
- Removed `ConversationAuthoringClient.GetUnassignDeploymentResourcesStatus` and `GetUnassignDeploymentResourcesStatusAsync`.
- Removed `ConversationAuthoringClient.UnassignDeploymentResources` and `UnassignDeploymentResourcesAsync`.
- Renamed `ConversationAnalysisClient.AnalyzeConversation` and `AnalyzeConversationAsync` that took a `WaitUntil` parameter to `AnalyzeConversations` and `AnalyzeConversationsAsync`.
- Renamed `ConversationAnalysisClient.CancelAnalyzeConversationJob` and `CancelAnalyzeConversationJobAsync` to `CancelAnalyzeConversations` and `CancelAnalyzeConversationsAsync`.
- Renamed `ConversationAuthoringClient.GetLoadSnapshotStatus` and `GetLoadSnapshotStatusAsync` to `GetLoadSnapshotJobStatus` and `GetLoadSnapshotJobStatusAsync`.

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
