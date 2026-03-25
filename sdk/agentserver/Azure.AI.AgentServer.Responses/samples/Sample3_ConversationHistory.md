# Sample 3: Conversation History — Study Tutor

This sample builds a study tutor agent that uses `IResponseContext.GetHistoryAsync()` to resolve prior conversation turns. The tutor references previous exchanges to give contextual follow-up answers, demonstrating multi-turn conversational flows using `previous_response_id`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class StudyTutorHandler : IResponseHandler
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

        var currentInput = request.GetInputText();
        var turnNumber = history.OfType<OutputItemOutputMessage>().Count() + 1;

        // In a real agent, pass the history + current question to a model.
        string reply;
        if (history.Count == 0)
        {
            reply = $"Welcome! I'm your study tutor. You asked: \"{currentInput}\". " +
                    "Let me help you understand that topic.";
        }
        else
        {
            var lastMessage = history.OfType<OutputItemOutputMessage>().LastOrDefault();
            var lastText = lastMessage?.Content
                .OfType<OutputMessageContentOutputTextContent>()
                .FirstOrDefault()?.Text ?? "(none)";

            reply = $"[Turn {turnNumber}] Building on our previous discussion " +
                    $"(last answer: \"{lastText[..Math.Min(50, lastText.Length)]}...\"), " +
                    $"you asked: \"{currentInput}\".";
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

## Start the server

This sample uses the Tier 2 builder pattern to configure `DefaultFetchHistoryCount`:

```csharp
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Responses;

var builder = AgentServer.CreateBuilder(args);
builder.AddResponses<StudyTutorHandler>(options =>
{
    options.DefaultFetchHistoryCount = 20;
});
var app = builder.Build();
app.Run();
```

## Test the endpoint

### Turn 1 — initial message (no history)

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "tutor", "input": "Explain photosynthesis."}' \
  --no-buffer
```

Extract the response `id` from the JSON response for the next turn.

### Turn 2 — chain via `previous_response_id`

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "tutor",
    "input": "What role does chlorophyll play in that process?",
    "previous_response_id": "<RESPONSE_1_ID>"
  }' --no-buffer
```

The tutor sees Turn 1 history and builds on the previous answer about photosynthesis.
