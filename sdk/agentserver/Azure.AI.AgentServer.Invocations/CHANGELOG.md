# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added
- Container protocol version `2.0.0` support: reads `x-agent-user-id` and `x-agent-foundry-call-id` from inbound requests and exposes them via `InvocationContext.PlatformContext`.

### Breaking Changes
- `InvocationContext.Isolation` is now `InvocationContext.PlatformContext` (type `PlatformContext` with `UserIdKey` / `CallId`), replacing the `IsolationContext` user/chat isolation keys.

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2026-05-21)

### Features Added

- Replaced `invoke_agent` SERVER span with baggage-only propagation. W3C trace context propagation is now handled automatically by ASP.NET Core, so handler spans are parented directly under the caller's span.
- Invocation and session IDs are propagated as Activity baggage for downstream correlation.
- Unhandled exceptions now include the `x-platform-error-source` header classifying error
  origin as `user` (invalid request), `platform` (SDK/infrastructure failure), or `upstream`
  (developer handler failure) per container-image-spec §8. Platform errors include
  `x-platform-error-detail` with diagnostic context.
- WebSocket protocol support — new public abstract `InvocationWebSocketHandler`
  base class (derived from `InvocationHandler`) declares abstract
  `HandleWebSocketAsync(WebSocket, InvocationContext, CancellationToken)`
  and defaults the inherited `HandleAsync` to HTTP `404 Not Found`. A
  WebSocket-only agent therefore implements only `HandleWebSocketAsync`;
  multi-protocol agents override both methods. Handlers that derive from
  plain `InvocationHandler` continue to short-circuit `/invocations_ws`
  to HTTP `404 Not Found`. The SDK accepts the upgrade
  (`AcceptWebSocketAsync`), maps clean handler returns to RFC 6455 close
  code `1000` (`NormalClosure`) and uncaught handler exceptions to `1011`
  (`InternalServerError`), and preserves handler-initiated close codes
  unchanged.
- WebSocket Ping/Pong keep-alive — disabled by default; enable via the
  `WS_KEEPALIVE_INTERVAL` environment variable (see
  `Azure.AI.AgentServer.Core` 1.0.0-beta.24), which is wired through to
  Kestrel's `WebSocketOptions.KeepAliveInterval`.
- WebSocket telemetry — structured close-event log line carrying
  `azure.ai.agentserver.invocations_ws.session_id`,
  `azure.ai.agentserver.invocations_ws.close_code`, and
  `azure.ai.agentserver.invocations_ws.duration_ms`.

## 1.0.0-beta.3 (2026-04-22)

### Features Added

- All endpoints now return the `x-request-id` response header for request correlation (via Core
  `RequestIdMiddleware`). Value is resolved from OTEL trace ID → incoming `x-request-id` header → GUID.

### Other Changes

- Migrated header name constants to use `PlatformHeaders` from Core package instead of
  local `private const` declarations.

## 1.0.0-beta.2 (2026-04-17)

### Features Added

- Added `x-agent-session-id` response header on GET, Cancel, and OpenAPI endpoints. The POST
  endpoint already set the header; all Invocations protocol endpoints now include it per spec §8.
- Added isolation key presence logging (`HasUserIsolationKey`, `HasChatIsolationKey`) to all
  endpoint handler logs (POST, GET, Cancel). Key values are never logged.
- Added startup configuration logging: protocol registration is logged at `Information` level
  when the host starts.

- Added inbound request logging for Tier 1 and Tier 2 setups (via `InvocationsServer.Run()` or
  `AgentHost.CreateBuilder()`). All incoming HTTP requests are logged with method, path, status
  code, duration, and correlation headers (`x-request-id`, `x-ms-client-request-id`).

### Breaking Changes

- Made `InvocationsActivitySource` internal. The activity source is managed by
  the framework; handlers do not need to create tracing activities directly.

### Other Changes

- Updated dependency on `Azure.AI.AgentServer.Core` to 1.0.0-beta.22, which adds outbound
  `HttpClient` instrumentation for distributed trace correlation.

## 1.0.0-beta.1 (2026-04-14)

### Features Added

- Initial release of the Azure.AI.AgentServer.Invocations library.
- `InvocationHandler` abstract class for implementing invocation protocol endpoints.
- `InvocationContext` providing request metadata and session information to handlers.
- Automatic session ID resolution from query parameters and environment variables for multi-turn invocation tracking.
- Automatic forwarding of `x-client-*` request headers to handlers.
- Invocation lifecycle operations: `HandleAsync`, `GetAsync`, `CancelAsync`, `GetOpenApiAsync`.
- `InvocationsActivitySource` for OpenTelemetry distributed tracing integration.
- ASP.NET Core hosting integration via `AddInvocations<THandler>()` builder extension.
- Protocol identity registration with `ServerVersionRegistry` during route mapping.
