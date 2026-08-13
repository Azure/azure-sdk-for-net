# Sample 22 — Resilient Multi-turn (serial conversation, no steering)

A self-contained multi-turn handler with no external LLM dependency. It
demonstrates the perpetual-task lifecycle: each turn completes, the task
suspends, and the next turn resumes it.

Without steering, the framework serializes turns via a conversation lock. If
turn A is executing when turn B arrives, turn B waits (it does not cancel A).

Key concepts:

- `ResilientBackground = true`, `SteerableConversations = false`.
- Conversation history via `context.GetHistoryAsync()` (framework-managed).
- Durable per-turn state via an explicit `FoundryStateStore` (turn counter and
  recovery idempotency marker).
- Crash recovery: the handler is re-invoked with the same input + history, so it
  produces the same output.

## Handler

```C# Snippet:Responses_Sample22_ResilientMultiTurnHandler
// Sample 22 — serial multi-turn (no steering). Durable per-conversation state is
// written to an explicit State Store scoped by the stable ConversationChainId.
public class ResilientMultiTurnHandler : ResponseHandler
{
    private static readonly DefaultAzureCredential s_credential = new();

    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request, createText: async ct =>
        {
            string inputText = await context.GetInputTextAsync(cancellationToken: ct);

            string chainId = context.ConversationChainId;
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
                $"responses/resilient-multiturn/{chainId}",
                s_credential,
                description: "State for the resilient multi-turn response sample",
                cancellationToken: CancellationToken.None);
            StateStoreItem? item = await store.GetItemAsync(
                "state",
                cancellationToken: CancellationToken.None);
            IDictionary<string, BinaryData> state = item?.Value
                ?? new Dictionary<string, BinaryData>(StringComparer.Ordinal);

            if (state.TryGetValue("terminated", out BinaryData? terminatedData)
                && terminatedData.ToObjectFromJson<bool>()
                && (!state.TryGetValue("last_response_id", out BinaryData? terminatedResponseData)
                    || terminatedResponseData.ToObjectFromJson<string>() != context.ResponseId))
            {
                state = new Dictionary<string, BinaryData>(StringComparer.Ordinal);
            }

            bool repeatedResponse =
                state.TryGetValue("last_response_id", out BinaryData? responseIdData)
                && responseIdData.ToObjectFromJson<string>() == context.ResponseId;
            int turnCount = repeatedResponse
                ? state.TryGetValue("turn_count", out BinaryData? existingTurnData)
                    ? existingTurnData.ToObjectFromJson<int>()
                    : 1
                : state.TryGetValue("turn_count", out BinaryData? priorTurnData)
                    ? priorTurnData.ToObjectFromJson<int>() + 1
                    : 1;

            if (string.Equals(inputText.Trim(), "done", StringComparison.OrdinalIgnoreCase))
            {
                int completedTurns;
                if (repeatedResponse
                    && state.TryGetValue("terminated", out BinaryData? repeatedTerminatedData)
                    && repeatedTerminatedData.ToObjectFromJson<bool>())
                {
                    completedTurns = state.TryGetValue("completed_turns", out BinaryData? completedData)
                        ? completedData.ToObjectFromJson<int>()
                        : 0;
                }
                else
                {
                    completedTurns = Math.Max(turnCount - 1, 0);
                    await store.SetItemAsync(
                        "state",
                        new Dictionary<string, BinaryData>
                        {
                            ["turn_count"] = BinaryData.FromObjectAsJson(completedTurns),
                            ["last_response_id"] = BinaryData.FromObjectAsJson(context.ResponseId),
                            ["terminated"] = BinaryData.FromObjectAsJson(true),
                            ["completed_turns"] = BinaryData.FromObjectAsJson(completedTurns),
                        },
                        cancellationToken: CancellationToken.None);
                }

                return $"Done! Session complete after {completedTurns} turns on {chainId}. Goodbye!";
            }

            // Framework-managed conversation history.
            IReadOnlyList<OutputItem> history = await context.GetHistoryAsync(ct);

            string reply =
                $"Turn {turnCount}: You said '{inputText}'. " +
                $"I have {history.Count} items of conversation context.";

            await store.SetItemAsync(
                "state",
                new Dictionary<string, BinaryData>
                {
                    ["turn_count"] = BinaryData.FromObjectAsJson(turnCount),
                    ["last_response_id"] = BinaryData.FromObjectAsJson(context.ResponseId),
                },
                cancellationToken: CancellationToken.None);

            return reply;
        });
    }
}
```

## Start the server

A `conversation` id routes the serial turns through the multi-turn task while
`SteerableConversations = false` keeps them serialized by the conversation lock
(a new turn waits for the in-progress one rather than superseding it).

```C# Snippet:Responses_Sample22_StartServer
// Serial multi-turn: resilient background without steering keeps turns
// serialized by the conversation lock.
AgentHost.CreateBuilder()
    .AddResponses<ResilientMultiTurnHandler>(o =>
    {
        o.ResilientBackground = true;
        o.SteerableConversations = false;
    })
    .Build()
    .Run();
```

## Try it

```bash
# Turn 1
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "chat", "input": "My name is Alice", "store": true, "background": true, "conversation": "chat-1"}'

# Turn 2 (reference previous for conversation context)
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "chat", "input": "What is my name?", "store": true, "background": true, "conversation": "chat-1", "previous_response_id": "<id>"}'

# End conversation
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "chat", "input": "done", "store": true, "background": true, "conversation": "chat-1", "previous_response_id": "<id>"}'
```

## Recovery behavior

Because the reply is a deterministic function of the input text and the
framework-managed history, a crash mid-turn is fully recoverable: on restart the
handler is re-invoked with the identical request and history, and the State Store's
`last_response_id` prevents the recovered attempt from incrementing the turn count
twice.

> **Verified.** The published flow of this sample — a serial (non-steering)
> conversation chain that accumulates per-turn state across turns via an explicit
> State Store + framework history — is exercised end-to-end against the real
> Core-composed engine by
> `ResilienceSampleParityEndToEndTests.Sample22_ResilientMultiTurn_AccumulatesStateAcrossTurns`.
