# Migration guide: `Azure.AI.Extensions.OpenAI` 2.x to 3.0.0-beta.1

This guide helps you upgrade from the 2.x releases of `Azure.AI.Extensions.OpenAI` to `3.0.0-beta.1`.

## Overview

Through the 2.x line, `Azure.AI.Extensions.OpenAI` shipped its own generated copies of the OpenAI
Responses object model (response items, tools, and the conversation types), each prefixed with
`Responses` or `Agent`. Starting with `3.0.0-beta.1`, the library instead **consumes those types
directly from the official [`OpenAI`](https://www.nuget.org/packages/OpenAI) .NET library (2.12.0)**.

This is a large, deliberately breaking change. The benefits:

- Response items, tools, and conversations are the same types you already use with the OpenAI
  client — no conversion between "OpenAI" and "Azure" shapes.
- New OpenAI features flow through automatically instead of waiting to be re-emitted here.
- Azure-specific capabilities (Bing grounding, Azure AI Search, Fabric, SharePoint, and the other
  Foundry tools) remain, now expressed as subtypes of the upstream OpenAI base types.

The changes fall into four categories, each covered below:

1. [Response items and tools are now OpenAI types](#1-response-items-and-tools-are-now-openai-types)
2. [Conversations are now OpenAI types](#2-conversations-are-now-openai-types)
3. [Azure tool and model types were renamed](#3-azure-tool-and-model-types-were-renamed)
4. [Client options](#4-client-options)

There is also guidance on [preview tool kinds that were temporarily dropped](#preview-tool-kinds-temporarily-unavailable)
and on [experimental APIs](#experimental-apis).

## Update your package references

`3.0.0-beta.1` depends on `OpenAI` 2.12.0. If you reference the `OpenAI` package directly, ensure it
is at 2.12.0 or later:

```xml
<PackageReference Include="Azure.AI.Extensions.OpenAI" Version="3.0.0-beta.1" />
<PackageReference Include="OpenAI" Version="2.12.0" />
```

Add the relevant `OpenAI` namespaces where you previously relied on Azure-emitted equivalents:

```csharp
using OpenAI.Responses;      // ResponseItem, ResponseTool, ResponseResult, ...
using OpenAI.Conversations;  // ConversationResource, ConversationCreationOptions, ConversationUpdateOptions
```

## 1. Response items and tools are now OpenAI types

The `AgentResponseItem` base type and the `AgentResponseItemKind` enum were **removed**. The
Azure-specific response items and tools now derive from the upstream base types:

- Azure response items (for example `BingGroundingToolCall`, `AzureAISearchToolCall`,
  `OAuthConsentRequestResponseItem`) derive from `OpenAI.Responses.ResponseItem`.
- Azure tools (for example `BingGroundingTool`, `AzureAISearchTool`) derive from
  `OpenAI.Responses.ResponseTool`.

### Enumerating output items

The public `ResponseItem.AsAgentResponseItem()` extension method was **removed**. It is no longer
needed: results returned by `ProjectResponsesClient` and by the `CreateResponse`/`CreateResponseAsync`
extension methods are normalized automatically, so `ResponseResult.OutputItems` (and the echoed
`ResponseResult.Tools`) already contain the strongly-typed Azure subtypes.

Before (2.x):

```csharp
foreach (ResponseItem item in response.OutputItems)
{
    // Manual conversion was required to get the strongly-typed Azure item.
    AgentResponseItem agentItem = item.AsAgentResponseItem();
    if (agentItem is BingGroundingToolCall bingCall)
    {
        // ...
    }
}
```

After (3.0.0-beta.1):

```csharp
foreach (ResponseItem item in response.OutputItems)
{
    // Items are already the strongly-typed Azure subtypes of OpenAI.Responses.ResponseItem.
    if (item is BingGroundingToolCall bingCall)
    {
        // ...
    }
}
```

If you cached, stored, or passed around `AgentResponseItem` values, change those references to
`OpenAI.Responses.ResponseItem`. Where you previously switched on `AgentResponseItemKind`, switch on
`ResponseItem.Kind` (an `OpenAI.Responses.ResponseItemKind`) or pattern-match on the concrete Azure
subtype as shown above.

### Agent metadata is now exposed through extension members

`AgentResponseItem` declared `AgentReference` and `ResponseId` as settable instance properties. Because
the base type is now the upstream `OpenAI.Responses.ResponseItem`, that metadata is surfaced as
**read-only extension properties** in `ResponseItemExtensions`. The equivalent response-level metadata
is surfaced by `ResponseResultExtensions` (`Agent`, `AgentConversationId`) and the request-level
metadata by `CreateResponseOptionsExtensions` (`Agent`, `AgentConversationId`, `SessionId` — these are
settable).

To see them, keep a `using Azure.AI.Extensions.OpenAI;` in scope:

```csharp
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

// Response-level metadata.
AgentReference agent = response.Agent;
string conversationId = response.AgentConversationId;

foreach (ResponseItem item in response.OutputItems)
{
    // Item-level metadata (read-only).
    AgentReference itemAgent = item.AgentReference;
    string sourceResponseId = item.ResponseId;
}

// Request-level metadata (settable).
CreateResponseOptions options = new(inputItems);
options.Agent = new AgentReference(FOUNDRY_AGENT_NAME);
options.AgentConversationId = conversation.Id;
options.SessionId = sessionId;
```

If you previously *assigned* `AgentResponseItem.AgentReference` or `AgentResponseItem.ResponseId`,
there is no replacement on the item; set the corresponding value on `CreateResponseOptions` instead.
`CreateResponseOptions.SessionId` is new in `3.0.0-beta.1` and lets you scope a response to a specific
session.

### Built-in tools now come from OpenAI

Tools and items that OpenAI already models are no longer emitted by this library. Use the upstream
`OpenAI.Responses` types instead. This includes the computer-use, web-search, function, and MCP
tool/item shapes (for example `ResponsesComputerTool`, `ResponsesWebSearchTool`,
`ResponsesFunctionToolParam`, `ResponsesMCPToolFilter`, `ComputerScreenshotImage`). The
Azure-specific Foundry tools are unaffected apart from the renames in section 3.

## 2. Conversations are now OpenAI types

The `ProjectConversation`, `ProjectConversationCreationOptions`, and `ProjectConversationUpdateOptions`
types were **removed** and replaced by the upstream conversation types from `OpenAI.Conversations`:

| Old (2.x) | New (3.0.0-beta.1) |
| --- | --- |
| `ProjectConversation` | `OpenAI.Conversations.ConversationResource` |
| `ProjectConversationCreationOptions` | `OpenAI.Conversations.ConversationCreationOptions` |
| `ProjectConversationUpdateOptions` | `OpenAI.Conversations.ConversationUpdateOptions` |

`ProjectConversationsClient` and its method names (`CreateProjectConversation`,
`GetProjectConversation(s)`, `UpdateProjectConversation`) are unchanged; only the model types differ.

One behavioral difference: `ProjectConversation` had an implicit conversion to its ID string, but
`ConversationResource` does not. Use `conversation.Id` explicitly.

Before (2.x):

```csharp
ProjectConversationCreationOptions conversationOptions = new()
{
    Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
    Metadata = { ["foo"] = "bar" },
};
ProjectConversation conversation = await projectClient.ProjectOpenAIClient
    .GetProjectConversationsClient().CreateProjectConversationAsync(conversationOptions);

// Implicit conversion to the conversation id.
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient
    .GetProjectResponsesClientForAgent(FOUNDRY_AGENT_NAME, conversation);
```

After (3.0.0-beta.1):

```csharp
ConversationCreationOptions conversationOptions = new()
{
    Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
    Metadata = { ["foo"] = "bar" },
};
ConversationResource conversation = await projectClient.ProjectOpenAIClient
    .GetProjectConversationsClient().CreateProjectConversationAsync(conversationOptions);

// Pass the id explicitly.
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient
    .GetProjectResponsesClientForAgent(FOUNDRY_AGENT_NAME, conversation.Id);
```

The `CreateResponse`/`CreateResponseAsync` extension methods on `ResponsesClient` that accepted a
`ProjectConversation` now accept a `ConversationResource`.

## 3. Azure tool and model types were renamed

Azure Responses tool and model types dropped the `Responses` prefix so they read naturally alongside
the upstream `OpenAI.Responses` types. A few names were normalized further:

- `...ToolParameters` became `...ToolOptions`.
- `...Configuration` and `...ConnectionParameters` on the Bing and browser-automation search shapes
  became `...Options`.
- `...AuthDetails` became `...AuthenticationDetails`.
- `Sharepoint` became `SharePoint` (on the options type), and `OpenApi` became `OpenAPI` on the tool
  type name.

Full mapping (old to new):

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
| `ResponsesOpenApiAnonymousAuthDetails` | `OpenAPIAnonymousAuthenticationDetails` |
| `ResponsesOpenApiAuthDetails` | `OpenApiAuthenticationDetails` |
| `ResponsesOpenApiFunctionDefinition` | `OpenApiFunctionDefinition` |
| `ResponsesOpenApiFunctionDefinitionFunction` | `OpenApiFunctionDefinitionFunction` |
| `ResponsesOpenApiManagedAuthDetails` | `OpenApiManagedAuthenticationDetails` |
| `ResponsesOpenApiManagedSecurityScheme` | `OpenApiManagedSecurityScheme` |
| `ResponsesOpenApiProjectConnectionAuthDetails` | `OpenApiProjectConnectionAuthenticationDetails` |
| `ResponsesOpenApiProjectConnectionSecurityScheme` | `OpenApiProjectConnectionSecurityScheme` |
| `ResponsesOpenApiTool` | `OpenAPITool` |
| `ResponsesSharepointGroundingToolParameters` | `SharePointGroundingToolOptions` |
| `ResponsesSharepointPreviewTool` | `SharepointPreviewTool` |
| `ResponsesStructuredOutputDefinition` | `StructuredOutputDefinition` |
| `ResponsesToolProjectConnection` | `ToolProjectConnection` |
| `ResponsesWebSearchConfiguration` | `WebSearchConfiguration` |
| `ResponsesWorkIQPreviewTool` | `WorkIQPreviewTool` |

The `...ToolCall` and `...ToolCallOutput` response-item types (for example `BingGroundingToolCall`,
`AzureAISearchToolCallOutput`) keep their names; only their base type changed from `AgentResponseItem`
to `OpenAI.Responses.ResponseItem` as described in section 1.

Before (2.x):

```csharp
ResponsesBingGroundingTool bingGroundingAgentTool = new(new ResponsesBingGroundingSearchToolParameters(
    searchConfigurations: [new ResponsesBingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
));
```

After (3.0.0-beta.1):

```csharp
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchOptions(projectConnectionId: bingConnectionName.Id)]
));
```

### Member renames

A few members were renamed alongside their declaring types:

| Type | Old member (2.x) | New member (3.0.0-beta.1) |
| --- | --- | --- |
| `OpenApiFunctionDefinition` | `Auth` (and the `auth` constructor parameter) | `Authentication` (and `authentication`) |
| `OpenApiFunctionDefinition` | `DefaultParams` | `DefaultParameters` |
| `OpenApiAuthenticationDetails` | `Type` | `Kind` |

`OAuthConsentRequestResponseItem` also changed shape: the consent link is now the strongly-typed
`Uri ConsentLink` property (previously the `internalConsentLink` string), and both `ConsentLink` and
`Id` are now settable.

Before (2.x):

```csharp
ResponsesOpenApiFunctionDefinition openApiFunction = new(name, specification, auth)
{
    DefaultParams = { "format" },
};
ResponsesOpenApiAuthDetails details = openApiFunction.Auth;
```

After (3.0.0-beta.1):

```csharp
OpenApiFunctionDefinition openApiFunction = new(name, specification, authentication)
{
    DefaultParameters = { "format" },
};
OpenApiAuthenticationDetails details = openApiFunction.Authentication;
```

## 4. Client options

`ProjectResponsesClientOptions` now derives from the upstream OpenAI option hierarchy. In `OpenAI`
2.11.0, `ResponsesClientOptions` became a sibling of `OpenAIClientOptions` rather than a subclass, so
`ProjectResponsesClientOptions` now derives from `OpenAI.Responses.ResponsesClientOptions` (instead of
`ProjectOpenAIClientOptions`):

- `ProjectResponsesClientOptions` derives from `OpenAI.Responses.ResponsesClientOptions`. There is an
  implicit conversion from `ProjectOpenAIClientOptions` that copies all public configuration (endpoint,
  organization/project IDs, user-agent application ID, pipeline/retry/logging/transport settings,
  network timeout, distributed tracing flag, `ApiVersion`, and `AgentName`). `ProjectResponsesClient`
  constructors accept it, including parameterless-options overloads.
- Because `ProjectResponsesClientOptions` no longer derives from `ProjectOpenAIClientOptions`, it can no
  longer be passed to the `ProjectOpenAIClient` constructor; use `ProjectOpenAIClientOptions` there.

Before (2.x):

```csharp
// ProjectResponsesClientOptions derived from ProjectOpenAIClientOptions, so the same
// options instance could be handed to both clients.
ProjectResponsesClientOptions options = new();
ProjectOpenAIClient openAIClient = new(projectEndpoint, tokenProvider, options);
ProjectResponsesClient client = new(projectEndpoint, tokenProvider, options);
```

After (3.0.0-beta.1):

```csharp
// ProjectOpenAIClient requires ProjectOpenAIClientOptions.
ProjectOpenAIClientOptions openAIOptions = new();
ProjectOpenAIClient openAIClient = new(projectEndpoint, tokenProvider, openAIOptions);

// ProjectResponsesClientOptions is still accepted by ProjectResponsesClient, and
// ProjectOpenAIClientOptions converts implicitly if you want to share configuration.
ProjectResponsesClientOptions responsesOptions = openAIOptions;
ProjectResponsesClient client = new(projectEndpoint, tokenProvider, responsesOptions);
```

## Code-interpreter container settings

The generated code-interpreter container types were replaced by the upstream Responses container
configuration and the equivalent container-management value types:

| Old (2.x) | New (3.0.0-beta.1) |
| --- | --- |
| `ResponsesAutoCodeInterpreterToolParam` | `OpenAI.Responses.AutomaticCodeInterpreterToolContainerConfiguration` |
| `ResponsesContainerMemoryLimit` | `OpenAI.Containers.ContainerMemoryLimit` |
| `ResponsesContainerNetworkPolicyParam` | `OpenAI.Containers.ContainerNetworkPolicy` |
| `ResponsesContainerNetworkPolicyAllowlistParam` | `OpenAI.Containers.ContainerAllowlistNetworkPolicy` |
| `ResponsesContainerNetworkPolicyDisabledParam` | `OpenAI.Containers.ContainerDisabledNetworkPolicy` |
| `ResponsesContainerNetworkPolicyDomainSecretParam` | `OpenAI.Containers.ContainerNetworkPolicyDomainSecret` |

Create the automatic container configuration through `OpenAI.Responses`, then set `MemoryLimit` and
`NetworkPolicy` using the extension properties provided by this library:

```csharp
using Azure.AI.Extensions.OpenAI;
using OpenAI.Containers;
using OpenAI.Responses;

ContainerAllowlistNetworkPolicy networkPolicy =
    new(["pypi.org", "files.pythonhosted.org"]);

networkPolicy.DomainSecrets.Add(
    new ContainerNetworkPolicyDomainSecret(
        domain: "pypi.org",
        name: "PYPI_TOKEN",
        value: "<token>"));

AutomaticCodeInterpreterToolContainerConfiguration configuration =
    CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
        fileIds: ["file_123"]);

configuration.MemoryLimit = ContainerMemoryLimit.Max4GB;
configuration.NetworkPolicy = networkPolicy;

ResponseTool codeInterpreterTool = ResponseTool.CreateCodeInterpreterTool(
    new CodeInterpreterToolContainer(configuration));
```

Use `new ContainerDisabledNetworkPolicy()` when the container should have no network access. File IDs
and container-ID selection continue to use the upstream `OpenAI.Responses` APIs.

## Preview tool kinds temporarily unavailable

Some preview Responses tool kinds have no equivalent in `OpenAI` 2.12.0, so mapping onto the upstream
types dropped their strongly-typed request/response classes. These are:

- **Custom tools + grammar:** `ResponsesCustomToolParam`, `ResponsesCustomTextFormatParam`,
  `CustomGrammarFormatParam`, `OutputItemCustomToolCallOutputResource`.
- **`local_shell` / `shell` tools:** `ResponsesLocalShellToolParam`, `ResponsesFunctionShellToolParam`
  (and its environment variants), `OutputItemLocalShellToolCallOutput`.
- **`namespace` tool:** `ResponsesNamespaceToolParam`.
- **`tool_search` tool:** `ResponsesToolSearchToolParam`, `OutputItemToolSearchCall`,
  `OutputItemToolSearchOutput`.
- **Skills:** `ResponsesInlineSkillParam`, `ResponsesInlineSkillSourceParam`,
  `ResponsesSkillReferenceParam`, `LocalSkillParam`.

These capabilities remain reachable on the wire because the corresponding tool kind is an extensible
enum and the tool slots accept a raw object payload — but strongly-typed construction is not
available. Native support for each will return once the upstream OpenAI .NET SDK models the tool kind.
This does not affect the Azure Foundry toolbox search feature, which remains available (surfaced as
`OpenAI.Responses.ResponseToolKind.ToolboxSearchPreview`).

## Experimental APIs

Parts of this library are marked with `[Experimental]` and must be explicitly acknowledged before you
can compile against them. Two diagnostic IDs are used:

| Diagnostic | Applies to |
| --- | --- |
| `AAIP001` | Response-normalization surfaces, `ProjectResponsesClient`, the `CreateResponse`/`CreateResponseAsync` extension overloads that take a `ConversationResource`, the extension-member classes, and the preview Foundry tool/item types (A2A, SharePoint, Fabric data agent, memory, Azure Function, browser automation, Bing custom search, ...). |
| `AAIP002` | The remaining Azure tool and response-item models, including `BingGroundingTool`, `AzureAISearchTool`, `CaptureStructuredOutputsTool`, `OAuthConsentRequestResponseItem`, `AgentStructuredOutputsResponseItem`, `AgentWorkflowPreviewActionResponseItem`, and their `...ToolCall`/`...ToolCallOutput` types. |

Suppress the IDs you use — for example with `#pragma warning disable AAIP001, AAIP002` around the call
site, or by adding them to `<NoWarn>` in your project. Code that only suppressed `AAIP001` against an
earlier `3.0.0-beta.1` drop must add `AAIP002`.

Extension properties additionally surface the .NET `SCME0001` experimental diagnostic from
`System.ClientModel`, and upstream OpenAI preview surfaces use `OPENAI001`; suppress those as well if
you consume them. Experimental APIs may change in a later release.

## Getting help

If you hit a migration issue not covered here, please
[open an issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose) with the
`Azure.AI.Extensions.OpenAI` label. See the [CHANGELOG](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/CHANGELOG.md) for the complete list of
changes in this release.
