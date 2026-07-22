# Activity Hosting & Handler Guide

> Developer guidance for hosting a Microsoft 365 Agents SDK `AgentApplication` as an
> Azure AI Foundry **hosted agent** with `Azure.AI.AgentServer.Activity` — the library
> that adds the Foundry activity-protocol contract on top of an ordinary agent.

---

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Minimal Host](#minimal-host)
  - [Running the Server](#running-the-server)
- [The Agent You Write](#the-agent-you-write)
- [Hosting Tiers](#hosting-tiers)
  - [Tier 1 — One-Line Startup](#tier-1--one-line-startup)
  - [Tier 2 — Host Builder](#tier-2--host-builder)
  - [Tier 3 — Self-Hosted (ASP.NET Core)](#tier-3--self-hosted-aspnet-core)
  - [The Two-Line Conversion](#the-two-line-conversion)
- [API Reference](#api-reference)
  - [`ActivityServer.Run`](#activityserverrun)
  - [`AddFoundryActivity` / `AddActivityServer`](#addfoundryactivity--addactivityserver)
  - [`MapFoundryActivity` / `MapActivityServer`](#mapfoundryactivity--mapactivityserver)
  - [`AddActivity` (host builder)](#addactivity-host-builder)
- [`ActivityServerOptions`](#activityserveroptions)
  - [`DigitalWorker`](#digitalworker)
  - [`Storage`](#storage)
  - [`Connections`](#connections)
  - [`ConnectionConfiguration`](#connectionconfiguration)
  - [`ConfigureServices`](#configureservices)
- [Endpoints](#endpoints)
- [Request Lifecycle](#request-lifecycle)
- [Outbound-Auth Models](#outbound-auth-models)
  - [Simple Agent (default)](#simple-agent-default)
  - [Digital Worker](#digital-worker)
- [`ActivityEnvironment`](#activityenvironment)
- [Session and Correlation](#session-and-correlation)
- [Error-Source Classification](#error-source-classification)
- [Distributed Tracing](#distributed-tracing)
- [Custom Request Handler (Tier 3, raw)](#custom-request-handler-tier-3-raw)
- [Testing Your Agent](#testing-your-agent)
- [Best Practices](#best-practices)
- [Common Mistakes](#common-mistakes)

---

## Overview

`Azure.AI.AgentServer.Activity` hosts a Microsoft 365 Agents SDK `AgentApplication`
as an Azure AI Foundry **hosted agent** that speaks the **activity protocol**
(`POST /activity/messages` and a `GET /readiness` probe).

The library owns all the Foundry hosting concerns so your agent code stays plain
Microsoft 365 Agents SDK code. You do **not** need to think about:

- The HTTP endpoint, routing, or request/response framing.
- How inbound activities are read, queued, and acknowledged with `202 Accepted`.
- How outbound replies are authenticated to the channel (Bot Connector or digital-worker token).
- Session-id resolution and the `x-agent-session-id` response header.
- Error-source classification (platform fault vs. user-container fault).
- Distributed-tracing baggage propagation for a turn.
- Reading the Foundry container identity/environment to wire outbound auth.

The split of responsibilities:

- **You own** the agent behaviour — the `AgentApplication` and its activity handlers
  (ordinary Microsoft 365 Agents SDK code).
- **The library owns** the Foundry hosting concerns — the activity endpoint, the
  outbound-auth connection provider, session/correlation resolution, error-source
  classification, and distributed tracing.

For most agents, the [one-line startup](#tier-1--one-line-startup) eliminates all
hosting boilerplate. When you need to own the ASP.NET Core pipeline, drop down to
[Tier 3](#tier-3--self-hosted-aspnet-core).

---

## Getting Started

### Minimal Host

The simplest agent registers a single message handler and starts the host in one call:

```csharp
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder.App;

ActivityServer.Run(
    (AgentApplication app) =>
    {
        app.OnActivity(ActivityTypes.Message, async (turnContext, turnState, cancellationToken) =>
        {
            var text = turnContext.Activity.Text ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(text))
            {
                await turnContext.SendActivityAsync($"Echo: {text}", cancellationToken: cancellationToken);
            }
        });
    },
    args);
```

### Running the Server

`ActivityServer.Run(...)` builds the full host from the environment, registers your
inline handlers, maps the endpoints, and runs. One call starts a Kestrel host with
OpenTelemetry, the `/readiness` probe, identity/session headers, the outbound-auth
connection provider, and the `POST /activity/messages` endpoint.

**Next steps**: See [Hosting Tiers](#hosting-tiers) for the builder and self-hosted
options, [`ActivityServerOptions`](#activityserveroptions) for configuration, and
[Outbound-Auth Models](#outbound-auth-models) for how replies are authenticated.

---

## The Agent You Write

The agent is a standard Microsoft 365 Agents SDK `AgentApplication`. Register
handlers by activity type — nothing here is library-specific:

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

The same agent runs on any Microsoft 365 Agents SDK host. The library only changes
*how the app is hosted* — it adds the Foundry activity-protocol contract around your
unchanged handlers.

---

## Hosting Tiers

Choose the tier that matches how much of the host you want to own. All three expose
the same endpoints and outbound-auth behaviour.

| Tier | Entry point | Own the host? | Use when |
|------|-------------|---------------|----------|
| 1 — One-liner | `ActivityServer.Run(...)` | No — the library builds it | You just want to run an agent |
| 2 — Host builder | `AgentHost.CreateBuilder(args)` + `builder.AddActivity<TAgent>()` | Partially — you configure the builder | You need to register services, storage, or an agent class |
| 3 — Self-hosted | `builder.AddFoundryActivity()` + `app.MapFoundryActivity()` | Yes — your own `WebApplication` | You have an existing ASP.NET Core app or want full pipeline control |

### Tier 1 — One-Line Startup

`ActivityServer.Run(...)` builds the full host from the environment, registers your
inline handlers, maps the endpoints, and runs. Simplest path.

```csharp
ActivityServer.Run(
    (AgentApplication app) =>
    {
        app.OnActivity(ActivityTypes.Message, async (turnContext, turnState, cancellationToken) =>
            await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken));
    },
    args);
```

Overloads let you register an agent by type, pass an already-constructed
`AgentApplication`, supply a factory, configure `ActivityServerOptions`, or customize
the underlying `AgentHostBuilder` before it runs. See
[`ActivityServer.Run`](#activityserverrun) for the full overload table.

### Tier 2 — Host Builder

Use the host builder when you need to register services, storage, or an agent class
before the host is built. Create the builder, add the activity server (which also
registers your agent), build, and run:

```csharp
using Azure.AI.AgentServer.Activity;
using Azure.AI.AgentServer.Core;

var builder = AgentHost.CreateBuilder(args);
builder.AddActivity<EchoAgent>();   // register the agent + the Foundry activity hosting
var app = builder.Build();
app.Run();
```

`AddActivity` has three overloads — by agent type (`TAgent`), by a constructed
`AgentApplication` instance, or by a `Func<IServiceProvider, AgentApplication>`
factory. Each accepts an optional `Action<ActivityServerOptions>`. See
[`AddActivity` (host builder)](#addactivity-host-builder).

### Tier 3 — Self-Hosted (ASP.NET Core)

Add the Activity endpoints to your **own** ASP.NET Core app. There are two entry points:

- `builder.AddFoundryActivity()` / `app.MapFoundryActivity()` — convert an existing
  Microsoft 365 Agents SDK app to a Foundry hosted agent with a two-line change (see
  [The two-line conversion](#the-two-line-conversion)).
- `builder.Services.AddActivityServer()` /
  `((IEndpointRouteBuilder)app).MapFoundryActivity(requestDelegate)` — own the request
  pipeline entirely (see [Custom request handler](#custom-request-handler-tier-3-raw)).

### The Two-Line Conversion

An existing Microsoft 365 Agents SDK app becomes a Foundry hosted agent by adding two
lines — the rest of the app is unchanged:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddAgent<EchoAgent>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();

builder.AddFoundryActivity();   // (1) register the Foundry hosting

var app = builder.Build();
app.MapFoundryActivity();        // (2) map the Activity endpoint + readiness probe
app.Run();
```

`AddActivityServer()` is an alias of `AddFoundryActivity()`, and `MapActivityServer()`
is an alias of `MapFoundryActivity()` — use whichever name reads best in your app.

---

## API Reference

### `ActivityServer.Run`

The Tier 1 entry point. Every overload builds the host, maps the endpoints, and runs
the app (this call blocks until the host shuts down). All overloads accept an optional
`string[] args`, an optional `Action<AgentHostBuilder> configure` to customize the
builder, and (for the agent overloads) an optional `Action<ActivityServerOptions>
configureOptions`.

| Overload | Register the agent by… | Use when |
|----------|------------------------|----------|
| `Run<TAgent>(...)` | Agent **type** (`TAgent : AgentApplication`) | Your agent is its own class |
| `Run(AgentApplication agentApp, ...)` | A **constructed instance** | You built the `AgentApplication` yourself |
| `Run(Action<AgentApplication> configureAgent, ...)` | An **inline configurator** | You register handlers inline (most samples) |
| `Run(Func<IServiceProvider, AgentApplication> factory, ...)` | A **DI factory** | The agent needs services from the container |
| `Run(RequestDelegate requestHandler, ...)` | *(no agent)* — a raw handler | You own the request pipeline (no M365 adapter) |

```csharp
// By type
ActivityServer.Run<EchoAgent>(args);

// Inline, with options
ActivityServer.Run(
    (AgentApplication app) => app.OnActivity(ActivityTypes.Message, HandleAsync),
    args,
    configureOptions: options => options.DigitalWorker = true);

// Raw request handler (no M365 SDK adapter)
ActivityServer.Run(async context =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    await context.Response.WriteAsync($"Received {body.Length} bytes.");
}, args);
```

### `AddFoundryActivity` / `AddActivityServer`

Registers the Foundry activity server services. Available on both
`IServiceCollection` and `IHostApplicationBuilder`, each with an optional
`Action<ActivityServerOptions>`. `AddActivityServer` is an alias of
`AddFoundryActivity`.

```csharp
// On the builder (registers into builder.Services)
builder.AddFoundryActivity(options => options.DigitalWorker = true);

// On a service collection directly
builder.Services.AddActivityServer();
```

Use the `IServiceCollection` overload (`AddActivityServer`) when you want the Activity
services **without** the Microsoft 365 Agents SDK adapter — for example when mapping a
[raw request handler](#custom-request-handler-tier-3-raw).

### `MapFoundryActivity` / `MapActivityServer`

Maps the `POST /activity/messages` endpoint and the `GET /readiness` probe. Available
on `WebApplication` and `IEndpointRouteBuilder`, plus an overload that takes a
`RequestDelegate` to route requests to your own handler. `MapActivityServer` is an
alias of `MapFoundryActivity`.

```csharp
app.MapFoundryActivity();                                   // adapter-backed (uses your AgentApplication)
((IEndpointRouteBuilder)app).MapFoundryActivity(handler);   // raw — routes to your RequestDelegate
```

### `AddActivity` (host builder)

The Tier 2 extension on `AgentHostBuilder`. Three overloads, each with an optional
`Action<ActivityServerOptions>`:

| Overload | Register the agent by… |
|----------|------------------------|
| `AddActivity<TAgent>(...)` | Agent **type** |
| `AddActivity(AgentApplication agentApp, ...)` | A **constructed instance** |
| `AddActivity(Func<IServiceProvider, AgentApplication> factory, ...)` | A **DI factory** |

```csharp
var builder = AgentHost.CreateBuilder(args);
builder.AddActivity<EchoAgent>(options => options.Storage = new MemoryStorage());
builder.Build().Run();
```

---

## `ActivityServerOptions`

Configuration for the host, passed via the `Action<ActivityServerOptions>` overloads
of `ActivityServer.Run`, `AddFoundryActivity`, `AddActivityServer`, and `AddActivity`.
**Every property is optional** — leave the defaults to have the host build the whole
Microsoft 365 Agents SDK stack from the Foundry container environment.

| Property | Type | Default | Purpose |
|----------|------|---------|---------|
| `DigitalWorker` | `bool` | `false` | Selects the [outbound-auth model](#outbound-auth-models). |
| `Storage` | `IStorage?` | `null` (→ `MemoryStorage`) | Turn-state storage backend. |
| `Connections` | `IConnections?` | `null` (→ Foundry-native) | Outbound-token connection provider. |
| `ConnectionConfiguration` | `IReadOnlyDictionary<string,string?>?` | `null` (→ derived) | The M365 `CONNECTIONS__*` mapping. |
| `ConfigureServices` | `Action<IServiceCollection>?` | `null` | Register additional/override services. |

### `DigitalWorker`

Selects the outbound-auth model used when the agent replies to the channel:

- `false` (default) — **Simple agent** model: the agent *instance* identity
  (`FOUNDRY_AGENT_INSTANCE_CLIENT_ID`) mints a Bot Connector token via Managed
  Identity, scoped to `https://api.botframework.com/.default`. Standard single-tenant
  Teams bot pattern.
- `true` — **Digital worker** model: the *blueprint* identity
  (`FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID`) performs a federated-identity (FMI) token
  exchange to obtain an agentic token.

```csharp
builder.AddFoundryActivity(options => options.DigitalWorker = true);
```

See [Outbound-Auth Models](#outbound-auth-models) for the full comparison.

### `Storage`

Optional storage backend for the Microsoft 365 Agents SDK turn state. Leave `null` to
use the built-in `MemoryStorage` — suitable for local and development use, but
conversation state is **not durable or shared across instances**. Supply a persistent
`IStorage` implementation for production multi-instance deployments.

```csharp
options.Storage = new MemoryStorage();      // dev/local
// options.Storage = new CosmosDbStorage(...); // production
```

### `Connections`

Optional connection provider used to acquire outbound (Bot Connector) tokens. Leave
`null` to use the Foundry-native provider that mints tokens from the container's
managed identity. Supply your own `IConnections` to control outbound-auth entirely
(for example, in a local test harness with a fake token provider).

### `ConnectionConfiguration`

Optional connection configuration (the M365 `CONNECTIONS__*` mapping) for the built
stack. Leave `null` to derive the settings from the Foundry-native identity via
[`ActivityEnvironment.GetHostedAgentConfiguration(bool)`](#activityenvironment). When
supplied, these settings are used **as-is** instead of the derived values.

### `ConfigureServices`

Optional callback to register additional services into the host's DI container
**before** the Microsoft 365 Agents SDK services are added. Because the SDK registers
its defaults only when a service is not already present, **anything registered here
wins** — use it to plug in a custom adapter, authorization, channel-service factory,
or any other service.

```csharp
options.ConfigureServices = services =>
{
    services.AddSingleton<IMyDependency, MyDependency>();
};
```

---

## Endpoints

Mapping the Activity endpoints registers:

| Route | Method | Purpose |
|-------|--------|---------|
| `/activity/messages` | POST | The activity-protocol inbound endpoint (primary). |
| `/readiness` | GET | Readiness probe — returns `200` when the host is ready. |

There is a single inbound endpoint — `POST /activity/messages`. (Earlier previews also
mapped a Bot Framework-compatible `/api/messages`; that path has been removed —
`/activity/messages` is the canonical route.)

---

## Request Lifecycle

A single turn flows through the library like this:

1. **Inbound** — the channel `POST`s an activity to `/activity/messages`.
2. **Session resolution** — the library resolves a session id and stamps it on the
   response as `x-agent-session-id` (see [Session and correlation](#session-and-correlation)).
3. **Accept** — a normal-delivery `message` activity is queued to the Microsoft 365
   Agents SDK background service and acknowledged immediately with **`202 Accepted`**.
   The HTTP response carries the session header and correlation baggage.
4. **Process** — the background service runs your `AgentApplication` handler.
5. **Outbound reply** — your handler's `SendActivityAsync(...)` is delivered to the
   channel over an authenticated connection (see [Outbound-auth models](#outbound-auth-models)).

Because the reply is delivered **asynchronously** over the channel (not in the HTTP
response body), an accept-path test only observes the `202` and the session header;
asserting on the delivered reply requires a live channel or Bot Connector token.

---

## Outbound-Auth Models

The library replies to the channel (e.g. Teams) using one of two models, selected by
[`ActivityServerOptions.DigitalWorker`](#digitalworker). The identity material
(blueprint / instance client ids, tenant) is provided by the Foundry-hosted container
environment — you do not configure credentials directly, you only choose the model.

| | Simple agent (default) | Digital worker |
|---|---|---|
| `DigitalWorker` | `false` | `true` |
| Identity used | Agent **instance** MI (`FOUNDRY_AGENT_INSTANCE_CLIENT_ID`) | Agent **blueprint** identity (`FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID`) |
| Token | Bot Connector token via Managed Identity | Agentic token via federated-identity (FMI) exchange |
| Scope | `https://api.botframework.com/.default` | Agentic scope (`…/.default`) |
| Typical use | Standard single-tenant Teams bot | On-behalf-of / agentic scenarios |

### Simple Agent (default)

With `DigitalWorker = false`, the agent-instance managed identity mints a Bot Connector
token directly. This is the standard single-tenant Teams bot pattern and requires no
extra configuration beyond the Foundry-provided instance identity.

### Digital Worker

With `DigitalWorker = true`, the blueprint identity performs a federated-identity token
exchange to obtain an agentic token. Select this model only when your scenario requires
the blueprint/agentic identity rather than the plain instance Bot Connector token.

---

## `ActivityEnvironment`

`ActivityEnvironment` reads the Foundry-hosted container environment and returns the
Microsoft 365 Agents SDK configuration (the `CONNECTIONS__*` mapping) that the host
uses to wire outbound auth. You normally never call it — the host calls it for you —
but it is public so you can inspect or reuse the derived settings.

```csharp
// The configuration the host would derive for the simple-agent model
IReadOnlyDictionary<string, string?> config = ActivityEnvironment.GetHostedAgentConfiguration();

// The configuration for the digital-worker model
IReadOnlyDictionary<string, string?> dwConfig = ActivityEnvironment.GetHostedAgentConfiguration(digitalWorker: true);
```

The result is the same mapping you would otherwise supply via
[`ActivityServerOptions.ConnectionConfiguration`](#connectionconfiguration) — useful for
diagnostics, or for composing a custom stack that reuses the Foundry-derived identity.

---

## Session and Correlation

Each inbound request resolves a **session id** (from the request, headers, or the
inbound activity) and stamps it on the response as `x-agent-session-id`. Session ids
are **sanitized** before use in headers and logs to prevent header-injection and to
enforce the id character/length constraints. Correlation baggage is propagated for
tracing so a whole turn shows up as a single correlated trace.

You do not need to do anything to opt in — mapping the endpoints wires this up.

---

## Error-Source Classification

Exceptions thrown while handling a request are classified as **platform** faults vs.
**user-container** faults, so the Foundry platform can attribute failures correctly.
The classification is applied as an endpoint filter on the mapped routes and surfaced
via response headers. Mapping the endpoints wires it up automatically — there is
nothing to configure.

This lets the platform distinguish "the hosting infrastructure failed" from "the
agent's own handler threw," which drives correct ret/alerting and billing attribution.

---

## Distributed Tracing

The library instruments the request path with `System.Diagnostics.Activity` and
propagates session/conversation baggage so a turn shows up as a single correlated
trace. Use your host's normal OpenTelemetry configuration to export it — no
library-specific setup is required. The Tier 1 and Tier 2 hosts enable OpenTelemetry
by default; in a Tier 3 self-hosted app, configure exporters as you would for any
ASP.NET Core service.

---

## Custom Request Handler (Tier 3, raw)

When you want to own the request pipeline — read the request and write the response
yourself, without the Microsoft 365 Agents SDK adapter — map the Activity endpoints to
your own `RequestDelegate`. The platform still stamps the session-id header,
correlation baggage, and error-source classification around your handler.

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

Use the raw handler only when you genuinely need to own request parsing and response
writing. If you just want to run an `AgentApplication`, prefer the adapter-backed
`MapFoundryActivity()` (no `RequestDelegate`), which handles the activity protocol for you.

---

## Testing Your Agent

Host your agent in an in-process ASP.NET Core test server and drive it over HTTP — no
live channel required for the accept/readiness paths:

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

Outbound **reply delivery** requires a real Bot Connector token, so tests that assert
on the delivered reply must run as live tests against a Foundry project. See
`tests/SampleEndToEndTests.cs` for the CI-safe (accept/readiness) and live
(reply-delivery) split.

### What to Test at Each Layer

| Layer | What to assert | Live? |
|-------|----------------|-------|
| Readiness | `GET /readiness` returns `200` | No |
| Accept path | `POST /activity/messages` returns `202` + `x-agent-session-id` | No |
| Handler logic | Your `AgentApplication` handler behaviour (unit-test the handler directly) | No |
| Reply delivery | The outbound reply reaches the channel | Yes |

---

## Best Practices

- **Prefer the highest tier that fits.** Use [Tier 1](#tier-1--one-line-startup) unless
  you actually need to own services (Tier 2) or the ASP.NET Core pipeline (Tier 3).
  Less hosting code means fewer ways to misconfigure the Foundry contract.
- **Leave `ActivityServerOptions` at its defaults** unless you have a specific reason to
  override. The defaults derive everything from the Foundry container environment.
- **Choose the outbound-auth model deliberately.** Keep `DigitalWorker = false` for a
  standard Teams bot; set it to `true` only for agentic/on-behalf-of scenarios.
- **Use a durable `IStorage` in production.** The default `MemoryStorage` loses turn
  state on restart and is not shared across instances.
- **Keep handlers plain M365 SDK code.** Don't reach into the library's hosting types
  from your handler — register handlers by activity type and let the library host them.
- **Split accept-path tests from reply-delivery tests.** Assert `202`/readiness in
  CI-safe tests; put reply-delivery assertions behind a live category.
- **Let error-source classification work for you.** Don't swallow exceptions in the
  hosting layer — let them propagate so the platform can attribute the fault correctly.

---

## Common Mistakes

| Mistake | Symptom | Fix |
|---------|---------|-----|
| Asserting on the reply body in a non-live test | Test sees only `202`, no reply text | Reply is delivered outbound over the channel — assert reply delivery in a **live** test. |
| Expecting a synchronous response | No reply in the HTTP response | Normal messages are acked with `202`; the reply is delivered asynchronously. |
| Using `MemoryStorage` in production | Turn state lost on restart / not shared across instances | Supply a durable `IStorage` via `options.Storage`. |
| Posting to `/api/messages` | `404 Not Found` | Use the canonical `/activity/messages` route. |
| Forgetting `app.MapFoundryActivity()` | Endpoint returns `404`; no `/readiness` | Both **register** (`AddFoundryActivity`) and **map** (`MapFoundryActivity`) are required. |
| Setting `DigitalWorker = true` for a plain Teams bot | Outbound token has the wrong audience | Keep the default (`false`) unless you need the blueprint/agentic identity. |
| Using the raw `RequestDelegate` overload for an `AgentApplication` | You have to re-implement the activity protocol yourself | Use the adapter-backed `MapFoundryActivity()` (no `RequestDelegate`) to run an agent. |
| Overriding `ConnectionConfiguration` partially | Outbound auth breaks — supplied config is used as-is | Supply the **complete** `CONNECTIONS__*` mapping, or leave it `null` to derive from the environment. |
