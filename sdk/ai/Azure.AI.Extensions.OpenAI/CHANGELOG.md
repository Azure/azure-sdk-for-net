# Release History

## 2.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
