// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Top-level scope for building a streaming response event sequence.
/// Manages the global sequence counter and output index counter, and provides
/// factory methods for creating child scopes (message builders, function call builders).
/// Owns a private <see cref="Response"/> object that is embedded in emitted events.
/// </summary>
public class ResponseEventStream
{
    private readonly ResponseContext _context;
    private readonly Models.ResponseObject _response;
    private long _sequenceNumber;
    private long _outputIndex;

    /// <summary>
    /// Creates a new event stream that builds its own <see cref="Response"/> from the request.
    /// </summary>
    /// <param name="context">Context providing the response ID.</param>
    /// <param name="request">The original create request (used for Model, Instructions, Metadata).</param>
    public ResponseEventStream(ResponseContext context, CreateResponse request)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        ArgumentNullException.ThrowIfNull(request);

        var conversationId = request.GetConversationId();
        _response = new Models.ResponseObject(context.ResponseId, request.Model ?? string.Empty)
        {
            Metadata = request.Metadata!,
            AgentReference = request.AgentReference,
            Background = request.Background,
            Conversation = conversationId != null ? new ConversationReference(conversationId) : null,
            PreviousResponseId = request.PreviousResponseId,
        };
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseEventStream"/> for mocking.
    /// </summary>
    protected ResponseEventStream()
    {
        _context = null!;
        _response = null!;
    }

    // ── Public Properties ──────────────────────────────────────

    /// <summary>
    /// Gets the <see cref="Models.ResponseObject"/> object being constructed.
    /// Allows the handler to set any <see cref="Models.ResponseObject"/> property
    /// (e.g. <c>Metadata</c>, <c>Instructions</c>, <c>Temperature</c>)
    /// before calling <see cref="EmitCreated"/>.
    /// </summary>
    public Models.ResponseObject Response => _response;

    // ── Internal Properties (used by auto-stamping) ───────────

    /// <summary>Gets the response ID for auto-stamping output items.</summary>
    internal string ResponseId => _response.Id;

    /// <summary>Gets the agent reference for auto-stamping output items.</summary>
    internal AgentReference? AgentReference => _response.AgentReference;

    // ── Response Lifecycle Events ──────────────────────────────

    /// <summary>
    /// Produces a <c>response.queued</c> event.
    /// Sets <c>Status = Queued</c> before creating the event.
    /// </summary>
    /// <returns>A <see cref="ResponseQueuedEvent"/> with the current response snapshot.</returns>
    public virtual ResponseQueuedEvent EmitQueued()
    {
        _response.Status = ResponseStatus.Queued;
        return new ResponseQueuedEvent(NextSequenceNumber(), _response);
    }

    /// <summary>
    /// Produces a <c>response.created</c> event.
    /// Sets <c>Status</c> to the specified value before creating the event.
    /// Use <see cref="ResponseStatus.Queued"/> when the response will go through
    /// a queued phase before processing; use <see cref="ResponseStatus.InProgress"/>
    /// (the default) to start processing immediately.
    /// </summary>
    /// <param name="status">
    /// The initial response status. Defaults to <see cref="ResponseStatus.InProgress"/>.
    /// </param>
    /// <returns>A <see cref="ResponseCreatedEvent"/> with the current response snapshot.</returns>
    public virtual ResponseCreatedEvent EmitCreated(ResponseStatus status = ResponseStatus.InProgress)
    {
        _response.Status = status;
        return new ResponseCreatedEvent(NextSequenceNumber(), _response);
    }

    /// <summary>
    /// Produces a <c>response.in_progress</c> event.
    /// Sets <c>Status = InProgress</c> before creating the event.
    /// </summary>
    /// <returns>A <see cref="ResponseInProgressEvent"/> with the current response snapshot.</returns>
    public virtual ResponseInProgressEvent EmitInProgress()
    {
        _response.Status = ResponseStatus.InProgress;
        return new ResponseInProgressEvent(NextSequenceNumber(), _response);
    }

