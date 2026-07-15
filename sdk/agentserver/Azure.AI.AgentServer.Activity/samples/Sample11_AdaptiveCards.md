# Sample 11: Adaptive Cards with Submit Actions

Adaptive Cards are the primary rich-UI surface for Activity-protocol agents (Teams, Microsoft 365
Copilot, and Web Chat). This sample sends a card with `Action.Submit` buttons and handles the
button press, which arrives back as a **message activity with a `value` payload and no text**.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## Send a card and handle its submit action

An Adaptive Card is attached to a message activity with the content type
`application/vnd.microsoft.card.adaptive`. When the user taps a submit button, the channel sends a
message activity whose `Activity.Value` holds the button's `data` object:

```C# Snippet:Activity_Sample11_AdaptiveCards
const string AdaptiveCardContentType = "application/vnd.microsoft.card.adaptive";

ActivityServer.Run(
    (AgentApplication app) =>
// On a text message, reply with an Adaptive Card that has a submit action.
app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    // A card submit action arrives as a message with a `value` payload and no text.
    if (turnContext.Activity.Value is not null)
    {
        var choice = JsonSerializer.Serialize(turnContext.Activity.Value);
        await turnContext.SendActivityAsync($"You chose: {choice}", cancellationToken: cancellationToken);
        return;
    }

    var cardJson = """
    {
      "type": "AdaptiveCard",
      "version": "1.5",
      "body": [ { "type": "TextBlock", "text": "Pick one:", "weight": "Bolder" } ],
      "actions": [
        { "type": "Action.Submit", "title": "Yes", "data": { "answer": "yes" } },
        { "type": "Action.Submit", "title": "No",  "data": { "answer": "no" } }
      ]
    }
    """;

    var reply = new Microsoft.Agents.Core.Models.Activity
    {
        Type = ActivityTypes.Message,
        Attachments =
        [
            new Attachment
            {
                ContentType = AdaptiveCardContentType,
                Content = JsonSerializer.Deserialize<JsonElement>(cardJson),
            }
        ],
    };

    await turnContext.SendActivityAsync(reply, cancellationToken: cancellationToken);
}),
    args);
```

## How the round-trip works

1. The user sends any text message → the agent replies with the card.
2. The user taps **Yes** or **No** → the channel sends a message activity with
   `Activity.Value = { "answer": "yes" }` and no `Text`.
3. The agent branches on `Activity.Value` and echoes the choice.

`Attachment.Content` accepts any JSON-serializable object; here a `JsonElement` parsed from the card
JSON. You can equally build the card from a typed model or a templating library.

## Next steps

- [Invoke Activities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample12_InvokeActivities.md) — synchronous request/response (task modules, message extensions, `Action.Execute`).
- [Welcome & Commands](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample2_WelcomeAndCommands.md) — greet new members and handle keyword commands.
