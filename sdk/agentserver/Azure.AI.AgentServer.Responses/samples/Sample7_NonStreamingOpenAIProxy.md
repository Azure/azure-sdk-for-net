# Sample 7: Non-Streaming OpenAI Proxy — Call upstream and build event stream

This sample shows how to implement a `ResponseHandler` that acts as a **non-streaming proxy**: it calls an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet), waits for the complete response, and translates every output item back into a standard SSE event stream for the client.

All item types (messages, function calls, reasoning, file search, etc.) are preserved with full fidelity using the built-in `.Translate().To<T>()` helper:

```csharp
// Our Item → OpenAI ResponseItem (input)
options.InputItems.Add(item.Translate().To<ResponseItem>());

// OpenAI ResponseItem → our OutputItem (output)
OutputItem outputItem = upstreamItem.Translate().To<OutputItem>();
```

This pattern is useful when your handler needs to inspect or transform the full response before streaming it to the client.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Implement the handler

```C# Snippet:Responses_Sample7_NonStreamingProxyHandler
public class NonStreamingProxyHandler : ResponseHandler
{
    private readonly ResponsesClient _upstream;

    public NonStreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

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
        foreach (Item item in request.GetInputExpanded())
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

```C# Snippet:Responses_Sample7_StartServer
ResponsesServer.Run<NonStreamingProxyHandler>(configure: builder =>
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
