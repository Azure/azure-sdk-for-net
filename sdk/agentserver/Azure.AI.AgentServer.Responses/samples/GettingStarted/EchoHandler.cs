using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

namespace GettingStarted;

/// <summary>
/// A simple handler that echoes the input text back as a response.
/// </summary>
public class EchoHandler : IResponseHandler
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

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Hello from the echo handler!");
        yield return text.EmitDone("Hello from the echo handler!");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
