// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a message-type output item. Manages the content index
/// counter within the message and provides factory methods for content part scopes.
/// Child content builders are auto-tracked so <see cref="EmitDone"/> can build
/// the final message from their accumulated state.
/// </summary>
public class OutputItemMessageBuilder : OutputItemBuilder<OutputItemMessage>
{
    private long _contentIndex;
    private readonly List<object> _contentBuilders = new();

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
    /// The builder is auto-tracked for inclusion in <see cref="EmitDone"/>.
    /// </summary>
    /// <returns>A new <see cref="TextContentBuilder"/> for the text content part.</returns>
    public virtual TextContentBuilder AddTextContent()
    {
        var contentIndex = _contentIndex++;
        var builder = new TextContentBuilder(_stream, _outputIndex, contentIndex, _itemId);
        _contentBuilders.Add(builder);
        return builder;
    }

    /// <summary>
    /// Creates a refusal content part scope with the next content index.
    /// The builder is auto-tracked for inclusion in <see cref="EmitDone"/>.
    /// </summary>
    /// <returns>A new <see cref="RefusalContentBuilder"/> for the refusal content part.</returns>
    public virtual RefusalContentBuilder AddRefusalContent()
    {
        var contentIndex = _contentIndex++;
        var builder = new RefusalContentBuilder(_stream, _outputIndex, contentIndex, _itemId);
        _contentBuilders.Add(builder);
        return builder;
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
        yield return builder.EmitTextDone(text);

        foreach (var annotation in annotationList)
        {
            yield return builder.EmitAnnotationAdded(annotation);
        }

        yield return builder.EmitDone();
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

        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            yield return builder.EmitDelta(chunk);
        }

        yield return builder.EmitTextDone();
        yield return builder.EmitDone();
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
        yield return builder.EmitRefusalDone(text);
        yield return builder.EmitDone();
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

        yield return builder.EmitRefusalDone(sb.ToString());
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a
    /// completed message output item. The content list is built automatically
    /// from the tracked child content builders.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this message.</returns>
    /// <exception cref="ResponseValidationException">No content parts have been added to this message.</exception>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        if (_contentBuilders.Count == 0)
        {
            throw new ResponseValidationException(
            [
                new ValidationError("$.content", "Message output item requires at least one content part before EmitDone().")
            ]);
        }

        var completedContents = new List<MessageContent>();
        for (int i = 0; i < _contentBuilders.Count; i++)
        {
            object builder = _contentBuilders[i];
            if (builder is TextContentBuilder tc)
            {
                if (!tc.IsDone)
                {
                    throw new ResponseValidationException(
                    [
                        new ValidationError($"$.content[{i}]", "Text content builder must complete its full lifecycle (EmitTextDone + EmitDone) before message EmitDone().")
                    ]);
                }

                completedContents.Add(new MessageContentOutputTextContent(
                    text: tc.FinalText!,
                    annotations: tc.Annotations,
                    logprobs: Array.Empty<LogProb>()));
            }
            else if (builder is RefusalContentBuilder rc)
            {
                if (!rc.IsDone)
                {
                    throw new ResponseValidationException(
                    [
                        new ValidationError($"$.content[{i}]", "Refusal content builder must complete its full lifecycle (EmitRefusalDone + EmitDone) before message EmitDone().")
                    ]);
                }

                completedContents.Add(new MessageContentRefusalContent(
                    refusal: rc.FinalRefusal!));
            }
        }

        var message = new OutputItemMessage(
            id: _itemId,
            status: MessageStatus.Completed,
            content: completedContents);
        return EmitDone(message);
    }
}
