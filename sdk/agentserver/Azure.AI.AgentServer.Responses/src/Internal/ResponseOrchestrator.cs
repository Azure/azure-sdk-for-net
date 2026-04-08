// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Logging;

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
    private readonly ResponsesStreamProvider _streamProvider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ILogger<ResponseOrchestrator> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseOrchestrator"/>.
    /// </summary>
    public ResponseOrchestrator(
        ResponseHandler handler,
        ResponsesProvider provider,
        ResponsesCancellationSignalProvider cancellationProvider,
        ResponsesStreamProvider streamProvider,
        ResponseExecutionTracker tracker,
        ILogger<ResponseOrchestrator> logger)
    {
        _handler = handler;
        _provider = provider;
        _cancellationProvider = cancellationProvider;
        _streamProvider = streamProvider;
        _tracker = tracker;
        _logger = logger;
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
        var publisher = await _streamProvider.CreateEventPublisherAsync(execution.ResponseId, ct);
        try
        {
            await foreach (var _ in ProcessEventsAsync(request, execution, context, publisher, ct)
                .WithCancellation(ct))
            {
                // Consume — non-streaming just accumulates state.
            }

            await EnsureTerminalOrFailAsync(execution, publisher);
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

        return OrchestratorResult.Completed(execution.Response!);
    }

    /// <summary>
    /// Retrieves a stored response by ID.
    /// Encapsulates all guard logic: store check, background check, completion check.
    /// </summary>
    /// <param name="responseId">The response ID to look up.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <returns>The Response snapshot.</returns>
    /// <exception cref="ResourceNotFoundException">If the response cannot be retrieved.</exception>
    public async Task<Models.ResponseObject> GetAsync(string responseId, IsolationContext isolation)
    {
        // If the response is in-flight, apply in-flight guards and return a snapshot.
        if (_tracker.TryGet(responseId, out var execution) && execution is not null)
        {
            // Guard: store=false responses are not retrievable (FR-014)
            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // Non-background responses are only visible after completion with a non-cancelled terminal state
            if (!execution.IsBackground
                && (execution.Response is null
                    || execution.CompletedAt is null
                    || execution.Response.Status == ResponseStatus.Cancelled))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            return execution.Response!.Snapshot();
        }

        // Not in-flight — fall through to the durable store.
        // Provider throws ResourceNotFoundException if the ID doesn't exist.
        return await _provider.GetResponseAsync(responseId, isolation);
    }

    /// <summary>
    /// Cancels a background response.
    /// Encapsulates all cancel logic: background guard, terminal status guard,
    /// idempotency, winddown wait, output clearing.
    /// </summary>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <returns>The cancelled Response snapshot.</returns>
    /// <exception cref="ResourceNotFoundException">If the response is not found.</exception>
    /// <exception cref="BadRequestException">If the response cannot be cancelled.</exception>
    public async Task<Models.ResponseObject> CancelAsync(string responseId, IsolationContext isolation)
    {
        if (!_tracker.TryGet(responseId, out var execution) || execution is null)
        {
            // Not in-flight — check durable store for terminal state.
            // If it exists and is already terminal, return as-is (idempotent).
            // If it doesn't exist, provider throws ResourceNotFoundException.
            var persisted = await _provider.GetResponseAsync(responseId, isolation);

            // Already completed / failed / cancelled / incomplete — not cancellable.
            return persisted.Status switch
            {
                ResponseStatus.Cancelled => persisted,
                ResponseStatus.Completed => throw new BadRequestException("Cannot cancel a completed response."),
                ResponseStatus.Failed => throw new BadRequestException("Cannot cancel a failed response."),
                ResponseStatus.Incomplete => throw new BadRequestException("Cannot cancel an incomplete response."),
                _ => throw new BadRequestException("Cannot cancel a response that is not in progress."),
            };
        }

        // B1/B16: non-background responses cannot be cancelled via this endpoint.
        // If still in-flight, return 404 (non-background in-flight not findable per B16).
        // If finished, return 400 (background check takes priority per contract matrix).
        if (!execution.IsBackground)
        {
            if (execution.CompletedAt is null)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            throw new BadRequestException("Cannot cancel a synchronous response.");
        }

        // B12: terminal statuses are rejected
        switch (execution.Response?.Status)
        {
            case ResponseStatus.Completed:
                throw new BadRequestException("Cannot cancel a completed response.");
            case ResponseStatus.Failed:
                throw new BadRequestException("Cannot cancel a failed response.");
            case ResponseStatus.Incomplete:
                throw new BadRequestException("Cannot cancel an incomplete response.");
            case ResponseStatus.Cancelled:
                // B3: idempotent — return current state
                return execution.Response!.Snapshot();
        }

        // In-progress: execute winddown (B11)
        execution.CancelRequested = true;

        await _cancellationProvider.CancelResponseAsync(responseId);

        // Wait for handler to complete with grace period
        if (execution.ExecutionTask is not null)
        {
            try
            {
                await execution.ExecutionTask.WaitAsync(TimeSpan.FromSeconds(10));
            }
            catch
            {
                // Handler may throw or timeout — already handled by the task itself
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
        var outputItemCount = 0;

        await foreach (var evt in _handler.CreateAsync(request, context, ct)
            .WithCancellation(ct))
        {
            if (firstEvent)
            {
                firstEvent = false;

                if (evt is not ResponseCreatedEvent createdEvt)
                {
                    // FR-006: Wrong first event — bad handler
                    ThrowBadHandler(execution,
                        $"Handler did not yield response.created as its first event. Received: {evt.EventType}. Handler type: {_handler.GetType().Name}.");
                    yield break; // unreachable — satisfies compiler definite-assignment
                }

                // FR-006: Response.Id must match ResponseContext.ResponseId
                if (createdEvt.Response.Id != context.ResponseId)
                {
                    ThrowBadHandler(execution,
                        $"Handler emitted response.created with id '{createdEvt.Response.Id}' but expected '{context.ResponseId}'. Handler type: {_handler.GetType().Name}.");
                }

                // FR-007: Response.Status must be non-terminal on response.created
                if (IsTerminalStatus(createdEvt.Response.Status))
                {
                    ThrowBadHandler(execution,
                        $"Handler emitted response.created with terminal status '{createdEvt.Response.Status}'. Expected a non-terminal status. Handler type: {_handler.GetType().Name}.");
                }

                // FR-008a: Output manipulation detection on response.created
                if (createdEvt.Response.Output.Count != 0)
                {
                    ThrowBadHandler(execution,
                        $"Handler directly modified Response.Output (found {createdEvt.Response.Output.Count} items, expected 0). Use output builder events instead. Handler type: {_handler.GetType().Name}.");
                }

                // B31: Status is a required field. Auto-stamp InProgress if the
                // handler omitted it so that GET never returns a statusless response.
                createdEvt.Response.Status ??= ResponseStatus.InProgress;

                // For bg=true: persist immediately when response.created is yielded (FR-003)
                if (execution.IsBackground && execution.Store)
                {
                    ResponseMutations.ApplyOutputItemAutoStamps(evt, execution.ResponseId, request.AgentReference);
                    ResponseMutations.ReplaceResponse(execution, evt);
                    ResponseMutations.StampAgentReference(execution, request);
                    ResponseMutations.StampAgentSessionId(execution, request);
                    evt.SnapshotEmbeddedResponse(execution.Response!);
                    await publisher.OnNextAsync(evt);

                    var (inputItems, historyItemIds) = await ResolveItemsForPersistenceAsync(context);
                    await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response!, inputItems, historyItemIds), context.Isolation);

                    // Signal that response.created has been processed — unblocks
                    // the bg non-streaming endpoint path waiting for the handler's response.
                    // Snapshot before signaling: the background task continues to mutate
                    // execution.Response (output items, terminal status) concurrently.
                    // Passing a live reference would race with Snapshot() on the request thread.
                    execution.ResponseCreatedSignal.TrySetResult(execution.Response!.Snapshot());

                    yield return evt;
                    continue;
                }
            }

            // Track output items for FR-008a output manipulation detection
            if (evt is ResponseOutputItemAddedEvent)
            {
                outputItemCount++;
            }

            // FR-008a: Detect direct Output manipulation on response.* events (after response.created)
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

            // Stamp AgentSessionId — resolved during request processing (S-048)
            ResponseMutations.StampAgentSessionId(execution, request);

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

            // Push to replay subject via provider publisher
            await publisher.OnNextAsync(evt);

            yield return evt;
        }

        // FR-007: Empty enumerable — bad handler
        if (firstEvent)
        {
            ThrowBadHandler(execution,
                $"Handler produced no events. Handler type: {_handler.GetType().Name}.");
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
        var publisher = await _streamProvider.CreateEventPublisherAsync(execution.ResponseId, ct);
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
                catch (Exception ex) when (ex is not ResponsesApiException || execution.Response is not null)
                {
                    await HandleExecutionExceptionAsync(execution, publisher, ex);
                    ThrowIfPreCreatedFailure(execution);
                    break;
                }

                if (evt is ResponseCompletedEvent or ResponseFailedEvent or ResponseIncompleteEvent)
                {
                    terminalEventYielded = true;
                }

                yield return evt;
            }

            await EnsureTerminalOrFailAsync(execution, publisher);

            // Yield terminal event emitted by error recovery or FR-009 that wasn't
            // yielded in the while loop (because C# disallows yield inside catch blocks).
            // The SDK only sets Failed or Cancelled (never Incomplete — that's handler-driven),
            // so this always emits ResponseFailedEvent.
            if (!terminalEventYielded && execution.Response is not null
                && IsTerminalStatus(execution.Response.Status))
            {
                yield return new ResponseFailedEvent(0, execution.Response.Snapshot());
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
    /// FR-009: if the handler ended without a terminal event, emits
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
        Exception? exception = null)
    {
        if (exception is not null)
        {
            execution.Response!.SetFailed(exception);
        }
        else
        {
            execution.Response!.SetFailed();
        }

        var failedEvent = new ResponseFailedEvent(0, execution.Response!.Snapshot());
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
        var cancelledEvent = new ResponseFailedEvent(0, execution.Response!.Snapshot());
        await publisher.OnNextAsync(cancelledEvent);
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
            else if (execution.ShutdownRequested)
            {
                await EmitTerminalFailureAsync(execution, publisher, exception);
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
    /// and marks the execution as completed in the tracker.
    /// </summary>
    /// <remarks>
    /// Every path through this method must reach <see cref="ResponseExecutionTracker.MarkCompleted"/>
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
        try
        {
            await publisher.OnCompletedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex,
                "Publisher.OnCompletedAsync failed for response {ResponseId}", execution.ResponseId);
        }

        // 2. If the handler never yielded response.created, fault the signal so
        // any awaiter (e.g. bg non-streaming endpoint) gets an error instead of hanging.
        if (execution.Response is null)
        {
            execution.ResponseCreatedSignal.TrySetException(
                ApiErrorFactory.ServerException());
        }

        // 3. Persist — best effort. Provider failures must not prevent cleanup.
        try
        {
            if (execution.Store && execution.Response is not null)
            {
                if (execution.IsBackground)
                {
                    // Background mode: Create already happened at response.created time — update.
                    await _provider.UpdateResponseAsync(execution.Response, execution.Context?.Isolation ?? IsolationContext.Empty);
                }
                else if (IsNonCancelledTerminal(execution.Response.Status))
                {
                    // Default mode: single persist at non-cancelled terminal state.
                    var (inputItems, historyItemIds) = await ResolveItemsForPersistenceAsync(execution.Context);
                    await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, inputItems, historyItemIds), execution.Context?.Isolation ?? IsolationContext.Empty);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Provider persistence failed for response {ResponseId}", execution.ResponseId);
        }

        // 4. Always mark completed — prevents orphaned executions in the tracker.
        _tracker.MarkCompleted(execution.ResponseId);
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
            inputItems = await context.GetInputItemsAsync();
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
