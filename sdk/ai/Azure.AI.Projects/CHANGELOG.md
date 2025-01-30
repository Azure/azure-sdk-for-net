# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
