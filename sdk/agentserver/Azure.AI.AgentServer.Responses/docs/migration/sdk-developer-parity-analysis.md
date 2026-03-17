# SDK Developer Parity Analysis

> Detailed comparison between `Azure.AI.AgentServer.Core` (v1.0.0-beta.11, feature branch `agentserver/first-release`) and `Azure.AI.AgentServer.Responses` (v0.1.0-preview) for SDK developers responsible for maintaining feature parity and discovering gaps.

---

## 1. Parity Status Overview

### Legend

- ✅ **Parity achieved** — feature exists in new SDK with equivalent or superior implementation
- ⚠️ **Partial parity** — feature exists but with differences that may need attention
- ❌ **Not implemented** — feature from old SDK is missing in new SDK
- 🆕 **New feature** — exists only in new SDK (not in old)
- 🔀 **AgentServer library** — belongs in `Azure.AI.AgentServer.Core`, a Foundry-specific agent server package that composes with protocol-specific SDKs for developers hosting and integrating with Foundry
- 🏗️ **Consumer-owned** — standard ASP.NET Core pattern; consumer adds via built-in framework features

---

## 2. Feature-by-Feature Parity Matrix

### 2.1 Core Handler Contract

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| Handler interface | `IAgentInvocation` (2 methods: `InvokeAsync`, `InvokeStreamAsync`) | `IResponseHandler` (1 method: `CreateAsync`) | ✅ Superior — unified model |
| Abstract base class | `AgentInvocationBase` — wraps exceptions, adds telemetry Activity, returns `(Generator, PostInvoke)` tuple | None — SDK handles internally | ✅ Simplified |
| Streaming event factory | `DoInvokeStreamAsync` returns `INestedStreamEventGenerator<Response>` plus `Func<CancellationToken, Task> PostInvoke` hook | Handler yields `IAsyncEnumerable<ResponseStreamEvent>` directly via builder API | ✅ Simpler |
| PostInvoke hook | `Func<CancellationToken, Task>` — runs after SSE streaming completes | Not supported — cleanup after final `yield return` | ❌ G1 |
| Non-streaming handler | `DoInvokeAsync` returns `Task<Response>` | Same `CreateAsync` — SDK collects events into final JSON | ✅ Unified |
| Request type | `CreateResponseRequest` | `CreateResponse` | ✅ Renamed |
| Context type | `AgentRunContext` (public class — rich: Request, RawPayload, UserInfo, AgentTools, IdGenerator, GetTools, GetAgentIdObject, GetConversationObject) | `IResponseContext` (public interface — minimal: ResponseId, IsShutdownRequested, GetInputItemsAsync, GetHistoryAsync, RawBody) | 🔀 Foundry-specific members (UserInfo, AgentTools, GetTools) belong in `Azure.AI.AgentServer.Core` |
| AsyncLocal context | `AgentRunContext.Current` via `AsyncLocal<T>` + `Setup()` method | Not used | ✅ Removed (anti-pattern for library SDK) |
| Raw payload access | `context.RawPayload` — `IReadOnlyDictionary<string, object?>` for custom fields | `IResponseContext.RawBody` — `JsonElement` with full raw JSON body | ✅ Parity achieved |
| Stream flag access | `context.Stream` — `bool` | Not available to handler (consumed by SDK) | ✅ By design |

### 2.2 Server Bootstrap & Hosting

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| Application entry point | `AgentServerApplication.RunAsync(ApplicationOptions)` — owns the entire WebApplication | `AddResponsesServer()` + `MapResponsesServer()` — extension methods on `IServiceCollection` / `IEndpointRouteBuilder` | ✅ Standard ASP.NET Core |
| Kestrel configuration | Hardcoded HTTP/1 on configurable port (`DEFAULT_AD_PORT`) | Consumer configures Kestrel | ✅ Consumer-owned |
| Service validation | Validates `IAgentInvocation` registration, throws if missing | `MapResponsesServer()` throws `InvalidOperationException` if `IResponseHandler` not registered | ✅ Parity achieved |
| Configurable route prefix | `/runs` or `/responses` via regex constraint `^runs\|responses$` | `MapResponsesServer(prefix)` parameter | ✅ |
| `ApplicationOptions.ConfigureServices` | `Action<IServiceCollection>` callback | Not needed — consumer calls `AddResponsesServer()` directly | ✅ |
| `ApplicationOptions.LoggerFactory` | Custom `ILoggerFactory` injection | Consumer configures logging on `WebApplicationBuilder` | ✅ |
| `ApplicationOptions.TelemetrySourceName` | Configurable ActivitySource name | `ResponsesActivitySource` (public, virtual `StartCreateResponseActivity`) — subclass to override. Defaults to `"Azure.AI.AgentServer.Responses"` | ✅ Parity achieved |
| `ApplicationOptions.EndpointName` | Display name for the agent | Not available — agent display name is a Foundry deployment concept | 🔀 AgentServer library |
| `ApplicationOptions.ToolRuntime` | `IFoundryToolRuntime` injection | Not available — Foundry tool runtime is platform-specific | 🔀 AgentServer library |
| `ApplicationOptions.UserProvider` | `Func<HttpContext, Task<UserInfo?>>` injection | Not available — Foundry user resolution via AML headers | 🔀 AgentServer library |
| `ApplicationOptions.AgentTools` | `IEnumerable<object>` passed to context | Not available — Foundry tool discovery and injection | 🔀 AgentServer library |

