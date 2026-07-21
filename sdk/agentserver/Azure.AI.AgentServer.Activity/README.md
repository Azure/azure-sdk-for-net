# Azure AI Agent Server Activity library for .NET

`Azure.AI.AgentServer.Activity` is a .NET library for hosting a Microsoft 365 Agents SDK
`AgentApplication` as an Azure AI Foundry hosted agent that speaks the **activity protocol**
(`POST /activity/messages`, plus the Bot Framework-compatible `POST /api/messages`). Your agent is
an ordinary Microsoft 365 Agents SDK application; this library adds the Foundry-specific hosting —
the outbound-auth connection provider, the activity endpoint, session and correlation resolution,
error-source classification, and distributed tracing — on top of the shared
`Azure.AI.AgentServer.Core` host.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 8](https://dotnet.microsoft.com/download) or later
- The `Azure.AI.AgentServer.Core` package (installed automatically as a dependency)

### Run an agent

The fastest path registers handlers inline on the `AgentApplication` the host builds for you — no
agent class required:

```csharp
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Core.Models;

ActivityServer.Run((AgentApplication app) =>
{
    app.OnActivity(ActivityTypes.Message, async (turnContext, turnState, cancellationToken) =>
    {
        await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
    });
});
```

Or host an agent class by type — the standard Microsoft 365 Agents SDK style, where handlers are
registered in the constructor:

```csharp
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;

public sealed class EchoAgent : AgentApplication
{
    public EchoAgent(AgentApplicationOptions options) : base(options)
    {
        OnActivity(ActivityTypes.Message, OnMessageAsync, rank: RouteRank.Last);
    }

    private Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
        => turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
}

// Program.cs
ActivityServer.Run<EchoAgent>(args);
```

## Key concepts

### `ActivityServer.Run(...)`

The one-line entry point. Each overload creates the Core host builder, registers the Activity
protocol, builds, and runs — wiring OpenTelemetry, health probes, and the Foundry middleware for
you. Pick the overload that matches how your agent is constructed:

| Overload | Use when |
|----------|----------|
| `Run<TAgent>()` | You have an `AgentApplication` subclass (handlers in its constructor). |
| `Run(app => ...)` | You want to register handlers inline, without an agent class. |
| `Run(agentApp)` | You built the `AgentApplication` instance yourself. |
| `Run(factory)` | Constructing the agent needs services from DI (`Func<IServiceProvider, AgentApplication>`). |
| `Run(requestHandler)` | You want to own the raw request pipeline (`RequestDelegate`); the M365 SDK is not initialized. |

Each `Run` overload (except the raw-handler one) also accepts `configureOptions` to configure
`ActivityServerOptions` and `configure` to further configure the underlying `AgentHostBuilder`.

### `ActivityServerOptions`

Configuration for the built stack. Every property is optional.

| Property | Description |
|----------|-------------|
| `DigitalWorker` | Selects the outbound-auth model (default `false` = simple agent-instance identity). |
| `Storage` | The turn-state storage backend (default: in-memory `MemoryStorage`). |
| `Connections` | The outbound-auth token provider (default: Foundry managed-identity connections). |
| `ConnectionConfiguration` | The M365 `CONNECTIONS__*` mapping (default: derived from the Foundry-native identity). |
| `ConfigureServices` | A callback to register additional services before the SDK defaults. |

### Outbound auth models

Reply delivery supports two identity models, selected via `ActivityServerOptions.DigitalWorker`:

- **Simple** (`DigitalWorker = false`, default) — the agent *instance* identity
  (`FOUNDRY_AGENT_INSTANCE_CLIENT_ID`) mints the Bot Connector token directly, scoped to
  `https://api.botframework.com/.default`.
- **Digital worker** (`DigitalWorker = true`) — the *blueprint* identity
  (`FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID`) performs a federated-identity (FMI) token exchange to obtain
  an agentic user token.

### Hosting tiers

Three levels of control, from most opinionated to least:

- **Tier 1 — one-liner:** `ActivityServer.Run(...)`. The library owns the host.
- **Tier 2 — builder:** `AgentHost.CreateBuilder(args).AddActivity<TAgent>()` (also `AddActivity(agentApp)`
  and `AddActivity(factory)`). Compose on the Core builder to register your own services and tracing.
- **Tier 3 — self-hosted:** on your own `WebApplication`, `builder.AddFoundryActivity()` +
  `app.MapFoundryActivity()` (aliased as `AddActivityServer()` / `MapActivityServer()`) add the
  Activity endpoints alongside your own routes. This is also the two-line conversion path for an
  existing Microsoft 365 Agents SDK app.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.AddAgent<EchoAgent>();                            // unchanged Microsoft 365 Agents SDK
builder.Services.AddSingleton<IStorage, MemoryStorage>(); // unchanged
builder.AddFoundryActivity();                             // Foundry conversion (1/2)

var app = builder.Build();
app.MapFoundryActivity();                                 // Foundry conversion (2/2)
app.Run();
```

### Endpoints

| Method | Path | Purpose |
|--------|------|---------|
| POST | `/activity/messages` | Inbound activity (Foundry path). |
| POST | `/api/messages` | Inbound activity (Bot Framework-compatible path). |
| GET | `/readiness` | Readiness probe (200 when ready). |

Inbound `message` activities are queued to the Microsoft 365 Agents SDK background service and
acknowledged with **HTTP 202 Accepted**; the reply is delivered asynchronously to the caller''s
`serviceUrl`. Every response carries the resolved session-id header and correlation baggage.

## Examples

Compiled walkthroughs live in the [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples)
directory (getting started, welcome/commands, digital worker, customizing the build, custom request
handler, injected application, M365-native hosting, the three hosting tiers, Adaptive Cards, and
invoke activities). Deployable projects are in the Foundry hosted-agents sample gallery.

## Troubleshooting

- **404 on `/activity/messages`**: Ensure you registered the protocol — via `ActivityServer.Run(...)`,
  `builder.AddActivity(...)`, or `builder.AddFoundryActivity()` + `app.MapFoundryActivity()`.
- **Replies not delivered**: Confirm the inbound activity carries a `serviceUrl` and conversation
  id, and that the outbound-auth model (`DigitalWorker`) and connection environment variables
  (`FOUNDRY_AGENT_INSTANCE_CLIENT_ID` / `FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID` / `FOUNDRY_AGENT_TENANT_ID`)
  match your deployment. Outbound managed-identity token acquisition only succeeds when deployed to
  Azure.

## Next steps

- Read the [hosting & handler guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/docs/hosting-guide.md) for the full hosting-tier and handler reference.
- Review the [activity protocol samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples).
- Learn about the shared host in [`Azure.AI.AgentServer.Core`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core).

## Contributing

This project welcomes contributions and suggestions. See the repository
[CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Activity
[product_doc]: https://learn.microsoft.com/azure/ai-foundry/
