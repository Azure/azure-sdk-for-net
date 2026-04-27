// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a reasoning output item. Manages the summary part index
/// counter and provides factory methods for creating summary part scopes.
/// Child summary builders are auto-tracked so <see cref="EmitDone"/> can build
/// the final reasoning item from their accumulated state.
/// </summary>
public class OutputItemReasoningItemBuilder : OutputItemBuilder<OutputItemReasoningItem>
{
    private long _summaryIndex;
    private readonly List<ReasoningSummaryPartBuilder> _summaryBuilders = new();

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemReasoningItemBuilder"/>.
    /// </summary>
    internal OutputItemReasoningItemBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemReasoningItemBuilder"/> for mocking.
    /// </summary>
    protected OutputItemReasoningItemBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an
    /// in-progress reasoning output item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this reasoning item.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemReasoningItem(
            id: _itemId,
            summary: Array.Empty<SummaryTextContent>());
        item.Status = ItemReasoningItemStatus.InProgress;
        return EmitAdded(item);
    }

    /// <summary>
    /// Creates a reasoning summary part scope with the next summary index.
    /// The builder is auto-tracked for inclusion in <see cref="EmitDone"/>.
    /// </summary>
    /// <returns>A new <see cref="ReasoningSummaryPartBuilder"/> for the summary part.</returns>
    public virtual ReasoningSummaryPartBuilder AddSummaryPart()
    {
        var summaryIndex = _summaryIndex++;
        var builder = new ReasoningSummaryPartBuilder(_stream, _outputIndex, summaryIndex, _itemId);
        _summaryBuilders.Add(builder);
        return builder;
    }

    // ── Sub-Item Convenience Generators (S-053/S-054/S-055) ────

    /// <summary>
    /// Convenience generator that yields the complete summary part sub-item
    /// event sequence from a single string (S-053, complete-text mode per S-054).
    /// </summary>
    /// <param name="text">The complete summary text.</param>
    /// <returns>An enumerable of events: <c>reasoning_summary_part.added</c> → <c>reasoning_summary_text.delta</c> → <c>reasoning_summary_text.done</c> → <c>reasoning_summary_part.done</c>.</returns>
    public virtual IEnumerable<ResponseStreamEvent> SummaryPart(string text)
    {
        var builder = AddSummaryPart();
        yield return builder.EmitAdded();
        yield return builder.EmitTextDelta(text);
        yield return builder.EmitTextDone(text);
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete summary part sub-item
    /// event sequence from streaming chunks (S-053, streaming mode per S-054).
    /// Each chunk is emitted as a delta immediately (S-055).
    /// </summary>
    /// <param name="chunks">An async enumerable of summary text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>reasoning_summary_part.added</c> → N × <c>reasoning_summary_text.delta</c> → <c>reasoning_summary_text.done</c> → <c>reasoning_summary_part.done</c>.</returns>
    public virtual async IAsyncEnumerable<ResponseStreamEvent> SummaryPart(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddSummaryPart();
        yield return builder.EmitAdded();

        var sb = new StringBuilder();
        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            sb.Append(chunk);
            yield return builder.EmitTextDelta(chunk);
        }

        var finalText = sb.ToString();
        yield return builder.EmitTextDone(finalText);
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a
    /// completed reasoning output item. The summary list is built automatically
    /// from the tracked child summary builders.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this reasoning item.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var completedSummaries = new List<SummaryTextContent>();
        for (int i = 0; i < _summaryBuilders.Count; i++)
        {
            var builder = _summaryBuilders[i];
            if (!builder.IsDone)
            {
                throw new ResponseValidationException(
                [
                    new ValidationError($"$.summary[{i}]", "Summary part builder must complete its full lifecycle (EmitTextDone + EmitDone) before reasoning EmitDone().")
                ]);
            }

            completedSummaries.Add(new SummaryTextContent(
                text: builder.FinalText));
        }

        var item = new OutputItemReasoningItem(
            id: _itemId,
            summary: completedSummaries);
        item.Status = ItemReasoningItemStatus.Completed;
        return EmitDone(item);
    }
}
