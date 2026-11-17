# Sample 11: Non-Streaming Upstream Integration — Call upstream and build event stream

This sample shows how to implement a `ResponseHandler` that integrates with an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet). The handler calls the upstream without streaming, waits for the complete response, and uses the builder API to construct output items for the client.

This pattern is useful when your handler needs to inspect or transform the full response before streaming it to the client — for example, filtering output items, injecting additional context, or calling multiple upstreams.

> **Conversation ID isolation.** If you use conversation IDs (`previous_response_id`) to maintain conversation state, use a **different** conversation ID for the upstream call than the one your client uses. Both servers persist conversation history, and sharing the same ID can cause duplicate messages or state conflicts.

All item types (messages, function calls, reasoning, file search, etc.) share the OpenAI SDK `ResponseItem` type, so input and output items can be forwarded without conversion:

```csharp
// Input items are OpenAI ResponseItem instances — forward them directly.
options.InputItems.Add(item);

// Upstream output items can be emitted as-is.
var builder = stream.AddOutputItem<ResponseItem>(upstreamItem.Id);
yield return builder.EmitAdded(upstreamItem);
yield return builder.EmitDone(upstreamItem);
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Implement the handler

The handler calls the upstream without streaming, then iterates over the output items and uses the generic `AddOutputItem<T>()` builder to emit `output_item.added` / `output_item.done` pairs for each. Add orchestration logic (filtering, transformation, enrichment) between the upstream call and the output loop.

```C# Snippet:Responses_Sample11_NonStreamingUpstreamHandler
public class NonStreamingUpstreamHandler : ResponseHandler
{
    private readonly ResponsesClient _upstream;

    public NonStreamingUpstreamHandler(ResponsesClient upstream) => _upstream = upstream;

    public override async IAsyncEnumerable<StreamingResponseUpdate> CreateAsync(
        CreateResponseOptions request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Build the upstream request using the OpenAI .NET SDK.
        var options = new CreateResponseOptions()
        {
            Model = request.Model,
            Instructions = request.Instructions,
        };

        // Input items are already OpenAI ResponseItem instances, so
        // they can be forwarded to the upstream as-is.
        foreach (ResponseItem item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
        {
            options.InputItems.Add(item);
        }

        // Call upstream without streaming and get the complete response.
        var result = await _upstream.CreateResponseAsync(options, cancellationToken);

        // Build a standard SSE event stream, emitting every upstream
        // output item.
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        foreach (ResponseItem upstreamItem in result.Value.OutputItems)
        {
            var builder = stream.AddOutputItem<ResponseItem>(upstreamItem.Id);
            yield return builder.EmitAdded(upstreamItem);
            yield return builder.EmitDone(upstreamItem);
        }

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```C# Snippet:Responses_Sample11_StartServer
ResponsesServer.Run<NonStreamingUpstreamHandler>(configure: builder =>
{
    builder.Services.AddSingleton(new ResponsesClient(
        new ApiKeyCredential(
            Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "your-api-key"),
        new ResponsesClientOptions
        {
            Endpoint = new Uri(
                Environment.GetEnvironmentVariable("UPSTREAM_ENDPOINT")
                    ?? "https://api.openai.com/v1")
        }));
});
```

## Test the endpoint

```bash
export OPENAI_API_KEY="sk-..."
# Optionally point to another local server:
# export UPSTREAM_ENDPOINT="http://localhost:8089"

curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "gpt-4o-mini", "input": "Summarize quantum computing in one sentence."}' \
  --no-buffer
```
