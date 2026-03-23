# Sample 3: Conversation History

This sample shows how to use `IResponseContext.GetHistoryAsync()` to resolve prior conversation turns and build multi-turn conversational flows using `previous_response_id`.

## Implement the handler

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class ConversationHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Resolve conversation history from previous responses.
        // Returns empty list if no previous_response_id is set.
        var history = await context.GetHistoryAsync(cancellationToken);
        var inputItems = await context.GetInputItemsAsync(cancellationToken);

        var currentInput = request.GetInputText();
        var turnNumber = history.OfType<OutputItemOutputMessage>().Count() + 1;

        string reply;
        if (history.Count == 0)
        {
            reply = $"[Turn 1] No history. You said: \"{currentInput}\"";
        }
        else
        {
            var lastMessage = history.OfType<OutputItemOutputMessage>().LastOrDefault();
            var lastText = lastMessage?.Content
                .OfType<OutputMessageContentOutputTextContent>()
                .FirstOrDefault()?.Text ?? "(none)";

            reply = $"[Turn {turnNumber}] History has {history.Count} item(s). " +
                    $"Last assistant message: \"{lastText}\". " +
                    $"You said: \"{currentInput}\"";
        }

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta(reply);
        yield return text.EmitDone(reply);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

## Configure the server

```csharp
var builder = WebApplication.CreateBuilder(args);

// DefaultFetchHistoryCount controls how many prior items are resolved (default: 100).
builder.Services.AddResponsesServer(options =>
{
    options.DefaultFetchHistoryCount = 20;
});

builder.Services.AddSingleton<IResponseHandler, ConversationHandler>();

var app = builder.Build();
app.MapResponsesServer();
app.Run();
```

## Test the endpoint

### Turn 1 — initial message (no history)

```bash
curl -X POST http://localhost:5000/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "test", "input": "Hello, I am Alice."}' \
  --no-buffer
```

Extract the response `id` from the JSON response for the next turn.

### Turn 2 — chain via `previous_response_id`

```bash
curl -X POST http://localhost:5000/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "test",
    "input": "What is 2 + 2?",
    "previous_response_id": "<RESPONSE_1_ID>"
  }' --no-buffer
```

The handler sees Turn 1 history and reports the turn number and previous assistant message.
