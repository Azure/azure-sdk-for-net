# Sample 6: Multi-Output — Math Problem Solver with Reasoning

This sample builds a math problem solver that shows its work. The agent emits a **reasoning** item (the thought process) followed by a **message** item (the final answer). This demonstrates streaming multiple output types in a single response — first using convenience generators, then with full builder control.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use `OutputItemReasoningItem()` and `OutputItemMessage()` to emit complete output items with one call each. The convenience generators handle all the inner content events automatically:

```C# Snippet:Responses_Sample6_MathSolverHandlerConvenience
public class MathSolverHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);
        var question = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Output item 0: Reasoning — show the thought process.
        var thought = $"The user asked: \"{question}\". " +
                      "I need to identify the mathematical operation, " +
                      "compute the result, and explain the steps.";
        foreach (var evt in stream.OutputItemReasoningItem(thought))
            yield return evt;

        // Output item 1: Message — the final answer.
        var answer = "The answer is 42. Here's how: " +
                     "6 × 7 = 42. The multiplication of 6 and 7 gives 42.";
        foreach (var evt in stream.OutputItemMessage(answer))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## With full event control

When you need multiple summary parts in a single reasoning item, set custom properties on output items before `EmitAdded()`, or interleave non-event work between builder calls, use the builder API:

```C# Snippet:Responses_Sample6_MathSolverHandler
public class MathSolverHandlerFullControl : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);
        var question = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Output item 0: Reasoning — show the thought process.
        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();

        var summary = reasoning.AddSummaryPart();
        yield return summary.EmitAdded();

        // In a real agent, this would be the model's chain-of-thought.
        var thought = $"The user asked: \"{question}\". " +
                      "I need to identify the mathematical operation, " +
                      "compute the result, and explain the steps.";
        yield return summary.EmitTextDelta(thought);
        yield return summary.EmitTextDone(thought);
        yield return summary.EmitDone();
        reasoning.EmitSummaryPartDone(summary);

        yield return reasoning.EmitDone();

        // Output item 1: Message — the final answer.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        var answer = "The answer is 42. Here's how: " +
                     "6 × 7 = 42. The multiplication of 6 and 7 gives 42.";
        yield return text.EmitDelta(answer);
        yield return text.EmitDone(answer);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```C# Snippet:Responses_Sample6_StartServer
ResponsesServer.Run<MathSolverHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "math", "input": "What is 6 times 7?"}' \
  --no-buffer
```

The SSE stream will contain events for two output items in sequence:
1. A **reasoning** item (output index 0) — the agent’s thought process
2. A **message** item (output index 1) — the final answer with explanation
