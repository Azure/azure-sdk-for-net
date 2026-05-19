# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

- Unhandled exceptions now include the `x-platform-error-source` header classifying error
  origin as `user` (invalid request), `platform` (SDK/infrastructure failure), or `upstream`
  (developer handler failure) per container-image-spec §8. Platform errors include
  `x-platform-error-detail` with diagnostic context.
- WebSocket protocol support — `InvocationHandler` now exposes a virtual
  `HandleWebSocketAsync(WebSocket, InvocationContext, CancellationToken)`
  method. Handlers that override it serve `/invocations_ws` alongside
  `POST /invocations` on the same host. Handlers that do not override it
  cause the endpoint to short-circuit to HTTP 404, matching the Python
  "route not registered" 404 behaviour for hosts without a registered
  WS handler.
- The SDK accepts the upgrade for you (`AcceptWebSocketAsync`), maps
  clean handler returns to RFC 6455 close code `1000` (`NormalClosure`)
  and uncaught handler exceptions to close code `1011`
  (`InternalServerError`), and preserves handler-initiated close codes
  unchanged.
- Per-connection telemetry — a single structured close-event log line
  carrying `azure.ai.agentserver.invocations_ws.session_id`,
  `azure.ai.agentserver.invocations_ws.close_code`, and
  `azure.ai.agentserver.invocations_ws.duration_ms` (via structured
  message templates). No framework-level OpenTelemetry span is created
  for the connection — ASP.NET Core auto-propagates the W3C trace
  context, so any spans the user handler starts are parented correctly
  without a per-connection wrapper. Mirrors the Python design in
  https://github.com/Azure/azure-sdk-for-python/pull/46973.
- Session ID honours `FOUNDRY_AGENT_SESSION_ID` so HTTP and WebSocket
  transports on the same container report the same session, falling
  back to a fresh UUID when the platform does not inject one.
- WebSocket Ping/Pong keep-alive is configured via the new
  `WS_KEEPALIVE_INTERVAL` environment variable (see
  `Azure.AI.AgentServer.Core` 1.0.0-beta.24); disabled by default.

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
