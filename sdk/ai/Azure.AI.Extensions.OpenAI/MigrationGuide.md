# Migration guide: `Azure.AI.Extensions.OpenAI` 2.x to 3.x

This guide helps you upgrade from the 2.x releases of `Azure.AI.Extensions.OpenAI` to 3.x.
The migration began in `3.0.0-beta.1`; the current source version is `3.0.0-beta.6` (unreleased),
with an `OpenAI` 2.14.0 dependency.

## Overview

Through the 2.x line, `Azure.AI.Extensions.OpenAI` shipped its own generated copies of the OpenAI
Responses object model (response items, tools, and the conversation types), including types prefixed with
`Responses`, `Agent`, or `Project`. Starting with `3.0.0-beta.1`, the library instead **consumes those types
directly from the official [`OpenAI`](https://www.nuget.org/packages/OpenAI) .NET library**.
That first 3.x preview depended on OpenAI 2.12.0; the current source depends on 2.14.0.

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

There is also guidance on [custom tools and preview tool availability](#custom-tools-and-preview-tool-availability)
and on [experimental APIs](#experimental-apis).

## Update your package references

Use the OpenAI dependency version required by the Extensions version you install. The example below
uses the latest released Extensions preview, `3.0.0-beta.5`, with `OpenAI` 2.14.0. The current
`3.0.0-beta.6` source is unreleased and also depends on 2.14.0. If you reference `OpenAI` directly,
use 2.14.0 or later with this dependency; 2.12.0 was the dependency of the historical `3.0.0-beta.1`.

```xml
<PackageReference Include="Azure.AI.Extensions.OpenAI" Version="3.0.0-beta.5" />
<PackageReference Include="OpenAI" Version="2.14.0" />
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

After (3.x):

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
CreateResponseOptions options = new();
foreach (ResponseItem inputItem in inputItems)
{
    options.InputItems.Add(inputItem);
}
options.Agent = new AgentReference(FOUNDRY_AGENT_NAME);
options.AgentConversationId = conversation.Id;
options.SessionId = sessionId;
```

If you previously *assigned* `AgentResponseItem.AgentReference` or `AgentResponseItem.ResponseId`,
there is no public setter on the item. Configure request-level agent and conversation metadata on
`CreateResponseOptions` instead; these are not setters for an output item's source `ResponseId`.
`CreateResponseOptions.SessionId` was introduced in `3.0.0-beta.1` and lets you scope a response to a specific
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

| Old (2.x) | New (3.x) |
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

After (3.x):

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
- `Sharepoint` became `SharePoint` on the tool, options, and response-item type names.
- OpenAPI model names consistently use `OpenApi`, including `OpenApiTool` and
  `OpenApiAnonymousAuthenticationDetails`.

Full mapping (old to new):

| Old (2.x) | New (3.x) |
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
| `ResponsesMemorySearchOptions` | `MemorySearchResultOptions` |
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

Most `...ToolCall` and `...ToolCallOutput` response-item types (for example `BingGroundingToolCall`,
`AzureAISearchToolCallOutput`) keep their names; their base type changed from `AgentResponseItem`
to `OpenAI.Responses.ResponseItem` as described in section 1. The SharePoint items were also renamed:
`SharepointGroundingToolCall` became `SharePointGroundingToolCall`, and
`SharepointGroundingToolCallOutput` became `SharePointGroundingToolCallOutput`.

Before (2.x):

```csharp
ResponsesBingGroundingTool bingGroundingAgentTool = new(new ResponsesBingGroundingSearchToolParameters(
    searchConfigurations: [new ResponsesBingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
));
```

After (3.x):

```csharp
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchOptions(projectConnectionId: bingConnectionName.Id)]
));
```

### Member renames

A few members were renamed alongside their declaring types:

| Type | Old member (2.x) | New member (3.x) |
| --- | --- | --- |
| `OpenApiFunctionDefinition` | `Auth` (and the `auth` constructor parameter) | `Authentication` (and `authentication`) |
| `OpenApiFunctionDefinition` | `DefaultParams` | `DefaultParameters` |
| `OpenApiAuthenticationDetails` | `Type` | `Kind` |
| `SharePointPreviewTool` | `SharepointGroundingPreview` (and `sharepointGroundingPreview`) | `ToolOptions` (and `toolOptions`) |
| `MicrosoftFabricPreviewTool` | `FabricDataagentPreview` (and `fabricDataagentPreview`) | `ToolOptions` (and `toolOptions`) |

`OpenApiFunctionDefinition.Specification` and its `specification` constructor parameter also changed
from `IDictionary<string, BinaryData>` to `BinaryData`. Supply a JSON object as `BinaryData` rather
than passing the old dictionary directly.

Before (2.x):

```csharp
// specification is an IDictionary<string, BinaryData> containing the OpenAPI document fields.
ResponsesOpenApiFunctionDefinition openApiFunction = new(name, specification, auth)
{
    DefaultParams = { "format" },
};
ResponsesOpenApiAuthDetails details = openApiFunction.Auth;
```

After (3.x):

```csharp
BinaryData specification = BinaryData.FromString(openApiDocumentJson);
OpenApiFunctionDefinition openApiFunction = new(name, specification, authentication)
{
    DefaultParameters = { "format" },
};
OpenApiAuthenticationDetails details = openApiFunction.Authentication;
```

Here, `openApiDocumentJson` is the complete OpenAPI document as JSON. If converting an existing
dictionary whose values are JSON-encoded `BinaryData`, preserve those values as JSON rather than
serializing their byte representation.

### Memory migration from earlier 2.x releases

The replacement of `MemorySearchToolCallResponseItem` by `MemorySearchToolCall`,
`MemoryCommandToolCall`, and `MemoryCommandToolCallOutput`, and removal of `MemoryToolSearchItem`,
were already announced in `2.1.0-beta.3`. They are not newly introduced 3.0 changes, but applications
migrating from 2.0.0 still need to account for them.

Search results no longer have a `MemoryToolSearchItem` wrapper. Access the `MemoryOutputItem`
directly through `MemorySearchToolCall.Memories`:

```csharp
// Before (2.0.0): memoryCall is a MemorySearchToolCallResponseItem.
MemoryOutputItem memory = memoryCall.Results[i].MemoryItem;
```

```csharp
// After: memoryCall is a MemorySearchToolCall.
MemoryOutputItem memory = memoryCall.Memories[i];
```

The old extensible `MemorySearchToolCallStatus` was replaced by the `ToolCallStatus` enum, whose
values are `InProgress`, `Completed`, `Incomplete`, and `Failed`. The old `Searching` value has no
named equivalent; update status-handling code rather than referring to the retired type or value.

The current memory APIs require acknowledgement of `AAIP001`, including `MemorySearchPreviewTool`,
`MemorySearchResultOptions`, the memory search/command response items, `MemoryOutputItem`, and its
concrete subtypes. Some earlier memory APIs shipped without the intended experimental marker;
its presence now is a correction to experimental status, not a restoration of the old model.

## 4. Client options

`ProjectResponsesClientOptions` now derives from the upstream OpenAI option hierarchy. In `OpenAI`
2.11.0, `ResponsesClientOptions` became a sibling of `OpenAIClientOptions` rather than a subclass, so
`ProjectResponsesClientOptions` now derives from `OpenAI.Responses.ResponsesClientOptions` (instead of
`ProjectOpenAIClientOptions`):

- `ProjectResponsesClientOptions` derives from `OpenAI.Responses.ResponsesClientOptions`. `ProjectResponsesClient`
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

After (3.x), when sharing root-client configuration:

```csharp
// ProjectOpenAIClient requires ProjectOpenAIClientOptions.
ProjectOpenAIClientOptions openAIOptions = new();
ProjectOpenAIClient openAIClient = new(projectEndpoint, tokenProvider, openAIOptions);
ProjectResponsesClient client = openAIClient.GetProjectResponsesClient();
```

Configure `openAIOptions` before constructing the root client. The factory reuses that client's
existing pipeline, including its transport and custom policies.

When constructing clients independently, create and configure one options instance of each type:

```csharp
ProjectOpenAIClientOptions openAIOptions = new();
ProjectResponsesClientOptions responsesOptions = new();
// Configure each options instance before constructing its client.
ProjectOpenAIClient openAIClient = new(projectEndpoint, tokenProvider, openAIOptions);
ProjectResponsesClient client = new(projectEndpoint, tokenProvider, responsesOptions);
```

These clients are independently configured. Setting a transport, retry policy, custom pipeline policy,
or another option on `openAIOptions` does not configure `responsesOptions`. Use the root factory when
shared-pipeline behavior is intended. These Responses client/options/factory paths require
`OPENAI001`; individual response calls may additionally require `AAIP001`.

## Code-interpreter container settings

The generated code-interpreter container types were replaced by the upstream Responses container
configuration and the equivalent container-management value types:

| Old (2.x) | New (3.x) |
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

## Custom tools and preview tool availability

The initial migration to OpenAI 2.12.0 dropped some generated preview request/response classes.
Availability depends on the upstream version, not just on the Extensions major version.

OpenAI 2.14.0 now provides strongly-typed custom tools, including text and grammar formats:

| Removed Extensions type | OpenAI 2.14.0 type in `OpenAI.Responses` |
| --- | --- |
| `ResponsesCustomToolParam` | `CustomTool` |
| `ResponsesCustomTextFormatParam` | `CustomToolTextFormat` |
| `CustomGrammarFormatParam` | `CustomToolGrammarFormat` |
| `OutputItemCustomToolCallOutputResource` | `CustomToolCallOutputItem` |

Use `CustomToolCallItem` for custom-tool calls. These are upstream types, not restored copies of the
removed Extensions models.

The following formerly generated preview models still have no strongly-typed equivalents in
OpenAI 2.14.0:

- **`local_shell` / `shell` tools:** `ResponsesLocalShellToolParam`, `ResponsesFunctionShellToolParam`
  (and its environment variants), `OutputItemLocalShellToolCallOutput`.
- **`namespace` tool:** `ResponsesNamespaceToolParam`.
- **`tool_search` tool:** `ResponsesToolSearchToolParam`, `OutputItemToolSearchCall`,
  `OutputItemToolSearchOutput`.
- **Skills:** `ResponsesInlineSkillParam`, `ResponsesInlineSkillSourceParam`,
  `ResponsesSkillReferenceParam`, `LocalSkillParam`.

For service-supported capabilities without a strongly-typed model, use protocol overloads with
`BinaryContent` containing the required JSON payload. An extensible tool-kind value alone does not
provide strongly-typed construction. Check the upstream API surface when upgrading OpenAI versions.
This does not affect the Azure Foundry toolbox search feature, which remains available (surfaced as
`OpenAI.Responses.ResponseToolKind.ToolboxSearchPreview`).

## Content-filter configuration package migration

`Azure.AI.Extensions.OpenAI.ContentFilterConfiguration` was removed entirely; it was not made
internal. For `ToolboxPolicies.RaiConfig`, use the separate, existing public
`Azure.AI.Projects.Agents.ContentFilterConfiguration` model. That model already exists in Agents 2.0;
this is not an automatic type forward or a newly introduced Agents type.

| Removed Extensions API | Existing Agents counterpart |
| --- | --- |
| `Azure.AI.Extensions.OpenAI.ContentFilterConfiguration` | `Azure.AI.Projects.Agents.ContentFilterConfiguration` |
| Constructor parameter `policyName` | Constructor parameter `raiPolicyName` |
| Property `PolicyName` | Property `RaiPolicyName` |

Add a reference to the `Azure.AI.Projects.Agents` package and import its namespace:

```csharp
using Azure.AI.Projects.Agents;

ContentFilterConfiguration configuration = new(raiPolicyName: policyName);
ToolboxPolicies policies = new() { RaiConfig = configuration };
```

The supported `ToolboxPolicies.RaiConfig` functionality remains in the Agents package; do not restore
the removed Extensions model or remove the live Agents model as part of this migration.

## Experimental APIs

Parts of this library and its dependencies are marked with `[Experimental]` and must be explicitly
acknowledged before you can compile against them. The applicable diagnostics depend on the API used:

| Diagnostic | Applies to |
| --- | --- |
| `OPENAI001` | Upstream OpenAI preview surfaces; also the Extensions `ProjectResponsesClient`, `ProjectResponsesClientOptions`, `ProjectConversationsClient`, the Responses/conversation factories on `ProjectOpenAIClient`, `ResponseItemExtensions`, `ResponseResultExtensions`, and the response/tool-kind extension classes. |
| `AAIP001` | Response creation/normalization methods, the `CreateResponse`/`CreateResponseAsync` extension overloads that take a `ConversationResource`, `CreateResponseOptionsExtensions`, automatic-container configuration extensions, and preview Foundry tool/item types (A2A, SharePoint, Fabric data agent, memory, Azure Function, browser automation, Bing custom search, ...). |
| `AAIP002` | The remaining Azure tool and response-item models, including `BingGroundingTool`, `AzureAISearchTool`, `CaptureStructuredOutputsTool`, `OAuthConsentRequestResponseItem`, `AgentStructuredOutputsResponseItem`, `AgentWorkflowPreviewActionResponseItem`, and their `...ToolCall`/`...ToolCallOutput` types. |
| `SCME0001` | Extension properties backed by the experimental `System.ClientModel` JSON patch APIs. |

Suppress only the IDs required by the APIs you use, with `#pragma warning disable` around the call
site or by adding them to `<NoWarn>` in your project. For example, constructing the root client and
obtaining its Responses client requires only `OPENAI001` for the APIs shown:

```csharp
#pragma warning disable OPENAI001
ProjectOpenAIClientOptions openAIOptions = new();
ProjectOpenAIClient openAIClient = new(projectEndpoint, tokenProvider, openAIOptions);
ProjectResponsesClient client = openAIClient.GetProjectResponsesClient();
#pragma warning restore OPENAI001
```

Calling response methods, accessing extension properties, or constructing Azure tools can require
additional diagnostics from the table. In particular, memory models require `AAIP001`, and callers
using `AAIP002` models must acknowledge that ID even if older code suppressed only `AAIP001`.
Experimental APIs may change in a later release.

## Getting help

If you hit a migration issue not covered here, please
[open an issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose) with the
`Azure.AI.Extensions.OpenAI` label. See the [CHANGELOG](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/CHANGELOG.md) for the complete list of
changes in each release.
