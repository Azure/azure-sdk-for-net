# Sample 3: ResponseEventStream — Beyond TextResponse

When your handler needs to emit function calls, reasoning items, multiple outputs, or set custom Response properties, step up from `TextResponse` to `ResponseEventStream`. Start with **convenience generators** — they handle the event lifecycle for you. Drop down to **builders** only when you need fine-grained control over individual events.

For simple text-only responses, prefer [`TextResponse`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample1_GettingStarted.md) (Samples 1–2). For advanced multi-output patterns, see [Sample 6 — Multi-Output](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample6_MultiOutput.md).

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use `OutputItemMessage()` to emit a complete text message in one call. The convenience generator handles all the inner events (`output_item.added`, `content_part.added`, deltas, `content_part.done`, `output_item.done`) for you:

```C# Snippet:Responses_Sample3_GreetingHandlerConvenience
public class GreetingHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        // Configure Response properties BEFORE EmitCreated().
        stream.Response.Temperature = 0.7;
        stream.Response.MaxOutputTokens = 1024;

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Emit a complete text message in one call.
        var input = request.GetInputText();
        foreach (var evt in stream.OutputItemMessage($"Hello! You said: \"{input}\""))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## With streaming deltas

When your handler calls an LLM that produces tokens incrementally, pass an `IAsyncEnumerable<string>` to `OutputItemMessage()`. Each chunk becomes a separate `response.output_text.delta` SSE event — the client sees tokens in real time:

```C# Snippet:Responses_Sample3_StreamingGreetingHandler
public class StreamingGreetingHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Stream tokens as they arrive — each chunk becomes a delta event.
        await foreach (var evt in stream.OutputItemMessage(
            GenerateTokensAsync(request.GetInputText(), cancellationToken),
            cancellationToken))
        {
            yield return evt;
        }

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<string> GenerateTokensAsync(
        string input,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Replace with your actual LLM call.
        var tokens = new[] { "Hello! ", "You ", "said: ", $"\"{input}\"" };
        foreach (var token in tokens)
        {
            await Task.Delay(100, ct);
            yield return token;
        }
    }
}
```

## With full event control

When you need to interleave non-event work between individual delta/done calls within a content part, or set custom properties on the output item before `EmitAdded()`, drop down to the builder API. Each `Add*` returns a builder; each `Emit*` call produces one SSE event. (For multiple content parts such as text + refusal, you can stay at the convenience level — see `OutputItemMessageBuilder.TextContent()` and `RefusalContent()`.)

```C# Snippet:Responses_Sample3_GreetingHandler
public class GreetingHandlerFullControl : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

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

All three versions produce the same SSE event sequence. The convenience generators handle the inner events automatically:

```
response.created
response.in_progress
  response.output_item.added     ─┐
    response.content_part.added   │
    response.output_text.delta    ├─ OutputItemMessage() handles these
    response.output_text.done     │
    response.content_part.done    │
  response.output_item.done      ─┘
response.completed
```

Set `stream.Response.*` properties **before** `EmitCreated()` — they are frozen into the response snapshot at that point.
