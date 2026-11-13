# Sample 5: Conversation History — Study Tutor

This sample builds a study tutor agent that uses `ResponseContext.GetHistoryAsync()` to resolve prior conversation turns. The tutor references previous exchanges to give contextual follow-up answers, demonstrating multi-turn conversational flows using `previous_response_id`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```C# Snippet:Responses_Sample5_StudyTutorHandler
public class StudyTutorHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                // Resolve conversation history from previous responses.
                // Returns empty list if no previous_response_id is set.
                var history = await context.GetHistoryAsync(ct);

                var currentInput = await context.GetInputTextAsync(cancellationToken: ct);
                var turnNumber = history.OfType<OutputItemMessage>().Count() + 1;

                // In a real agent, pass the history + current question to a model.
                if (history.Count == 0)
                {
                    return $"Welcome! I'm your study tutor. You asked: \"{currentInput}\". " +
                           "Let me help you understand that topic.";
                }

                var lastMessage = history.OfType<OutputItemMessage>().LastOrDefault();
                var lastText = lastMessage?.Content
                    .OfType<MessageContentOutputTextContent>()
                    .FirstOrDefault()?.Text ?? "(none)";

                return $"[Turn {turnNumber}] Building on our previous discussion " +
                       $"(last answer: \"{lastText[..Math.Min(50, lastText.Length)]}...\"), " +
                       $"you asked: \"{currentInput}\".";
            });
    }
}
```

## Start the server

This sample uses the Tier 2 builder pattern to configure `DefaultFetchHistoryCount`:

```C# Snippet:Responses_Sample5_BuilderConfig
var builder = AgentHost.CreateBuilder();
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
