# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-07-25)

### Features Added
- Tracing for Agents. More information [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Agents.Persistent/README.md#tracing).
- Added `include` parameter to `CreateRunStreaming` and `CreateRunStreamingAsync`.
- Added `tool_resources` parameter to `CreateRun` and `CreateRunAsync`

## 1.0.0 (2025-05-15)

### Features Added
- First stable release of Azure AI Agents Persistent client library.

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
