# Sample 7: M365-Native Hosting — Convert an Existing Agent

If you already have a Microsoft 365 Agents SDK agent (a class deriving from `AgentApplication`
registered with `builder.AddAgent<T>()`), you can host it in Azure AI Foundry as an Activity
protocol agent with a **two-line change**. Your agent class, its `AddAgent<T>()` registration, and
your storage registration all stay exactly as they are.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## Keep your agent class unchanged

This is an ordinary Microsoft 365 Agents SDK agent — nothing here is Foundry-specific.

```C# Snippet:Activity_Sample7_Agent
// A standard Microsoft 365 Agents SDK agent — unchanged when hosting in Foundry.
public class EchoAgent : AgentApplication
{
    public EchoAgent(AgentApplicationOptions options)
        : base(options)
    {
        // Register handlers by referencing named methods (the common Microsoft 365 Agents SDK style).
        OnActivity(ActivityTypes.Message, OnMessageAsync, rank: RouteRank.Last);
    }

    private async Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
    {
        var userText = turnContext.Activity.Text ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(userText))
        {
            await turnContext.SendActivityAsync($"Echo: {userText}", cancellationToken: cancellationToken);
        }
    }
}
```

## Convert the host — two lines

Replace the Microsoft 365 Agents SDK authentication registration with `AddFoundryActivity()`, and
replace the authentication middleware + endpoint mapping with `MapFoundryActivity()`.

| Concern        | Microsoft 365 Agents SDK                                        | Foundry hosted agent           |
| -------------- | -------------------------------------------------------------- | ------------------------------ |
| Auth wiring    | `.AddAgentAuthorization(b => b.AddAgentAspNetAuthentication())` | `builder.AddFoundryActivity()` |
| Pipeline + map | `app.UseAgents()` + `app.MapDefaultAgentEndpoints()`           | `app.MapFoundryActivity()`     |

> Depending on your Microsoft 365 Agents SDK version the auth/pipeline lines may instead read
> `AddAgentAspNetAuthentication(Configuration)`, `UseAuthentication()`/`UseAuthorization()`, and
> `MapAgentApplicationEndpoints(...)`. The Foundry replacement is the same either way.
> `AddAgentAspNetAuthentication` is a sample-local helper (each Microsoft 365 sample copies it into
> its own `AspNetExtensions.cs`), not a library method.

```C# Snippet:Activity_Sample7_M365NativeHosting
var builder = WebApplication.CreateBuilder(args);

// Register the agent — UNCHANGED from the Microsoft 365 Agents SDK.
builder.AddAgent<EchoAgent>();

// Register storage — UNCHANGED from the Microsoft 365 Agents SDK.
builder.Services.AddSingleton<IStorage, MemoryStorage>();

// Foundry conversion (1/2): replaces the Microsoft 365 auth registration
// (AddAgentAspNetAuthentication / AddAgentAuthorization).
builder.AddFoundryActivity();

var app = builder.Build();

// Foundry conversion (2/2): replaces the Microsoft 365 pipeline + endpoint mapping
// (UseAgents / UseAuthentication + MapDefaultAgentEndpoints / MapAgentApplicationEndpoints).
app.MapFoundryActivity();

app.Run();
```

`AddFoundryActivity()` registers the Activity protocol server, the Foundry-managed `IConnections`
(outbound token provider), the `CloudAdapter`, and the background delivery service.
`MapFoundryActivity()` maps the Activity endpoint (`POST /activity/messages`) and exposes the `/readiness` health probe.

## When to use the factory instead

If you are starting fresh (no existing M365 host to convert), [`ActivityServer.Run(...)`](Sample1_GettingStarted.md)
is a more concise entry point that also wires OpenTelemetry and health probes for you.

## Next steps

- [Getting Started](Sample1_GettingStarted.md) — the `ActivityServer.Run(...)` one-liner.
- [Customize the Build](Sample4_CustomizeTheBuild.md) — override storage, connections, and services.
