# Release History

## 2.1.0-beta.4 (Unreleased)

### Features Added
- Added `ProjectOAIResponsesClientOptions`, a new options type for `ProjectResponsesClient` that derives from `OpenAI.Responses.ResponsesClientOptions`. This aligns with the upstream OpenAI client option hierarchy after `ResponsesClientOptions` was split out as a sibling of `OpenAIClientOptions`.
- Added an implicit conversion from `ProjectOpenAIClientOptions` to `ProjectOAIResponsesClientOptions` that copies all public configuration (endpoint, organization/project IDs, user-agent application ID, pipeline/retry/logging/transport settings, network timeout, distributed tracing flag, `ApiVersion`, and `AgentName`).
- Added new `ProjectResponsesClient` constructors that accept `ProjectOAIResponsesClientOptions`, including parameterless-options overloads so `new ProjectResponsesClient(projectEndpoint, tokenProvider)` resolves to a visible constructor without requiring an options argument.

### Breaking Changes

### Bugs Fixed

### Other Changes
- Updated the `OpenAI` package dependency to `2.11.0`. This release reshapes `OpenAI.Responses.ResponsesClientOptions` to derive directly from `System.ClientModel.Primitives.ClientPipelineOptions` (a sibling of `OpenAI.OpenAIClientOptions` rather than a subclass), which motivated the new `ProjectOAIResponsesClientOptions` type above.
- The legacy `ProjectResponsesClientOptions` type and the `ProjectResponsesClient` constructors that take it are retained for binary compatibility but are now hidden from IntelliSense via `[EditorBrowsable(EditorBrowsableState.Never)]`. New code should prefer `ProjectOAIResponsesClientOptions`.

## 2.1.0-beta.3 (2026-05-29)

### Breaking Changes
- **Breaking changes since version 2.0.0** `MemorySearchToolCallResponseItem` was replaced by `MemorySearchToolCall`, `MemoryCommandToolCall` and `MemoryCommandToolCallOutput`.
- **Breaking changes since version 2.0.0** `MemoryToolSearchItem` was removed, because it is not used anymore.

### Sample Updates
- Added a sample for Fabric IQ Tool (preview).
- Added a sample for Work IQ Tool (preview).

## 2.1.0-beta.2 (2026-05-14)

### Features Added
- Added `ResponsesToolboxSearchPreviewTool` for discovering deferred tools via `search_tools` queries at runtime.
- Added `Name` and `Description` properties to Responses tool classes.
- Added new method `GetProjectResponsesClientForAgentEndpoint` on the `ProjectOpenAIClient`.

### Breaking Changes
- `ComputerScreenshotImage` property `ImageUrl` was renamed to `ImageUri`.
- `ResponsesAutoCodeInterpreterToolParam` property `Type` was renamed to `Kind`.
- `ResponsesAzureAISearchTool` property `AzureAiSearch` was renamed to `AzureAISearch`.
- `ResponsesAzureFunctionBinding` property `Type` was renamed to `Kind`.
- `ResponsesBingGroundingSearchConfiguration` property `SetLang` was renamed to `Language`.
- `ResponsesCustomToolParam` property `DeferLoading` was renamed to `ShouldDeferLoading`.
- `ResponsesFunctionToolParam` property `DeferLoading` was renamed to `ShouldDeferLoading`.
- `ResponsesFunctionToolParam` property `Strict` was renamed to `IsStrict`.
- `ResponsesFunctionCallOutputStatusEnum` was renamed to `ResponsesFunctionCallOutputStatus`.
- `ResponsesMCPToolFilter` property `ReadOnly` was renamed to `IsReadOnly`.
- `ResponsesMemorySearchPreviewTool` property `UpdateDelay` was renamed to `UpdateDelayInSeconds`.
- `ResponsesOpenApiFunctionDefinition` property `Spec` was renamed to `Specification`.
- `ResponsesOpenApiTool` property `Openapi` was renamed to `OpenApi`.
- `ResponsesStructuredOutputDefinition` property `Strict` was renamed to `IsStrict`.
- `ResponsesWebSearchApproximateLocation` property `Type` was renamed to `Kind`.

## 2.1.0-beta.1 (2026-04-21)

### Features Added
- The sample for Hosted agent was updated.

## 2.0.0 (2026-03-31)

### Breaking Changes
- The `StructuredInputs` property was removed from `CreateResponseOptions`.
- `Conversations` property was replaced by `GetProjectConversationsClient()` method.
- `Responses` property was replaced by `GetProjectResponsesClient()` method.
- `Files` property was replaced by `GetProjectFilesClient()` method.
- `VectorStores` property was replaced by `GetProjectVectorStoresClient()` method.

## 2.0.0-beta.1 (2026-03-12)

### Features Added
This is the first release of the `Azure.AI.Extensions.OpenAI` library, a new extension package for the official `OpenAI` .NET library that facilitates and simplifies use of Microsoft Foundry extensions to OpenAI APIs. This package replaces the `Azure.AI.Projects.OpenAI` package. All features, related to `Agents` management were moved to `Azure.AI.Projects.Agents`.

### Breaking Changes
* The Agents tools were moved to the `Azure.AI.Projects.Agents` package.
* `GetProjectResponsesClientForAgent` cannot be used with `AgentDefinition` and `AgentRecord` as these classes are the part of the `Azure.AI.Projects.Agents` package.
