# Sample 5: Customize the build

Inject application dependencies and configure native A2A server options.

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

## Register dependencies

Use `A2A` and `Microsoft.Extensions.DependencyInjection`:

```C# Snippet:A2A_Sample5_Configure
public static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton(new GreetingSettings("Welcome"));
}
```

Native A2A provides an in-memory task store by default, so this sample does not
register one. To keep Tasks across restarts, register your own `ITaskStore`; see
[task persistence](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample11_TaskPersistence.md).

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
