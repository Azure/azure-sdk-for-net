# Azure AI Agent Server A2A library for .NET

Azure.AI.AgentServer.A2A is a .NET library for hosting native [A2A][a2a] agents
as Microsoft Foundry hosted agents. Implement a native `IAgentHandler`, supply
an `AgentCard`, and the library handles the Foundry hosting integration:
JSON-RPC endpoints, readiness, request context, task storage
selection, and distributed tracing.

Your agent continues to use native A2A messages, tasks, artifacts, and handlers.
The library builds on `Azure.AI.AgentServer.Core` without translating A2A
requests into another protocol.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.A2A --prerelease
```

### Prerequisites

- [.NET 8](https://dotnet.microsoft.com/download) or later.
- An ASP.NET Core application.
- An [Azure subscription](https://azure.microsoft.com/free/dotnet/) and a
  Foundry project when deploying to Foundry. Local execution does not require
  an Azure subscription.

The native `A2A.AspNetCore` library and `Azure.AI.AgentServer.Core` are installed
automatically as dependencies.

### Configure the server

Use the `A2A` namespace for native protocol types and
`Azure.AI.AgentServer.A2A` for the Foundry hosting extensions.
The fastest way to start a server is:

```C# Snippet:A2A_Run
A2AAgentServer.Run<EchoAgent>(CreateCard());
```

This starts the Core host on port 8088 by default, with readiness, graceful
shutdown, OpenTelemetry, and the A2A endpoints. Set `PORT` to change the
listening port.

Define the native Agent Card describing your agent. Its interface URL should
match the address clients use to reach your local server:

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
    Capabilities = new AgentCapabilities(),
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

For more control over service registration, use the [Core host builder](#customizing-the-host),
or add A2A to an [existing ASP.NET Core application](#use-an-existing-aspnet-core-application).

## Key concepts

### Native A2A handlers and agent cards

`IAgentHandler` is the native A2A execution contract. Implement `ExecuteAsync`
to process a message and write responses to the supplied `AgentEventQueue`.
Use `MessageResponder` for message-only replies, or `TaskUpdater` for task
lifecycle and artifact updates.

`AgentCard` describes the agent's identity, skills, media types, and supported
interfaces. The same card is served through the public card endpoint.

If you already have an `IA2ARequestHandler`, pass it with the card to
`AddA2A(card, requestHandler)` or `AddFoundryA2A(card, requestHandler)`.
The existing handler and its storage are preserved. Manage the lifetime of
externally constructed handlers and their dependencies in your application.

### Customizing the host

Choose the integration level that matches your application:

| Entry point | Use when |
| --- | --- |
| `A2AAgentServer.Run<THandler>(card)` | You want the library to build and run the host. |
| `AgentHost.CreateBuilder().AddA2A<THandler>(card)` | You need application services, custom tracing, or multiple protocols on one Core host. |
| `services.AddFoundryA2A<THandler>(card)` and `app.MapFoundryA2A()` | You already own an ASP.NET Core application. |
| `services.AddFoundryA2A()` | Native A2A services, including the card and request handler, are already registered. |

`AddA2A<THandler>` and `AddFoundryA2A<THandler>` accept a configuration callback
for the native `A2AServerOptions`.
The `A2AAgentServer` name distinguishes the Foundry entry point from the native
`A2A.A2AServer`.

### Handler lifetime

Native handlers registered through `AddA2A<THandler>` or
`AddFoundryA2A<THandler>` are singletons and may handle concurrent requests.
Keep per-request data in local variables or the native request context, and
ensure shared dependencies are thread-safe.

### Endpoints

| Method | Container route | Purpose |
| --- | --- | --- |
| POST | `/a2a` | Native v1.0 JSON-RPC |
| GET | `/a2a/.well-known/agent-card.json` | Native public Agent Card |
| GET | `/readiness` | Core readiness probe |

The library does not expose HTTP+JSON/REST, gRPC, push notifications,
or extended agent cards. Cards advertising push notifications or extended cards
are rejected at startup rather than silently rewritten.

### Platform request context

Core captures `x-agent-foundry-call-id` and `x-agent-user-id` in
`FoundryAgentRequestContext.Current`. Use Core's `FoundryCallIdHandler` for
outbound Foundry calls so the current request's call ID is forwarded.
The user ID is available for application-owned state partitioning; it is not
forwarded as an outbound identity header.

Native A2A `contextId` and platform session IDs remain separate identifiers.

### Task storage

| Registration | Default task storage |
| --- | --- |
| New native handler in Foundry | `FoundryTaskStore` |
| New native handler locally | Native `InMemoryTaskStore` |
| Explicit `ITaskStore` registration | Supplied store, unchanged |
| Existing native request handler or services | Existing storage, unchanged |

Register a custom native `ITaskStore` before or after `AddFoundryA2A<THandler>()` to
override the default. `FoundryTaskStore` can also wrap an existing Core
`FoundryStateStore`, or lazily resolve a named store using optional credentials,
endpoint, and retention settings.

An explicitly supplied `TokenCredential` takes precedence. When none is supplied,
hosted task storage uses `DefaultAzureCredential` limited by default to production
credentials: environment, workload identity, and managed identity. Developer
credentials are excluded from that default chain. Set `AZURE_TOKEN_CREDENTIALS`
to select a credential source explicitly; invalid selections fail rather than
silently falling back to another identity.

Hosted persistence requires brokered request context or caller identity, and
an existing backing store must enable server-side user isolation.
Task records are scoped by the platform user, native HTTP identity, and tenant.
The per-request call ID does not change the storage partition.

Explicit local persistence uses Core's file-backed state store. Local partitions
are a development convenience, not an authentication boundary. Persisting a task
does not restart an interrupted executor, restore subscriptions, or enable
resilient background execution. The default local in-memory store loses tasks
when the process stops.

### Errors

The native transport handles JSON-RPC request validation and response serialization.

Protocol-level errors use native JSON-RPC error objects, including when returned
with HTTP 200. Clients must inspect the JSON-RPC result rather than relying
only on the HTTP status code. Transport failures may use HTTP 4xx or 5xx.

HTTP errors on the A2A routes include `x-platform-error-source`, including
method-not-allowed responses generated by routing. Unexpected dispatch failures
are logged with their original exception before the native transport creates
the JSON-RPC error response.

### Distributed tracing

`Azure.AI.AgentServer.A2A` emits a `SERVER` span named after the JSON-RPC method.
In Foundry, `SendMessage` also emits an enclosing
`INTERNAL` `invoke_agent` span using deployment identity. The operation span
retains the native Agent Card identity. Lookup, list, cancellation, and
subscription do not emit a hosted invocation span.

Spans cover dispatch and complete response transmission. They
record method, version, message/task IDs, tenant, and request `contextId`, without
recording prompts, application metadata, or artifacts. Single-task operations
also record the first observed returned task ID when none was supplied in the
request.

HTTP failures and unary JSON-RPC errors mark spans failed, including protocol
errors returned with HTTP 200. Transmission exceptions also mark spans failed.

Core-hosted applications register the A2A source automatically. Existing ASP.NET
Core applications must configure their own OpenTelemetry exporters. Native A2A
sources are not enabled by this library; subscribing to them separately can
produce additional implementation-level spans.

## Examples

| Sample | Description |
| --- | --- |
| [Getting started](samples/Sample1_GettingStarted.md) | Native Agent Card, message handler, and JSON-RPC request. |
| [Tasks and artifacts](samples/Sample2_TasksAndArtifacts.md) | Task lifecycle, artifact output, and retrieval. |
| [Multi-turn](samples/Sample3_MultiTurn.md) | Input-required workflow and task continuation. |
| [Long-running tasks](samples/Sample4_LongRunningTasks.md) | Immediate return and polling for completion. |
| [Customize the build](samples/Sample5_CustomizeTheBuild.md) | Application dependencies, storage, and native options. |
| [Existing request handler](samples/Sample6_ExistingRequestHandler.md) | Preserve a native handler and its storage. |
| [Native A2A hosting](samples/Sample7_NativeA2AHosting.md) | Add Foundry hosting to existing native registrations. |
| [Tier 1 customization](samples/Sample8_Tier1HostingCustomize.md) | Configure the one-call server. |
| [Tier 2 builder](samples/Sample9_Tier2HostingBuilder.md) | Compose protocols on the Core host. |
| [Tier 3 self-hosting](samples/Sample10_Tier3SelfHosting.md) | Own the ASP.NET Core application and middleware. |
| [Task persistence](samples/Sample11_TaskPersistence.md) | Retention and snapshot retrieval after host reconstruction. |

### Compose with the Core host

Use the builder to register application services, configure tracing, or compose
A2A with another Agent Server protocol:

```C# Snippet:A2A_Builder
var builder = AgentHost.CreateBuilder();
builder.AddA2A<EchoAgent>(CreateCard());
builder.Build().Run();
```

### Use an existing ASP.NET Core application

Register Foundry services and map the A2A endpoints on your own application:

```C# Snippet:A2A_Standalone
var builder = WebApplication.CreateBuilder();
builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
var app = builder.Build();
app.MapFoundryA2A();
app.Run();
```

`WebApplication.MapFoundryA2A()` installs Core middleware and maps readiness as
well as the protocol endpoints. Your application still owns port configuration,
telemetry exporters, and shutdown settings.

If you use the `IEndpointRouteBuilder.MapFoundryA2A()` overload instead, it maps
only protocol routes. Register Core services, install `UseAgentServerCore()`,
and map readiness yourself.

### Emit native tasks and artifacts

A message-only reply does not create a task snapshot. Use the native `TaskUpdater`
when you want task lifecycle and artifact events. Snapshots are saved through
the configured `ITaskStore`; using this handler does not itself enable durable
storage:

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

## Troubleshooting

### Common errors

- **Endpoint not found:** Register services with `AddFoundryA2A` and map them
  with `MapFoundryA2A`, or use the Core builder's `AddA2A` integration.
- **Task not found:** Check the task ID, caller scope, retention settings, and
  configured store. A message-only response does not create a task, and the
  default local store does not survive process restarts.
- **Storage isolation error:** Supply the hosted caller context and use a
  backing state store with user isolation enabled. Do not disable isolation
  to work around the error.
- **Method not found:** Use A2A v1.0 method names, such as `SendMessage` and
  `GetTask`, rather than v0.3 names.
- **Unsupported card capability at startup:** Do not advertise push notifications
  or extended agent cards; those surfaces are not exposed by this host.

### Logging

Enable ASP.NET Core logging to diagnose request routing and application failures.
Core-hosted applications configure OpenTelemetry automatically; configure an
exporter to collect the `Azure.AI.AgentServer.A2A` activity source in an existing
ASP.NET Core host.

## Next steps

- [Samples](samples/) - Native A2A handlers, tasks, and hosting.
- [Native A2A examples][a2a_samples] - Native handlers, tasks, and clients.
- [Agent Server Core][core] - Shared hosting, request context, and telemetry.
- [Agent Server libraries][agentserver] - Protocol selection and multi-protocol hosting.

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only
need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.A2A/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.A2A
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
[a2a]: https://github.com/a2aproject/a2a-dotnet
[a2a_samples]: https://github.com/a2aproject/a2a-dotnet/tree/main/samples
[core]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core
[agentserver]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver
