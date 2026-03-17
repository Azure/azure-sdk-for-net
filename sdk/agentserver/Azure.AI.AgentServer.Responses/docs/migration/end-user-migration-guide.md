# End-User Migration Guide

> Migrating from `Azure.AI.AgentServer.Core` (v1.0.0-beta.11, feature branch `agentserver/first-release`) to `Azure.AI.AgentServer.Responses` (v0.1.0-preview)

---

## Executive Summary

The new SDK is a ground-up rewrite that replaces the old `Azure.AI.AgentServer.Core` package. It delivers the same core purpose — building .NET servers that implement the Azure AI Responses API — but with a fundamentally different architecture, a dramatically simplified developer experience, and significant new capabilities. The old SDK evolved from a minimal invocation layer in beta.1 to a rich runtime with Foundry tool integration, middleware pipelines, and user identity in beta.11. The new SDK takes a different approach: it provides a minimal, composable library that consumers integrate into their own ASP.NET Core hosts.

**Key changes at a glance:**

| Area | Old SDK (`AgentServer.Core` beta.11) | New SDK (`Responses.Server.Sdk`) |
|------|--------------------------------------|----------------------------------|
| Package name | `Azure.AI.AgentServer.Core` | `Azure.AI.AgentServer.Responses` |
| Target frameworks | `net9.0` + `net8.0` | `net8.0` |
| Handler interface | `IAgentInvocation` (2 methods, takes `AgentRunContext`) | `IResponseHandler` (1 method, takes `IResponseContext`) |
| Bootstrap | `AgentServerApplication.RunAsync()` — owns WebApplication | `AddResponsesServer()` + `MapResponsesServer()` — extension methods |
| Context model | `AgentRunContext` (rich: Request, RawPayload, UserInfo, AgentTools, IdGenerator) | `IResponseContext` (minimal: ResponseId, GetInputItemsAsync, GetHistoryAsync) |
| Endpoints | `POST /responses` (also `/runs`) | 5 endpoints (POST, GET, DELETE, Cancel, InputItems) |
| SSE streaming | Manual via `INestedStreamEventGenerator` | Builder API with automatic bookkeeping |
| Background mode | Not supported | Full support (4 execution modes) |
| Cancellation | Not supported | Cancel endpoint + cooperative CT |
| State persistence | None (fire-and-forget) | Pluggable provider (in-memory default) |
| Event replay | Not supported | SSE replay via `GET ?stream=true` |
| Tool runtime | Full `IFoundryToolRuntime` + `FoundryToolClient` + MCP + Connected tools | Not included — bring your own |
| User identity | `UserInfoContextMiddleware` extracts OID/TID from headers | Not included — bring your own |
| Middleware pipeline | `UserInfoContext` → `AgentRunContext` (built-in, ordered) | None built-in |
| Error handling | 502 for handler errors; SSE error events via `ResponseErrorEvent` | Structured error model with correct HTTP status codes |
| Health checks | `/liveness`, `/readiness` | Not included (standard ASP.NET Core health checks) |
| OTEL | Full App Insights + OTLP + OpenTelemetry exporter pipeline | `ActivitySource` for distributed tracing |
| Dependencies | Azure.AI.Projects, Azure.Monitor.OpenTelemetry, ModelContextProtocol, OTLP exporter | System.Reactive.Async only |

---

## 1. Package & Namespace Changes

### Package Reference

```diff
- <PackageReference Include="Azure.AI.AgentServer.Core" />
+ <PackageReference Include="Azure.AI.AgentServer.Responses" />
```

### Dependencies Removed

The old SDK pulled in five heavyweight dependencies. The new SDK has one:

