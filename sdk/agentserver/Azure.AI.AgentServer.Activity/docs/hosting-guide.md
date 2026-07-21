# Activity hosting & handler guide

This guide is the developer-facing reference for building an activity-protocol
agent with `Azure.AI.AgentServer.Activity`. Every sample in
[samples/](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples)
is written using only this guide and the public API surface.

- [What the library does](#what-the-library-does)
- [The agent you write](#the-agent-you-write)
- [Hosting tiers](#hosting-tiers)
- [`ActivityServerOptions`](#activityserveroptions)
- [Endpoints](#endpoints)
- [Outbound-auth models](#outbound-auth-models)
- [Session and correlation](#session-and-correlation)
- [Error-source classification](#error-source-classification)
- [Distributed tracing](#distributed-tracing)
- [Custom request handler (Tier 3, raw)](#custom-request-handler-tier-3-raw)
- [Testing your agent](#testing-your-agent)

## What the library does

`Azure.AI.AgentServer.Activity` hosts a Microsoft 365 Agents SDK
`AgentApplication` as an Azure AI Foundry **hosted agent** that speaks the
**activity protocol** (`POST /activity/messages`, plus the Bot
Framework-compatible `POST /api/messages`, and a `GET /readiness` probe).

The split of responsibilities:

- **You own** the agent behaviour — the `AgentApplication` and its activity
  handlers (this is ordinary Microsoft 365 Agents SDK code).
- **The library owns** the Foundry hosting concerns — the activity endpoint, the
  outbound-auth connection provider, session/correlation resolution,
  error-source classification, and distributed tracing.

## The agent you write

The agent is a standard Microsoft 365 Agents SDK `AgentApplication`. Register
handlers by activity type:

```csharp
app.OnActivity(ActivityTypes.Message, async (turnContext, turnState, cancellationToken) =>
{
    var text = turnContext.Activity.Text ?? string.Empty;
    if (!string.IsNullOrWhiteSpace(text))
    {
        await turnContext.SendActivityAsync($"Echo: {text}", cancellationToken: cancellationToken);
    }
});

app.OnConversationUpdate(ConversationUpdateEvents.MembersAdded, async (turnContext, turnState, cancellationToken) =>
{
    await turnContext.SendActivityAsync("Welcome!", cancellationToken: cancellationToken);
});
```

Nothing about your handlers is library-specific — the same agent runs on any
Microsoft 365 Agents SDK host. The library only changes *how the app is hosted*.

## Hosting tiers

Choose the tier that matches how much of the host you want to own. All three
expose the same endpoints and outbound-auth behaviour.

### Tier 1 — one-liner

`ActivityServer.Run(...)` builds the full host from the environment, registers
your inline handlers, maps the endpoints, and runs. Simplest path.

```csharp
ActivityServer.Run(
    (AgentApplication app) =>
    {
        app.OnActivity(ActivityTypes.Message, async (turnContext, turnState, cancellationToken) =>
            await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken));
    },
    args);
```

Overloads let you pass an `Action<ActivityServerOptions>` to configure the model,
or customize the underlying builder before it runs.

### Tier 2 — builder

Use the host builder when you need to register services, storage, or an agent
class before the host is built. Register the agent with `builder.AddAgent<TAgent>()`
(or the activity host builder extension), then map the endpoints.

### Tier 3 — self-hosted

Add the Activity endpoints to your **own** ASP.NET Core app. Two entry points:

- `builder.AddFoundryActivity()` / `app.MapFoundryActivity()` — convert an
  existing Microsoft 365 Agents SDK app to a Foundry hosted agent with a
  two-line change (see [M365-native hosting](#the-two-line-conversion)).
- `builder.Services.AddActivityServer()` / `((IEndpointRouteBuilder)app).MapFoundryActivity(requestDelegate)`
  — own the request pipeline entirely (see
  [Custom request handler](#custom-request-handler-tier-3-raw)).

### The two-line conversion

An existing Microsoft 365 Agents SDK app becomes a Foundry hosted agent by adding
two lines — the rest of the app is unchanged:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddAgent<EchoAgent>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();

builder.AddFoundryActivity();   // (1) register the Foundry hosting

var app = builder.Build();
app.MapFoundryActivity();        // (2) map the Activity endpoints + readiness probe
app.Run();
```

`MapActivityServer()` is an alias of `MapFoundryActivity()`.

## `ActivityServerOptions`

Configuration for the host, passed via the `Action<ActivityServerOptions>`
overloads of `AddFoundryActivity` / `ActivityServer.Run`.

| Property | Meaning |
|----------|---------|
| `DigitalWorker` | Selects the outbound-auth model. `false` (default) uses the simple Bot Connector token; `true` uses the digital-worker federated-identity model. See [Outbound-auth models](#outbound-auth-models). |

```csharp
builder.AddFoundryActivity(options =>
{
    options.DigitalWorker = true;
});
```

## Endpoints

Mapping the Activity endpoints registers:

| Route | Method | Purpose |
|-------|--------|---------|
| `/activity/messages` | POST | The activity-protocol inbound endpoint (primary). |
| `/api/messages` | POST | Bot Framework-compatible alias for the same inbound path. |
| `/readiness` | GET | Readiness probe — returns `200` when the host is ready. |

A normal-delivery inbound message is queued and acknowledged with **`202
Accepted`**; the reply is delivered outbound over the channel. Every response
carries the `x-agent-session-id` header (see
[Session and correlation](#session-and-correlation)).

## Outbound-auth models

The library replies to the channel (e.g. Teams) using one of two models,
selected by `ActivityServerOptions.DigitalWorker`:

- **Simple** (`DigitalWorker = false`, default) — the agent-instance managed
  identity mints a Bot Connector token (scope
  `https://api.botframework.com/.default`).
- **Digital worker** (`DigitalWorker = true`) — the blueprint identity performs a
  federated-identity (FMI) token exchange to obtain an agentic token (scope
  `5a807f24-c9de-44ee-a3a7-329e88a00ffc/.default`).

The identity material (blueprint / instance client ids, tenant) is provided by
the Foundry-hosted container environment. You do not configure credentials
directly — you only choose the model.

## Session and correlation

Each inbound request resolves a **session id** (from the request, headers, or the
inbound activity) and stamps it on the response as `x-agent-session-id`. Session
ids are sanitized before use in headers and logs to prevent header-injection and
to enforce the id character/length constraints. Correlation baggage is propagated
for tracing.

## Error-source classification

Exceptions thrown while handling a request are classified as **platform** faults
vs. **user-container** faults, so the Foundry platform can attribute failures
correctly. The classification is applied as an endpoint filter on the mapped
routes and surfaced via response headers. You do not need to do anything to opt
in — mapping the endpoints wires it up.

## Distributed tracing

The library instruments the request path with `System.Diagnostics.Activity` and
propagates session/conversation baggage so a turn shows up as a single
correlated trace. Use your host's normal OpenTelemetry configuration to export
it; no library-specific setup is required.

## Custom request handler (Tier 3, raw)

When you want to own the request pipeline — read the request and write the
response yourself, without the Microsoft 365 Agents SDK adapter — map the Activity
endpoints to your own `RequestDelegate`. The platform still stamps the session-id
header, correlation baggage, and error-source classification around your handler.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddActivityServer();     // Activity services only (no M365 SDK adapter)

var app = builder.Build();
app.UseAgentServerCore();
app.MapHealthChecks("/readiness");

((IEndpointRouteBuilder)app).MapFoundryActivity(async context =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync($"Received {body.Length} bytes.");
});

app.Run();
```

## Testing your agent

Host your agent in an in-process ASP.NET Core test server and drive it over HTTP —
no live channel required for the accept/readiness paths:

```csharp
var builder = WebApplication.CreateBuilder();
builder.WebHost.UseTestServer();
builder.AddAgent<EchoAgent>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();
builder.AddFoundryActivity();

using var app = builder.Build();
app.MapFoundryActivity();
await app.StartAsync();

var client = app.GetTestClient();
var response = await client.PostAsync("/activity/messages", new StringContent(
    """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a1"}""",
    System.Text.Encoding.UTF8, "application/json"));

// Normal-delivery messages are acknowledged with 202 and carry the session header.
Assert.That((int)response.StatusCode, Is.EqualTo(202));
```

Outbound **reply delivery** requires a real Bot Connector token, so tests that
assert on the delivered reply must run as live tests against a Foundry project.
See `tests/SampleEndToEndTests.cs` for the CI-safe (accept/readiness) and
live (reply-delivery) split.
