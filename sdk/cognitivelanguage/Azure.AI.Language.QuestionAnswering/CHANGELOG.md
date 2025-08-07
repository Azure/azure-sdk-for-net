# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

- Renamed `projectName` and `deploymentName` tags reported on `QuestionAnsweringClient` activities to `az.cognitivelanguage.project.name` and `az.cognitivelanguage.deployment.name` following OpenTelemetry attribute naming conventions.

### Bugs Fixed

### Other Changes

## 1.1.0 (2022-10-13)

### Breaking Changes

- Renamed the `QuestionAnsweringProjectsClient` to `QuestionAnsweringAuthoringClient` and moved it to the `Azure.AI.Language.QuestionAnswering.Authoring` namespace.
- Changed method return types of `QuestionAnsweringAuthoringClient.UpdateQnas` and `UpdateQnasAsync` to return an `Operation<Pageable<BinaryData>>` and `Operation<AsyncPageable<BinaryData>>` respectively.
- Changed method return types of `QuestionAnsweringAuthoringClient.UpdateSources` and `UpdateSourcesAsync` to return an `Operation<Pageable<BinaryData>>` and `Operation<AsyncPageable<BinaryData>>` respectively.
- Changed return type of `QuestionAnsweringAuthoringClient.DeleteProject` and `DeleteProjectAsync` from `Operation<BinaryData>` to just `Operation`.

## 1.1.0-beta.2 (2022-07-19)

### Features Added

- Added support for Azure Active Directory (AAD) authentication.

## 1.1.0-beta.1 (2022-02-08)

### Features Added

- Added the `QuestionAnsweringProjectsClient` to manage Question Answering projects.

## 1.0.0 (2021-11-03)

This version of the client library targets service version `2021-10-01`.

### Breaking Changes

- Preview service versions `2021-05-01-preview` and 2021-07-15-preview` were removed.
- Moved all models from `Azure.AI.Language.QuestionAnswering.Models` to `Azure.AI.Language.QuestionAnswering`.
- Renamed method `QuestionAnsweringClient.QueryKnowledgeBase` to `GetAnswers`.
- Renamed method `QuestionAnsweringClient.QueryKnowledgeBaseAsync` to `GetAnswersAsync`.
- Methods `GetAnswers` and `GetAnswersAsync` now accept a question string or QnA ID, a `QuestionAnsweringProject`, and optional `AnswersOptions` parameters.
- Moved parameters `projectName` and `deploymentName` to the new `QuestionAnsweringProject` class.
- Renamed class `QueryKnowledgeBaseOptions` to `AnswersOptions`.
- Renamed property `QueryKnowledgeBaseOptions.AnswerSpanRequest` to `AnswersOptions.ShortAnswerOptions`.
- Renamed property `QueryKnowledgeBaseOptions.ConfidenceScoreThreshold` to `AnswersOptions.ConfidenceThreshold`.
- Renamed property `QueryKnowledgeBaseOptions.Context` to `AnswersOptions.AnswerContext`.
- Renamed property `QueryKnowledgeBaseOptions.RankerType` to `AnswersOptions.RankerKind`.
- Renamed property `QueryKnowledgeBaseOptions.Top` to `AnswersOptions.Size`.
- Renamed method `QuestionAnsweringClient.QueryText` to `GetAnswersFromText`.
- Renamed method `QuestionAnsweringClient.QueryTextAsync` to `GetAnswersFromTextAsync`.
- Renamed class `QueryTextOptions` to `AnswersFromTextOptions`.
- Renamed property `QueryTextOptions.Records` to `AnswersFromTextOptions.TextDocuments`.
- Renamed class `TextRecord` to `TextDocument`.
- Renamed class `AnswerSpanRequest` to `ShortAnswerOptions`.
- Renamed property `AnswerSpanRequest.ConfidenceScoreThreshold` to `ShortAnswerOptions.ConfidenceThreshold`.
- Renamed property `AnswerSpanRequest.TopAnswersWithSpan` to `ShortAnswersOptions.Size`.
- Renamed class `KnowledgeBaseAnswerRequestContext` to `KnowledgeBaseAnswerContext`.
- Renamed property `KnowledgeBaseAnswerRequestContext.PreviousUserQuery` to `KnowledgeBaseAnswerContext.PreviousQuestion`.
- Renamed class `KnowledgeBaseAnswers` to `AnswersResult`.
- Renamed class `TextAnswers` to `AnswersFromTextResult`.
- Renamed property `KnowledgeBaseAnswer.AnswerSpan` to `KnowledgeBaseAnswer.ShortAnswer`.
- Renamed property `KnowledgeBaseAnswer.ConfidenceScore` to `KnowledgeBaseAnswer.Confidence`.
- Renamed property `KnowledgeBaseAnswer.Id` to `KnowledgeBaseAnswer.QnaId`.
- Renamed property `AnswerSpan.ConfidenceScore` has been renamed to `AnswerSpan.Confidence`.
- Renamed property `TextAnswer.ConfidenceScore` has been renamed to `TextAnswer.confidence`.
- Renamed property `TextAnswer.AnswerSpan` has been renamed to T`extAnswer.ShortAnswer`.
- Removed class `StringIndexType`. Hard-coded to "Utf16CodeUnit" for .NET.

## 1.0.0-beta.2 (2021-10-06)

### Features Added

- Added support for API version 2021-07-15-preview.
- Added `QuestionAnsweringClientOptions.DefaultLanguage` to specify a client default, and the `language` parameters of `QueryTextOptions` optional.

### Breaking Changes

- Changed `StrictFilters` to `QueryFilters` which now contains a list of `MetadataRecord` - key-value pairs that allow for referencing the same key numerous times in a filter similar to, for example, "food = 'fruit' OR food = 'vegetable'".
- Made `projectName` and `deploymentName` parameters required for `QuestionAnsweringClient` methods.
- Moved `QueryKnowledgeBaseOptions`, `QueryTextOptions`, and `TextRecord` to `Azure.AI.Language.QuestionAnswering` namespace.
- Removed `QueryTextOptions.StringIndexType` property and will always pass `StringIndexType.Utf16CodeUnit` for .NET.
- Renamed "CompoundOperation" to "LogicalOperation" in properties and type names.
- Renamed `QuestionKnowledgeBaseOptions.StrictFilters` to `Filters` and changed type to `QueryFilters`.

## 1.0.0-beta.1 (2021-07-27)

- Initial release which supports querying of knowledge bases and text records.
