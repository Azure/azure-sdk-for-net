````markdown
# Sample 2: Streaming Text Deltas

This sample shows how to stream text token-by-token using `TextResponse`. This is the typical pattern when your handler calls an LLM that produces tokens incrementally.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```C# Snippet:Responses_Sample2_StreamingHandler
public class StreamingHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            configure: response =>
            {
                response.Temperature = 0.7;
            },
            createTextStream: GenerateTokensAsync);
    }

    private static async IAsyncEnumerable<string> GenerateTokensAsync(
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Simulate an LLM producing tokens one at a time.
        // Replace this with your actual model call.
        var tokens = new[] { "Hello", ", ", "world", "!" };
        foreach (var token in tokens)
        {
            await Task.Delay(100, ct);
            yield return token;
        }
    }
}
```

## Start the server

```C# Snippet:Responses_Sample2_StartServer
ResponsesServer.Run<StreamingHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "streaming", "input": "Tell me a story."}' \
  --no-buffer
```

Each token arrives as a separate `response.output_text.delta` SSE event, giving the client real-time streaming. The `configure` callback sets response properties (like `Temperature`) before the `response.created` event is emitted.
````