    /// <summary>
    /// Produces a <c>response.completed</c> event.
    /// Sets <c>Status = Completed</c>, <c>CompletedAt</c>, and <c>Usage</c>
    /// before creating the event.
    /// </summary>
    /// <param name="usage">Optional token usage data to include in the response.</param>
    /// <returns>A <see cref="ResponseCompletedEvent"/> with the finalized response.</returns>
    public virtual ResponseCompletedEvent EmitCompleted(ResponseUsage? usage = null)
    {
        _response.SetCompleted(usage);
        return new ResponseCompletedEvent(NextSequenceNumber(), _response);
    }

    /// <summary>
    /// Produces a <c>response.failed</c> event.
    /// Sets <c>Status = Failed</c>, <c>CompletedAt</c>, <c>Error</c>,
    /// and <c>Usage</c> (if provided) before creating the event.
    /// </summary>
    /// <param name="code">The error code. Defaults to <see cref="ResponseErrorCode.ServerError"/>.</param>
    /// <param name="message">The error message. Defaults to "An internal server error occurred.".</param>
    /// <param name="usage">Optional token usage data to include in the response.</param>
    /// <returns>A <see cref="ResponseFailedEvent"/> with the finalized response.</returns>
    public virtual ResponseFailedEvent EmitFailed(
        ResponseErrorCode code = ResponseErrorCode.ServerError,
        string message = "An internal server error occurred.",
        ResponseUsage? usage = null)
    {
        _response.SetFailed(code, message, usage);
        return new ResponseFailedEvent(NextSequenceNumber(), _response);
    }

    /// <summary>
    /// Produces a <c>response.incomplete</c> event.
    /// Sets <c>Status = Incomplete</c>, <c>CompletedAt</c>, <c>IncompleteDetails</c>,
    /// and <c>Usage</c> (if provided) before creating the event.
    /// </summary>
    /// <param name="reason">Optional reason for incompleteness.</param>
    /// <param name="usage">Optional token usage data to include in the response.</param>
    /// <returns>A <see cref="ResponseIncompleteEvent"/> with the finalized response.</returns>
    public virtual ResponseIncompleteEvent EmitIncomplete(
        ResponseIncompleteDetailsReason? reason = null,
        ResponseUsage? usage = null)
    {
        _response.SetIncomplete(reason, usage);
        return new ResponseIncompleteEvent(NextSequenceNumber(), _response);
    }

    // ── Output Item Accumulation ──────────────────────────────

    /// <summary>
    /// Called by builders when an output item is finalized via <c>EmitDone()</c>.
    /// Accumulates the item in the stream-owned <c>Response.Output</c> at the given index.
    /// </summary>
    /// <param name="item">The completed output item.</param>
    /// <param name="outputIndex">The zero-based output index for this item.</param>
    internal void TrackCompletedOutputItem(OutputItem item, long outputIndex)
    {
        _response.Output.SetOutputItemAtIndex((int)outputIndex, item);
    }

    // ── Output Item Scope Factories ───────────────────────────

