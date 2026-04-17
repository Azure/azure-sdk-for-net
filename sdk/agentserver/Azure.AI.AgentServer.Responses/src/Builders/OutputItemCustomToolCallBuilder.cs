// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a custom tool call output item. Provides methods
/// for lifecycle events and streaming input deltas.
/// </summary>
public class OutputItemCustomToolCallBuilder : OutputItemBuilder<OutputItemCustomToolCall>
{
    private readonly string _callId;
    private readonly string _name;
    private string? _finalInput;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemCustomToolCallBuilder"/>.
    /// </summary>
    internal OutputItemCustomToolCallBuilder(ResponseEventStream stream, long outputIndex, string itemId, string callId, string name)
        : base(stream, outputIndex, itemId)
    {
        _callId = callId;
        _name = name;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemCustomToolCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemCustomToolCallBuilder()
        : base()
    {
        _callId = string.Empty;
        _name = string.Empty;
    }

    /// <summary>The call ID for this custom tool call.</summary>
    public string CallId => _callId;

    /// <summary>The tool name.</summary>
    public string Name => _name;

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with a custom tool call item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this custom tool call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemCustomToolCall(
            callId: _callId,
            name: _name,
            input: "");
        item.Id = _itemId;
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.custom_tool_call_input.delta</c> event with the given input chunk.
    /// </summary>
    /// <param name="delta">The input chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseCustomToolCallInputDeltaEvent"/> with the delta.</returns>
    public virtual ResponseCustomToolCallInputDeltaEvent EmitInputDelta(string delta)
    {
        return new ResponseCustomToolCallInputDeltaEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, delta);
    }

    /// <summary>
    /// Produces a <c>response.custom_tool_call_input.done</c> event with the final input.
    /// </summary>
    /// <param name="input">The final complete input.</param>
    /// <returns>A <see cref="ResponseCustomToolCallInputDoneEvent"/> with the final input.</returns>
    public virtual ResponseCustomToolCallInputDoneEvent EmitInputDone(string input)
    {
        _finalInput = input;
        return new ResponseCustomToolCallInputDoneEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, input);
    }

    /// <summary>
    /// Convenience generator that emits a complete input as delta → done events.
    /// </summary>
    /// <param name="input">The complete input text.</param>
    /// <returns>An enumerable of <see cref="ResponseStreamEvent"/> for the input.</returns>
    public IEnumerable<ResponseStreamEvent> Input(string input)
    {
        yield return EmitInputDelta(input);
        yield return EmitInputDone(input);
    }

    /// <summary>
    /// Convenience generator that streams input chunks as real-time delta events
    /// followed by a done event with the accumulated input.
    /// </summary>
    /// <param name="chunks">An async sequence of input text chunks.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An async enumerable of <see cref="ResponseStreamEvent"/> for the input.</returns>
    public async IAsyncEnumerable<ResponseStreamEvent> Input(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var accumulated = new StringBuilder();
        await foreach (var chunk in chunks.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            accumulated.Append(chunk);
            yield return EmitInputDelta(chunk);
        }
        yield return EmitInputDone(accumulated.ToString());
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with the completed custom tool call item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this custom tool call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemCustomToolCall(
            callId: _callId,
            name: _name,
            input: _finalInput ?? "");
        item.Id = _itemId;
        return EmitDone(item);
    }
}
