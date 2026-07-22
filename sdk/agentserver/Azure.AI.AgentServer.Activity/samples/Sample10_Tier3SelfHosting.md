# Sample 10: Tier 3 — Self-Hosted in an Existing ASP.NET App

This sample demonstrates the **Tier 3** developer experience for the Activity protocol: you own the
HTTP host and use `AddActivityServer()` + `MapActivityServer()` to add Activity endpoints alongside
your own routes. This is useful when you have an existing ASP.NET Core application and want to add a
Microsoft 365 Agents SDK agent without adopting the Core framework one-liner.

> `AddActivityServer()` / `MapActivityServer()` are aliases for `AddFoundryActivity()` /
> `MapFoundryActivity()`. Use whichever names you prefer — they are identical.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## The agent

```C# Snippet:Activity_Sample10_Agent
// A standard Microsoft 365 Agents SDK agent hosted in your own ASP.NET Core app.
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

## Add the Activity protocol to your existing app

```C# Snippet:Activity_Sample10_SelfHost
var builder = WebApplication.CreateBuilder(args);

// Your existing agent + storage registration (unchanged Microsoft 365 Agents SDK setup).
builder.AddAgent<EchoAgent>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();

// Add the Activity protocol to your own host. AddActivityServer() is the alias for
// AddFoundryActivity().
builder.AddActivityServer();

var app = builder.Build();

// Your existing endpoints coexist with the Activity endpoints.
app.MapGet("/", () => "My existing app");

// Map the Activity endpoint (/activity/messages) and /readiness.
// MapActivityServer() is the alias for MapFoundryActivity().
app.MapActivityServer();

app.Run();
```

## Full control — wire the pipeline and observability yourself

`AddActivityServer()` + `app.MapActivityServer()` bundle the Core middleware and `/readiness` probe
for you, but they do **not** wire OpenTelemetry. When you need full control over pipeline ordering
and observability, register the Activity services, add the Microsoft OpenTelemetry distro yourself,
and map only the endpoints via the `IEndpointRouteBuilder` overload:

```C# Snippet:Activity_Sample10_FullControl
var builder = WebApplication.CreateBuilder(args);

builder.AddAgent<EchoAgent>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();

// Register the Activity protocol services without the bundled endpoint/middleware wiring,
// so you own the pipeline order and can add your own middleware and observability.
builder.Services.AddActivityServer();

// Observability: the Microsoft OpenTelemetry distro with traces and metrics. The bundled
// MapActivityServer() path does not wire this for you, so add it here for full control.
var otel = builder.Services.AddOpenTelemetry();
otel.UseMicrosoftOpenTelemetry(options => { });
otel.WithTracing(tracing => tracing.AddSource("Azure.AI.AgentServer.Activity"))
    .WithMetrics(metrics => metrics.AddMeter("Azure.AI.AgentServer.Activity"));

var app = builder.Build();

// You order the middleware pipeline and health probe yourself.
app.UseAgentServerCore();
app.MapHealthChecks("/readiness");

app.MapGet("/", () => "My existing app");

// Map only the Activity endpoints via the IEndpointRouteBuilder overload (no bundled
// middleware/health — you wired those above).
((IEndpointRouteBuilder)app).MapActivityServer();

app.Run();
```

## Own the request pipeline — a raw handler (no Microsoft 365 adapter)

When you want to receive each inbound activity as a raw `HttpContext` and write the response
yourself — without the Microsoft 365 Agents SDK adapter — pass a `RequestDelegate` to the
`IEndpointRouteBuilder` overload of `MapFoundryActivity()` (aliased as `MapActivityServer()`). The
Microsoft 365 Agents SDK is **not** initialized on this path, but the platform still stamps the
session-id response header, correlation baggage, and error-source classification around your handler.

```C# Snippet:Activity_Sample10_RawHandler
var builder = WebApplication.CreateBuilder(args);

// Register only the Activity package services (for the session-id / baggage stamping).
// The Microsoft 365 Agents SDK is not initialized on the raw-handler path.
builder.Services.AddActivityServer();

var app = builder.Build();

// Foundry platform middleware (request-id, correlation baggage, inbound logging).
app.UseAgentServerCore();
app.MapHealthChecks("/readiness");

// Your existing endpoints coexist with the Activity endpoints.
app.MapGet("/", () => "My existing app");

// Own the request pipeline: map the Activity endpoints to your own RequestDelegate.
// You read the request and write the response yourself — no Microsoft 365 adapter —
// while the platform still stamps the session-id header, correlation baggage, and
// error-source classification around your handler.
((IEndpointRouteBuilder)app).MapFoundryActivity(async context =>
{
    using var reader = new System.IO.StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync($"Received {body.Length} bytes.");
});

app.Run();
```

> This is the Tier 3 counterpart of `ActivityServer.Run(RequestDelegate)` (see
> [Custom Request Handler](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample5_CustomRequestHandler.md)):
> the Tier 1 one-liner owns the host for you, while this overload maps the raw handler onto a host
> you already own.


```bash
# Your existing route
curl http://localhost:8088/

# The Activity endpoint (message activities require from + recipient)
curl -X POST http://localhost:8088/activity/messages \
  -H "Content-Type: application/json" \
  -d '{"type":"message","text":"hello","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:9099/","id":"a1"}'
# -> HTTP/1.1 202 Accepted (the reply is delivered asynchronously to serviceUrl)
```

## When to use Tier 3

Use `WebApplication.CreateBuilder()` + `AddActivityServer()` + `MapActivityServer()` when you:

- Have an **existing ASP.NET Core application** and want to add a Microsoft 365 agent endpoint
- Need **full control** over middleware, DI, port binding, and health probes
- Are **converting an existing Microsoft 365 Agents SDK agent** to a Foundry hosted agent (see also
  [M365-Native Hosting](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample7_M365NativeHosting.md))

For the simplest single-protocol experience, see
[Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample8_Tier1HostingCustomize.md).
For composition with the Core builder, see
[Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample9_Tier2HostingBuilder.md).
