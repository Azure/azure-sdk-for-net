// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for an <c>image_generation_call</c> output item. Provides methods
/// for lifecycle events and streaming partial image data.
/// <para>
/// The typical lifecycle is:
/// <see cref="EmitAdded"/> → <see cref="EmitInProgress"/> → <see cref="EmitGenerating"/> →
/// zero or more <see cref="EmitPartialImage"/> → <see cref="EmitCompleted"/> →
/// <see cref="EmitDone"/>. The final <see cref="EmitDone"/> call carries the
/// base64-encoded image result.
/// </para>
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
    /// Produces a <c>response.output_item.added</c> event with an in-progress image generation item.
    /// The item is emitted with an empty result and <c>in_progress</c> status.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this image generation call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemImageGenToolCall(
            id: _itemId,
            status: ItemImageGenToolCallStatus.InProgress,
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
    /// Partial images allow clients to display progressive rendering while the image is being generated.
    /// </summary>
    /// <param name="partialImageB64">
    /// Base64-encoded partial image data. For example:
    /// <c>Convert.ToBase64String(partialPngBytes)</c>.
    /// </param>
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
    /// Produces a <c>response.output_item.done</c> event with a completed image generation item
    /// containing the final image result.
    /// </summary>
    /// <param name="result">
    /// The base64-encoded image data (PNG, JPEG, or WebP). Clients decode this value with
    /// <c>Convert.FromBase64String(result)</c> to obtain the raw image bytes.
    /// <para>
    /// To produce the value from a byte array:
    /// <c>Convert.ToBase64String(imageBytes)</c>.
    /// </para>
    /// <para>
    /// To produce the value from a file:
    /// <c>Convert.ToBase64String(File.ReadAllBytes("image.png"))</c>.
    /// </para>
    /// </param>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this image generation call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone(string result)
    {
        var item = new OutputItemImageGenToolCall(
            id: _itemId,
            status: ItemImageGenToolCallStatus.Completed,
            result: result);
        return EmitDone(item);
    }
}
