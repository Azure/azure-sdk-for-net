// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a refusal content part within a message. Owns its full
/// lifecycle: <c>EmitAdded</c> → <c>EmitDelta</c> (0+) → <c>EmitRefusalDone</c>
/// → <c>EmitDone</c>.
/// </summary>
public class RefusalContentBuilder
{
    private readonly ResponseEventStream _stream;
    private readonly long _outputIndex;
    private readonly long _contentIndex;
    private readonly string _itemId;
    private string? _finalRefusal;
    private bool _refusalDone;
    private BuilderLifecycleState _lifecycleState;

    /// <summary>
    /// Initializes a new instance of <see cref="RefusalContentBuilder"/>.
    /// </summary>
    internal RefusalContentBuilder(ResponseEventStream stream, long outputIndex, long contentIndex, string itemId)
    {
        _stream = stream;
        _outputIndex = outputIndex;
        _contentIndex = contentIndex;
        _itemId = itemId;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="RefusalContentBuilder"/> for mocking.
    /// </summary>
    protected RefusalContentBuilder()
    {
        _stream = null!;
        _itemId = string.Empty;
    }

    /// <summary>The final refusal text set by <see cref="EmitRefusalDone"/>. Null if not yet finalized.</summary>
    public string? FinalRefusal => _finalRefusal;

    /// <summary>The content index assigned to this refusal content part.</summary>
    public long ContentIndex => _contentIndex;

    /// <summary>Whether this builder has completed its full lifecycle (<see cref="EmitDone"/> called).</summary>
    internal bool IsDone => _lifecycleState == BuilderLifecycleState.Done;

    /// <summary>
    /// Produces a <c>response.content_part.added</c> event with an empty refusal content part.
    /// </summary>
    /// <returns>A <see cref="ResponseContentPartAddedEvent"/> for this content part.</returns>
    public virtual ResponseContentPartAddedEvent EmitAdded()
    {
        if (_lifecycleState != BuilderLifecycleState.NotStarted)
            throw new InvalidOperationException($"Cannot call EmitAdded — builder is in '{_lifecycleState}' state.");
        _lifecycleState = BuilderLifecycleState.Added;

        var part = new OutputContentRefusalContent(refusal: "");
        return new ResponseContentPartAddedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, part);
    }

    /// <summary>
    /// Produces a <c>response.refusal.delta</c> event with the given refusal text chunk.
    /// </summary>
    /// <param name="text">The refusal text chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseRefusalDeltaEvent"/> with the delta.</returns>
    public virtual ResponseRefusalDeltaEvent EmitDelta(string text)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDelta — builder is in '{_lifecycleState}' state.");
        if (_refusalDone)
            throw new InvalidOperationException("Cannot emit deltas after EmitRefusalDone has been called.");

        return new ResponseRefusalDeltaEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, text);
    }

    /// <summary>
    /// Produces a <c>response.refusal.done</c> event with the final complete refusal text.
    /// Call this after all deltas have been emitted and before <see cref="EmitDone"/>.
    /// </summary>
    /// <param name="finalRefusal">The final complete refusal text.</param>
    /// <returns>A <see cref="ResponseRefusalDoneEvent"/> with the final refusal.</returns>
    public virtual ResponseRefusalDoneEvent EmitRefusalDone(string finalRefusal)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitRefusalDone — builder is in '{_lifecycleState}' state.");
        if (_refusalDone)
            throw new InvalidOperationException("EmitRefusalDone has already been called.");

        _refusalDone = true;
        _finalRefusal = finalRefusal;
        return new ResponseRefusalDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, finalRefusal);
    }

    /// <summary>
    /// Produces a <c>response.content_part.done</c> event, closing this content part.
    /// Must be called after <see cref="EmitRefusalDone"/>.
    /// </summary>
    /// <returns>A <see cref="ResponseContentPartDoneEvent"/> for this content part.</returns>
    public virtual ResponseContentPartDoneEvent EmitDone()
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDone — builder is in '{_lifecycleState}' state.");
        if (!_refusalDone)
            throw new InvalidOperationException("Must call EmitRefusalDone() before EmitDone().");
        _lifecycleState = BuilderLifecycleState.Done;

        var part = new OutputContentRefusalContent(
            refusal: _finalRefusal ?? string.Empty);
        return new ResponseContentPartDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, part);
    }
}
