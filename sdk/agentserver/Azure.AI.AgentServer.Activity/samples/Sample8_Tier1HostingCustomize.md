# Sample 8: Tier 1 — The One-Liner

**Tier 1** is the fastest path to a running Activity agent: a single call,
`ActivityServer.Run<TAgent>()`. It creates the Core host builder, registers the Activity protocol
with your agent, and runs — wiring OpenTelemetry, health probes, and the Foundry middleware for you.
This is the Activity counterpart to `ResponsesServer.Run<THandler>()` /
`InvocationsServer.Run<THandler>()`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## The agent

Your agent is a standard Microsoft 365 Agents SDK `AgentApplication`, with its handlers registered
in the constructor so the one-liner can host it by type:

```C# Snippet:Activity_Sample8_Agent
// A standard Microsoft 365 Agents SDK agent. Its handlers are registered in the constructor,
// so the Tier 1 one-liner can host it by type.
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

## Run with one line

```C# Snippet:Activity_Sample8_OneLiner
// The fastest path to a running Activity agent — one line.
ActivityServer.Run<EchoAgent>(args);
```

## Select the outbound-auth model

Use the `configureOptions` callback to select the digital-worker model or override storage,
connections, and the connection configuration:

```C# Snippet:Activity_Sample8_SelectAuthModel
// Select the outbound-auth model (or override storage) via the options callback.
ActivityServer.Run<EchoAgent>(args, configureOptions: options =>
{
    options.DigitalWorker = true;
});
```

## Register services, configuration, and tracing

The `configure` callback exposes the underlying Core `AgentHostBuilder`, so you can register your
own services, add an OpenTelemetry source, and set a shutdown timeout:

```C# Snippet:Activity_Sample8_RegisterServicesAndTracing
// Use the configure callback for the underlying Core AgentHostBuilder: register services,
// add a custom OpenTelemetry source, and set a shutdown timeout.
ActivityServer.Run<EchoAgent>(args, configure: builder =>
{
    builder.Services.AddSingleton<IGreetingService, GreetingService>();
    builder.ConfigureTracing(tracing => tracing.AddSource("MyAgent.BusinessLogic"));
    builder.ConfigureShutdown(TimeSpan.FromSeconds(10));
});
```

## Access the underlying WebApplication

For ASP.NET Core–level customization (middleware, authentication, CORS), reach the
`WebApplicationBuilder` through the same callback:

```C# Snippet:Activity_Sample8_WebAppAccess
// Reach the ASP.NET Core WebApplicationBuilder for middleware, authentication, or CORS.
ActivityServer.Run<EchoAgent>(args, configure: builder =>
{
    builder.WebApplicationBuilder.Services.AddCors(cors =>
    {
        cors.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    });
});
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

## When to use Tier 1

Use `ActivityServer.Run<TAgent>()` when you want the simplest single-protocol experience with
optional customization. For composing the Activity protocol with other protocols on one host, see
[Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample9_Tier2HostingBuilder.md).
To add Activity endpoints to an existing ASP.NET Core app, see
[Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample10_Tier3SelfHosting.md).

> Prefer to register handlers **inline** instead of hosting by type? Use the inline
> `ActivityServer.Run(app => { app.OnActivity(...); })` overload
> — see [Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample1_GettingStarted.md).
