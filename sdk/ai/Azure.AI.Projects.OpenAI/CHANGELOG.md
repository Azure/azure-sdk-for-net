# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

- Updated for full `net10` framework compatibility, including removal of `<EnablePreviewFeatures>` flagging.

### Sample Updates
- Added Hosted Agent sample.

## 1.0.0-beta.5 (2025-12-12)

### Features Added

- Added transitive compatibility for `OpenAI 2.8.0`, including significant changes to the `[Experimental]` Responses API surface
- Added possibility of authentication to MCP server using project connection.

## 1.0.0-beta.4 (2025-11-17)

### Features Added

This change updates the baseline `OpenAI` dependency to the latest `2.7.0` official version. For inherited details, please see the [OpenAI .NET changelog](https://github.com/openai/openai-dotnet/tree/main/CHANGELOG.md).

### Breaking Changes

**Transitive from upgrade to System.ClientModel 1.8.1**:

- The extension `StructuredInputs` on `CreateResponseOptions` will now correctly return a `BinaryData` instance with enclosing quotes included when retrieving an encoded string value

## 1.0.0-beta.3 (2025-11-15)

### Bugs Fixed

- Addressed an issue that caused paginated responses like conversation items to never terminate when large numbers of items are fetched

## 1.0.0-beta.2 (2025-11-14)

### Features Added

- `ProjectResponsesClient.GetProjectResponses()` is added, supporting the ability to list previous responses with optional agent and conversation filters.

### Breaking Changes (beta)

- `ProjectConversationsClient.GetProjectConversations()` has an updated signature that accepts an `AgentReference` instead of distinct `agentName` and `agentId` parameters, aligned with the new "list responses" operation.

### Bugs Fixed

- Addressed a problem where not supplying an options instance to the `ProjectResponsesClient` constructor resulted in fallback to the `https://api.openai.com/v1` endpoint

## 1.0.0-beta.1 (2025-11-14)

This is the first release of the `Azure.AI.Projects.OpenAI` library, a new extension package for the official `OpenAI` .NET library that facilitates and simplifies use of Microsoft Foundry extensions to OpenAI APIs.

### Features Added

- `Responses` support, including C# 14 extension properties to `ResponseResult` and `CreateResponseOptions`, together with a `ProjectResponsesClient` type (extends official `ResponsesClient`)
- `Files` support, including a `ProjectFilesClient` type (extends official `OpenAIFileClient`)
- Types and functionality in support of `Azure.AI.Projects` OpenAI-based features, including new Microsoft Foundry Agents Service capabilities
