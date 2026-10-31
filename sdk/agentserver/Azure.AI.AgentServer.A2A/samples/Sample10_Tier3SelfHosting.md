# Sample 10: Tier 3 self-hosting

Add A2A endpoints to an application-owned ASP.NET Core host.

## Register and map the application

Use `CreateCard` and `EchoAgent` from
[getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample1_GettingStarted.md). Import
`Microsoft.AspNetCore.Builder` and `Microsoft.Extensions.DependencyInjection`.

```C# Snippet:A2A_Sample10_Start
var builder = WebApplication.CreateBuilder();
builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
var app = builder.Build();
app.MapGet("/", () => "My application");
app.MapFoundryA2A();
app.Run();
```

`AddFoundryA2A<THandler>` registers the native application and Foundry hosting
services. `WebApplication.MapFoundryA2A()` installs Core middleware and maps
the protocol endpoints and readiness. It does not configure the listening
address, telemetry exporters, or shutdown settings for the application.

If the application is not listening on port 8088, update both its address
configuration and the Agent Card URL.

## Own the middleware pipeline

Use the route-builder overload when your application already composes Core
middleware and readiness. Import `Microsoft.AspNetCore.Routing`:

```C# Snippet:A2A_Sample10_Routes
var builder = WebApplication.CreateBuilder();
builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
var app = builder.Build();
app.UseAgentServerCore();
app.MapHealthChecks("/readiness");
((IEndpointRouteBuilder)app).MapFoundryA2A();
app.Run();
```

Choose one mapping approach; do not map readiness or protocol routes twice.
`UseAgentServerCore()` must execute before the A2A endpoint so the request-scoped
Foundry context is available to the handler.

## Verify coexistence

With the first configuration:

```powershell
Invoke-RestMethod -Uri "http://localhost:8088/"
(Invoke-WebRequest -Uri "http://localhost:8088/readiness").StatusCode
```

Expected output is `My application` and `200`. Send the getting-started
JSON-RPC request to `/a2a` to receive `Echo: Hello, agent!`.

Both pipeline configurations have HTTP tests. The route-only configuration
intentionally omits the sample's `/` application route.
