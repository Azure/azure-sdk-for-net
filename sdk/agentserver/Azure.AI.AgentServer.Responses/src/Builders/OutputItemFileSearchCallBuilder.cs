// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Scoped builder for a file search tool call output item. Provides methods
/// for the file search lifecycle: added, in-progress, searching, completed, done.
/// </summary>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
public class OutputItemFileSearchCallBuilder : OutputItemBuilder<OutputItemFileSearchToolCall>
{
    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemFileSearchCallBuilder"/>.
    /// </summary>
    internal OutputItemFileSearchCallBuilder(ResponseEventStream stream, long outputIndex, string itemId)
        : base(stream, outputIndex, itemId)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemFileSearchCallBuilder"/> for mocking.
    /// </summary>
    protected OutputItemFileSearchCallBuilder()
        : base()
    {
    }

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event with an in-progress file search item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this file search call.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded()
    {
        var item = new OutputItemFileSearchToolCall(Array.Empty<string>())
        {
            Id = _itemId,
            Status = FileSearchCallStatus.InProgress,
        };
        return EmitAdded(item);
    }

    /// <summary>
    /// Produces a <c>response.file_search_call.in_progress</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseFileSearchCallInProgressEvent"/>.</returns>
    public virtual ResponseFileSearchCallInProgressEvent EmitInProgress()
    {
        return new ResponseFileSearchCallInProgressEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), OutputIndex = (int)(_outputIndex), ItemId = _itemId };
    }

    /// <summary>
    /// Produces a <c>response.file_search_call.searching</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseFileSearchCallSearchingEvent"/>.</returns>
    public virtual ResponseFileSearchCallSearchingEvent EmitSearching()
    {
        return new ResponseFileSearchCallSearchingEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), OutputIndex = (int)(_outputIndex), ItemId = _itemId };
    }

    /// <summary>
    /// Produces a <c>response.file_search_call.completed</c> event.
    /// </summary>
    /// <returns>A <see cref="ResponseFileSearchCallCompletedEvent"/>.</returns>
    public virtual ResponseFileSearchCallCompletedEvent EmitCompleted()
    {
        return new ResponseFileSearchCallCompletedEvent { SequenceNumber = (int)(_stream.NextSequenceNumber()), OutputIndex = (int)(_outputIndex), ItemId = _itemId };
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event with a completed file search item.
    /// </summary>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this file search call.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone()
    {
        var item = new OutputItemFileSearchToolCall(Array.Empty<string>())
        {
            Id = _itemId,
            Status = FileSearchCallStatus.Completed,
        };
        return EmitDone(item);
    }
}