| Old Dependency | Purpose | New SDK Equivalent |
|---------------|---------|-------------------|
| `Azure.AI.Projects` | Foundry project client | Not needed — no Foundry coupling |
| `Azure.Monitor.OpenTelemetry.AspNetCore` | App Insights integration | Bring your own |
| `ModelContextProtocol` | MCP tool hosting | Not needed — no built-in tool runtime |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | OTLP export | Bring your own |
| `Azure.AI.AgentServer.Contracts` | Generated request/response models | `Azure.AI.AgentServer.Responses.Contracts` (bundled) |

### Namespace Mapping

| Old Namespace | New Namespace |
|--------------|--------------|
| `Azure.AI.AgentServer.Responses.Invocation` | `Azure.AI.AgentServer.Responses` |
| `Azure.AI.AgentServer.Contracts.Generated.Responses` | `Azure.AI.AgentServer.Responses.Models` |
| `Azure.AI.AgentServer.Contracts.Generated.OpenAI` | `Azure.AI.AgentServer.Responses.Models` |
| `Azure.AI.AgentServer.Core.Server` | `Azure.AI.AgentServer.Responses` |
| `Azure.AI.AgentServer.Core.Server.Middleware` | _(no equivalent — bring your own middleware)_ |
| `Azure.AI.AgentServer.Core.Tools.*` | _(no equivalent — no built-in tool runtime)_ |
| `Azure.AI.AgentServer.Core.Responses.Conversations` | _(no equivalent — history via `IResponseContext.GetHistoryAsync`)_ |
| `Azure.AI.AgentServer.Core.Common.Id` | _(internal in new SDK)_ |
| `Azure.AI.AgentServer.Core.Telemetry` | _(internal in new SDK)_ |
| `Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent` | _(internal in new SDK)_ |

---

## 2. Handler Interface — The Core Change

### Old: `IAgentInvocation` (two separate methods, rich context)

```csharp
// OLD (beta.11 — AgentInvocationContext is [Obsolete], replaced by AgentRunContext)
public interface IAgentInvocation
{
    Task<Response> InvokeAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default);
}
```

The old `AgentRunContext` provided rich access to:
- `Request` — the typed `CreateResponseRequest`
- `RawPayload` — the raw JSON dictionary (for custom fields)
- `UserInfo` — user identity (OID, TID) from middleware
- `AgentTools` — tool definitions passed at registration
- `IdGenerator` — ID generation (prefix-based)
- `ResponseId` / `ConversationId` — computed IDs
- `Stream` — whether streaming was requested
- `GetTools()` — resolve tool runtime tools
- `GetAgentIdObject()` / `GetConversationObject()` — typed access to request fields

### New: `IResponseHandler` (single method, minimal context)

```csharp
// NEW
public interface IResponseHandler
{
    IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        CancellationToken cancellationToken);
}
```

The new `IResponseContext` is intentionally minimal:
- `ResponseId` — the unique response ID
- `IsShutdownRequested` — server shutdown signal
- `GetInputItemsAsync()` — resolve inline + referenced input items
- `GetHistoryAsync()` — resolve conversation history

**Key differences:**
1. **Unified method** — no separate streaming/non-streaming paths; the SDK handles mode detection
2. **No raw payload** — only the typed `CreateResponse` is available
3. **No user identity** — no built-in middleware; implement your own
4. **No tool runtime** — tools are not part of the SDK; inject your own via DI
5. **No agent tools** — not passed through context; use DI
6. **Builder API** — use `ResponseEventStream` to emit events (replaces `INestedStreamEventGenerator`)

---

## 3. Bootstrap / Application Startup

### Old: Opinionated Application Owner

```csharp
// OLD — the SDK owns the entire WebApplication
await AgentServerApplication.RunAsync(
    args,
    new ApplicationOptions
    {
        EndpointName = "MyAgent",
        AgentInvocation = typeof(MyHandler),
        ConfigureServices = services => { /* custom DI */ },
        LoggerFactory = myLoggerFactory,
        ToolRuntime = myToolRuntime,        // beta.6+
        UserProvider = myUserResolver,       // beta.6+
        AgentTools = [tool1, tool2],         // beta.6+
        TelemetrySourceName = "MyAgent",
    });
```

