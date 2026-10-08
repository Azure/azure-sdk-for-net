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

## Compose multiple protocols on one host

The main reason to reach for Tier 2 is **composition** — hosting more than one agent
protocol on a single server. Because every `Add*` extension returns the same
`AgentHostBuilder`, you can chain them; each protocol registers its own endpoints on the
shared Core pipeline (OpenTelemetry, health probes, identity/session headers, graceful
shutdown), and everything runs on one port.

Add a second protocol package alongside Activity:

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

Here the Activity agent (Teams/channel conversations at `POST /activity/messages`) is
composed with an Invocations handler (synchronous request/response at `POST /invocations`)
on the same host:

```C# Snippet:Activity_Sample9_OpsInvocationHandler
// A second protocol hosted on the same server: a simple Invocations handler
// that exposes an operational "ping" endpoint at POST /invocations. Composition
// means the Activity agent and this handler share one host, port, and pipeline.
public sealed class OpsInvocationHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        response.ContentType = "application/json";
        await response.WriteAsJsonAsync(
            new { status = "ok", session_id = context.SessionId },
            cancellationToken);
    }
}
```

```C# Snippet:Activity_Sample9_ComposeProtocols
var builder = AgentHost.CreateBuilder(args);

builder.Services.AddSingleton<IStorage, MemoryStorage>();

// Compose multiple protocols on a single host. Each Add* call registers its
// own endpoints on the shared Core pipeline (OpenTelemetry, health probes,
// identity/session headers, graceful shutdown):
//   - Activity     -> POST /activity/messages   (Teams/channel conversations)
//   - Invocations  -> POST /invocations         (synchronous request/response)
builder
    .AddActivity<EchoAgent>()
    .AddInvocations<OpsInvocationHandler>();

var app = builder.Build();
app.Run();
```

The same pattern extends to the Responses protocol (`builder.AddResponses<THandler>()`) —
mix and match whichever protocols your agent needs.

## Test the endpoint

Message activities require `from` + `recipient`; the reply is delivered asynchronously to the
caller's `serviceUrl`:

```bash
curl -X POST http://localhost:8088/activity/messages \
  -H "Content-Type: application/json" \
  -d '{"type":"message","text":"hello","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:9099/","id":"a1"}'
# -> HTTP/1.1 202 Accepted
```

When you compose the Invocations protocol (above), its endpoint is served on the same host:

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: application/json" -d '{}'
# -> {"status":"ok","session_id":"..."}
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