### 2.3 Middleware Pipeline

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `UserInfoContextMiddleware` | Extracts `x-aml-oid` / `x-aml-tid` → `AsyncLocalUserProvider.Current` | Not included — Foundry-specific AML header extraction | 🔀 AgentServer library |
| `AgentRunContextMiddleware` | Parses request body → creates `AgentRunContext` → stores in `HttpContext.Items` + `AsyncLocal` + OTEL Baggage | Not included (SDK parses body in endpoint handler) | ✅ Different approach |
| Middleware ordering | `UseUserInfoContext()` → `UseAgentRunContext()` | No built-in middleware — Foundry middleware pipeline | 🔀 AgentServer library |
| Request body buffering | `EnableBuffering()` in middleware for multi-read | Handled internally by endpoint handler | ✅ |
| Error handling in middleware | `AgentRunContextMiddleware` catches exceptions → 400/500 JSON error | `ResponsesExceptionFilter` (endpoint filter) handles exceptions | ✅ Different approach |
| OTEL Baggage propagation | Middleware sets `Baggage` items (response_id, conversation_id, agent.id, streaming, provider.name) | Endpoint handler sets 7 baggage items on `Activity.Current`: response.id, streaming, provider.name, conversation.id, agent.name, agent.id, request.id | ✅ Parity achieved |

### 2.4 Endpoint Routing

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `POST /responses` | ✅ (also `/runs`) | ✅ | ✅ |
| `GET /responses/{id}` | ❌ | ✅ | 🆕 |
| `POST /responses/{id}/cancel` | ❌ | ✅ | 🆕 |
| `DELETE /responses/{id}` | ❌ | ✅ | 🆕 |
| `GET /responses/{id}/input_items` | ❌ | ✅ | 🆕 |
| `/runs` alias | ✅ (regex `^runs\|responses$`) | ❌ | ❌ G4 |
| `/liveness` health check | ✅ (`Results.Ok("Alive")`) | ❌ | 🏗️ Consumer-owned — use `MapHealthChecks()` |
| `/readiness` health check | ✅ (`Results.Ok("Ready")`) | ❌ | 🏗️ Consumer-owned — use `MapHealthChecks()` |
| Endpoint filter for exceptions | `AgentRunExceptionFilter` (IEndpointFilter) | `ResponsesExceptionFilter` (IEndpointFilter) | ✅ |
| Endpoint filter for identity | None | `SdkIdentityFilter` sets `x-platform-server` header | 🆕 |
| Endpoint tags | `WithTags("Agent Runs")` | `.WithTags("Responses")` on all 5 endpoints | ✅ Parity achieved |
| Request ID header | `X-Request-Id` extracted in middleware → OTEL Baggage | Extracted in endpoint handler → `request.id` activity tag + baggage (truncated to 256 chars) | ✅ Parity achieved |

### 2.5 SSE Streaming

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| SSE content type | `text/event-stream; charset=utf-8` | `text/event-stream; charset=utf-8` | ✅ Parity achieved |
| SSE headers | `Cache-Control: no-cache`, `X-Accel-Buffering: no`, `Connection: keep-alive` | `Cache-Control: no-cache`, `X-Accel-Buffering: no`, `Connection: keep-alive` | ✅ Parity achieved |
| Keep-alive interval | 15 seconds (hardcoded) | Configurable, disabled by default | ✅ Superior |
| Keep-alive format | `: keep-alive\n\n` | `: keep-alive\n\n` | ✅ |
| Backpressure | `ActionBlock<string>` bounded queue (256 capacity, `MaxDegreeOfParallelism = 1`) | `SemaphoreSlim(1)` serialized writes | ✅ Simpler, equivalent |
| SSE replay (GET) | ❌ | ✅ via `SseReplayResult` with cursor-based replay | 🆕 |
| `event:` field | Uses event type string | Uses event type string | ✅ |
| `data:` field | Serialized via `JsonSerializer` with `JsonModelConverter` | Serialized via `JsonSerializer` with TypeSpec converters, `sequence_number` injected via `JsonNode` | ✅ |
| Error events on SSE | `AgentInvoker` catches handler exceptions → writes `ResponseErrorEvent` | `ResponseOrchestrator` catches handler exceptions → writes `ResponseErrorEvent` | ✅ |
| `SseResult` implementation | `IResult` with `ActionBlock<string>` pipeline + `TimeoutException`-based keep-alive | `SseResult` with `SemaphoreSlim` + async iteration | ✅ Different approach |

