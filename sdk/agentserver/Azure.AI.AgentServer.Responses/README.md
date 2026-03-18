# Azure.AI.AgentServer.Responses

A .NET 8 SDK for building ASP.NET Core servers that implement the [Azure AI Responses API](https://learn.microsoft.com/en-us/azure/foundry/reference/foundry-project#responses-94). Add the NuGet package, implement one interface, and the SDK handles routing, streaming (SSE), background execution, cancellation, caching, and response lifecycle management.

## Quick Start

### 1. Install the package

```bash
dotnet add package Azure.AI.AgentServer.Responses
```

### 2. Implement `IResponseHandler`

```csharp
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class MyHandler : IResponseHandler
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

        yield return text.EmitDelta("Hello, ");
        yield return text.EmitDelta("world!");

        yield return text.EmitDone("Hello, world!");
        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

`ResponseEventStream` manages `sequenceNumber`, `outputIndex`, `contentIndex`, `itemId`, and the full `Response` lifecycle automatically — each `yield return` maps 1:1 to an SSE event with zero bookkeeping. The handler never touches the `Response` object directly; it interacts only through `IResponseContext.ResponseId` and the builder API.

### 3. Register and map routes

```csharp
var builder = WebApplication.CreateBuilder(args);

// Register the SDK services and your handler
builder.Services.AddResponsesServer();
builder.Services.AddScoped<IResponseHandler, MyHandler>();

var app = builder.Build();

// Map the Responses API endpoints
app.MapResponsesServer();

app.Run();
```

This gives you five endpoints:

| Method | Route                          | Description                              |
|--------|--------------------------------|------------------------------------------|
| POST   | `/responses`                   | Create a new response                    |
| GET    | `/responses/{responseId}`      | Get response state (JSON or SSE replay)  |
| POST   | `/responses/{responseId}/cancel` | Cancel an in-flight response           |
| DELETE | `/responses/{responseId}`      | Delete a stored response                 |
| GET    | `/responses/{responseId}/input_items` | List input items (paginated)      |

## Features

- **Streaming event builders** — Scoped builders eliminate SSE bookkeeping (see below)
- **Four execution modes** — The SDK automatically handles all combinations of `stream` and `background` flags:
  - **Default** — Run to completion, return final JSON response
  - **Streaming** — Pipe events as SSE in real-time, cancel on client disconnect
  - **Background** — Return immediately, handler runs in the background
  - **Streaming + Background** — SSE while connected, handler continues after disconnect
- **SSE keep-alive** — Automatic keep-alive comments to prevent proxy/load-balancer timeouts
- **Event stream replay** — SSE replay buffers retained per-event with configurable TTL (default: 10 min). JSON GET snapshots available indefinitely
- **Pluggable state provider** — Three focused interfaces (`IResponsesProvider`, `IResponsesCancellationSignalProvider`, `IResponsesStreamProvider`) abstract state persistence, cancellation, and event streaming. Default in-memory implementation included; override any subset for multi-instance deployments
- **Cancellation** — Cancel endpoint triggers cooperative cancellation via `CancellationToken`
- **Graceful shutdown** — Handlers distinguish shutdown from cancel via `context.IsShutdownRequested`. Shutdown-terminated responses are marked `failed` for client retry
- **Content negotiation** — GET endpoint returns JSON snapshot by default, or SSE replay when `?stream=true` query parameter is specified
- **Distributed tracing** — Built-in `ActivitySource` for OpenTelemetry integration
- **Error handling** — Global exception filter maps exceptions to appropriate HTTP responses

## Streaming Event Builder

`ResponseEventStream` provides a scoped, hierarchical builder that mirrors the SSE event nesting. Each scope manages its own bookkeeping — you never touch `sequenceNumber`, `outputIndex`, `contentIndex`, or `itemId`.

```
ResponseEventStream                          → response.queued / created / in_progress / completed / failed / incomplete
  ├─ OutputItemMessageBuilder                → output_item.added / done
  │    ├─ TextContentBuilder                 → content_part.added / text.delta / text.done / content_part.done
  │    │    └─ EmitAnnotationAdded           → output_text.annotation.added
  │    └─ RefusalContentBuilder              → content_part.added / refusal.delta / refusal.done / content_part.done
  ├─ OutputItemFunctionCallBuilder           → output_item.added / function_call_arguments.delta / done / output_item.done
  ├─ OutputItemReasoningItemBuilder          → output_item.added / done
  │    └─ ReasoningSummaryPartBuilder        → summary_part.added / text.delta / text.done / summary_part.done
  ├─ OutputItemFileSearchCallBuilder         → output_item.added / in_progress / searching / completed / done
  ├─ OutputItemWebSearchCallBuilder          → output_item.added / in_progress / searching / completed / done
  ├─ OutputItemCodeInterpreterCallBuilder    → output_item.added / in_progress / code.delta / code.done / completed / done
  ├─ OutputItemImageGenCallBuilder           → output_item.added / in_progress / partial_image / completed / done
  ├─ OutputItemMcpCallBuilder                → output_item.added / in_progress / args.delta / args.done / completed|failed / done
  ├─ OutputItemMcpListToolsBuilder           → output_item.added / in_progress / completed|failed / done
  ├─ OutputItemCustomToolCallBuilder         → output_item.added / input.delta / input.done / done
  └─ OutputItemBuilder<T>                    → output_item.added / done (via AddOutputItem<T> for any OutputItem subtype)
```

All specialized builders (e.g. `OutputItemMessageBuilder`, `OutputItemFunctionCallBuilder`) extend `OutputItemBuilder<T>`, which provides the shared `EmitAdded()` / `EmitDone()` lifecycle.

**Naming convention:** `AddOutputItem*()` methods create child scopes (return builders). `Emit*()` methods produce SSE events (return `ResponseStreamEvent` subtypes).

### Function call response

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var fnCall = stream.AddOutputItemFunctionCall(name: "get_weather", callId: "call_abc123");
yield return fnCall.EmitAdded();
yield return fnCall.EmitArgumentsDelta("{\"location\":");
yield return fnCall.EmitArgumentsDelta("\"San Francisco\"}");
yield return fnCall.EmitArgumentsDone("{\"location\":\"San Francisco\"}");
yield return fnCall.EmitDone();

yield return stream.EmitCompleted();
```

### Text with annotations

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

var text = message.AddTextContent();
yield return text.EmitAdded();

yield return text.EmitDelta("According to the docs");
yield return text.EmitDelta(", the answer is 42.");

// Emit an annotation (e.g. a URL citation)
var citation = AzureAIResponsesServerSdkModelFactory.UrlCitationBody(
    url: new Uri("https://example.com/docs"), title: "Official Docs",
    startIndex: 0, endIndex: 22);
yield return text.EmitAnnotationAdded(citation);

yield return text.EmitDone("According to the docs, the answer is 42.");
yield return message.EmitContentDone(text);
yield return message.EmitDone();

yield return stream.EmitCompleted();
```

### MCP tool call with argument streaming

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var mcp = stream.AddOutputItemMcpCall(serverLabel: "my-mcp-server", name: "search");
yield return mcp.EmitAdded();
yield return mcp.EmitInProgress();

// Stream the arguments incrementally
yield return mcp.EmitArgumentsDelta("{\"query\":");
yield return mcp.EmitArgumentsDelta("\"climate data\"}");
yield return mcp.EmitArgumentsDone("{\"query\":\"climate data\"}");

// Mark as completed (or use EmitFailed() on error)
yield return mcp.EmitCompleted();
yield return mcp.EmitDone();

yield return stream.EmitCompleted();
```

### Multiple output items

Output indices auto-increment across `AddOutputItemMessage()` and `AddOutputItemFunctionCall()` calls:

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

// outputIndex=0
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();
var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitDelta("Let me check the weather.");
yield return text.EmitDone("Let me check the weather.");
yield return message.EmitContentDone(text);
yield return message.EmitDone();

// outputIndex=1 (auto-incremented)
var fnCall = stream.AddOutputItemFunctionCall("get_weather", "call_456");
yield return fnCall.EmitAdded();
yield return fnCall.EmitArgumentsDone("{\"city\":\"NYC\"}");
yield return fnCall.EmitDone();

yield return stream.EmitCompleted();
```

### Generic output item (AddOutputItem)

Use `AddOutputItem<T>()` to wrap any `OutputItem` subtype that doesn't have a dedicated `AddOutputItem*()` factory. Pass a valid item ID (generated via `IdGenerator`), then pass items to `EmitAdded()` and `EmitDone()` — this avoids shared mutable state across events:

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{\"x\":1}");
item.Id = IdGenerator.NewFunctionCallItemId();
var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(item.Id);
yield return builder.EmitAdded(item);

// ... mutate or rebuild item as needed ...

yield return builder.EmitDone(item);

yield return stream.EmitCompleted();
```

### Mixing builders with raw events

Use `NextSequenceNumber()` to get the next sequence number for manually constructed events:

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var message = stream.AddOutputItemMessage();
// ... build message with builders ...

// Raw event using the shared sequence counter
yield return new ResponseErrorEvent(
    sequenceNumber: stream.NextSequenceNumber(),
    code: "custom_warning",
    message: "Something happened",
    param: "");

yield return stream.EmitCompleted();
```

<details>
<summary>Using raw events without builders</summary>

You can also construct all events manually — the builder is optional.
Note: The `Response` object is not exposed by `IResponseContext`; you must construct your own:

```csharp
var response = new Response(context.ResponseId, request.Model ?? string.Empty)
{
    Status = ResponseStatus.InProgress,
};
var itemId = "msg_001";

yield return new ResponseCreatedEvent(sequenceNumber: 0, response: response);
yield return new ResponseInProgressEvent(sequenceNumber: 1, response: response);

var inProgressMsg = new OutputItemOutputMessage(
    id: itemId, content: [], status: OutputItemOutputMessageStatus.InProgress);
yield return new ResponseOutputItemAddedEvent(
    sequenceNumber: 2, outputIndex: 0, item: inProgressMsg);

var emptyPart = new OutputContentOutputTextContent(text: "", annotations: [], logprobs: []);
yield return new ResponseContentPartAddedEvent(
    sequenceNumber: 3, itemId: itemId, outputIndex: 0, contentIndex: 0, part: emptyPart);

yield return new ResponseTextDeltaEvent(
    sequenceNumber: 4, itemId: itemId, outputIndex: 0,
    contentIndex: 0, delta: "Hello, world!", logprobs: []);

yield return new ResponseTextDoneEvent(
    sequenceNumber: 5, itemId: itemId, outputIndex: 0,
    contentIndex: 0, text: "Hello, world!", logprobs: []);

var donePart = new OutputContentOutputTextContent(
    text: "Hello, world!", annotations: [], logprobs: []);
yield return new ResponseContentPartDoneEvent(
    sequenceNumber: 6, itemId: itemId, outputIndex: 0, contentIndex: 0, part: donePart);

var doneContent = new OutputMessageContentOutputTextContent(
    text: "Hello, world!", annotations: [], logprobs: []);
var doneMessage = new OutputItemOutputMessage(
    id: itemId, content: [doneContent], status: OutputItemOutputMessageStatus.Completed);
yield return new ResponseOutputItemDoneEvent(
    sequenceNumber: 7, outputIndex: 0, item: doneMessage);

yield return new ResponseCompletedEvent(sequenceNumber: 8, response: response);
```

</details>

## Configuration

```csharp
builder.Services.AddResponsesServer(options =>
{
    // SSE keep-alive interval to prevent proxy timeouts (default: disabled)
    options.SseKeepAliveInterval = TimeSpan.FromSeconds(15);
});

// In-memory provider options (separate from server options)
builder.Services.Configure<InMemoryProviderOptions>(opts =>
{
    // Per-event SSE replay buffer retention (default: 10 min from emission)
    opts.EventStreamTtl = TimeSpan.FromMinutes(30);
});
```

### Route prefix

```csharp
// Mount at a custom prefix
app.MapResponsesServer(prefix: "/openai/v1");
// Routes become: /openai/v1/responses, /openai/v1/responses/{id}, etc.
```

### Custom Response Provider

For multi-instance deployments, register custom provider implementations before `AddResponsesServer()`. The provider contract is split into three focused interfaces — override any subset:

```csharp
// Override state persistence (e.g., use a database)
builder.Services.AddSingleton<IResponsesProvider, MyDurableProvider>();

// Optionally override cancellation signalling (e.g., use Redis pub/sub)
builder.Services.AddSingleton<IResponsesCancellationSignalProvider, MySignalProvider>();

// Optionally override event streaming (e.g., use a message broker)
builder.Services.AddSingleton<IResponsesStreamProvider, MyStreamProvider>();

builder.Services.AddResponsesServer();
// TryAddSingleton skips the default in-memory implementation for each interface you register
```

See the [handler implementation guide](docs/handler-implementation-guide.md) for the full provider interface contract.

## Response Lifecycle

The SDK manages the `Response` object internally — handlers never touch it directly. `ResponseEventStream` owns a private `Response` that it mutates and embeds in emitted events:

1. **Construction** — `new ResponseEventStream(context, request)` builds a `Response` from the request's `Model`, `Instructions`, and `Metadata`. Alternatively, `new ResponseEventStream(context, response)` takes ownership of a pre-built `Response`.
2. **Lifecycle events** — `EmitQueued()`, `EmitCreated()`, and `EmitInProgress()` each set the response's `Status` before emitting the event. `EmitCreated()` accepts an optional `ResponseStatus` parameter (defaults to `InProgress`; pass `Queued` for the queued flow).
3. **Output accumulation** — Each builder's `EmitDone()` automatically tracks the completed output item in the response's `Output` list.
4. **Terminal events** — `EmitCompleted()`, `EmitFailed()`, and `EmitIncomplete()` set the response's status, timestamp, usage, and computed output text before emitting the event.

```csharp
// Lifecycle events set Status automatically:
yield return stream.EmitQueued();                                      // Status = Queued
yield return stream.EmitCreated();                                     // Status = InProgress (default)
yield return stream.EmitCreated(ResponseStatus.Queued);                // Status = Queued (for queued flow)
yield return stream.EmitInProgress();                                  // Status = InProgress

// Terminal events accept optional parameters:
yield return stream.EmitCompleted(usage);                              // response.completed
yield return stream.EmitFailed(ResponseErrorCode.ServerError,          // response.failed
    "Something went wrong", usage);
yield return stream.EmitIncomplete(                                    // response.incomplete
    ResponseIncompleteDetailsReason.MaxOutputTokens, usage);
```

## Project Structure

```
src/Contracts/             TypeSpec-generated model contracts (Azure.AI.AgentServer.Responses.Contracts)
  ├─ Generated/            Auto-generated model classes
  ├─ Custom/               Hand-written model customizations
  └─ TypeSpec/             TypeSpec definitions and pipeline
src/Sdk/                   Hand-written SDK library (Azure.AI.AgentServer.Responses)
  ├─ Builders/             Streaming event builder classes (OutputItemMessageBuilder, TextContentBuilder, etc.)
  ├─ Exceptions/           API exception types (BadRequestException, ResourceNotFoundException, etc.)
  ├─ Hosting/              ASP.NET Core integration (AddResponsesServer, MapResponsesServer)
  └─ Internal/             Internal plumbing (ResponseMutations, ResponseEndpointHandler, SSE, etc.)
samples/                   Runnable sample servers (see samples/README.md)
tests/Sdk.Tests/           xUnit test project
Sdk.sln                    Solution file (3 projects: Contracts, Sdk, Tests)
Makefile                   Build automation
```

## Samples

The [`samples/`](samples/) directory contains runnable ASP.NET Core servers demonstrating the SDK:

| Sample | Description |
|--------|-------------|
| [GettingStarted](samples/GettingStarted/) | Minimal echo handler — text message in default, streaming, and background modes |
| [FunctionCalling](samples/FunctionCalling/) | Two-turn conversation — server emits a function call, client submits output, server returns result |
| [MultiOutput](samples/MultiOutput/) | Multiple output items — reasoning followed by a text message |
| [ConversationHistory](samples/ConversationHistory/) | Multi-turn with `previous_response_id` — demonstrates `GetHistoryAsync()` and `DefaultFetchHistoryCount` |

Each sample includes a `test.sh` script that starts the server, exercises it with `curl`, and logs full HTTP wireline (request/response headers and bodies). Run all samples at once:

```bash
bash samples/test-all.sh
```

See [samples/README.md](samples/README.md) for details.

## Development

### Dev Container (recommended)

The dev container config is at the **monorepo root** (`.devcontainer/agentserver/`) — the standard named-config pattern for monorepos. This mounts the entire repo so git works, while focusing VS Code on `sdk/agentserver/`.

```bash
# From sdk/agentserver/ — auto-detects devcontainer CLI or falls back to code CLI
make dev
```

Or manually: open the repo root in VS Code → Ctrl+Shift+P → **Reopen in Container** → select **AgentServer**.

For a multi-root workspace (agentserver + monorepo root in explorer), open `agentserver.code-workspace`.

### Prerequisites

- .NET 8/9 SDK
- Node.js (for TypeSpec model generation)

### Build & Test

```bash
make all        # restore → build → test → lint
make build      # dotnet build
make test       # dotnet test (NUnit)
make lint       # dotnet format --verify-no-changes
make format     # dotnet format (auto-fix)
make pack       # dotnet pack → ./nupkg/
make clean      # clean build artifacts
```

### Model Generation

Models are generated from TypeSpec definitions. To regenerate after TypeSpec changes:

```bash
make generate-models
```

## License

See [LICENSE](LICENSE) for details.
