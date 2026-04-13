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
    /// Creates a structured outputs item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the structured outputs item.</returns>
    public virtual OutputItemBuilder<StructuredOutputsOutputItem> AddOutputItemStructuredOutputs()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewStructuredOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<StructuredOutputsOutputItem>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a computer tool call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the computer tool call output item.</returns>
    public virtual OutputItemBuilder<OutputItemComputerToolCall> AddOutputItemComputerCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewComputerCallItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemComputerToolCall>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a computer tool call output result scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the computer tool call output result.</returns>
    public virtual OutputItemBuilder<OutputItemComputerToolCallOutputResource> AddOutputItemComputerCallOutput()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewComputerCallOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemComputerToolCallOutputResource>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a local shell call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the local shell call output item.</returns>
    public virtual OutputItemBuilder<OutputItemLocalShellToolCall> AddOutputItemLocalShellCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewLocalShellCallItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemLocalShellToolCall>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a local shell call output result scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the local shell call output result.</returns>
    public virtual OutputItemBuilder<OutputItemLocalShellToolCallOutput> AddOutputItemLocalShellCallOutput()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewLocalShellCallOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemLocalShellToolCallOutput>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a function shell call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the function shell call output item.</returns>
    public virtual OutputItemBuilder<OutputItemFunctionShellCall> AddOutputItemFunctionShellCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewFunctionShellCallItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemFunctionShellCall>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a function shell call output result scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the function shell call output result.</returns>
    public virtual OutputItemBuilder<OutputItemFunctionShellCallOutput> AddOutputItemFunctionShellCallOutput()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewFunctionShellCallOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemFunctionShellCallOutput>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an apply-patch call output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the apply-patch call output item.</returns>
    public virtual OutputItemBuilder<OutputItemApplyPatchToolCall> AddOutputItemApplyPatchCall()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewApplyPatchCallItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemApplyPatchToolCall>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an apply-patch call output result scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the apply-patch call output result.</returns>
    public virtual OutputItemBuilder<OutputItemApplyPatchToolCallOutput> AddOutputItemApplyPatchCallOutput()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewApplyPatchCallOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemApplyPatchToolCallOutput>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a custom tool call output result scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the custom tool call output result.</returns>
    public virtual OutputItemBuilder<OutputItemCustomToolCallOutput> AddOutputItemCustomToolCallOutput()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewCustomToolCallOutputItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemCustomToolCallOutput>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an MCP approval request output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the MCP approval request output item.</returns>
    public virtual OutputItemBuilder<OutputItemMcpApprovalRequest> AddOutputItemMcpApprovalRequest()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewMcpApprovalRequestItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemMcpApprovalRequest>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates an MCP approval response output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the MCP approval response output item.</returns>
    public virtual OutputItemBuilder<OutputItemMcpApprovalResponseResource> AddOutputItemMcpApprovalResponse()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewMcpApprovalResponseItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemMcpApprovalResponseResource>(this, outputIndex, itemId);
    }

    /// <summary>
    /// Creates a compaction output item scope with the next output index
    /// and an auto-generated item ID.
    /// </summary>
    /// <returns>A new <see cref="OutputItemBuilder{T}"/> for the compaction output item.</returns>
    public virtual OutputItemBuilder<OutputItemCompactionBody> AddOutputItemCompaction()
    {
        var outputIndex = _outputIndex++;
        var itemId = IdGenerator.NewCompactionItemId(_context.ResponseId);
        return new OutputItemBuilder<OutputItemCompactionBody>(this, outputIndex, itemId);
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

    // ── Output-Item Convenience Generators (S-056/S-057/S-058) ──

    /// <summary>
    /// Convenience generator that yields the complete message output-item lifecycle
    /// with a single text content part from a complete string (S-056).
    /// </summary>
    /// <param name="text">The complete message text.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → text content convenience → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemMessage(string text)
    {
        return OutputItemMessage(text, Array.Empty<Annotation>());
    }

    /// <summary>
    /// Convenience generator that yields the complete message output-item lifecycle
    /// with a single text content part and annotations (S-056).
    /// </summary>
    /// <param name="text">The complete message text.</param>
    /// <param name="annotations">The annotations to attach to the text content part.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → text content convenience (with annotations) → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemMessage(
        string text, IEnumerable<Annotation> annotations)
    {
        var builder = AddOutputItemMessage();
        yield return builder.EmitAdded();
        foreach (var evt in builder.TextContent(text, annotations))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete message output-item lifecycle
    /// with a single text content part from streaming chunks (S-056, S-058).
    /// </summary>
    /// <param name="chunks">An async enumerable of text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>output_item.added</c> → text content convenience → <c>output_item.done</c>.</returns>
    public async IAsyncEnumerable<ResponseStreamEvent> OutputItemMessage(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddOutputItemMessage();
        yield return builder.EmitAdded();
        await foreach (var evt in builder.TextContent(chunks, cancellationToken).ConfigureAwait(false))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete function call output-item lifecycle
    /// with arguments from a complete string (S-056).
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="callId">The call ID.</param>
    /// <param name="arguments">The complete arguments JSON string.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → arguments convenience → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemFunctionCall(string name, string callId, string arguments)
    {
        var builder = AddOutputItemFunctionCall(name, callId);
        yield return builder.EmitAdded();
        foreach (var evt in builder.Arguments(arguments))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete function call output-item lifecycle
    /// with arguments from streaming chunks (S-056, S-058).
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="callId">The call ID.</param>
    /// <param name="chunks">An async enumerable of argument chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>output_item.added</c> → arguments convenience → <c>output_item.done</c>.</returns>
    public async IAsyncEnumerable<ResponseStreamEvent> OutputItemFunctionCall(
        string name,
        string callId,
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddOutputItemFunctionCall(name, callId);
        yield return builder.EmitAdded();
        await foreach (var evt in builder.Arguments(chunks, cancellationToken).ConfigureAwait(false))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete function call output item lifecycle
    /// (S-056). Function call outputs have no deltas — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the function call this output is for.</param>
    /// <param name="output">The output data from the function call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemFunctionCallOutput(string callId, BinaryData output)
    {
        var itemId = IdGenerator.NewFunctionCallOutputItemId(_context.ResponseId);
        var builder = AddOutputItem<FunctionToolCallOutputResource>(itemId);
        var item = new FunctionToolCallOutputResource(callId, output);
        item.Id = itemId;
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete reasoning output-item lifecycle
    /// with a single summary part from a complete string (S-056).
    /// </summary>
    /// <param name="summaryText">The complete summary text.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → summary part convenience → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemReasoningItem(string summaryText)
    {
        var builder = AddOutputItemReasoningItem();
        yield return builder.EmitAdded();
        foreach (var evt in builder.SummaryPart(summaryText))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete reasoning output-item lifecycle
    /// with a single summary part from streaming chunks (S-056, S-058).
    /// </summary>
    /// <param name="chunks">An async enumerable of summary text chunks.</param>
    /// <param name="cancellationToken">A token to cancel iteration.</param>
    /// <returns>An async enumerable of events: <c>output_item.added</c> → summary part convenience → <c>output_item.done</c>.</returns>
    public async IAsyncEnumerable<ResponseStreamEvent> OutputItemReasoningItem(
        IAsyncEnumerable<string> chunks,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var builder = AddOutputItemReasoningItem();
        yield return builder.EmitAdded();
        await foreach (var evt in builder.SummaryPart(chunks, cancellationToken).ConfigureAwait(false))
        {
            yield return evt;
        }
        yield return builder.EmitDone();
    }

    /// <summary>
    /// Convenience generator that yields the complete image generation call output-item lifecycle
    /// from a final base64-encoded image result.
    /// </summary>
    /// <param name="resultBase64">
    /// The base64-encoded image data (PNG, JPEG, or WebP). For example:
    /// <c>Convert.ToBase64String(imageBytes)</c>.
    /// </param>
    /// <returns>
    /// An enumerable of events: <c>output_item.added</c> → <c>image_gen_call.in_progress</c> →
    /// <c>image_gen_call.generating</c> → <c>image_gen_call.completed</c> → <c>output_item.done</c>.
    /// </returns>
    /// <remarks>
    /// For streaming partial images (progressive rendering), use
    /// <see cref="AddOutputItemImageGenCall"/> to get a builder and call
    /// <see cref="OutputItemImageGenCallBuilder.EmitPartialImage"/> between
    /// <c>EmitGenerating()</c> and <c>EmitCompleted()</c>.
    /// </remarks>
    public IEnumerable<ResponseStreamEvent> OutputItemImageGenCall(string resultBase64)
    {
        var builder = AddOutputItemImageGenCall();
        yield return builder.EmitAdded();
        yield return builder.EmitInProgress();
        yield return builder.EmitGenerating();
        yield return builder.EmitCompleted();
        yield return builder.EmitDone(resultBase64);
    }

    /// <summary>
    /// Convenience generator that yields the complete structured outputs item lifecycle.
    /// Use this to return any open-ended structured information as a JSON object. This is
    /// useful when none of the existing output item types (message, function call, image, etc.)
    /// fit your use case — for example, returning analytics results, classification labels,
    /// form data, or any custom JSON payload.
    /// </summary>
    /// <param name="output">
    /// The structured data to return. Use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>
    /// to serialize a strongly typed object, or <see cref="BinaryData.FromString(string)"/> to pass raw JSON.
    /// <para>
    /// Example:
    /// <c>BinaryData.FromObjectAsJson(new { sentiment = "positive", confidence = 0.95 })</c>
    /// </para>
    /// </param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemStructuredOutputs(BinaryData output)
    {
        var builder = AddOutputItemStructuredOutputs();
        var item = new StructuredOutputsOutputItem(output, builder.ItemId);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete computer tool call output-item lifecycle.
    /// Computer call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the computer tool call.</param>
    /// <param name="action">The computer action to perform.</param>
    /// <param name="pendingSafetyChecks">The safety checks that must pass before execution.</param>
    /// <param name="status">The status of the computer tool call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemComputerCall(
        string callId,
        ComputerAction action,
        IEnumerable<ComputerCallSafetyCheckParam> pendingSafetyChecks,
        OutputItemComputerToolCallStatus status)
    {
        var builder = AddOutputItemComputerCall();
        var item = new OutputItemComputerToolCall(builder.ItemId, callId, action, pendingSafetyChecks, status);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete computer tool call output resource lifecycle.
    /// Computer call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the computer tool call this output is for.</param>
    /// <param name="output">The screenshot image output from the computer tool.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemComputerCallOutput(
        string callId,
        ComputerScreenshotImage output)
    {
        var builder = AddOutputItemComputerCallOutput();
        var item = new OutputItemComputerToolCallOutputResource(callId, output);
        item.Id = builder.ItemId;
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete local shell tool call lifecycle.
    /// Local shell calls have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID for the shell call.</param>
    /// <param name="action">The shell exec action to perform.</param>
    /// <param name="status">The status of the shell tool call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemLocalShellCall(
        string callId,
        LocalShellExecAction action,
        OutputItemLocalShellToolCallStatus status)
    {
        var builder = AddOutputItemLocalShellCall();
        var item = new OutputItemLocalShellToolCall(builder.ItemId, callId, action, status);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete local shell tool call output lifecycle.
    /// Local shell call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="output">The output text from the shell command.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemLocalShellCallOutput(string output)
    {
        var builder = AddOutputItemLocalShellCallOutput();
        var item = new OutputItemLocalShellToolCallOutput(builder.ItemId, output);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete function shell call lifecycle.
    /// Function shell calls have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID for the function shell call.</param>
    /// <param name="action">The function shell action to perform.</param>
    /// <param name="status">The status of the function shell call.</param>
    /// <param name="environment">The execution environment for the shell call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemFunctionShellCall(
        string callId,
        FunctionShellAction action,
        LocalShellCallStatus status,
        FunctionShellCallEnvironment environment)
    {
        var builder = AddOutputItemFunctionShellCall();
        var item = new OutputItemFunctionShellCall(builder.ItemId, callId, action, status, environment);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete function shell call output lifecycle.
    /// Function shell call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the function shell call this output is for.</param>
    /// <param name="status">The output status.</param>
    /// <param name="output">The output content from the shell call.</param>
    /// <param name="maxOutputLength">Optional maximum output length.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemFunctionShellCallOutput(
        string callId,
        LocalShellCallOutputStatusEnum status,
        IEnumerable<FunctionShellCallOutputContent> output,
        long? maxOutputLength = null)
    {
        var builder = AddOutputItemFunctionShellCallOutput();
        var item = new OutputItemFunctionShellCallOutput(builder.ItemId, callId, status, output, maxOutputLength);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete apply-patch tool call lifecycle.
    /// Apply-patch calls have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID for the apply-patch call.</param>
    /// <param name="status">The status of the apply-patch call.</param>
    /// <param name="operation">The file operation to apply.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemApplyPatchCall(
        string callId,
        ApplyPatchCallStatus status,
        ApplyPatchFileOperation operation)
    {
        var builder = AddOutputItemApplyPatchCall();
        var item = new OutputItemApplyPatchToolCall(builder.ItemId, callId, status, operation);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete apply-patch tool call output lifecycle.
    /// Apply-patch call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the apply-patch call this output is for.</param>
    /// <param name="status">The output status.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemApplyPatchCallOutput(
        string callId,
        ApplyPatchCallOutputStatus status)
    {
        var builder = AddOutputItemApplyPatchCallOutput();
        var item = new OutputItemApplyPatchToolCallOutput(builder.ItemId, callId, status);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete custom tool call output lifecycle.
    /// Custom tool call outputs have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="callId">The call ID of the custom tool call this output is for.</param>
    /// <param name="output">The output data from the custom tool call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemCustomToolCallOutput(string callId, BinaryData output)
    {
        var builder = AddOutputItemCustomToolCallOutput();
        var item = new OutputItemCustomToolCallOutput(callId, output);
        item.Id = builder.ItemId;
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete MCP approval request lifecycle.
    /// MCP approval requests have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="serverLabel">The label of the MCP server.</param>
    /// <param name="name">The name of the tool requiring approval.</param>
    /// <param name="arguments">The arguments JSON for the tool call.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemMcpApprovalRequest(
        string serverLabel,
        string name,
        string arguments)
    {
        var builder = AddOutputItemMcpApprovalRequest();
        var item = new OutputItemMcpApprovalRequest(builder.ItemId, serverLabel, name, arguments);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete MCP approval response lifecycle.
    /// MCP approval responses have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="approvalRequestId">The ID of the approval request being responded to.</param>
    /// <param name="approve">Whether the MCP tool call is approved.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemMcpApprovalResponse(
        string approvalRequestId,
        bool approve)
    {
        var builder = AddOutputItemMcpApprovalResponse();
        var item = new OutputItemMcpApprovalResponseResource(builder.ItemId, approvalRequestId, approve);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    /// <summary>
    /// Convenience generator that yields the complete compaction output-item lifecycle.
    /// Compaction items have no intermediate events — only <c>output_item.added</c> and
    /// <c>output_item.done</c>.
    /// </summary>
    /// <param name="encryptedContent">The encrypted compaction content.</param>
    /// <returns>An enumerable of events: <c>output_item.added</c> → <c>output_item.done</c>.</returns>
    public IEnumerable<ResponseStreamEvent> OutputItemCompaction(string encryptedContent)
    {
        var builder = AddOutputItemCompaction();
        var item = new OutputItemCompactionBody(builder.ItemId, encryptedContent);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);
    }

    // ── Raw Event Interop ─────────────────────────────────────

    /// <summary>
    /// Returns the next sequence number for use with manually constructed events.
    /// Uses post-increment semantics: returns the current value and then increments.
    /// </summary>
    /// <returns>The next sequence number.</returns>
    public virtual long NextSequenceNumber() => _sequenceNumber++;
}