### 2.6 Error Handling

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| Handler exception → HTTP | 502 Bad Gateway | 500 Internal Server Error | ✅ Correct |
| Handler typed exception | `AgentInvocationException` → 502 | `ResponsesApiException` → configurable status code | ✅ Superior |
| Payload validation | None | 400 with per-field `details[]` via `PayloadValidationException` | 🆕 |
| Not found | None | 404 via `ResourceNotFoundException` | 🆕 |
| Client disconnect | No special handling | 499 (logged) | 🆕 |
| Parameter-specific errors | None | `BadRequestException` with `ParamName` + `Code` | 🆕 |

### 2.7 State Management

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| Response persistence | None (fire-and-forget) | `IResponsesProvider` with `InMemoryResponsesProvider` default | 🆕 |
| Event stream persistence | None | `IResponsesStreamProvider` with `SeekableReplaySubject` | 🆕 |
| Cancellation signalling | None | `IResponsesCancellationSignalProvider` | 🆕 |
| Background execution | Not supported | Full support via `ResponseOrchestrator` + `ResponseExecution` + `ResponseExecutionTracker` | 🆕 |
| Execution mode matrix | Stream / Non-stream only | 4 modes: default, streaming, background, streaming+background | 🆕 |
| Graceful shutdown | Not handled | `ResponseExecutionTracker` signals `IsShutdownRequested` → cancels CTS → waits for background tasks | 🆕 |

### 2.8 ID Generation

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| ID format | `{prefix}_{encoded}` | `{prefix}_{partitionKey}{entropy}` | ✅ Compatible |
| Response ID prefix | `caresp` | `caresp` | ✅ |
| Message ID prefix | `msg` | `msg` | ✅ |
| Function call prefix | `fc` | `fc` | ✅ |
| Reasoning prefix | `rs` | `rs` | ✅ |
| File search prefix | `fs` | `fs` | ✅ |
| Web search prefix | `ws` | `ws` | ✅ |
| Code interpreter prefix | `ci` | `ci` | ✅ |
| Image gen prefix | `ig` | `ig` | ✅ |
| MCP call prefix | `mcp` | `mcp` | ✅ |
| MCP list tools prefix | `mcpl` | `mcpl` | ✅ |
| Custom tool call prefix | `ctc` | `ctc` | ✅ |
| Computer tool call prefix | `ctco` | `ctco` | ✅ |
| File call out prefix | `fco` | `fco` | ✅ |
| Custom prefix | `cu` | `cu` | ✅ |
| Local shell prefix | `lsh` | `lsh` | ✅ |
| Apply patch prefix | `ap` | `ap` | ✅ |
| MCP approval prefix | `mcpa` | `mcpa` | ✅ |
| MCP approval request prefix | `mcpr` | `mcpr` | ✅ |

### 2.9 Tool Runtime

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `IFoundryToolRuntime` | Full interface: `Catalog` + `Invocation` + `InvokeAsync` | Not included — Foundry platform tool orchestration | 🔀 AgentServer library |
| `IFoundryToolCatalog` | Tool discovery with caching (`CachedFoundryToolCatalog`) | Not included — Foundry tool catalog | 🔀 AgentServer library |
| `IFoundryToolInvocationResolver` | Tool invocation resolver | Not included — Foundry tool resolution | 🔀 AgentServer library |
| `FoundryToolClient` | HTTP client for MCP + Connected tools with bearer auth | Not included — Foundry tool HTTP client | 🔀 AgentServer library |
| `FoundryMcpToolsOperations` | Hosted MCP tool list + invoke | Not included — Foundry hosted MCP | 🔀 AgentServer library |
| `FoundryConnectedToolsOperations` | Connected tool resolve + invoke | Not included — Foundry connected tools | 🔀 AgentServer library |
| `ResolvedFoundryTool` | Resolved tool descriptor with `Invoker` + `AsyncInvoker` | Not included — Foundry tool resolution model | 🔀 AgentServer library |
| `FoundryToolFactory` | Dictionary → `FoundryTool` conversion | Not included — Foundry tool factory | 🔀 AgentServer library |
| `AgentServerContext` | Singleton access to tool runtime | Not included — Foundry global context | 🔀 AgentServer library |
| `OAuthConsentRequiredException` | OAuth consent required for tool | Not included — Foundry OAuth flow | 🔀 AgentServer library |
| `MCPToolApprovalRequiredException` | MCP tool approval required | Not included — Foundry MCP approval flow | 🔀 AgentServer library |
| `HumanInTheLoopFunctionName` | Constant for HITL tool calls | Not included — Foundry HITL pattern | 🔀 AgentServer library |
| Tool name conflict resolution | `NameResolver.EnsureUniqueName` | Not included — Foundry tool name dedup | 🔀 AgentServer library |

