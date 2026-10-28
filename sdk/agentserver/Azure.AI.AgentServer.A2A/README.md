# Azure AI Agent Server A2A library for .NET

`Azure.AI.AgentServer.A2A` hosts native [A2A .NET](https://github.com/a2aproject/a2a-dotnet)
v1.0 applications in Azure AI Foundry hosted-agent containers. The native library owns
messages, tasks, agent cards, JSON-RPC validation, errors, and SSE serialization. This
library adds Foundry's routes, shared hosting lifecycle, request context, task persistence,
and semantic tracing through `Azure.AI.AgentServer.Core`.

This is an unreleased preview. Its native `A2A.AspNetCore` dependency is
`1.0.0-preview3`; dependency and public API approval are required before release.
The hosting library is optional: applications can implement the Foundry container
contract directly instead.

## Getting started

### Build the package

From the repository root, build the library using the repository's .NET SDK:

```powershell
dotnet build sdk\agentserver\Azure.AI.AgentServer.A2A\src\Azure.AI.AgentServer.A2A.csproj
dotnet pack sdk\agentserver\Azure.AI.AgentServer.Core\src\Azure.AI.AgentServer.Core.csproj -c Release
dotnet pack sdk\agentserver\Azure.AI.AgentServer.A2A\src\Azure.AI.AgentServer.A2A.csproj -c Release
```

Until a preview is published, consume the project through a project reference or
install the resulting NuGet package from your local package feed.
Use Core and A2A packages from the same build to include the native Agent Card
identity-preservation fix.

### Prerequisites

- .NET 8 or .NET 10 for the consuming ASP.NET Core application.
- The repository-pinned .NET SDK when building from source.
- A native `AgentCard` and either an `IAgentHandler` or an existing `IA2ARequestHandler`.
- Foundry project and managed-identity configuration when using hosted task persistence.

### Run an agent

Use the native A2A types in your application, together with the
`Azure.AI.AgentServer.A2A` namespace. The entry point is named `A2AAgentServer`
to avoid colliding with the native `A2A.A2AServer`.

Define your native card:

```C# Snippet:A2A_AgentCard
public static AgentCard CreateCard() => new()
{
    Name = "echo",
    Description = "A native A2A echo agent",
    Version = "1.0",
    SupportedInterfaces =
    [
        new AgentInterface
        {
            Url = "http://localhost:8088/a2a",
            ProtocolBinding = "JSONRPC",
            ProtocolVersion = "1.0",
        },
    ],
    Capabilities = new AgentCapabilities { Streaming = true },
    DefaultInputModes = ["text/plain"],
    DefaultOutputModes = ["text/plain"],
    Skills = [new AgentSkill { Id = "echo", Name = "Echo", Description = "Echoes input", Tags = ["echo"] }],
};
```

Implement a native handler:

```C# Snippet:A2A_EchoAgent
public class EchoAgent : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        await new MessageResponder(eventQueue, context.ContextId)
            .ReplyAsync($"Echo: {context.UserText}", cancellationToken: cancellationToken);
    }
}
```

Run it with the shared Core host:

```C# Snippet:A2A_Run
A2AAgentServer.Run<EchoAgent>(CreateCard());
```

## Key concepts

### Hosting tiers

- `A2AAgentServer.Run<THandler>(card)` builds and runs a Core host, using
  `${PORT:-8088}`, readiness, graceful shutdown, and Core telemetry.
- `AgentHost.CreateBuilder().AddA2A<THandler>(card)` composes A2A with other
  protocols and supports application DI and tracing customization.
- `services.AddFoundryA2A<THandler>(card)` and `app.MapFoundryA2A()` add Foundry
  hosting to an existing ASP.NET Core application.
- `services.AddFoundryA2A(card, requestHandler)` preserves an existing native
  request handler and its storage. The native handler remains responsible for
  the lifetime of its own dependencies.
- `services.AddFoundryA2A()` adds hosting to already-registered native services,
  without changing the native card, handler, or task store.

The `IEndpointRouteBuilder.MapFoundryA2A()` overload maps only protocol routes.
When using it directly, register Core services, install `UseAgentServerCore()`,
and map readiness yourself. The `WebApplication` overload does this automatically.
Existing ASP.NET Core applications retain ownership of port configuration,
telemetry exporters, and shutdown settings.

### Endpoints

| Method | Container route | Purpose |
| --- | --- | --- |
| POST | `/a2a` | Native v1.0 JSON-RPC, including SSE |
| GET | `/a2a/.well-known/agent-card.json` | Native public Agent Card |
| POST | `/invocations/a2a` | Compatibility alias |
| GET | `/invocations/a2a/.well-known/agent-card.json` | Compatibility alias |
| GET | `/readiness` | Core readiness probe |

Aliases run the same transport and do not rewrite the card or add advertised
interfaces. The library does not expose HTTP+JSON/REST, gRPC, push notifications,
or extended agent cards. Cards advertising push notifications or extended cards
are rejected at startup rather than silently rewritten.

### Request identity and storage

Core captures `x-agent-foundry-call-id` and `x-agent-user-id` in
`FoundryAgentRequestContext.Current`. Use Core's `FoundryCallIdHandler` for
outbound Foundry calls. Only the call ID is forwarded; the user ID is not echoed.
The native A2A `contextId` is not reinterpreted as a Foundry session ID.

| Registration | Default task storage |
| --- | --- |
| New native handler in Foundry | `FoundryTaskStore` |
| New native handler locally | Native `InMemoryTaskStore` |
| Explicit `ITaskStore` registration | Supplied store, unchanged |
| Existing native request handler or services | Existing storage, unchanged |

Register a custom `ITaskStore` before or after `AddFoundryA2A<THandler>()` to
override the default. `FoundryTaskStore` can also wrap an existing Core
`FoundryStateStore`, or lazily resolve a named store using optional credentials,
endpoint, and retention settings. The default hosted store name is
`a2a/tasks/{agent-id-or-name}` and excludes deployment version so task snapshots
survive upgrades.

Hosted persistence requires brokered request context or caller identity, and
verifies server-side user isolation on every operation. Keys additionally scope
tasks by platform user, native HTTP identity, and tenant. The call ID is not a
stable storage key. Snapshots use native A2A JSON serialization; listing delegates
filtering, history/artifact projection, and pagination to the native in-memory
store after reading the caller's persisted records.

Explicit local persistence uses Core's file-backed state store. Local partitions
are a development convenience, not an authentication boundary. Persisting a task
does not restart an interrupted executor, restore subscriptions, or enable
resilient background execution.

### Distributed tracing and errors

`Azure.AI.AgentServer.A2A` emits a `SERVER` span named after the JSON-RPC method.
In Foundry, `SendMessage` and `SendStreamingMessage` also emit an enclosing
`INTERNAL` `invoke_agent` span using deployment identity. The operation span
retains the native Agent Card identity. Lookup, list, cancellation, and
subscription do not emit a hosted invocation span.

Spans cover dispatch and complete response transmission, including SSE. They
record method, version, message/task IDs, tenant, and request `contextId`, without
recording prompts, application metadata, or artifacts. The first returned task ID
is also observed for single-task operations. Response observation forwards bytes
unchanged and is bounded to 1 MiB per JSON payload or SSE event.

HTTP failures and unary JSON-RPC errors mark spans failed, including protocol
errors returned with HTTP 200. HTTP-200 SSE application-error events do not mark
the span failed; transmission exceptions do. HTTP transport failures receive
Foundry's `x-platform-error-source` classification. Native JSON-RPC application
errors retain their native envelope and HTTP status.

Core-hosted applications register the A2A source automatically. Existing ASP.NET
Core applications must configure their own OpenTelemetry exporters. Native A2A
sources are not enabled by this library; subscribing to them separately can
produce additional implementation-level spans.

## Examples

### Compose with the Core host

```C# Snippet:A2A_Builder
var builder = AgentHost.CreateBuilder();
builder.AddA2A<EchoAgent>(CreateCard());
builder.Build().Run();
```

### Use an existing ASP.NET Core application

```C# Snippet:A2A_Standalone
var builder = WebApplication.CreateBuilder();
builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
var app = builder.Build();
app.MapFoundryA2A();
app.Run();
```

### Emit persistent native tasks

A message-only reply does not create a task snapshot. Use the native `TaskUpdater`
when you want task lifecycle and artifact events:

```C# Snippet:A2A_TaskAgent
public class TaskAgent : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
        await task.SubmitAsync(cancellationToken: cancellationToken);
        await task.AddArtifactAsync(
            [Part.FromText($"Echo: {context.UserText}")],
            cancellationToken: cancellationToken);
        await task.CompleteAsync(cancellationToken: cancellationToken);
    }
}
```

The compiled examples have matching offline HTTP tests in
[SampleEndToEndTests.cs](tests/SampleEndToEndTests.cs).

## Troubleshooting

- An isolation error means the hosted state store is not user-isolated or the
  request lacks caller context. Do not disable isolation to work around it.
- Missing task snapshots can result from a changed store name, caller scope,
  task retention, or a handler that only sends messages.
- Use the v1.0 method names, such as `SendMessage`, rather than v0.3 names.
- Startup rejects cards advertising unsupported extended-card or push features.
- Native preview APIs may change; update the native dependency and HTTP tests together.

## Next steps

See the [native A2A examples](https://github.com/a2aproject/a2a-dotnet/tree/main/samples)
and the [Agent Server libraries](../README.md) for multi-protocol hosting.

## Contributing

See the repository [contributing guide](../../../CONTRIBUTING.md). API design
follows the [.NET API design guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespace-naming).
Run the package tests and compile documentation snippets before submitting changes.
