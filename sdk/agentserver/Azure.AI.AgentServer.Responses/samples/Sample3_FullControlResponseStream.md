# Sample 3: ResponseEventStream — Full Control

This sample introduces `ResponseEventStream`, the low-level builder that gives you full control over every SSE event in the response. Use this when you need to:
- Emit **multiple output types** (reasoning + message, function calls, etc.)
- **Set Response properties** like `Temperature` or `Instructions` before the `response.created` event
- Control **exact event ordering** and **delta granularity**

For simple text-only responses, prefer [`TextResponse`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample1_GettingStarted.md) (Samples 1–2). For advanced multi-output patterns, see [Sample 6 — Multi-Output](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample6_MultiOutput.md).

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```C# Snippet:Responses_Sample3_GreetingHandler
public class GreetingHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        // ── Configure Response properties BEFORE EmitCreated() ──
        // Any property set here will appear in the response.created event
        // and every subsequent event that carries the Response snapshot.
        stream.Response.Temperature = 0.7;
        stream.Response.MaxOutputTokens = 1024;

        // Emit the opening lifecycle events.
        yield return stream.EmitCreated();   // response.created
        yield return stream.EmitInProgress(); // response.in_progress

        // Add a message output item.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();    // response.output_item.added

        // Add text content to the message.
        var text = message.AddTextContent();
        yield return text.EmitAdded();       // response.content_part.added

        // Emit the text body — delta first, then the final "done" with full text.
        var input = request.GetInputText();
        var reply = $"Hello! You said: \"{input}\"";
        yield return text.EmitDelta(reply);  // response.output_text.delta
        yield return text.EmitDone(reply);   // response.output_text.done

        // Close the content, message, and response.
        yield return message.EmitContentDone(text);  // response.content_part.done
        yield return message.EmitDone();              // response.output_item.done
        yield return stream.EmitCompleted();          // response.completed
    }
}
```

## Start the server

```C# Snippet:Responses_Sample3_StartServer
ResponsesServer.Run<GreetingHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "greeting", "input": "Hi there!"}' \
  --no-buffer
```

## Event lifecycle

Every `ResponseEventStream` handler follows this lifecycle:

```
response.created
response.in_progress
  response.output_item.added     (per output item)
    response.content_part.added  (per content part)
    response.output_text.delta   (one or more deltas)
    response.output_text.done
    response.content_part.done
  response.output_item.done
response.completed
```

Set `stream.Response.*` properties **before** `EmitCreated()` — they are frozen into the response snapshot at that point.