### 2.10 User Identity

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `UserInfo` model | `{ ObjectId, TenantId }` | Not included — Foundry AML identity model | 🔀 AgentServer library |
| `UserInfoContextMiddleware` | Extracts from `x-aml-oid` / `x-aml-tid` headers | Not included — Foundry AML header extraction | 🔀 AgentServer library |
| `AsyncLocalUserProvider` | AsyncLocal storage for user context | Not included — Foundry user context propagation | 🔀 AgentServer library |
| `UserResolvers` | Header → UserInfo resolution | Not included — Foundry header resolvers | 🔀 AgentServer library |
| Custom user resolver | `Func<HttpContext, Task<UserInfo?>>` via `UseUserInfoContext(resolver)` | Not included — Foundry user resolution pipeline | 🔀 AgentServer library |

### 2.11 Conversation History

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `ConversationItemsClient` | HTTP client for Foundry `openai/conversations/{id}/items` API | Not included — replaced by provider-based `GetHistoryAsync()` | ✅ Different approach |
| Response chaining | Not supported (no state) | `IResponsesProvider.GetHistoryItemIdsAsync()` follows `previous_response_id` / `conversation` | 🆕 |
| History caching in context | Not available | `IResponseContext.GetHistoryAsync()` — lazy-cached per request | 🆕 |

### 2.12 Telemetry

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `ActivitySource` | `HostedAgentTelemetry.Source = new("Azure.AI.AgentServer")` | Internal `ActivitySource("Azure.AI.AgentServer.Responses")` | ✅ |
| Activity per request | `StartActivity($"HostedAgents-{responseId}", ActivityKind.Server)` | SDK creates activity per request | ✅ |
| Activity tags — `gen_ai.agent.id` | ✅ `{name}:{version}` | ✅ `{name}:{version}` or `{name}` (no version) | ✅ Parity achieved |
| Activity tags — `gen_ai.agent.name` | ✅ | ✅ Set from `AgentReference` or `Agent` | ✅ Parity achieved |
| Activity tags — `gen_ai.provider.name` | ✅ `"AzureAI Hosted Agents"` | ✅ `"azure.ai.responses"` | ✅ Parity achieved |
| Activity tags — `gen_ai.response.id` | ✅ | ✅ Set on every request | ✅ Parity achieved |
| Activity tags — `service.name` | ✅ `"azure.ai.agentserver"` | ✅ `"azure.ai.responses"` | ✅ Parity achieved |
| Activity tags — OTEL extensions | N/A | ✅ `gen_ai.system`, `gen_ai.operation.name`, `gen_ai.request.model`, `gen_ai.conversation.id`, `gen_ai.agent.version`, `response.mode` | 🆕 |
| OTEL Baggage | response_id, conversation_id, streaming, agent.name, agent.id, provider.name, x-request-id | ✅ 7 baggage items: response.id, streaming, provider.name, conversation.id, agent.name, agent.id, request.id | ✅ Parity achieved |
| App Insights integration | Full `UseAzureMonitor()` pipeline | Not included — Foundry deployment telemetry pipeline | 🔀 AgentServer library |
| OTLP exporter | `UseOtlpExporter()` with configurable endpoint | Not included — Foundry OTLP export configuration | 🔀 AgentServer library |
| Configurable telemetry source | `ApplicationOptions.TelemetrySourceName` | `ResponsesActivitySource` (public, non-sealed \u2014 subclass and override `StartCreateResponseActivity` for full control) | \u2705 Parity achieved |

### 2.13 Configuration

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `AppConfiguration` class | Record bound to env vars (port, OTEL, project, etc.) | No equivalent — minimal `ResponsesServerOptions` | ✅ Simplified |
| `FoundryProjectEndpointResolver` | Centralised `AZURE_AI_PROJECT_ENDPOINT` resolution | Not included — Foundry project endpoint discovery | 🔀 AgentServer library |
| `FoundryProjectInfo` | Project metadata (name, subscription, resource group) | Not included — Foundry project metadata | 🔀 AgentServer library |

