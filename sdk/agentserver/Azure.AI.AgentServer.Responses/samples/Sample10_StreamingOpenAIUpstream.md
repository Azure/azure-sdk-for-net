# Sample 10: Streaming Upstream Integration — Forward to an OpenAI-compatible server

This sample shows how to integrate with an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet). The handler **owns the response lifecycle** — it constructs its own `response.created`, `response.in_progress`, and terminal events — while forwarding upstream **content events** (output items, text deltas, function-call arguments, reasoning, tool calls) as-is. Handler inputs and outputs already use the OpenAI SDK types, so no translation is needed.

> **Not a transparent proxy.** This sample showcases forwarding upstream events directly, not a production forwarding pattern. In practice you would add orchestration logic — filtering outputs, injecting items, calling multiple upstreams, or transforming content — between the upstream call and the `yield return`.

> **Conversation ID isolation.** If you use conversation IDs (`previous_response_id`) to maintain conversation state, use a **different** conversation ID for the upstream call than the one your client uses. Both servers persist conversation history, and sharing the same ID can cause duplicate messages or state conflicts.

The handler constructs its own `ResponseResult` with the local server's ID and request-scoped properties, then yields the upstream content events unchanged:

```csharp
// Input items are OpenAI ResponseItem instances — forward them directly.
options.InputItems.Add(item);

// Upstream StreamingResponseUpdate content events — yield them directly.
yield return update;
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
            StreamingEnabled = true,
        };

        // Input items are already OpenAI ResponseItem instances, so
        // they can be forwarded to the upstream as-is.
        foreach (ResponseItem item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
        {
            options.InputItems.Add(item);
        }

        // This handler owns the response lifecycle — construct
        // lifecycle events directly instead of forwarding the
        // upstream's. This gives full control over the response
        // envelope (ID, metadata, status) while the upstream only
        // contributes content.
        int seq = 0;
        var conversationId = request.GetConversationId();
        var response = new ResponseResult { Id = context.ResponseId, Model = request.Model ?? "", Status = ResponseStatus.InProgress, AgentReference = request.AgentReference, BackgroundModeEnabled = request.BackgroundModeEnabled, ConversationOptions = conversationId != null ? new ResponseConversationOptions(conversationId) : null, PreviousResponseId = request.PreviousResponseId };
        yield return new StreamingResponseCreatedUpdate { SequenceNumber = (int)(seq++), Response = response };
        yield return new StreamingResponseInProgressUpdate { SequenceNumber = (int)(seq++), Response = response };

        // Stream from the upstream. Forward content events (output
        // items, deltas, etc.) directly. Skip upstream
        // lifecycle events — we own the response envelope.
        // Track completed output items for the terminal event.
        var outputItems = new List<ResponseItem>();
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

            // Clear upstream response_id on output items so the
            // orchestrator's auto-stamp fills in this server's ID.
            if (update is StreamingResponseOutputItemAddedUpdate added)
                added.Item.ResponseId = null;
            else if (update is StreamingResponseOutputItemDoneUpdate done)
            {
                done.Item.ResponseId = null;
                outputItems.Add(done.Item);
            }

            yield return update;
        }

        // Emit terminal event — the handler decides the outcome.
        if (upstreamFailed)
        {
            response.Status = ResponseStatus.Failed;
            response.Error = new OpenAI.Responses.ResponseError { Code = ResponseErrorCode.ServerError, Message = "Upstream request failed" };
            yield return new StreamingResponseFailedUpdate { SequenceNumber = (int)(seq++), Response = response };
        }
        else
        {
            response.Status = ResponseStatus.Completed;
            foreach (var item in outputItems)
                response.OutputItems.Add(item);
            yield return new StreamingResponseCompletedUpdate { SequenceNumber = (int)(seq++), Response = response };
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
  -d '{"model": "gpt-4o-mini", "input": "What is Azure AI Foundry?"}' \
  --no-buffer
```
