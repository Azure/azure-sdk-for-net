# Release History

## 2.1.0-beta.2 (Unreleased)

### Features Added
- Added `ResponsesToolboxSearchPreviewTool` for discovering deferred tools via `search_tools` queries at runtime.
- Added `Name` and `Description` properties to Responses tool classes.

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

### Bugs Fixed

### Other Changes

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
