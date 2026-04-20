# Release History

## 1.0.0-beta.23 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
