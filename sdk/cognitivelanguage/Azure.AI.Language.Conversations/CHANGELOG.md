# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

* Added conversation issue summarization as a long-running operation.
* Added conversation personally identifiable information (PII) extraction as a long-running operation.

### Breaking Changes

- Removed `StringIndexType` and hardcoded it to `Utf16CodeUnit`.
- Renamed `Conversation` to `ConversationInput`.
- Renamed "CustomConversation" to just "Conversation", including `AnalyzeConversationTaskKind.Conversation`, `ConversationResult`, `ConversationTaskParameters`, etc.
- Renamed `Entity` to `TextEntity`.
- Renamed `Error` to `AnalyzeError`.
- Renamed `KnowledgeBaseAnswers` to `AnswersResult`.
- Renamed "Orchestrator" to "Orchestration" including `OrchestrationPrediction`, etc.
- Renamed `Role` to `ParticipantRole`.
- Renamed `TargetKind` to `TargetProjectKind`.
- Renamed "Workflow" to "Orchestration" including `ProjectKind.Workflow`, etc.

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
