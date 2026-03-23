// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a text content part within a message. Provides methods
/// for the text content lifecycle: added, delta, and done events.
/// </summary>
public class TextContentBuilder
{
    private readonly ResponseEventStream _stream;
    private readonly long _outputIndex;
    private readonly long _contentIndex;
    private readonly string _itemId;
    private string? _finalText;
    private long _annotationIndex;
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

    /// <summary>The final text passed to <see cref="EmitDone"/>. Null if not yet finalized.</summary>
    public string? FinalText => _finalText;

    /// <summary>The content index assigned to this text content part.</summary>
    public long ContentIndex => _contentIndex;

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
        return new ResponseTextDeltaEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex,
            text, Array.Empty<ResponseLogProb>());
    }

    /// <summary>
    /// Produces a <c>response.output_text.done</c> event with the final complete text.
    /// </summary>
    /// <param name="finalText">The final complete text.</param>
    /// <returns>A <see cref="ResponseTextDoneEvent"/> with the final text.</returns>
    public virtual ResponseTextDoneEvent EmitDone(string finalText)
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
            throw new InvalidOperationException($"Cannot call EmitDone — builder is in '{_lifecycleState}' state.");
        _lifecycleState = BuilderLifecycleState.Done;

        _finalText = finalText;
        return new ResponseTextDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex,
            finalText, Array.Empty<ResponseLogProb>());
    }

    /// <summary>
    /// Produces a <c>response.output_text.annotation.added</c> event with the given annotation.
    /// </summary>
    /// <param name="annotation">The annotation to emit.</param>
    /// <returns>A <see cref="ResponseOutputTextAnnotationAddedEvent"/> with the annotation.</returns>
    public virtual ResponseOutputTextAnnotationAddedEvent EmitAnnotationAdded(Annotation annotation)
    {
        var annotationIndex = _annotationIndex++;
        return new ResponseOutputTextAnnotationAddedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, _contentIndex, annotationIndex, annotation);
    }
}
