// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a code interpreter tool call output item. Provides methods
/// for the lifecycle events and streaming code deltas.
/// </summary>
public class OutputItemCodeInterpreterCallBuilder : OutputItemBuilder<OutputItemCodeInterpreterToolCall>
{
    private string? _finalCode;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemCodeInterpreterCallBuilder"/>.
    /// </summary>
    internal OutputItemCodeInterpreterCallBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemCodeInterpreterCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemCodeInterpreterCallBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an in-progress code interpreter item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this code interpreter call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemCodeInterpreterToolCall(
            id: _itemId,
            status: OutputItemCodeInterpreterToolCallStatus.InProgress,
            containerId: "",
            code: "",
            outputs: Array.Empty<BinaryData>());
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.code_interpreter_call.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseCodeInterpreterCallInProgressEvent"/>.</returns>
    public virtual ResponseCodeInterpreterCallInProgressEvent EmitInProgress()
    {
        return new ResponseCodeInterpreterCallInProgressEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.code_interpreter_call.interpreting</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseCodeInterpreterCallInterpretingEvent"/>.</returns>
    public virtual ResponseCodeInterpreterCallInterpretingEvent EmitInterpreting()
    {
        return new ResponseCodeInterpreterCallInterpretingEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.code_interpreter_call.code.delta</c> event with the given code chunk.
    /// </summary>
    /// <param name="delta">The code chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseCodeInterpreterCallCodeDeltaEvent"/> with the delta.</returns>
    public virtual ResponseCodeInterpreterCallCodeDeltaEvent EmitCodeDelta(string delta)
    {
        return new ResponseCodeInterpreterCallCodeDeltaEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, delta);
    }

    /// <summary>
    /// Produces a <c>response.code_interpreter_call.code.done</c> event with the final code.
    /// </summary>
    /// <param name="code">The final complete code.</param>
    /// <returns>A <see cref="ResponseCodeInterpreterCallCodeDoneEvent"/> with the final code.</returns>
    public virtual ResponseCodeInterpreterCallCodeDoneEvent EmitCodeDone(string code)
    {
        _finalCode = code;
        return new ResponseCodeInterpreterCallCodeDoneEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, code);
    }

    /// <summary>
    /// Produces a <c>response.code_interpreter_call.completed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseCodeInterpreterCallCompletedEvent"/>.</returns>
    public virtual ResponseCodeInterpreterCallCompletedEvent EmitCompleted()
    {
        return new ResponseCodeInterpreterCallCompletedEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a completed code interpreter item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this code interpreter call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemCodeInterpreterToolCall(
            id: _itemId,
            status: OutputItemCodeInterpreterToolCallStatus.Completed,
            containerId: "",
            code: _finalCode ?? "",
            outputs: Array.Empty<BinaryData>());
        return EmitDone(item);
    }
}
