# Sample 12: Invoke Activities (Task Modules, Message Extensions)

Unlike message activities (which are acknowledged asynchronously), **invoke activities** are
synchronous request/response. They power Teams message extensions, task modules, and Adaptive Card
`Action.Execute`. The agent replies with an `invokeResponse` activity carrying an HTTP-style status
and body.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Activity --prerelease
```

## Handle an invoke and return a response

Register a handler for `ActivityTypes.Invoke`. The `Activity.Name` tells you which invoke it is
(for example `composeExtension/query` or `task/fetch`). Reply with an activity of type
`invokeResponse` whose `Value` is an `InvokeResponse`:

```C# Snippet:Activity_Sample12_Invoke
ActivityServer.Run(
    (AgentApplication app) =>
// Invoke activities are synchronous request/response (e.g. Teams message extensions,
// task modules, adaptive card Action.Execute). Reply with an "invokeResponse" activity
// carrying an InvokeResponse (HTTP-style status + body).
app.OnActivity(ActivityTypes.Invoke, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
{
    var name = turnContext.Activity.Name; // e.g. "composeExtension/query", "task/fetch"

    var response = new Microsoft.Agents.Core.Models.Activity
    {
        Type = "invokeResponse",
        Value = new InvokeResponse
        {
            Status = 200,
            Body = new { message = $"Handled invoke: {name}" },
        },
    };

    await turnContext.SendActivityAsync(response, cancellationToken: cancellationToken);
}),
    args);
```

## Message flow

1. The channel POSTs an **invoke** activity (e.g. the user opens a task module).
2. The agent handles it and sends an `invokeResponse` with `Status = 200` and a `Body`.
3. The channel returns the body to the client synchronously (the invoke's HTTP response), rather
   than delivering it asynchronously like a normal message.

The `Body` is any JSON-serializable object shaped to the specific invoke contract (a task module
response, a message-extension result, an `Action.Execute` card, and so on).

## Next steps

- [Adaptive Cards](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample11_AdaptiveCards.md) — send cards and handle submit actions.
- [Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample1_GettingStarted.md) — the echo agent.
