# Release History

## 1.2.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fix issue with image block serialization in async scenarios [issue](https://github.com/Azure/azure-sdk-for-net/issues/52671)

### Other Changes

## 1.2.0-beta.5 (2025-09-18)

### Bugs Fixed
- Fix issue with image block serialization [issue](https://github.com/Azure/azure-sdk-for-net/issues/52571)

## 1.2.0-beta.4 (2025-09-05)

### Features Added
- Updated `Microsoft.Extensions.AI.Abstractions` dependency to version 9.8.0.
- Added support of `FileSearchTool` and `CodeInterpreterTool` for `PersistentAgentsChatClient`.
- Make `Azure.AI.Agents.Persistent` compatible with [ahead-of-time compilation process (AOT)](https://learn.microsoft.com/aspnet/core/fundamentals/native-aot).
- Improved the way `RequireApproval` is being set. See the [issue](https://github.com/Azure/azure-sdk-for-net/issues/52213).

### Bugs Fixed
- Fix issues related to `ResponseFormat` when using `PersistentAgentsChatClient` with Structured Outputs.
- Fix handling of streaming update of unexpected type [issue](https://github.com/Azure/azure-sdk-for-net/issues/52407).

## 1.2.0-beta.3 (2025-08-22)

### Features Added
- Added delete operation for `ThreadMessages`.
- Add `RunStepDeltaCustomBingGroundingToolCall`, describing `BingCustomSearchTool` updates in streaming scenario.
- Add `RunStepDeltaMicrosoftFabricToolCall`, describing `FabricTool` updates in streaming scenario.
- Add `RunStepDeltaSharepointToolCall`, describing `SharepointTool` updates in streaming scenario.

## 1.2.0-beta.2 (2025-08-13)

### Features Added

- Implemented streaming scenario for MCP tool.
- Added `RunStepDetailsActivity`, describing MCP function parameters.

### Bugs Fixed

- Fixed the deserialization issue, when agent service returns the customized lists of trusted and requiring authentication MCP tools.
- Added classes for deserialization of `RunStepDeltaAzureAISearchToolCall`, `RunStepDeltaOpenAPIToolCall` and `RunStepDeltaDeepResearchToolCall`, required to get the real time updates when Azure AI Search, OpenAPI or Deep Research tools are being used during streaming scenarios.
- Added `RunStepConnectedAgentToolCall` and `RunStepDeltaConnectedAgentToolCall` for deserializing Connected Agent tool updates in non-streaming and streaming scenarios.

### Sample updates

- Added the streaming sample for Bing grounding.

## 1.2.0-beta.1 (2025-07-25)

### Bugs Fixed

- Fixed the [issue](https://github.com/Azure/azure-sdk-for-net/issues/51342) with ignoring `after` parameter when getting pageable lists.

## 1.1.0-beta.4 (2025-07-11)

### Features Added

- Added support for Deep Research.
- Added support for MCP.

### Sample updates

- Added sample for Deep Research.
- Expose the `GetVectorStoreFileBatchFiles` and `GetVectorStoreFileBatchFilesAsync` methods.

## 1.1.0-beta.3 (2025-06-27)

### Features Added

- Tracing for Agents. More information [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Agents.Persistent/README.md#tracing).
- Convenience constructor for BingCustomSearchToolParameters
- Support for automatic execution of function tool calls. More information [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Agents.Persistent/README.md#function-call-executed-automatically).

### Sample updates
- The Azure function sample was simplified.
- Added samples for file search citation with streaming.
- Fabric tool sample added
- Connected Agent tool sample added
- Multiple Connected Agent sample added.
- Bing Custom Search sample added.

## 1.1.0-beta.2 (2025-06-04)

### Bugs Fixed
- Fixed uploading files with non ASCII symbols in names.

## 1.1.0-beta.1 (2025-05-21)

### Features Added
- Set API version to 2025-05-15-preview.
- Added Bing Custom search tool.
- Added Sharepoint grounding tool.
- Added Microsoft Fabric tool.

## 1.0.0 (2025-05-15)

### Features Added
- First stable release of Azure AI Agents Persistent client library.

### Breaking Changes
- Support for project connection string and hub-based projects has been discontinued. We recommend creating a new Azure AI Foundry resource utilizing project endpoint. If this is not possible, please pin the version of `Azure.AI.Agents.Persistent` to version `1.0.0-beta.2` or earlier.

## 1.0.0-beta.2 (2025-05-14)

### Breaking Changes
- ThreadRunSteps methods were moved to Runs.
- VectorStoreFileBatches and VectorStoreFiles methods were moved to VectorStores.
- The AzureAISearchResource was replaced by AzureAISearchToolResource.

### Sample updates
- Added sample demonstrating uploading single file to vector store and listing run steps.

## 1.0.0-beta.1 (2025-05-09)

### Features Added
- Initial release
- Please see the [agents migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/AGENTS_MIGRATION_GUIDE.md) on how to use `Azure.AI.Projects` with `Azure.AI.Agents.Persistent` package.