    /// <summary>
    /// Creates a message output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemMessageBuilder"/> for the message output item.</returns>
    public virtual OutputItemMessageBuilder AddOutputItemMessage()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewMessageItemId(_context.ResponseId);
        return new OutputItemMessageBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a function call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="callId">The call ID for this function call.</param>
    /// <returns>A new <see cref="OutputItemFunctionCallBuilder"/> for the function call output item.</returns>
    public virtual OutputItemFunctionCallBuilder AddOutputItemFunctionCall(string name, string callId)
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewFunctionCallItemId(_context.ResponseId);
        return new OutputItemFunctionCallBuilder(this, outputIndex, itemId, name, callId);
    }

    /// <summary>
    /// Creates a reasoning output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemReasoningItemBuilder"/> for the reasoning output item.</returns>
    public virtual OutputItemReasoningItemBuilder AddOutputItemReasoningItem()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewReasoningItemId(_context.ResponseId);
        return new OutputItemReasoningItemBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a file search call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemFileSearchCallBuilder"/> for the file search call output item.</returns>
    public virtual OutputItemFileSearchCallBuilder AddOutputItemFileSearchCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewFileSearchCallItemId(_context.ResponseId);
        return new OutputItemFileSearchCallBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a web search call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemWebSearchCallBuilder"/> for the web search call output item.</returns>
    public virtual OutputItemWebSearchCallBuilder AddOutputItemWebSearchCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewWebSearchCallItemId(_context.ResponseId);
        return new OutputItemWebSearchCallBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a code interpreter call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemCodeInterpreterCallBuilder"/> for the code interpreter call output item.</returns>
    public virtual OutputItemCodeInterpreterCallBuilder AddOutputItemCodeInterpreterCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewCodeInterpreterCallItemId(_context.ResponseId);
        return new OutputItemCodeInterpreterCallBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an image generation call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemImageGenCallBuilder"/> for the image generation call output item.</returns>
    public virtual OutputItemImageGenCallBuilder AddOutputItemImageGenCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewImageGenCallItemId(_context.ResponseId);
        return new OutputItemImageGenCallBuilder(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an MCP tool call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <param name="serverLabel">The MCP server label.</param>
    /// <param name="name">The tool name.</param>
    /// <returns>A new <see cref="OutputItemMcpCallBuilder"/> for the MCP tool call output item.</returns>
    public virtual OutputItemMcpCallBuilder AddOutputItemMcpCall(string serverLabel, string name)
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewMcpCallItemId(_context.ResponseId);
        return new OutputItemMcpCallBuilder(this, outputIndex, itemId, serverLabel, name);
    }

    /// <summary>
    /// Creates an MCP list-tools output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <param name="serverLabel">The MCP server label.</param>
    /// <returns>A new <see cref="OutputItemMcpListToolsBuilder"/> for the MCP list-tools output item.</returns>
    public virtual OutputItemMcpListToolsBuilder AddOutputItemMcpListTools(string serverLabel)
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewMcpListToolsItemId(_context.ResponseId);
        return new OutputItemMcpListToolsBuilder(this, outputIndex, itemId, serverLabel);
    }

    /// <summary>
    /// Creates a custom tool call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <param name="callId">The call ID for the custom tool call.</param>
    /// <param name="name">The tool name.</param>
    /// <returns>A new <see cref="OutputItemCustomToolCallBuilder"/> for the custom tool call output item.</returns>
    public virtual OutputItemCustomToolCallBuilder AddOutputItemCustomToolCall(string callId, string name)
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewCustomToolCallItemId(_context.ResponseId);
        return new OutputItemCustomToolCallBuilder(this, outputIndex, itemId, callId, name);
    }

    /// <summary>
    /// Creates an output item scope with the next output index.
    /// Use for output item types that have no dedicated <c>Add*()</c> factory
    /// and no streaming sub-events (no deltas, no status transitions).
    /// Call <see cref="OutputItemBuilder{T}.EmitAdded(T)"/> and
    /// <see cref="OutputItemBuilder{T}.EmitDone(T)"/> on the
    /// returned builder, passing the item to each call.
    /// </summary>
    /// <typeparam name="T">The concrete <see cref="OutputItem"/> subtype.</typeparam>
    /// <param name="itemId">The item ID. Must be in a valid format (use <see cref="IdGenerator"/>).</param>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the output item.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="itemId"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="itemId"/> is not in a valid ID format.</exception>
    public virtual OutputItemBuilder<T> AddOutputItem<T>(string itemId) where T : Models.OutputItem
    {
        ArgumentNullException.ThrowIfNull(itemId);

        if (!IdGenerator.IsValid(itemId, out var error))
        {
            throw new ArgumentException($"Invalid item ID '{itemId}': {error}", nameof(itemId));
        }

        var outputIndex = _outputIndex++;
        return new OutputItemBuilder<T>(this, outputIndex, itemId);
    }

    // ── Raw Event Interop ─────────────────────────────────────

    /// <summary>
    /// Returns the next sequence number for use with manually constructed events.
    /// Uses post-increment semantics: returns the current value and then increments.
    /// </summary>
    /// <returns>The next sequence number.</returns>
    public virtual long NextSequenceNumber() => _sequenceNumber++;
}
