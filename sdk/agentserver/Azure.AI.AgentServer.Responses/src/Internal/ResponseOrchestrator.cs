// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Transport-agnostic orchestration layer for response lifecycle management.
/// Encapsulates event consumption, error recovery, persistence, and terminal
/// state transitions — logic previously duplicated across
/// <see cref="ResponseEndpointHandler"/> and <see cref="SseResult"/>.
/// </summary>
internal sealed class ResponseOrchestrator
{
    private readonly ResponseHandler _handler;
    private readonly ResponsesProvider _provider;
    private readonly ResponsesCancellationSignalProvider _cancellationProvider;
    private readonly IEventStreamRegistry _eventStreamRegistry;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ILogger<ResponseOrchestrator> _logger;
    private readonly bool _resilientBackground;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseOrchestrator"/>.
    /// </summary>
    public ResponseOrchestrator(
        ResponseHandler handler,
        ResponsesProvider provider,
        ResponsesCancellationSignalProvider cancellationProvider,
        IEventStreamRegistry eventStreamRegistry,
        ResponseExecutionTracker tracker,
        ILogger<ResponseOrchestrator> logger,
        IOptions<ResponsesServerOptions> options)
    {
        _handler = handler;
        _provider = provider;
        _cancellationProvider = cancellationProvider;
        _eventStreamRegistry = eventStreamRegistry;
        _tracker = tracker;
        _logger = logger;
        _resilientBackground = options.Value.ResilientBackground;
    }

    // --- Status Helpers ---

    /// <summary>
    /// Determines whether a <see cref="ResponseStatus"/> represents a terminal state.
    /// </summary>
    internal static bool IsTerminalStatus(ResponseStatus? status) =>
        status is ResponseStatus.Completed
            or ResponseStatus.Failed
            or ResponseStatus.Incomplete
            or ResponseStatus.Cancelled;

    /// <summary>
    /// Determines whether a <see cref="ResponseStatus"/> represents a non-cancelled terminal state.
    /// </summary>
    internal static bool IsNonCancelledTerminal(ResponseStatus? status) =>
        status is ResponseStatus.Completed
            or ResponseStatus.Failed
            or ResponseStatus.Incomplete;

    /// <summary>
    /// Processes a Create response request through the handler.
    /// For non-streaming modes: consumes all handler events synchronously and returns
    /// the final Response.
    /// For streaming modes: returns an <see cref="IAsyncEnumerable{T}"/> of processed events
    /// that the caller (<see cref="SseResult"/>) can write to the SSE wire format.
    /// </summary>
    /// <param name="request">The deserialized CreateResponse request.</param>
    /// <param name="execution">The <see cref="ResponseExecution"/> tracking this request.</param>
    /// <param name="context">The <see cref="ResponseContext"/> passed to the handler.</param>
    /// <param name="ct">
    /// Cancellation token assembled by the endpoint handler. Includes
    /// httpContext.RequestAborted for non-background modes.
    /// </param>
    /// <returns>
    /// An <see cref="OrchestratorResult"/> — either
    /// <see cref="OrchestratorResult.Completed(Models.ResponseObject)"/> or
    /// <see cref="OrchestratorResult.Streaming(IAsyncEnumerable{ResponseStreamEvent})"/>.
    /// </returns>
    public async Task<OrchestratorResult> CreateAsync(
        CreateResponse request,
        ResponseExecution execution,
        ResponseContext context,
        CancellationToken ct)
    {
        if (execution.IsStreaming)
        {
            // Streaming: return a lazy event stream. Error recovery + finalization
            // happen inside the stream when the consumer iterates it.
            var events = CreateStreamingAsync(request, execution, context, ct);
            return OrchestratorResult.Streaming(events);
        }

        // Non-streaming: consume all events, apply error recovery, finalize, return completed.
        // Non-streaming responses are never eligible for SSE replay (B2 requires both
        // background=true AND stream=true), so a NullPublisher that assigns sequence
        // numbers without buffering is sufficient — avoids creating a Core event stream.
        IAsyncObserver<ResponseStreamEvent> publisher = new NullPublisher();
        try
        {
            await foreach (var _ in ProcessEventsAsync(request, execution, context, publisher, ct)
                .WithCancellation(ct))
            {
                // Consume — non-streaming just accumulates state.
            }

            // A handler may have swallowed the ExitForRecoveryAsync() signal with a broad catch and
            // returned normally. Honor the deferral intent so the outcome is identical to the
            // caught-signal path (FR-036); this must run before EnsureTerminalOrFailAsync so the
            // response is not mistaken for a bad handler that ended without a terminal event.
            ObserveSwallowedDeferral(execution, context);

            if (!execution.DeferredForRecovery)
            {
                await EnsureTerminalOrFailAsync(execution, publisher);
            }
        }
        catch (ResponseExitForRecovery)
        {
            // Handler deferred to next-lifetime recovery (FR-036): mark deferred so finalization
            // skips the pre-terminal persist (preserving the last checkpoint snapshot) and retains
            // the recovery entry (durable status stays non-terminal). NOT a failure.
            execution.DeferredForRecovery = true;
        }
        catch (Exception ex) when (ex is not ResponsesApiException || execution.Response is not null)
        {
            await HandleExecutionExceptionAsync(execution, publisher, ex);
            ThrowIfPreCreatedFailure(execution);
        }
        finally
        {
            await FinalizeExecutionAsync(execution, publisher);
        }

        // Non-bg, non-streaming: if persistence failed, throw the original storage
        // exception instead of returning a response object with a dangling ID. The
        // response was never created in storage — post-sandbox GET would 404. Since
        // this mode is synchronous, the client never committed to the response ID
        // and can retry cleanly.
        // If the original exception is one of our mapped types (ResponsesApiException
        // or BadRequestException — mapped from Foundry status codes with user-safe
        // messages), re-throw it directly so the exception filter serializes it.
        // Otherwise (e.g. TCP/HTTP client failure), throw a generic 500.
        if (execution.PersistenceFailed && !execution.IsBackground)
        {
            _tracker.TryEvict(execution.ResponseId);
            if (execution.PersistenceException is ResponsesApiException or BadRequestException)
            {
                throw execution.PersistenceException;
            }

            // Persistence failed with a non-mapped exception (TCP, I/O, etc.) — platform infra failure
            var persistenceEx = ApiErrorFactory.ServerException();
            persistenceEx.Data[StorageErrorMapper.PlatformErrorDataKey] = true;
            throw persistenceEx;
        }

        return OrchestratorResult.Completed(execution.Response!);
    }

