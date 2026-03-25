# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Library-owned hosting foundation via `AgentHost.Run<THandler>()` (Tier 1) and `AgentHostBuilder` (Tier 2).
- OpenTelemetry integration with `Azure.Monitor.OpenTelemetry.AspNetCore` and OTLP exporter support.
- Health endpoint at `/healthy` for liveness and readiness probes.
- Multi-protocol composition via `AgentHostBuilder.AddResponses<T>()` and `AddInvocations<T>()`.
- Graceful shutdown with configurable drain period.
- Server user-agent middleware (`ServerUserAgentMiddleware`) setting `x-platform-server` header with SDK version info.
- `ServerUserAgentRegistry` for protocol packages to register user-agent identity segments.
- `AddAgentServerUserAgent()` and `UseAgentServerUserAgent()` extensions for standalone (Tier 3) setups.
- `FoundryEnvironment` for Azure AI Foundry platform variable resolution.
- `RequestIdBaggagePropagator` for distributed tracing context propagation.
