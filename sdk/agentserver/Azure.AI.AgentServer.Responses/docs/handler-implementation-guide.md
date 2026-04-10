# Handler Implementation Guide

> Developer guidance for implementing `ResponseHandler` — the single integration point for building Azure AI Responses API servers with this library.

---

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [TextResponse](#textresponse)
- [Server Registration](#server-registration)
- [ResponseHandler](#responsehandler)
- [ResponseEventStream](#responseeventstream)
  - [Method Naming Conventions](#method-naming-conventions)
  - [Setting Custom Metadata](#setting-custom-metadata)
  - [Builder Pattern](#builder-pattern)
- [ResponseContext](#responsecontext)
- [Emitting Output](#emitting-output)
  - [Text Messages](#text-messages)
  - [Function Calls (Tool Use)](#function-calls-tool-use)
  - [Function Call Output](#function-call-output)
  - [Reasoning Items](#reasoning-items)
  - [Multiple Output Items](#multiple-output-items)
  - [Other Tool Call Types](#other-tool-call-types)
  - [MCP Terminal State](#mcp-terminal-state)
- [Handling Input](#handling-input)
- [Cancellation](#cancellation)
- [Error Handling](#error-handling)
  - [Validation Pipeline](#validation-pipeline)
- [Response Lifecycle](#response-lifecycle)
  - [Terminal Event Requirement](#terminal-event-requirement)
  - [Signalling Incomplete](#signalling-incomplete)
  - [Token Usage Reporting](#token-usage-reporting)
- [RawBody Access](#rawbody-access)
- [Configuration](#configuration)
  - [Distributed Tracing](#distributed-tracing)
  - [TTL Eviction](#ttl-eviction)
  - [SSE Keep-Alive](#sse-keep-alive)
- [Best Practices](#best-practices)
- [Common Mistakes](#common-mistakes)

---

## Overview

The library handles all protocol concerns — routing, serialization, SSE framing, `stream`/`background` mode negotiation, status lifecycle, and error shapes. You extend **one abstract class**: `ResponseHandler`. Your handler receives a `CreateResponse` request and yields SSE events via `IAsyncEnumerable<ResponseStreamEvent>`. The library wraps these events into the correct HTTP response format based on the client's requested mode.

You do **not** need to think about:
- Whether the client requested JSON or SSE streaming
- Whether the response is running in the foreground or background
- HTTP status codes, content types, or error envelopes
- Sequence numbers or response IDs

The library manages all of this. Your handler just yields events.

For most handlers, `TextResponse` eliminates even the event plumbing — you provide text (or a stream of tokens) and the library does the rest. For full control over every SSE event, use `ResponseEventStream`.

---

## Getting Started

### Minimal Handler

The simplest handler uses `TextResponse` — a convenience class that handles the full SSE event lifecycle for text-only responses:

```csharp
using Azure.AI.AgentServer.Responses;

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

### Running the Server

```csharp
ResponsesServer.Run<EchoHandler>(args);
```

That's it. One line starts a Kestrel host with OpenTelemetry, health checks, identity headers, and all Responses protocol endpoints (`POST /responses`, `GET /responses/{id}`, `POST /responses/{id}/cancel`, and more).

**Next steps**: See [TextResponse](#textresponse) for streaming text and more patterns. For full SSE control (function calls, reasoning items, multiple outputs), see [ResponseEventStream](#responseeventstream). For hosting options beyond the one-liner, see [Server Registration](#server-registration).

---

## TextResponse

A standalone convenience class for the most common case — returning a single text message. `TextResponse` implements `IAsyncEnumerable<ResponseStreamEvent>` and handles the full event lifecycle internally (created → in_progress → message → content → deltas → completed).

### Complete Text

When you have the full text available at once:

```csharp
public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken cancellationToken)
{
    return new TextResponse(context, request,
        createText: async ct =>
        {
            var answer = await _model.GenerateAsync(await context.GetInputTextAsync(cancellationToken: ct), ct);
            return answer;
        });
}
```

### Streaming Text

When an LLM produces tokens incrementally:

```csharp
public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken cancellationToken)
{
    return new TextResponse(context, request,
        createTextStream: GenerateTokensAsync);
}

private static async IAsyncEnumerable<string> GenerateTokensAsync(
    [EnumeratorCancellation] CancellationToken ct)
{
    // Replace with actual LLM call
    var tokens = new[] { "Hello", ", ", "world", "!" };
    foreach (var token in tokens)
    {
        await Task.Delay(50, ct);
        yield return token;
    }
}
```

### Setting Response Properties

Use the optional `configure` callback to set properties like `Temperature` or `MaxOutputTokens` before the `response.created` event:

```csharp
return new TextResponse(context, request,
    configure: response =>
    {
        response.Temperature = 0.7;
        response.MaxOutputTokens = 1024;
    },
    createText: ct => Task.FromResult("Hello!"));
```

### When to Use TextResponse vs ResponseEventStream

| Use `TextResponse` when... | Use `ResponseEventStream` when... |
|---|---|
| Your handler returns a single text message | You need multiple output types (reasoning + message, function calls) |
| You want minimal boilerplate | You need fine-grained delta control |
| The focus of your handler is business logic, not event plumbing | You need to emit function calls, reasoning items, or tool calls |

---

## Server Registration

### Tier 1: One-Line Startup (Recommended)

The simplest way to start a Responses server is with the `Azure.AI.AgentServer.Core` package:

```csharp
using Azure.AI.AgentServer.Responses;

ResponsesServer.Run<MyHandler>(args);
```

This creates a Kestrel host with OpenTelemetry, health checks, identity headers, and the Responses protocol endpoints — all in one line.

### Tier 2: Builder Pattern

For more control over the host configuration:

```csharp
using Azure.AI.AgentServer.Responses;

var builder = AgentHost.CreateBuilder(args);
builder.AddResponses<MyHandler>();
var app = builder.Build();
app.Run();
```

### Tier 3: Manual Setup (Without Core)

If you don't use the Core package, register services and map endpoints directly:

#### Basic Setup

```csharp
builder.Services.AddResponsesServer();
builder.Services.AddSingleton<ResponseHandler, MyHandler>();
```

#### With Options

```csharp
builder.Services.AddResponsesServer(options =>
{
    options.DefaultFetchHistoryCount = 50; // Limit history resolution (default: 100)
});

// Configure in-memory provider TTLs separately
builder.Services.Configure<InMemoryProviderOptions>(opts =>
{
    opts.EventStreamTtl = TimeSpan.FromMinutes(5);   // How long SSE replay is available (default: 10 min)
});
```

### Route Mapping

```csharp
app.MapResponsesServer();
```

This maps five endpoints:
- `POST /responses` — Create a response
- `GET /responses/{responseId}` — Retrieve a response (JSON or SSE replay)
- `POST /responses/{responseId}/cancel` — Cancel a response
- `DELETE /responses/{responseId}` — Delete a response
- `GET /responses/{responseId}/input_items` — List input items (paginated)

**Startup validation**: `MapResponsesServer()` throws `InvalidOperationException` if no `ResponseHandler` is registered. This fail-fast behaviour ensures misconfigured servers are caught at startup, not at the first request.

### Custom Response Provider

The server delegates state persistence, event streaming, and cancellation to three pluggable provider abstract classes. The default in-memory implementation works for single-instance deployments.

#### Provider Abstract Class Split

The provider contract is split into **three focused abstract classes**, each with a single responsibility:

| Abstract class | Responsibility | Methods |
|---|---|---|
| `ResponsesProvider` | State persistence (CRUD for responses, input items, history) | `CreateResponseAsync`, `GetResponseAsync`, `UpdateResponseAsync`, `DeleteResponseAsync`, `GetInputItemsAsync`, `GetItemsAsync`, `GetHistoryItemIdsAsync` |
| `ResponsesCancellationSignalProvider` | Cancellation signal coordination | `CancelResponseAsync`, `GetResponseCancellationTokenAsync` |
| `ResponsesStreamProvider` | SSE event streaming (publish/subscribe) | `CreateEventPublisherAsync`, `SubscribeToEventsAsync` |

The default in-memory provider extends `ResponsesProvider` and provides companion adapters for cancellation and streaming. You can override **any subset** — the library falls back to the in-memory implementation for unregistered types.

```csharp
// Override only state persistence (e.g., use a database)
services.AddSingleton<ResponsesProvider, MyDatabaseProvider>();

// Override only cancellation (e.g., use Redis pub/sub)
services.AddSingleton<ResponsesCancellationSignalProvider, MyRedisSignalProvider>();

// Override state with companion adapters for cancellation and streaming
services.AddSingleton<ResponsesProvider, MyProvider>();
services.AddSingleton<ResponsesCancellationSignalProvider>(sp =>
    sp.GetRequiredService<MyProvider>().AsCancellationProvider());
services.AddSingleton<ResponsesStreamProvider>(sp =>
    sp.GetRequiredService<MyProvider>().AsStreamProvider());
```

When deployed to Azure AI Foundry, durable persistence is enabled by default — no custom provider registration is needed. Custom pluggable persistence is not yet supported but is coming soon.

---

## ResponseHandler

```csharp
public abstract class ResponseHandler
{
    public abstract IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken);
}
```

| Parameter | Purpose |
|---|---|
| `request` | The deserialized `CreateResponse` body from the client (model, input, tools, instructions, etc.) |
| `context` | Provides the response ID and ID generation helpers |
| `cancellationToken` | Triggered on cancellation (explicit `/cancel` call or client disconnection for non-background) |

Your handler is an `IAsyncEnumerable` — you `yield return` events one at a time. The library consumes them, assigns sequence numbers, manages the response lifecycle, and delivers them to the client.

---

## ResponseEventStream

For full control over every SSE event — multiple output types, custom Response properties, streaming deltas — use `ResponseEventStream`. This is the lower-level counterpart to `TextResponse`:

```csharp
using Azure.AI.AgentServer.Responses;

public class EchoHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var stream = new ResponseEventStream(context, request);

        // 1. Signal response creation
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // 2. Build and emit output
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("Hello, world!");
        yield return text.EmitDone("Hello, world!");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        // 3. Signal completion
        yield return stream.EmitCompleted();
    }
}
```

Create a `ResponseEventStream` at the start of your handler:

```csharp
var stream = new ResponseEventStream(context, request);
```

It provides:

| Category | Methods / Properties |
|---|---|
| **Response** | `Response` — the underlying `Response` object. Set custom `Metadata` or `Instructions` before `EmitCreated()` |
| **Lifecycle** | `EmitCreated()`, `EmitInProgress()`, `EmitQueued()`, `EmitCompleted()`, `EmitFailed()`, `EmitIncomplete()` |
| **Output factories** | `AddOutputItemMessage()`, `AddOutputItemFunctionCall()`, `AddOutputItemReasoningItem()`, `AddOutputItemCodeInterpreterCall()`, `AddOutputItemFileSearchCall()`, `AddOutputItemWebSearchCall()`, `AddOutputItemImageGenCall()`, `AddOutputItemMcpCall()`, `AddOutputItemCustomToolCall()`, `AddOutputItemStructuredOutputs()`, `AddOutputItemComputerCall()`, `AddOutputItemLocalShellCall()`, `AddOutputItemApplyPatchCall()`, `AddOutputItemMcpApprovalRequest()`, `AddOutputItemCompaction()`, and more |

### Setting Custom Metadata

Use the `Response` property to set custom metadata or instructions before emitting the created event:

```csharp
var stream = new ResponseEventStream(context, request);

// Set custom metadata (preserved in all response.* events)
stream.Response.Metadata = new Metadata
{
    ["handler_version"] = "2.0",
    ["region"] = "us-west-2",
};

// Set custom instructions (preserved in final response)
stream.Response.Instructions = BinaryData.FromObjectAsJson("You are a helpful assistant.");

yield return stream.EmitCreated();
```

If the handler does not set `Metadata` or `Instructions`, the library automatically copies them from the original `CreateResponse` request.

The library also auto-populates `Conversation` and `PreviousResponseId` on the `Response` from the original request:

- **`Conversation`** — set to a `ConversationReference` with the request's `conversation_id` (if present), enabling conversation chain tracking.
- **`PreviousResponseId`** — set to the request's `previous_response_id` (if present), linking responses in a chain.

Handlers do not need to set these — they are populated automatically in the `ResponseEventStream` constructor.

**Important**: Do not add output items directly to `stream.Response.Output`. Use the output builder factories instead — the library tracks output items through `output_item.added` events and will detect direct manipulation as a handler error.

**Every `ResponseEventStream` handler must**:
1. Call `stream.EmitCreated()` first — this creates the `response.created` SSE event. **This is mandatory and must be the first event yielded.** No response is persisted before this event.
2. Call `stream.EmitInProgress()` — this creates the `response.in_progress` SSE event.
3. Emit output items using the builder factories.
4. End with exactly one terminal event: `stream.EmitCompleted()`, `stream.EmitFailed()`, or `stream.EmitIncomplete()`.

**Bad handler consequences** — if the handler violates this contract:

| Violation | Library Behaviour |
|-----------|--------------|
| First event is not `response.created` | HTTP 500 error, handler CT cancelled, no persistence |
| `Response.Id` doesn't match `ResponseContext.ResponseId` | HTTP 500 error, handler CT cancelled, no persistence (FR-006) |
| `Response.Status` is terminal on `response.created` | HTTP 500 error, handler CT cancelled, no persistence (FR-007) |
| Direct `Response.Output` manipulation detected | Post-created: `response.failed`; pre-created: HTTP 500 (FR-008a) |
| Empty enumerable (no events) | HTTP 500 error, handler CT cancelled, no persistence |
| Throws before `response.created` | HTTP 500 error, no persistence |
| Ends without terminal event or error | The library emits `response.failed` automatically (FR-009) |
| Throws after `response.created` | The library emits `response.failed`, persists failed state |

All violations are logged with handler type name and request ID for diagnostics.

> **Note**: `TextResponse` handles all lifecycle events internally — the contract above applies only when you use `ResponseEventStream` directly.

### Builder Pattern

Output is constructed through a **builder hierarchy** that enforces correct event ordering:

```
ResponseEventStream
  └── OutputItemBuilder (message, function call, reasoning, etc.)
        └── Content builders (text, refusal, summary, etc.)
```

Each builder tracks its lifecycle state (`NotStarted` → `Added` → `Done`) and will throw if you emit events out of order. This prevents protocol violations at development time rather than runtime.

**Key rule**: Every builder that you start (`EmitAdded`) must be finished (`EmitDone`). Unfinished builders result in malformed responses.

### Method Naming Conventions

`ResponseEventStream` and its builders use a consistent naming scheme. Knowing the three prefixes tells you what any method does at a glance:

#### Stream-level methods (`ResponseEventStream`)

| Prefix | Example | Returns | Purpose |
|--------|---------|---------|----------|
| `Emit*` | `EmitCreated()`, `EmitCompleted()` | A single `ResponseStreamEvent` | Produce one response-lifecycle event |
| `Add*` | `AddOutputItemMessage()`, `AddOutputItemFunctionCall(...)` | A **builder** object | Create a builder for step-by-step, fine-grained event emission |
| `OutputItem*` | `OutputItemMessage(text)`, `OutputItemFunctionCall(...)` | `IEnumerable` or `IAsyncEnumerable` of events | **Convenience generator** — yields the complete output-item lifecycle in one call |

#### Builder-level methods (e.g. `OutputItemMessageBuilder`)

| Prefix | Example | Returns | Purpose |
|--------|---------|---------|----------|
| `Emit*` | `EmitAdded()`, `EmitDone()`, `EmitDelta(chunk)` | A single event | Produce one event in the builder's lifecycle |
| `Add*` | `AddTextContent()`, `AddSummaryPart()` | A **child builder** | Create a nested content builder for sub-items |
| *(content name)* | `TextContent(text)`, `Arguments(args)`, `SummaryPart(text)` | `IEnumerable` or `IAsyncEnumerable` of events | **Sub-item convenience** — yields the complete content-part lifecycle in one call |

**Rule of thumb**: If a method returns a single event, it starts with `Emit`. If it returns a builder, it starts with `Add`. If it returns an enumerable of events, it's a convenience generator named after the content it produces.

Every convenience generator has two overloads:

| Overload | Signature pattern | Use when |
|----------|-------------------|----------|
| **Complete** | Takes a `string` → returns `IEnumerable<ResponseStreamEvent>` | You have the full value up-front |
| **Streaming** | Takes an `IAsyncEnumerable<string>` → returns `IAsyncEnumerable<ResponseStreamEvent>` | You're receiving chunks from a model or service |

> **Tip**: Start with convenience generators. Drop down to `Add*` builders only when you need fine-grained control (e.g., multiple content parts in one message, custom properties on the output item, or interleaving non-content work between events).

---

## ResponseContext

```csharp
public class ResponseContext
{
    public string ResponseId { get; }
    public bool IsShutdownRequested { get; set; }
    public virtual BinaryData? RawBody { get; }
    public virtual Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default);
    public virtual Task<string> GetInputTextAsync(bool resolveReferences = true, CancellationToken cancellationToken = default);
    public virtual Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default);
    public virtual IsolationContext Isolation { get; }
    public virtual IReadOnlyDictionary<string, string> ClientHeaders { get; }
    public virtual IReadOnlyDictionary<string, StringValues> QueryParameters { get; }
}
```

Provides the library-generated response ID, shutdown signalling, access to resolved input and history items, forwarded client headers, and query parameters from the original request.

### Input Items — `GetInputItemsAsync()`

Returns the caller's input items as their `Item` subtypes:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken ct)
{
    var inputItems = await context.GetInputItemsAsync(cancellationToken: ct);
    // inputItems contains ItemMessage, FunctionCallOutputItemParam, etc.
    // Inline items are returned directly; item references are resolved via the provider
}
```

- **Inline items** are returned as-is — the same `Item` subtypes from the original request (e.g., `ItemMessage`, `FunctionCallOutputItemParam`, `ItemFunctionToolCall`).
- **Item references** (e.g., `{"type":"item_reference","id":"msg_123"}`) are batch-resolved via `ResponsesProvider.GetItemsAsync` and converted back to their corresponding `Item` subtypes.
- **`resolveReferences` parameter** — pass `false` to skip reference resolution and receive `ItemReferenceParam` instances as-is: `await context.GetInputItemsAsync(resolveReferences: false, cancellationToken: ct)`.
- **Input order is preserved** — items are returned in the same order as in the request.
- **Lazy singleton** — the result is computed once on first call and cached per `resolveReferences` mode. Subsequent calls return the same instance. Thread-safe.

### Input Text — `GetInputTextAsync()`

A convenience that resolves input items and extracts all text content as a single string:

```csharp
var text = await context.GetInputTextAsync(cancellationToken: ct);
// Equivalent to: (await context.GetInputItemsAsync(cancellationToken: ct)).GetInputText()
```

You can also use the `GetInputText()` extension on any `IEnumerable<Item>`:

```csharp
var items = await context.GetInputItemsAsync(cancellationToken: ct);
var text = items.GetInputText(); // filters for ItemMessage, joins text content
```

### Conversation History — `GetHistoryAsync()`

Returns resolved output items from previous responses in the conversation chain:

```csharp
var history = await context.GetHistoryAsync(ct);
// history contains OutputItem instances from previous responses
// Empty if no previous_response_id or conversation context
```

- **Two-step resolution**: First resolves history item IDs via `ResponsesProvider.GetHistoryItemIdsAsync`, then fetches actual items via `GetItemsAsync`.
- **Ascending order** — items are returned oldest-first (ascending by position).
- **Configurable limit** — controlled by `ResponsesServerOptions.DefaultFetchHistoryCount` (default: 100).
- **Lazy singleton** — computed once and cached, like `GetInputItemsAsync`.

### Client Headers — `ClientHeaders`

Returns `x-client-*` prefixed headers forwarded from the original HTTP request. These headers enable end-to-end tracing context and client metadata to flow through the server:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken ct)
{
    // Access forwarded client headers (e.g., x-client-request-id, x-client-trace-id)
    var clientHeaders = context.ClientHeaders;

    if (clientHeaders.TryGetValue("x-client-request-id", out var requestId))
    {
        // Use the client's request ID for correlation
    }

    // ... emit events
}
```

- **Prefix filtering**: Only headers with the `x-client-` prefix are included.
- **Read-only**: The dictionary is immutable — values cannot be modified by the handler.
- **Empty if no matching headers**: Returns an empty dictionary when the request contains no `x-client-*` headers.

### Query Parameters — `QueryParameters`

Returns all query parameters from the original HTTP request:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken ct)
{
    var queryParams = context.QueryParameters;

    if (queryParams.TryGetValue("model_override", out var modelOverride))
    {
        // Use a custom query parameter for handler logic
    }

    // ... emit events
}
```

- **All query parameters**: Unlike `ClientHeaders`, this includes all query string key-value pairs, not just prefixed ones.
- **Multi-valued**: Values are `StringValues`, supporting multiple values for the same key.
- **Read-only**: The dictionary is immutable.

### ID Generation Extensions

Extension methods on `ResponseContext` generate correctly-prefixed IDs for child items:

| Method | Prefix | Use For |
|---|---|---|
| `context.NewMessageItemId()` | `msg_` | Message output items |
| `context.NewFunctionCallItemId()` | `fc_` | Function call output items |
| `context.NewReasoningItemId()` | `rs_` | Reasoning items |
| `context.NewFileSearchCallItemId()` | `fs_` | File search tool calls |
| `context.NewWebSearchCallItemId()` | `ws_` | Web search tool calls |
| `context.NewCodeInterpreterCallItemId()` | `ci_` | Code interpreter calls |
| `context.NewImageGenCallItemId()` | `ig_` | Image generation calls |
| `context.NewMcpCallItemId()` | `mcp_` | MCP tool calls |
| `context.NewMcpListToolsItemId()` | `mcpl_` | MCP list tools items |
| `context.NewCustomToolCallItemId()` | `ctc_` | Custom tool calls |

You typically don't need to call these directly — the builders handle ID generation internally. They're available if you need IDs before creating a builder.

---

## Emitting Output

Each output type can be emitted using either **convenience generators** (recommended — less code, correct by construction) or **builders** (when you need fine-grained control). The examples below show both, starting with the simpler approach.

> **Tip**: For simple text-only responses, [`TextResponse`](#textresponse) is even simpler than `ResponseEventStream` — it handles the entire event lifecycle in a single line.

### Text Messages

#### Using conveniences

The simplest way to emit a text message — one call per output item:

```csharp
var stream = new ResponseEventStream(context, request);
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

// Complete text — full value up-front
foreach (var evt in stream.OutputItemMessage("Hello, world!"))
    yield return evt;

yield return stream.EmitCompleted();
```

Streaming from an LLM:

```csharp
await foreach (var evt in stream.OutputItemMessage(GetTokenStream(cancellationToken), cancellationToken))
    yield return evt;
```

If you need the builder for other reasons (e.g., setting properties) but still want convenience for the content part:

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

foreach (var evt in message.TextContent("Hello, world!"))
    yield return evt;

yield return message.EmitDone();
```

#### Using builders (fine-grained control)

When you need multiple content parts in one message (e.g., text + refusal), emit refusal content, set custom properties on the output item, or interleave non-event work between builder calls:

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

var text = message.AddTextContent();
yield return text.EmitAdded();

// Stream text incrementally (deltas are sent to the client in real-time)
yield return text.EmitDelta("First chunk of text. ");
yield return text.EmitDelta("Second chunk. ");

// Finalise the text content (final text = full accumulated text)
yield return text.EmitDone("First chunk of text. Second chunk. ");

yield return message.EmitContentDone(text);
yield return message.EmitDone();
```

**Tip**: For streaming, emit small deltas frequently for a responsive feel. For non-streaming mode, the library accumulates everything and delivers the final JSON — so delta granularity doesn't affect the JSON response, only SSE streaming UX.

### Function Calls (Tool Use)

When your handler needs the client to execute a function (tool) and return the result.

#### Using conveniences

```csharp
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var args = JsonSerializer.Serialize(new { location = "Seattle" });
foreach (var evt in stream.OutputItemFunctionCall("get_weather", "call_1", args))
    yield return evt;

yield return stream.EmitCompleted();
```

#### Using builders (fine-grained control)

```csharp
var funcCall = stream.AddOutputItemFunctionCall("get_weather", "call_weather_1");
yield return funcCall.EmitAdded();

var arguments = JsonSerializer.Serialize(new { location = "Seattle", unit = "fahrenheit" });
yield return funcCall.EmitArgumentsDelta(arguments);
yield return funcCall.EmitArgumentsDone(arguments);
yield return funcCall.EmitDone();
```

The client receives the function call, executes it locally, and sends a new request with the function output as input. Your handler then processes the result on the next turn.

#### Multi-Turn Function Calling

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    await Task.CompletedTask;
    var stream = new ResponseEventStream(context, request);
    var inputItems = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

    // Check if this is a follow-up with function output
    var toolOutput = inputItems.OfType<FunctionCallOutputItemParam>().FirstOrDefault();

    if (toolOutput is not null)
    {
        // Turn 2+: Process the function result and respond
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        foreach (var evt in stream.OutputItemMessage($"The result is: {toolOutput.Output}"))
            yield return evt;

        yield return stream.EmitCompleted();
    }
    else
    {
        // Turn 1: Request a function call
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var args = JsonSerializer.Serialize(new { location = "Seattle" });
        foreach (var evt in stream.OutputItemFunctionCall("get_weather", "call_weather_1", args))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

### Function Call Output

When your handler itself executes a tool and includes the output in the response (no client round-trip):

```csharp
foreach (var evt in stream.OutputItemFunctionCallOutput("call_weather_1", BinaryData.FromString(weatherJson)))
    yield return evt;
```

Function call outputs have no deltas — only `output_item.added` and `output_item.done`.

### Reasoning Items

Emit reasoning (chain-of-thought) before the main response.

#### Using conveniences

```csharp
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

// Output 0: Reasoning
foreach (var evt in stream.OutputItemReasoningItem("Let me think about this..."))
    yield return evt;

// Output 1: Message with the answer
foreach (var evt in stream.OutputItemMessage("The answer is 42."))
    yield return evt;

yield return stream.EmitCompleted();
```

#### Using builders (fine-grained control)

```csharp
var reasoning = stream.AddOutputItemReasoningItem();
yield return reasoning.EmitAdded();

var summary = reasoning.AddSummaryPart();
yield return summary.EmitAdded();
yield return summary.EmitTextDelta("Let me think about this...");
yield return summary.EmitTextDone("Let me think about this...");
yield return summary.EmitDone();
reasoning.EmitSummaryPartDone(summary);
yield return reasoning.EmitDone();
```

### Multiple Output Items

A single response can contain multiple output items. Each gets an auto-incrementing output index:

```csharp
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

// Output 0
foreach (var evt in stream.OutputItemMessage("First message."))
    yield return evt;

// Output 1
foreach (var evt in stream.OutputItemMessage("Second message."))
    yield return evt;

yield return stream.EmitCompleted();
```

### Other Tool Call Types

The library provides specialised builders for each tool call type. Each also has sub-item convenience generators (see [Method Naming Conventions](#method-naming-conventions)):

| Builder | Factory Method (`Add*`) | Builder Lifecycle | Sub-Item Convenience |
|---|---|---|---|
| `OutputItemCodeInterpreterCallBuilder` | `AddOutputItemCodeInterpreterCall()` | `EmitAdded()` → `EmitInProgress()` → `EmitInterpreting()` → `EmitCodeDelta()` → `EmitCodeDone()` → `EmitCompleted()` → `EmitDone()` | `Code(string\|IAsyncEnumerable<string>)` |
| `OutputItemFileSearchCallBuilder` | `AddOutputItemFileSearchCall()` | `EmitAdded()` → `EmitInProgress()` → `EmitSearching()` → `EmitCompleted()` → `EmitDone()` | — |
| `OutputItemWebSearchCallBuilder` | `AddOutputItemWebSearchCall()` | `EmitAdded()` → `EmitInProgress()` → `EmitSearching()` → `EmitCompleted()` → `EmitDone()` | — |
| `OutputItemImageGenCallBuilder` | `AddOutputItemImageGenCall()` | `EmitAdded()` → `EmitInProgress()` → `EmitGenerating()` → `EmitPartialImage()` → `EmitCompleted()` → `EmitDone(result)` | — |
| `OutputItemMcpCallBuilder` | `AddOutputItemMcpCall(serverLabel, name)` | `EmitAdded()` → `EmitInProgress()` → `EmitArgumentsDelta()` → `EmitArgumentsDone()` → `EmitCompleted()` / `EmitFailed()` → `EmitDone()` | `Arguments(string\|IAsyncEnumerable<string>)` |
| `OutputItemCustomToolCallBuilder` | `AddOutputItemCustomToolCall(callId, name)` | `EmitAdded()` → `EmitInputDelta()` → `EmitInputDone()` → `EmitDone()` | `Input(string\|IAsyncEnumerable<string>)` |

Each builder enforces its own lifecycle ordering — follow the method progression from left to right.

### Simple Output Items (Add + Done)

Many output item types have no intermediate SSE events — just `output_item.added` and `output_item.done`. For these, `ResponseEventStream` provides one-liner convenience generators that accept the domain-specific parameters, auto-generate the item ID, and yield the complete event pair:

| Convenience Method | Description |
|---|---|
| `OutputItemFunctionCallOutput(callId, output)` | Server-side tool execution result |
| `OutputItemStructuredOutputs(output)` | Arbitrary structured JSON data |
| `OutputItemImageGenCall(resultBase64)` | Image generation result (with status transitions) |
| `OutputItemComputerCall(callId, action, pendingSafetyChecks, status)` | Computer tool call |
| `OutputItemComputerCallOutput(callId, output)` | Computer tool call output |
| `OutputItemLocalShellCall(callId, action, status)` | Local shell tool call |
| `OutputItemLocalShellCallOutput(output)` | Local shell tool call output |
| `OutputItemFunctionShellCall(callId, action, status, environment)` | Function shell call |
| `OutputItemFunctionShellCallOutput(callId, status, output, maxOutputLength?)` | Function shell call output |
| `OutputItemApplyPatchCall(callId, status, operation)` | Apply-patch tool call |
| `OutputItemApplyPatchCallOutput(callId, status)` | Apply-patch tool call output |
| `OutputItemCustomToolCallOutput(callId, output)` | Custom tool call output |
| `OutputItemMcpApprovalRequest(serverLabel, name, arguments)` | MCP approval request |
| `OutputItemMcpApprovalResponse(approvalRequestId, approve)` | MCP approval response |
| `OutputItemCompaction(encryptedContent)` | Compaction item |

Example:

```csharp
// Emit a function call output (no deltas — just added + done)
foreach (var evt in stream.OutputItemFunctionCallOutput("call_1", BinaryData.FromString(resultJson)))
    yield return evt;

// Emit a structured JSON payload
foreach (var evt in stream.OutputItemStructuredOutputs(BinaryData.FromObjectAsJson(new { score = 0.95 })))
    yield return evt;
```

For fine-grained control, use the corresponding `Add*()` builder factory and call `EmitAdded(item)` / `EmitDone(item)` manually.

### MCP Terminal State

For MCP tool calls, `EmitCompleted()` and `EmitFailed()` on `OutputItemMcpCallBuilder` record the terminal status so that `EmitDone()` sets the correct `MCPToolCallStatus` on the output item. If neither is called, `EmitDone()` defaults to `Completed`.

```csharp
var mcp = stream.AddOutputItemMcpCall("my-server", "tool_name");
yield return mcp.EmitAdded();
yield return mcp.EmitInProgress();
// ... arguments ...

// Option A: Success
yield return mcp.EmitCompleted();  // Records status = Completed
yield return mcp.EmitDone();       // Output item has Status = Completed

// Option B: Failure
yield return mcp.EmitFailed();     // Records status = Failed
yield return mcp.EmitDone();       // Output item has Status = Failed
```

---

## Handling Input

Access the client's input via `context.GetInputItemsAsync()`:

```csharp
var inputItems = await context.GetInputItemsAsync(cancellationToken: ct);

// Check for specific input types
var textMessages = inputItems.OfType<ItemMessage>();
var functionOutputs = inputItems.OfType<FunctionCallOutputItemParam>();
```

Or use `context.GetInputTextAsync()` when you only need the text content:

```csharp
var text = await context.GetInputTextAsync(cancellationToken: ct);
```

The `CreateResponse` object also provides:
- `request.Model` — the requested model name
- `request.Instructions` — system instructions
- `request.Tools` — registered tool definitions
- `request.Metadata` — key-value metadata pairs
- `request.Store` — whether to persist the response
- `request.Stream` — whether SSE streaming was requested
- `request.Background` — whether background mode was requested

### Expanding Message Content

To access typed content parts from an `ItemMessage` (e.g., in resolved input items or history), use `GetContentExpanded()`:

```csharp
var inputItems = await context.GetInputItemsAsync(cancellationToken);
foreach (var item in inputItems.OfType<ItemMessage>())
{
    var contentParts = item.GetContentExpanded();
    foreach (var part in contentParts)
    {
        if (part is MessageContentInputTextContent textContent)
        {
            Console.WriteLine(textContent.Text);
        }
    }
}
```

This complements the context-level helpers (`GetInputItemsAsync`, `GetInputTextAsync`) — they resolve and return input items from the `ResponseContext`, while `GetContentExpanded` operates on individual `ItemMessage` instances.

---

## Cancellation

The `CancellationToken` is triggered when:
- A client calls `POST /responses/{id}/cancel` (background mode only)
- A client disconnects the HTTP connection (non-background mode)

### TextResponse Handlers

`TextResponse` handlers use `return new TextResponse(...)` and pass cancellation through the delegate's `ct` parameter. No `[EnumeratorCancellation]` is needed:

```csharp
public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context, CancellationToken cancellationToken)
{
    return new TextResponse(context, request,
        createText: async ct =>
        {
            // Pass ct to async operations — it triggers on cancel/disconnect
            var result = await _httpClient.GetStringAsync(url, ct);
            return result;
        });
}
```

For streaming, check cancellation between chunks:

```csharp
return new TextResponse(context, request,
    createTextStream: async ct =>
    {
        await foreach (var token in _model.StreamAsync(prompt, ct))
        {
            yield return token;
        }
    });
```

### ResponseEventStream Handlers

**Use `[EnumeratorCancellation]` on the cancellation token parameter** — this is required for `IAsyncEnumerable` to propagate cancellation correctly with `yield return`.

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    var stream = new ResponseEventStream(context, request);
    yield return stream.EmitCreated();
    yield return stream.EmitInProgress();

    var message = stream.AddOutputItemMessage();
    yield return message.EmitAdded();
    var text = message.AddTextContent();
    yield return text.EmitAdded();

    // Long-running work — check cancellation between chunks
    foreach (var chunk in GetChunks())
    {
        cancellationToken.ThrowIfCancellationRequested();
        yield return text.EmitDelta(chunk);
    }

    yield return text.EmitDone(fullText);
    yield return message.EmitContentDone(text);
    yield return message.EmitDone();
    yield return stream.EmitCompleted();
}
```

### What the Library Does on Cancellation

Let `OperationCanceledException` propagate — the server handles the winddown automatically:

1. The library sets `CancelRequested = true` and fires the execution's `CancellationTokenSource`.
2. It waits up to **10 seconds** for the handler to wind down. If the handler doesn't cooperate in time, the cancel endpoint returns the response in its current state — the execution task continues in the background until it completes.
3. Once the handler finishes (within or beyond the grace period), the response transitions to `cancelled` status and a `response.failed` terminal event is emitted and persisted.

You don't need to emit any terminal event on cancellation — just let `OperationCanceledException` propagate and the library handles the rest. Handlers should cooperate with `CancellationToken` and wind down promptly to ensure the cancel endpoint returns a fully resolved `cancelled` snapshot.

### Graceful Shutdown

When the host shuts down (e.g., `SIGTERM`, `IHost.StopAsync()`), `context.IsShutdownRequested` is set to `true` and the handler's `CancellationToken` is cancelled.

Use `context.IsShutdownRequested` to distinguish shutdown from explicit cancel or client disconnect and choose the appropriate terminal state for your scenario.

**Option A — Emit `response.incomplete`** (clients can resume with `previous_response_id`):

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    var stream = new ResponseEventStream(context, request);
    yield return stream.EmitCreated();
    yield return stream.EmitInProgress();

    try
    {
        await DoLongRunningWorkAsync(cancellationToken);
    }
    catch (OperationCanceledException)
    {
        if (context.IsShutdownRequested)
        {
            // Server is shutting down — emit incomplete so clients can resume
            yield return stream.EmitIncomplete();
            yield break;
        }
        throw; // Let library handle cancel/disconnect
    }

    yield return stream.EmitCompleted();
}
```

**Option B — Emit `response.failed` with a retry indicator** (clients receive an explicit error instructing them to retry):

```csharp
catch (OperationCanceledException) when (context.IsShutdownRequested)
{
    yield return stream.EmitFailed("server_shutting_down", "Server is restarting. Please retry.");
    yield break;
}
```

Configure the shutdown timeout via `HostOptions`:

```csharp
builder.Services.Configure<HostOptions>(options =>
{
    options.ShutdownTimeout = TimeSpan.FromSeconds(10);
});
```

Internally, the library uses `ResponseExecutionTracker` (registered as an `IHostedService`) to coordinate shutdown. When the host stops, the tracker cancels all in-flight response executions and waits for them to complete within the shutdown timeout. This propagation chain is automatic — `context.IsShutdownRequested` and the handler's `CancellationToken` are both triggered by the tracker.

**Client-side reconnection**: When a client receives `response.incomplete` (e.g., because the handler chose Option A above), it can resume by creating a new request with `previous_response_id` set to the incomplete response's ID. The new request continues from where the previous one stopped. This works only when `store=true` — ephemeral (`store=false`) responses cannot be resumed because they are not persisted.

---

## Error Handling

### Handler Exceptions

Throwing an exception is a valid way to terminate your handler — you don't need to emit a terminal event first. The library catches the exception, maps it to the appropriate HTTP error response, and emits `response.failed` on your behalf.

**What clients see when your handler throws**:

| Exception Type | HTTP Status | Response Status | `error.code` | `error.message` |
|---------------|-------------|-----------------|-------------|----------------|
| `BadRequestException` | 400 | `failed` | from exception (e.g., `"invalid_value"`) | from exception |
| `ResourceNotFoundException` | 404 | `failed` | `null` | from exception |
| `ResponsesApiException` | from exception | `failed` | from exception | from exception |
| Any other exception | 500 | `failed` | `"server_error"` | `"An internal error occurred."` |
| `OperationCanceledException` | *(special)* | `cancelled` | *(see [Cancellation](#cancellation))* | *(see [Cancellation](#cancellation))* |

The library recognises specific exception types and maps them to structured error responses. For unknown exceptions, clients see a generic 500 with `"server_error"` — the actual exception details are logged server-side but never exposed to callers.

**The `ResponseError` on the response object** (visible via `GET /responses/{id}` when `store=true`) contains only `code` and `message` — no `type` or `param`. This is a different (smaller) shape than the HTTP error envelope.

### Explicit Failure

To signal a specific failure with a custom error code and message:

```csharp
yield return stream.EmitCreated();
yield return stream.EmitInProgress();
// ... some work ...

// Something went wrong — signal failure explicitly
yield return stream.EmitFailed(ResponseErrorCode.ServerError, "Custom error message");
// Do NOT yield any more events after a terminal event
```

### Input Validation in the Handler

For request-level validation (e.g., unsupported model, missing required tool), throw `BadRequestException`:

```csharp
if (request.Model != "my-model")
{
    throw new BadRequestException("Model not supported", "model");
}
```

The library converts this to an HTTP 400 response with the standard error envelope shape.

### Validation Pipeline

Bad client input returns HTTP 400 before your handler runs. Bad handler output returns HTTP 500 or triggers `response.failed`. Don't catch either exception type — `PayloadValidationException` runs before your handler, and `ResponseValidationException` indicates a bug in your handler code that should be fixed, not caught.

**Debugging**: If you see unexpected 500 errors during development, check your application logs for validation errors. The logged details include the JSON path and expected type, pointing you to the builder call that produced invalid output.



---

## Response Lifecycle

### Terminal Event Requirement

Your handler **must** do one of two things before the `IAsyncEnumerable` completes:

1. **Emit a terminal event** — `EmitCompleted()`, `EmitFailed()`, or `EmitIncomplete()`
2. **Throw an exception** — the library maps it to `response.failed` (see [Handler Exceptions](#handler-exceptions))

Both are valid ways to end a response. What is **not** valid is silently completing the stream without either — that is a programming error and the library treats it as one.

```csharp
// ✅ Emit a terminal event
yield return stream.EmitCompleted();

// ✅ Also good: emit with usage data
yield return stream.EmitCompleted(usage);

// ✅ Also valid: throw an exception — library handles the error response
throw new BadRequestException("Unsupported model", "model");

// ❌ Bad handler: stopping without a terminal event or exception
//    → library emits response.failed with a diagnostic log (B32)
```

**Why the library doesn't auto-complete**:
- A silent completion could mask bugs — the handler may have forgotten to emit output
- The library fails loudly so programming errors surface during development
- Allows passing `ResponseUsage` data (see [Token Usage Reporting](#token-usage-reporting) below)
- Lets you choose the right terminal status (`completed`, `failed`, or `incomplete`)
- Makes handler intent unambiguous to readers of your code



> **Note**: This section applies to `ResponseEventStream` handlers. `TextResponse` handles terminal events automatically.

### Signalling Incomplete

If your handler cannot fully complete the request (e.g., output was truncated), signal incomplete:

```csharp
yield return stream.EmitCreated();
yield return stream.EmitInProgress();

var message = stream.AddOutputItemMessage();
// ... partial output ...
yield return message.EmitDone();

yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
```

The `incomplete` status is **handler-driven** — the library does not automatically detect truncation. Your handler decides when to signal it.

### Token Usage Reporting

All three terminal methods accept an optional `ResponseUsage?` parameter for reporting token consumption. If no usage is provided, the `usage` field is omitted from the response.

```csharp
// Completed with usage
yield return stream.EmitCompleted(usage);

// Failed with usage
yield return stream.EmitFailed(ResponseErrorCode.ServerError, "Error message", usage);

// Incomplete with usage
yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens, usage);
```

Create `ResponseUsage` using the model factory:

```csharp
var usage = AzureAIAgentServerResponsesModelFactory.ResponseUsage(
    inputTokens: 150,
    outputTokens: 42,
    totalTokens: 192);
yield return stream.EmitCompleted(usage);
```

Handlers that proxy to an LLM and receive token counts should pass them through. Handlers that do not interact with an LLM typically omit usage.



---

## RawBody Access

The `ResponseContext` exposes the full raw JSON request body via `context.RawBody`:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    // Access the raw JSON request body
    BinaryData? rawBody = context.RawBody;

    // Parse and read custom extension fields not in the typed model
    if (rawBody is not null)
    {
        using var doc = JsonDocument.Parse(rawBody);
        if (doc.RootElement.TryGetProperty("x-custom-field", out var customField))
        {
            var customValue = customField.GetString();
            // Use custom value in handler logic
        }
    }

    // ... emit events ...
}
```

| Property | Type | Description |
|---|---|---|
| `context.RawBody` | `BinaryData?` | The full raw JSON request body, including any custom extension fields not present in the typed `CreateResponse` model |

**Notes**:
- Returns `null` in test contexts where no HTTP request is available (e.g., unit tests using `ResponseContext`).
- Useful for forward-compatible extension fields, vendor-specific annotations, or custom metadata that the typed model does not capture.
- Use `JsonDocument.Parse(context.RawBody)` or `context.RawBody.ToObjectFromJson<T>()` to inspect the JSON content.

---

## Configuration

| Option | Type | Default | Description |
|---|---|---|---|
| `DefaultModel` | `string?` | `null` | Default model when `model` is omitted from `CreateResponse`. Falls back to `""` if null |
| `DefaultFetchHistoryCount` | `int` | `100` | Maximum number of history items to resolve when `GetHistoryAsync()` is called. Controls the `limit` parameter passed to `ResponsesProvider.GetHistoryItemIdsAsync` |

**Platform environment variables** (read once at startup via `FoundryEnvironment`):

| Variable | Default | Description |
|---|---|---|
| `SSE_KEEPALIVE_INTERVAL` | Disabled | Interval (in seconds) between SSE keep-alive comments. See [SSE Keep-Alive](#sse-keep-alive) |
| `PORT` | `8088` | HTTP listen port for the Kestrel server |

**In-memory provider options** (`InMemoryProviderOptions` — separate from `ResponsesServerOptions`):

| Option | Type | Default | Description |
|---|---|---|---|
| `EventStreamTtl` | `TimeSpan` | 10 minutes | Per-event SSE replay buffer retention. Each event is available for replay for this duration from when it was emitted. See [TTL Eviction](#ttl-eviction) |

### Model Resolution

The `model` field is optional on `CreateResponse`. When omitted, the library resolves it in priority order:

1. **Request-level**: `request.Model` (from the JSON payload)
2. **Server default**: `ResponsesServerOptions.DefaultModel`
3. **Fallback**: empty string (`""`)

```csharp
services.AddResponsesServer(options =>
{
    options.DefaultModel = "gpt-4o";  // Used when request omits model
});
```

### Auto-Stamping

The library automatically stamps output items with contextual metadata:

- **`ResponseId`**: Every `OutputItem` gets its `ResponseId` set to the current response ID. If you set it explicitly in your handler, your value takes precedence.
- **`AgentReference`**: When `CreateResponse.AgentReference` is set, it is propagated to every `OutputItem.AgentReference`. If you set it explicitly in your handler, your value takes precedence.

This happens transparently — no handler code is needed.

### Library Identity Header

The server automatically adds an `x-platform-server` identity header to all responses via the `ServerUserAgentMiddleware` in the Core package. Each protocol registers its own identity segment (e.g., `azure-ai-agentserver-responses/{version}`) with the `ServerUserAgentRegistry` during route mapping. To append custom identity information, use the core options:

```csharp
var builder = AgentHost.CreateBuilder(args);
builder.Configure(options =>
{
    options.AdditionalServerIdentity = "my-app/1.0";
});
builder.AddResponses<MyHandler>();
var app = builder.Build();
app.Run();
```



### Distributed Tracing

The server emits OpenTelemetry-compatible spans for `POST /responses` requests. To capture them:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddSource("Azure.AI.AgentServer.Responses")  // library spans
        .AddAspNetCoreInstrumentation()
        .AddOtlpExporter());
```

Handler authors can create child activities using their own `ActivitySource` — they are automatically parented under the library's span via `Activity.Current` propagation.

#### Baggage Items

The library sets baggage items on the activity for `POST /responses` requests. Handlers can read these from `Activity.Current`:

```csharp
using System.Diagnostics;

public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    var activity = Activity.Current;
    if (activity is not null)
    {
        var responseId = activity.GetBaggageItem("response.id");
        var conversationId = activity.GetBaggageItem("conversation.id");
        var streaming = activity.GetBaggageItem("streaming");
        var agentName = activity.GetBaggageItem("agent.name");
        var agentId = activity.GetBaggageItem("agent.id");
        var providerName = activity.GetBaggageItem("provider.name");
        var requestId = activity.GetBaggageItem("request.id");
    }

    // ... emit events ...
}
```

| Baggage Key | Description |
|---|---|
| `response.id` | The library-generated response identifier |
| `conversation.id` | Conversation ID from the request (if present) |
| `streaming` | `"true"` or `"false"` — whether SSE streaming was requested |
| `agent.name` | Agent name from `agent_reference` (if provided) |
| `agent.id` | Composite `{name}:{version}` from `agent_reference` (if provided) |
| `provider.name` | Fixed: `"azure.ai.responses"` |
| `request.id` | From the `X-Request-Id` HTTP header (if present) |

Baggage items are propagated to child activities and downstream telemetry processors automatically.

#### Customizing Tracing with `ResponsesActivitySource`

All distributed tracing behaviour — tags, baggage, activity name — is encapsulated in the virtual method `ResponsesActivitySource.StartCreateResponseActivity`. The library registers a default instance via `TryAddSingleton`, so you can replace it entirely by registering your own subclass **before** calling `AddResponsesServer()`.

##### Composition pattern (recommended)

Because `Activity.SetTag` **replaces** existing values for the same key, and `Activity.AddBaggage` prepends (so `GetBaggageItem` returns the most recently added value), you can call `base` first and then selectively override — no need to duplicate the entire method:

```csharp
class MyActivitySource : ResponsesActivitySource
{
    public override Activity? StartCreateResponseActivity(
        CreateResponse request, string responseId, IHeaderDictionary headers)
    {
        // Get all defaults (GenAI tags, baggage, X-Request-Id, etc.)
        var activity = base.StartCreateResponseActivity(request, responseId, headers);
        if (activity is null) return null;

        // Override service identity
        activity.SetTag("gen_ai.provider.name", "my-service");
        activity.SetTag("service.name", "my-service");
        activity.SetTag("gen_ai.system", "my-service");
        activity.AddBaggage("provider.name", "my-service");

        // Add extra tags
        activity.SetTag("service.namespace", "my.company.agents");

        // Read any header you need
        if (headers.TryGetValue("X-Tenant-Id", out var tenantId))
            activity.SetTag("tenant.id", tenantId.ToString());

        return activity;
    }
}

// Register before AddResponsesServer so TryAddSingleton skips the default:
builder.Services.AddSingleton<ResponsesActivitySource, MyActivitySource>();
builder.Services.AddResponsesServer();
```

##### Full override

To completely replace the tracing behaviour, override without calling `base`:

```csharp
class MinimalActivitySource : ResponsesActivitySource
{
    public override Activity? StartCreateResponseActivity(
        CreateResponse request, string responseId, IHeaderDictionary headers)
    {
        var activity = Source.StartActivity($"my-op {request.Model}");
        activity?.SetTag("custom.response.id", responseId);
        return activity;
    }
}
```

##### OpenTelemetry integration

The default `ActivitySource` name is `ResponsesActivitySource.DefaultName` (`"Azure.AI.AgentServer.Responses"`). Configure your tracing pipeline to listen for it:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddSource(ResponsesActivitySource.DefaultName)
        .AddAspNetCoreInstrumentation()
        .AddOtlpExporter());
```

If your subclass uses a different source name (via the `protected` constructor), listen for that name instead.

### TTL Eviction

The default in-memory response store retains response data indefinitely. Only event stream replay buffers are automatically evicted — each SSE event is retained for a configurable TTL from the time it was emitted (default: 10 minutes).

```csharp
builder.Services.Configure<InMemoryProviderOptions>(opts =>
{
    opts.EventStreamTtl = TimeSpan.FromMinutes(30);  // SSE replay available for 30 min
});
```

If you register a custom `ResponsesProvider`, you manage your own retention strategy. `InMemoryProviderOptions` only affects the built-in in-memory provider.



### SSE Keep-Alive

The server can send periodic keep-alive comments during SSE streaming to prevent reverse proxies from closing idle connections. Disabled by default.

**Enable via environment variable**:

```bash
export SSE_KEEPALIVE_INTERVAL=15
```

This is a platform-controlled setting read once at startup via `FoundryEnvironment.SseKeepAliveInterval`.

The `X-Accel-Buffering: no` response header is automatically set on SSE streams to disable nginx buffering.



---

## Best Practices

### 1. Always Emit Created First, Terminal Last

Every `ResponseEventStream` handler must yield `stream.EmitCreated()` followed by `stream.EmitInProgress()` as its first two events, and exactly one terminal event (`EmitCompleted`, `EmitFailed`, or `EmitIncomplete`) as its last. The library validates this ordering. `TextResponse` handles this automatically.

### 2. Use Small, Frequent Deltas

For streaming mode, smaller deltas create a more responsive UX. Don't buffer the entire response — stream it as it's generated:

```csharp
// Good: Stream word-by-word
foreach (var word in words)
{
    yield return text.EmitDelta(word + " ");
    await Task.Delay(50, cancellationToken); // Simulate generation
}
```

### 3. Check Cancellation in Loops

Any long-running loop should check `cancellationToken`:

```csharp
foreach (var item in largeCollection)
{
    cancellationToken.ThrowIfCancellationRequested();
    // ... process item ...
}
```

### 4. Pass CancellationToken to Async Calls

```csharp
var result = await httpClient.GetAsync(url, cancellationToken);
var data = await database.QueryAsync(query, cancellationToken);
```

### 5. Close Every Builder You Open

Every builder follows `EmitAdded()` → work → `EmitDone()`. If you forget `EmitDone()`, the response will have incomplete output items.

### 6. Use `await Task.CompletedTask` for Sync Handlers

If your `ResponseEventStream` handler does no async work, the compiler requires at least one `await`. Use `await Task.CompletedTask` at the top:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(...)
{
    await Task.CompletedTask;
    // ... synchronous work with yield return ...
}
```

> **Tip**: `TextResponse` handlers that use `return new TextResponse(...)` don't need `await Task.CompletedTask` or `[EnumeratorCancellation]` — they use `return` instead of `yield return`.

### 7. Register as Singleton for Stateless, Scoped for Stateful

```csharp
// Stateless handler — one instance for the lifetime of the app
builder.Services.AddSingleton<ResponseHandler, MyHandler>();

// Stateful handler — new instance per request
builder.Services.AddScoped<ResponseHandler, MyStatefulHandler>();
```

### 8. Let the library Handle Mode Negotiation

Never branch on `request.Stream` or `request.Background` in your handler. The library handles these concerns — your handler always produces the same event sequence regardless of mode.

---

## Common Mistakes

### Forgetting `[EnumeratorCancellation]`

When using `ResponseEventStream` with `yield return`, you must annotate the cancellation token:

```csharp
// ❌ Cancellation won't propagate correctly
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    CancellationToken cancellationToken)

// ✅ Correct
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
```

> **Note**: `TextResponse` handlers use `return new TextResponse(...)` and don't need `[EnumeratorCancellation]` since they don't use `yield return`.

### Emitting Events After a Terminal Event

```csharp
// ❌ Don't yield after EmitCompleted
yield return stream.EmitCompleted();
yield return message.EmitDone(); // This will be ignored or cause errors

// ✅ Finish all output items before the terminal event
yield return message.EmitDone();
yield return stream.EmitCompleted();
```

### Not Closing Content Builders

```csharp
// ❌ Missing EmitContentDone
var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitDone("text");
yield return message.EmitDone(); // Content wasn't properly closed

// ✅ Always call EmitContentDone before closing the message
var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitDone("text");
yield return message.EmitContentDone(text); // Close the content part
yield return message.EmitDone();
```

### Swallowing OperationCanceledException

```csharp
// ❌ Don't catch and convert to failure
try { /* work */ }
catch (OperationCanceledException)
{
    yield return stream.EmitFailed(ResponseErrorCode.ServerError, "Cancelled");
}

// ✅ Let it propagate — the library handles it correctly
// (just don't catch OperationCanceledException)
```

### Branching on Stream/Background Flags

```csharp
// ❌ Don't do this — the library handles mode negotiation
if (request.Stream == true)
{
    // streaming path
}
else
{
    // non-streaming path
}

// ✅ Same event sequence regardless of mode
yield return stream.EmitCreated();
yield return stream.EmitInProgress();
// ... same output for all modes ...
yield return stream.EmitCompleted();
```

### Omitting Output Items from Terminal Response (Raw Events)

When emitting raw events (without `ResponseEventStream` builders), each `response.*` event **fully replaces** the library's tracked `Response` with the event's embedded `Response`. If the terminal `response.completed` has empty output, accumulated `output_item.added/done` items are lost. Additionally, the handler **must** set the correct `Status` on the `Response` before yielding a terminal event — the library validates but never auto-sets terminal status.

```csharp
// ❌ Terminal response has empty output — items accumulated via output_item.added are lost
var response = new Response(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseOutputItemAddedEvent(0, 0, msg);
yield return new ResponseCompletedEvent(0, response); // response.Output is still empty!

// ❌ Status not set — library validates and emits response.failed
var response = new Response(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseCompletedEvent(0, response); // Status is still null!

// ✅ Include output items and set Status in the terminal response
var response = new Response(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseOutputItemAddedEvent(0, 0, msg);

var completedResponse = new Response(ctx.ResponseId, "test-model");
completedResponse.Output.Add(msg); // Handler is source of truth
completedResponse.SetCompleted();  // Sets Status, CompletedAt, OutputText
yield return new ResponseCompletedEvent(0, completedResponse);
```

**Note**: This only applies to raw event construction. When using `ResponseEventStream` builders (e.g., `stream.EmitCompleted()`), the library automatically includes all accumulated output items in the terminal response — no additional work is needed.