### 2.14 Builder API

| Feature | Old SDK | New SDK | Status |
|---------|---------|---------|--------|
| `INestedStreamEventGenerator` | Tree-based, builder creates events imperatively | Not used | ✅ Deprecated in favour of builder API |
| `ResponseEventStream` | Not available | Top-level scope: manages sequence numbers, output indices, lifecycle events | 🆕 |
| Output item builders | Not available as separate types | 15+ dedicated builders: Message, FunctionCall, Reasoning, FileSearch, WebSearch, CodeInterpreter, ImageGen, MCP, McpListTools, CustomToolCall + content builders | 🆕 |
| `ResponsesModelFactory` | Not available | Test/mock factory for Response, Error, Events, DeleteResult, PagedResult | 🆕 |

---

## 3. Identified Gaps

### Resolved Gaps (v0.1.0-preview)

The following 9 gaps were resolved in the `026-sdk-parity-gaps` implementation:

| Gap ID | Category | Resolution | Commit |
|--------|----------|------------|--------|
| G2 | Handler Contract | Added `IResponseContext.RawBody` (`JsonElement`) — exposes full raw JSON request body including custom/extension fields | `026-sdk-parity-gaps` |
| G3 | Telemetry | Added 7 OTEL Baggage items on `Activity.Current`: `response.id`, `streaming`, `provider.name`, `conversation.id`, `agent.name`, `agent.id`, `request.id` — set before handler invocation | `026-sdk-parity-gaps` |
| G5 | Endpoints | `X-Request-Id` header extracted in endpoint handler → `request.id` activity tag + baggage item (truncated to 256 chars) | `026-sdk-parity-gaps` |
| G7 | Telemetry | Full GenAI semantic convention tags: `gen_ai.response.id`, `gen_ai.agent.name`, `gen_ai.agent.id` (`{name}:{version}`), `gen_ai.agent.version`, `gen_ai.provider.name`, `gen_ai.system`, `gen_ai.operation.name`, `gen_ai.request.model`, `gen_ai.conversation.id`, `service.name`, `response.mode` | `026-sdk-parity-gaps` |
| G8 | SSE | Added `Connection: keep-alive` header to `SseResult` and `SseReplayResult` | `026-sdk-parity-gaps` |
| G9 | SSE | Changed Content-Type to `text/event-stream; charset=utf-8` in `SseResult` and `SseReplayResult` | `026-sdk-parity-gaps` |
| G10 | Hosting | `MapResponsesServer()` now throws `InvalidOperationException` with descriptive message if `IResponseHandler` not registered | `026-sdk-parity-gaps` |
| G11 | Hosting | All 5 endpoints tagged with `.WithTags("Responses")` for OpenAPI/Swagger | `026-sdk-parity-gaps` |
| G12 | Hosting | `ResponsesActivitySource` is public, non-sealed with virtual `StartCreateResponseActivity(request, responseId, headers)`. Subclass and register via DI to fully customize tracing. Composition pattern: call `base`, then `SetTag` to replace or add tags. | `026-sdk-parity-gaps` |

### Remaining Gaps

| Gap ID | Category | Description | Severity | Recommendation |
|--------|----------|-------------|----------|---------------|
| G1 | Handler Contract | No `PostInvoke` hook — old SDK returns `(Generator, PostInvoke)` tuple from `DoInvokeStreamAsync` allowing post-streaming cleanup | Low | Document that cleanup should happen after final `yield return`. Consider adding `IAsyncDisposable` support on context or a middleware hook if demand materialises. |
| G4 | Endpoints | No `/runs` alias — old SDK supports both `/runs` and `/responses` via regex constraint `^runs\|responses$` | Low | Add optional `/runs` alias in `MapResponsesServer()` or document as intentionally dropped. |

---

## 4. Contracts Type Mapping

### Request/Response Types

| Old Type (Azure.AI.AgentServer.Contracts) | New Type (Azure.AI.AgentServer.Responses.Models) | Notes |
|------------------------------------------|------------------------------------------------|-------|
| `CreateResponseRequest` | `CreateResponse` | Renamed |
| `Response` | `Response` | Same name, different namespace |
| `ResponseStreamEvent` | `ResponseStreamEvent` | Same name |
| `OutputItem` (and subtypes) | `OutputItem` (and subtypes) | Same hierarchy |
| `ItemResource` | `OutputItem` | Used in `ConversationItemsClient`; new SDK doesn't have separate ItemResource |
| `AgentReference` | `AgentReference` | Same |
| `ConversationParam` | `ConversationParam` | Same |
| `ConversationReference` | `ConversationReference` | Same |
| `ResponseStreamOptions` | `ResponseStreamOptions` | Same |
| `ResponseError` | `ResponseError` | Same |
| `ResponseErrorCode` | `ResponseErrorCode` | Same |
| `ResponseUsage` | `ResponseUsage` | Same |
| `DeleteResponseResult` | `DeleteResponseResult` | Same |

