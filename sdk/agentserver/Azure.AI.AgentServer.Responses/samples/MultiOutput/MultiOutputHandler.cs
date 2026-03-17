using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

namespace MultiOutput;

/// <summary>
/// A handler that produces multiple output items: reasoning followed by a message.
/// Demonstrates sequential output indices and mixed output types.
/// </summary>
public class MultiOutputHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Output item 0: Reasoning
        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();

        var summary = reasoning.AddSummaryPart();
        yield return summary.EmitAdded();
        yield return summary.EmitTextDelta("Let me think about this...");
        yield return summary.EmitTextDone("Let me think about this...");
        yield return summary.EmitDone();
        reasoning.EmitSummaryPartDone(summary);

        yield return reasoning.EmitDone();

        // Output item 1: Message with text content
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Here is my answer.");
        yield return text.EmitDone("Here is my answer.");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
