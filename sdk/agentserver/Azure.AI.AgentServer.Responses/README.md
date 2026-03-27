# Azure AI Agent Server Responses library for .NET

Azure.AI.AgentServer.Responses is a .NET library for building ASP.NET Core servers that implement the [Azure AI Responses API][product_doc]. Add the NuGet package, implement one interface (`IResponseHandler`), and the library handles routing, streaming (SSE), background execution, cancellation, caching, and response lifecycle management.

[Source code][source] | [Package (NuGet)][nuget] | [REST API reference][rest_api] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 8.0](https://dotnet.microsoft.com/download) or later
- An ASP.NET Core application

### Configure the server

The recommended way to start a Responses server is with the Hosting package's one-line API:

```C# Snippet:Responses_ReadMe_ConfigureServer_Tier1
ResponsesServer.Run<EchoHandler>();
```

This starts a Kestrel server with OpenTelemetry, health checks, server user-agent headers, and your handler mapped to the Responses API endpoints. Install the `Azure.AI.AgentServer.Core` package for this approach.

Alternatively, register the library services manually in your `Program.cs`:

```C# Snippet:Responses_ReadMe_ConfigureServer_Manual
var builder = WebApplication.CreateBuilder();

builder.Services.AddResponsesServer();
builder.Services.AddScoped<IResponseHandler, EchoHandler>();

var app = builder.Build();
app.MapResponsesServer();
app.Run();
```

## Key concepts

### IResponseHandler

The core abstraction you implement. The library calls `CreateAsync` for each incoming request and delivers the returned `IAsyncEnumerable<ResponseStreamEvent>` to clients via SSE:

```C# Snippet:Responses_ReadMe_EchoHandler
public class EchoHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("Hello, world!");
        yield return text.EmitDone("Hello, world!");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
```

### ResponseEventStream

Manages `sequenceNumber`, `outputIndex`, `contentIndex`, `itemId`, and the full `Response` lifecycle automatically. Each `yield return` maps 1:1 to an SSE event with zero bookkeeping.

### Streaming & Background Modes

- **Streaming mode** (default): SSE events are delivered in real-time to the connected client.
- **Background mode**: The handler runs to completion without a connected SSE client; events are buffered and available for replay via `GET /responses/{id}`.

### Response Lifecycle

The library orchestrates the complete response lifecycle: `created` → `in_progress` → `completed` (or `failed` / `cancelled`). Cancellation, error handling, and terminal event guarantees are all managed automatically.

For detailed handler implementation guidance, see [docs/handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md).

### Thread safety

All service instances registered via `AddResponsesServer()` are thread-safe. Handler instances are scoped per-request.

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples).

## Troubleshooting

### Common errors

- **400 Bad Request**: The request body failed validation. Check that required fields (`model`) are present and that `input` items are well-formed.
- **404 Not Found**: The response ID does not exist or has expired past the configured TTL.
- **409 Conflict**: A cancellation was attempted on a response that has already reached a terminal state.

### Logging

The library emits OpenTelemetry traces via `Azure.AI.AgentServer.Responses` activity source. Enable logging in your ASP.NET Core application to diagnose issues.

## Next steps

- [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) — Getting started, function calling, conversation history, multi-output
- [Handler implementation guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) — Detailed reference for building handlers
- [API behaviour contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) — Protocol-level specification

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Responses
[rest_api]: https://learn.microsoft.com/azure/foundry/reference/foundry-project#responses-94
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
