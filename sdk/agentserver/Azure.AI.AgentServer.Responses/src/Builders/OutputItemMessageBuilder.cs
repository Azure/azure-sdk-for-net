// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a message-type output item. Manages the content index
/// counter within the message and provides factory methods for content part scopes.
/// </summary>
public class OutputItemMessageBuilder : OutputItemBuilder<OutputItemMessage>
{
    private long _contentIndex;
    private readonly List<MessageContent> _completedContents = new();

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMessageBuilder"/>.
    /// </summary>
    internal OutputItemMessageBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMessageBuilder"/> for mocking.
    /// </summary>
    protected OutputItemMessageBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an
    /// in-progress message output item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this message.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var message = new OutputItemMessage(
            id: _itemId,
            status: MessageStatus.InProgress,
            content: Array.Empty<MessageContent>());
        return EmitAdded(message);
    }

    /// <summary>
    /// Creates a text content part scope with the next content index.
    /// </summary>
    /// <returns>A new <see cref="TextContentBuilder"/> for the text content part.</returns>
    public virtual TextContentBuilder AddTextContent()
    {
        var contentIndex = _contentIndex++;
        return new TextContentBuilder(_stream, _outputIndex, contentIndex, _itemId);
    }

    /// <summary>
    /// Creates a refusal content part scope with the next content index.
    /// </summary>
    /// <returns>A new <see cref="RefusalContentBuilder"/> for the refusal content part.</returns>
    public virtual RefusalContentBuilder AddRefusalContent()
    {
        var contentIndex = _contentIndex++;
        return new RefusalContentBuilder(_stream, _outputIndex, contentIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.content_part.done</c> event for the given
    /// text content builder, using its accumulated final text.
    /// </summary>
    /// <param name="textContent">The text content builder whose final text to use.</param>
    /// <returns>A <see cref="ResponseContentPartDoneEvent"/> for this content part.</returns>
    public virtual ResponseContentPartDoneEvent EmitContentDone(TextContentBuilder textContent)
    {
        var part = new OutputContentOutputTextContent(
            text: textContent.FinalText ?? string.Empty,
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        _completedContents.Add(new MessageContentOutputTextContent(
            text: textContent.FinalText ?? string.Empty,
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>()));
        return new ResponseContentPartDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, textContent.ContentIndex, part);
    }

    /// <summary>
    /// Produces a <c>response.content_part.done</c> event for the given
    /// refusal content builder, using its accumulated final refusal text.
    /// </summary>
    /// <param name="refusalContent">The refusal content builder whose final refusal to use.</param>
    /// <returns>A <see cref="ResponseContentPartDoneEvent"/> for this content part.</returns>
    public virtual ResponseContentPartDoneEvent EmitContentDone(RefusalContentBuilder refusalContent)
    {
        var part = new OutputContentRefusalContent(
            refusal: refusalContent.FinalRefusal ?? string.Empty);
        _completedContents.Add(new MessageContentRefusalContent(
            refusal: refusalContent.FinalRefusal ?? string.Empty));
        return new ResponseContentPartDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, refusalContent.ContentIndex, part);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a
    /// completed message output item containing the accumulated content.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this message.</returns>
    /// <exception cref="ResponseValidationException">No content parts have been added to this message.</exception>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        if (_completedContents.Count == 0)
        {
            throw new ResponseValidationException(
            [
                new ValidationError("$.content", "Message output item requires at least one content part before EmitDone().")
            ]);
        }

        var message = new OutputItemMessage(
            id: _itemId,
            status: MessageStatus.Completed,
            content: _completedContents);
        return EmitDone(message);
    }
}
