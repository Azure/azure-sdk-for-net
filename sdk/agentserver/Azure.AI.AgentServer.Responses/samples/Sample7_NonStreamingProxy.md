# Sample 7: Non-Streaming Proxy — Call upstream and build event stream

This sample shows how to implement a `ResponseHandler` that acts as a **non-streaming proxy**: it calls an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet), waits for the complete response, and then builds a standard SSE event stream for the client using `ResponseEventStream`.

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
        // Call the upstream server without streaming.
        var options = new CreateResponseOptions()
        {
            Model = request.Model,
            Instructions = request.Instructions,
        };
        options.InputItems.Add(
            ResponseItem.CreateUserMessageItem(request.GetInputText()));

        var result = await _upstream.CreateResponseAsync(options, cancellationToken);
        string answer = result.Value.GetOutputText();

        // Build a standard SSE event stream from the completed response.
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta(answer);
        yield return text.EmitDone(answer);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
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
