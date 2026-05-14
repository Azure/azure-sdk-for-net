// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for an MCP tool call output item. Provides methods
/// for lifecycle events and streaming arguments.
/// </summary>
public class OutputItemMcpCallBuilder : OutputItemBuilder<OutputItemMcpToolCall>
{
    private readonly string _serverLabel;
    private readonly string _name;
    private string? _finalArguments;
    private MCPToolCallStatus? _terminalStatus;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMcpCallBuilder"/>.
    /// </summary>
    internal OutputItemMcpCallBuilder(ResponseEventStream stream, long outputIndex, string itemId, string serverLabel, string name)
        : base(stream, outputIndex, itemId)
    {
        _serverLabel = serverLabel;
        _name = name;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMcpCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemMcpCallBuilder()
        : base()
    {
        _serverLabel = string.Empty;
        _name = string.Empty;
    }

    /// <summary>The MCP server label.</summary>
    public string ServerLabel => _serverLabel;

    /// <summary>The MCP tool name.</summary>
    public string Name => _name;

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an in-progress MCP tool call item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this MCP call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemMcpToolCall(
            id: _itemId,
            serverLabel: _serverLabel,
            name: _name,
            arguments: "");
        item.Status = MCPToolCallStatus.InProgress;
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.mcp_call.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseMCPCallInProgressEvent"/>.</returns>
    public virtual ResponseMCPCallInProgressEvent EmitInProgress()
    {
        return new ResponseMCPCallInProgressEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.mcp_call_arguments.delta</c> event with the given argument chunk.
    /// </summary>
    /// <param name="delta">The argument chunk to send as a delta.</param>
    /// <returns>A <see cref="ResponseMCPCallArgumentsDeltaEvent"/> with the delta.</returns>
    public virtual ResponseMCPCallArgumentsDeltaEvent EmitArgumentsDelta(string delta)
    {
        return new ResponseMCPCallArgumentsDeltaEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, delta);
    }

    /// <summary>
    /// Produces a <c>response.mcp_call_arguments.done</c> event with the complete arguments.
    /// </summary>
    /// <param name="arguments">The complete arguments JSON string.</param>
    /// <returns>A <see cref="ResponseMCPCallArgumentsDoneEvent"/> with the arguments.</returns>
    public virtual ResponseMCPCallArgumentsDoneEvent EmitArgumentsDone(string arguments)
    {
        _finalArguments = arguments;
        return new ResponseMCPCallArgumentsDoneEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId, arguments);
    }

    // ── Sub-Item Convenience Generators (S-053/S-054/S-055) ────

    /// <summary>
    /// Convenience generator that yields the complete arguments sub-item
    /// event sequence from a single string (S-053, complete-text mode per S-054).
    /// </summary>
    /// <param name="arguments">The complete arguments JSON string.</param>
    /// <returns>An enumerable of events: <c>mcp_call_arguments.delta</c> → <c>mcp_call_arguments.done</c>.</returns>
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
    /// <returns>An async enumerable of events: N × <c>mcp_call_arguments.delta</c> → <c>mcp_call_arguments.done</c>.</returns>
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
    /// Produces a <c>response.mcp_call.completed</c> event and records the terminal
    /// status so that <see cref="EmitDone"/> uses <see cref="MCPToolCallStatus.Completed"/> (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseMCPCallCompletedEvent"/>.</returns>
    public virtual ResponseMCPCallCompletedEvent EmitCompleted()
    {
        _terminalStatus = MCPToolCallStatus.Completed;
        return new ResponseMCPCallCompletedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex);
    }

    /// <summary>
    /// Produces a <c>response.mcp_call.failed</c> event and records the terminal
    /// status so that <see cref="EmitDone"/> uses <see cref="MCPToolCallStatus.Failed"/> (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseMCPCallFailedEvent"/>.</returns>
    public virtual ResponseMCPCallFailedEvent EmitFailed()
    {
        _terminalStatus = MCPToolCallStatus.Failed;
        return new ResponseMCPCallFailedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with the completed MCP tool call item.
    /// Uses the terminal status recorded by <see cref="EmitCompleted"/> or <see cref="EmitFailed"/>,
    /// defaulting to <see cref="MCPToolCallStatus.Completed"/> if neither was called (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this MCP call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemMcpToolCall(
            id: _itemId,
            serverLabel: _serverLabel,
            name: _name,
            arguments: _finalArguments ?? "");
        item.Status = _terminalStatus ?? MCPToolCallStatus.Completed;
        return EmitDone(item);
    }
}