The old SDK created the `WebApplicationBuilder`, configured Kestrel (HTTP/1 on `DEFAULT_AD_PORT`), registered the handler, set up the middleware pipeline (UserInfoContext → AgentRunContext), mapped endpoints, configured full OTEL pipeline (App Insights + OTLP), and ran the application.

### New: Composable Library Extensions

```csharp
// NEW — the consumer owns the WebApplication
var builder = WebApplication.CreateBuilder(args);

// Register your handler
builder.Services.AddSingleton<IResponseHandler, MyHandler>();

// Register the SDK
builder.Services.AddResponsesServer(options =>
{
    options.DefaultModel = "gpt-4o";
    options.SseKeepAliveInterval = TimeSpan.FromSeconds(15);
});

var app = builder.Build();

// Map the API routes
app.MapResponsesServer("/openai/v1");

app.Run();
```

**Key differences:**
- Consumer owns `WebApplication` — full control over Kestrel, logging, middleware
- No `ApplicationOptions` — configure via `ResponsesServerOptions` and standard DI
- No built-in OTEL — add App Insights and OTLP yourself
- No built-in middleware pipeline — add your own middleware for user identity etc.
- No `ToolRuntime` / `UserProvider` / `AgentTools` parameters — use DI

---

## 4. Streaming & Event Emission

### Old: Nested Stream Event Generator

```csharp
// OLD — AgentInvocationBase pattern
protected override async Task<(INestedStreamEventGenerator<Response>, Func<CancellationToken, Task>)>
    DoInvokeStreamAsync(AgentRunContext context, CancellationToken ct)
{
    var generator = context.CreateNestedStreamEventGenerator();
    var textOutput = generator.AddTextOutputItem();
    textOutput.AppendContent("Hello");
    textOutput.Done();
    generator.Complete();
    return (generator, PostInvoke);          // PostInvoke hook runs after streaming
}

private async Task PostInvoke(CancellationToken ct) { /* cleanup */ }
```

### New: Builder API

```csharp
// NEW
public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request, IResponseContext context,
    [EnumeratorCancellation] CancellationToken ct)
{
    var stream = new ResponseEventStream(context, request);
    stream.Response.Model = "gpt-4o";

    yield return stream.EmitCreated();
    yield return stream.EmitInProgress();

    var msg = stream.AddOutputItemMessage();
    yield return msg.EmitAdded();

    var text = msg.AddTextContent();
    yield return text.EmitAdded();
    yield return text.EmitDelta("Hello");
    yield return text.EmitDone("Hello");
    yield return msg.EmitContentDone(text);
    yield return msg.EmitDone();

    yield return stream.EmitCompleted();
}
```

**Key differences:**
- No abstract base class hierarchy — just implement `IResponseHandler` directly
- No `INestedStreamEventGenerator` — use `ResponseEventStream` and builders
- No `PostInvoke` hook — return pattern not supported; do cleanup in handler after yielding final event
- Builder API manages sequence numbers, output indices, and ID generation automatically
- Explicit `yield return` for every event — full control over timing
- 15+ specialized builder types (message, function call, MCP, reasoning, etc.)

---

## 5. Request Model Changes

### Type Rename

| Old | New |
|-----|-----|
| `CreateResponseRequest` | `CreateResponse` |
| `ResponseStreamEvent` | `ResponseStreamEvent` (same) |
| `OutputItem` | `OutputItem` (same) |
| `Response` | `Response` (same) |

### Input Access

