// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a function call output item. Provides methods
/// for the function call event lifecycle: added, arguments delta/done, and done events.
/// </summary>
public class OutputItemFunctionCallBuilder : OutputItemBuilder<OutputItemFunctionToolCall>
{
    private readonly string _name;
    private readonly string _callId;
    private string? _finalArguments;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemFunctionCallBuilder"/>.
    /// </summary>
    internal OutputItemFunctionCallBuilder(ResponseEventStream stream, long outputIndex, string itemId, string name, string callId)
        : base(stream, outputIndex, itemId)
    {
        _name = name;
        _callId = callId;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemFunctionCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemFunctionCallBuilder()
        : base()
    {
        _name = string.Empty;
        _callId = string.Empty;
    }

    /// <summary>The function name.</summary>
    public string Name => _name;

    /// <summary>The call ID.</summary>
    public string CallId => _callId;

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with a function call output item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this function call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemFunctionToolCall(
            callId: _callId,
            name: _name,
            arguments: "");
        item.Id = _itemId;
        item.Status = OutputItemFunctionToolCallStatus.InProgress;
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.function_call_arguments.delta</c> event with the given argument chunk.
    /// </summary>
    /// <param name="delta">The argument chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseFunctionCallArgumentsDeltaEvent"/> with the delta.</returns>
    public virtual ResponseFunctionCallArgumentsDeltaEvent EmitArgumentsDelta(string delta)
    {
        return new ResponseFunctionCallArgumentsDeltaEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex, delta);
    }

    /// <summary>
    /// Produces a <c>response.function_call_arguments.done</c> event with the complete arguments.
    /// </summary>
    /// <param name="arguments">The complete arguments JSON string.</param>
    /// <returns>A <see cref="ResponseFunctionCallArgumentsDoneEvent"/> with the arguments.</returns>
    public virtual ResponseFunctionCallArgumentsDoneEvent EmitArgumentsDone(string arguments)
    {
        _finalArguments = arguments;
        return new ResponseFunctionCallArgumentsDoneEvent(
            _stream.NextSequenceNumber(), _itemId, _name, _outputIndex, arguments);
    }

    // ── Sub-Item Convenience Generators (S-053/S-054/S-055) ────

    /// <summary>
    /// Convenience generator that yields the complete arguments sub-item
    /// event sequence from a single string (S-053, complete-text mode per S-054).
    /// </summary>
    /// <param name="arguments">The complete arguments JSON string.</param>
    /// <returns>An enumerable of events: <c>function_call_arguments.delta</c> → <c>function_call_arguments.done</c>.</returns>
    public virtual IEnumerable<ResponseStreamEvent> Arguments(string arguments)
    {
        yield return EmitArgumentsDelta(arguments);
        yield return EmitArgumentsDone(arguments);
    }

    /// <summary>
    /// Convenience generator that yields the complete arguments sub-item
    /// event sequence from streaming chunks (S-053, streaming mode per S-054).
    /// Each chunk is emitted as a delta immediately (S-055).
    /// </summary>
    /// <param name="chunks">An async enumerable of argument text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: N × <c>function_call_arguments.delta</c> → <c>function_call_arguments.done</c>.</returns>
    public virtual async IAsyncEnumerable<ResponseStreamEvent> Arguments(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var sb = new StringBuilder();
        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            sb.Append(chunk);
            yield return EmitArgumentsDelta(chunk);
        }

        yield return EmitArgumentsDone(sb.ToString());
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with the completed function call output item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this function call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemFunctionToolCall(
            callId: _callId,
            name: _name,
            arguments: _finalArguments ?? "");
        item.Id = _itemId;
        item.Status = OutputItemFunctionToolCallStatus.Completed;
        return EmitDone(item);
    }
}
