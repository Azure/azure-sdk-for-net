# Sample 3: Host configuration

Choose between the Core host builder and an existing ASP.NET Core application.
Both examples use the native card and `EchoAgent` from
[getting started](Sample1_GettingStarted.md).

## Use the Core builder

```C# Snippet:A2A_Builder
var builder = AgentHost.CreateBuilder();
builder.AddA2A<EchoAgent>(CreateCard());
builder.Build().Run();
```

Before calling `Build`, use the builder to register application services,
configure tracing, or add another Agent Server protocol. The Core host owns
port configuration, readiness, telemetry, and graceful shutdown.

`AddA2A<THandler>(card, configure)` accepts native `A2AServerOptions`.
When an application already has a native request handler,
`AddA2A(card, requestHandler)` preserves that handler and its storage.

## Use an existing ASP.NET Core application

```C# Snippet:A2A_Standalone
var builder = WebApplication.CreateBuilder();
builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
var app = builder.Build();
app.MapFoundryA2A();
app.Run();
```

`AddFoundryA2A` registers Foundry hosting services and the native A2A application.
`WebApplication.MapFoundryA2A()` installs Core middleware and maps readiness,
JSON-RPC, and public Agent Card endpoints.

Your application still owns its listening address, OpenTelemetry exporters, and
shutdown configuration. The card URL must match the listening address.

If native A2A services are already registered, call the parameterless
`services.AddFoundryA2A()` to add hosting without replacing the native card,
request handler, or store.

## Map routes separately

The `IEndpointRouteBuilder.MapFoundryA2A()` overload maps only protocol routes.
Use it when your application already installs Core middleware and readiness.
Do not install duplicate readiness routes when composing the pipeline yourself.

## Ownership

Native handlers registered by type are singletons and must support concurrent
requests. Externally constructed request handlers and task stores remain
application-owned; dispose them when the application no longer needs them.
