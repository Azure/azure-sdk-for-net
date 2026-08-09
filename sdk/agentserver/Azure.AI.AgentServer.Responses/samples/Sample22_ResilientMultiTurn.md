# Sample 22 — Resilient Multi-turn (serial conversation, no steering)

A self-contained multi-turn handler with no external LLM dependency. It
demonstrates the perpetual-task lifecycle: each turn completes, the task
suspends, and the next turn resumes it.

Without steering, the framework serializes turns via a conversation lock. If
turn A is executing when turn B arrives, turn B waits (it does not cancel A).

Key concepts:

- `ResilientBackground = true`, `SteerableConversations = false`.
- Conversation history via `context.GetHistoryAsync()` (framework-managed).
- Durable per-turn state via `context.ConversationChainMetadata` (turn counter).
- Crash recovery: the handler is re-invoked with the same input + history, so it
  produces the same output.

## Handler

```C# Snippet:Responses_Sample22_ResilientMultiTurnHandler
// Sample 22 — serial multi-turn (no steering). Durable per-conversation state is
// written through a MetadataNamespace on the stable ConversationChainId.
public class ResilientMultiTurnHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request, createText: async ct =>
        {
            string inputText = await context.GetInputTextAsync(cancellationToken: ct);

            // Durable per-conversation state is scoped to the stable chain id.
            ConversationChainMetadataNamespace state = context.MetadataNamespace("state");
            string chainId = context.ConversationChainId;

            int turnCount = 1;
            if (state.TryGet("turn_count", out var raw) && int.TryParse(raw, out var prior))
            {
                turnCount = prior + 1;
            }

            if (string.Equals(inputText.Trim(), "done", StringComparison.OrdinalIgnoreCase))
            {
                return $"Done! Session complete after {turnCount - 1} turns on {chainId}. Goodbye!";
            }

            // Framework-managed conversation history.
            IReadOnlyList<OutputItem> history = await context.GetHistoryAsync(ct);

            string reply =
                $"Turn {turnCount}: You said '{inputText}'. " +
                $"I have {history.Count} items of conversation context.";

            state.Set("turn_count", turnCount.ToString());
            await state.FlushAsync(ct);

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
framework-managed history, a crash mid-turn is fully recoverable with zero extra
handler work: on restart the handler is re-invoked with the identical request and
history and produces the identical reply. The `turn_count` watermark is persisted
through `ConversationChainMetadata.FlushAsync()` so it survives the crash.

> **Verified.** The published flow of this sample — a serial (non-steering)
> conversation chain that accumulates per-turn state across turns via durable
> chain metadata + framework history — is exercised end-to-end against the real
> Core-composed engine by
> `ResilienceSampleParityEndToEndTests.Sample22_ResilientMultiTurn_AccumulatesStateAcrossTurns`.
