// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a text content part within a message. Owns its full
/// lifecycle: <c>EmitAdded</c> → <c>EmitDelta</c> (0+) → <c>EmitTextDone</c>
/// → <c>EmitAnnotationAdded</c> (0+) → <c>EmitDone</c>.
/// </summary>
public class TextContentBuilder
{
    private readonly ResponseEventStream _stream;
    private readonly long _outputIndex;
    private readonly long _contentIndex;
    private readonly string _itemId;
    private readonly List<string> _deltaFragments = new();
    private readonly List<Annotation> _annotations = new();
    private string? _finalText;
    private long _annotationIndex;
    private bool _textDone;
    private BuilderLifecycleState _lifecycleState;

    /// <summary>
    /// Initializes a new instance of <see cref="TextContentBuilder"/>.
    /// </summary>
    internal TextContentBuilder(ResponseEventStream stream, long outputIndex, long contentIndex, string itemId)
    {
        _stream = stream;
        _outputIndex = outputIndex;
        _contentIndex = contentIndex;
        _itemId = itemId;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TextContentBuilder"/> for mocking.
    /// </summary>
    protected TextContentBuilder()
    {
        _stream = null!;
        _itemId = string.Empty;
    }

    /// <summary>The final text set by <see cref="EmitTextDone"/>. Null if not yet finalized.</summary>
    public string? FinalText => _finalText;

    /// <summary>The content index assigned to this text content part.</summary>
    public long ContentIndex => _contentIndex;

    /// <summary>Whether this builder has completed its full lifecycle (<see cref="EmitDone"/> called).</summary>
    internal bool IsDone => _lifecycleState == BuilderLifecycleState.Done;

    /// <summary>The annotations emitted via <see cref="EmitAnnotationAdded"/>.</summary>
    public IReadOnlyList<Annotation> Annotations => _annotations.AsReadOnly();

    /// <summary>
    /// Produces a <c>response.content_part.added</c> event with an empty text content part.
    /// </summary>
    /// <returns>A <see cref="ResponseContentPartAddedEvent"/> for this content part.</returns>
    public virtual ResponseContentPartAddedEvent EmitAdded()
    {
        if (_lifecycleState != BuilderLifecycleState.NotStarted)
            throw new InvalidOperationException($"Cannot call EmitAdded — builder is in '{_lifecycleState}' state.");
        _lifecycleState = BuilderLifecycleState.Added;

        var part = new OutputContentOutputTextContent(
            text: "",
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        return new ResponseContentPartAddedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, part);
    }

    /// <summary>
    /// Produces a <c>response.output_text.delta</c> event with the given text chunk.
    /// </summary>
    /// <param name="text">The text chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseTextDeltaEvent"/> with the text delta.</returns>
    public virtual ResponseTextDeltaEvent EmitDelta(string text)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDelta — builder is in '{_lifecycleState}' state.");
        if (_textDone)
            throw new InvalidOperationException("Cannot emit deltas after EmitTextDone has been called.");

        _deltaFragments.Add(text);
        return new ResponseTextDeltaEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex,
            text, Array.Empty<ResponseLogProb>());
    }

    /// <summary>
    /// Produces a <c>response.output_text.done</c> event with the final complete text.
    /// Call this after all deltas have been emitted. After this, you may call
    /// <see cref="EmitAnnotationAdded"/> and then <see cref="EmitDone"/>.
    /// </summary>
    /// <param name="finalText">
    /// Optional override for the final text. When <c>null</c>, the accumulated delta
    /// fragments are merged automatically.
    /// </param>
    /// <returns>A <see cref="ResponseTextDoneEvent"/> with the final text.</returns>
    public virtual ResponseTextDoneEvent EmitTextDone(string? finalText = null)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitTextDone — builder is in '{_lifecycleState}' state.");
        if (_textDone)
            throw new InvalidOperationException("EmitTextDone has already been called.");

        _textDone = true;
        _finalText = finalText ?? string.Concat(_deltaFragments);

        return new ResponseTextDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex,
            _finalText, Array.Empty<ResponseLogProb>());
    }

    /// <summary>
    /// Produces a <c>response.output_text.annotation.added</c> event with the given annotation.
    /// The annotation is also tracked so that <see cref="EmitDone"/> can include it in
    /// the <c>content_part.done</c> event.
    /// </summary>
    /// <param name="annotation">The annotation to emit.</param>
    /// <returns>A <see cref="ResponseOutputTextAnnotationAddedEvent"/> with the annotation.</returns>
    public virtual ResponseOutputTextAnnotationAddedEvent EmitAnnotationAdded(Annotation annotation)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitAnnotationAdded — builder is in '{_lifecycleState}' state.");
        if (!_textDone)
            throw new InvalidOperationException("Must call EmitTextDone() before EmitAnnotationAdded().");

        _annotations.Add(annotation);
        var annotationIndex = _annotationIndex++;
        return new ResponseOutputTextAnnotationAddedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, annotationIndex, annotation);
    }

    /// <summary>
    /// Produces a <c>response.content_part.done</c> event, closing this content part.
    /// Must be called after <see cref="EmitTextDone"/>.
    /// </summary>
    /// <returns>A <see cref="ResponseContentPartDoneEvent"/> for this content part.</returns>
    public virtual ResponseContentPartDoneEvent EmitDone()
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDone — builder is in '{_lifecycleState}' state.");
        if (!_textDone)
            throw new InvalidOperationException("Must call EmitTextDone() before EmitDone().");
        _lifecycleState = BuilderLifecycleState.Done;

        var part = new OutputContentOutputTextContent(
            text: _finalText ?? string.Empty,
            annotations: _annotations,
            logprobs: Array.Empty<LogProb>());
        return new ResponseContentPartDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, part);
    }
}
