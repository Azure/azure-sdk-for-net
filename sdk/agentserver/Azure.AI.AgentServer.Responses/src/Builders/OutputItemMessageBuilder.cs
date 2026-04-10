// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
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
        return EmitContentDone(textContent, Array.Empty<Annotation>());
    }

    /// <summary>
    /// Produces a <c>response.content_part.done</c> event for the given
    /// text content builder, including the specified annotations.
    /// </summary>
    /// <param name="textContent">The text content builder whose final text to use.</param>
    /// <param name="annotations">The annotations to include in the completed content part.</param>
    /// <returns>A <see cref="ResponseContentPartDoneEvent"/> for this content part.</returns>
    public virtual ResponseContentPartDoneEvent EmitContentDone(
        TextContentBuilder textContent, IEnumerable<Annotation> annotations)
    {
        ArgumentNullException.ThrowIfNull(textContent);
        ArgumentNullException.ThrowIfNull(annotations);

        var annotationList = annotations as IList<Annotation> ?? annotations.ToList();
        var part = new OutputContentOutputTextContent(
            text: textContent.FinalText ?? string.Empty,
            annotations: annotationList,
            logprobs: Array.Empty<LogProb>());
        _completedContents.Add(new MessageContentOutputTextContent(
            text: textContent.FinalText ?? string.Empty,
            annotations: annotationList,
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

    // ── Sub-Item Convenience Generators (S-053/S-054/S-055) ────

    /// <summary>
    /// Convenience generator that yields the complete text content sub-item
    /// event sequence from a single string (S-053, complete-text mode per S-054).
    /// </summary>
    /// <param name="text">The complete text to emit.</param>
    /// <returns>An enumerable of events: <c>content_part.added</c> → <c>output_text.delta</c> → <c>output_text.done</c> → <c>content_part.done</c>.</returns>
    public virtual IEnumerable<ResponseStreamEvent> TextContent(string text)
    {
        return TextContent(text, Array.Empty<Annotation>());
    }

    /// <summary>
    /// Convenience generator that yields the complete text content sub-item
    /// event sequence from a single string with annotations. Each annotation is
    /// emitted as a <c>response.output_text.annotation.added</c> event after the
    /// text done event.
    /// </summary>
    /// <param name="text">The complete text to emit.</param>
    /// <param name="annotations">The annotations to attach to this text content part.</param>
    /// <returns>An enumerable of events: <c>content_part.added</c> → <c>output_text.delta</c> → <c>output_text.done</c> → N × <c>annotation.added</c> → <c>content_part.done</c>.</returns>
    public virtual IEnumerable<ResponseStreamEvent> TextContent(
        string text, IEnumerable<Annotation> annotations)
    {
        var annotationList = annotations as IList<Annotation> ?? annotations.ToList();
        var builder = AddTextContent();
        yield return builder.EmitAdded();
        yield return builder.EmitDelta(text);
        yield return builder.EmitDone(text);

        foreach (var annotation in annotationList)
        {
            yield return builder.EmitAnnotationAdded(annotation);
        }

        yield return EmitContentDone(builder, annotationList);
    }

    /// <summary>
    /// Convenience generator that yields the complete text content sub-item
    /// event sequence from streaming chunks (S-053, streaming mode per S-054).
    /// Each chunk is emitted as a delta immediately (S-055).
    /// </summary>
    /// <param name="chunks">An async enumerable of text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>content_part.added</c> → N × <c>output_text.delta</c> → <c>output_text.done</c> → <c>content_part.done</c>.</returns>
    public virtual async IAsyncEnumerable<ResponseStreamEvent> TextContent(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddTextContent();
        yield return builder.EmitAdded();

        var sb = new StringBuilder();
        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            sb.Append(chunk);
            yield return builder.EmitDelta(chunk);
        }

        var finalText = sb.ToString();
        yield return builder.EmitDone(finalText);
        yield return EmitContentDone(builder);
    }

    /// <summary>
    /// Convenience generator that yields the complete refusal content sub-item
    /// event sequence from a single string (S-053, complete-text mode per S-054).
    /// </summary>
    /// <param name="text">The complete refusal text to emit.</param>
    /// <returns>An enumerable of events: <c>content_part.added</c> → <c>refusal.delta</c> → <c>refusal.done</c> → <c>content_part.done</c>.</returns>
    public virtual IEnumerable<ResponseStreamEvent> RefusalContent(string text)
    {
        var builder = AddRefusalContent();
        yield return builder.EmitAdded();
        yield return builder.EmitDelta(text);
        yield return builder.EmitDone(text);
        yield return EmitContentDone(builder);
    }

    /// <summary>
    /// Convenience generator that yields the complete refusal content sub-item
    /// event sequence from streaming chunks (S-053, streaming mode per S-054).
    /// Each chunk is emitted as a delta immediately (S-055).
    /// </summary>
    /// <param name="chunks">An async enumerable of refusal text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>content_part.added</c> → N × <c>refusal.delta</c> → <c>refusal.done</c> → <c>content_part.done</c>.</returns>
    public virtual async IAsyncEnumerable<ResponseStreamEvent> RefusalContent(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddRefusalContent();
        yield return builder.EmitAdded();

        var sb = new StringBuilder();
        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            sb.Append(chunk);
            yield return builder.EmitDelta(chunk);
        }

        var finalText = sb.ToString();
        yield return builder.EmitDone(finalText);
        yield return EmitContentDone(builder);
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
