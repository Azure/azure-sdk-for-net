# Sample 5: Customize the build

Inject application dependencies, choose a native task store, and configure native
A2A server options.

## Define an application dependency

Use `CreateCard` from [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample1_GettingStarted.md).
This handler receives immutable greeting configuration through dependency
injection:

```C# Snippet:A2A_Sample5_Handler
public sealed record GreetingSettings(string Prefix);

public class GreetingAgent(GreetingSettings settings) : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        await new MessageResponder(eventQueue, context.ContextId).ReplyAsync(
            $"{settings.Prefix}: {context.UserText}", cancellationToken: cancellationToken);
    }
}
```

## Register dependencies and storage

Use `A2A` and `Microsoft.Extensions.DependencyInjection`:

```C# Snippet:A2A_Sample5_Configure
public static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton(new GreetingSettings("Welcome"));
    services.AddSingleton<ITaskStore, InMemoryTaskStore>();
}
```

Explicitly registering a native `ITaskStore` preserves the application's storage
selection, including when hosted. This example deliberately uses in-memory
storage and does not persist Tasks across restarts.

## Configure native server options

```C# Snippet:A2A_Sample5_Start
var builder = AgentHost.CreateBuilder();
ConfigureServices(builder.Services);
builder.AddA2A<GreetingAgent>(CreateCard(), options =>
{
    options.AutoAppendHistory = false;
});
builder.Build().Run();
```

`AutoAppendHistory = false` disables the native server's automatic appending of
continuation input messages to Task history. The greeting handler is
message-only; the option matters if the application later uses task-producing
handlers. Native options do not configure application business logic.

Send the getting-started `SendMessage` request with text `Ada`. The message
response contains `Welcome: Ada`.

Handlers and injected singleton dependencies must support concurrent requests.
Do not store per-request input in singleton instance fields.
