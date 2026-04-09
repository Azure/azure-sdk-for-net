# Sample 10: Streaming Upstream Integration — Forward to an OpenAI-compatible server

This sample shows how to integrate with an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet). The handler **owns the response lifecycle** — it constructs its own `response.created`, `response.in_progress`, and terminal events — while translating upstream **content events** (output items, text deltas, function-call arguments, reasoning, tool calls) via `.Translate().To<T>()`. Both model stacks share the same JSON wire contract, so content events round-trip with full fidelity.

> **Not a transparent proxy.** This sample showcases type compatibility between the two model stacks, not a production forwarding pattern. In practice you would add orchestration logic — filtering outputs, injecting items, calling multiple upstreams, or transforming content — between the upstream call and the `yield return`.

> **Conversation ID isolation.** If you use conversation IDs (`previous_response_id`) to maintain conversation state, use a **different** conversation ID for the upstream call than the one your client uses. Both servers persist conversation history, and sharing the same ID can cause duplicate messages or state conflicts.

The handler constructs its own `ResponseObject` with the local server's ID and request-scoped properties, then uses `.Translate().To<T>()` only for content events from the upstream:

```csharp
// Our Item → OpenAI ResponseItem (input)
ResponseItem openAiItem = ourItem.Translate().To<ResponseItem>();

// OpenAI StreamingResponseUpdate → our ResponseStreamEvent (content only)
ResponseStreamEvent evt = update.Translate().To<ResponseStreamEvent>();
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Implement the handler

```C# Snippet:Responses_Sample10_StreamingUpstreamHandler
public class StreamingUpstreamHandler : ResponseHandler
{
    private readonly ResponsesClient _upstream;

    public StreamingUpstreamHandler(ResponsesClient upstream) => _upstream = upstream;

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
            StreamingEnabled = true,
        };

        // Translate every input item. Both model stacks share the
        // same JSON wire contract, so .Translate().To<T>() round-trips
        // through JSON: our Item → JSON → OpenAI ResponseItem.
        foreach (Item item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
        {
            options.InputItems.Add(item.Translate().To<ResponseItem>());
        }

        // This handler owns the response lifecycle — construct
        // lifecycle events directly instead of forwarding the
        // upstream's. This gives full control over the response
        // envelope (ID, metadata, status) while the upstream only
        // contributes content.
        int seq = 0;
        var conversationId = request.GetConversationId();
        var response = new ResponseObject(context.ResponseId, request.Model ?? "")
        {
            Status = Models.ResponseStatus.InProgress,
            Metadata = request.Metadata!,
            AgentReference = request.AgentReference,
            Background = request.Background,
            Conversation = conversationId != null
                ? new ConversationReference(conversationId) : null,
            PreviousResponseId = request.PreviousResponseId,
        };
        yield return new ResponseCreatedEvent(seq++, response);
        yield return new ResponseInProgressEvent(seq++, response);

        // Stream from the upstream. Translate content events (output
        // items, deltas, etc.) and yield them directly. Skip upstream
        // lifecycle events — we own the response envelope.
        // Track completed output items for the terminal event.
        var outputItems = new List<OutputItem>();
        bool upstreamFailed = false;

        await foreach (StreamingResponseUpdate update in
            _upstream.CreateResponseStreamingAsync(options, cancellationToken))
        {
            // Skip lifecycle events — we own the response envelope.
            if (update is StreamingResponseCreatedUpdate
                or StreamingResponseInProgressUpdate)
            {
                continue;
            }

            if (update is StreamingResponseCompletedUpdate)
            {
                break;
            }

            if (update is StreamingResponseFailedUpdate)
            {
                upstreamFailed = true;
                break;
            }

            // Translate content events via JSON round-trip.
            ResponseStreamEvent evt = update.Translate().To<ResponseStreamEvent>();

            // Clear upstream response_id on output items so the
            // orchestrator's auto-stamp fills in this server's ID.
            if (evt is ResponseOutputItemAddedEvent added)
                added.Item.ResponseId = null;
            else if (evt is ResponseOutputItemDoneEvent done)
            {
                done.Item.ResponseId = null;
                outputItems.Add(done.Item);
            }

            yield return evt;
        }

        // Emit terminal event — the handler decides the outcome.
        if (upstreamFailed)
        {
            response.Status = Models.ResponseStatus.Failed;
            response.Error = new ResponseErrorInfo(
                Models.ResponseErrorCode.ServerError, "Upstream request failed");
            yield return new ResponseFailedEvent(seq++, response);
        }
        else
        {
            response.Status = Models.ResponseStatus.Completed;
            foreach (var item in outputItems)
                response.Output.Add(item);
            yield return new ResponseCompletedEvent(seq++, response);
        }
    }
}
```

## Start the server

Register the OpenAI `ResponsesClient` as a singleton service. Set `UPSTREAM_ENDPOINT` to point at another responses server, or leave it unset to call OpenAI directly.

```C# Snippet:Responses_Sample10_StartServer
ResponsesServer.Run<StreamingUpstreamHandler>(configure: builder =>
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