    /// <summary>
    /// Retrieves a stored response by ID.
    /// Encapsulates all guard logic: store check, background check, completion check.
    /// </summary>
    /// <param name="responseId">The response ID to look up.</param>
    /// <param name="platformContext">The platform identity context. Use <see cref="PlatformContext.Empty"/> when not applicable.</param>
    /// <returns>The Response snapshot.</returns>
    /// <exception cref="ResourceNotFoundException">If the response cannot be retrieved.</exception>
    public async Task<Models.ResponseObject> GetAsync(string responseId, PlatformContext platformContext)
    {
        // If the response is in-flight, apply in-flight guards and return a snapshot.
        if (_tracker.TryGet(responseId, out var execution) && execution is not null)
        {
            // User-key enforcement for in-flight responses
            execution.EnforceUserIsolation(platformContext);

            // Guard: store=false responses are not retrievable (B14)
            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // Persistence-failed executions are always retrievable from the tracker
            // regardless of background mode — the response was never persisted to the
            // durable store, so we serve it from memory.
            if (execution.PersistenceFailed && execution.Response is not null)
            {
                return execution.Response.Snapshot();
            }

            // B16: non-background in-flight responses are not findable via GET.
            // With eager eviction, all tracked executions are in-flight — completed
            // ones are evicted by FinalizeExecutionAsync and served from the provider.
            if (!execution.IsBackground)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // Response object may not yet exist if GET arrives before handler yields response.created.
            if (execution.Response is null)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            return execution.Response.Snapshot();
        }

        // Not in-flight — fall through to the durable store.
        // Provider throws ResourceNotFoundException if the ID doesn't exist.
        return await _provider.GetResponseAsync(responseId, platformContext);
    }

    /// <summary>
    /// Cancels a background response.
    /// Encapsulates all cancel logic: background guard, terminal status guard,
    /// idempotency, winddown wait, output clearing.
    /// </summary>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="platformContext">The platform identity context. Use <see cref="PlatformContext.Empty"/> when not applicable.</param>
    /// <returns>The cancelled Response snapshot.</returns>
    /// <exception cref="ResourceNotFoundException">If the response is not found.</exception>
    /// <exception cref="BadRequestException">If the response cannot be cancelled.</exception>
    public async Task<Models.ResponseObject> CancelAsync(string responseId, PlatformContext platformContext)
    {
        if (!_tracker.TryGet(responseId, out var execution) || execution is null)
        {
            // Not in-flight — check durable store for terminal state.
            // If it exists and is already terminal, return as-is (idempotent).
            // If it doesn't exist, provider throws ResourceNotFoundException.
            var persisted = await _provider.GetResponseAsync(responseId, platformContext);

            // B1: background check comes first — non-bg responses always get the
            // "synchronous" message regardless of terminal status (spec line 485).
            if (persisted.Background != true)
            {
                throw new BadRequestException("Cannot cancel a synchronous response.");
            }

            // Already completed / failed / cancelled / incomplete — not cancellable.
            return persisted.Status switch
            {
                ResponseStatus.Cancelled => persisted,
                ResponseStatus.Completed => throw new BadRequestException("Cannot cancel a completed response."),
                ResponseStatus.Failed => throw new BadRequestException("Cannot cancel a failed response."),
                ResponseStatus.Incomplete => throw new BadRequestException("Cannot cancel a response in terminal state."),
                _ => throw new BadRequestException("Cannot cancel a response in terminal state."),
            };
        }

        // User-key enforcement for in-flight responses
        execution.EnforceUserIsolation(platformContext);

        // B1/B16: non-background in-flight responses are not findable via Cancel.
        // With eager eviction, all tracked executions are in-flight — completed
        // non-bg responses are evicted and handled by the provider fallback above.
        if (!execution.IsBackground)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        // B12: terminal statuses are rejected
        switch (execution.Response?.Status)
        {
            case ResponseStatus.Completed:
                throw new BadRequestException("Cannot cancel a completed response.");
            case ResponseStatus.Failed:
                throw new BadRequestException("Cannot cancel a failed response.");
            case ResponseStatus.Incomplete:
                throw new BadRequestException("Cannot cancel a response in terminal state.");
            case ResponseStatus.Cancelled:
                // B3: idempotent — return current state
                return execution.Response!.Snapshot();
        }

        // In-progress: signal cancellation (B11).
        execution.CancelRequested = true;

        await _cancellationProvider.CancelResponseAsync(responseId);

        // Cancel the execution's CTS so the handler's CancellationToken fires.
        execution.CancellationTokenSource.Cancel();

        // Wait for FinalizeExecutionAsync to complete within a 10-second grace period (B11).
        // FinalizedSignal fires at the end of FinalizeExecutionAsync — after error recovery
        // (HandleExecutionExceptionAsync), terminal event emission, persistence, and tracker
        // cleanup. This works uniformly for all modes:
        //   - bg+non-streaming: ExecutionTask runs CreateAsync → FinalizeExecutionAsync
        //   - bg+streaming: SseResult drives CreateStreamingAsync → FinalizeExecutionAsync
        //   - non-bg disconnect: same pipeline, different CTS source
        // By waiting on FinalizedSignal instead of mutating the response concurrently,
        // we avoid race conditions between CancelAsync and the event processing pipeline.
        try
        {
            await execution.FinalizedSignal.Task.WaitAsync(TimeSpan.FromSeconds(10));
        }
        catch (TimeoutException)
        {
            // Handler didn't wind down in time — FinalizeExecutionAsync hasn't run yet.
            // Force the cancelled state so the cancel endpoint can return immediately.
            // FinalizeExecutionAsync will see the terminal status and persist it when
            // it eventually runs (its step 3 B11 guarantee is idempotent).
            if (execution.Response is not null && !IsTerminalStatus(execution.Response.Status))
            {
                execution.Response.SetCancelled();
            }
        }

        return execution.Response!.Snapshot();
    }

    // --- Event Processing Pipeline (US2) ---

