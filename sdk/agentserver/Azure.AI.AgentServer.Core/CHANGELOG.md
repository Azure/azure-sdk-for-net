# Release History

## 1.0.0-beta.29 (Unreleased)

### Features Added

### Breaking Changes

- State-store optimistic-concurrency values now use the standard `Azure.ETag` type.
  This includes `StateStoreItem.Etag`, `StateStoreItemRef.Etag`,
  `StateStoreItemKey.Etag`, `FoundryStoragePreconditionException.CurrentETag`, the
  corresponding model-factory parameters, and `FoundryStateStore.SetItemAsync` /
  `DeleteItemAsync` `ifMatch` parameters.

### Bugs Fixed

### Other Changes

## 1.0.0-beta.28 (2026-08-12)

### Features Added

- `FoundryStateStore` item operations now accept an explicit `callId` and forward
  the ambient `FoundryAgentRequestContext.Current.CallId` by default. Resilient
  task handlers restore a top-level persisted `call_id` for every execution attempt.
- Added resilient **task** and **streaming** primitives for building durable, long-running agents (`Azure.AI.AgentServer.Core.Tasks` and `Azure.AI.AgentServer.Core.Streaming`):
  - Register one-shot and multi-turn tasks with the flat `IServiceCollection.AddResilientTask()` / `AddResilientMultiTurnTask()` extension methods, including overloads that accept a source-generated `JsonTypeInfo<TInput>` for Native-AOT / trimming-safe input serialization. The reflection-based overloads carry `[RequiresUnreferencedCode]` / `[RequiresDynamicCode]` so trimming/AOT builds get a compile-time warning steering them to the `JsonTypeInfo<TInput>` overloads. Each call self-initializes the resilient-tasks services on first use (`AddResilientTasks(credential)` remains available to supply a hosted-storage credential before or after task registrations while composing services; the first non-null credential wins) and returns a typed `TaskDefinition<TInput, TOutput>` handle that binds the task name and its input/output types once, so invocation is strongly typed (a mismatched input or output is a compile error).
  - Run and resume tasks through the mockable `TaskDefinition<TInput, TOutput>` handle (`RunAsync`, `StartAsync`, `GetActiveRunAsync`) with the `TaskRun<TOutput>` handle (await its `Completion` task, or `Completion.WaitAsync(token)` to cancel only your wait) and the `TaskContext<TInput>` handler surface (entry mode, retry attempt, cooperative cancellation, shutdown, and steering signals). Each registered handle is also registered as a keyed singleton service (keyed by task name — resolution is never ambiguous even when multiple tasks share the same input/output types); resolve it in a request handler with `IServiceProvider.GetResilientTask<TInput, TOutput>(name)`. The protected constructor and virtual members support consumer unit-test substitutes.
  - Configure per-task durability with `TaskRegistrationOptions` (title, timeout, retry) and `TaskRetryPolicy` (attempt count + an `Azure.Core.DelayStrategy` for the backoff).
  - Resumable event streaming with `AgentEventStreamRegistry` / `AgentEventStream` and `AddAgentEventStreams()`, supporting in-memory live, in-memory replay, and file-backed replay backings via `AgentEventStreamOptions`. The event representation is `System.Net.ServerSentEvents.SseItem<string>`: the caller places the serialized event text in `SseItem<string>.Data` and an opaque `SseItem<string>.EventId` is the resume/reconnect token (`Subscribe(afterEventId)`, `GetLastEventIdAsync()`). Because the data is already a string, there is no payload codec — `SseFormatter` can frame a `Subscribe(...)` stream directly onto an HTTP response.
  - A single `ResilientTaskException` carrying an extensible `ResilientTaskErrorCode` (`HandlerError`, `ExhaustedRetries`, `Conflict`, `PreconditionFailed`, `QueueFull`) with code-specific data exposed as nullable properties (`CurrentStatus`, `ActualLastInputId`, `Failure`). Argument validation surfaces as `ArgumentException` and cancellation as `OperationCanceledException`; recovery deferral (`ExitForRecoveryAsync`) is an internal lifecycle handoff and never surfaces as an exception. The streaming layer keeps its `AgentEventStreamException` hierarchy.

### Bugs Fixed

