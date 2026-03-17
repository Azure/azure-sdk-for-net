using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

namespace ConversationHistory;

/// <summary>
/// A conversational handler that uses <see cref="IResponseContext.GetHistoryAsync"/>
/// to retrieve prior conversation turns and include them in the response.
///
/// Demonstrates:
/// - Using <c>previous_response_id</c> to chain responses into a conversation
/// - Calling <c>context.GetHistoryAsync()</c> to resolve history items
/// - Extracting text from history <see cref="OutputItemOutputMessage"/> items
/// - Configuring <c>DefaultFetchHistoryCount</c> to control history depth
/// </summary>
public class ConversationHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Resolve conversation history from previous responses.
        // This calls the provider's GetHistoryItemIdsAsync → GetItemsAsync pipeline.
        // Returns empty list if no previous_response_id or conversation context.
        var history = await context.GetHistoryAsync(cancellationToken);

        // Resolve the current request's input items.
        var inputItems = await context.GetInputItemsAsync(cancellationToken);

        // Build a reply that summarises the conversation so far.
        var currentInput = request.GetInputText();
        var reply = BuildReply(currentInput, history, inputItems);

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta(reply);
        yield return text.EmitDone(reply);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Builds a reply string summarising the conversation history and current input.
    /// </summary>
    private static string BuildReply(
        string currentInput,
        IReadOnlyList<OutputItem> history,
        IReadOnlyList<OutputItem> inputItems)
    {
        if (history.Count == 0)
        {
            return $"[Turn 1] No history. You said: \"{currentInput}\"";
        }

        // Count text messages in history to determine the turn number.
        var historyMessages = history
            .OfType<OutputItemOutputMessage>()
            .ToList();

        var turnNumber = historyMessages.Count + 1;

        // Extract text from the most recent history message.
        var lastMessage = historyMessages.LastOrDefault();
        var lastText = ExtractText(lastMessage);

        return $"[Turn {turnNumber}] History has {history.Count} item(s). " +
               $"Last assistant message: \"{lastText}\". " +
               $"You said: \"{currentInput}\"";
    }

    /// <summary>
    /// Extracts the first text content from an <see cref="OutputItemOutputMessage"/>.
    /// </summary>
    private static string ExtractText(OutputItemOutputMessage? message)
    {
        if (message is null)
        {
            return "(none)";
        }

        var textContent = message.Content
            .OfType<OutputMessageContentOutputTextContent>()
            .FirstOrDefault();

        return textContent?.Text ?? "(no text)";
    }
}
