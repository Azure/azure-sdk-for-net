# Release History

## 1.0.0-beta.2 (2024-10-22)

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

### Bugs Fixed
- Fixed support for chat completions streaming while using tools.

### Other Changes
- Removed the need to manually provide an `api-key` header when talking to Azure OpenAI.

## 1.0.0-beta.1 (2024-08-06)
### Features Added
- Initial release, containing basic chat completions functionality
