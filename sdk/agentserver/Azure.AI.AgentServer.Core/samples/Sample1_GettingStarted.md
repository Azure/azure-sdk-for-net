# Sample 1: Getting Started — Create and Run a Server

This sample demonstrates the foundational API: `AgentHost.CreateBuilder()` returns an `AgentHostBuilder` that configures Kestrel, OpenTelemetry, health probes, and the `x-platform-server` identity header automatically. You register your own endpoints via `RegisterProtocol()`.

> **Note:** Most developers will use a **protocol package** (`Azure.AI.AgentServer.Responses` or `Azure.AI.AgentServer.Invocations`) instead of calling `RegisterProtocol()` directly. Those packages provide `AddResponses<T>()` / `AddInvocations<T>()` extension methods that wire everything up. See [Responses samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) and [Invocations samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples) for the recommended getting-started experience.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
```

## Create and run a server

```C# Snippet:Core_Sample1_CreateAndRun
var builder = AgentHost.CreateBuilder();

// Register a custom protocol endpoint directly.
builder.RegisterProtocol("MyProtocol", endpoints =>
{
    endpoints.MapGet("/hello", () => "Hello from the agent server!");
});

var app = builder.Build();
app.Run();
```

This starts a server on port 8088 (or the `PORT` environment variable) with:
- Kestrel HTTP/1.1 listening
- OpenTelemetry traces and metrics
- A `/readiness` health endpoint
- The `x-platform-server` identity header on all responses
- Your custom `/hello` endpoint

## Test the server

```bash
# Health probe
curl http://localhost:8088/readiness

# Custom endpoint
curl http://localhost:8088/hello
```

## What `AgentHost.CreateBuilder()` gives you

| Feature | Default behavior |
|---------|-----------------|
| **Port** | `PORT` env var, or 8088 |
| **Health** | `/readiness` endpoint |
| **Telemetry** | OpenTelemetry traces + metrics via Azure Monitor |
| **Version** | `x-platform-server` header on every response |
| **Shutdown** | 30-second graceful shutdown |

## Next steps

For a full protocol experience, install a protocol package and use its extension methods:
- [Responses samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) — streaming AI responses
- [Invocations samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples) — request/response agent tasks
