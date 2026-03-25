# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- `InvocationHandler` abstract class for implementing invocation protocol endpoints.
- `InvocationContext` providing request metadata and session information to handlers.
- Session resolution via `SessionIdResolver` for multi-turn invocation tracking.
- Client header forwarding via `ClientHeaderForwarder` for `x-client-*` prefixed headers.
- Invocation lifecycle operations: `HandleAsync`, `GetAsync`, `CancelAsync`, `GetOpenApiAsync`.
- `InvocationsActivitySource` for OpenTelemetry distributed tracing integration.
- ASP.NET Core hosting integration via `AddInvocations<THandler>()` builder extension.
- Protocol identity registration with `ServerUserAgentRegistry` during route mapping.
