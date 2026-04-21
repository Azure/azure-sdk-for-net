// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Lightweight pipeline context for a single in-flight or recently-completed response execution.
/// <para>
/// <see cref="Response"/> is <c>null</c> until the handler yields <c>response.created</c>
/// and the orchestrator calls <see cref="ResponseMutations.ReplaceResponse"/>. Code that
/// needs to distinguish pre-created from post-created state should null-check
/// <see cref="Response"/> instead of maintaining a separate boolean flag.
/// </para>
/// State persistence, event streaming, and sequence numbering are delegated to
/// <see cref="ResponsesProvider"/> and <see cref="SeekableReplaySubject"/>.
/// </summary>
internal sealed class ResponseExecution : IDisposable
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResponseExecution"/>.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="isBackground">Whether the response was created with <c>background=true</c>.</param>
    /// <param name="isStreaming">Whether the response was created with <c>stream=true</c>.</param>
    /// <param name="store">Whether the response should be stored for later retrieval.</param>
    public ResponseExecution(string responseId,
        bool isBackground = false, bool isStreaming = false, bool store = true)
    {
        ResponseId = responseId;
        IsBackground = isBackground;
        IsStreaming = isStreaming;
        Store = store;
        CancellationTokenSource = new CancellationTokenSource();
    }

    /// <summary>Gets the unique response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets whether the response was created with <c>background=true</c>.</summary>
    public bool IsBackground { get; }

    /// <summary>Gets whether the response was created with <c>stream=true</c>.</summary>
    public bool IsStreaming { get; }

    /// <summary>Gets whether the response should be stored for later retrieval.</summary>
    public bool Store { get; }

    /// <summary>
    /// Gets or sets the resolved session ID that was determined when this response was created.
    /// Stored at creation time so that subsequent operations (GET SSE replay, Cancel, DELETE)
    /// can emit the <c>x-agent-session-id</c> response header even before the handler yields
    /// <c>response.created</c> (when <see cref="Response"/> is still <c>null</c>).
    /// </summary>
    public string? AgentSessionId { get; set; }

    /// <summary>
    /// Gets or sets the chat isolation key that was present when this response was created.
    /// When non-null, all subsequent operations (GET, Cancel, DELETE, InputItems) must
    /// provide the same key; mismatches are treated as "not found" (404) to prevent
    /// information leakage across chat partitions.
    /// </summary>
    public string? ChatIsolationKey { get; set; }

    /// <summary>
    /// Gets or sets the mutable response object (accumulator for the current pipeline).
    /// <c>null</c> until the handler yields <c>response.created</c> and
    /// <see cref="ResponseMutations.ReplaceResponse"/> sets it.
    /// </summary>
    public Models.ResponseObject? Response { get; set; }

    /// <summary>Gets the cancellation token source for this execution (used by StopAsync for shutdown).</summary>
    public CancellationTokenSource CancellationTokenSource { get; }

    /// <summary>Gets or sets the background task running the handler (if applicable).</summary>
    public Task? ExecutionTask { get; set; }

    /// <summary>
    /// Tracks the highest sequence number emitted by <see cref="ResponseOrchestrator.ProcessEventsAsync"/>
    /// so that SDK-synthesized terminal events (error recovery, cancellation) can continue
    /// the monotonic sequence (B9) instead of hardcoding 0.
    /// </summary>
    public long LastEmittedSequenceNumber { get; set; } = -1;

    /// <summary>
    /// Gets or sets whether an explicit cancel request has been issued for this response.
    /// Used by handler code to distinguish cancellation from timeout/disconnect.
    /// Written from cancel endpoint thread, read from handler thread — uses Volatile for visibility.
    /// </summary>
    public bool CancelRequested
    {
        get => Volatile.Read(ref _cancelRequested);
        set => Volatile.Write(ref _cancelRequested, value);
    }

    /// <summary>
    /// Gets or sets whether a graceful shutdown has been requested for this response.
    /// Set by <see cref="ResponseExecutionTracker.StopAsync"/> before cancelling the CTS.
    /// Handlers can check <see cref="ResponseContext.IsShutdownRequested"/> to distinguish
    /// shutdown from explicit cancel or client disconnect.
    /// Written from shutdown thread, read from handler thread — uses Volatile for visibility.
    /// </summary>
    public bool ShutdownRequested
    {
        get => Volatile.Read(ref _shutdownRequested);
        set => Volatile.Write(ref _shutdownRequested, value);
    }

    /// <summary>
    /// Gets or sets whether the HTTP client has disconnected.
    /// Set by <see cref="ResponseEndpointHandler"/> when <c>httpContext.RequestAborted</c> fires
    /// for non-background modes. Used by the orchestrator to distinguish client disconnect
    /// (→ cancelled) from unknown cancellation (→ failed).
    /// Written from RequestAborted callback thread, read from handler thread — uses Volatile for visibility.
    /// </summary>
    public bool ClientDisconnected
    {
        get => Volatile.Read(ref _clientDisconnected);
        set => Volatile.Write(ref _clientDisconnected, value);
    }

    private bool _cancelRequested;
    private bool _shutdownRequested;
    private bool _clientDisconnected;

    /// <summary>
    /// Gets or sets the response context associated with this execution.
    /// Used by <see cref="ResponseExecutionTracker.StopAsync"/> to propagate
    /// <see cref="ResponseContext.IsShutdownRequested"/> to the handler.
    /// </summary>
    public ResponseContext? Context { get; set; }

    /// <summary>
    /// Signal that completes when the handler yields <c>response.created</c> (with the
    /// handler-provided <see cref="Response"/>), or faults if the handler fails before
    /// emitting it. Used by the background non-streaming path to wait for the handler's
    /// response before returning to the client.
    /// </summary>
    public TaskCompletionSource<Models.ResponseObject> ResponseCreatedSignal { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    /// <summary>
    /// Signal that completes when <see cref="ResponseOrchestrator.FinalizeExecutionAsync"/>
    /// finishes — the response is in its final terminal state and has been persisted.
    /// <see cref="ResponseOrchestrator.CancelAsync"/> awaits this (with a 10-second timeout)
    /// so that the cancel endpoint always returns the finalized cancelled snapshot,
    /// regardless of streaming vs non-streaming mode.
    /// </summary>
    public TaskCompletionSource FinalizedSignal { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    /// <summary>
    /// Enforces chat isolation key for in-flight responses.
    /// If this execution was created with a chat isolation key, the caller must
    /// provide the same key; mismatches are treated as "not found" to prevent
    /// cross-chat information leakage.
    /// </summary>
    /// <param name="isolation">The caller's isolation context.</param>
    /// <exception cref="ResourceNotFoundException">
    /// Thrown when the execution has a chat isolation key and the caller's key does not match.
    /// </exception>
    public void EnforceChatIsolation(IsolationContext isolation)
    {
        if (ChatIsolationKey is not null
            && !string.Equals(ChatIsolationKey, isolation.ChatIsolationKey, StringComparison.Ordinal))
        {
            throw new ResourceNotFoundException($"Response '{ResponseId}' not found.");
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        CancellationTokenSource.Cancel();
        CancellationTokenSource.Dispose();
    }
}
