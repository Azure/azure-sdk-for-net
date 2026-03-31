# Sample 2: Configuration — Health, Tracing, Shutdown, and Escape Hatches

This sample shows how to customize the `AgentHostBuilder` with health checks, tracing, shutdown timeout, and direct access to the underlying `WebApplicationBuilder`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
```

## Configure tracing and shutdown

```C# Snippet:Core_Sample2_TracingAndShutdown
var builder = AgentHost.CreateBuilder();

// Add a custom OpenTelemetry tracing source.
builder.ConfigureTracing(tracing =>
{
    tracing.AddSource("MyAgent.BusinessLogic");
});

// Set a custom shutdown timeout (default is 30s).
builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

// Register a protocol endpoint.
builder.RegisterProtocol("MyProtocol", endpoints =>
{
    endpoints.MapGet("/ping", () => "pong");
});

var app = builder.Build();
app.Run();
```

## Add custom health checks

```C# Snippet:Core_Sample2_HealthChecks
var builder = AgentHost.CreateBuilder();

// Add a custom health check alongside the default liveness probe.
builder.ConfigureHealth(health =>
{
    health.AddCheck("database", () =>
        Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("DB reachable"));
});

builder.RegisterProtocol("MyProtocol", endpoints =>
{
    endpoints.MapGet("/ping", () => "pong");
});

var app = builder.Build();
app.Run();
```

## Access the underlying WebApplicationBuilder

For advanced scenarios, use `builder.WebApplicationBuilder` to configure middleware,
authentication, or other ASP.NET Core features directly:

```C# Snippet:Core_Sample2_EscapeHatch
var builder = AgentHost.CreateBuilder();

// Access the underlying WebApplicationBuilder for CORS, auth, etc.
builder.WebApplicationBuilder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register services on the builder's DI container.
builder.Services.AddSingleton<MyService>();

// Read configuration values.
var setting = builder.Configuration["MySetting"];

builder.RegisterProtocol("MyProtocol", endpoints =>
{
    endpoints.MapGet("/ping", () => $"pong: {setting}");
});

var app = builder.Build();
app.Run();
```

## Configuration summary

| Method | Purpose |
|--------|---------|
| `ConfigureTracing(...)` | Add custom OpenTelemetry trace sources |
| `ConfigureHealth(...)` | Add custom health checks alongside `/readiness` |
| `ConfigureShutdown(...)` | Override the 30-second graceful shutdown timeout |
| `Configure(...)` | Set `AgentHostOptions` (shutdown timeout, identity) |
| `WebApplicationBuilder` | Escape hatch for CORS, auth, middleware |
| `Services` | Escape hatch for the DI `IServiceCollection` |
| `Configuration` | Access `IConfiguration` for appsettings, env vars |

## Next steps

- [Responses samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) — protocol-level samples including Tier 1/2/3 hosting
- [Invocations samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples) — protocol-level samples including Tier 1/2/3 hosting
