# Release History

## 1.1.0-beta.3 (Unreleased)

### Features Added
- Added delete operation for `ThreadMessages`.

- Tracing for Agents

### Breaking Changes

### Bugs Fixed

### Other Changes

### Sample updates
- The Azure function sample was simplified.
- Added samples for file search citation with streaming. 

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
