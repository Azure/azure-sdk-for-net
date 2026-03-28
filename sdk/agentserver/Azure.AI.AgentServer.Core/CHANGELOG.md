# Release History

## 1.0.0-beta.21 (Unreleased)

### Breaking Changes

- Package renamed from `Azure.AI.AgentServer.Hosting` to `Azure.AI.AgentServer.Core`.
- Namespace changed from `Azure.AI.AgentServer.Hosting` to `Azure.AI.AgentServer.Core`.

### Features Added

- Library-owned hosting foundation via `AgentHostBuilder` (composable builder pattern).
- OpenTelemetry integration with `Azure.Monitor.OpenTelemetry.AspNetCore` and OTLP exporter support.
- Health endpoint at `/healthy` for liveness and readiness probes.
- Multi-protocol composition via `AgentHostBuilder.RegisterProtocol()`. Protocol packages provide extension methods (e.g., `AddResponses<T>()`, `AddInvocations<T>()`) built on top of this API.
- Graceful shutdown with configurable drain period.
- Server user-agent `x-platform-server` header on every response with SDK version info.
- `ServerUserAgentRegistry` for protocol packages to register user-agent identity segments.
- `AddAgentServerUserAgent()` and `UseAgentServerUserAgent()` extensions for standalone (Tier 3) setups.
- `FoundryEnvironment` for Azure AI Foundry platform variable resolution.
- Distributed tracing context propagation via request ID baggage.
