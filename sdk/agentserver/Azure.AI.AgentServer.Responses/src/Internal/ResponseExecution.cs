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
/// State persistence is delegated to <see cref="ResponsesProvider"/>; event streaming and
/// sequence numbering are delegated to the Core event-stream primitive.
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
    /// Gets or sets whether this streaming execution's SSE events are relayed to the client through
    /// the per-response event-stream registry wire stream rather than the direct <c>result.Events</c>
    /// yield path. Set by the endpoint for every resilient (task-wrapped) streaming
    /// turn — background AND foreground — because the handler runs inside a decoupled Core task whose
    /// event enumerator is drained by the task body, so the client connection subscribes to the wire
    /// stream instead. When set, the orchestrator populates the registry publisher (so a foreground
    /// stream is not left on a <c>NullPublisher</c>) and routes the created/terminal events through the
    /// wire stream only after their Phase-1/Phase-2 persistence outcome is known, so the relayed
    /// sequence matches the corrected <c>result.Events</c> sequence (no <c>response.created</c> on a
    /// Phase-1 failure; <c>response.failed</c> — not <c>response.completed</c> — on a Phase-2 failure).
    /// </summary>
    public bool RelayViaRegistry { get; set; }

    /// <summary>
    /// Gets or sets the resolved session ID that was determined when this response was created.
    /// Stored at creation time so that subsequent operations (GET SSE replay, Cancel, DELETE)
    /// can emit the <c>x-agent-session-id</c> response header even before the handler yields
    /// <c>response.created</c> (when <see cref="Response"/> is still <c>null</c>).
    /// </summary>
    public string? AgentSessionId { get; set; }

    /// <summary>
    /// Gets or sets the user ID key that was present when this response was created.
    /// When non-null, all subsequent operations (GET, Cancel, DELETE, InputItems) must
    /// provide the same key; mismatches are treated as "not found" (404) to prevent
    /// information leakage across user partitions.
    /// </summary>
    public string? UserIdKey { get; set; }

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
    /// The canonical serialized bytes of the last snapshot durably persisted for this response
    /// (via <c>response.created</c>, a successful checkpoint, or a terminal write). Used to
    /// deduplicate checkpoint writes (FR-030 idempotency): a checkpoint whose snapshot is
    /// byte-identical to the last persisted snapshot is skipped. <c>null</c> until the first
    /// durable write.
    /// </summary>
    public byte[]? LastPersistedSnapshotBytes { get; set; }

    /// <summary>
    /// The number of output items already present in <see cref="ResponseContext.PersistedResponse"/>
    /// at the start of a crash-recovery re-invocation (0 on a normal, non-recovery invocation). The
    /// orchestrator seeds its output-item watermark from this value so a recovered handler that
    /// resumes from the durable snapshot (re-seeding the stream via the recovery
    /// <see cref="ResponseEventStream(ResponseContext, ResponseObject)"/> constructor) is not flagged
    /// by the direct-output-manipulation guard (B30/S-033) for the already-emitted items.
    /// </summary>
    public int RecoveredOutputWatermark { get; set; }

    /// <summary>
    /// Set when the handler defers this invocation to next-lifetime recovery via
    /// <see cref="ResponseContext.ExitForRecoveryAsync"/>. When set, finalization skips the
    /// pre-terminal persist so the last checkpoint snapshot is preserved (FR-036) and the
    /// acceptance-time recovery entry is retained (the durable status stays non-terminal).
    /// </summary>
    public bool DeferredForRecovery { get; set; }

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
    /// Gets or sets whether a steering supersession has been requested for this response — i.e. a
    /// new turn arrived for the same steerable conversation while this turn was still active, so
    /// the framework woke this turn (by cancelling its token) to let it wind down cooperatively.
    /// Distinct from <see cref="CancelRequested"/>: a steering-superseded turn reaches its own
    /// natural terminal (<see cref="ResponseStatus.Completed"/> with partial output preserved as
    /// valid conversation context) and is NOT marked <see cref="ResponseStatus.Cancelled"/> (FR-053).
    /// Written from the arbitration thread, read from the handler/finalization thread — Volatile.
    /// </summary>
    public bool SteeringRequested
    {
        get => Volatile.Read(ref _steeringRequested);
        set => Volatile.Write(ref _steeringRequested, value);
    }

    /// <summary>
    /// Wakes this active turn for steering supersession: sets <see cref="SteeringRequested"/> and
    /// cancels the execution token so a cooperative handler observing
    /// <see cref="ResponseContext.PendingInputCount"/> winds down to a natural terminal. Does NOT
    /// set <see cref="CancelRequested"/>, so the superseded turn is not marked cancelled.
    /// </summary>
    public void RequestSteering()
    {
        SteeringRequested = true;
        try
        {
            CancellationTokenSource.Cancel();
        }
        catch (ObjectDisposedException)
        {
            // The execution already finalized and disposed its CTS — nothing to wake.
        }
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

    /// <summary>
    /// Gets or sets whether persistence failed for this response.
    /// When <c>true</c>, the execution is kept in the tracker (not evicted) so that
    /// subsequent GET calls can serve the failed response from memory rather than
    /// returning 404. The response status will have been mutated to
    /// <see cref="ResponseStatus.Failed"/> with a storage error.
    /// Written from the finalization path, read from GET/Cancel/Delete paths.
    /// </summary>
    public bool PersistenceFailed
    {
        get => Volatile.Read(ref _persistenceFailed);
        set => Volatile.Write(ref _persistenceFailed, value);
    }

    /// <summary>
    /// Gets or sets the original exception that caused persistence to fail.
    /// Stored so that non-background, non-streaming callers can re-throw the
    /// actual storage error to the API consumer instead of a generic 500.
    /// </summary>
    public Exception? PersistenceException { get; set; }

    /// <summary>
    /// Gets or sets the exception that ended this streaming turn BEFORE <c>response.created</c> was
    /// emitted (a Phase-1 persistence failure or a handler that threw before yielding created). It is
    /// thrown on the task-body yield path, which the resilient relay never observes, so it is recorded
    /// here for the relay (<c>SubscribeBackgroundStreamAsync</c>) to surface as a standalone <c>error</c>
    /// SSE event with full fidelity — matching the inline streaming path (spec B8) instead of the
    /// generic <c>server_error</c> a bare relay cancellation/empty close would produce. Only meaningful
    /// for a task-wrapped streaming turn (<see cref="RelayViaRegistry"/>); ignored otherwise.
    /// </summary>
    public Exception? PreCreatedRelayFailure { get; set; }

    /// <summary>
    /// Gets or sets whether the streaming turn's terminal event was already persisted by the
    /// <c>CreateStreamingAsync</c> while-loop (the normal path: the handler yielded its own terminal,
    /// which is persisted BEFORE being written to the wire — spec "Option A"). When <c>false</c> and
    /// the response nonetheless reached <see cref="ResponseStatus.Completed"/> — e.g. the framework
    /// steering-completion fallback (<c>EmitTerminalCompletionAsync</c>) produced the terminal from the
    /// exception path — <c>FinalizeExecutionAsync</c> owns the durable persist so the client-visible
    /// <c>response.completed</c> is not left divergent from a non-terminal durable record (FR-053).
    /// Prevents a double-persist for the cooperative path where the while-loop already stored the terminal.
    /// </summary>
    public bool StreamingTerminalPersisted { get; set; }

    private bool _cancelRequested;
    private bool _shutdownRequested;
    private bool _steeringRequested;
    private bool _clientDisconnected;
    private bool _persistenceFailed;

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
    /// Enforces the user ID key for in-flight responses.
    /// If this execution was created with a user ID key, the caller must
    /// provide the same key; mismatches are treated as "not found" to prevent
    /// cross-user information leakage.
    /// </summary>
    /// <param name="context">The caller's platform context.</param>
    /// <exception cref="ResourceNotFoundException">
    /// Thrown when the execution has a user ID key and the caller's key does not match.
    /// </exception>
    public void EnforceUserIsolation(PlatformContext context)
    {
        if (UserIdKey is not null
            && !string.Equals(UserIdKey, context.UserIdKey, StringComparison.Ordinal))
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