### Tool/Identity Types (Old SDK only — no new SDK equivalent)

| Old Type | Purpose | New SDK Equivalent |
|---------|---------|-------------------|
| `UserInfo` | User identity (ObjectId, TenantId) | None — consumer-defined |
| `ResolvedFoundryTool` | Resolved tool descriptor | None — consumer-defined |
| `FoundryTool` | Tool definition | None — `Tool` in contracts |
| `FoundryConnectedTool` | Connected tool descriptor | None |
| `FoundryHostedMcpTool` | Hosted MCP tool descriptor | None |
| `FoundryToolSource` | Tool source enum (HOSTED_MCP, CONNECTED) | None |
| `FoundryToolClientOptions` | Client configuration | None |
| `ConversationItemsClientOptions` | Client configuration | None |

---

## 5. Dependency Comparison

| Dependency | Old SDK | New SDK | Notes |
|-----------|---------|---------|-------|
| `Microsoft.AspNetCore.App` (framework ref) | ✅ | ✅ | Both |
| `Azure.AI.AgentServer.Contracts` / `Azure.AI.AgentServer.Responses.Contracts` | ✅ (separate package) | ✅ (bundled) | Different contract packages |
| `Azure.AI.Projects` | ✅ (for Foundry project client) | ❌ | No Foundry coupling |
| `Azure.Monitor.OpenTelemetry.AspNetCore` | ✅ (App Insights) | ❌ | Consumer-provided |
| `ModelContextProtocol` | ✅ (MCP tools) | ❌ | No built-in tool runtime |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | ✅ (OTLP export) | ❌ | Consumer-provided |
| `System.Reactive.Async` | ❌ | ✅ (event streams) | New dependency |
| `System.Threading.Tasks.Dataflow` | ✅ (SSE backpressure) | ❌ | Different SSE implementation |

**Impact:** The new SDK has a dramatically smaller dependency footprint (1 production dependency vs 5). This is intentional — the new SDK is a composable library, not an opinionated application framework.

---

## 6. Architecture Decision Records

### ADR-1: Foundry Tool Runtime → AgentServer Package

**Decision:** The generalized SDK does not include a tool runtime (`IFoundryToolRuntime`, `FoundryToolClient`, MCP operations, Connected tools, etc.). These belong in `Azure.AI.AgentServer.Core`.

**Rationale:** The tool runtime is tightly coupled to Azure Foundry platform specifics (MCP hosted tools, connected tools, OAuth consent, approval flows). The generalized SDK provides the Responses API protocol implementation; `Azure.AI.AgentServer.Core` is a separate Foundry-specific package that provides `IFoundryToolRuntime`, `FoundryToolClient`, and related services as composable DI registrations.

**Impact:** Consumers who relied on `context.GetTools()` or `AgentServerContext.Get().Tools` use `Azure.AI.AgentServer.Core`, which registers Foundry tool services via DI alongside any protocol-specific SDK. Non-Foundry consumers are unaffected.

### ADR-2: Foundry User Identity → AgentServer Package

**Decision:** The generalized SDK does not include `UserInfoContextMiddleware` or `AsyncLocalUserProvider`. These belong in `Azure.AI.AgentServer.Core`.

**Rationale:** User identity extraction via Azure ML headers (`x-aml-oid`, `x-aml-tid`) is Foundry deployment-specific. The generalized SDK should not prescribe identity resolution. `Azure.AI.AgentServer.Core` provides `UseFoundryUserIdentity()` middleware that extracts AML headers and populates user context.

**Impact:** Foundry consumers use `Azure.AI.AgentServer.Core` for identity. Non-Foundry consumers implement their own middleware. The pattern is straightforward and well-documented in the migration guide.

### ADR-3: Foundry OTEL Pipeline → AgentServer Package

**Decision:** The generalized SDK exposes an `ActivitySource` with GenAI semantic convention tags but does not configure Azure Monitor, OTLP exporters, or App Insights integration. Pre-configured OTEL pipelines belong in `Azure.AI.AgentServer.Core`.