- Kept the task lease renewed across retry backoff delays so a long inter-attempt backoff cannot let the lease lapse and allow a concurrent re-invocation of the same task turn.
- Hardened the resilient-task engine shutdown signalling against a benign race between a completing turn and host disposal.
- A one-shot task whose durable completion write fails, and a multi-turn task whose durable suspend write fails, now surface the failure to the caller instead of reporting success while the record remains `in_progress` (which a later recovery scan could re-run).
- The local file-backed task store now serializes its existence check and record write under the same lock as patch/delete, so two concurrent creates for the same id can no longer both succeed with the later write silently overwriting the earlier record.
- The file-backed event-stream custom serializer/deserializer are now `Func<object, string>` / `Func<string, object>` (previously `byte[]`), matching the UTF-8 JSON-string on-disk format so a custom codec cannot silently corrupt non-UTF-8 payloads.
- The local file-backed task store now writes each record through a temporary file and an atomic replace, so a crash mid-write can no longer leave a truncated record that reads back as a parse error and renders the task id permanently unusable.
- The per-task write gate is no longer disposed when its bookkeeping entry is removed, closing a race where a concurrent write could observe `ObjectDisposedException` on a gate that was torn down while still in use.
- A turn transition that replaces and disposes a handler's cancellation source concurrently with a cancel/steering signal no longer surfaces `ObjectDisposedException` from the cancel path.
- `AddResilientTasks` and `AddAgentEventStreams` are now safe against repeated registration: `AddResilientTasks` no longer registers the durability hosted service more than once (and rejects a conflicting second credential), and `AddAgentEventStreams` rejects a second configuring call instead of silently discarding its configuration.
- Steering inputs that were queued but not yet drained when a process crashed are no longer stranded: on recovery the persisted `pending_inputs` queue is rehydrated into the in-process steering FIFO, so a recovered chain drains them instead of silently dropping them. Each queued input's per-turn `InputId` is persisted alongside it so a recovered turn keeps its own identity and advances the chain head (`last_input_id`) exactly as it would without a crash.

## 1.0.0-beta.27 (2026-07-29)

### Features Added
- Added a durable key-value **state store** client under `Azure.AI.AgentServer.Core.Storage`. `FoundryStateStore.GetOrCreateAsync` binds (creating if needed) a named, Foundry-backed store; instances expose async `GetAsync`/`UpdateAsync`/`DeleteAsync` for the store and `CreateItemAsync`/`SetItemAsync`/`GetItemAsync`/`DeleteItemAsync`/`ListKeysAsync` for its items, with optimistic concurrency (`If-Match`/`ETag`), optional per-user isolation, and store-level item TTL. The .NET analogue of the Python SDK's `FoundryStateStore`.
- Added support for Microsoft Entra authentication when exporting telemetry to Azure Monitor. When `APPLICATIONINSIGHTS_AUTH_MODE` is set to `Entra`, the Azure Monitor exporter attempts to use a system-assigned managed identity credential (falling back to connection-string authentication if the credential cannot be created).

## 1.0.0-beta.26 (2026-06-28)

### Features Added
- Container protocol version `2.0.0` support: added the platform identity header constants `PlatformHeaders.UserId` (`x-agent-user-id`) and `PlatformHeaders.FoundryCallId` (`x-agent-foundry-call-id`).
- Added `FoundryEnvironment.AgentId` exposing the agent's stable GUID from the `FOUNDRY_AGENT_ID` environment variable.
- Added the request-scoped `FoundryAgentRequestContext` (`AsyncLocal`-backed, never-null `Current`) that captures the inbound `x-agent-foundry-call-id` / `x-agent-user-id` via an SDK middleware, and `FoundryCallIdHandler` (a `DelegatingHandler`) that echoes **only** the call ID on outbound Foundry-bound `HttpClient` calls (`x-agent-user-id` is never echoed). The .NET analogue of the Python SDK's `get_request_context()`.

### Breaking Changes
- Renamed `IsolationContext` to `PlatformContext`. Its members are now `UserIdKey` (from `x-agent-user-id`) and `CallId` (from `x-agent-foundry-call-id`), replacing `UserIsolationKey` / `ChatIsolationKey`.
- Replaced the `PlatformHeaders.UserIsolationKey` / `PlatformHeaders.ChatIsolationKey` constants with `PlatformHeaders.UserId` and `PlatformHeaders.FoundryCallId` per container protocol version `2.0.0`.

## 1.0.0-beta.25 (2026-05-25)

### Bugs Fixed

