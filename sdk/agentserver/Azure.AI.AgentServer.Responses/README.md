# Azure AI Agent Server Responses library for .NET

Azure.AI.AgentServer.Responses is a .NET library for building ASP.NET Core servers that implement the [Azure AI Responses API][product_doc]. Add the NuGet package, extend one abstract class (`ResponseHandler`), and the library handles routing, streaming (SSE), background execution, cancellation, caching, and response lifecycle management.

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

The recommended way to start a Responses server is with the built-in one-line API:

```C# Snippet:Responses_ReadMe_ConfigureServer_Tier1
ResponsesServer.Run<EchoHandler>();
```

This starts a Kestrel server with OpenTelemetry, health checks, server user-agent headers, and your handler mapped to the Responses API endpoints. The `Azure.AI.AgentServer.Core` package is included as a transitive dependency.

Alternatively, register the library services manually in your `Program.cs`:

```C# Snippet:Responses_ReadMe_ConfigureServer_Manual
var builder = WebApplication.CreateBuilder();

builder.Services.AddResponsesServer();
builder.Services.AddScoped<ResponseHandler, EchoHandler>();

var app = builder.Build();
app.MapResponsesServer();
app.Run();
```

## Key concepts

### ResponseHandler

The core abstraction you implement. The library calls `CreateAsync` for each incoming request and delivers the returned `IAsyncEnumerable<ResponseStreamEvent>` to clients via SSE.

**`TextResponse` — recommended for text-only responses:**

```C# Snippet:Responses_ReadMe_EchoHandler
public class EchoHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var input = await context.GetInputTextAsync(cancellationToken: ct);
                return $"Echo: {input}";
            });
    }
}
```

**`ResponseEventStream` convenience generators — recommended for multi-output scenarios:**

When `TextResponse` is too simple but the full builder API is more than you need, use the convenience generators on `ResponseEventStream`. They handle all inner events (`output_item.added`, content deltas, `output_item.done`) automatically:

```C# Snippet:Responses_ReadMe_EchoHandler_Convenience
public class EchoHandlerConvenience : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // One call emits all text output events automatically.
        var input = await context.GetInputTextAsync(cancellationToken: cancellationToken);
        foreach (var evt in stream.OutputItemMessage($"Echo: {input}"))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

Available convenience generators:

| Method | Description |
|--------|-------------|
| `OutputItemMessage(string)` | Emits a complete text message output item |
| `OutputItemMessage(IAsyncEnumerable<string>, CancellationToken)` | Streams tokens as `response.output_text.delta` events |
| `OutputItemFunctionCall(name, callId, arguments)` | Emits a complete function call output item |
| `OutputItemReasoningItem(...)` | Emits a reasoning output item |

See [Sample 3 — Full control ResponseStream](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample3_FullControlResponseStream.md) and [Sample 4 — Function calling](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample4_FunctionCalling.md) for more examples.

**`ResponseEventStream` — full builder control:**

Use the full builder API only when you need fine-grained control over individual delta/done events within a content part, or to set custom properties on output items:

```C# Snippet:Responses_ReadMe_EchoHandler_FullControl
public class EchoHandlerFullControl : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
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

Manages `sequenceNumber`, `outputIndex`, `contentIndex`, and `itemId` tracking internally. Each `yield return` maps 1:1 to an SSE event with zero bookkeeping.

### Streaming & Background Modes

- **Streaming mode**: Enabled when the `stream` parameter is `true` (defaults to `false`); SSE events are delivered in real-time to the connected client.
- **Background mode**: The handler runs to completion without a connected SSE client; events are buffered and available for replay via `GET /responses/{id}`. Requires `background=true` and `store=true`.

### Response Lifecycle

The library orchestrates the complete response lifecycle: `created` → `in_progress` → `completed` (or `failed` / `cancelled`). Cancellation, error handling, and terminal event guarantees are all managed automatically.

For detailed handler implementation guidance, see [docs/handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md).

### Thread safety

All service instances registered via `AddResponsesServer()` are thread-safe. Handler instances are scoped per-request.

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples).

## Troubleshooting

### Common errors

- **400 Bad Request**: The request body failed validation. Check that optional fields such as `model` (when provided) are valid and that `input` items are well-formed.
- **404 Not Found**: The response ID does not exist or has expired past the configured TTL.
- **400 Bad Request** (cancel): The response was not created with `background=true`, or it has already reached a terminal state.
- **404 Not Found** (cancel): The response was created with `store=false`, or a non-background response is still in-flight and not findable.

### Logging

The library emits OpenTelemetry traces via `Azure.AI.AgentServer.Responses` activity source. Enable logging in your ASP.NET Core application to diagnose issues.

## Next steps

- [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) — Getting started, function calling, conversation history, multi-output
- [Handler implementation guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) — Detailed reference for building handlers


## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Responses
[rest_api]: https://learn.microsoft.com/azure/foundry/reference/foundry-project#responses-94
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
