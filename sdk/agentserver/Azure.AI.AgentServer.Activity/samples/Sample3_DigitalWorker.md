# Sample 3: Digital Worker Outbound Auth

By default the host uses the **simple** outbound-auth model: the agent *instance* identity mints the Bot Connector token directly. The **digital worker** model uses the *blueprint* identity with a federated-identity (FMI) token exchange to obtain an agentic user token.

Select it by setting `DigitalWorker` on the options.

```C# Snippet:Activity_Sample3_DigitalWorker
// Select the digital-worker outbound-auth model: the blueprint identity performs a
// federated-identity (FMI) token exchange to obtain an agentic user token.
var host = ActivityServer.Create(options =>
{
    options.DigitalWorker = true;
});

host.Run(args);
```

Register handlers on `host.AgentApp` exactly as in [Getting Started](Sample1_GettingStarted.md); only the outbound-auth model differs.

| Model | Identity source | Scope |
|---|---|---|
| Simple (default) | `FOUNDRY_AGENT_INSTANCE_CLIENT_ID` | `https://api.botframework.com/.default` |
| Digital worker | `FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID` (FMI exchange) | agentic resource |