    /// <summary>
    /// Core event processing pipeline. Iterates handler events, validates the first event,
    /// applies auto-stamping, performs full replacement for response.* events,
    /// updates output lists for output_item.* events, snapshots embedded responses,
    /// and pushes each event to the publisher. Yields each processed event.
    /// </summary>
    internal async IAsyncEnumerable<ResponseStreamEvent> ProcessEventsAsync(
        CreateResponse request,
        ResponseExecution execution,
        ResponseContext context,
        IAsyncObserver<ResponseStreamEvent> publisher,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var firstEvent = true;

        // On a crash-recovery re-invocation the handler may re-seed the stream from the durable
        // snapshot (context.PersistedResponse). Those already-emitted output items are legitimately
        // present without a fresh output_item.added event this lifetime, so the direct-manipulation
        // guard (B30/S-033) starts from the recovered watermark rather than 0.
        var outputItemCount = execution.RecoveredOutputWatermark;

        _logger.LogInformation(
            "Invoking handler {HandlerType} for response {ResponseId}",
            _handler.GetType().Name, execution.ResponseId);

        await foreach (var evt in _handler.CreateAsync(request, context, ct)
            .WithCancellation(ct))
        {
            // F2 (FR-036): ExitForRecoveryAsync() records DeferralRequested immediately before it
            // raises the ResponseExitForRecovery signal. A handler that swallows that signal with a
            // broad catch and then keeps yielding events (e.g. a terminal completed) must NOT be able
            // to drive the durable response terminal — the signal "cannot be effectively swallowed"
            // (parity with Python's BaseException, whose post-except code cannot run). So once a
            // deferral was requested, stop consuming handler events WITHOUT processing, publishing, or
            // persisting this (or any later) yielded event or control signal; mark the execution
            // deferred so finalization takes the checkpoint-preserving deferral path (no terminal
            // persist, recovery entry retained), exactly like the caught-signal path.
            if (context is ResponseContextImpl deferImpl && deferImpl.DeferralRequested)
            {
                execution.DeferredForRecovery = true;
                yield break;
            }

            // Checkpoint control signal (Row 11): persist the current snapshot (gated to resilient
            // background) and resume the handler. Intercepted by CLR type BEFORE any wire coercion —
            // it is never forwarded to the SSE stream and does not consume a sequence number. The
            // handler's yield is backpressured because the persist is awaited inline here (FR-031).
            if (evt is ResponseCheckpointEvent)
            {
                await DoCheckpointPersistAsync(execution, context).ConfigureAwait(false);
                continue;
            }

            if (firstEvent)
            {
                firstEvent = false;

                if (evt is not ResponseCreatedEvent createdEvt)
                {
                    // S-031: Wrong first event — bad handler
                    ThrowBadHandler(execution,
                        $"Handler did not yield response.created as its first event. Received: {evt.EventType}. Handler type: {_handler.GetType().Name}.");
                    yield break; // unreachable — satisfies compiler definite-assignment
                }

                // S-031: Response.Id must match ResponseContext.ResponseId
                if (createdEvt.Response.Id != context.ResponseId)
                {
                    ThrowBadHandler(execution,
                        $"Handler emitted response.created with id '{createdEvt.Response.Id}' but expected '{context.ResponseId}'. Handler type: {_handler.GetType().Name}.");
                }

                // B6/B8: Response.Status must be non-terminal on response.created
                if (IsTerminalStatus(createdEvt.Response.Status))
                {
                    ThrowBadHandler(execution,
                        $"Handler emitted response.created with terminal status '{createdEvt.Response.Status}'. Expected a non-terminal status. Handler type: {_handler.GetType().Name}.");
                }

                // B30/S-033: Output manipulation detection on response.created. On a crash-recovery
                // re-invocation the handler legitimately re-seeds the stream with the items already
                // emitted before the crash, so the expected count is the recovered watermark (0 on a
                // normal invocation — behavior unchanged off the recovery path).
                if (createdEvt.Response.Output.Count != execution.RecoveredOutputWatermark)
                {
                    ThrowBadHandler(execution,
                        $"Handler directly modified Response.Output (found {createdEvt.Response.Output.Count} items, expected {execution.RecoveredOutputWatermark}). Use output builder events instead. Handler type: {_handler.GetType().Name}.");
                }

                // B31: Status is a required field. Auto-stamp InProgress if the
                // handler omitted it so that GET never returns a statusless response.
                createdEvt.Response.Status ??= ResponseStatus.InProgress;

                // For bg=true: persist immediately when response.created is yielded (S-035)
                if (execution.IsBackground && execution.Store)
                {
                    ResponseMutations.ApplyOutputItemAutoStamps(evt, execution.ResponseId, request.AgentReference);
                    ResponseMutations.ReplaceResponse(execution, evt);
                    ResponseMutations.StampAgentReference(execution, request);
                    ResponseMutations.StampAgentSessionId(execution, request);
                    ResponseMutations.StampRequestEchoFields(execution, request);
                    evt.SnapshotEmbeddedResponse(execution.Response!);

                    var (inputItems, historyItemIds) = await ResolveItemsForPersistenceAsync(context);

                    try
                    {
                        if (context.IsRecovery)
                        {
                            // Recovery re-invocation: the response was already created in a prior
                            // lifetime, so update the existing durable record rather than creating
                            // a duplicate (CreateResponseAsync throws on an existing id). This keeps
                            // exactly one logical response.created across lifetimes.
                            await _provider.UpdateResponseAsync(execution.Response!, context.PlatformContext);
                        }
                        else
                        {
                            await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response!, inputItems, historyItemIds), context.PlatformContext);
                        }

                        // FR-037: record the durable snapshot written at response.created so a
                        // subsequent no-change Checkpoint() is deduplicated (FR-030 idempotency).
                        execution.LastPersistedSnapshotBytes =
                            ResponseMutations.SerializeSnapshotForDedup(execution.Response!.Snapshot());
                    }
                    catch (Exception ex)
                    {
                        // Phase 1 persistence failed — the client has NOT received
                        // response.created yet (yield return hasn't executed) and it has NOT been
                        // published to the wire stream (the publish now happens only AFTER a
                        // successful persist, below). Null out Response so the error handling path
                        // treats this as a pre-creation failure → standalone "error" SSE event per
                        // spec (B8), for both the yield path and the registry relay path. Record the
                        // original persistence exception so the resilient relay can surface it with
                        // full fidelity (storage_error) instead of the generic server_error the relay
                        // would otherwise derive from the execution-CTS cancellation below — the real
                        // error is thrown on the task-body's yield path, which never reaches the relay.
                        // Cancel the execution CTS so the handler stops processing.
                        _logger.LogError(ex,
                            "Phase 1 persistence (CreateResponseAsync) failed for response {ResponseId}",
                            execution.ResponseId);
                        execution.Response = null;
                        execution.PersistenceFailed = true;
                        execution.PersistenceException = ex;
                        execution.PreCreatedRelayFailure = ex;
                        execution.CancellationTokenSource.Cancel();
                        throw;
                    }

                    // Publish response.created to the wire stream ONLY after Phase-1 persistence
                    // succeeded — a registry subscriber (GET ?stream=true replay, or the resilient
                    // relay) must never observe a created event whose durable write later failed.
                    await publisher.OnNextAsync(evt);

                    // Signal that response.created has been processed — unblocks
                    // the bg non-streaming endpoint path waiting for the handler's response.
                    // Snapshot before signaling: the background task continues to mutate
                    // execution.Response (output items, terminal status) concurrently.
                    // Passing a live reference would race with Snapshot() on the request thread.
                    execution.ResponseCreatedSignal.TrySetResult(execution.Response!.Snapshot());

                    // Track highest emitted sequence number for SDK-synthesized terminal events (B9)
                    if (evt.SequenceNumber > execution.LastEmittedSequenceNumber)
                    {
                        execution.LastEmittedSequenceNumber = evt.SequenceNumber;
                    }

                    yield return evt;
                    continue;
                }
            }

