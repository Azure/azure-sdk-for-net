# Azure AI Agent Server Activity library for .NET

`Azure.AI.AgentServer.Activity` is a .NET library for building ASP.NET Core servers that
implement the Azure AI **activity protocol** (`POST /activity/messages`) used by Microsoft 365
and Teams hosted agents. Author a handler, register it with the hosting builder, and the library
handles endpoint routing, session and correlation resolution, error-source classification,
distributed tracing, and the Microsoft 365 Agents SDK bridge for reply delivery.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 8](https://dotnet.microsoft.com/download) or later
- The `Azure.AI.AgentServer.Core` package (installed automatically as a dependency)

### Configure the server

The fastest way to get running is the lambda-registration style:

```csharp
using Azure.AI.AgentServer.Activity;

ActivityServer.Run(handlers =>
{
    handlers.OnMessage(async (context, ct) =>
    {
        var text = context.Activity?.Text ?? string.Empty;
        await context.SendActivityAsync($"You said: {text}", ct);
    });
});
```

Or subclass `ActivityHandler` for a strongly-typed handler:

```csharp
using Azure.AI.AgentServer.Activity;
using Microsoft.AspNetCore.Http;

public sealed class EchoHandler : ActivityHandler
{
    protected override async Task OnMessageAsync(
        HttpRequest request, HttpResponse response,
        ActivityContext context, CancellationToken cancellationToken)
    {
        var text = context.Activity?.Text ?? string.Empty;
        await context.SendActivityAsync($"You said: {text}", cancellationToken);
    }
}

// Program.cs
ActivityServer.Run<EchoHandler>();
```

For more control over service registration and middleware, use `AgentHost.CreateBuilder()`:

```csharp
var builder = AgentHost.CreateBuilder();
builder.AddActivity<EchoHandler>();
builder.Build().Run();
```

## Key concepts

### ActivityHandler

The abstract base class you subclass for activity handling. Override the activity-type hooks you
care about — `OnMessageAsync`, `OnConversationUpdateAsync`, `OnInvokeAsync`,
`OnUnhandledActivityAsync` — or override `HandleAsync` for full control. `OnErrorAsync` provides a
central error hook.

### ActivityHandlerBuilder

A fluent builder for registering activity handlers as lambda delegates. Use `OnMessage`,
`OnActivity(type, ...)`, `OnConversationUpdate`, `OnInvoke`, `OnUnhandledActivity`, and `OnError`.

### ActivityContext

Provides per-request metadata and reply capability to the handler.

| Property | Type | Description |
|----------|------|-------------|
| `ActivityId` | `string` | The inbound activity ID (sanitized). |
| `SessionId` | `string` | Resolved multi-turn session identifier. |
| `ConversationId` | `string?` | The conversation ID from the `x-agent-conversation-id` header. |
| `Activity` | `ActivityMessage?` | The parsed inbound activity. |
| `ClientHeaders` | `IReadOnlyDictionary<string, string>` | Forwarded `x-client-*` headers. |
| `QueryParameters` | `IReadOnlyDictionary<string, StringValues>` | All inbound query parameters. |
| `Isolation` | `IsolationContext` | Platform-injected user / chat isolation keys for scoping state. |
| `IsExpectRepliesMode` | `bool` | Whether replies are collected synchronously into the HTTP response. |

`SendActivityAsync(text, ct)` sends a text reply back to the channel. In `ExpectReplies` mode the
reply is collected in-memory and returned in the HTTP response; otherwise it is delivered through
the Microsoft 365 Agents SDK connector.

### ProactiveMessenger

Sends messages to a conversation *after* the originating turn has completed (for example, from a
background task or timer), using the stored conversation reference.

### Outbound auth models

Reply delivery supports two identity models, selected via `ActivityServerOptions.DigitalWorker`:

- **Simple** (`DigitalWorker = false`, default) — the agent *instance* identity mints the Bot
  Connector token directly.
- **Digital worker** (`DigitalWorker = true`) — the *blueprint* identity with the
  federated-identity (FMI) token exchange.

### Hosting a Microsoft 365 `AgentApplication`

When you already have a Microsoft 365 Agents SDK `AgentApplication`, host it directly and the
library bridges the activity protocol endpoint to it. See the samples for a complete example.

## Examples

Runnable samples live in the [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples)
directory and in the Foundry hosted-agents sample gallery.

## Troubleshooting

- **404 on `/activity/messages`**: Ensure your handler is registered via `AddActivity(...)` on the
  builder, or that you called `ActivityServer.Run(...)`.
- **Replies not delivered**: Confirm the inbound activity carries a `serviceUrl` and conversation
  ID, and that the outbound-auth model (`DigitalWorker`) and connection environment variables match
  your deployment.

## Next steps

- Review the [activity protocol samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples).
- Learn about the shared host in [`Azure.AI.AgentServer.Core`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core).

## Contributing

This project welcomes contributions and suggestions. See the repository
[CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Activity
[product_doc]: https://learn.microsoft.com/azure/ai-foundry/
