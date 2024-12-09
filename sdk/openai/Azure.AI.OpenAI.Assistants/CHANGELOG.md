# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2024-04-30)

This small, out-of-band version addresses a couple of critical blocking bugs. To use the latest service features, including streaming support and the Assistants v2 API, migrate to the [Azure.AI.OpenAI package](https://www.nuget.org/packages/Azure.AI.OpenAI).

### Bugs Fixed

- Several issues with direct equality comparisons of function tool definitions have been fixed
- The mistaken, remain instance of an "Azure not supported" exception has been removed, along with its related
  mentions. This should unblock the use of the the token-based client constructor.

## 1.0.0-beta.3 (2024-03-06)

This update includes a fix for assistant-generated files as represented on messages along with an overdue README update reflecting the release status of Azure OpenAI Assistants support.

### Bugs Fixed

- Incorporates a specification fix for message image file content that caused generated image file IDs (e.g. from the Code Interpreter tool) to not properly appear in messages

## 1.0.0-beta.2 (2024-02-05)

This small release fixes a bug with function tools that use arguments.

### Breaking Changes

- Addressing a related bug, `RequiredFunctionToolCall` has a property replacement:
  - REMOVED: `Parameters` of type `BinaryData`
  - ADDED: `Arguments` of type `string`
- For improved clarity, several types specific to the representation of tool call information in run steps have been renamed with a `RunStep` prefix, better differentiating from request-time tool definitions and model-provided required tool calls:
  - `ToolCall` is now `RunStepToolCall`
  - `FunctionToolCall` is now `RunStepFunctionToolCall`
  - `CodeInterpreterToolCall` is now `RunStepCodeInterpreterToolCall`
    - `CodeInterpreterToolCallOutput` is now `RunStepCodeInterpreterToolCallOutput`
    - `CodeInterpreterLogOutput` is now `RunStepCodeInterpreterToolCallOutput`
    - `CodeInterpreterImageOutput` is now `RunStepCodeInterpreterImageOutput`
    - `CodeInterpreterImageReference` is now `RunStepCodeInterpreterImageReference`
  - `RetrievalToolCall` is now `RunStepRetrievalToolCall`

### Bugs Fixed

- Function calls initiated by the model (when a run enters a RequiresAction status involving function tools) will now provide the intended JSON `Arguments` string corresponding to the earlier `FunctionDefinition`'s `Parameters`. The latter `Parameters` was previously reused within the required action flow, effectively ignoring the proper `Arguments`.

## 1.0.0-beta.1 (2024-02-01)

### Features Added

- This is the initial release of `Azure.AI.OpenAI.Assistants`.
- Full support for OpenAI's beta Assistants features is included; see OpenAI's documentation for more: https://platform.openai.com/docs/assistants/overview
- [Azure OpenAI](https://learn.microsoft.com/azure/ai-services/openai/overview) does not yet feature an `/assistants` endpoint and this library will thus currently only work with the `api.openapi.com` endpoint. Stay tuned!