            // Track output items for B30/S-033 output manipulation detection
            if (evt is ResponseOutputItemAddedEvent)
            {
                outputItemCount++;
            }

            // B30/S-033: Detect direct Output manipulation on response.* events (after response.created)
            {
                Models.ResponseObject? eventResponse = evt switch
                {
                    ResponseInProgressEvent e => e.Response,
                    ResponseCompletedEvent e => e.Response,
                    ResponseFailedEvent e => e.Response,
                    ResponseIncompleteEvent e => e.Response,
                    ResponseQueuedEvent e => e.Response,
                    _ => null,
                };

                if (eventResponse is not null && eventResponse.Output.Count > outputItemCount)
                {
                    _logger.LogError(
                        "Bad handler: Response.Output has {ActualCount} items but {ExpectedCount} output_item.added events were emitted. Handler: {HandlerType}",
                        eventResponse.Output.Count, outputItemCount, _handler.GetType().FullName);

                    // Post-created error — set failed status and emit response.failed
                    RecordBadHandlerError($"Bad handler: Output item count mismatch ({eventResponse.Output.Count} vs {outputItemCount} output_item.added events)");
                    await EmitTerminalFailureAsync(execution, publisher);
                    yield break;
                }
            }

            // Auto-stamp ResponseId and AgentReference on output items
            ResponseMutations.ApplyOutputItemAutoStamps(evt, execution.ResponseId, request.AgentReference);

            // Full replacement for response.* events — handler is source of truth
            ResponseMutations.ReplaceResponse(execution, evt);

            // Stamp AgentReference — the only SDK-managed property on Response
            ResponseMutations.StampAgentReference(execution, request);

            // Stamp AgentSessionId — resolved during request processing (B39)
            ResponseMutations.StampAgentSessionId(execution, request);

            // S-040: Re-stamp request echo-through fields (background, previous_response_id,
            // conversation) so they always reflect the original request regardless of how
            // the handler constructed the response.
            ResponseMutations.StampRequestEchoFields(execution, request);

            // Validate terminal event status consistency — handler must set the
            // correct Status on the Response before yielding a terminal event.
            {
                ResponseStatus? expectedStatus = evt switch
                {
                    ResponseCompletedEvent => ResponseStatus.Completed,
                    ResponseFailedEvent => ResponseStatus.Failed,
                    ResponseIncompleteEvent => ResponseStatus.Incomplete,
                    _ => null,
                };

                if (expectedStatus is not null && execution.Response!.Status != expectedStatus)
                {
                    _logger.LogError(
                        "Bad handler: {EventType} event has mismatched status '{ActualStatus}'. Expected '{ExpectedStatus}'. Handler: {HandlerType}",
                        evt.GetType().Name, execution.Response!.Status, expectedStatus, _handler.GetType().FullName);
                    RecordBadHandlerError($"Bad handler: {evt.GetType().Name} event has mismatched status '{execution.Response!.Status}', expected '{expectedStatus}'");
                    await EmitTerminalFailureAsync(execution, publisher);
                    yield break;
                }
            }

            // Update output list for output_item.* events
            execution.Response!.UpdateFromEvent(evt);

            // Snapshot the Response embedded in lifecycle events
            evt.SnapshotEmbeddedResponse(execution.Response!);

            // Push to replay subject via provider publisher. Terminal events
            // (completed/failed/incomplete) are the ONE exception: they are published by
            // CreateStreamingAsync AFTER its Phase-2 persistence step so the wire stream (registry
            // replay + resilient relay) observes the SAME corrected terminal as the yield path —
            // e.g. response.failed, not response.completed, when the terminal persist fails.
            if (evt is not (ResponseCompletedEvent or ResponseFailedEvent or ResponseIncompleteEvent))
            {
                await publisher.OnNextAsync(evt);
            }

            // Track highest emitted sequence number for SDK-synthesized terminal events (B9)
            if (evt.SequenceNumber > execution.LastEmittedSequenceNumber)
            {
                execution.LastEmittedSequenceNumber = evt.SequenceNumber;
            }

