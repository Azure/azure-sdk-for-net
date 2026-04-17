# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
- Protocol identity registration with `ServerUserAgentRegistry` during route mapping.
