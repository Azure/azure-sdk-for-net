# Sample 3: Digital Worker Outbound Auth

By default the host uses the **simple** outbound-auth model: the agent *instance* identity mints the Bot Connector token directly. The **digital worker** model uses the *blueprint* identity with a federated-identity (FMI) token exchange to obtain an agentic user token.

Select it by setting `DigitalWorker` on the options.

```C# Snippet:Activity_Sample3_DigitalWorker
// Select the digital-worker outbound-auth model: the blueprint identity performs a
// federated-identity (FMI) token exchange to obtain an agentic user token. Register
// your handlers inline; the option is applied via configureOptions.
ActivityServer.Run(
    (AgentApplication app) =>
        app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
        {
            await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
        }),
    args,
    configureOptions: options => options.DigitalWorker = true);
```

Register handlers inline on the `AgentApplication` exactly as in [Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample1_GettingStarted.md); only the outbound-auth model differs (set via `configureOptions`).

| Model | Identity source | Scope |
|---|---|---|
| Simple (default) | `FOUNDRY_AGENT_INSTANCE_CLIENT_ID` | `https://api.botframework.com/.default` |
| Digital worker | `FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID` (FMI exchange) | agentic resource |
