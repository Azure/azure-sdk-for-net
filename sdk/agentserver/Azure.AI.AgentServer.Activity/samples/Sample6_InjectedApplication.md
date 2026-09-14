# Sample 6: Injected Application

When you want to construct the Microsoft 365 Agents SDK `AgentApplication` yourself — with your own `AgentApplicationOptions`, storage, dependency injection, and extensions — build it and hand it to `ActivityServer.Run(app)`. The host serves it as-is.

```C# Snippet:Activity_Sample6_Injected
// Register handlers on your own AgentApplication as usual.
app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
});

// Host the pre-built AgentApplication as-is.
ActivityServer.Run(app, args);
```

This is the most advanced construction mode. For most agents, the default [Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample1_GettingStarted.md) path (or [Customize the Build](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample4_CustomizeTheBuild.md) for targeted overrides) is simpler — the host builds the `AgentApplication` for you and lets you register handlers inline.