**Rationale:** Telemetry *configuration* (exporters, sampling, endpoints) is deployment-specific. The generalized SDK produces rich telemetry data (13 activity tags, 7 baggage items) that any OTEL-compatible exporter can consume. `Azure.AI.AgentServer.Core` provides `UseFoundryTelemetry()` with pre-configured Azure Monitor and OTLP export for Foundry deployments.

**Impact:** Consumers must configure their own OpenTelemetry pipeline, or use `Azure.AI.AgentServer.Core` for turnkey Azure Monitor integration. The SDK sets GenAI semantic convention tags on activities (13 tags including `gen_ai.response.id`, `gen_ai.agent.name`, `gen_ai.provider.name`, etc.) and 7 OTEL Baggage items, providing meaningful distributed tracing data to any exporter.

### ADR-4: Replace `AgentServerApplication.RunAsync()` with Extension Methods

**Decision:** The new SDK uses `AddResponsesServer()` + `MapResponsesServer()` instead of owning the `WebApplication`.

**Rationale:** The old pattern prevented consumers from adding their own middleware, configuring Kestrel, or integrating with existing applications. The extension method pattern follows standard ASP.NET Core conventions.

**Impact:** Consumers own the full application lifecycle — more flexibility but slightly more boilerplate. The Getting Started sample demonstrates the minimal setup.

### ADR-5: Unified Handler Method

**Decision:** Single `CreateAsync` method returning `IAsyncEnumerable<ResponseStreamEvent>` instead of separate `InvokeAsync`/`InvokeStreamAsync`.

**Rationale:** The SDK can handle all 4 execution modes from a single event stream. The handler doesn't need to know whether it's streaming, non-streaming, background, or background+streaming. This reduces implementation complexity and eliminates mode-related bugs.

**Impact:** Consumers implement one method instead of two. The `ResponseEventStream` builder API handles the complexity of event construction, sequence numbering, and ID generation.

### ADR-6: AgentServer Library Is Protocol-Agnostic

**Decision:** All 26 items classified as 🔀 AgentServer library concerns are fully protocol-agnostic. `Azure.AI.AgentServer.Core` does not need awareness of `CreateResponse`, `ResponseStreamEvent`, `IResponseContext`, the SSE pipeline, or any other Responses API type.

**Rationale:** The old monolithic SDK coupled Foundry platform services (tool runtime, user identity, OTEL pipeline, project configuration) directly into the request context (`AgentRunContext`). The new architecture decouples them via standard ASP.NET Core DI. The 26 items break down into 5 categories, none requiring protocol awareness:

| Category | Count | Examples | Why protocol-agnostic |
|----------|-------|---------|----------------------|
| DI services | 6 | `IFoundryToolRuntime`, `IFoundryToolCatalog`, `AgentServerContext` | Handler injects via constructor DI — no need to extend `IResponseContext` |
| HTTP clients | 4 | `FoundryToolClient`, `FoundryMcpToolsOperations`, `FoundryProjectEndpointResolver` | External API calls to Foundry services, no Responses API types |
| Middleware / identity | 7 | `UserInfoContextMiddleware`, `AsyncLocalUserProvider`, `UserResolvers` | Pure ASP.NET Core `IMiddleware`, reads HTTP headers only |
| Models / utilities | 7 | `ResolvedFoundryTool`, `FoundryToolFactory`, `HumanInTheLoopFunctionName` | POCOs, constants, string helpers, exception definitions |
| OTEL pipeline | 2 | App Insights, OTLP exporter | Exporter configuration — SDK already emits `ActivitySource` data |

**Integration pattern:** The handler (consumer code) is the sole integration point between the two packages. It implements `IResponseHandler` from the generalized SDK and injects Foundry services from `Azure.AI.AgentServer.Core`:

```csharp
// Handler bridges the two packages — AgentServer.Core doesn't reference the Responses SDK
public class MyHandler(IFoundryToolRuntime tools, IUserProvider user) : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request, IResponseContext context, ...) { ... }
}
```

`Azure.AI.AgentServer.Core` can optionally compose with `AddResponsesServer()` via a convenience extension, but does not depend on or reference the Responses SDK directly:

```csharp
// AgentServer.Core composes with any protocol SDK — no direct dependency required
services.AddAgentServer(options => { ... }); // registers Foundry DI services
services.AddResponsesServer<MyHandler>();    // registers protocol SDK separately
```

**Impact:** `Azure.AI.AgentServer.Core` can be developed, tested, and versioned independently of any protocol SDK. It is a Foundry-specific package of DI services, middleware, and HTTP clients that composes with protocol-specific SDKs.

---

## 7. Recommended Actions

### Completed (v0.1.0-preview)

