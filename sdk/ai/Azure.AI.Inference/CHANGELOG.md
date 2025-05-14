# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (2025-05-14)

### Other Changes

- Updated support for `AIInferenceExtensions` methods to consume stable SCM version.

## 1.0.0-beta.4 (2025-03-18)

### Features Added

- Added extension methods to get `ChatCompletionsClient` and `EmbeddingsClient` using [AIProjectClient](https://learn.microsoft.com/dotnet/api/azure.ai.projects.aiprojectclient?view=azure-dotnet-preview).

### Bugs Fixed

- Fixed an issue with the audio samples not properly showcasing the intended workflow.

## 1.0.0-beta.3 (2025-02-13)

### Features Added

- Added new `ImageEmbeddingsClient`, to provide support for generating embeddings with model input. See sample for more information.
- Added support for Chat Completions with audio input, for supported models.
- Added support for Chat Completions with structured output.
- Added support for providing a "Developer" message to models which support it.

### Breaking Changes

- `ChatCompletionsResponseFormatJSON` has been renamed to `ChatCompletionsResponseFormatJsonObject`.

### Bugs Fixed

- Fixed an issue where `usage` wasn't being properly included in chat responses.

## 1.0.0-beta.2 (2024-10-24)

### Features Added
- Added new `EmbeddingsClient`, to provide support for generating text embeddings using supported models.
- Add support for passing a string file path on disk in order to provide an image for chat completions.

### Breaking Changes
- `ChatCompletionsClientOptions` has been renamed to `AzureAIInferenceClientOptions`.
- `ChatCompletions` response object has been flattened. `ChatCompletions.Choices` has been removed, and the underlying properties have been bubbled up to be on the `ChatCompletions` object instead.
- `ChatCompletionsFunctionToolCall` has been replaced with `ChatCompletionsToolCall`.
- `ChatCompletionsFunctionToolDefinition` has been replaced with `ChatCompletionsToolDefinition`.
- `ChatCompletionsToolSelectionPreset` has been replaced with `ChatCompletionsToolChoicePreset`.
- `ChatCompletionsNamedFunctionToolSelection` has been replaced with `ChatCompletionsNamedToolChoice`.
- `ChatCompletionsFunctionToolSelection` has been replaced with `ChatCompletionsNamedToolChoiceFunction`.
- `StreamingChatCompletionsUpdate.AuthorName` has been removed
- Removed `extraParams` from the `complete` and `completeAsync` methods. It is now set implicitly if `additionalProperties` is provided in the options object.

### Bugs Fixed
- Fixed support for chat completions streaming while using tools.

### Other Changes
- Removed the need to manually provide an `api-key` header when talking to Azure OpenAI.

## 1.0.0-beta.1 (2024-08-06)
### Features Added
- Initial release, containing basic chat completions functionality