```csharp
// OLD — via AgentRunContext
var request = context.Request;
var rawPayload = context.RawPayload; // Dictionary<string, object?>
var stream = context.Stream;         // bool
var responseId = context.ResponseId;
var conversationId = context.ConversationId;
var agentId = context.GetAgentIdObject();
var conversation = context.GetConversationObject();

// NEW — via CreateResponse directly + IResponseContext
var responseId = context.ResponseId;
var conversationId = request.GetConversationId();     // extension method
var inputItems = request.GetInputExpanded();           // typed items
var inputText = request.GetInputText();                // combined text
var toolChoice = request.GetToolChoiceExpanded();       // typed union
// stream/background flags are consumed by SDK — not available to handler
```

---

## 6. Endpoints

| Endpoint | Old SDK | New SDK |
|----------|---------|---------|
| `POST /responses` | ✅ | ✅ |
| `POST /runs` | ✅ (alias via regex) | ❌ Not supported |
| `GET /responses/{id}` | ❌ | ✅ |
| `GET /responses/{id}?stream=true` | ❌ | ✅ SSE replay |
| `POST /responses/{id}/cancel` | ❌ | ✅ |
| `DELETE /responses/{id}` | ❌ | ✅ |
| `GET /responses/{id}/input_items` | ❌ | ✅ Paginated |
| `/liveness` | ✅ Health check | ❌ Use ASP.NET Core health checks |
| `/readiness` | ✅ Health check | ❌ Use ASP.NET Core health checks |

---

## 7. Execution Modes

The old SDK only supported two modes: streaming and non-streaming (determined by examining the request). The new SDK supports four modes, determined by `stream` and `background` flags:

| Mode | `stream` | `background` | Behaviour |
|------|----------|-------------|-----------|
| Default | `false` | `false` | Collect all events → return final JSON |
| Streaming | `true` | `false` | SSE event stream, fail on client disconnect |
| Background | `false` | `true` | Return `200 OK` with `queued` status, handler runs asynchronously |
| Background + Streaming | `true` | `true` | Return SSE, survive client disconnect, events replayable via GET |

---

## 8. State Persistence

### Old: Fire-and-Forget

The old SDK had no state persistence. Once the response was streamed, it was gone. No GET, DELETE, or cancel operations were possible.

### New: Pluggable Provider

The new SDK uses `IResponsesProvider` for state persistence (in-memory by default):

```csharp
// Optional: implement for distributed deployment
public class RedisResponsesProvider : IResponsesProvider, IResponsesStreamProvider, IResponsesCancellationSignalProvider
{
    // CreateResponseAsync, GetResponseAsync, UpdateResponseAsync, DeleteResponseAsync
    // GetInputItemsAsync, GetItemsAsync, GetHistoryItemIdsAsync
    // CreateEventPublisherAsync, SubscribeToEventsAsync
    // CancelResponseAsync, GetResponseCancellationTokenAsync
}

// Register
builder.Services.AddSingleton<IResponsesProvider, RedisResponsesProvider>();
builder.Services.AddSingleton<IResponsesStreamProvider, RedisResponsesProvider>();
builder.Services.AddSingleton<IResponsesCancellationSignalProvider, RedisResponsesProvider>();
```

---

## 9. Conversation History

### Old: `ConversationItemsClient` (Foundry Conversations API)

```csharp
// OLD — explicit Foundry API call
var client = new ConversationItemsClient(endpoint, credential);
var items = await client.ListItemsAsync(conversationId, ct);
```

The old SDK provided a dedicated client that called the Foundry `openai/conversations/{id}/items` API endpoint. This was tightly coupled to the Azure Foundry platform.

### New: Provider-Based History Resolution

```csharp
// NEW — history is resolved through the provider
var history = await context.GetHistoryAsync(ct);
```

The new SDK resolves history through `IResponsesProvider.GetHistoryItemIdsAsync()` + `GetItemsAsync()`, which uses `previous_response_id` and/or `conversation` context from the request. The in-memory provider chains responses automatically. For Foundry integration, implement a custom provider that wraps the conversation API.

---

## 10. User Identity

### Old: Built-in Middleware Pipeline