| # | Action | Gap(s) | Status |
|---|--------|--------|--------|
| 1 | ~~Add GenAI semantic convention tags to activities~~ | G7 | ✅ Done — 13 tags including `gen_ai.response.id`, `gen_ai.agent.name`, `gen_ai.agent.id`, `gen_ai.provider.name`, `service.name`, plus OTEL extensions |
| 2 | ~~Add OTEL Baggage propagation~~ | G3 | ✅ Done — 7 baggage items set before handler invocation |
| 3 | ~~Add `RawBody` (`JsonElement`) to `IResponseContext`~~ | G2 | ✅ Done — full raw JSON body accessible via `context.RawBody` |
| 4 | ~~Add `Connection: keep-alive` header to SSE responses~~ | G8 | ✅ Done |
| 5 | ~~Add `charset=utf-8` to SSE content type~~ | G9 | ✅ Done |
| 6 | ~~Add `X-Request-Id` header extraction and propagation~~ | G5 | ✅ Done — tag + baggage, truncated to 256 chars |
| 7 | ~~Add startup validation of `IResponseHandler` registration~~ | G10 | ✅ Done — `InvalidOperationException` in `MapResponsesServer()` |
| 8 | ~~Add `.WithTags()` to endpoint registration for OpenAPI~~ | G11 | ✅ Done — `.WithTags("Responses")` |
| 11 | ~~Make `TelemetrySourceName` configurable~~ | G12 | ✅ Done — `ResponsesActivitySource` (public, virtual `StartCreateResponseActivity`, composition via `SetTag`) |

### Remaining

| # | Action | Gap(s) | Effort |
|---|--------|--------|--------|
| 9 | Consider adding `/runs` route alias or documenting intentional removal | G4 | Low |
| 12 | Document `PostInvoke` equivalent pattern (cleanup after final yield) | G1 | Trivial |

---

## 8. Version & Release Timeline

| Old SDK Version | Date | Key Features |
|----------------|------|--------------|
| 1.0.0-beta.1 | 2025-11-07 | Initial release — `IAgentInvocation`, `AgentServerApplication.RunAsync()` |
| 1.0.0-beta.2 | 2025-11-10 | Bug fixes |
| 1.0.0-beta.3 | 2025-11-10 | AgentId serialization fix, NPE fix |
| 1.0.0-beta.4 | 2025-11-11 | ID generation fix |
| 1.0.0-beta.5 | 2025-12-05 | `created_by` population, error response handling fix |
| 1.0.0-beta.6 | 2026-01-20 | `AgentRunContext` (rich context), batched Foundry tool resolution |
| 1.0.0-beta.7 | 2026-02-10 | `FoundryProjectEndpointResolver`, `ConversationItemsClient` |
| 1.0.0-beta.8 | 2026-02-11 | Optional conversationId |
| 1.0.0-beta.9 | 2026-03-03 | Package updates |
| 1.0.0-beta.10 | 2026-03-11 | Package updates |
| 1.0.0-beta.11 | 2026-03-13 | `UseFoundryTools` optional TokenCredential |

---

## 9. Summary

The new SDK achieves **parity or superiority** in core handler contract, server hosting, endpoint routing, SSE streaming, error handling, state management, ID generation, telemetry, and builder API.

Features from the old monolithic SDK are split across two packages:

1. **`Azure.AI.AgentServer.Responses`** (this package) — generalized Responses API protocol implementation with full distributed tracing, SSE compliance, builder API, and state management
2. **`Azure.AI.AgentServer.Core`** — Foundry-specific agent server package that composes with protocol-specific SDKs. Provides: tool runtime (`IFoundryToolRuntime`), user identity (`UserInfo` + AML header extraction), OTEL pipeline (Azure Monitor, OTLP export), project configuration (`FoundryProjectEndpointResolver`), and agent deployment metadata

Of the 12 originally identified gaps (G1–G12):
- **9 resolved** in `026-sdk-parity-gaps`: telemetry (G3, G5, G7, G12), SSE headers (G8, G9), convenience (G2, G10, G11)
- **1 reclassified as AgentServer library concern** (G6 — `HumanInTheLoopFunctionName` belongs in `Azure.AI.AgentServer.Core`)
- **2 remaining** (both Low severity):
  - **G1** — No `PostInvoke` hook; document `yield return` cleanup pattern
  - **G4** — No `/runs` alias; intentionally dropped or add optional alias

**26 items** previously marked "by design" are now identified as **AgentServer library concerns** — they aren't missing features, they're features that belong in `Azure.AI.AgentServer.Core`. Only 2 items (health check endpoints) remain as consumer-owned ASP.NET Core patterns.

No architectural changes are needed for the remaining gaps.
