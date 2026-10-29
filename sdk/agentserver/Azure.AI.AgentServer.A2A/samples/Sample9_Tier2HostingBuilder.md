# Sample 9: Tier 2 host builder

Compose a native A2A agent and an independent Invocations handler on the same
Core host.

## Prerequisites

Install the additional protocol library:

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

Use `CreateCard` from [getting started](Sample1_GettingStarted.md) and
`GreetingSettings` and `GreetingAgent` from
[customize the build](Sample5_CustomizeTheBuild.md).
Import `Azure.AI.AgentServer.Invocations` for the additional handler and hosting
extensions, and `Microsoft.AspNetCore.Http` for HTTP response extensions.

## Implement the independent handler

```C# Snippet:A2A_Sample9_Handler
public class StatusHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        await response.WriteAsync("Agent is ready", cancellationToken);
    }
}
```

## Compose the host

```C# Snippet:A2A_Sample9_Configure
public static void ConfigureHost(AgentHostBuilder builder)
{
    builder.Services.AddSingleton(new GreetingSettings("Composed"));
    builder.AddA2A<GreetingAgent>(CreateCard());
    builder.AddInvocations<StatusHandler>();
}
```

```C# Snippet:A2A_Sample9_Start
var builder = AgentHost.CreateBuilder();
ConfigureHost(builder);
builder.Build().Run();
```

The A2A endpoint processes native JSON-RPC at `/a2a`. The second handler processes
HTTP requests at `/invocations`; neither translates requests into the other.
Core supplies the shared host and readiness endpoint.

## Test both protocols

Send the getting-started A2A request with text `Ada`. Its native message result
contains `Composed: Ada`.

```powershell
Invoke-RestMethod -Uri "http://localhost:8088/invocations" `
    -Method Post -ContentType "text/plain" -Body "status"
```

Expected output from the independent handler: `Agent is ready`.

Configure application services before `Build`. Each protocol can be registered
only once on a builder.