- Corrected `FoundryEnrichmentProcessor` to emit the Agent365 blueprint telemetry key as `microsoft.a365.agent.blueprint.id` (previously emitted as `gen_ai.agent.blueprint.id` in this code path).

## 1.0.0-beta.24 (2026-05-21)

### Features Added

- Added Agent365 tracing export support with managed identity token acquisition when `FOUNDRY_AGENT365_TRACING_ENABLED` is set.
- Added `AgentInstanceClientId`, `AgentBlueprintClientId`, `AgentTenantId`, and `IsAgent365TracingEnabled` properties to `FoundryEnvironment`.
- Added `FoundryEnrichmentProcessor` attributes: `microsoft.a365.agent.blueprint.id`, `microsoft.tenant.id`, and `microsoft.foundry.agent.type` on telemetry spans.
- Added `W3CBaggagePropagator` middleware that parses the W3C `baggage` header into `Activity.Baggage` on all target frameworks (net8.0, net9.0, net10.0).
- Configured W3C Trace Context and Baggage propagators via `Sdk.SetDefaultTextMapPropagator` for outgoing request propagation.
- Added conditional exporter registration: Azure Monitor, OTLP, and Agent365 exporters activate only when their respective environment variables are set.
- Added `PlatformHeaders.ErrorSource` (`x-platform-error-source`), `PlatformHeaders.ErrorDetail`
  (`x-platform-error-detail`), and error source value constants (`ErrorSourceUser`,
  `ErrorSourcePlatform`, `ErrorSourceUpstream`) for error classification per container-image-spec §8.
- Replaced `Azure.Monitor.OpenTelemetry.AspNetCore` with the unified `Microsoft.OpenTelemetry` distro for telemetry. The new distro auto-detects Azure Monitor and OTLP exporters from environment variables and eliminates the need for duplicate-instrumentation guards.
- Added `FoundryEnvironment.WebSocketKeepAliveInterval` (sourced from the
  `WS_KEEPALIVE_INTERVAL` environment variable) for the new
  `invocations_ws` (WebSocket) protocol. Wired through
  `AgentHostMiddlewareExtensions.UseAgentServerCore` into Kestrel's
  `WebSocketOptions.KeepAliveInterval`, so a positive value emits RFC 6455
  protocol-level Ping frames (opcode `0x9`) that keep idle WebSocket
  connections alive across upstream proxy / load-balancer idle timeouts.
  Disabled by default (`Timeout.InfiniteTimeSpan`).
- `UseAgentServerCore` now also calls `IApplicationBuilder.UseWebSockets`,
  so any protocol library that hosts WebSocket endpoints (e.g., the
  Invocations `/invocations_ws` endpoint) works out of the box without
  the consumer having to wire `UseWebSockets` themselves.

## 1.0.0-beta.23 (2026-04-22)

### Features Added

- Added `PlatformHeaders` static class centralizing all platform HTTP header name constants
  (`x-request-id`, `x-platform-server`, `x-agent-session-id`, isolation keys, `traceparent`,
  `x-ms-client-request-id`). All AgentServer packages now reference these shared constants
  instead of declaring private duplicates.
- Added `RequestIdMiddleware` that sets the `x-request-id` response header on every HTTP response.
  Value is resolved in priority order: OTEL trace ID → incoming `x-request-id` header → new GUID.
  Registered automatically by `AgentHostBuilder` and by `AddAgentServerCore()` for
  standalone (Tier 3) setups.
- Added `RequestIdBaggagePropagator` middleware that propagates incoming `x-request-id` header
  values into `Activity.Baggage` for end-to-end distributed tracing correlation.

### Breaking Changes

- Removed `IsolationContext.UserIsolationKeyHeaderName` and `IsolationContext.ChatIsolationKeyHeaderName`
  — use `PlatformHeaders.UserIsolationKey` and `PlatformHeaders.ChatIsolationKey` instead.
- Replaced `AddAgentServerRequestId()`, `AddAgentServerVersion()`, `AddAgentServerLogging()`,
  `UseAgentServerRequestId()`, `UseAgentServerVersion()`, and `UseAgentServerLogging()` with a
  single `AddAgentServerCore()` / `UseAgentServerCore()` pair. Tier 3 standalone setups now use
  two calls instead of six.

## 1.0.0-beta.22 (2026-04-17)

### Features Added

