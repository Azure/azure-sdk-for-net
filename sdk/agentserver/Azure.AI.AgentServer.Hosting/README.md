# Azure AI Agent Server Hosting library for .NET

Azure.AI.AgentServer.Hosting is a shared hosting foundation for Azure AI Agent Server packages. It provides a library-owned ASP.NET Core host with built-in OpenTelemetry, health checks, graceful shutdown, and multi-protocol composition — so you can go from `dotnet add package` to a running agent server in minutes.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Hosting --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 10](https://dotnet.microsoft.com/download) or later

### Start a server (Tier 1 — recommended)

The simplest way to create an agent server is with the one-line `AgentHost.Run<THandler>()` API. You'll also need a protocol package such as `Azure.AI.AgentServer.Responses`:

```C# Snippet:Hosting_ReadMe_Tier1
AgentHost.Run<MyHandler>(args);
```

This starts a Kestrel server with OpenTelemetry, a `/healthy` health endpoint, server user-agent headers, and your handler wired up to the Responses protocol.

### Start a server (Tier 2 — builder pattern)

For more control, use the builder pattern:

```C# Snippet:Hosting_ReadMe_Tier2
var builder = AgentHost.CreateBuilder(args);
builder.AddResponses<MyHandler>();
var app = builder.Build();
app.Run();
```

## Key concepts

### AgentHost

The static entry point. `AgentHost.Run<THandler>()` is the fastest path to a working server — one line of code. `AgentHost.CreateBuilder()` returns an `AgentHostBuilder` for progressive customisation.

### AgentHostBuilder

Configures the underlying ASP.NET Core host with sensible defaults: Kestrel on the `PORT` environment variable (or 8088), OpenTelemetry traces and metrics, a `/healthy` health endpoint, and `x-platform-server` user-agent header via `ServerUserAgentMiddleware`. Use `.AddResponses<T>()` and `.AddInvocations<T>()` to compose protocol packages on a single host — each protocol registers its identity segment with the `ServerUserAgentRegistry`.

### AgentHostApp

The built application. Call `Run()` to start listening. Wraps `WebApplication` with server-specific configuration applied.

### FoundryEnvironment

Reads Azure AI Foundry platform variables (`AZF_*`) to resolve endpoint URLs, deployment names, and connection strings. Useful when your agent server runs as a hosted agent in AI Foundry.

### Telemetry

OpenTelemetry is configured automatically via `Azure.Monitor.OpenTelemetry.AspNetCore`. The `AgentHostTelemetry` class exposes the shared `ActivitySource` for custom trace spans. OTLP export is enabled when the `OTEL_EXPORTER_OTLP_ENDPOINT` environment variable is set.

### Health endpoint

A `/healthy` endpoint is registered by default, responding to liveness and readiness probes. It reports healthy as soon as the host finishes starting.

## Examples

You can familiarise yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Hosting/samples).

## Troubleshooting

### Common errors

- **Port already in use**: The server defaults to port 8088 (or the `PORT` environment variable). If the port is occupied, set `PORT` to another value or configure Kestrel directly via the builder.
- **No protocol registered**: If you call `AgentHost.Run<THandler>()` without also installing a protocol package (e.g., `Azure.AI.AgentServer.Responses`), the server will start but will have no protocol endpoints mapped.

### Logging

The library emits OpenTelemetry traces via the `Azure.AI.AgentServer.Hosting` activity source. Enable ASP.NET Core logging in your application configuration to diagnose startup issues.

## Next steps

- [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Hosting/samples) — Getting started, multi-protocol composition
- [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses) — Responses protocol implementation
- [Azure.AI.AgentServer.Invocations](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations) — Invocations protocol implementation

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Hosting/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Hosting
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
