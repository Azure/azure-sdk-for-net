# Sample 7: Native A2A hosting

Add Foundry hosting to an existing native ASP.NET Core A2A application.

## Keep native service registration

Use `CreateCard` and `EchoAgent` from
[getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample1_GettingStarted.md), with `A2A.AspNetCore` and
`Microsoft.Extensions.DependencyInjection`:

```C# Snippet:A2A_Sample7_Registration
public static void RegisterNativeAgent(IServiceCollection services, AgentCard card)
{
    services.AddSingleton<ITaskStore, InMemoryTaskStore>();
    services.AddA2AAgent<EchoAgent>(card);
}
```

An application with existing native registrations can keep them unchanged.
Do not register a second request handler just to add Foundry hosting.

## Add Foundry hosting and endpoints

```C# Snippet:A2A_Sample7_Start
var builder = WebApplication.CreateBuilder();
RegisterNativeAgent(builder.Services, CreateCard());
builder.Services.AddFoundryA2A();

var app = builder.Build();
app.MapFoundryA2A();
app.Run();
```

The parameterless `AddFoundryA2A()` adds hosting services without replacing the
native card, handler, or store. The existing native storage choice remains
in effect both locally and when hosted.

Replace the application's native endpoint mapping with `MapFoundryA2A()` for
the Foundry container routes. Do not map both implementations to the same URL.
This maps `/a2a`, `/a2a/.well-known/agent-card.json`, and `/readiness`.

## Verify the application

Use the JSON-RPC request from the getting-started sample. The response remains
a native message containing `Echo: Hello, agent!`. The card retains the native
identity, skills, media types, and interface configuration.

The application still owns its listening address, telemetry exporters, and
shutdown configuration. For a complete application-owned pipeline, see
[Tier 3 self-hosting](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample10_Tier3SelfHosting.md).
