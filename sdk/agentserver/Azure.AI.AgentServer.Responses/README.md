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

This starts a Kestrel server with OpenTelemetry, health checks, server version header, inbound request logging, and your handler mapped to the Responses API endpoints. The `Azure.AI.AgentServer.Core` package is included as a transitive dependency.

Alternatively, use `AgentHost.CreateBuilder()` for more control over service registration and middleware:

```C# Snippet:Responses_ReadMe_ConfigureServer_Manual
var builder = AgentHost.CreateBuilder();
builder.AddResponses<EchoHandler>();
builder.Build().Run();
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

Available convenience generators (commonly used):

| Method | Description |
|--------|-------------|
| `OutputItemMessage(string)` | Emits a complete text message output item |
| `OutputItemMessage(string, IEnumerable<Annotation>)` | Emits a text message with file annotations |
| `OutputItemMessage(IAsyncEnumerable<string>, CancellationToken)` | Streams tokens as `response.output_text.delta` events |
| `OutputItemFunctionCall(name, callId, arguments)` | Emits a complete function call output item |
| `OutputItemFunctionCallOutput(callId, output)` | Emits a function call output (no deltas) |
| `OutputItemReasoningItem(...)` | Emits a reasoning output item |
| `OutputItemImageGenCall(resultBase64)` | Emits an image generation result with status transitions |
| `OutputItemStructuredOutputs(output)` | Emits an arbitrary structured JSON output item |

Additional convenience generators are available for computer calls, local shell calls, function shell calls, apply-patch calls, custom tool call outputs, MCP approval requests/responses, and compaction. Each follows the same pattern — accepts domain parameters and yields the complete `output_item.added` → `output_item.done` event pair.

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
        yield return text.EmitTextDone("Hello, world!");

        yield return text.EmitDone();
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
```

### ResponseContext

Injected into every `CreateAsync` call, `ResponseContext` provides access to the client's input, conversation history, and request metadata:

- **`GetInputItemsAsync(resolveReferences, cancellationToken)`** — returns the resolved input items from the request. Item references are resolved to their content by default; pass `resolveReferences: false` to receive them as-is. Computed once and cached.
- **`GetInputTextAsync(resolveReferences, cancellationToken)`** — shorthand that resolves input items and concatenates all text content from `ItemMessage` entries.
- **`GetHistoryAsync(cancellationToken)`** — returns output items from previous responses in the conversation chain (oldest-first). Uses `previous_response_id` to walk the conversation and resolves items via the provider. Limit controlled by `ResponsesServerOptions.DefaultFetchHistoryCount` (default: 100).
- **`ResponseId`** — the unique ID for this response, used to construct child item IDs.
- **`ClientHeaders`** — forwarded HTTP headers from the original client request.
- **`QueryParameters`** — query parameters from the original request.
- **`RawBody`** — the raw request body as `BinaryData` for advanced scenarios.
- **`Isolation`** — isolation context (tenant/session) extracted from request headers.

For collections of `Item` objects, the `GetInputText()` extension method (on `IEnumerable<Item>`) extracts and joins text content without needing a `ResponseContext`.

See the [handler implementation guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#responsecontext) for the full `ResponseContext` API reference.

### ResponseEventStream

Manages `sequenceNumber`, `outputIndex`, `contentIndex`, and `itemId` tracking internally. Each `yield return` maps 1:1 to an SSE event with zero bookkeeping.

### Streaming & Background Modes

- **Streaming mode**: Enabled when the `stream` parameter is `true` (defaults to `false`); SSE events are delivered in real-time to the connected client.
- **Background mode**: The handler runs to completion without a connected SSE client; events are buffered and available for replay via `GET /responses/{id}`. Requires `background=true` and `store=true`.

### Response Lifecycle

The library orchestrates the complete response lifecycle: `created` → `in_progress` → `completed` (or `failed` / `cancelled`). Cancellation, error handling, and terminal event guarantees are all managed automatically.

For detailed handler implementation guidance, see [docs/handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md).

### Input validation

The library eagerly validates `previous_response_id` and `conversation.id` before starting handler execution:

- **Format validation** — IDs that don't match the expected format return `400 Bad Request` with `param` identifying the invalid field.
- **Existence check** — `previous_response_id` values that pass format validation but reference a nonexistent response return `404 Not Found` with a structured error containing `code` and `param`.

This means handlers can rely on `ResponseContext.GetInputItemsAsync()` and `GetHistoryAsync()` returning valid data — invalid references are caught before `CreateAsync` is called.

### Structured error responses

All error responses follow the same JSON structure:

```json
{
  "error": {
    "code": "invalid_request_error",
    "message": "The response 'resp_abc123' was not found.",
    "param": "previous_response_id",
    "type": "invalid_request_error"
  }
}
```

Exception types carry structured fields that map to the error body:

| Exception | HTTP status | `error.code` | `error.param` |
|-----------|-------------|--------------|----------------|
| `PayloadValidationException` | 400 | `invalid_request_error` | Per-field errors |
| `BadRequestException` | 400 | Caller-provided or `invalid_request_error` | Caller-provided |
| `ResourceNotFoundException` | 404 | Caller-provided or `not_found` | Caller-provided |
| `ResponsesApiException` | 500 | Upstream code or `server_error` | — |

### Request correlation

Every response includes an `x-request-id` header (set by Core's `RequestIdMiddleware`). Error responses also embed the same value in `error.additionalInfo.request_id`, so clients can correlate errors to specific requests even when headers are stripped by intermediaries.

### Error source classification

All error responses (4xx/5xx) include the `x-platform-error-source` header classifying the error origin as `user`, `platform`, or `upstream`. See the [Core README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core#error-source-classification) for the full classification table.

### Chat isolation and session ID

When the platform injects `x-agent-user-isolation-key` and `x-agent-chat-isolation-key` request headers, the library forwards them to the storage provider so that responses are scoped to the correct tenant and conversation. The resolved session ID is returned on every response via the `x-agent-session-id` header.

Handlers can access the isolation context through `ResponseContext.Isolation` for custom partitioning logic.

### Persistence resilience

When storage operations fail (e.g., Foundry storage is unreachable), responses complete gracefully instead of crashing:

- The response reaches a terminal state with `status: "failed"` and `error.code: "storage_error"`.
- For streaming responses, the terminal SSE event is replaced with `response.failed` carrying `error_code="storage_error"`.
- For synchronous responses, the error is returned as an HTTP 500 with the storage error details.

This ensures clients always receive a definitive terminal state rather than hanging indefinitely.

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
