# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

* Only supported service version now 2022-05-01.

### Breaking Changes

* Removed support for service versions 2021-11-01-preview and 2022-03-01-preview.
* Renamed "CustomConversation" to just "Conversation", including `AnalyzeConversationTaskKind.Conversation`, `ConversationResult`, `ConversationTaskParameters`, etc.
* Renamed `KnowledgeBaseAnswers` to `AnswersResult`.
* Renamed "Orchestrator" to "Orchestration" including `OrchestrationPrediction`, etc.
* Renamed `TargetKind` to `TargetProjectKind`.
* Renamed "Workflow" to "Orchestration" including `ProjectKind.Workflow`, etc.

### Bugs Fixed

### Other Changes

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
