# Sample 1: Getting Started — Echo Agent

The simplest activity-protocol agent: build the host, register a message handler on the Microsoft 365 Agents SDK `AgentApplication` that the host exposes, and run.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## Implement the agent

`ActivityServer.Run(app => ...)` initializes the Microsoft 365 Agents SDK stack from the environment and hands you the built `AgentApplication` to register handlers on inline (no agent class required) with `OnActivity(...)`, `OnConversationUpdate(...)`, `OnMessage(...)`, and friends — the full M365 handler surface.

```C# Snippet:Activity_Sample1_EchoAgent
// Build the host (initializes the Microsoft 365 Agents SDK stack from the environment)
// and register handlers inline on the AgentApplication — no agent class required.
ActivityServer.Run(
    (AgentApplication app) =>
    {
        // Echo the user's message back.
        app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
        {
            var userText = turnContext.Activity.Text ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(userText))
            {
                await turnContext.SendActivityAsync($"Echo: {userText}", cancellationToken: cancellationToken);
            }
        });
    },
    args);
```

The host serves the activity endpoint at `POST /activity/messages` (and the equivalent `POST /api/messages`), along with health probes and OpenTelemetry.

## Next steps

- [Welcome & Commands](Sample2_WelcomeAndCommands.md) — greet new members and handle keyword commands.
- [Digital Worker](Sample3_DigitalWorker.md) — the blueprint + FMI outbound-auth model.
