// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// A high-level convenience that produces a complete text-message response stream.
/// Implements <see cref="IAsyncEnumerable{ResponseStreamEvent}"/> so it can be
/// returned directly from <see cref="ResponseHandler.CreateAsync"/>.
/// <para>
/// Handles the full SSE lifecycle automatically:
/// <c>response.created</c> → <c>response.in_progress</c> → message/content events
/// → <c>response.completed</c>.
/// </para>
/// <para>
/// Use the <see cref="TextResponse(ResponseContext, CreateResponse, Func{CancellationToken, Task{string}}, Action{ResponseObject}?)"/>
/// constructor when you have the complete text available (or can produce it in a single async call).
/// Use the <see cref="TextResponse(ResponseContext, CreateResponse, Func{CancellationToken, IAsyncEnumerable{string}}, Action{ResponseObject}?)"/>
/// constructor when text arrives incrementally (e.g., token-by-token from an LLM).
/// </para>
/// </summary>
/// <example>
/// Simplest usage — return a single text string:
/// <code>
/// return new TextResponse(context, request,
///     createText: ct =&gt; Task.FromResult("Hello!"));
/// </code>
/// </example>
public class TextResponse : IAsyncEnumerable<ResponseStreamEvent>
{
    private readonly ResponseContext _context;
    private readonly CreateResponse _request;
    private readonly Action<ResponseObject>? _configure;
    private readonly Func<CancellationToken, Task<string>>? _createText;
    private readonly Func<CancellationToken, IAsyncEnumerable<string>>? _createTextStream;

    /// <summary>
    /// Creates a <see cref="TextResponse"/> that produces a single text message
    /// from a complete string.
    /// </summary>
    /// <param name="context">The response context (provides the response ID).</param>
    /// <param name="request">The incoming create-response request.</param>
    /// <param name="createText">
    /// An async delegate that produces the complete response text.
    /// Called after <c>response.created</c> and <c>response.in_progress</c> have been emitted,
    /// so the client sees progress before the potentially slow text generation begins.
    /// </param>
    /// <param name="configure">
    /// An optional callback to configure the <see cref="ResponseObject"/> (e.g., set
    /// <c>Temperature</c>, <c>Instructions</c>, <c>Metadata</c>) before
    /// <c>response.created</c> is emitted.
    /// </param>
    public TextResponse(
        ResponseContext context,
        CreateResponse request,
        Func<CancellationToken, Task<string>> createText,
        Action<ResponseObject>? configure = null)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _request = request ?? throw new ArgumentNullException(nameof(request));
        _createText = createText ?? throw new ArgumentNullException(nameof(createText));
        _configure = configure;
    }

    /// <summary>
    /// Creates a <see cref="TextResponse"/> that produces a text message
    /// from a stream of text chunks (e.g., tokens from an LLM).
    /// Each chunk is emitted as a <c>response.output_text.delta</c> event.
    /// </summary>
    /// <param name="context">The response context (provides the response ID).</param>
    /// <param name="request">The incoming create-response request.</param>
    /// <param name="createTextStream">
    /// A delegate that returns an async enumerable of text chunks.
    /// Called after <c>response.created</c> and <c>response.in_progress</c> have been emitted.
    /// </param>
    /// <param name="configure">
    /// An optional callback to configure the <see cref="ResponseObject"/> before
    /// <c>response.created</c> is emitted.
    /// </param>
    public TextResponse(
        ResponseContext context,
        CreateResponse request,
        Func<CancellationToken, IAsyncEnumerable<string>> createTextStream,
        Action<ResponseObject>? configure = null)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _request = request ?? throw new ArgumentNullException(nameof(request));
        _createTextStream = createTextStream ?? throw new ArgumentNullException(nameof(createTextStream));
        _configure = configure;
    }

    /// <inheritdoc/>
    public async IAsyncEnumerator<ResponseStreamEvent> GetAsyncEnumerator(
        CancellationToken cancellationToken = default)
    {
        var stream = new ResponseEventStream(_context, _request);

        _configure?.Invoke(stream.Response);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        if (_createText != null)
        {
            // Complete-text mode: one delta with the full text.
            var result = await _createText(cancellationToken).ConfigureAwait(false);
            yield return text.EmitDelta(result);
            yield return text.EmitTextDone(result);
        }
        else
        {
            // Streaming mode: N deltas, accumulate final text.
            var sb = new StringBuilder();
            await foreach (var chunk in _createTextStream!(cancellationToken).WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                sb.Append(chunk);
                yield return text.EmitDelta(chunk);
            }
            yield return text.EmitTextDone(sb.ToString());
        }

        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