```csharp
// OLD — extracted automatically from headers
// UserInfoContextMiddleware reads x-aml-oid and x-aml-tid headers
// Stored in AsyncLocalUserProvider.Current
var userInfo = context.UserInfo; // UserInfo { ObjectId, TenantId }
```

The old SDK had `UserInfoContextMiddleware` that extracted Azure ML identity headers (`x-aml-oid`, `x-aml-tid`) and stored them in `AsyncLocal<UserInfo>`. The `AgentRunContext` provided direct access via `.UserInfo`.

### New: Not Included

The new SDK does not include user identity middleware. Implement your own:

```csharp
// NEW — bring your own middleware
app.Use(async (context, next) =>
{
    var oid = context.Request.Headers["x-aml-oid"].FirstOrDefault();
    var tid = context.Request.Headers["x-aml-tid"].FirstOrDefault();
    context.Items["UserInfo"] = new UserInfo(oid, tid);
    await next();
});

// Access in your handler via HttpContextAccessor or DI
```

---

## 11. Tool Runtime

### Old: Full Foundry Tool Runtime

The old SDK included a comprehensive tool runtime system:

```csharp
// OLD — ApplicationOptions
await AgentServerApplication.RunAsync(args, new ApplicationOptions
{
    ToolRuntime = myToolRuntime,
    AgentTools = [tool1, tool2],
});

// In handler
var tools = await context.GetTools();     // Lists tools from runtime
var result = await context.Tools.InvokeAsync(tool, args, ct);
```

Key components:
- `IFoundryToolRuntime` — catalog + invocation facade
- `IFoundryToolCatalog` — tool discovery and resolution (with caching)
- `IFoundryToolInvocationResolver` — tool invocation
- `FoundryToolClient` — HTTP client for MCP and Connected tools
- `FoundryMcpToolsOperations` — hosted MCP tool operations
- `FoundryConnectedToolsOperations` — connected tool operations
- `ResolvedFoundryTool` — resolved tool descriptor with embedded invokers
- `AgentServerContext` — singleton access to tool runtime
- Exception types: `OAuthConsentRequiredException`, `MCPToolApprovalRequiredException`
- `HumanInTheLoopFunctionName` — constant for human-in-the-loop tool calls

### New: Not Included

The new SDK does not include a tool runtime. Tools are the consumer's responsibility:

```csharp
// NEW — bring your own tools via DI
builder.Services.AddSingleton<IMyToolService, MyToolService>();

// In handler
public class MyHandler(IMyToolService tools) : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(...)
    {
        // Use injected tool service directly
        var result = await tools.InvokeAsync("myTool", args, ct);
    }
}
```

---

## 12. Error Handling

### Old: 502 + SSE Error Events

```csharp
// OLD — AgentInvocationException → 502
throw new AgentInvocationException("Something failed");
// → HTTP 502 Bad Gateway

// OLD — SSE error events (beta.5+)
// AgentInvoker catches exceptions and writes ResponseErrorEvent to SSE
```

### New: Structured Error Model

```csharp
// NEW — ResponsesApiException with configurable status code
throw new ResponsesApiException(
    new Error { Message = "Something failed", Code = "server_error" },
    statusCode: 500);

// NEW — BadRequestException for validation errors
throw new BadRequestException("Invalid param", "temperature");

// NEW — PayloadValidationException for schema errors
// → 400 with details[] array

// NEW — ResourceNotFoundException
throw new ResourceNotFoundException("Response not found");
// → 404
```

| Scenario | Old SDK | New SDK |
|----------|---------|---------|
| Handler exception | 502 Bad Gateway | 500 Internal Server Error |
| Handler typed exception | `AgentInvocationException` → 502 | `ResponsesApiException` → configurable status |
| Payload validation | None | 400 with per-field `details[]` |
| Not found | None | 404 |
| Client disconnect | No special handling | 499 (logged) |
| SSE error event | `ResponseErrorEvent` written by `AgentInvoker` | `ResponseErrorEvent` written by `ResponseOrchestrator` |

