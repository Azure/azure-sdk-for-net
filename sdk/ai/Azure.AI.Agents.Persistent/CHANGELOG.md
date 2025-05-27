# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
- The support of connection strings and hub based projects was dropped. Please create a new project, which uses endpoints (recommended), or pin the version of `Azure.AI.Agents.Persistent` to `1.0.0-beta.2` if it is not possible.

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
