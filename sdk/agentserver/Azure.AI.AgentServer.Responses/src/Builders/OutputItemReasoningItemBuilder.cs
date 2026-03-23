// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a reasoning output item. Manages the summary part index
/// counter and provides factory methods for creating summary part scopes.
/// </summary>
public class OutputItemReasoningItemBuilder : OutputItemBuilder<OutputItemReasoningItem>
{
    private long _summaryIndex;
    private readonly List<SummaryTextContent> _completedSummaries = new();

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
        item.Status = OutputItemReasoningItemStatus.InProgress;
        return EmitAdded(item);
    }

    /// <summary>
    /// Creates a reasoning summary part scope with the next summary index.
    /// </summary>
    /// <returns>A new <see cref="ReasoningSummaryPartBuilder"/> for the summary part.</returns>
    public virtual ReasoningSummaryPartBuilder AddSummaryPart()
    {
        var summaryIndex = _summaryIndex++;
        return new ReasoningSummaryPartBuilder(_stream, _outputIndex, summaryIndex, _itemId);
    }

    /// <summary>
    /// Records a completed summary part for inclusion in the done event.
    /// </summary>
    /// <param name="summaryPart">The summary part builder whose final text to accumulate.</param>
    public virtual void EmitSummaryPartDone(ReasoningSummaryPartBuilder summaryPart)
    {
        _completedSummaries.Add(new SummaryTextContent(
            text: summaryPart.FinalText ?? string.Empty));
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a
    /// completed reasoning output item containing the accumulated summaries.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this reasoning item.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemReasoningItem(
            id: _itemId,
            summary: _completedSummaries);
        item.Status = OutputItemReasoningItemStatus.Completed;
        return EmitDone(item);
    }
}