            yield return evt;
        }

        // S-015: Empty enumerable — bad handler
        if (firstEvent)
        {
            ThrowBadHandler(execution,
                $"Handler produced no events. Handler type: {_handler.GetType().Name}.");
        }
    }

    /// <summary>
    /// Persists a checkpoint snapshot yielded via <c>stream.Checkpoint()</c> (Row 11 / FR-030..037).
    /// Semantics (all Python-parity with <c>_do_checkpoint_persist</c>):
    /// <list type="bullet">
    /// <item>No-op unless resilient background (<c>ResilientBackground</c> + <c>store</c> + <c>background</c>).</item>
    /// <item>Dropped after a terminal status — the terminal write is authoritative (C4/FR-034).</item>
    /// <item>Idempotent — a snapshot byte-identical to the last persisted one is skipped (FR-030).</item>
    /// <item>Status preserved — the response is persisted as-is; the checkpoint never rewrites status.</item>
    /// <item>Failures swallowed — a transient store error is logged, not surfaced to the handler, and
    /// the prior snapshot is retained (C5/FR-035).</item>
    /// </list>
    /// </summary>
    private async Task DoCheckpointPersistAsync(
        ResponseExecution execution, ResponseContext context)
    {
        // No-op gate: checkpoints only persist for resilient background responses.
        if (!_resilientBackground || !execution.IsBackground || !execution.Store)
        {
            return;
        }

        // Persist the authoritative orchestrator snapshot (execution.Response), not the stream-owned
        // response carried by the checkpoint event. execution.Response reflects every event processed
        // before this checkpoint (intercepted at the top of the loop) AND the SDK-managed stamps
        // (agent_session_id, output-item auto-stamps) that the created/terminal writes also carry.
        // Using the stream's un-stamped response would drop agent_session_id from the durable record
        // for the whole in-progress window and defeat the FR-030 dedup baseline. If no created event
        // has been processed yet there is nothing durable to checkpoint.
        if (execution.Response is null)
        {
            return;
        }

        var snapshot = execution.Response.Snapshot();

        // C4/FR-034: a checkpoint after the terminal event is dropped (no overwrite, no exception).
        if (IsTerminalStatus(snapshot.Status))
        {
            return;
        }

        byte[]? snapshotBytes = ResponseMutations.SerializeSnapshotForDedup(snapshot);
        if (snapshotBytes is null)
        {
            // If we cannot even serialize the snapshot, treat it like a swallowed transient failure:
            // do not surface to the handler; retain the prior snapshot.
            _logger.LogWarning(
                "Checkpoint snapshot serialization failed for response {ResponseId}; checkpoint skipped.",
                execution.ResponseId);
            return;
        }

        // FR-030 idempotency: skip a byte-identical re-persist of the last durable snapshot.
        if (execution.LastPersistedSnapshotBytes is { } prior
            && prior.AsSpan().SequenceEqual(snapshotBytes))
        {
            return;
        }

        try
        {
            await _provider.UpdateResponseAsync(snapshot, context.PlatformContext).ConfigureAwait(false);
            execution.LastPersistedSnapshotBytes = snapshotBytes;
        }
        catch (Exception ex)
        {
            // C5/FR-035: transient store failure during checkpoint is swallowed — the handler does not
            // observe it and the prior durable snapshot is retained for recovery.
            _logger.LogWarning(ex,
                "Checkpoint persist failed for response {ResponseId}; prior snapshot retained.",
                execution.ResponseId);
        }
    }

    /// <summary>
    /// Wraps <see cref="ProcessEventsAsync"/> for streaming consumers with
    /// error recovery and finalization. The publisher is created internally.
    /// </summary>
    /// <remarks>
    /// C# does not allow <c>yield return</c> inside a try block with a catch clause.
    /// This method works around the limitation by using an inner try-catch for the
    /// <c>MoveNextAsync</c> call (no yield) and an outer try-finally for the yield.
    /// </remarks>
    private async IAsyncEnumerable<ResponseStreamEvent> CreateStreamingAsync(
        CreateResponse request,
        ResponseExecution execution,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // A replay-capable registry publisher is needed whenever a second subscriber consumes the
        // per-response wire stream instead of the direct yield path: background responses (SSE replay
        // via GET ?stream=true, B2) AND every resilient (task-wrapped) streaming turn, whose client
        // connection relays the wire stream because the handler runs inside a decoupled Core task
        // (execution.RelayViaRegistry). A plain foreground non-resilient stream delivers events straight
        // from the yield path — no second subscriber ever connects — so it uses a NullPublisher.
        var publisher = (execution.IsBackground || execution.RelayViaRegistry)
            ? await EventStreamObserver.CreateAsync(await _eventStreamRegistry.GetOrCreateAsync(execution.ResponseId, ct).ConfigureAwait(false), ct).ConfigureAwait(false)
            : (IAsyncObserver<ResponseStreamEvent>)new NullPublisher();
        var enumerator = ProcessEventsAsync(request, execution, context, publisher, ct)
            .GetAsyncEnumerator(ct);
        var terminalEventYielded = false;
        try
        {
            while (true)
            {
                ResponseStreamEvent evt;
                try
                {
                    if (!await enumerator.MoveNextAsync())
                    {
                        break;
                    }

                    evt = enumerator.Current;
                }
                catch (ResponseExitForRecovery)
                {
                    // Handler deferred to next-lifetime recovery (FR-036): mark deferred so
                    // finalization skips the pre-terminal persist (preserving the last checkpoint
                    // snapshot) and retains the recovery entry. Stop draining; NOT a failure.
                    execution.DeferredForRecovery = true;
                    break;
                }
                catch (Exception ex) when (ex is not ResponsesApiException || execution.Response is not null)
                {
                    await HandleExecutionExceptionAsync(execution, publisher, ex);
                    ThrowIfPreCreatedFailure(execution);
                    break;
                }

                if (evt is ResponseCompletedEvent or ResponseFailedEvent or ResponseIncompleteEvent)
                {
                    terminalEventYielded = true;

                    // Option A: Persist BEFORE yielding the terminal event.
                    // This ensures zero consistency gap — if the client sees
                    // response.completed, the data is durable. The Foundry provider's
                    // Azure.Core pipeline already handles transport-level retries.
                    if (execution.Store && execution.Response is not null)
                    {
                        // The while-loop owns the terminal persist for the cooperative streaming path;
                        // record that so FinalizeExecutionAsync does not persist a second time (and so it
                        // CAN persist a steering-completion terminal that never reached this block).
                        execution.StreamingTerminalPersisted = true;
                        Exception? persistException = null;
                        try
                        {
                            if (execution.IsBackground)
                            {
                                await _provider.UpdateResponseAsync(execution.Response, execution.Context?.PlatformContext ?? PlatformContext.Empty);
                            }
                            else
                            {
                                var (inputItems, historyItemIds) = await ResolveItemsForPersistenceAsync(execution.Context);
                                await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, inputItems, historyItemIds), execution.Context?.PlatformContext ?? PlatformContext.Empty);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex,
                                "Persistence failed before terminal event for response {ResponseId}",
                                execution.ResponseId);
                            persistException = ex;
                        }

                        if (persistException is not null)
                        {
                            // Always overwrite with storage error — the handler's error
                            // won't survive sandbox termination anyway (zombie detection
                            // replaces it), and the client needs to know to retry.
                            // Clear output: items won't be available from the storage API
                            // post-sandbox, so returning them now creates a false expectation.
                            execution.Response.Output.Clear();
                            execution.Response.SetFailed(
                                new ResponseErrorCode("storage_error"),
                                "An internal error occurred while storing the response. Subsequent retrieval is not guaranteed. Please retry the request.");
                            execution.PersistenceFailed = true;
                            execution.PersistenceException = persistException;
                            evt = new ResponseFailedEvent(
                                evt.SequenceNumber, execution.Response.Snapshot());
                        }
                    }

                    // Publish the corrected terminal to the wire stream here (NOT at the ProcessEventsAsync
                    // push point) so registry subscribers observe the post-Phase-2 event: response.failed
                    // when the terminal persist failed, otherwise the handler's terminal. No-op for a
                    // NullPublisher (plain foreground non-resilient stream).
                    await publisher.OnNextAsync(evt);
                }

                yield return evt;
            }

            // On a recovery deferral the handler intentionally ended non-terminal; do not treat
            // that as a bad handler and do not synthesize a terminal failure (FR-036). Also honor a
            // deferral signal a handler swallowed with a broad catch before returning normally.
            ObserveSwallowedDeferral(execution, context);

            if (!execution.DeferredForRecovery)
            {
                await EnsureTerminalOrFailAsync(execution, publisher);

                // Yield terminal event emitted by error recovery or S-015 that wasn't
                // yielded in the while loop (because C# disallows yield inside catch blocks).
                // The SDK only sets Failed or Cancelled (never Incomplete — that's handler-driven),
                // so this always emits ResponseFailedEvent.
                if (!terminalEventYielded && execution.Response is not null
                    && IsTerminalStatus(execution.Response.Status))
                {
                    yield return new ResponseFailedEvent(
                        execution.LastEmittedSequenceNumber + 1, execution.Response.Snapshot());
                }
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
            await FinalizeExecutionAsync(execution, publisher);
        }
    }

    // --- Shared Helpers ---

    /// <summary>
    /// Logs a bad-handler error, cancels the execution CTS, and throws
    /// <see cref="ResponsesApiException"/> with HTTP 500.
    /// The detailed <paramref name="internalMessage"/> is logged but not exposed to the API consumer.
    /// </summary>
    [DoesNotReturn]
    private void ThrowBadHandler(ResponseExecution execution, string internalMessage)
    {
        _logger.LogError(
            "Bad handler: {Message} Request: {RequestId}",
            internalMessage, execution.ResponseId);
        execution.CancellationTokenSource.Cancel();
        throw ApiErrorFactory.ServerException();
    }

    /// <summary>
    /// Throws HTTP 500 if the handler failed before emitting <c>response.created</c>.
    /// </summary>
    private static void ThrowIfPreCreatedFailure(ResponseExecution execution)
    {
        if (execution.Response is null)
        {
            throw ApiErrorFactory.ServerException();
        }
    }

    /// <summary>
    /// Detects a deferral signal that a handler swallowed with a broad <c>catch</c> and then
    /// returned normally, marking the execution deferred so the durable outcome matches the
    /// caught-signal path (FR-036): the response stays non-terminal (in_progress), finalization
    /// skips the pre-terminal persist, and the recovery entry is retained. Idempotent — a no-op when
    /// the execution is already deferred or the context did not request deferral. Mirrors the
    /// non-swallowable nature of Python's <c>ResponseExitForRecovery(BaseException)</c>.
    /// </summary>
    private static void ObserveSwallowedDeferral(ResponseExecution execution, ResponseContext context)
    {
        if (!execution.DeferredForRecovery
            && context is ResponseContextImpl impl
            && impl.DeferralRequested)
        {
            execution.DeferredForRecovery = true;
        }
    }

    /// <summary>
    /// S-015: if the handler ended without a terminal event, emits
    /// <see cref="ResponseFailedEvent"/>.
    /// </summary>
    private async Task EnsureTerminalOrFailAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher)
    {
        if (!IsTerminalStatus(execution.Response!.Status))
        {
            _logger.LogError(
                "Bad handler: ended without emitting a terminal event. Handler: {HandlerType}, Request: {RequestId}",
                _handler.GetType().FullName, execution.ResponseId);
            RecordBadHandlerError("Bad handler: ended without emitting a terminal event");
            await EmitTerminalFailureAsync(execution, publisher);
        }
    }

    // --- Terminal Emission Helpers (US5) ---

    /// <summary>
    /// Sets the response status to <see cref="ResponseStatus.Failed"/>,
    /// snapshots the response, and pushes a <see cref="ResponseFailedEvent"/>
    /// to the publisher. When an <paramref name="exception"/> is provided,
    /// the error is mapped with full fidelity via
    /// <see cref="ApiErrorFactory.ToResponseError"/>.
    /// </summary>
    internal async Task EmitTerminalFailureAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher,
        Exception? exception = null,
        string? shutdownReason = null)
    {
        if (!string.IsNullOrEmpty(shutdownReason))
        {
            // Shutdown-driven mark-failed (Row 2/3): code=server_error with an
            // additionalInfo.shutdown_reason diagnostic ("grace_exhausted" Path B, "crash_recovery"
            // Path C), mirroring Python's dispatch matrix. Ordinary handler failures never carry this.
            execution.Response!.SetFailed(
                ResponseErrorCode.ServerError,
                ApiErrorFactory.GenericServerErrorMessage,
                shutdownReason);
        }
        else if (exception is not null)
        {
            execution.Response!.SetFailed(exception);
        }
        else
        {
            execution.Response!.SetFailed();
        }

        var failedEvent = new ResponseFailedEvent(
            execution.LastEmittedSequenceNumber + 1, execution.Response!.Snapshot());
        await publisher.OnNextAsync(failedEvent);
    }

    /// <summary>
    /// Sets the response status to <see cref="ResponseStatus.Cancelled"/>,
    /// snapshots the response, and pushes a <see cref="ResponseFailedEvent"/>
    /// (cancelled responses use the failed event type) to the publisher.
    /// </summary>
    internal async Task EmitTerminalCancellationAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher)
    {
        execution.Response!.SetCancelled();
        var cancelledEvent = new ResponseFailedEvent(
            execution.LastEmittedSequenceNumber + 1, execution.Response!.Snapshot());
        await publisher.OnNextAsync(cancelledEvent);
    }

    /// <summary>
    /// Sets the response status to <see cref="ResponseStatus.Completed"/>, snapshots the response,
    /// and pushes a <see cref="ResponseCompletedEvent"/> to the publisher. Used for a steering
    /// supersession where the framework woke the active turn but the handler did not itself emit a
    /// terminal event before the token tripped: the partial output is preserved as a completed
    /// (not cancelled, not failed) turn so it remains valid conversation context (FR-053).
    /// </summary>
    internal async Task EmitTerminalCompletionAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher)
    {
        execution.Response!.SetCompleted();
        var completedEvent = new ResponseCompletedEvent(
            execution.LastEmittedSequenceNumber + 1, execution.Response!.Snapshot());
        await publisher.OnNextAsync(completedEvent);
    }

    /// <summary>
    /// Consolidated error recovery matrix. Determines the appropriate terminal
    /// state based on exception type and execution flags, then emits the
    /// corresponding terminal event.
    /// </summary>
    /// <param name="execution">The current execution.</param>
    /// <param name="publisher">The event publisher.</param>
    /// <param name="exception">The exception that occurred.</param>
    internal async Task HandleExecutionExceptionAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher,
        Exception exception)
    {
        // Distributed tracing: record exception and error tags on the current span
        // matching Core's AgentInvocationBase parity contract.
        var currentActivity = System.Diagnostics.Activity.Current;
        if (currentActivity is not null)
        {
            currentActivity.AddEvent(new System.Diagnostics.ActivityEvent("exception",
                tags: new System.Diagnostics.ActivityTagsCollection
                {
                    { "exception.type", exception.GetType().FullName },
                    { "exception.message", exception.Message },
                    { "exception.stacktrace", exception.ToString() },
                }));
            currentActivity.SetStatus(System.Diagnostics.ActivityStatusCode.Error, exception.Message);

            if (exception is ResponsesApiException apiEx)
            {
                var errorCode = apiEx.Error.Code ?? "server_error";
                var errorMessage = apiEx.Error.Message;
                currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorCode, errorCode);
                currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorMessage, errorMessage);
                currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelErrorType, errorCode);
                currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelStatusDescription, errorMessage);
            }
            else if (exception is not OperationCanceledException)
            {
                currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorCode, "server_error");
                currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorMessage, exception.Message);
                currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelErrorType, exception.GetType().FullName!);
                currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelStatusDescription, exception.Message);
            }
        }

        // Log the exception at the appropriate level.
        if (exception is ResponseValidationException valEx)
        {
            _logger.LogError(exception,
                "Response validation failed for {ResponseId} with {ErrorCount} error(s): {Errors}",
                execution.ResponseId, valEx.Errors.Count,
                string.Join("; ", valEx.Errors.Select(e => $"{e.Path}: {e.Message}")));
        }
        else if (exception is not OperationCanceledException)
        {
            _logger.LogError(exception,
                "Handler failed for response {ResponseId}",
                execution.ResponseId);
        }
        else
        {
            _logger.LogInformation(
                "Handler cancelled for response {ResponseId}", execution.ResponseId);
        }

        // Pre-created: response was never created, nothing to mutate or publish.
        // The caller (ThrowIfPreCreatedFailure / FinalizeExecutionAsync) will throw
        // or fault the signal because execution.Response is null.
        if (execution.Response is null)
        {
            // Record the pre-created failure so the resilient relay can surface it as a standalone
            // `error` SSE event with full fidelity (B8). On the inline path the same exception is
            // re-thrown by ThrowIfPreCreatedFailure and caught by SseResult; on the task-wrapped path
            // it is thrown in the decoupled task body, so the relay reads it from here instead. Do not
            // clobber a more specific failure already recorded by the Phase-1 persistence catch.
            execution.PreCreatedRelayFailure ??= exception;
            return;
        }

        // If the response is already in a terminal state, do not override.
        if (IsTerminalStatus(execution.Response.Status))
        {
            return;
        }

        if (exception is OperationCanceledException)
        {
            if (execution.CancelRequested || execution.ClientDisconnected)
            {
                await EmitTerminalCancellationAsync(execution, publisher);
            }
            else if (execution.SteeringRequested)
            {
                // Steering supersession (FR-053): a new turn arrived for the same steerable
                // conversation while this turn was active, so the framework woke this turn by
                // cancelling its token. A cooperative handler normally observes
                // context.PendingInputCount and emits its own terminal (e.g. completed with the
                // partial output). If it instead let the token trip without emitting a terminal,
                // finalize it as completed — NOT cancelled — so the partial work is preserved as
                // valid conversation context for the draining steered turn. Steering never marks
                // the superseded turn cancelled.
                await EmitTerminalCompletionAsync(execution, publisher);
            }
            else if (execution.ShutdownRequested)
            {
                // Path B (grace exhausted): the framework forcibly cancelled the handler at shutdown.
                // Row 1 (resilient background) — hand the in-flight handler to next-lifetime recovery
                // (FR-014): leave the response in_progress (NOT failed), preserve the last checkpoint
                // snapshot, and retain the acceptance-time recovery entry so the next lifetime
                // re-invokes with IsRecovery==true. A well-behaved handler observes context.Shutdown
                // and calls ExitForRecoveryAsync() explicitly; this is the framework-level fallback
                // for a Row 1 handler that did not.
                if (_resilientBackground && execution.IsBackground && execution.Store)
                {
                    execution.DeferredForRecovery = true;
                }
                else
                {
                    // Row 2/3 (non-resilient background or foreground) — in-process fail semantics
                    // (mark failed with code=server_error, persist final events, respond to waiting
                    // clients in this lifetime). No next-lifetime re-invocation. The mark-failed is
                    // shutdown-driven, so tag it with shutdown_reason="grace_exhausted" (Path B).
                    await EmitTerminalFailureAsync(execution, publisher, exception, shutdownReason: "grace_exhausted");
                }
            }
            else
            {
                // Unknown cancellation — treat as failure
                await EmitTerminalFailureAsync(execution, publisher, exception);
            }
        }
        else
        {
            // General exception or ResponsesApiException — set failed with full fidelity
            await EmitTerminalFailureAsync(execution, publisher, exception);
        }
    }

    /// <summary>
    /// Tags the current <see cref="System.Diagnostics.Activity"/> with error
    /// information for bad-handler or missing-terminal paths that bypass
    /// <see cref="HandleExecutionExceptionAsync"/>.
    /// </summary>
    private static void RecordBadHandlerError(string errorMessage)
    {
        var currentActivity = System.Diagnostics.Activity.Current;
        if (currentActivity is null)
        {
            return;
        }

        currentActivity.SetStatus(System.Diagnostics.ActivityStatusCode.Error, errorMessage);
        currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorCode, "server_error");
        currentActivity.SetTag(ResponsesTracingConstants.Tags.ErrorMessage, errorMessage);
        currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelErrorType, "server_error");
        currentActivity.SetTag(ResponsesTracingConstants.Tags.OTelStatusDescription, errorMessage);
    }

    /// <summary>
    /// Shared finally-block logic: completes the publisher, conditionally
    /// persists the response (Create or Update depending on background mode),
    /// and evicts the execution from the tracker so that subsequent API calls
    /// fall through to the durable <see cref="ResponsesProvider"/>.
    /// </summary>
    /// <remarks>
    /// Every path through this method must reach <see cref="ResponseExecutionTracker.TryEvict"/>
    /// and must attempt <see cref="TaskCompletionSource{T}.TrySetException(Exception)"/> when
    /// <c>execution.Response</c> is null. Failures in the publisher or provider
    /// are logged and swallowed — they must never prevent the signal from being
    /// faulted (which would deadlock bg-non-streaming callers) or the tracker
    /// from being cleaned up.
    /// </remarks>
    internal async Task FinalizeExecutionAsync(
        ResponseExecution execution,
        IAsyncObserver<ResponseStreamEvent> publisher)
    {
        // 1. Complete the publisher — best effort.
        // SKIP on recovery deferral (FR-036): a resilient background+streaming handler that called
        // ExitForRecoveryAsync() is handing the durable stream off to the next lifetime, which will
        // resume publishing onto it. Completing the publisher here writes a completion sentinel to
        // the durable stream file; on the next restart RehydrateFromFile would seed the subject as
        // already-completed, so a client reconnecting via GET /responses/{id}?stream=true while the
        // re-invocation is still producing events would see a premature close and miss the live tail
        // (violating FR-041). Leaving the stream open (no sentinel) mirrors a true crash, where the
        // process dies and this finally never runs.
        if (!execution.DeferredForRecovery)
        {
            try
            {
                await publisher.OnCompletedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,
                    "Publisher.OnCompletedAsync failed for response {ResponseId}", execution.ResponseId);
            }
        }

        // 2. If the handler never yielded response.created, fault the signal so
        // any awaiter (e.g. bg non-streaming endpoint) gets an error instead of hanging.
        if (execution.Response is null)
        {
            execution.ResponseCreatedSignal.TrySetException(
                ApiErrorFactory.ServerException());
        }

        // 3. B11 final guarantee: if CancelRequested but the response is not cancelled
        // (e.g. a race between CancelAsync and a handler terminal event), force cancelled.
        // Cancellation always wins per spec.
        if (execution.CancelRequested
            && execution.Response is not null
            && execution.Response.Status != ResponseStatus.Cancelled)
        {
            execution.Response.SetCancelled();
        }

        // 4. Persist — if it fails after Azure.Core's built-in transport retries,
        // mark the response as failed and keep it in the tracker.
        // SKIP for streaming mode: persistence was already attempted in CreateStreamingAsync
        // before the terminal event was yielded to the client (Option A).
        // SKIP on recovery deferral (FR-036): the handler called ExitForRecoveryAsync() to hand
        // off to the next lifetime, so overwriting the durable record now with the current
        // pre-terminal in-memory response would clobber the last checkpoint snapshot. The recovery
        // entry is retained (status stays non-terminal) and the next lifetime resumes from the
        // preserved snapshot.
        if (!execution.DeferredForRecovery
            && (!execution.IsStreaming
                || execution.Response?.Status == ResponseStatus.Cancelled
                || (execution.IsStreaming
                    && execution.Response?.Status == ResponseStatus.Completed
                    && !execution.StreamingTerminalPersisted)))
        {
            try
            {
                if (execution.Store && execution.Response is not null && !execution.PersistenceFailed)
                {
                    if (execution.IsBackground)
                    {
                        // Background mode: Create already happened at response.created time — update.
                        await _provider.UpdateResponseAsync(execution.Response, execution.Context?.PlatformContext ?? PlatformContext.Empty);
                    }
                    else if (IsNonCancelledTerminal(execution.Response.Status))
                    {
                        // Default mode: single persist at non-cancelled terminal state.
                        var (inputItems, historyItemIds) = await ResolveItemsForPersistenceAsync(execution.Context);
                        await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, inputItems, historyItemIds), execution.Context?.PlatformContext ?? PlatformContext.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Provider persistence failed for response {ResponseId}", execution.ResponseId);

                // Mark response as failed due to persistence error — but never override
                // a cancelled status (B11: cancellation always wins).
                if (execution.Response is not null
                    && execution.Response.Status != ResponseStatus.Cancelled)
                {
                    // Clear output: items won't be available from the storage API
                    // post-sandbox, so returning them now creates a false expectation.
                    execution.Response.Output.Clear();
                    execution.Response.SetFailed(
                        new ResponseErrorCode("storage_error"),
                        "An internal error occurred while storing the response. Subsequent retrieval is not guaranteed. Please retry the request.");
                }

                execution.PersistenceFailed = true;
                execution.PersistenceException = ex;
            }
        }

        // 5. Evict from tracker — subsequent GET / DELETE / Cancel calls will
        // fall through to the durable ResponsesProvider instead of returning a
        // stale in-memory snapshot. Without eviction, completed executions
        // accumulate in the tracker for the lifetime of the process.
        // EXCEPTION: If persistence failed, keep the execution in the tracker so
        // GET can serve the failed response from memory (it was never persisted).
        // TryEvict (not TryRemove) intentionally does NOT dispose the execution:
        // CancelAsync may still hold a reference and read Response.Snapshot()
        // after FinalizedSignal fires in step 6 below.
        if (!execution.PersistenceFailed)
        {
            _tracker.TryEvict(execution.ResponseId);
        }

        // 6. Signal FinalizedSignal — CancelAsync and StopAsync await this to know
        // that the response is in its final state and has been persisted.
        execution.FinalizedSignal.TrySetResult();

        // 7. Core owns durable task lifecycle cleanup for resilient background responses.
    }

    /// <summary>
    /// Resolves input items and history item IDs from the context for persistence.
    /// Returns null collections when the context is not available (e.g. cancelled before response.created).
    /// </summary>
    private static async Task<(IEnumerable<OutputItem>? InputItems, IEnumerable<string>? HistoryItemIds)>
        ResolveItemsForPersistenceAsync(ResponseContext? context)
    {
        if (context is null)
        {
            return (null, null);
        }

        IEnumerable<OutputItem>? inputItems = null;
        IEnumerable<string>? historyItemIds = null;

        try
        {
            if (context is ResponseContextImpl impl)
            {
                inputItems = await impl.GetInputItemsForPersistenceAsync();
            }
            else
            {
                // Fallback: resolve items and convert to OutputItem for persistence
                var items = await context.GetInputItemsAsync();
                inputItems = items
                    .Select(item => ItemConversion.ToOutputItem(item, context.ResponseId))
                    .Where(item => item is not null)
                    .Select(item => item!)
                    .ToList();
            }
        }
        catch
        {
            // Input resolution failure must not prevent persistence
        }

        try
        {
            if (context is ResponseContextImpl impl)
            {
                historyItemIds = await impl.GetHistoryItemIdsAsync();
            }
        }
        catch
        {
            // History resolution failure must not prevent persistence
        }

        return (inputItems, historyItemIds);
    }
}
