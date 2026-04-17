# Release History

## 1.0.0-beta.22 (2026-05-05)

### Features Added

- Added `HttpClient` instrumentation (`AddHttpClientInstrumentation`) for both tracing and metrics
  in the OTLP-only telemetry path. This exports outbound HTTP client spans, enabling end-to-end
  distributed trace correlation through Foundry storage and other downstream services.

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
- `ServerUserAgentRegistry` for protocol packages to register user-agent identity segments.
- `AddAgentServerUserAgent()` and `UseAgentServerUserAgent()` extensions for standalone (Tier 3) setups.
- `FoundryEnvironment` for Azure AI Foundry platform variable resolution.
- Distributed tracing context propagation via request ID baggage.

## Previous versions (prior to 1.0.0-beta.21)

Versions prior to `1.0.0-beta.21` used a monolithic architecture where `Azure.AI.AgentServer.Core`
bundled protocol logic and depended on `Azure.AI.AgentServer.Contracts` for generated models.
These versions are superseded by the new 3-package architecture. See the
[Migration Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/MigrationGuide.md)
for details.
