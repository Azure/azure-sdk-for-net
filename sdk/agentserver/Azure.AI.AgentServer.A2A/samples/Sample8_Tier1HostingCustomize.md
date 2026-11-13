# Sample 8: Tier 1 hosting customization

Configure the library-owned host without replacing the one-call server entry
point.

## Define the host configuration

Use `CreateCard` from [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample1_GettingStarted.md) and
`GreetingSettings` and `GreetingAgent` from
[customize the build](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample5_CustomizeTheBuild.md).
The health-check callback uses `Microsoft.Extensions.Diagnostics.HealthChecks`;
the tracing extension uses `OpenTelemetry.Trace`.

```C# Snippet:A2A_Sample8_Configure
public static void ConfigureHost(AgentHostBuilder builder)
{
    builder.Services.AddSingleton(new GreetingSettings("Configured"));
    builder.ConfigureShutdown(TimeSpan.FromSeconds(15));
    builder.ConfigureHealth(health => health.AddCheck(
        "application", () => HealthCheckResult.Healthy()));
    builder.ConfigureTracing(tracing => tracing.AddSource("Echo.Application"));
}
```

The configuration callback runs before the host is built. Services registered
here are available when the native agent handler is constructed.

## Start the server

```C# Snippet:A2A_Sample8_Start
A2AAgentServer.Run<GreetingAgent>(
    CreateCard(),
    configure: ConfigureHost);
```

The host provides port binding, Core middleware, readiness, telemetry, and
graceful shutdown. The sample adds application configuration, an application
health check, a 15-second shutdown timeout, and an application tracing source.

## Verify the configuration

Send the getting-started `SendMessage` request with text `Ada`; the response
contains `Configured: Ada`.

```powershell
(Invoke-WebRequest -Uri "http://localhost:8088/readiness").StatusCode
```

Expected readiness status: `200`. The application check participates in the
readiness result. Registering a tracing source does not configure a new exporter
or create spans by itself.

Use [Tier 2](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample9_Tier2HostingBuilder.md) when your application needs explicit
builder composition or more than one protocol.