---

## 13. Cancellation

### Old: Not Supported

The old SDK did not support cancellation. `CancellationToken` was passed through but there was no cancel endpoint or explicit cancellation mechanism beyond client disconnect.

### New: Full Cancellation Support

```csharp
// Cancel a background response
POST /responses/{id}/cancel

// In handler — CancellationToken is triggered on:
// 1. Client disconnect (non-background mode)
// 2. Explicit cancel request (background mode)
// 3. Server shutdown (all modes)

// Distinguish shutdown from cancel
if (context.IsShutdownRequested)
    yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
```

---

## 14. OTEL / Telemetry

### Old: Full Pipeline

The old SDK configured a complete telemetry pipeline in `AgentServerApplication.RunAsync()`:
- Azure Monitor / App Insights integration (`Azure.Monitor.OpenTelemetry.AspNetCore`)
- OTLP exporter (`OpenTelemetry.Exporter.OpenTelemetryProtocol`)
- `HostedAgentTelemetry.Source` — `ActivitySource("Azure.AI.AgentServer")`
- OpenTelemetry Baggage for distributed tracing (response_id, conversation_id, agent.id, etc.)
- `AppConfiguration` for configuring telemetry via env vars (`AGENT_APP_INSIGHTS_ENABLED`, `APPLICATIONINSIGHTS_CONNECTION_STRING`, `OTEL_EXPORTER_ENDPOINT`)
- Semantic conventions: `gen_ai.agent.name`, `gen_ai.agent.id`, `gen_ai.provider.name`, `gen_ai.response.id`

### New: Minimal ActivitySource

The new SDK exposes an `ActivitySource` for distributed tracing but does not configure exporters or integrations. Add your own:

```csharp
// Standard ASP.NET Core OpenTelemetry setup
builder.Services.AddOpenTelemetry()
    .WithTracing(b => b
        .AddSource("Azure.AI.AgentServer.Responses")
        .AddAspNetCoreInstrumentation()
        .AddOtlpExporter());
```

---

## 15. ID Generation

### Old: Prefix-Based IDs

```csharp
// OLD
context.ResponseId;        // Generated in AgentRunContext constructor
context.IdGenerator.NewId("msg");  // Prefixed ID generation
```

Default prefixes: `caresp_` (response), `msg_`, `fc_`, `rs_`, etc.

### New: Prefix-Based IDs (Compatible)

```csharp
// NEW — via extension methods on IResponseContext
context.ResponseId;              // Generated by SDK
context.NewMessageItemId();      // msg_{partitionKey}{entropy}
context.NewFunctionCallItemId(); // fc_{...}
// etc. for all output item types
```

The prefix scheme is compatible. The new SDK uses the same general pattern (`{prefix}_{partitionKey}{entropy}`) with some prefix differences:

| Item Type | Old Prefix | New Prefix |
|-----------|-----------|-----------|
| Response | `caresp` | `caresp` |
| Message | `msg` | `msg` |
| Function call | `fc` | `fc` |
| Reasoning | `rs` | `rs` |
| File search | `fs` | `fs` |
| Web search | `ws` | `ws` |
| Code interpreter | `ci` | `ci` |
| Image gen | `ig` | `ig` |
| MCP call | `mcp` | `mcp` |
| MCP list tools | `mcpl` | `mcpl` |
| Custom tool call | `ctc` | `ctc` |

---

## 16. SSE Wire Format

