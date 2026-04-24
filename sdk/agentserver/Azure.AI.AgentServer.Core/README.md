# Azure AI Agent Server Core library for .NET

Azure.AI.AgentServer.Core is a shared hosting foundation for Azure AI Agent Server packages. It provides a library-owned ASP.NET Core host with built-in OpenTelemetry, health checks, graceful shutdown, and multi-protocol composition — so you can go from `dotnet add package` to a running agent server in minutes.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 8](https://dotnet.microsoft.com/download) or later

> **Upgrading from a version prior to beta.21?** The package has been redesigned as a lightweight hosting
> foundation. Protocol logic has moved to [`Azure.AI.AgentServer.Responses`][responses] and
> [`Azure.AI.AgentServer.Invocations`][invocations]. See the [Migration Guide][migration] for details.

### Tier 1 — One-liner (recommended)

Each protocol package provides a one-line server that includes Core as a transitive dependency:

```csharp
// Responses protocol — install Azure.AI.AgentServer.Responses
ResponsesServer.Run<EchoHandler>();

// Invocations protocol — install Azure.AI.AgentServer.Invocations
InvocationsServer.Run<MathHandler>();
```

This starts a Kestrel server on the `PORT` environment variable (default 8088) with OpenTelemetry, a `/readiness` health endpoint, `x-request-id` request correlation, `x-platform-server` version header, and inbound request logging — all configured automatically.

Tier 1 supports customization via an `Action<AgentHostBuilder>` callback for registering additional services, middleware, or configuration. See the protocol-specific README for details.

### Tier 2 — Builder pattern

Use `AgentHost.CreateBuilder()` when you need to compose multiple protocols, register custom services, or customize the host:

```C# Snippet:Core_ReadMe_CreateBuilder
var builder = AgentHost.CreateBuilder();

// Register protocol endpoints (protocol packages provide extension methods).
builder.RegisterProtocol("MyProtocol", endpoints =>
{
    endpoints.MapGet("/hello", () => "Hello from the agent server!");
});

var app = builder.Build();
app.Run();
```

The builder provides all the same defaults as Tier 1 (OpenTelemetry, health endpoint, request correlation, version header, logging). Access the underlying `WebApplicationBuilder` via `builder.WebApplicationBuilder` for full ASP.NET Core customization (CORS, authentication, custom middleware, etc.).

### Tier 3 — Standalone (existing apps)

If you have an existing ASP.NET Core application, call `AddAgentServerCore()` and `UseAgentServerCore()` to opt in to Core middleware, then register protocol endpoints alongside your own:

```C# Snippet:Core_ReadMe_Tier3Setup
var builder = WebApplication.CreateBuilder();
builder.Services.AddAgentServerCore();

var app = builder.Build();
app.UseAgentServerCore();
app.MapGet("/hello", () => "Hello!");
app.Run();
```

This enables request correlation (`x-request-id`), server version header (`x-platform-server`), and inbound request logging. See the protocol-specific Tier 3 samples ([Responses][responses_tier3], [Invocations][invocations_tier3]) for complete examples including handler registration, health probes, and OpenTelemetry setup.

## Key concepts

### AgentHost

The static entry point. `AgentHost.CreateBuilder()` returns an `AgentHostBuilder` for composing protocols and configuring the server.

### AgentHostBuilder

Configures the underlying ASP.NET Core host with sensible defaults: Kestrel on the `PORT` environment variable (or 8088), OpenTelemetry traces and metrics, a `/readiness` health endpoint, and `x-platform-server` version header. Protocol packages use `RegisterProtocol()` to add their endpoints — each protocol registers its identity segment with the `ServerVersionRegistry`.

### PlatformHeaders

The `PlatformHeaders` static class defines all HTTP header name constants used across the AgentServer platform. Using these constants avoids typos and keeps header names consistent across protocol packages.

| Constant | Header | Direction | Description |
|----------|--------|-----------|-------------|
| `RequestId` | `x-request-id` | Request ↔ Response | Request correlation ID |
| `ServerVersion` | `x-platform-server` | Response | Server SDK identity |
| `SessionId` | `x-agent-session-id` | Response | Resolved session ID |
| `UserIsolationKey` | `x-agent-user-isolation-key` | Request | Platform user partition key |
| `ChatIsolationKey` | `x-agent-chat-isolation-key` | Request | Platform conversation partition key |
| `ClientHeaderPrefix` | `x-client-` | Request | Pass-through client header prefix |
| `ErrorSource` | `x-platform-error-source` | Response | Error origin classification |
| `ErrorDetail` | `x-platform-error-detail` | Response | Diagnostic error context |

### Request correlation (`x-request-id`)

`RequestIdMiddleware` sets the `x-request-id` response header on every HTTP response. The value is resolved in priority order:

1. OpenTelemetry trace ID (if an `Activity` is active)
2. Incoming `x-request-id` request header (if present)
3. New GUID (fallback)

### Error source classification

All error responses (4xx/5xx) include the `x-platform-error-source` header to classify where the error originated:

| Value | Meaning | Example |
|-------|---------|---------|
| `user` | Caller's input is invalid — fix the request and retry | Bad JSON, missing field, unknown resource ID |
| `platform` | SDK or infrastructure failure — not the caller's fault | Storage unreachable, auth failure, internal timeout |
| `upstream` | Developer's handler code failed | Handler threw exception, protocol violation |

Platform errors also include `x-platform-error-detail` with diagnostic context (exception type, message, stack trace). User and upstream errors omit the detail header.

### FoundryEnvironment

Reads Azure AI Foundry platform variables (`FOUNDRY_*`, `PORT`, `SSE_KEEPALIVE_INTERVAL`) to resolve agent identity, listening port, and connection strings. Also detects `OTEL_EXPORTER_OTLP_ENDPOINT` and `APPLICATIONINSIGHTS_CONNECTION_STRING` for telemetry configuration. Useful when your agent server runs as a hosted agent in AI Foundry.

### Telemetry

OpenTelemetry is configured automatically via `Azure.Monitor.OpenTelemetry.AspNetCore`. The Responses and Invocations protocols use dedicated activity source names (`Azure.AI.AgentServer.Responses` and `Azure.AI.AgentServer.Invocations`) for distributed tracing. OTLP export is enabled when the `OTEL_EXPORTER_OTLP_ENDPOINT` environment variable is set.

### Health endpoint

A `/readiness` endpoint is registered by default, responding to liveness and readiness probes. It reports healthy as soon as the host finishes starting.

## Examples

You can familiarise yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core/samples).

## Troubleshooting

### Common errors

- **Port already in use**: The server defaults to port 8088 (or the `PORT` environment variable). If the port is occupied, set `PORT` to another value or configure Kestrel directly via the builder.
- **No protocol registered**: If you use `AgentHost.CreateBuilder()` without calling `RegisterProtocol()` (or a protocol extension method), the server will start but will have no protocol endpoints mapped.

### Logging

The library emits OpenTelemetry traces via the `Azure.AI.AgentServer.Responses` and `Azure.AI.AgentServer.Invocations` activity sources. Inbound request logging is enabled automatically for Tier 1 and Tier 2 setups; for Tier 3, call `AddAgentServerCore()` and `UseAgentServerCore()` to enable it. Enable ASP.NET Core logging in your application configuration to diagnose startup issues.

## Next steps

- [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core/samples) — Getting started, multi-protocol composition

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Core
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
[migration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/MigrationGuide.md
[responses]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses
[invocations]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations
[responses_tier3]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample9_Tier3SelfHosting.md
[invocations_tier3]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample7_Tier3SelfHosting.md
