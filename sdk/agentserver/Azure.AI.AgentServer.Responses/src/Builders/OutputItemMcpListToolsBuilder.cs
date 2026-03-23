// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for an MCP list tools output item. Provides methods
/// for lifecycle events with success or failure terminal states.
/// </summary>
public class OutputItemMcpListToolsBuilder : OutputItemBuilder<OutputItemMcpListTools>
{
    private readonly string _serverLabel;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMcpListToolsBuilder"/>.
    /// </summary>
    internal OutputItemMcpListToolsBuilder(ResponseEventStream stream, long outputIndex, string itemId, string serverLabel)
        : base(stream, outputIndex, itemId)
    {
        _serverLabel = serverLabel;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemMcpListToolsBuilder"/> for mocking.
    /// </summary>
    protected OutputItemMcpListToolsBuilder()
        : base()
    {
        _serverLabel = string.Empty;
    }

    /// <summary>The MCP server label.</summary>
    public string ServerLabel => _serverLabel;

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an MCP list tools item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this MCP list tools item.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemMcpListTools(
            id: _itemId,
            serverLabel: _serverLabel,
            tools: Array.Empty<MCPListToolsTool>());
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsInProgressEvent"/>.</returns>
    public virtual ResponseMCPListToolsInProgressEvent EmitInProgress()
    {
        return new ResponseMCPListToolsInProgressEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex);
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.completed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsCompletedEvent"/>.</returns>
    public virtual ResponseMCPListToolsCompletedEvent EmitCompleted()
    {
        return new ResponseMCPListToolsCompletedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex);
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.failed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsFailedEvent"/>.</returns>
    public virtual ResponseMCPListToolsFailedEvent EmitFailed()
    {
        return new ResponseMCPListToolsFailedEvent(
            _stream.NextSequenceNumber(), _itemId, _outputIndex);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with the MCP list tools item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this MCP list tools item.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemMcpListTools(
            id: _itemId,
            serverLabel: _serverLabel,
            tools: Array.Empty<MCPListToolsTool>());
        return EmitDone(item);
    }
}
