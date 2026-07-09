# Sample: Resilient Multi-turn Conversation — Steerable Durable Task

This sample demonstrates a **multi-turn conversational agent** backed by a durable steerable task. Each HTTP invocation is one turn; the `TaskId` (derived from the session id) ties them into a single chain that persists across calls and survives restarts.

## Key concepts

- **Multi-turn task**: `AddMultiTurnTask` with `steerable: true` — accepts a new input while a turn is still running.
- **Session convergence**: the same `TaskId` is reused for every turn, so the chain accumulates context.
- **DeleteAsync**: explicitly ends the chain when the conversation is over.
- **No streaming required**: the response is a simple JSON reply (though you could combine this with SSE).

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## The durable, steerable producer task

Each turn runs this producer. It persists the turn count in durable `Metadata` and, while
running, observes `ctx.PendingInputCount` so a newly-arrived (steering) message can wrap up
the in-flight turn early:

```C# Snippet:ResilientMultiturn_ProducerTask
/// <summary>
/// The durable, steerable conversation task — one execution per turn.
/// Uses TWO metadata namespaces:
/// <list type="bullet">
///   <item><c>ctx.Metadata</c> (default) — per-invocation state (status, output).</item>
///   <item><c>ctx.Metadata.Namespace("session")</c> — session-level state that persists
///         across many invocations: conversation <c>history</c> and <c>turn_count</c>.</item>
/// </list>
/// On <c>EntryMode.Recovered</c>, the handler reads persisted session history from the
/// named namespace and seamlessly continues. A message of "done" terminates and clears
/// session history for future reuse.
/// </summary>
/// <remarks>
/// The reply is produced by a <paramref name="respond"/> delegate so the same
/// durable, steerable chain works with any backend: pass a real model in
/// production, or a deterministic stub in tests. The delegate receives the full
/// conversation history (as a JSON array) and the current user message.
/// </remarks>
public static async Task<ConversationOutput> RunConversationTurnAsync(
    TaskContext<ConversationInput> ctx,
    Func<List<ConversationMessage>, string, CancellationToken, Task<string>> respond,
    CancellationToken ct)
{
    // Session-level state lives in a named namespace — logically separate from
    // per-invocation ephemeral state. Both survive crashes.
    TaskMetadata session = ctx.Metadata.Namespace("session");

    List<ConversationMessage> history;
    if (session.TryGetValue("history", out var histRaw) && histRaw is not null)
    {
        history = histRaw.ToObjectFromJson<List<ConversationMessage>>()
            ?? new List<ConversationMessage>();
    }
    else
    {
        history = new List<ConversationMessage>();
    }

    int turnCount = 0;
    if (session.TryGetValue("turn_count", out var tcRaw) && tcRaw is not null)
    {
        turnCount = tcRaw.ToObjectFromJson<int>();
    }

    // Mark default namespace as running
    ctx.Metadata["status"] = BinaryData.FromObjectAsJson("running");
    await ctx.Metadata.FlushAsync(ct);

    if (ctx.EntryMode == EntryMode.Recovered)
    {
        // On crash recovery, session history was already flushed by a prior lifetime.
        // We simply continue from where we left off.
    }

    string message = ctx.Input.Message;

    // Handle explicit session end — "done" clears session history for reuse.
    if (string.Equals(message.Trim(), "done", StringComparison.OrdinalIgnoreCase))
    {
        string summary = $"Session complete after {turnCount} turns. " +
            $"Total messages exchanged: {history.Count}.";
        session["history"] = BinaryData.FromObjectAsJson(new List<ConversationMessage>());
        session["turn_count"] = BinaryData.FromObjectAsJson(0);
        await session.FlushAsync(ct);

        var doneResult = new ConversationOutput(turnCount, summary, Finished: true);
        ctx.Metadata["status"] = BinaryData.FromObjectAsJson("completed");
        ctx.Metadata["output"] = BinaryData.FromObjectAsJson(doneResult);
        await ctx.Metadata.FlushAsync(ct);
        return doneResult;
    }

    // Process this turn
    history.Add(new ConversationMessage("user", message));
    turnCount++;

    // Simulate incremental work that a steering input can interrupt. A steering nudge
    // signals ctx.Cancellation (cooperatively) and bumps ctx.PendingInputCount, so any
    // ct-aware await throws OperationCanceledException.
    for (int step = 0; step < 10; step++)
    {
        if (ctx.PendingInputCount > 0)
        {
            // A newer message is waiting — wrap up early so the next turn runs.
            string partial = $"Turn {turnCount} (interrupted): \"{message}\"";
            history.Add(new ConversationMessage("assistant", partial));
            session["history"] = BinaryData.FromObjectAsJson(history);
            session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
            await session.FlushAsync(ct);
            return new ConversationOutput(turnCount, partial);
        }

        try
        {
            await Task.Delay(10, ct);
        }
        catch (OperationCanceledException) when (IsBareSteeringNudge(ctx))
        {
            string partial = $"Turn {turnCount} (interrupted): \"{message}\"";
            history.Add(new ConversationMessage("assistant", partial));
            session["history"] = BinaryData.FromObjectAsJson(history);
            session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
            await session.FlushAsync(ct);
            return new ConversationOutput(turnCount, partial);
        }
    }

    // Generate the reply (model call behind the injected delegate)
    string reply = await respond(history, message, ct);
    history.Add(new ConversationMessage("assistant", reply));

    // Checkpoint session state — survives crash.
    session["history"] = BinaryData.FromObjectAsJson(history);
    session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
    await session.FlushAsync(ct);

    // Persist invocation result BEFORE suspending.
    var output = new ConversationOutput(turnCount, reply);
    ctx.Metadata["status"] = BinaryData.FromObjectAsJson("completed");
    ctx.Metadata["output"] = BinaryData.FromObjectAsJson(output);
    await ctx.Metadata.FlushAsync(ct);

    return output;
}

// A bare steering nudge cancels ctx.Cancellation with no cancel cause: a newer input is
// queued but the caller did not cancel, no timeout fired, and shutdown is not in progress.
private static bool IsBareSteeringNudge(TaskContext<ConversationInput> ctx)
    => ctx.PendingInputCount > 0
       && !ctx.CancelRequested
       && !ctx.TimeoutExceeded
       && !ctx.Shutdown.IsCancellationRequested;
```

