// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a web search tool call output item. Provides methods
/// for the web search lifecycle: added, in-progress, searching, completed, done.
/// </summary>
public class OutputItemWebSearchCallBuilder : OutputItemBuilder<OutputItemWebSearchToolCall>
{
    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemWebSearchCallBuilder"/>.
    /// </summary>
    internal OutputItemWebSearchCallBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemWebSearchCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemWebSearchCallBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an in-progress web search item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this web search call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemWebSearchToolCall(
            id: _itemId,
            status: ItemWebSearchToolCallStatus.InProgress,
            action: new BinaryData("{}"));
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.web_search_call.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseWebSearchCallInProgressEvent"/>.</returns>
    public virtual ResponseWebSearchCallInProgressEvent EmitInProgress()
    {
        return new ResponseWebSearchCallInProgressEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.web_search_call.searching</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseWebSearchCallSearchingEvent"/>.</returns>
    public virtual ResponseWebSearchCallSearchingEvent EmitSearching()
    {
        return new ResponseWebSearchCallSearchingEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.web_search_call.completed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseWebSearchCallCompletedEvent"/>.</returns>
    public virtual ResponseWebSearchCallCompletedEvent EmitCompleted()
    {
        return new ResponseWebSearchCallCompletedEvent(
            _stream.NextSequenceNumber(), _outputIndex, _itemId);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a completed web search item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this web search call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemWebSearchToolCall(
            id: _itemId,
            status: ItemWebSearchToolCallStatus.Completed,
            action: new BinaryData("{}"));
        return EmitDone(item);
    }
}
