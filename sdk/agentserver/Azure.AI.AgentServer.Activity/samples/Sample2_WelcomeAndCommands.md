# Sample 2: Welcome & Commands

Greet members as they join a conversation, and handle keyword commands before the general message handler.

## Welcome new members

`OnConversationUpdate(ConversationUpdateEvents.MembersAdded, ...)` fires when members join. The bot itself also appears in `MembersAdded`, so skip the recipient id.

```C# Snippet:Activity_Sample2_Welcome
// Greet members as they join the conversation.
app.OnConversationUpdate(ConversationUpdateEvents.MembersAdded, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    foreach (var member in turnContext.Activity.MembersAdded ?? [])
    {
        // Skip the bot itself, which also appears in MembersAdded.
        if (member.Id != turnContext.Activity.Recipient?.Id)
        {
            await turnContext.SendActivityAsync($"Welcome, {member.Name}!", cancellationToken: cancellationToken);
        }
    }
});
```

## Handle a keyword command

Register `OnMessage("/help", ...)` for an exact keyword. Routes are evaluated in registration order, so put specific commands before the catch-all `OnActivity(ActivityTypes.Message, ...)` handler.

```C# Snippet:Activity_Sample2_Command
// Handle a keyword command before the general message handler.
app.OnMessage("/help", async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    await turnContext.SendActivityAsync("Send me any message and I'll echo it back.", cancellationToken: cancellationToken);
});

app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
});
```

## Next steps

- [Getting Started](Sample1_GettingStarted.md) — the minimal echo agent.
- [Customize the Build](Sample4_CustomizeTheBuild.md) — supply your own storage or services.
