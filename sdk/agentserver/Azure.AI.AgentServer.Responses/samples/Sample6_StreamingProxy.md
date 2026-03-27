# Sample 6: Streaming Proxy — Forward to an upstream server

This sample shows how to implement a `ResponseHandler` that acts as a **streaming proxy**: it receives requests from clients, forwards them to an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet), and streams each event back as it arrives.

Because both model stacks are generated from TypeSpec and share the same JSON wire format, translating between them is a one-liner using `ModelReaderWriter`:

```csharp
// OpenAI SDK event → our ResponseStreamEvent
ResponseStreamEvent ourEvent = ModelReaderWriter.Read<ResponseStreamEvent>(
    ModelReaderWriter.Write(openAiUpdate))!;
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Implement the handler

```C# Snippet:Responses_Sample6_StreamingProxyHandler
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
        options.InputItems.Add(
            ResponseItem.CreateUserMessageItem(request.GetInputText()));

        // Stream from the upstream server. Both model stacks are generated
        // from TypeSpec and share the same JSON wire format, so translating
        // between them is a one-liner: serialize → deserialize as our type.
        await foreach (StreamingResponseUpdate update in
            _upstream.CreateResponseStreamingAsync(options, cancellationToken))
        {
            yield return ModelReaderWriter.Read<ResponseStreamEvent>(
                ModelReaderWriter.Write(update))!;
        }
    }
}
```

## Start the server

Register the OpenAI `ResponsesClient` as a singleton service. Set `UPSTREAM_ENDPOINT` to point at another responses server, or leave it unset to call OpenAI directly.

```C# Snippet:Responses_Sample6_StartServer
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
