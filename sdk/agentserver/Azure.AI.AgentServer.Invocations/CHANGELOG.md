# Release History

## 1.0.0-beta.2 (2026-04-17)

### Features Added

- Added `x-agent-session-id` response header on GET, Cancel, and OpenAPI endpoints. The POST
  endpoint already set the header; all Invocations protocol endpoints now include it per spec §8.

### Other Changes

- Inbound request logging is now automatically enabled for Tier 1 and Tier 2 setups
  (via `InvocationsServer.Run()` or `AgentHost.CreateBuilder()`). All incoming HTTP
  requests are logged with method, path, status code, duration, and correlation headers.
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
