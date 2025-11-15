# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

- `ProjectResponsesClient.GetProjectResponses()` is added, supporting the ability to list previous responses with optional agent and conversation filters.

### Breaking Changes (beta)

- `ProjectConversationsClient.GetProjectConversations()` has an updated signature that accepts an `AgentReference` instead of distinct `agentName` and `agentId` parameters, aligned with the new "list responses" operation.

## 1.0.0-beta.2 (2025-11-14)

### Bugs fixed

- Addressed a problem where not supplying an options instance to the `ProjectResponsesClient` constructor resulted in fallback to the `https://api.openai.com/v1` endpoint

## 1.0.0-beta.1 (2025-11-14)

This is the first release of the `Azure.AI.Projects.OpenAI` library, a new extension package for the official `OpenAI` .NET library that facilitates and simplifies use of Microsoft Foundry extensions to OpenAI APIs.

### Features Added

- `Responses` support, including C# 14 extension properties to `OpenAIResponse` and `ResponseCreationOptions`, together with a `ProjectResponsesClient` type (extends official `OpenAIResponseClient`)
- `Files` support, including a `ProjectFilesClient` type (extends official `OpenAIFileClient`)
- Types and functionality in support of `Azure.AI.Projects` OpenAI-based features, including new Microsoft Foundry Agents Service capabilities
