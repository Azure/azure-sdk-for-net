// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a single reasoning summary part. Provides methods
/// for the summary part lifecycle: added, text delta, text done, and part done events.
/// </summary>
public class ReasoningSummaryPartBuilder
{
    private readonly ResponseEventStream _stream;
    private readonly long _outputIndex;
    private readonly long _summaryIndex;
    private readonly string _itemId;
    private string? _finalText;
    private BuilderLifecycleState _lifecycleState;

    /// <summary>
    /// Initializes a new instance of <see cref="ReasoningSummaryPartBuilder"/>.
    /// </summary>
    internal ReasoningSummaryPartBuilder(ResponseEventStream stream, long outputIndex, long summaryIndex, string itemId)
    {
        _stream = stream;
        _outputIndex = outputIndex;
        _summaryIndex = summaryIndex;
        _itemId = itemId;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ReasoningSummaryPartBuilder"/> for mocking.
    /// </summary>
    protected ReasoningSummaryPartBuilder()
    {
        _stream = null!;
        _itemId = string.Empty;
    }

    /// <summary>The final text passed to <see cref="EmitTextDone"/>. Null if not yet finalized.</summary>
    public string? FinalText => _finalText;

    /// <summary>Whether this builder has completed its full lifecycle (<see cref="EmitDone"/> called).</summary>
    internal bool IsDone => _lifecycleState == BuilderLifecycleState.Done;

    /// <summary>The summary index assigned to this summary part.</summary>
    public long SummaryIndex => _summaryIndex;

    /// <summary>
    /// Produces a <c>response.reasoning_summary_part.added</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseReasoningSummaryPartAddedEvent"/> for this summary part.</returns>
    public virtual ResponseReasoningSummaryPartAddedEvent EmitAdded()
    {
        if (_lifecycleState != BuilderLifecycleState.NotStarted)
            throw new InvalidOperationException($"Cannot call EmitAdded — builder is in '{_lifecycleState}' state.");
        _lifecycleState = BuilderLifecycleState.Added;

        var part = new ResponseReasoningSummaryPartAddedEventPart(text: "");
        return new ResponseReasoningSummaryPartAddedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _summaryIndex, part);
    }

    /// <summary>
    /// Produces a <c>response.reasoning_summary_text.delta</c> event with the given text chunk.
    /// </summary>
    /// <param name="text">The text chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseReasoningSummaryTextDeltaEvent"/> with the delta.</returns>
    public virtual ResponseReasoningSummaryTextDeltaEvent EmitTextDelta(string text)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitTextDelta — builder is in '{_lifecycleState}' state.");
        if (_finalText is not null)
            throw new InvalidOperationException("Cannot emit deltas after EmitTextDone has been called.");

        return new ResponseReasoningSummaryTextDeltaEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _summaryIndex, text);
    }

    /// <summary>
    /// Produces a <c>response.reasoning_summary_text.done</c> event with the final text.
    /// </summary>
    /// <param name="finalText">The final complete text.</param>
    /// <returns>A <see cref="ResponseReasoningSummaryTextDoneEvent"/> with the final text.</returns>
    public virtual ResponseReasoningSummaryTextDoneEvent EmitTextDone(string finalText)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitTextDone — builder is in '{_lifecycleState}' state.");
        if (_finalText is not null)
            throw new InvalidOperationException("EmitTextDone has already been called.");

        _finalText = finalText;
        return new ResponseReasoningSummaryTextDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _summaryIndex, finalText);
    }

    /// <summary>
    /// Produces a <c>response.reasoning_summary_part.done</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseReasoningSummaryPartDoneEvent"/> for this summary part.</returns>
    public virtual ResponseReasoningSummaryPartDoneEvent EmitDone()
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDone — builder is in '{_lifecycleState}' state.");
        _lifecycleState = BuilderLifecycleState.Done;

        var part = new ResponseReasoningSummaryPartDoneEventPart(text: _finalText ?? string.Empty);
        return new ResponseReasoningSummaryPartDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _summaryIndex, part);
    }
}
