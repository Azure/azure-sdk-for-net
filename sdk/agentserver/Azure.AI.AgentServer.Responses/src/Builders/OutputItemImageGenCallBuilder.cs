// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for an image generation tool call output item. Provides methods
/// for lifecycle events and streaming partial image data.
/// </summary>
public class OutputItemImageGenCallBuilder : OutputItemBuilder<OutputItemImageGenToolCall>
{
    private long _partialImageIndex;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemImageGenCallBuilder"/>.
    /// </summary>
    internal OutputItemImageGenCallBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemImageGenCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemImageGenCallBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an in-progress image gen item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this image gen call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemImageGenToolCall(
            id: _itemId,
            status: OutputItemImageGenToolCallStatus.InProgress,
            result: "");
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.image_gen_call.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseImageGenCallInProgressEvent"/>.</returns>
    public virtual ResponseImageGenCallInProgressEvent EmitInProgress()
    {
        return new ResponseImageGenCallInProgressEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.image_gen_call.generating</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseImageGenCallGeneratingEvent"/>.</returns>
    public virtual ResponseImageGenCallGeneratingEvent EmitGenerating()
    {
        return new ResponseImageGenCallGeneratingEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.image_gen_call.partial_image</c> event with the given image data.
    /// </summary>
    /// <param name="partialImageB64">The base64-encoded partial image data.</param>
    /// <returns>A <see cref="ResponseImageGenCallPartialImageEvent"/> with the partial image.</returns>
    public virtual ResponseImageGenCallPartialImageEvent EmitPartialImage(string partialImageB64)
    {
        var index = _partialImageIndex++;
        return new ResponseImageGenCallPartialImageEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, index, partialImageB64);
    }

    /// <summary>
    /// Produces a <c>response.image_gen_call.completed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseImageGenCallCompletedEvent"/>.</returns>
    public virtual ResponseImageGenCallCompletedEvent EmitCompleted()
    {
        return new ResponseImageGenCallCompletedEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a completed image gen item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this image gen call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemImageGenToolCall(
            id: _itemId,
            status: OutputItemImageGenToolCallStatus.Completed,
            result: "");
        return EmitDone(item);
    }
}
