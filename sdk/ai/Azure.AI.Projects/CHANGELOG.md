# Release History

## 1.0.0-beta.9 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.8 (2025-04-23)

### Sample Updates
* New sample added for connected agent tool.

### Bugs Fixed
* Fix for filtering of messages by run ID [see GitHub issue issue 49513](https://github.com/Azure/azure-sdk-for-net/issues/49513).

## 1.0.0-beta.7 (2025-04-18)

### Features Added
* Added image input support for agents create message
* Added list threads support for agents

### Sample Updates
* New samples added for image input from url and file.
* New Fabric tool sample for agents

## 1.0.0-beta.6 (2025-03-28)

### Features Added
* Added `QueryType` parameter to `AISearchIndexResource` to allow different search types performed by an agent [issue](https://github.com/Azure/azure-sdk-for-net/issues/49069).
* Added sample for Azure AI Search in streaming scenarios [issue](https://github.com/Azure/azure-sdk-for-net/issues/49069).

### Breaking Changes
* `MicrosoftFabricToolDefinition` constructor parameter was renamed from `fabricAiskill` to `fabricDataagent`, the corresponding parameter was renamed from `FabricAiskill` to `FabricDataagent`.

### Bugs Fixed
* Fixed Azure AI Search in streaming scenarios.

### Sample updates
* Added documentation for each sample.
* The unnecessary code was removed from samples.

## 1.0.0-beta.5 (2025-03-17)

### Features Added

* Added `ConnectionProvider` abstraction in `AIProjectClient` to enable seamless connectivity with Azure OpenAI, Inference, and Search SDKs.
* Added `CognitiveService` connection type.
* Added support for URL citations with the `MessageTextUrlCitationAnnotation` class. `MessageTextContent` objects now can possibly have `Annotations` populated in order to provide information on URL citations.

## 1.0.0-beta.4 (2025-02-28)

### Bugs Fixed

* Fixed deserialization failure for AzureBlobStorage connection [issue](https://github.com/Azure/azure-sdk-for-net/issues/47874)
* Fixed a bug on deserialization of RunStepDeltaFileSearchToolCall [issue](https://github.com/Azure/azure-sdk-for-net/issues/48333)

## 1.0.0-beta.3 (2025-01-22)

### Bugs Fixed

* Fixed the bug preventing addition of a single Azure blob URI to the VectorStore.
* Fixed deserialization of Run Step when the file search is used [issue](https://github.com/Azure/azure-sdk-for-net/issues/47836).
* Fixed the issue preventing using streaming with function tools [issue](https://github.com/Azure/azure-sdk-for-net/issues/47797).

## 1.0.0-beta.2 (2024-12-13)

### Features Added

* Added `AzureFunctionToolDefinition` support to inform Agents about Azure Functions.
* Added `OpenApiTool` for Agents, which creates and executes a REST function defined by an OpenAPI spec.
* Add `parallelToolCalls` parameter to `CreateRunRequest`, `CreateRunAsync`, `CreateRunStreaming` and `CreateRunStreamingAsync`,  which allows parallel tool execution for Agents.

### Bugs Fixed

* Fix a bug preventing additional messages to be created when using `CreateRunStreamingAsync` and `CreateRunAsync` see [issue](https://github.com/Azure/azure-sdk-for-net/issues/47244).
* Fixed a bug where an exception would occur when run was not completed due to RAI check fail see [issue](https://github.com/Azure/azure-sdk-for-net/issues/47243).

## 1.0.0-beta.1 (2024-11-19)

### Features Added
- Initial release
