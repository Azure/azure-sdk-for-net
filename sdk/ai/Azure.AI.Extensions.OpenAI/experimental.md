# Experimental API assignments

This document describes the diagnostic assignments in the current
`Azure.AI.Extensions.OpenAI` source. The attributes in a released package may
differ from those in a newer checkout.

An API marked with `System.Diagnostics.CodeAnalysis.ExperimentalAttribute` is
not yet covered by the usual stability guarantees and may change or be removed
in a later release, including a stable release. Using it produces a compiler
diagnostic that must be acknowledged to compile. The attribute does not enable
a service feature or select a service API version.

## Diagnostic IDs

| ID | Current assignment | Examples |
| --- | --- | --- |
| `AAIP001` | Azure-owned experimental surfaces, including intentionally preview Foundry features and certain response operations and extensions. | `A2APreviewTool`, `FabricIQPreviewTool`, `MemorySearchPreviewTool`, `CreateResponseOptionsExtensions`, and the `CreateResponse`/`CreateResponseAsync` extensions taking a conversation. |
| `AAIP002` | Azure surfaces marked experimental because they depend on experimental OpenAI APIs, rather than solely because the Azure feature is intentionally experimental. | `AzureAISearchTool`, `BingGroundingTool`, `AzureFunctionTool`, `OpenApiTool`, their tool-call models, and `ProjectResponsesClient`. |
| `OPENAI001` | The OpenAI dependency's experimental diagnostic, also used on some Azure wrappers of those APIs. | `ProjectConversationsClient`, `ProjectVectorStoresClient`, `ProjectResponsesClientOptions`, response-client factories on `ProjectOpenAIClient`, and response-item and response-tool kind extensions. |
| `OPENAICUA001` | An OpenAI dependency diagnostic for experimental computer-use APIs. | OpenAI's `ResponseTool.CreateComputerTool` and `ComputerToolEnvironment`. |
| `SCME0001` | System.ClientModel's experimental diagnostic on extension properties backed by JSON patch APIs. | `CreateResponseOptionsExtensions.Agent` and `SessionId`, and response-item and response-result extension properties. |
| `SCME0002` | System.ClientModel's experimental diagnostic for settings-based client configuration. | `ProjectOpenAIClientSettings` and the `ProjectOpenAIClient` constructor accepting it. |

`AAIP001` and `AAIP002` are separate opt-ins; suppressing one does not suppress
the other or an upstream diagnostic. `AAIP001` identifies intentional Azure experimental surfaces, while `AAIP002` groups
surfaces affected by the underlying OpenAI dependency. Neither ID by itself
guarantees that the corresponding service feature is generally available.

Assignments are made per declaration, not just by feature name. For example,
`AgentWorkflowPreviewActionResponseItem` has `AAIP002` despite `Preview` in its
name, and some related option models have no experimental attribute. Members
can also have their own IDs: response overrides on `ProjectResponsesClient`
use `AAIP001`, and individual methods on `ExtensionsOpenAIModelFactory` are
annotated separately. Using several APIs together can require several IDs.

## Acknowledging a diagnostic

Suppress only the IDs required by the APIs used. For example:

```csharp
using Azure.AI.Extensions.OpenAI;

#pragma warning disable AAIP001
A2APreviewTool tool = new();
#pragma warning restore AAIP001
```

Alternatively, add the required ID to a project's existing `NoWarn` property:

```xml
<NoWarn>$(NoWarn);AAIP001</NoWarn>
```

Additional OpenAI or System.ClientModel diagnostics may be needed when their
experimental APIs are used directly.
