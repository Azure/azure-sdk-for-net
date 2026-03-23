# Sample 4: Multi-Output Handling

This sample shows how to produce multiple output items in a single response — a reasoning item followed by a text message. Demonstrates sequential output indices and mixed output types.

## Implement the handler

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class MultiOutputHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Output item 0: Reasoning
        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();

        var summary = reasoning.AddSummaryPart();
        yield return summary.EmitAdded();
        yield return summary.EmitTextDelta("Let me think about this...");
        yield return summary.EmitTextDone("Let me think about this...");
        yield return summary.EmitDone();
        reasoning.EmitSummaryPartDone(summary);

        yield return reasoning.EmitDone();

        // Output item 1: Message with text content
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Here is my answer.");
        yield return text.EmitDone("Here is my answer.");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

## Configure the server

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponsesServer();
builder.Services.AddSingleton<IResponseHandler, MultiOutputHandler>();

var app = builder.Build();
app.MapResponsesServer();
app.Run();
```

## Test the endpoint

```bash
curl -X POST http://localhost:5000/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "test", "stream": true}' \
  --no-buffer
```

The SSE stream will contain events for two output items in sequence:
1. A **reasoning** item (output index 0) with a summary part
2. A **message** item (output index 1) with text content

In non-streaming mode, the response JSON includes both items in the `output` array.
