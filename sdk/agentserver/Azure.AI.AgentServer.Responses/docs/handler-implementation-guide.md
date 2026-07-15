# Handler Implementation Guide

> Developer guidance for implementing response handlers — the single integration point for building Azure AI Responses API servers with this library.

---

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [TextResponse](#textresponse)
- [Server Registration](#server-registration)
- [Handler Signature](#handler-signature)
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
  - [SSE Keep-Alive](#sse-keep-alive)
- [Resilience](#resilience)
  - [Mental Model](#mental-model)
  - [The Recovery Loop](#the-recovery-loop)
  - [What the Library Does](#what-the-library-does)
  - [What the Handler Does](#what-the-handler-does)
  - [Stream Checkpoints](#stream-checkpoints)
  - [Item and Response `internal_metadata`](#item-and-response-internal_metadata)
  - [Which metadata facility?](#which-metadata-facility)
  - [Default Pattern (recovery-aware)](#default-pattern-recovery-aware)
  - [Fallback Pattern (no opt-in)](#fallback-pattern-no-opt-in)
  - [Upstream History Pattern](#upstream-history-pattern)
  - [Watermark Pattern](#watermark-pattern)
  - [Resumption Response Construction](#resumption-response-construction)
  - [Recovery × Cancellation Composition](#recovery--cancellation-composition)
  - [Configuration](#configuration-1)
- [Steering API](#steering-api)
  - [`ResponsesServerOptions.ResponseAcceptor`](#responsesserveroptionsresponseacceptor)
- [Best Practices](#best-practices)
- [Common Mistakes](#common-mistakes)
- [See also](#see-also)

---

## Overview

The library handles all protocol concerns — routing, serialization, SSE framing,
`stream`/`background` mode negotiation, status lifecycle, and error shapes. You
extend one handler class by overriding `ResponseHandler.CreateAsync`. Your
handler receives a `CreateResponse` request and produces response events. The
library wraps these events into the correct HTTP response format based on the
client's requested mode.

You do **not** need to think about:

- Whether the client requested JSON or SSE streaming
- Whether the response is running in the foreground or background
- HTTP status codes, content types, or error envelopes
- Sequence numbers or response IDs

The library manages all of this. Your handler just provides text or yields
events.

For most handlers, `TextResponse` eliminates even the event plumbing — you
provide text (or a stream of tokens) and the library does the rest. For full
control over every SSE event, use `ResponseEventStream`.

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

A standalone convenience class for the most common case — returning a single text message. `TextResponse` implements `IAsyncEnumerable<ResponseStreamEvent>` and handles the full event lifecycle internally (`response.created` → `response.in_progress` → message/content events → `response.completed`).

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

> **Note**: `TextResponse` handles all lifecycle events internally — the contract described in [ResponseEventStream](#responseeventstream) (created → output → terminal event) applies only when you use `ResponseEventStream` directly.

---

## Server Registration

### Default: One-Line Startup (Recommended)

The default way to register and run a handler is the `ResponsesServer.Run<THandler>()` one-liner:

```csharp
using Azure.AI.AgentServer.Responses;

ResponsesServer.Run<MyHandler>(args);
```

This creates a Kestrel host with OpenTelemetry, health checks, identity headers, and the Responses protocol endpoints — all in one line.

### With Options / Builder Pattern

For agents that need to configure services or host options before startup, use the builder pattern:

```csharp
using Azure.AI.AgentServer.Responses;

var builder = AgentHost.CreateBuilder(args);
builder.AddResponses<MyHandler>();
var app = builder.Build();
app.Run();
```

### Self-Hosting (Map into existing app)

If you have an existing ASP.NET Core application, register Core middleware and protocol services directly and map the Responses endpoints into that app. See the [Tier 3 self-hosting sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample9_Tier3SelfHosting.md) for a complete example with health checks and OpenTelemetry.

#### Basic Setup

```csharp
builder.Services.AddAgentServerCore();  // Core middleware (request ID, server version, logging)
builder.Services.AddResponsesServer();
builder.Services.AddScoped<ResponseHandler, MyHandler>();
// ...
app.UseAgentServerCore();  // Core middleware pipeline
app.MapResponsesServer();
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

The host maps five endpoints:
- `POST /responses` — Create a response
- `GET /responses/{responseId}` — Retrieve a response (JSON or SSE replay)
- `POST /responses/{responseId}/cancel` — Cancel a response
- `DELETE /responses/{responseId}` — Delete a response
- `GET /responses/{responseId}/input_items` — List input items (paginated)

**Startup validation**: `MapResponsesServer()` throws `InvalidOperationException` if no `ResponseHandler` is registered. This fail-fast behaviour ensures misconfigured servers are caught at startup, not at the first request.

### Custom Response Provider

The server delegates state persistence, event streaming, and cancellation to pluggable providers. The default in-memory implementation works for single-instance deployments; resilient deployments require a persistent provider.

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

## Handler Signature

```csharp
public abstract class ResponseHandler
{
    public abstract IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken);
}
```

| Parameter | Description |
|-----------|-------------|
| `request` | The deserialized `CreateResponse` body from the client (model, input, tools, instructions, etc.) |
| `context` | The handler-facing `ResponseContext` — request-scoped state, input/history helpers, forwarded headers, shutdown/recovery/steering flags, and durable conversation-chain metadata. |
| `cancellationToken` | The cooperative cancellation signal for the current execution. It is triggered by explicit cancel, foreground client disconnect, shutdown, steering pressure, or certain pre-creation persistence failures. |

Handlers override `CreateAsync` and return an `IAsyncEnumerable<ResponseStreamEvent>`.
Your handler can either:

1. **Return a `TextResponse`** — the simplest approach for text-only responses.
2. **Be an async iterator** — `yield return` events one at a time for full control.

The library consumes the events, assigns sequence numbers, manages the response
lifecycle, and delivers them to the client.

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
        yield return text.EmitTextDone("Hello, world!");

        yield return text.EmitDone();
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
| **Internal metadata** | `InternalMetadata` — response-scoped, framework-internal string metadata persisted with snapshots and stripped from client payloads |
| **Lifecycle** | `EmitCreated()`, `EmitInProgress()`, `EmitQueued()`, `EmitCompleted()`, `EmitFailed()`, `EmitIncomplete()` |
| **Output factories** | `AddOutputItemMessage()`, `AddOutputItemFunctionCall()`, `AddOutputItemReasoningItem()`, `AddOutputItemCodeInterpreterCall()`, `AddOutputItemFileSearchCall()`, `AddOutputItemWebSearchCall()`, `AddOutputItemImageGenCall()`, `AddOutputItemMcpCall()`, `AddOutputItemCustomToolCall()`, `AddOutputItemStructuredOutputs()`, `AddOutputItemComputerCall()`, `AddOutputItemLocalShellCall()`, `AddOutputItemApplyPatchCall()`, `AddOutputItemMcpApprovalRequest()`, `AddOutputItemCompaction()`, and more |

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

> **Tip**: Start with `TextResponse`. If you need `ResponseEventStream`, start with convenience generators. Drop down to `Add*` builders only when you need fine-grained control (e.g., multiple content parts in one message, custom properties on the output item, or interleaving non-content work between events).


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
        ├── TextContentBuilder    : EmitAdded → EmitDelta* → EmitTextDone → EmitAnnotationAdded* → EmitDone
        ├── RefusalContentBuilder : EmitAdded → EmitDelta* → EmitRefusalDone → EmitDone
        └── (other content builders follow the same Added → … → Done pattern)
```

Each builder tracks its lifecycle state (`NotStarted` → `Added` → `Done`) and will throw if you emit events out of order. This prevents protocol violations at development time rather than runtime.

**Key rule**: Every builder that you start (`EmitAdded`) must be finished (`EmitDone`). Unfinished builders result in malformed responses.

---

## ResponseContext

```csharp
public class ResponseContext
{
    public string ResponseId { get; }
    public bool IsShutdownRequested { get; set; }
    public virtual CancellationToken Shutdown { get; }
    public virtual BinaryData? RawBody { get; }
    public virtual Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default);
    public virtual Task<string> GetInputTextAsync(bool resolveReferences = true, CancellationToken cancellationToken = default);
    public virtual Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default);
    public virtual PlatformContext PlatformContext { get; }
    public virtual IReadOnlyDictionary<string, string> ClientHeaders { get; }
    public virtual IReadOnlyDictionary<string, StringValues> QueryParameters { get; }
}
```

Provides the library-generated response ID, shutdown signalling, access to resolved input and history items, forwarded client headers, and query parameters from the original request.

For resilient and steerable deployments, the concrete runtime context also exposes the recovery/steering surface used later in this guide:

| Member | Meaning |
|---|---|
| `IsRecovery` | `true` when this invocation re-enters after a crash. |
| `PersistedResponse` | The last durable response snapshot from the prior lifetime, if any. |
| `ConversationChainId` | Stable id shared across every turn/attempt of a conversation chain. |
| `ConversationChainMetadata` | Durable, explicitly-flushed per-chain metadata. |
| `IsSteeredTurn` | `true` on the drain re-entry that follows a steering input. |
| `PendingInputCount` | Steering inputs queued behind the current turn. |
| `ClientCancelled` | `true` when the client explicitly cancelled, distinct from shutdown. |
| `Shutdown` | A dedicated `CancellationToken` signaled on graceful shutdown — separate from the handler's primary cancellation token, mirroring `TaskContext.Shutdown` and Python's `context.shutdown`. |
| `ExitForRecoveryAsync()` | Defer the current turn for recovery instead of failing. |


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

#### Using TextResponse (simplest)

For text-only responses, prefer [`TextResponse`](#textresponse). When you need `ResponseEventStream`, the simplest stream-level approach is one convenience generator call per output item:

#### Using convenience generators

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
yield return text.EmitTextDone("First chunk of text. Second chunk. ");

yield return text.EmitDone();
yield return message.EmitDone();
```

**Tip**: For streaming, emit small deltas frequently for a responsive feel. For non-streaming mode, the library accumulates everything and delivers the final JSON — so delta granularity doesn't affect the JSON response, only SSE streaming UX.

#### Annotations on text content

After calling `EmitTextDone()`, you can attach annotations before closing the content part with `EmitDone()`. The lifecycle is: `EmitAdded` → `EmitDelta` (0+) → `EmitTextDone` → `EmitAnnotationAdded` (0+) → `EmitDone`.

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitDelta("Here are your files.");
yield return text.EmitTextDone("Here are your files.");

// Annotations are emitted after text is finalized
yield return text.EmitAnnotationAdded(new FilePath(fileId: "/reports/summary.pdf", index: 0));
yield return text.EmitAnnotationAdded(new UrlCitationBody(
    url: new Uri("https://example.com/docs"), startIndex: 0, endIndex: 19, title: "Docs"));

yield return text.EmitDone();
yield return message.EmitDone();
```

Or use the `TextContent(string, IEnumerable<Annotation>)` convenience on `OutputItemMessageBuilder` to handle the full sequence in one call:

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

foreach (var evt in message.TextContent("Here are your files.", new Annotation[]
{
    new FilePath(fileId: "/reports/summary.pdf", index: 0),
    new UrlCitationBody(url: new Uri("https://example.com/docs"), startIndex: 0, endIndex: 19, title: "Docs"),
}))
    yield return evt;

yield return message.EmitDone();
```

#### Refusal content

When the model refuses a request, emit a refusal content part instead of (or alongside) text. The lifecycle is: `EmitAdded` → `EmitDelta` (0+) → `EmitRefusalDone` → `EmitDone`.

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

var refusal = message.AddRefusalContent();
yield return refusal.EmitAdded();
yield return refusal.EmitDelta("I cannot ");
yield return refusal.EmitDelta("help with that.");
yield return refusal.EmitRefusalDone("I cannot help with that.");
yield return refusal.EmitDone();

yield return message.EmitDone();
```

Or use the `RefusalContent(string)` convenience for the common case:

```csharp
var message = stream.AddOutputItemMessage();
yield return message.EmitAdded();

foreach (var evt in message.RefusalContent("I cannot help with that."))
    yield return evt;

yield return message.EmitDone();
```

Both `RefusalContent` overloads follow the same pattern as `TextContent` — a `string` overload for complete text and an `IAsyncEnumerable<string>` overload for streaming chunks.

### Function Calls (Tool Use)

When your handler needs the client to execute a function (tool) and return the result.

#### Using convenience generators

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

#### Using convenience generators

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

#### Convenience generators

For simple output items that only need an added → done pair, convenience generators avoid the builder ceremony entirely. Many output item types have no intermediate SSE events — just `output_item.added` and `output_item.done`. For these, `ResponseEventStream` provides one-liner convenience generators that accept the domain-specific parameters, auto-generate the item ID, and yield the complete event pair:

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

The handler observes cancellation through a `CancellationToken`, shutdown via the
dedicated `context.Shutdown` token (and the `context.IsShutdownRequested` flag), and
cause/steering flags on `ResponseContext`. `context.Shutdown` is a *separate* signal from
the handler's primary `CancellationToken` — it mirrors the task-primitive
`ctx.Shutdown` and the Python `context.shutdown` event, so a handler can `await` or link
it to react to shutdown *specifically* rather than inferring it from a generic
`OperationCanceledException`. These surfaces are cooperative: the framework asks the
handler to wind down; the handler chooses whether to complete partial work, propagate
cancellation, fail, or defer resilient background work for recovery.

> **Never fail a handler purely because shutdown is happening.** On graceful shutdown a
> well-behaved handler checkpoints and calls `ExitForRecoveryAsync()` (resilient
> background) or emits `response.incomplete`; a handler that does nothing special is
> automatically deferred for recovery (resilient background) or failed with
> `grace_exhausted` (non-resilient) by the framework — it is *not* your job to manufacture
> a `failed` terminal on shutdown. Always inspect `context.Shutdown` /
> `context.IsShutdownRequested` before treating a cancellation as an error.

| Cause | `CancellationToken` | `context.IsShutdownRequested` | `context.ClientCancelled` | Framework behaviour | What handler should do |
|-------|:---:|:---:|:---:|---|---|
| **Steering** | cancelled | false | false | If no terminal is emitted, the library treats the handler exit as failure. If a terminal is emitted, it is honoured. | Break the loop, close builders, emit `EmitCompleted()` for the superseded turn. |
| **Client Cancel** | cancelled | false | true | Framework forces `cancelled` regardless of handler output. Output items are abandoned. | Return as soon as cleanup is done or let `OperationCanceledException` propagate. |
| **Foreground disconnect** | cancelled | false | false | Treated as request cancellation for non-background work. | Stop promptly; normally let `OperationCanceledException` propagate. |
| **Shutdown** | cancelled | true | false | Resilient background: `ExitForRecoveryAsync()` (or a passive exit) leaves the response `in_progress` for re-entry. Non-resilient: fails with `grace_exhausted` only after the grace window. | Observe `context.Shutdown`, checkpoint progress, then call `ExitForRecoveryAsync()` for resilient work; otherwise finish or emit `incomplete`. Never emit `failed` just because shutdown fired. |
| **Shutdown + Client Cancel race** | cancelled | true | true | Each surface reflects its independent cause; cancellation status can win. | Inspect each surface as needed; resilient background handlers usually prefer `ExitForRecoveryAsync()`. |

**Key status rules:**

- `cancelled` is produced by the framework for explicit client cancellation; handlers should not manufacture it as a normal steering/shutdown outcome.
- `incomplete` is handler-controlled; the framework does not infer truncation.
- `ExitForRecoveryAsync()` is the graceful-shutdown recovery primitive for resilient background responses.

### Default Pattern (handles cancel + shutdown)

Most streaming handlers need to observe both the `CancellationToken` and the
shutdown signal in their work loop. Treat cancellation as a wake-up signal for
client cancel, disconnect, or steering; treat shutdown separately — observe
`context.Shutdown` (or the `context.IsShutdownRequested` flag) — because resilient
background handlers should defer to the next lifetime instead of producing a
misleading terminal response.

### Advanced Pattern (pre-entry steering, resilient shutdown recovery)

For steerable + resilient handlers, the token may already be cancelled when the
handler is entered: a newer turn may already be queued, or a client may already
have cancelled. Check shutdown first, then inspect `context.ClientCancelled` and
`context.PendingInputCount` to distinguish explicit cancel from steering. On a
steering-only pre-entry, emitting `EmitCompleted()` lets the superseded turn end
cleanly and the queued turn drain.

### Metadata Usage in Cancellation

`context.ConversationChainMetadata` is appropriate for lightweight progress
signals that help on re-entry — for example a `last_processed_item_id`, a phase
index, or a checkpoint reference. Do not store full conversation history, LLM
outputs, or large framework checkpoints there; keep those in the upstream
framework or your own store.

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

    yield return text.EmitTextDone(fullText);
    yield return text.EmitDone();
    yield return message.EmitDone();
    yield return stream.EmitCompleted();
}
```

### What the Library Does on Cancellation

Let `OperationCanceledException` propagate for true cancellation — the server handles the winddown automatically:

1. The library records the cancellation cause and fires the execution's `CancellationTokenSource`.
2. It waits up to **10 seconds** for the handler to wind down. If the handler doesn't cooperate in time, the cancel endpoint returns the response in its current state — the execution task continues in the background until it completes.
3. Once the handler finishes (within or beyond the grace period), the response transitions to `cancelled` status and a `response.failed` terminal event is emitted and persisted.

You don't need to emit any terminal event on cancellation — just let `OperationCanceledException` propagate and the library handles the rest. Handlers should cooperate with `CancellationToken` and wind down promptly to ensure the cancel endpoint returns a fully resolved `cancelled` snapshot.

> **Note on persistence-triggered cancellation**: When Phase 1 persistence fails in background mode, the `CancellationToken` fires identically to an explicit cancel. Your handler cannot distinguish this from a normal cancellation — and doesn't need to. The library handles error reporting to the client. Simply let `OperationCanceledException` propagate as you would for any other cancellation.

### Graceful Shutdown

When the host shuts down (e.g., `SIGTERM`, `IHost.StopAsync()`), the dedicated
`context.Shutdown` token is signaled and `context.IsShutdownRequested` is set to `true`.
The handler's primary `CancellationToken` is also cancelled so that a handler parked
purely on that token still wakes.

Prefer observing `context.Shutdown` (or the `context.IsShutdownRequested` flag) to
distinguish shutdown from an explicit cancel or client disconnect, and choose the
appropriate terminal state for your scenario. Do **not** convert a raw cancellation into
a `failed` terminal just because shutdown fired — check the shutdown surface first.

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

Internally, the library uses `ResponseExecutionTracker` (registered as an `IHostedService`) to coordinate shutdown. When the host stops, the tracker signals shutdown to all in-flight response executions and waits for them to complete within the shutdown timeout. This propagation chain is automatic — `context.Shutdown`, `context.IsShutdownRequested`, and the handler's `CancellationToken` are all triggered by the tracker.

**Client-side reconnection**: When a client receives `response.incomplete` (e.g., because the handler chose Option A above), it can resume by creating a new request with `previous_response_id` set to the incomplete response's ID. The new request continues from where the previous one stopped. This works only when `store=true` — ephemeral (`store=false`) responses cannot be resumed because they are not persisted.


### Rules

1. **MUST emit `response.created` before any early return** — the framework cannot persist or track a response until `EmitCreated()` is yielded.
2. **MUST emit a terminal event** (`EmitCompleted()`, `EmitIncomplete()`, or `EmitFailed()`) in normal paths. If the handler exits without a terminal event, the framework forces `failed` status.
3. **Do not treat steering as client cancellation** — for steering pressure, close builders and emit `EmitCompleted()` so the superseded turn has a valid terminal.
4. **Client cancel is cooperative but status-forced** — clean up promptly; the framework produces `cancelled`.
5. **Shutdown has a hard cutoff** — keep post-signal work short; resilient background handlers should checkpoint and call `ExitForRecoveryAsync()` if they cannot finish.

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

### Persistence Failures

When `store=true` (the default), the library persists the response to durable storage. If persistence fails (e.g., the storage service is unavailable), the library handles it transparently — **your handler does not need to handle persistence errors**.

**What happens when persistence fails:**

| Mode | When persistence fails | What the handler sees | What the client sees |
|------|----------------------|----------------------|---------------------|
| Non-streaming, non-background | Phase 1 (create) or Phase 2 (finalize) | Nothing — handler already produced its response | **HTTP error** carrying the *original* storage error (e.g. `500` `storage_error`, or `400` for a non-retryable bad request); no dangling response is returned |
| Streaming, non-background | Before yielding the terminal event | Nothing — handler already emitted terminal | Terminal event replaced with `response.failed` |
| Background, non-streaming | Phase 1 (CreateResponse): before response returned to client | `CancellationToken` fires (`OperationCanceledException`) | HTTP 500 error (pre-creation failure) |
| Background, non-streaming | Phase 2 (UpdateResponse): after handler completes | Nothing — handler already finished | `GET` returns `status: "failed"` |
| Background, streaming | Phase 1 (CreateResponse): before `response.created` sent | `CancellationToken` fires (`OperationCanceledException`) | Standalone `error` SSE event |
| Background, streaming | Phase 2 (UpdateResponse): after terminal event streamed | Nothing — handler already finished | `response.failed` SSE event replaces original terminal |

**Key points for handler authors:**

1. **You don't need to catch or handle persistence errors.** The library handles the storage lifecycle and error reporting automatically.

2. **Your handler may be cancelled if Phase 1 persistence fails.** In background mode, the library persists the response *before* signalling `response.created` to the client. If this initial persist fails, the handler's `CancellationToken` fires. Your handler sees this as a normal cancellation — the same `OperationCanceledException` that fires on client disconnect or explicit cancel. No special handling is required; let the exception propagate.

3. **Phase 2 failures don't affect your handler.** Phase 2 persistence (updating the final state) happens *after* your handler finishes. If it fails, the response is marked as `failed` but your handler has already completed normally.

4. **Failed responses remain accessible via `GET`.** When persistence fails, the response stays in memory for the lifetime of the sandbox. Clients can retrieve the failed response with its error details via `GET /responses/{id}`.

5. **The storage provider's transport layer retries automatically.** The library does not add application-level retries. By the time a persistence error surfaces, the underlying HTTP pipeline has already exhausted its retry budget (typically 3 retries with exponential backoff).

**When does persistence failure affect running handlers?**

In the **pre-creation (Phase 1)** persistence failure of a **background or streaming** response — when the library tries to create the initial response record *before* `response.created` reaches the client. In those modes the handler may still be emitting events when creation is persisted, so its `CancellationToken` fires. For a **non-streaming foreground** response the handler has already produced its full response by the time persistence occurs, so it is not cancelled — the failure surfaces as an HTTP error carrying the original storage error instead.



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

Create `ResponseUsage` directly:

```csharp
var usage = new ResponseUsage(
    inputTokens: 150,
    inputTokensDetails: new ResponseUsageInputTokensDetails(cachedTokens: 0),
    outputTokens: 42,
    outputTokensDetails: new ResponseUsageOutputTokensDetails(reasoningTokens: 0),
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
| `ResilientBackground` | `bool` | `false` | Opts background responses into crash-recoverable re-invocation when `store=true` and `background=true` |
| `SteerableConversations` | `bool` | `false` | Allows a new turn to queue behind an active conversation and drain as a steered turn |
| `ResponseAcceptor` | delegate | `null` | Optional hook for customizing the `queued` response returned to a POST that was queued behind an active steerable conversation |

**Platform environment variables** (read once at startup via `FoundryEnvironment`):

| Variable | Default | Description |
|---|---|---|
| `SSE_KEEPALIVE_INTERVAL` | Disabled | Interval (in seconds) between SSE keep-alive comments. See [SSE Keep-Alive](#sse-keep-alive) |
| `PORT` | `8088` | HTTP listen port for the Kestrel server |
| `DEFAULT_FETCH_HISTORY_ITEM_COUNT` | `100` | Override for `DefaultFetchHistoryCount` |

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

The server automatically adds an `x-platform-server` identity header to all responses via the `ServerVersionMiddleware` in the Core package. Each protocol registers its own identity segment (e.g., `azure-ai-agentserver-responses/{version}`) with the `ServerVersionRegistry` during route mapping. To append custom identity information, use the core options:

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

#### OpenTelemetry integration

The default `ActivitySource` name is `"Azure.AI.AgentServer.Responses"`. Configure your tracing pipeline to listen for it:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddSource("Azure.AI.AgentServer.Responses")
        .AddAspNetCoreInstrumentation()
        .AddOtlpExporter());
```

> **Note:** `ResponsesActivitySource` is an internal type managed by the framework. Handlers do not need to create tracing activities directly — the library instruments each `POST /responses` call automatically.

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

## Resilience

The framework re-invokes your handler when the server crashes mid-response if
`ResponsesServerOptions.ResilientBackground = true` and the request had
`store=true, background=true`. What that re-invocation gives you, what you have
to do to take advantage of it, and how clients reconcile a multi-attempt stream
is the **recovery contract**.

The deeper contract is in [`resilience-contract.md`](resilience-contract.md).
This section is the developer how-to for the .NET surface.

You can opt out of all of this and your response will still be correct (just
potentially duplicative). You opt in when you want the recovered attempt to pick
up where the crashed one left off instead of re-running the whole turn.

### Mental Model

Three layers, each owning a specific slice of state:

| Layer | Owns | On crash recovery, surfaces / provides |
|---|---|---|
| **Library** (this SDK) | Persisted SSE event stream and selected response snapshots. The library persists the response object at `response.created`, at each successful `stream.Checkpoint()`, and at the terminal event. | Re-invokes the handler. Surfaces `context.IsRecovery`, `context.PersistedResponse`, `context.IsSteeredTurn`, `context.PendingInputCount`, and `context.ConversationChainMetadata`. Replays persisted events to reconnecting clients and rebuilds the `ResponseContext` with the same `ResponseId`. |
| **Handler** (your code) | The decision about what was safely committed, plus side-effect watermarks in `context.ConversationChainMetadata`. | Decides the resumption point. Constructs the resumption response. Emits a fresh `response.in_progress` carrying it. Continues producing new output items. |
| **Upstream framework** (Copilot SDK, LangGraph, your LLM client, or your store) | Conversational / graph / agent state that has to outlive a process death. | Provides its own resume facility that the handler calls. |

You do **not** own response event resilience — that is the library. The library
does **not** own conversational resilience — that is upstream. The handler glues
them together.

### The Recovery Loop

When the server restarts after a crash and your handler is re-invoked:

1. The library calls your handler with `context.IsRecovery == true`.
2. You query upstream and your own `context.ConversationChainMetadata` watermarks to determine the **resumption point** — the most recent state you are confident is persisted.
3. You build or select a **resumption response** reflecting only the output items you trust at that point. In-flight items from the crashed attempt are excluded.
4. You construct `ResponseEventStream` from that resumption response when appropriate, or from the request for a fresh/naive restart.
5. You emit `response.created` exactly as on a fresh attempt — the framework deduplicates the response-store write across recovery attempts.
6. You emit `response.in_progress`. This event's response payload is the client-visible snapshot reset.
7. You continue producing new output items and then emit your terminal event.

The reset `in_progress` is important: reconnecting clients replace their partial
in-progress view with that payload before applying later output events.

### What the Library Does

- Persists every SSE event in order. The recovered handler's duplicate `response.created` is suppressed on the durable stream so replay sees it exactly once.
- Persists the response object at `response.created`, each successful `stream.Checkpoint()`, and terminal events.
- Rebuilds `ResponseContext` on recovery with the same request-scoped data and the same `ResponseId`.
- Surfaces flat recovery + steering classifiers on `ResponseContext`: `context.IsRecovery`, `context.PersistedResponse`, `context.IsSteeredTurn`, `context.PendingInputCount`, and `context.ConversationChainMetadata`.
- Treats `response.in_progress` after recovery as a snapshot reset.
- Replays persisted events to reconnecting clients using `starting_after` cursors.
- Marks non-resilient interrupted responses as `failed` rather than re-invoking the handler.

### What the Handler Does

- Branches on `context.IsRecovery` to choose fresh-entry vs recovered-entry code paths.
- Builds the resumption response from upstream state plus its own metadata watermarks, excluding in-flight items.
- Emits `EmitCreated()` unconditionally and emits `EmitInProgress()` early in the recovered path so clients get a reset point.
- Uses the upstream framework's native resume facility before repeating side-effecting work.
- Watermarks any upstream side-effecting call by writing a small marker to `context.ConversationChainMetadata` before the call and clearing it after the upstream commit. Use `FlushAsync()` when the marker must survive a crash before the next lifecycle boundary.

### Stream Checkpoints

For resilient background responses, `ResponseEventStream.Checkpoint()` persists a
snapshot of `stream.Response` at explicit, developer-chosen phase boundaries. A
checkpoint writes the completed output items currently in the response, so a
crashed attempt can resume from that boundary instead of re-running the whole
turn.

Semantics:

- **Deterministic + developer-driven.** Checkpoints happen only where you yield one.
- **Backpressured.** The handler is suspended at the yield until the provider write completes.
- **No-op unless resilient background.** The signal is dropped outside `ResilientBackground=true`, `store=true`, `background=true`.
- **Idempotent.** A byte-identical snapshot is skipped.
- **Failures swallowed.** Provider errors are logged and recovery falls back to the previous snapshot.
- **After terminal.** A checkpoint after a terminal event is dropped; the terminal write is authoritative.

#### `context.PersistedResponse`

On a recovered entry, `context.PersistedResponse` is the last durable response
snapshot: the last checkpoint, or the `response.created` snapshot if no
checkpoint ran. It is an entry-time recovery aid; read it at the start of a
recovered invocation to decide where to resume.

### Item and Response `internal_metadata`

Internal metadata is a single-turn, platform-internal key/value bag that rides
on output items and on the response, is persisted with the response, and is
stripped before client-facing HTTP or SSE payloads. In .NET, response-level
internal metadata is exposed as `stream.InternalMetadata`; item-level
`internal_metadata` is also stripped from persisted payload trees before egress.
Use internal metadata for lightweight per-turn watermarks, id mappings, or
stale-message detection that should be recovered from `context.PersistedResponse`
but never sent to clients.

### Which metadata facility?

| Facility | Scope / lifetime | Visible to client? | Use for |
|---|---|---|---|
| `ResponseObject.Metadata` | Single response; client-owned | **Yes** | Values the caller set and expects back on the response. |
| `internal_metadata` | Single turn; framework-internal | **No** — stripped on egress | Per-turn bookkeeping you want persisted with the response for recovery. |
| `context.ConversationChainMetadata` | Whole conversation chain; survives crash and spans turns | **No** | Cross-turn / cross-crash resume state: phase watermarks, turn counts, side-effect fences. |

**Rule of thumb:** need it in a later turn or recovery →
`ConversationChainMetadata`; need it only to reconstruct this response on crash
recovery → `internal_metadata` plus `stream.Checkpoint()`; need it visible to the
client → `ResponseObject.Metadata`.

### Default Pattern (recovery-aware)

A recovery-aware handler uses the same first events on fresh and recovered
entries: `EmitCreated()` followed by `EmitInProgress()`. The difference is the
stream seed. On recovery, seed from `context.PersistedResponse` or a resumption
response built from upstream state. On fresh entry, seed from the incoming
`CreateResponse` request.

Then apply the cancellation contract from [Cancellation](#cancellation): check
shutdown first, call `ExitForRecoveryAsync()` for resilient deferral, distinguish
client cancellation with `context.ClientCancelled`, and treat steering pressure
as a clean completed turn.

### Fallback Pattern (no opt-in)

A handler that does nothing recovery-specific still produces a correct response.
The library accepts the duplicate `created` from re-entry, accepts a fresh
`in_progress` reset, and accumulates the re-streamed content as the new
authoritative view.

The cost is UX and side effects: reconnecting clients may see a reset to empty
and a full re-stream, and upstream side-effecting calls may be issued twice. If
your upstream has resilient history that matters, adopt the recovery-aware
pattern.

### Upstream History Pattern (preferred when available)

Many stateful upstream SDKs expose their persisted conversation log directly.
When that API is available, use it as the source of truth for whether the prior
attempt already sent this turn. Query history, compare, and send only if needed.
This avoids the window between issuing an upstream call and writing a handler
watermark.

### Watermark Pattern (fallback when upstream exposes no persisted history)

When the upstream SDK does not expose its committed log, stamp a small marker in
`context.ConversationChainMetadata` before the side-effecting call and clear it
after the upstream commit. The strict at-most-once pattern is:

1. write marker;
2. `FlushAsync()`;
3. perform the side effect;
4. clear marker;
5. `FlushAsync()`.

On recovery, a set marker means the prior attempt reached the upstream call;
use the upstream resume facility instead of issuing the call again. A missing or
false marker means no prior side effect is known.

### Resumption Response Construction

The resumption response is the `ResponseObject` you seed into
`ResponseEventStream` on a recovered entry; its `Output` is the client-visible
reset point. If you used framework checkpoints, `context.PersistedResponse`
already contains the committed items and can be used as-is. If the snapshot or
upstream view may include work that did not commit, trim it down to only the
items you trust before resuming.

Signals you can use to decide what to keep include upstream checkpoint state,
item-level `internal_metadata`, response-level `internal_metadata`, and
`context.ConversationChainMetadata` watermarks.

### Recovery × Cancellation Composition

The cancellation contract composes with recovery:

- **Recovered entry + cancellation already signalled**: inspect the cause flags. Steering emits `completed`; explicit client cancel returns/propagates; shutdown uses `ExitForRecoveryAsync()`.
- **Recovered entry + cancellation mid-stream**: break the loop, then check `context.Shutdown` / `context.IsShutdownRequested` before closing builders so shutdown can defer for recovery.
- **Crash during recovery itself**: the same path runs again; each attempt recomputes a resumption response and emits a fresh reset `in_progress`.

### Configuration

| Option | Default | Description |
|---|---|---|
| `ResilientBackground` | `false` | Opt into crash-recoverable background responses. |
| `SteerableConversations` | `false` | Multi-turn conversation steering; independent of resilience. |

See the [Resilient Responses Developer Guide](resilient-responses-developer-guide.md)
for the configuration matrix (`store` × `background` × `ResilientBackground`),
the recovery + steering surface, and client-side reconciliation rules.

---

## Steering API

Steering (`SteerableConversations = true`) lets a new turn arrive on an
already-active conversation. The framework queues the new turn, cancels the
in-progress turn via the handler's `CancellationToken`, and then re-invokes the
handler to drain the queued input. The handler-facing surface is:

- **`context.IsSteeredTurn`** — `true` on the drain re-entry that follows a steering input, not on the turn that was superseded.
- **`context.PendingInputCount`** — live count of additional inputs queued behind the current turn.
- **`ResponsesServerOptions.ResponseAcceptor`** — the hook that produces the `queued` response returned to the POST that was queued onto an already-active steerable conversation.

### `ResponsesServerOptions.ResponseAcceptor`

When a new turn is queued onto an active steerable conversation, the framework
immediately returns a `status="queued"` response to that POST while the prior
turn finishes. By default this is a minimal queued envelope; set
`ResponseAcceptor` to customize it.

- The framework ensures `status` defaults to `queued` if omitted.
- If the hook throws, the framework logs a warning and falls back to the default queued envelope.
- The hook is optional; omit it to use the default envelope.

---

## Best Practices

### 1. Start with TextResponse

Use `TextResponse` for text-only responses — it handles all lifecycle events automatically. Drop down to `ResponseEventStream` only when you need function calls, reasoning items, multiple outputs, or fine-grained event control.

### 2. Always Emit Created First, Terminal Last

Every `ResponseEventStream` handler must yield `stream.EmitCreated()` followed by `stream.EmitInProgress()` as its first two events, and exactly one terminal event (`EmitCompleted`, `EmitFailed`, or `EmitIncomplete`) as its last. The library validates this ordering. `TextResponse` handles this automatically.

### 3. Use Small, Frequent Deltas

For streaming mode, smaller deltas create a more responsive UX. Don't buffer the entire response — stream it as it's generated:

```csharp
// Good: Stream word-by-word
foreach (var word in words)
{
    yield return text.EmitDelta(word + " ");
    await Task.Delay(50, cancellationToken); // Simulate generation
}
```

### 4. Check Cancellation in Loops

Any long-running loop should check `cancellationToken`:

```csharp
foreach (var item in largeCollection)
{
    cancellationToken.ThrowIfCancellationRequested();
    // ... process item ...
}
```

### 5. Pass CancellationToken to Async Calls

```csharp
var result = await httpClient.GetAsync(url, cancellationToken);
var data = await database.QueryAsync(query, cancellationToken);
```

### 6. Close Every Builder You Open

Every builder follows `EmitAdded()` → work → `EmitDone()`. If you forget `EmitDone()`, the response will have incomplete output items.

### 7. Use `await Task.CompletedTask` for Sync Handlers

If your `ResponseEventStream` handler does no async work, the compiler requires at least one `await`. Use `await Task.CompletedTask` at the top:

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(...)
{
    await Task.CompletedTask;
    // ... synchronous work with yield return ...
}
```

> **Tip**: `TextResponse` handlers that use `return new TextResponse(...)` don't need `await Task.CompletedTask` or `[EnumeratorCancellation]` — they use `return` instead of `yield return`.

### 8. Register as Singleton for Stateless, Scoped for Stateful

```csharp
// Stateless handler — one instance for the lifetime of the app
builder.Services.AddSingleton<ResponseHandler, MyHandler>();

// Stateful handler — new instance per request
builder.Services.AddScoped<ResponseHandler, MyStatefulHandler>();
```

### 9. Prefer Convenience Generators Over Builders

Start with `OutputItemMessage(...)` and other convenience generators. Drop down to `AddOutputItemMessage()` builders only when you need fine-grained control.

### 10. Let the Library Handle Mode Negotiation

You usually do not need to branch on `request.Stream` or `request.Background`. The library negotiates the wire mode and replays the same event sequence for streaming, non-streaming, and background callers. Emit one event sequence and let the framework adapt it; reach for mode-specific behaviour only if your application genuinely needs it.

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
// ❌ Missing EmitDone on the content builder
var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitTextDone("text");
yield return message.EmitDone(); // Content wasn't properly closed

// ✅ Always call EmitDone on the content builder before closing the message
var text = message.AddTextContent();
yield return text.EmitAdded();
yield return text.EmitTextDone("text");
yield return text.EmitDone(); // Close the content part
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

When emitting raw events (without `ResponseEventStream` builders), each `response.*` event **fully replaces** the library's tracked `ResponseObject` with the event's embedded `ResponseObject`. If the terminal `response.completed` has empty output, accumulated `output_item.added/done` items are lost. Additionally, the handler **must** set the correct `Status` on the `ResponseObject` before yielding a terminal event — the library validates but never auto-sets terminal status.

```csharp
// ❌ Terminal response has empty output — items accumulated via output_item.added are lost
var response = new ResponseObject(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseOutputItemAddedEvent(0, 0, msg);
yield return new ResponseCompletedEvent(0, response); // response.Output is still empty!

// ❌ Status not set — library validates and emits response.failed
var response = new ResponseObject(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseCompletedEvent(0, response); // Status is still null!

// ✅ Include output items and set Status in the terminal response
var response = new ResponseObject(ctx.ResponseId, "test-model");
yield return new ResponseCreatedEvent(0, response);
yield return new ResponseOutputItemAddedEvent(0, 0, msg);

var completedResponse = new ResponseObject(ctx.ResponseId, "test-model");
completedResponse.Output.Add(msg);              // Handler is source of truth
completedResponse.Status = ResponseStatus.Completed;
completedResponse.CompletedAt = DateTimeOffset.UtcNow;
yield return new ResponseCompletedEvent(0, completedResponse);
```

**Note**: This only applies to raw event construction. When using `ResponseEventStream` builders (e.g., `stream.EmitCompleted()`), the library automatically includes all accumulated output items in the terminal response — no additional work is needed.

### Expecting a Running Snapshot of the Prior Attempt's In-Flight State

The library persists the response object at `response.created`, each
`stream.Checkpoint()`, and terminal events — not continuously. Use
`context.PersistedResponse` for the last durable snapshot, or build a resumption
response from upstream state.

### Calling Upstream Side-Effecting APIs on Recovery Without a Watermark

If a recovered handler blindly calls an upstream side-effecting API again, it can
duplicate messages, tool calls, or other effects in the upstream session. Prefer
an upstream history check when available; otherwise use
`context.ConversationChainMetadata` watermarks and `FlushAsync()` fences.

### Emitting `response.created` Without `response.in_progress` on Recovery

On recovery, `EmitInProgress()` is the client-visible reset point. Emit
`EmitCreated()` unconditionally, then `EmitInProgress()` before any output items
so reconnecting clients replace pre-crash partial state with the resumption
response.

### Storing Conversation History in `context.ConversationChainMetadata`

Conversation-chain metadata is for small watermarks and references, not full
conversation history or LLM outputs. Store bulk state in the upstream framework
or your own backing store and keep only a session/checkpoint reference in
`ConversationChainMetadata`.

---

## See also

- [Resilience contract](resilience-contract.md) — normative per-row × per-path conformance contract.
- [Resilient Responses Developer Guide](resilient-responses-developer-guide.md) — full .NET resilience guide and configuration matrix.
- [Sample 19 — Resilient Streaming](../samples/Sample19_ResilientStreaming.md), [Sample 20 — Resilient Steering](../samples/Sample20_ResilientSteering.md), and [Sample 22 — Resilient Multi-turn](../samples/Sample22_ResilientMultiTurn.md) — worked resilient samples.