- Added `HttpClient` instrumentation (`AddHttpClientInstrumentation`) for both tracing and metrics
  in the OTLP-only telemetry path. This exports outbound HTTP client spans, enabling end-to-end
  distributed trace correlation through Foundry storage and other downstream services.
- Added inbound request logging middleware that logs all incoming HTTP requests with method, path,
  status code, duration, correlation headers (`x-request-id`, `x-ms-client-request-id`), and
  OpenTelemetry trace ID. Successful requests log at `Information` level; 4xx/5xx responses log at
  `Warning` level. Request start is logged at `Information` level.
- Added `AddAgentServerLogging()` and `UseAgentServerLogging()` extensions for Tier 3 setups to
  independently enable the inbound request logging middleware.
- Added startup configuration logging: platform environment, connectivity, host options, and
  registered protocols are logged at `Information` level when the host starts.

### Breaking Changes

- Renamed `ServerUserAgentRegistry` to `ServerVersionRegistry`.
- Renamed `AgentHostBuilder.UserAgentRegistry` property to `VersionRegistry`.
- Renamed `AddAgentServerUserAgent()` to `AddAgentServerVersion()` and
  `UseAgentServerUserAgent()` to `UseAgentServerVersion()`. The version middleware
  no longer bundles the inbound request logging registration — use the new
  `AddAgentServerLogging()` / `UseAgentServerLogging()` pair separately.
- Made `AgentHostTelemetry` internal. The telemetry source and meter name constants
  are implementation details; use the string values directly if needed for OTel filtering.

## 1.0.0-beta.21 (2026-04-14)

This is a major architectural rewrite. The package has been redesigned as a lightweight hosting
foundation. Protocol implementations that were previously bundled in this package have moved to
dedicated protocol packages (`Azure.AI.AgentServer.Responses`, `Azure.AI.AgentServer.Invocations`).
See the [Migration Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/MigrationGuide.md)
for upgrading from earlier beta versions.

### Breaking Changes

- **Package split**: All Responses API protocol types (models, invocation handlers, SSE streaming) have moved to `Azure.AI.AgentServer.Responses`. All Invocations protocol types have moved to `Azure.AI.AgentServer.Invocations`. This package now contains only the shared hosting foundation.
- **Dependency removed**: `Azure.AI.AgentServer.Contracts` is no longer required. The generated OpenAI Responses API models are now built into `Azure.AI.AgentServer.Responses`.
- **Dependencies removed**: `Azure.AI.Projects`, `Microsoft.Agents.AI.*`, and `ModelContextProtocol` packages are no longer dependencies of this package.
- **API redesigned**: The old `IAgentInvocation` / `AgentInvocationContext` / `CreateResponseRequest` API surface has been replaced with `AgentHostBuilder` and protocol-specific handler abstractions (`ResponseHandler` in Responses, `InvocationHandler` in Invocations).
- **Namespace changed**: Code that previously used `Azure.AI.AgentServer.Core.Responses.*` or `Azure.AI.AgentServer.Contracts.*` namespaces must switch to `Azure.AI.AgentServer.Responses`.

### Features Added

- Library-owned hosting foundation via `AgentHostBuilder` (composable builder pattern).
- OpenTelemetry integration with `Azure.Monitor.OpenTelemetry.AspNetCore` and OTLP exporter support.
- Health endpoint at `/readiness` for liveness and readiness probes.
- Multi-protocol composition via `AgentHostBuilder.RegisterProtocol()`. Protocol packages provide extension methods (e.g., `AddResponses<T>()`, `AddInvocations<T>()`) built on top of this API.
- Graceful shutdown with configurable drain period.
- Server user-agent `x-platform-server` header on every response with SDK version info.
- `ServerVersionRegistry` for protocol packages to register version identity segments.
- `AddAgentServerVersion()` and `UseAgentServerVersion()` extensions for standalone (Tier 3) setups.
- `AddAgentServerLogging()` and `UseAgentServerLogging()` extensions for standalone inbound request logging.
- `FoundryEnvironment` for Azure AI Foundry platform variable resolution.
- Distributed tracing context propagation via request ID baggage.

## Previous versions (prior to 1.0.0-beta.21)

Versions prior to `1.0.0-beta.21` used a monolithic architecture where `Azure.AI.AgentServer.Core`
bundled protocol logic and depended on `Azure.AI.AgentServer.Contracts` for generated models.
These versions are superseded by the new 3-package architecture. See the
[Migration Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/MigrationGuide.md)
for details.
