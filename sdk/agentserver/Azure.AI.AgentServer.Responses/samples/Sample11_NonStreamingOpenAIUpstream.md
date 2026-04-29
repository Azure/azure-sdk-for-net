# Sample 11: Non-Streaming Upstream Integration — Call upstream and build event stream

This sample shows how to implement a `ResponseHandler` that integrates with an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet). The handler calls the upstream without streaming, waits for the complete response, and uses the builder API to construct output items for the client.

This pattern is useful when your handler needs to inspect or transform the full response before streaming it to the client — for example, filtering output items, injecting additional context, or calling multiple upstreams.

> **Conversation ID isolation.** If you use conversation IDs (`previous_response_id`) to maintain conversation state, use a **different** conversation ID for the upstream call than the one your client uses. Both servers persist conversation history, and sharing the same ID can cause duplicate messages or state conflicts.

All item types (messages, function calls, reasoning, file search, etc.) are translated using the built-in `.Translate().To<T>()` helper:

```csharp
// Our Item → OpenAI ResponseItem (input)
options.InputItems.Add(item.Translate().To<ResponseItem>());

// OpenAI ResponseItem → our OutputItem (output)
OutputItem outputItem = upstreamItem.Translate().To<OutputItem>();
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

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Build the upstream request using the OpenAI .NET SDK.
        var options = new CreateResponseOptions()
        {
            Model = request.Model,
            Instructions = request.Instructions,
        };

        // Translate every input item with full fidelity.
        // Both model stacks share the same JSON wire contract, so
        // .Translate().To<T>() round-trips through JSON to convert.
        foreach (Item item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
        {
            options.InputItems.Add(item.Translate().To<ResponseItem>());
        }

        // Call upstream without streaming and get the complete response.
        var result = await _upstream.CreateResponseAsync(options, cancellationToken);

        // Build a standard SSE event stream, translating every output
        // item back: OpenAI ResponseItem → our OutputItem.
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        foreach (ResponseItem upstreamItem in result.Value.OutputItems)
        {
            OutputItem outputItem = upstreamItem.Translate().To<OutputItem>();

            var builder = stream.AddOutputItem<OutputItem>(upstreamItem.Id);
            yield return builder.EmitAdded(outputItem);
            yield return builder.EmitDone(outputItem);
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
        new OpenAIClientOptions
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
