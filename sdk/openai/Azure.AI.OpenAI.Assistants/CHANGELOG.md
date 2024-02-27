# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