| Feature | Old SDK | New SDK |
|---------|---------|---------|
| Content type | `text/event-stream; charset=utf-8` | `text/event-stream; charset=utf-8` |
| SSE headers | `Cache-Control: no-cache`, `X-Accel-Buffering: no`, `Connection: keep-alive` | `Cache-Control: no-cache`, `X-Accel-Buffering: no`, `Connection: keep-alive` |
| Keep-alive interval | 15 seconds (hardcoded) | Configurable, disabled by default |
| Keep-alive format | `: keep-alive\n\n` | `: keep-alive\n\n` |
| Backpressure | `ActionBlock<string>` bounded queue (256 capacity) | `SemaphoreSlim(1)` serialized writes |
| `event:` field | Event type string | Event type string |
| `data:` field | `JsonSerializer` with `JsonModelConverter` | `JsonSerializer` with TypeSpec converters, `sequence_number` injected via `JsonNode` |
| SSE replay | Not supported | `GET /responses/{id}?stream=true` replays from cursor |
| Error events | Written by `AgentInvoker` on unhandled exceptions | Written by `ResponseOrchestrator` |

---

## 17. Configuration

### Old: Environment Variables + `AppConfiguration`

| Old Env Var | Purpose |
|------------|---------|
| `DEFAULT_AD_PORT` | Kestrel listen port |
| `AGENT_APP_INSIGHTS_ENABLED` | Enable/disable App Insights |
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | App Insights connection |
| `OTEL_EXPORTER_ENDPOINT` | OTLP exporter endpoint |
| `AZURE_TENANT_ID` | Azure tenant ID |
| `AGENT_SUBSCRIPTION_ID` | Azure subscription ID |
| `AGENT_RESOURCE_GROUP` | Azure resource group |
| `AGENT_PROJECT_NAME` | Foundry project name |
| `AGENT_LOG_LEVEL` | Log level |

### New: Environment Variables + `ResponsesServerOptions`

| New Env Var | Purpose |
|------------|---------|
| `AZURE_AI_RESPONSES_SERVER_SSE_KEEPALIVE_INTERVAL` | SSE keep-alive interval |
| `AZURE_AI_RESPONSES_SERVER_DEFAULT_FETCH_HISTORY_ITEM_COUNT` | Max history items to fetch |

The new SDK has far fewer configuration knobs — environment-specific concerns (ports, OTEL, identity) are owned by the consumer's ASP.NET Core host.

---

## 18. Migration Checklist

- [ ] Replace NuGet package reference: `Azure.AI.AgentServer.Core` → `Azure.AI.AgentServer.Responses`
- [ ] Update namespaces (see §1)
- [ ] Rewrite handler from `IAgentInvocation` (2 methods) to `IResponseHandler` (1 method)
- [ ] Replace `AgentServerApplication.RunAsync()` with `AddResponsesServer()` + `MapResponsesServer()`
- [ ] Create your own `WebApplication` host (Program.cs)
- [ ] Replace `INestedStreamEventGenerator` with `ResponseEventStream` builder API
- [ ] Replace `AgentRunContext` properties with `CreateResponse` extensions + `IResponseContext`
- [ ] Remove direct `context.UserInfo` access — implement own middleware if needed
- [ ] Remove `context.GetTools()` / `AgentServerContext.Get().Tools` — implement own tool service via DI
- [ ] Remove `PostInvoke` hook — do cleanup after yielding final event
- [ ] Remove `context.RawPayload` usage — use typed `CreateResponse` only
- [ ] Remove `context.Stream` checks — SDK handles mode detection
- [ ] Remove `AgentInvocationException` — use `ResponsesApiException` or `BadRequestException`
- [ ] Replace health check endpoints with standard ASP.NET Core health checks
- [ ] Configure OTEL manually (App Insights, OTLP exporter) if needed
- [ ] Replace `ConversationItemsClient` usage with `context.GetHistoryAsync()` or custom provider
- [ ] Update environment variables (see §17)
- [ ] If using `/runs` endpoint alias, update clients to use `/responses`
- [ ] If using `HumanInTheLoopFunctionName`, implement equivalent custom function call handling
- [ ] Test with all 4 execution modes (streaming, non-streaming, background, background+streaming)
- [ ] Implement `IResponsesProvider` for distributed deployments (replaces fire-and-forget model)
