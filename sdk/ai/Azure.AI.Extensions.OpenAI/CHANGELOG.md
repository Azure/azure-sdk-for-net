# Release History

## 3.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 3.0.0-beta.2 (2026-09-03)

### Other Changes
- No user-facing changes

## 3.0.0-beta.1 (2026-08-24)

This release migrates the library from emitting its own copies of the OpenAI Responses object model to consuming the types provided by the [`OpenAI`](https://www.nuget.org/packages/OpenAI) .NET library (2.12.0). This is a large, breaking change. See the [Migration Guide](https://aka.ms/Azure.AI.Extensions.OpenAI-V2V3Migration) for step-by-step upgrade guidance.

### Features Added
- Added distributed tracing support.
- Added `SessionId`, `Agent`, and `AgentConversationId` extension properties on `OpenAI.Responses.CreateResponseOptions` (via `CreateResponseOptionsExtensions`). `SessionId` scopes a response to a specific session.
- Added `AgentReference` and `ResponseId` extension properties on `OpenAI.Responses.ResponseItem` (via `ResponseItemExtensions`), and `Agent`/`AgentConversationId` on `OpenAI.Responses.ResponseResult` (via `ResponseResultExtensions`). These replace the instance properties that were declared on the removed `AgentResponseItem` base type, and are read-only.
- Added `ResponseItemKindExtensions` and `ResponseToolKindExtensions`, which surface the Azure-specific kinds (for example `ResponseToolKind.BingGrounding`, `ResponseItemKind.AzureAISearchCall`) as named members on the upstream `OpenAI.Responses.ResponseToolKind` and `ResponseItemKind` extensible enums.
- `FabricIQPreviewTool.RequireApproval` is now the strongly-typed `FabricIQPreviewToolRequireApprovalChoice` instead of a raw `BinaryData`. It converts implicitly from both `string` and `OpenAI.Responses.McpToolCallApprovalPolicy`.
- The `ProjectResponsesClient` constructors accept `ProjectResponsesClientOptions`, including parameterless-options overloads so `new ProjectResponsesClient(projectEndpoint, tokenProvider)` resolves to a visible constructor without requiring an options argument.
- Added `MemoryLimit` and `NetworkPolicy` extension properties on `OpenAI.Responses.AutomaticCodeInterpreterToolContainerConfiguration` (via `AutomaticCodeInterpreterToolContainerConfigurationExtensions`). These properties use the `OpenAI.Containers.ContainerMemoryLimit` and `OpenAI.Containers.ContainerNetworkPolicy` types and preserve the Foundry `memory_limit` and `network_policy` request fields.

### Breaking Changes
- Changed `ProjectResponsesClientOptions` to derive from `OpenAI.Responses.ResponsesClientOptions` (instead of `ProjectOpenAIClientOptions`). This aligns with the upstream OpenAI client option hierarchy after `ResponsesClientOptions` was split out as a sibling of `OpenAIClientOptions`. Because it no longer derives from `ProjectOpenAIClientOptions`, it can no longer be passed to the `ProjectOpenAIClient` constructor; use `ProjectOpenAIClientOptions` there.
- **Response items and tools are now the `OpenAI` SDK types.** This library no longer emits its own copies of the Responses object model; it consumes the types from the `OpenAI` library (2.12.0) directly. As a result:
  - The `AgentResponseItem` base type and the `AgentResponseItemKind` enum were removed. Azure-specific response items (for example `BingGroundingToolCall`, `AzureAISearchToolCall`, `OAuthConsentRequestResponseItem`) now derive from `OpenAI.Responses.ResponseItem`, and Azure-specific tools (for example `BingGroundingTool`, `AzureAISearchTool`) now derive from `OpenAI.Responses.ResponseTool`. Iterate `ResponseResult.OutputItems` as `OpenAI.Responses.ResponseItem` and pattern-match to the Azure subtypes.
  - The settable `AgentResponseItem.AgentReference` and `AgentResponseItem.ResponseId` instance properties are gone. The same values are now read-only extension properties on `OpenAI.Responses.ResponseItem` (`ResponseItemExtensions`), so a `using Azure.AI.Extensions.OpenAI;` must be in scope to see them. To set agent or conversation metadata, use the `Agent`, `AgentConversationId`, and `SessionId` extension properties on `CreateResponseOptions` instead.
  - The public `ResponseItem.AsAgentResponseItem()` extension method was removed. Results returned by `ProjectResponsesClient` and the `CreateResponse`/`CreateResponseAsync` extensions are now normalized automatically, so `OutputItems` and echoed `Tools` already surface the strongly-typed Azure subtypes without any caller-side conversion.
- **Azure Responses tool and model types were renamed by dropping the `Responses` prefix** so they read naturally alongside the upstream `OpenAI.Responses` types. A few names were further normalized (`...ToolParameters` → `...ToolOptions`, `...Configuration`/`...ConnectionParameters` → `...Options`, `...AuthDetails` → `...AuthenticationDetails`, `Sharepoint` → `SharePoint`, `OpenApi` → `OpenAPI` on tool types). The full mapping:

  | Old (2.x) | New (3.0.0-beta.1) |
  | --- | --- |
  | `ResponsesA2APreviewTool` | `A2APreviewTool` |
  | `ResponsesAzureAISearchQueryKind` | `AzureAISearchQueryKind` |
  | `ResponsesAzureAISearchTool` | `AzureAISearchTool` |
  | `ResponsesAISearchIndexResource` | `AzureAISearchToolIndex` |
  | `ResponsesAzureAISearchToolResource` | `AzureAISearchToolOptions` |
  | `ResponsesAzureFunctionBinding` | `AzureFunctionBinding` |
  | `ResponsesAzureFunctionDefinition` | `AzureFunctionDefinition` |
  | `ResponsesAzureFunctionDefinitionFunction` | `AzureFunctionDefinitionFunction` |
  | `ResponsesAzureFunctionStorageQueue` | `AzureFunctionStorageQueue` |
  | `ResponsesAzureFunctionTool` | `AzureFunctionTool` |
  | `ResponsesBingCustomSearchConfiguration` | `BingCustomSearchOptions` |
  | `ResponsesBingCustomSearchPreviewTool` | `BingCustomSearchPreviewTool` |
  | `ResponsesBingCustomSearchToolParameters` | `BingCustomSearchToolOptions` |
  | `ResponsesBingGroundingSearchConfiguration` | `BingGroundingSearchOptions` |
  | `ResponsesBingGroundingSearchToolParameters` | `BingGroundingSearchToolOptions` |
  | `ResponsesBingGroundingTool` | `BingGroundingTool` |
  | `ResponsesBrowserAutomationPreviewTool` | `BrowserAutomationPreviewTool` |
  | `ResponsesBrowserAutomationToolConnectionParameters` | `BrowserAutomationToolConnectionOptions` |
  | `ResponsesBrowserAutomationToolParameters` | `BrowserAutomationToolOptions` |
  | `ResponsesCaptureStructuredOutputsTool` | `CaptureStructuredOutputsTool` |
  | `ResponsesFabricDataAgentToolOptions` | `FabricDataAgentToolOptions` |
  | `ResponsesFabricIQPreviewTool` | `FabricIQPreviewTool` |
  | `ResponsesMemorySearchOptions` | `MemorySearchOptions` |
  | `ResponsesMemorySearchPreviewTool` | `MemorySearchPreviewTool` |
  | `ResponsesMicrosoftFabricPreviewTool` | `MicrosoftFabricPreviewTool` |
  | `ResponsesOpenApiAnonymousAuthDetails` | `OpenApiAnonymousAuthenticationDetails` |
  | `ResponsesOpenApiAuthDetails` | `OpenApiAuthenticationDetails` |
  | `ResponsesOpenApiFunctionDefinition` | `OpenApiFunctionDefinition` |
  | `ResponsesOpenApiFunctionDefinitionFunction` | `OpenApiFunctionDefinitionFunction` |
  | `ResponsesOpenApiManagedAuthDetails` | `OpenApiManagedAuthenticationDetails` |
  | `ResponsesOpenApiManagedSecurityScheme` | `OpenApiManagedSecurityScheme` |
  | `ResponsesOpenApiProjectConnectionAuthDetails` | `OpenApiProjectConnectionAuthenticationDetails` |
  | `ResponsesOpenApiProjectConnectionSecurityScheme` | `OpenApiProjectConnectionSecurityScheme` |
  | `ResponsesOpenApiTool` | `OpenApiTool` |
  | `ResponsesSharepointGroundingToolParameters` | `SharePointGroundingToolOptions` |
  | `ResponsesSharepointPreviewTool` | `SharePointPreviewTool` |
  | `ResponsesStructuredOutputDefinition` | `StructuredOutputDefinition` |
  | `ResponsesToolProjectConnection` | `ToolProjectConnection` |
  | `ResponsesWebSearchConfiguration` | `WebSearchConfiguration` |
  | `ResponsesWorkIQPreviewTool` | `WorkIQPreviewTool` |
- **Other renames** were done:

  | Old (2.x) | New (3.0.0-beta.1) |
  | --- | --- |
  | `OpenAPIAnonymousAuthenticationDetails` | `OpenApiAnonymousAuthenticationDetails` |
  | `SharepointGroundingToolCall` | `SharePointGroundingToolCall` |
  | `SharepointGroundingToolCallOutput` | `SharePointGroundingToolCallOutput` |

  The built-in tool and item types that OpenAI already models (for example computer-use, web-search, function, and MCP tools) are no longer emitted by this library; use the corresponding `OpenAI.Responses` types instead.
- **Members were renamed alongside their declaring types:**

  | Type | Old member (2.x) | New member (3.0.0-beta.1) |
  | --- | --- | --- |
  | `OpenApiFunctionDefinition` | `Auth` (and the `auth` constructor parameter) | `Authentication` (and `authentication`) |
  | `OpenApiFunctionDefinition` | `DefaultParams` | `DefaultParameters` |
  | `OpenApiAuthenticationDetails` | `Type` | `Kind` |

- `OAuthConsentRequestResponseItem` changed shape: the consent link is now the strongly-typed `Uri ConsentLink` property rather than the `internalConsentLink` string, and both `ConsentLink` and `Id` are now settable.
- Added the `AAIP002` experimental diagnostic, alongside the existing `AAIP001`. `AAIP002` is applied to the Azure tool and response-item models (for example `BingGroundingTool`, `AzureAISearchTool`, `CaptureStructuredOutputsTool`, `OAuthConsentRequestResponseItem`, and their `...ToolCall`/`...ToolCallOutput` types), while `AAIP001` covers the response-normalization surfaces, `ProjectResponsesClient`, the extension-member classes, and the preview Foundry tools. Callers that previously suppressed only `AAIP001` must now also suppress `AAIP002`.
- Removed the `ProjectConversation`, `ProjectConversationCreationOptions`, and `ProjectConversationUpdateOptions` data models. These duplicated the conversation types now provided by the `OpenAI` library (2.12.0+). `ProjectConversationsClient` and the `CreateResponse`/`CreateResponseAsync` extension overloads now consume and return `OpenAI.Conversations.ConversationResource`, `OpenAI.Conversations.ConversationCreationOptions`, and `OpenAI.Conversations.ConversationUpdateOptions` instead. The `ProjectConversationsClient` method names (`CreateProjectConversation`, `GetProjectConversation(s)`, `UpdateProjectConversation`) are unchanged. Note that `ProjectConversation`'s implicit conversion to its ID string is not available on `ConversationResource`; use `conversation.Id` explicitly.
- The generated code-interpreter container types `ResponsesAutoCodeInterpreterToolParam`, `ResponsesContainerMemoryLimit`, `ResponsesContainerNetworkPolicyParam`, `ResponsesContainerNetworkPolicyAllowlistParam`, `ResponsesContainerNetworkPolicyDisabledParam`, and `ResponsesContainerNetworkPolicyDomainSecretParam` were removed. Create an `OpenAI.Responses.AutomaticCodeInterpreterToolContainerConfiguration` and use its new `MemoryLimit` and `NetworkPolicy` extension properties with the corresponding `OpenAI.Containers` types instead.
- Removed the strongly-typed request/response types for several preview Responses tool kinds that have no equivalent in the upstream `OpenAI` library (2.12.0). OpenAI's `OpenAI.Responses.ResponseToolKind` models only `apply_patch`, `code_interpreter`, `computer_use_preview`, `file_search`, `function`, `image_generation`, `mcp`, `web_search`, and `web_search_preview`, so mapping onto the upstream types dropped the previously generated:
  - **Custom tools + grammar:** `ResponsesCustomToolParam`, `ResponsesCustomToolParamFormat`, `ResponsesCustomTextFormatParam`, `CustomGrammarFormatParam`, `ResponsesGrammarSyntax`, `OutputItemCustomToolCallOutputResource`.
  - **`local_shell` / `shell` tools:** `ResponsesLocalShellToolParam`, `ResponsesFunctionShellToolParam`, `ResponsesFunctionShellToolParamEnvironment`, `ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam`, `ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam`, `ItemLocalShellToolCallOutputStatus`, `OutputItemLocalShellToolCallOutput`.
  - **`namespace` tool:** `ResponsesNamespaceToolParam`.
  - **`tool_search` tool:** `ResponsesToolSearchToolParam`, `ResponsesToolSearchExecutionType`, `OutputItemToolSearchCall`, `OutputItemToolSearchOutput`.
  - **Skills:** `ContainerSkill`, `LocalSkillParam`, `ResponsesInlineSkillParam`, `ResponsesInlineSkillSourceParam`, `ResponsesSkillReferenceParam`.

  These tool kinds remain reachable on the wire because `ResponseToolKind` is an extensible enum and the corresponding tool slots accept a raw object payload, but strongly-typed construction is not available. Native support for each will return once the upstream OpenAI .NET SDK models the tool kind. The Azure Foundry toolbox search capability remains available, now surfaced as the `OpenAI.Responses.ResponseToolKind.ToolboxSearchPreview` tool kind (the previously generated `ResponsesToolboxSearchPreviewTool` type is no longer emitted).

### Other Changes
- Updated the `OpenAI` package dependency to `2.12.0`. `2.11.0` reshaped `OpenAI.Responses.ResponsesClientOptions` to derive directly from `System.ClientModel.Primitives.ClientPipelineOptions` (a sibling of `OpenAI.OpenAIClientOptions` rather than a subclass), which is why `ProjectResponsesClientOptions` now derives from `ResponsesClientOptions`. `2.12.0` adds strongly-typed conversation support (`OpenAI.Conversations.ConversationResource`, `ConversationCreationOptions`, `ConversationUpdateOptions`); the conversation data models previously emitted by this package are no longer generated, and the temporary local convenience layer now delegates to the upstream types.

### Sample Updates
- Added sample for running responses in specific sessions.
- Added sample for `ReminderPreviewToolboxTool`.
- Removed the session ID header from the samples; it does not affect which session is used.

## 2.1.0-beta.4 (2026-06-30)

### Bugs Fixed

- Fixed issue with stateless encrypted reasoning [issue](https://github.com/Azure/azure-sdk-for-net/issues/59967).

## 2.1.0-beta.3 (2026-05-29)

### Breaking Changes
- **Breaking changes since version 2.0.0** `MemorySearchToolCallResponseItem` was replaced by `MemorySearchToolCall`, `MemoryCommandToolCall` and `MemoryCommandToolCallOutput`.
- **Breaking changes since version 2.0.0** `MemoryToolSearchItem` was removed, because it is not used anymore.

### Sample Updates
- Added a sample for Fabric IQ Tool (preview).
- Added a sample for Work IQ Tool (preview).

## 2.1.0-beta.2 (2026-05-14)

### Features Added
- Added `ResponsesToolboxSearchPreviewTool` for discovering deferred tools via `search_tools` queries at runtime.
- Added `Name` and `Description` properties to Responses tool classes.
- Added new method `GetProjectResponsesClientForAgentEndpoint` on the `ProjectOpenAIClient`.

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
