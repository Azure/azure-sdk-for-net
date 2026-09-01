// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for an MCP list tools output item. Provides methods
/// for lifecycle events with success or failure terminal states.
/// </summary>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
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
        var item = new OutputItemMcpListTools(_serverLabel, Array.Empty<McpToolDefinition>())
        {
            Id = _itemId,
        };
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsInProgressEvent"/>.</returns>
    public virtual ResponseMCPListToolsInProgressEvent EmitInProgress()
    {
        return new ResponseMCPListToolsInProgressEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), ItemId = _itemId, OutputIndex = (int)(_outputIndex) };
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.completed</c> event and records the terminal
    /// state so that <see cref="EmitDone"/> knows the operation succeeded (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsCompletedEvent"/>.</returns>
    public virtual ResponseMCPListToolsCompletedEvent EmitCompleted()
    {
        return new ResponseMCPListToolsCompletedEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), ItemId = _itemId, OutputIndex = (int)(_outputIndex) };
    }

    /// <summary>
    /// Produces a <c>response.mcp_list_tools.failed</c> event and records the terminal
    /// state so that <see cref="EmitDone"/> knows the operation failed (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseMCPListToolsFailedEvent"/>.</returns>
    public virtual ResponseMCPListToolsFailedEvent EmitFailed()
    {
        return new ResponseMCPListToolsFailedEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), ItemId = _itemId, OutputIndex = (int)(_outputIndex) };
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with the MCP list tools item.
    /// The <see cref="OutputItemMcpListTools.Error"/> property is not populated by this
    /// builder; callers should set it on the item if <see cref="EmitFailed"/> was called (S-060).
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this MCP list tools item.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemMcpListTools(_serverLabel, Array.Empty<McpToolDefinition>())
        {
            Id = _itemId,
        };
        return EmitDone(item);
    }
}
