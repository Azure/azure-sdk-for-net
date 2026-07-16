# Sample 9: Tier 2 — Builder with Full Control

This sample demonstrates the **Tier 2** developer experience for the Activity protocol: use
`AgentHost.CreateBuilder()` to get full control over service registration, configuration, and
tracing while still leveraging the Core framework infrastructure (OpenTelemetry, health probes,
middleware). This is the Activity counterpart to `builder.AddResponses<T>()` /
`builder.AddInvocations<T>()`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## The agent

Your agent is a standard Microsoft 365 Agents SDK `AgentApplication` — unchanged from any other
hosting tier:

```C# Snippet:Activity_Sample9_Agent
// A standard Microsoft 365 Agents SDK agent hosted via the Tier 2 builder.
public sealed class EchoAgent : AgentApplication
{
    public EchoAgent(AgentApplicationOptions options) : base(options)
    {
        OnActivity(ActivityTypes.Message, OnMessageAsync, rank: RouteRank.Last);
    }

    private async Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
    {
        await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
    }
}
```

## Register on the builder

Register services on the Core host builder, then add the Activity protocol with your agent type:

```C# Snippet:Activity_Sample9_BuilderGeneric
var builder = AgentHost.CreateBuilder(args);

// Optional: register your own storage and services on the Core host builder.
builder.Services.AddSingleton<IStorage, MemoryStorage>();

// Register the Activity protocol with your AgentApplication type.
builder.AddActivity<EchoAgent>();

var app = builder.Build();
app.Run();
```

## Configuration, tracing, and the outbound-auth model

The options callback selects the outbound-auth model; `ConfigureTracing` / `ConfigureShutdown` work
exactly as in the other protocols:

```C# Snippet:Activity_Sample9_BuilderWithTracing
var builder = AgentHost.CreateBuilder(args);

builder.AddActivity<EchoAgent>(options =>
{
    options.DigitalWorker = true;
});

// Configuration and tracing work the same as the other protocols.
builder.ConfigureTracing(tracing => tracing.AddSource("MyAgent.BusinessLogic"));
builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

var app = builder.Build();
app.Run();
```

## Host a pre-built application instance

When you construct the `AgentApplication` yourself, host the instance (with its handlers already
registered) instead of a type:

```C# Snippet:Activity_Sample9_BuilderWithInstance
var builder = AgentHost.CreateBuilder(args);

// Host a pre-built AgentApplication instance (with its handlers already registered)
// instead of a type — useful when you construct the application yourself.
builder.AddActivity(prebuiltAgent);

var app = builder.Build();
app.Run();
```

## Use a factory delegate for full control

When you need full control over how the application is constructed — while still having access to
the `IServiceProvider` — use the factory overload. This mirrors the Microsoft 365 Agents SDK's
`builder.AddAgent(sp => ...)` factory registration:

```C# Snippet:Activity_Sample9_BuilderWithFactory
var builder = AgentHost.CreateBuilder(args);

// Use a factory delegate for full control over how the application is constructed,
// while still having access to the IServiceProvider. This mirrors the Microsoft 365
// Agents SDK's builder.AddAgent(sp => ...) factory registration.
builder.AddActivity(sp =>
{
    var options = sp.GetRequiredService<AgentApplicationOptions>();
    return new EchoAgent(options);
});

var app = builder.Build();
app.Run();
```

## Test the endpoint

Message activities require `from` + `recipient`; the reply is delivered asynchronously to the
caller's `serviceUrl`:

```bash
curl -X POST http://localhost:8088/activity/messages \
  -H "Content-Type: application/json" \
  -d '{"type":"message","text":"hello","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:9099/","id":"a1"}'
# -> HTTP/1.1 202 Accepted
```

## When to use Tier 2

Use `AgentHost.CreateBuilder()` when you need to:

- **Compose multiple protocols** on one host (Activity + Responses + Invocations)
- Override **shutdown timeout**, **port binding**, or **tracing** at the builder level
- Access the underlying `WebApplicationBuilder` for advanced configuration

For the simplest single-protocol experience, see
[Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample8_Tier1HostingCustomize.md).
To add Activity endpoints to an existing app, see
[Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample10_Tier3SelfHosting.md).
