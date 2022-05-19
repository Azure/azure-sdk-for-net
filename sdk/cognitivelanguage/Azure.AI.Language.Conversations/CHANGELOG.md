# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added
* Async conversation issue summarization task
* Async conversation PII extraction task

### Breaking Changes
- `Results` in `customConversationalTaskResult` changed to `Result`.
- `TargetKind` enum changed to `TargetProjectKind`.
- `CustomConversation` in `TargetProjectKind` changed to `Conversation`.

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