## Implement the handler

```C# Snippet:ResilientMultiturn_Handler
/// <summary>
/// A conversational multi-turn steerable agent that uses a durable task chain.
/// Each HTTP invocation maps to one turn of the chain; the TaskId (derived from
/// the session id) ties turns together across calls. Steering allows a new
/// message to interrupt the current turn.
/// </summary>
public class ResilientMultiturnHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await request.ReadFromJsonAsync<ConversationInput>(cancellationToken)
            ?? new ConversationInput("hello");

        var invoker = request.HttpContext.RequestServices
            .GetRequiredService<ITaskInvoker>();

        // Use the session id as the durable TaskId for multi-turn convergence.
        string taskId = context.SessionId;

        // StartAsync with the same TaskId reuses the chain (new turn). While a
        // turn is running, this input is queued as steering (run.IsQueued == true).
        var run = await invoker.StartAsync<ConversationInput, ConversationOutput>(
            "conversation", input,
            new RunOptions { TaskId = taskId },
            cancellationToken);

        ConversationOutput result = await run.GetResultAsync(cancellationToken);

        await response.WriteAsJsonAsync(new
        {
            invocation_id = context.InvocationId,
            session_id = context.SessionId,
            task_id = run.TaskId,
            turn = result.Turn,
            reply = result.Reply,
            finished = result.Finished,
            is_queued = run.IsQueued
        }, cancellationToken);
    }
}

/// <summary>Input for the conversation task.</summary>
public record ConversationInput(string Message);

/// <summary>Output for a single conversation turn.</summary>
public record ConversationOutput(int Turn, string Reply, bool Finished = false);

/// <summary>A single message in conversation history.</summary>
public record ConversationMessage(string Role, string Content);
```

## End the conversation

```C# Snippet:ResilientMultiturn_DeleteChain
/// <summary>
/// Demonstrates ending a multi-turn chain with DeleteAsync.
/// </summary>
public static async Task EndConversation(IMultiTurnTask multiTurn, string taskId)
{
    // End the multi-turn chain — cancels any in-flight turn and cleans up.
    await multiTurn.DeleteAsync(taskId);
}
```

## Test the endpoint

### Turn 1

```bash
curl -X POST "http://localhost:8088/invocations?agent_session_id=conv-001" \
  -H "Content-Type: application/json" \
  -d '{"Message":"What is Rust?"}'
```

### Turn 2

```bash
curl -X POST "http://localhost:8088/invocations?agent_session_id=conv-001" \
  -H "Content-Type: application/json" \
  -d '{"Message":"Compare it to Go"}'
```

### Turn 3 — Steering (interrupt an in-flight turn)

Steering happens when a new message arrives on the **same session while the previous turn
is still running**. Send the next message *without* waiting for the previous response to
complete (e.g. fire it from a second terminal/connection). The engine queues it as a
steering input; the running turn observes `ctx.PendingInputCount > 0` and wraps up early so
the steering message runs as the next turn.

```bash
# While the Turn 2 request above is still streaming, fire this concurrently:
curl -X POST "http://localhost:8088/invocations?agent_session_id=conv-001" \
  -H "Content-Type: application/json" \
  -d '{"Message":"Actually, just tell me about C#"}'
```

## Implementation pattern

This uses the **Multi-turn chain** pattern from the [Resilient Tasks guide](../../Azure.AI.AgentServer.Core/docs/tasks-guide.md). The durable `Metadata` persists conversation history across turns and restarts. Steering lets the client redirect the agent mid-turn without waiting for the current response.
