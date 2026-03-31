# Sample 10: Streaming OpenAI Proxy — Forward to an upstream server

This sample shows how to implement a `ResponseHandler` that acts as a **streaming proxy**: it receives requests from clients, forwards them to an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet), and streams each event back as it arrives.

All input and output item types are preserved with full fidelity. The Azure Responses models and the OpenAI .NET SDK models share the same underlying JSON wire contract — OpenAI payloads are generally a subset while Azure Responses is a superset with additional item types and extensions. The built-in `.Translate().To<T>()` helper converts between them:

```csharp
// Our Item → OpenAI ResponseItem (input)
ResponseItem openAiItem = ourItem.Translate().To<ResponseItem>();

// OpenAI StreamingResponseUpdate → our ResponseStreamEvent (output)
ResponseStreamEvent ourEvent = openAiUpdate.Translate().To<ResponseStreamEvent>();
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Implement the handler

```C# Snippet:Responses_Sample10_StreamingProxyHandler
public class StreamingProxyHandler : ResponseHandler
{
    private readonly ResponsesClient _upstream;

    public StreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

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

        // Translate every input item with full fidelity. Both model
        // stacks share the same JSON wire contract, so
        // .Translate().To<T>() round-trips through JSON to convert:
        //   our Item → JSON → OpenAI ResponseItem.
        foreach (Item item in request.GetInputExpanded())
        {
            options.InputItems.Add(item.Translate().To<ResponseItem>());
        }

        // Stream from the upstream server. Each event is translated back
        // using the same pattern in reverse.
        await foreach (StreamingResponseUpdate update in
            _upstream.CreateResponseStreamingAsync(options, cancellationToken))
        {
            yield return update.Translate().To<ResponseStreamEvent>();
        }
    }
}
```

## Start the server

Register the OpenAI `ResponsesClient` as a singleton service. Set `UPSTREAM_ENDPOINT` to point at another responses server, or leave it unset to call OpenAI directly.

```C# Snippet:Responses_Sample10_StartServer
ResponsesServer.Run<StreamingProxyHandler>(configure: builder =>
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
  -d '{"model": "gpt-4o-mini", "input": "What is Azure AI Foundry?"}' \
  --no-buffer
```
