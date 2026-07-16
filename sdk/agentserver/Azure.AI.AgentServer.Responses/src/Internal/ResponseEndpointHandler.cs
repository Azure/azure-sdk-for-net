// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Contains the endpoint handler methods for the Responses API.
/// </summary>
internal sealed class ResponseEndpointHandler
{
    /// <summary>
    /// When set on the incoming request, the library uses this value as the response ID
    /// instead of generating one. Gives platform/middletier services full control over ID generation.
    /// </summary>
    private const string AgentResponseIdHeader = "x-agent-response-id";

    private readonly ResponsesActivitySource _activitySource;
    private readonly ResponseOrchestrator _orchestrator;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponsesProvider _provider;
    private readonly ResponsesCancellationSignalProvider _cancellationProvider;
    private readonly IEventStreamRegistry _eventStreamRegistry;
    private readonly IOptions<ResponsesServerOptions> _options;
    private readonly ILogger<ResponseEndpointHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseEndpointHandler"/>.
    /// </summary>
    public ResponseEndpointHandler(
        ResponsesActivitySource activitySource,
        ResponseOrchestrator orchestrator,
        ResponseExecutionTracker tracker,
        ResponsesProvider provider,
        ResponsesCancellationSignalProvider cancellationProvider,
        IEventStreamRegistry eventStreamRegistry,
        IOptions<ResponsesServerOptions> options,
        ILogger<ResponseEndpointHandler> logger)
    {
        _activitySource = activitySource;
        _orchestrator = orchestrator;
        _tracker = tracker;
        _provider = provider;
        _cancellationProvider = cancellationProvider;
        _eventStreamRegistry = eventStreamRegistry;
        _options = options;
        _logger = logger;
    }

    /// <summary>
    /// B40: Validates that a path-parameter response ID matches the expected <c>caresp_*</c> format.
    /// Throws <see cref="BadRequestException"/> with <c>code: "invalid_parameters"</c> for malformed IDs.
    /// </summary>
    /// <remarks>
    /// Deliberately validates prefix and length only — character-set validation is not required.
    /// IDs with valid prefix/length but unexpected characters will fall through to the provider
    /// and return 404 (not found), which is an acceptable outcome.
    /// </remarks>
    private static void ValidateResponseIdFormat(string responseId)
    {
        if (!IdGenerator.IsValid(responseId, out _, allowedPrefixes: ["caresp"]))
        {
            throw new BadRequestException(
                "Malformed identifier.",
                code: "invalid_parameters",
                paramName: $"responseId{{{responseId}}}");
        }
    }

    /// <summary>
    /// Handles POST /responses — creates a new response and handles all 4 modes.
    /// </summary>
    public async Task<IResult> CreateResponseAsync(HttpContext httpContext)
    {
        CreateResponse request;
        BinaryData? rawBody = null;
        try
        {
            // Buffer the request body for validation + deserialization
            using var ms = new MemoryStream();
            await httpContext.Request.Body.CopyToAsync(ms, httpContext.RequestAborted);
            var bodyBytes = ms.ToArray();

            if (bodyBytes.Length == 0)
            {
                throw new BadRequestException("Request body is required.");
            }

            // Validate the raw JSON against the API schema
            var validationResult = CreateResponsePayloadValidator.Validate((ReadOnlySpan<byte>)bodyBytes);
            if (!validationResult.IsValid)
            {
                throw new PayloadValidationException(validationResult.Errors);
            }

            // Strip reserved internal metadata on ingress before model binding/persistence.
            var requestNode = JsonNode.Parse(bodyBytes)
                ?? throw new BadRequestException("Request body is required.");
            InternalMetadataEgress.Strip(requestNode);
            var sanitizedBodyBytes = JsonSerializer.SerializeToUtf8Bytes(requestNode, SharedJsonOptions.Instance);

            // Deserialize from the sanitized bytes
            request = JsonSerializer.Deserialize<CreateResponse>(sanitizedBodyBytes, SharedJsonOptions.Instance)
                ?? throw new BadRequestException("Request body is required.");

            // Capture sanitized raw bytes for ResponseContext.RawBody
            rawBody = BinaryData.FromBytes(sanitizedBodyBytes);
        }
        catch (JsonException ex)
        {
            throw new BadRequestException($"Invalid JSON in request body: {ex.Message}", ex);
        }

        // Detect mode flags (read-only on generated model)
        var isStreaming = request.Stream == true;
        var isBackground = request.Background == true;
        var store = request.Store ?? true;

        // B13: background=true requires store=true
        if (isBackground && !store)
        {
            throw new BadRequestException(
                "Background responses require store to be enabled.",
                code: "unsupported_parameter",
                paramName: "background");
        }

        // Resolve model: request-level → DefaultModel → empty string (PW-006)
        request.Model ??= _options.Value.DefaultModel ?? string.Empty;

        // Cache conversation ID — GetConversationId() parses the conversation JSON each call.
        var conversationId = request.GetConversationId();

        // B38: Use x-agent-response-id header as the response ID if present,
        // giving platform/middletier services full control over ID generation.
        // Otherwise, generate one with partition key colocation.
        string responseId;
        if (httpContext.Request.Headers.TryGetValue(AgentResponseIdHeader, out var agentResponseIdValue)
            && !string.IsNullOrEmpty(agentResponseIdValue.ToString()))
        {
            responseId = agentResponseIdValue.ToString();
            if (!IdGenerator.IsValid(responseId, out var idError, allowedPrefixes: ["caresp"]))
            {
                throw new BadRequestException(
                    $"x-agent-response-id header value is invalid: {idError}",
                    code: "invalid_request",
                    paramName: "x-agent-response-id");
            }
        }
        else
        {
            var partitionKeyHint = request.PreviousResponseId
                ?? conversationId
                ?? "";
            responseId = IdGenerator.NewResponseId(partitionKeyHint);
        }

        var platformContext = PlatformContext.FromRequest(httpContext.Request);

        _logger.LogInformation(
            "Creating response {ResponseId}: Streaming={IsStreaming} Background={IsBackground} Store={Store} Model={Model} ConversationId={ConversationId} PreviousResponseId={PreviousResponseId} HasUserId={HasUserId} HasCallId={HasCallId}",
            responseId, isStreaming, isBackground, store, request.Model, conversationId, request.PreviousResponseId,
            platformContext.UserIdKey is not null, platformContext.CallId is not null);

        // B39: Resolve session ID — request payload → environment variable → deterministic derivation.
        // Stamp on the request so the orchestrator can propagate it to the ResponseObject.
        if (string.IsNullOrEmpty(request.AgentSessionId))
        {
            request.AgentSessionId = !string.IsNullOrEmpty(FoundryEnvironment.SessionId)
                ? FoundryEnvironment.SessionId
                : SessionIdDerivation.Derive(
                    conversationId,
                    request.PreviousResponseId,
                    request.AgentReference);
        }

        // Store resolved session ID for the response header filter (§8).
        httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = request.AgentSessionId;

        // Propagate baggage for downstream correlation (no invoke_agent span —
        // W3C context propagation is handled by ASP.NET Core automatically)
        _activitySource.PropagateResponseBaggage(request, responseId, httpContext.Request.Headers);

        // Structured log scope — matches Core's HostedAgentTelemetry.StartActivity
        // for parity: ResponseId, ConversationId, Streaming appear on all log lines.
        using var logScope = _logger.BeginScope(new Dictionary<string, object?>
        {
            [ResponsesTracingConstants.LogScope.ResponseId] = responseId,
            [ResponsesTracingConstants.LogScope.ConversationId] = conversationId ?? string.Empty,
            [ResponsesTracingConstants.LogScope.Streaming] = isStreaming,
        });

        // Extract x-client-* headers and query parameters for ResponseContext (also needed to
        // build the queued-turn context on the steering path below).
        var clientHeaders = ExtractClientHeaders(httpContext.Request);
        var queryParameters = ExtractQueryParameters(httpContext.Request);

        // Conversation / steering dispatch selection (US5, CC-RE4): turns of one conversation share a
        // single Core multi-turn task keyed by the stable chain id, so Core owns steering (queue,
        // fork/lock preconditions, pending-input accounting) — the Responses layer never reimplements
        // it. Mirrors Python `_pick_primitive`: a conversation (`conversation_id`) or a steerable
        // server routes through the multi-turn task; everything else is one-shot. `previous_response_id`
        // alone is NOT a multi-turn trigger (parity with Python — it only tightens the fork precondition
        // once a chain exists). AddResponsesServer composes the Core task subsystem in both local and
        // hosted environments (hosted selects the hosted task store), so ANY conversation routes
        // multi-turn — a plain conversation_id chain gets concurrency protection (concurrent overlap
        // → 409 conversation_locked) even with default options.
        var steerable = _options.Value.SteerableConversations;
        bool multiTurnAvailable = true;
        bool pickMultiTurn = multiTurnAvailable
            && (steerable
                || !string.IsNullOrEmpty(conversationId));
        string? chainId = pickMultiTurn
            ? DeriveConversationChainId(request, conversationId, responseId, steerable)
            : null;

        // Multi-turn (conversation / steerable) is NOT background-gated (parity with Python
        // `_pick_primitive`, which routes any conversation_id or steerable turn through the multi-turn
        // primitive REGARDLESS of background) — a foreground conversation turn must still get
        // concurrency arbitration (concurrent overlap → 409 conversation_locked) and fork rejection
        // (409 conversation_fork_not_supported), which are FR-051/FR-052 requirements that are not
        // background-gated.
        //
        // EVERY store=true request is task-tracked — including background AND foreground streaming.
        // The streaming task path does NOT await response.created: the SSE result subscribes to the
        // per-response wire stream and relays immediately (parity with Python `_live_stream`), so a
        // pre-creation (Phase 1) persistence failure is surfaced by the relay as a standalone spec-B8
        // SSE `error` event (recorded on execution.PreCreatedRelayFailure and re-thrown by
        // SubscribeBackgroundStreamAsync) rather than an HTTP 500, and the Phase-2 terminal is published
        // to the wire stream by CreateStreamingAsync AFTER its persistence rewrite so a terminal persist
        // failure surfaces response.failed (not response.completed). This closes the former Row-2
        // background-streaming / Row-3 foreground crash-recovery gap: both are now task-tracked, so the
        // next-lifetime recovery scan observes and marks-failed a crashed turn (Path C).
        //
        // Task-routing gate (parity with Python responses-resilience-spec §6): the handler runs INSIDE
        // a Core resilient task for EVERY non-hosted store=true request — background OR foreground,
        // streaming OR non-streaming, one-shot OR multi-turn. Only store=false (Row 4) runs inline
        // (Python `run_sync`/`run_stream` skip the task when store=false: "no store ⇒ no resilient task").
        // StartResilientTurnAsync selects the primitive from pickMultiTurn and the recovery disposition
        // from the row (Row 1 bg+resilient → re-invoke; Rows 2/3 → mark-failed). The trailing clause
        // keeps the pre-existing .NET behavior of routing a store=false conversation / steerable turn
        // through the multi-turn task for concurrency arbitration (409 conversation_locked / fork) on
        // the non-streaming path; store=false is otherwise inline.
        //
        // Streaming task-routing does NOT await response.created: the SSE result subscribes to the
        // per-response wire stream and relays immediately (parity with Python `_live_stream`), so a
        // Phase-1 persistence failure inside the task body surfaces as a standalone SSE `error` event
        // (spec-B8) delivered by the relay, and a slow first turn never blocks the HTTP response. A
        // task-START infra failure still propagates BEFORE the SSE headers as HTTP 500 +
        // x-platform-error-source (see ResilientStartFailureProtocolTests) — .NET returns a clean HTTP
        // error rather than a 200 + error event because, unlike Starlette, the SSE headers are not yet
        // committed when StartResilientTurnAsync runs.
        bool useResilientTask = store
            || (pickMultiTurn && (isBackground || !isStreaming));

        var execution = _tracker.Create(responseId, isBackground, isStreaming, store);

        // Record the creation-time session ID and user ID key on the execution
        // so subsequent GET/Cancel/Delete can emit x-agent-session-id even before
        // the handler yields response.created (when execution.Response is still null).
        execution.AgentSessionId = request.AgentSessionId;
        execution.UserIdKey = platformContext.UserIdKey;

        var context = new ResponseContextImpl(
            responseId,
            _provider,
            request,
            _options,
            rawBody,
            clientHeaders,
            queryParameters,
            platformContext,
            isSteeredTurn: false,
            pendingInputCountProvider: null);

        // Only the BACKGROUND multi-turn resilient path lets the resilient-task handler rebuild the
        // steering-aware ResponseContext from the live Core TaskContext (IsSteeredTurn /
        // PendingInputCount), so its execution Context is intentionally left unset here. Every other
        // path — including foreground conversation/steerable turns (pickMultiTurn but not run inside a
        // Core task) and the background one-shot resilient path (handler reuses this Context) — needs
        // the endpoint-owned context so inline persistence keeps input items, history, and the
        // user-isolation platform context.
        if (!(pickMultiTurn && useResilientTask))
        {
            execution.Context = context;
        }
        // Eager history validation: if previous_response_id or conversation.id is present,
        // resolve history item IDs now to validate referenced state before the handler runs.
        // Invalid references are provider-validated here and may surface as 404 or 400
        // depending on which identifier is invalid.
        // The Lazy<Task<>> cache means the handler and persistence can reuse the result.
        if (!string.IsNullOrEmpty(request.PreviousResponseId) || !string.IsNullOrEmpty(conversationId))
        {
            await context.GetHistoryItemIdsAsync();
        }

        // Get cancellation token from provider (supports external cancel)
        var providerCt = await _cancellationProvider.GetResponseCancellationTokenAsync(responseId);

        if (isStreaming)
        {
            // Streaming (bg or non-bg): create orchestrator event stream, return SSE result.
            // CTS includes httpContext.RequestAborted for non-bg only (disconnect → cancel).
            // Do NOT use 'using' — SseResult takes ownership and disposes the CTS.
            CancellationTokenSource? linkedCts = null;
            try
            {
                if (useResilientTask)
                {
                    // The handler runs inside a decoupled Core task; the client connection relays the
                    // per-response wire stream (registry) rather than the task body's event enumerator.
                    // Flag it so the orchestrator populates the registry publisher for BOTH background
                    // and foreground streaming (foreground would otherwise get a NullPublisher and the
                    // relay would block forever on an empty wire stream) and routes created/terminal
                    // events through the wire stream only after their persistence outcome is known.
                    execution.RelayViaRegistry = true;

                    var run = await StartResilientTurnAsync(
                        httpContext, request, responseId, chainId, pickMultiTurn,
                        platformContext, clientHeaders, queryParameters);

                    // A steered turn queued behind an active turn does NOT short-circuit to a JSON
                    // queued envelope when the caller asked to stream: stream=true must always yield an
                    // SSE stream regardless of whether the turn runs immediately or is queued (the JSON
                    // queued envelope is reserved for the NON-streaming queued paths below). We keep the
                    // endpoint-created execution (RelayViaRegistry=true was set just above) rather than
                    // evicting it, so when the queued input drains later inside Core the re-entry REUSES
                    // this execution (tracker.TryGet) and its handler publishes response.created /
                    // in_progress / … onto the per-response wire stream — for foreground turns too, which
                    // would otherwise get a NullPublisher if the drain created a fresh execution. The SSE
                    // result below subscribes to that wire stream immediately (GetOrCreateAsync) and stays
                    // open, relaying nothing until the turn starts, then emitting events as they arrive.
                    // run.GetResultAsync resolves when the queued turn's steered re-entry completes.
                    execution.ExecutionTask = run.GetResultAsync(CancellationToken.None);

                    // Relay the per-response wire stream immediately — do NOT await
                    // ResponseCreatedSignal. The handler runs inside the task body and writes events
                    // (including response.created, or a standalone B8 `error` on a pre-created failure)
                    // to the registry wire stream; the SSE result subscribes and relays them as they
                    // arrive (parity with Python `_live_stream`). Awaiting response.created here would
                    // deadlock a foreground stream whose handler backpressures on the wire stream until
                    // a subscriber attaches.
                    //
                    // Disconnect semantics differ by mode (B17). A BACKGROUND stream is decoupled from
                    // this connection: a disconnect stops the relay but never cancels the task — the
                    // stored response stays recoverable and retrievable. A FOREGROUND stream is
                    // synchronously bound to the caller, so a client disconnect abandons the turn: flag
                    // it and cancel the shared execution CTS (which the task-body handler links), so the
                    // handler observes cancellation and the response terminates as cancelled — matching
                    // the pre-task inline foreground-streaming behavior (T067).
                    if (!isBackground)
                    {
                        httpContext.RequestAborted.Register(() =>
                        {
                            execution.ClientDisconnected = true;
                            try
                            {
                                execution.CancellationTokenSource.Cancel();
                            }
                            catch (ObjectDisposedException)
                            {
                                // The execution already finalized and disposed its CTS — nothing to cancel.
                            }
                        });
                    }

                    linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                        providerCt, execution.CancellationTokenSource.Token);
                    var backgroundSseResult = new SseResult(
                        SubscribeBackgroundStreamAsync(responseId, execution, linkedCts.Token),
                        execution, linkedCts, SharedJsonOptions.Instance, _logger,
                        FoundryEnvironment.SseKeepAliveInterval);
                    linkedCts = null;
                    return backgroundSseResult;
                }
                else if (isBackground)
                {
                    linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                        providerCt, execution.CancellationTokenSource.Token);
                }
                else
                {
                    // Order matters: CancellationToken callbacks fire LIFO, so register
                    // the linked CTS first and the flag second — flag is set before
                    // the linked CTS propagates cancellation to the handler.
                    linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                        providerCt, execution.CancellationTokenSource.Token, httpContext.RequestAborted);
                    httpContext.RequestAborted.Register(() => execution.ClientDisconnected = true);
                }

                var result = await _orchestrator.CreateAsync(request, execution, context, linkedCts.Token);

                // SseResult takes ownership of linkedCts — it will dispose it when
                // the SSE stream completes.
                var sseResult = new SseResult(
                    result.Events!, execution, linkedCts,
                    SharedJsonOptions.Instance, _logger, FoundryEnvironment.SseKeepAliveInterval);

                // Ownership transferred — prevent the catch/finally from disposing.
                linkedCts = null;
                return sseResult;
            }
            catch
            {
                // If CreateAsync or SseResult construction fails, we still own
                // the resources — dispose them before re-throwing.
                linkedCts?.Dispose();
                throw;
            }
        }
        else if (isBackground)
        {
            // Background (non-streaming): run handler inside the Core durable task primitive.
            // Wait for response.created before returning — the handler's response
            // is the source of truth, not a SDK-constructed seed.
            if (useResilientTask)
            {
                var run = await StartResilientTurnAsync(
                    httpContext, request, responseId, chainId, pickMultiTurn,
                    platformContext, clientHeaders, queryParameters);

                // A steered turn queued behind an active turn returns the queued envelope
                // immediately; it drains later inside Core as a steered re-entry.
                if (run.IsQueued)
                {
                    _tracker.TryEvict(responseId);
                    return JsonForClient(BuildQueuedEnvelope(request, context, responseId));
                }

                execution.ExecutionTask = run.GetResultAsync(CancellationToken.None);
            }
            else
            {
                execution.ExecutionTask = Task.Run(async () =>
                {
                    using var bgLinkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                        providerCt, execution.CancellationTokenSource.Token);
                    await _orchestrator.CreateAsync(request, execution, context, bgLinkedCts.Token);
                });
            }

            // Await the handler's response.created (or a pre-created error).
            // If the handler fails before response.created, the signal faults
            // and the exception propagates to the exception filter → HTTP 500.
            // The signal delivers an independent snapshot — no re-snapshot needed.
            var handlerResponse = await execution.ResponseCreatedSignal.Task;
            _logger.LogInformation(
                "Background response created signal received for {ResponseId}, status={Status}",
                responseId, handlerResponse.Status);
            return JsonForClient(handlerResponse);
        }
        else
        {
            // Default (non-streaming, non-background).
            if (useResilientTask)
            {
                // Foreground stored turn: route through the Core resilient task (parity with Python
                // responses-resilience-spec §6.2, whose foreground HTTP request awaits the task body's
                // terminal via TaskRun.result()). The one-shot task backs a plain stored request so a
                // crash mid-turn is task-tracked and the next-lifetime recovery scan marks it failed
                // (Row 3 Path C). A conversation / steerable turn instead routes through the multi-turn
                // task so it ALSO gets concurrency arbitration (concurrent overlap → 409
                // conversation_locked, FR-052) and fork rejection (previous_response_id not the chain
                // head → 409 conversation_fork_not_supported, FR-051) — StartResilientTurnAsync selects
                // the primitive from pickMultiTurn. Either way the foreground caller waits synchronously
                // for the terminal result and receives the FINAL response inline.
                var run = await StartResilientTurnAsync(
                    httpContext, request, responseId, chainId, pickMultiTurn,
                    platformContext, clientHeaders, queryParameters);

                // A steered turn queued behind an active turn returns the queued envelope immediately;
                // it drains later inside Core as a steered re-entry.
                if (run.IsQueued)
                {
                    _tracker.TryEvict(responseId);
                    return JsonForClient(BuildQueuedEnvelope(request, context, responseId));
                }

                // A foreground (non-background) turn is synchronously bound to the caller: a client
                // disconnect abandons it (B14/T022). The task body links the shared execution CTS, so
                // flag the disconnect and cancel it — the handler observes cancellation and the turn
                // terminates as cancelled + ephemeral (not persisted). This matches the pre-task inline
                // foreground behavior; a BACKGROUND turn, by contrast, is decoupled and survives a
                // disconnect (handled in the isBackground branch, which never registers this).
                httpContext.RequestAborted.Register(() =>
                {
                    execution.ClientDisconnected = true;
                    try
                    {
                        execution.CancellationTokenSource.Cancel();
                    }
                    catch (ObjectDisposedException)
                    {
                        // The execution already finalized and disposed its CTS — nothing to cancel.
                    }
                });

                execution.ExecutionTask = run.GetResultAsync(CancellationToken.None);

                // Block until the task turn reaches a terminal state, then return the FINAL response.
                // The Core task handler reuses this endpoint-created execution (tracker.TryGet), so
                // execution.Response is the terminal snapshot once the task completes. A non-background
                // terminal persistence failure re-raises the ORIGINAL storage exception from inside the
                // task body (orchestrator CreateAsync), which Core wraps as a task fault — so swallow the
                // wrapped fault ONLY when a persistence failure is recorded and re-raise the original
                // below (parity with Python run_sync, which checks record.persistence_failed after the
                // task terminal and raises the original rather than the task's server_error).
                try
                {
                    await execution.ExecutionTask;
                }
                catch (Exception) when (execution.PersistenceFailed)
                {
                    // The task fault is the wrapped persistence exception — handled uniformly below.
                }

                // Non-bg persistence failure: throw the original storage exception instead of returning
                // a response with a dangling ID (the response was never durably created; a post-crash
                // GET would 404). Mirrors the inline orchestrator path (ResponseOrchestrator.CreateAsync)
                // and Python run_sync §6.2.
                if (execution.PersistenceFailed)
                {
                    _tracker.TryEvict(responseId);
                    if (execution.PersistenceException is ResponsesApiException or BadRequestException)
                    {
                        throw execution.PersistenceException;
                    }

                    var persistenceEx = ApiErrorFactory.ServerException();
                    persistenceEx.Data[StorageErrorMapper.PlatformErrorDataKey] = true;
                    throw persistenceEx;
                }

                // Client disconnected mid-turn (B14/T022): the turn terminated as cancelled and was NOT
                // persisted (cancelled foreground responses are ephemeral), so a durable GET would 404.
                // The caller is gone, so the return value is discarded — return the in-memory snapshot
                // directly to avoid a spurious ResourceNotFoundException from the orchestrator read.
                if (execution.ClientDisconnected)
                {
                    _tracker.TryEvict(responseId);
                    httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = execution.AgentSessionId;
                    return JsonForClient(execution.Response?.Snapshot() ?? BuildQueuedEnvelope(request, context, responseId));
                }

                // A store=false response is ephemeral and NOT retrievable (B14): _orchestrator.GetAsync
                // would throw ResourceNotFoundException for it. Return the in-memory terminal snapshot
                // directly, mirroring the inline foreground path. (store=false still routes through the
                // multi-turn task above for conversation/steering arbitration — e.g. under
                // SteerableConversations=true — it just isn't persisted for later retrieval.)
                if (!store)
                {
                    httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = execution.AgentSessionId;
                    return JsonForClient(execution.Response!.Snapshot());
                }

                // A stored turn's terminal response is durable and fetched by id via the orchestrator
                // (which applies the same read guards as GET /responses/{id}).
                var finalResponse = await _orchestrator.GetAsync(responseId, platformContext);
                httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = finalResponse.AgentSessionId;
                _logger.LogInformation(
                    "Foreground resilient response {ResponseId} completed: Status={Status} OutputCount={OutputCount}",
                    responseId, finalResponse.Status, finalResponse.Output.Count);
                return JsonForClient(finalResponse);
            }

            // Inline foreground fallback — reached ONLY for store=false one-shot foreground (Row 4:
            // ephemeral, no durable state to recover, so no Core task). Every store=true foreground
            // turn routes through the resilient task above (Row 3 Path C task-tracking), matching Python
            // responses-resilience-spec §6 (the handler runs inside a resilient task for EVERY
            // store=true request; only store=false runs inline).
            // Order matters: register linked CTS first, then ClientDisconnected flag.
            // CancellationToken callbacks fire in LIFO order, so registering the flag
            // second ensures it is set before the linked CTS propagates cancellation
            // to the handler — matching the streaming path's registration order.
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                providerCt, execution.CancellationTokenSource.Token, httpContext.RequestAborted);
            httpContext.RequestAborted.Register(() => execution.ClientDisconnected = true);

            await _orchestrator.CreateAsync(request, execution, context, linkedCts.Token);

            _logger.LogInformation(
                "Response {ResponseId} completed: Status={Status} OutputCount={OutputCount}",
                responseId, execution.Response!.Status, execution.Response!.Output.Count);
            return JsonForClient(execution.Response!.Snapshot());
        }
    }

    private ResponseRecoveryPayload BuildRecoveryPayload(
        string responseId,
        CreateResponse request,
        PlatformContext platformContext,
        IReadOnlyDictionary<string, string> clientHeaders,
        IReadOnlyDictionary<string, StringValues> queryParameters)
    {
        var flatQuery = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var kvp in queryParameters)
        {
            flatQuery[kvp.Key] = kvp.Value.ToString();
        }

        // Derive the recovery disposition from the row classification rather than hard-coding it.
        // This call site now also serves Row 2 (store + background, non-resilient): ResilientBackground
        // resolves to re-invoke (Row 1) while a stored non-resilient background response resolves to
        // mark-failed (Row 2), so the recovery scan marks it failed instead of re-invoking. Deriving it
        // keeps every entry correct and matches the dispatch truth table exactly.
        var disposition = ResponseResilienceDispatch.DecideDisposition(
            store: request.Store != false,
            background: request.Background == true,
            resilientBackground: _options.Value.ResilientBackground);

        var payload = new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: disposition,
            request: request,
            agentReference: request.AgentReference,
            agentSessionId: request.AgentSessionId,
            userIdKey: platformContext.UserIdKey,
            callId: platformContext.CallId,
            clientHeaders: clientHeaders,
            queryParameters: flatQuery);

        return payload;
    }

    private async IAsyncEnumerable<ResponseStreamEvent> SubscribeBackgroundStreamAsync(
        string responseId,
        ResponseExecution execution,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = await _eventStreamRegistry.GetOrCreateAsync(responseId, cancellationToken)
            .ConfigureAwait(false);
        var enumerator = stream.Subscribe().WithCancellation(cancellationToken).ConfigureAwait(false).GetAsyncEnumerator();
        var createdSeen = false;
        try
        {
            while (true)
            {
                try
                {
                    if (!await enumerator.MoveNextAsync())
                    {
                        break;
                    }
                }
                catch (OperationCanceledException) when (!createdSeen && execution.PreCreatedRelayFailure is not null)
                {
                    // A pre-created failure inside the decoupled task body (Phase-1 persistence failure)
                    // cancels the execution CTS — which cancels this relay subscription — but the
                    // original error was thrown on the task-body yield path and never reached the wire
                    // stream. Surface the recorded failure so SseResult writes a standalone `error`
                    // event with full fidelity, matching the inline streaming path (B8).
                    throw execution.PreCreatedRelayFailure;
                }

                var evt = (ResponseStreamEvent)enumerator.Current;
                if (evt is ResponseCreatedEvent)
                {
                    createdSeen = true;
                }

                yield return evt;
            }

            // The wire stream closed cleanly. If the handler failed BEFORE emitting response.created
            // (e.g. a handler that threw pre-created, or a validation error), the failure was thrown in
            // the decoupled task body and the wire stream closed empty — surface the recorded pre-created
            // failure so the relay emits the standalone `error` event instead of an empty SSE stream.
            if (!createdSeen && execution.PreCreatedRelayFailure is not null)
            {
                throw execution.PreCreatedRelayFailure;
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
        }
    }

    /// <summary>
    /// Derives the stable conversation chain id for arbitration using the same inputs as
    /// <see cref="ResponseContextImpl.ConversationChainId"/>, so a turn keys to the same chain in
    /// the arbitrator as it reports to the handler.
    /// </summary>
    private static string DeriveConversationChainId(
        CreateResponse request, string? conversationId, string responseId, bool steerable)
    {
        AgentReference? agentReference = request.AgentReference ?? request.Agent;
        string agentName = agentReference?.Name is { Length: > 0 } name ? name : "server-default-agent";
        string sessionId = request.AgentSessionId is { Length: > 0 } sid
            ? sid
            : SessionIdDerivation.Derive(conversationId, request.PreviousResponseId, agentReference);

        return ConversationChainIdDerivation.Derive(
            conversationId, request.PreviousResponseId, responseId, agentName, sessionId, steerable);
    }

    /// <summary>
    /// Starts a background response turn inside the selected Core resilient task and maps Core
    /// steering/precondition exceptions to the Responses 409 envelopes. Picks the multi-turn
    /// (conversation / steering) task when <paramref name="pickMultiTurn"/> is set — keyed by the
    /// shared chain id with an <c>ifLastInputId</c> fork precondition — otherwise the one-shot task.
    /// </summary>
    private async Task<TaskRun<ResponseTaskOutput>> StartResilientTurnAsync(
        HttpContext httpContext,
        CreateResponse request,
        string responseId,
        string? chainId,
        bool pickMultiTurn,
        PlatformContext platformContext,
        IReadOnlyDictionary<string, string> clientHeaders,
        IReadOnlyDictionary<string, StringValues> queryParameters)
    {
        var payload = BuildRecoveryPayload(
            responseId, request, platformContext, clientHeaders, queryParameters);
        var invoker = httpContext.RequestServices.GetRequiredService<ITaskInvoker>();

        var taskName = pickMultiTurn
            ? ResponsesResilientTaskHandler.MultiTurnTaskName
            : ResponsesResilientTaskHandler.OneShotTaskName;

        // Multi-turn: the chain id is the task id and the response id is the per-turn input id; a
        // previous_response_id becomes the ifLastInputId fork precondition (Core rejects a turn that
        // does not extend the most recent turn). One-shot: task id == input id == response id.
        var runOptions = pickMultiTurn
            ? new RunOptions
            {
                TaskId = chainId!,
                InputId = responseId,
                IfLastInputId = string.IsNullOrEmpty(request.PreviousResponseId)
                    ? null
                    : request.PreviousResponseId,
            }
            : new RunOptions { TaskId = responseId, InputId = responseId };

        try
        {
            return await invoker.StartAsync<ResponseTaskInput, ResponseTaskOutput>(
                taskName,
                new ResponseTaskInput(payload),
                runOptions,
                CancellationToken.None).ConfigureAwait(false);
        }
        catch (LastInputIdPreconditionFailedException)
        {
            // A previous_response_id that does not reference the most recent turn is a conversation
            // fork (Core precondition failure) — reject rather than branch the chain. Body shape
            // (type/code/param/message) matches Python `_endpoint_handler` for wire parity.
            throw new ResponsesApiException(
                new Error("conversation_fork_not_supported",
                    "This agent does not support conversation forking. previous_response_id must reference the most recent response in the conversation.")
                {
                    Type = "conflict",
                    Param = "previous_response_id",
                },
                StatusCodes.Status409Conflict);
        }
        catch (TaskConflictException ex)
        {
            // A concurrent turn on a non-steerable conversation overlaps the active turn. Body shape
            // matches Python `_endpoint_handler` exactly: `Conversation is locked — task is {status}`
            // with the lower-case snake-case wire status and no trailing period.
            throw new ResponsesApiException(
                new Error("conversation_locked",
                    $"Conversation is locked — task is {ToWireStatus(ex.CurrentStatus)}")
                {
                    Type = "conflict",
                },
                StatusCodes.Status409Conflict);
        }
        catch (SteeringQueueFullException)
        {
            // The steering queue for the active turn is at capacity. Python does not document a
            // distinct queue-full code; surfaced as conversation_locked (409 conflict) — recorded as a
            // Python-side verification action item in the parity report.
            throw new ResponsesApiException(
                new Error("conversation_locked",
                    "Conversation is locked — the steering queue is full. Retry once the active turn has made progress.")
                {
                    Type = "conflict",
                },
                StatusCodes.Status409Conflict);
        }
        catch (Exception ex)
        {
            // FR-004: any other resilient-start failure is a Core task-subsystem infra failure
            // (e.g. a task-store write failing during StartAsync). Tag it as platform-sourced so the
            // exception filter surfaces it as 500 + x-platform-error-source: platform rather than
            // silently downgrading it to an upstream error. The 409 catches above rethrow their own
            // ResponsesApiException, which is not intercepted here (a throw from a sibling catch is
            // not caught by later catch clauses of the same try).
            ex.Data[StorageErrorMapper.PlatformErrorDataKey] = true;
            throw;
        }
    }

    private static string ToWireStatus(Core.Tasks.TaskStatus status) => status switch
    {
        Core.Tasks.TaskStatus.Pending => "pending",
        Core.Tasks.TaskStatus.InProgress => "in_progress",
        Core.Tasks.TaskStatus.Suspended => "suspended",
        Core.Tasks.TaskStatus.Completed => "completed",
        _ => status.ToString().ToLowerInvariant(),
    };
    /// <summary>
    /// Builds the <c>queued</c> envelope surfaced to the caller for a steered turn. When a
    /// <see cref="ResponsesServerOptions.ResponseAcceptor"/> hook is configured it is invoked to
    /// customize the envelope; a throwing hook falls back to the default envelope (logged at
    /// warning). The returned object's status is normalized to <see cref="ResponseStatus.Queued"/>.
    /// </summary>
    private ResponseObject BuildQueuedEnvelope(
        CreateResponse request, ResponseContext context, string responseId)
    {
        var acceptor = _options.Value.ResponseAcceptor;
        if (acceptor is not null)
        {
            try
            {
                var customized = acceptor(request, context);
                if (customized is not null)
                {
                    customized.Status ??= ResponseStatus.Queued;
                    return customized;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,
                    "Response acceptor hook threw for response {ResponseId}; falling back to the default queued envelope.",
                    responseId);
            }
        }

        return new ResponseObject(responseId, request.Model ?? string.Empty)
        {
            Status = ResponseStatus.Queued,
        };
    }

    /// <summary>
    /// Handles GET /responses/{responseId} — returns current response state or SSE replay.
    /// Uses <c>?stream=true</c> query parameter to trigger SSE replay, else delegates
    /// guard logic and snapshot to <see cref="ResponseOrchestrator.GetAsync"/>.
    /// </summary>
    public async Task<IResult> GetResponseAsync(HttpContext httpContext, string responseId)
    {
        ValidateResponseIdFormat(responseId);
        var platformContext = PlatformContext.FromRequest(httpContext.Request);

        // SSE replay trigger: ?stream=true query parameter (B2)
        if (httpContext.Request.Query.TryGetValue("stream", out var streamValue)
            && string.Equals(streamValue, "true", StringComparison.OrdinalIgnoreCase))
        {
            _logger.LogInformation(
                "Getting response {ResponseId} with SSE replay: HasUserId={HasUserId} HasCallId={HasCallId}",
                responseId, platformContext.UserIdKey is not null, platformContext.CallId is not null);
            // Apply B2 guards: SSE replay requires background + streaming + store.
            if (_tracker.TryGet(responseId, out var execution) && execution is not null)
            {
                // User-key enforcement for in-flight responses
                execution.EnforceUserIsolation(platformContext);

                // Store resolved session ID for the response header filter.
                // Use execution.AgentSessionId (set at creation time) instead of
                // execution.Response?.AgentSessionId, which can be null before
                // the handler yields response.created.
                httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = execution.AgentSessionId;

                // In-flight: mode flags are available on the execution.
                if (!execution.Store)
                {
                    throw new ResourceNotFoundException($"Response '{responseId}' not found.");
                }

                // Guard: SSE replay requires background (B2)
                if (!execution.IsBackground)
                {
                    throw new BadRequestException(
                        "This response cannot be streamed because it was not created with background=true.",
                        code: null,
                        paramName: "stream");
                }

                // Guard: SSE replay requires streaming (B2)
                if (!execution.IsStreaming)
                {
                    throw new BadRequestException(
                        "This response cannot be streamed because it was not created with stream=true.",
                        code: null,
                        paramName: "stream");
                }
            }
            else
            {
                // Not in-flight (evicted or never tracked): verify the response exists
                // in the provider and check B2 mode flags from the persisted response.
                // Provider throws ResourceNotFoundException (404) for unknown IDs.
                // This also covers store=false (never persisted → 404).
                var persisted = await _provider.GetResponseAsync(responseId, platformContext);
                httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = persisted.AgentSessionId;

                // B2: SSE replay requires background mode. Non-bg responses never
                // have event streams (they use NullPublisher).
                if (persisted.Background != true)
                {
                    throw new BadRequestException(
                        "This response cannot be streamed because it was not created with background=true.",
                        code: null,
                        paramName: "stream");
                }
            }

            // In-flight and passed guards OR not-in-flight and exists in provider —
            // replay from the Core event-stream registry, which retains buffered events
            // (in-memory with TTL, or file-backed for durable resilient background) so
            // a reconnecting client can resume even after in-flight execution is gone.

            // Parse starting_after query parameter (B4). When present but not parseable as an
            // integer, reject with 400 invalid_request rather than silently full-replaying
            // (parity with Python `_parse_starting_after`).
            long? startingAfter = null;
            if (httpContext.Request.Query.TryGetValue("starting_after", out var startingAfterValue)
                && !StringValues.IsNullOrEmpty(startingAfterValue))
            {
                if (!long.TryParse(startingAfterValue, out var parsedValue))
                {
                    throw new BadRequestException(
                        "The 'starting_after' query parameter must be an integer.",
                        code: null,
                        paramName: "starting_after");
                }

                startingAfter = parsedValue;
            }

            return new SseReplayResult(
                _eventStreamRegistry, responseId, SharedJsonOptions.Instance, _logger,
                FoundryEnvironment.SseKeepAliveInterval, startingAfter);
        }

        // Delegate guard logic and snapshot to orchestrator
        _logger.LogInformation(
            "Getting response {ResponseId}: HasUserId={HasUserId} HasCallId={HasCallId}",
            responseId, platformContext.UserIdKey is not null, platformContext.CallId is not null);
        var response = await _orchestrator.GetAsync(responseId, platformContext);
        httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = response.AgentSessionId;
        _logger.LogInformation(
            "Retrieved response {ResponseId}: Status={Status} OutputCount={OutputCount}",
            responseId, response.Status, response.Output.Count);
        return JsonForClient(response);
    }
    /// <summary>
    /// Handles POST /responses/{responseId}/cancel — delegates to orchestrator.
    /// </summary>
    public async Task<IResult> CancelResponseAsync(HttpContext httpContext, string responseId)
    {
        ValidateResponseIdFormat(responseId);
        var platformContext = PlatformContext.FromRequest(httpContext.Request);
        _logger.LogInformation(
            "Cancelling response {ResponseId}: HasUserId={HasUserId} HasCallId={HasCallId}",
            responseId, platformContext.UserIdKey is not null, platformContext.CallId is not null);
        var response = await _orchestrator.CancelAsync(responseId, platformContext);
        httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = response.AgentSessionId;
        _logger.LogInformation("Cancelled response {ResponseId}, status={Status}", responseId, response.Status);
        return JsonForClient(response);
    }

    /// <summary>
    /// Handles DELETE /responses/{responseId} — deletes a stored response.
    /// Guards: not-found (404), in-flight (400), store=false (404).
    /// </summary>
    public async Task<IResult> DeleteResponseAsync(HttpContext httpContext, string responseId)
    {
        ValidateResponseIdFormat(responseId);
        var platformContext = PlatformContext.FromRequest(httpContext.Request);
        _logger.LogInformation(
            "Deleting response {ResponseId}: HasUserId={HasUserId} HasCallId={HasCallId}",
            responseId, platformContext.UserIdKey is not null, platformContext.CallId is not null);

        // Guard: if response is in-flight, reject deletion.
        // With eager eviction, all tracked executions are in-flight — completed
        // responses are evicted by FinalizeExecutionAsync and served from the provider.
        if (_tracker.TryGet(responseId, out var execution) && execution is not null)
        {
            // User-key enforcement for in-flight responses
            execution.EnforceUserIsolation(platformContext);

            // Store resolved session ID for the response header filter (error paths).
            // Use execution.AgentSessionId (set at creation time) — execution.Response
            // can be null before handler yields response.created.
            httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = execution.AgentSessionId;

            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // Persistence-failed responses are terminal — evict from tracker and
            // attempt to clean up storage. In background mode, Phase 1 (CreateResponse)
            // may have succeeded before Phase 2 (UpdateResponse) failed, so the response
            // could exist in storage. Best-effort delete — ignore NotFound.
            if (execution.PersistenceFailed)
            {
                _tracker.TryEvict(responseId);

                try
                {
                    await _provider.DeleteResponseAsync(responseId, platformContext);
                }
                catch (ResourceNotFoundException)
                {
                    // Expected for non-background mode where CreateResponse never ran.
                }

                try
                {
                    await _eventStreamRegistry.DeleteAsync(responseId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Event-stream delete failed during persistence-failed cleanup for {ResponseId}", responseId);
                }

                var deleteResult = AgentServerResponsesModelFactory.DeleteResponseResult(id: responseId);
                _logger.LogInformation("Deleted persistence-failed response {ResponseId}", responseId);
                return JsonForClient(deleteResult);
            }

            // B16: non-background in-flight responses are not findable
            if (!execution.IsBackground)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // A background execution that has already reached a terminal status is deletable
            // even though it has not yet been evicted from the tracker: FinalizeExecutionAsync
            // persists the terminal snapshot (durable I/O) BEFORE it evicts, so a caller that
            // has observed the terminal status via GET can race the eviction. Only a genuinely
            // non-terminal (still-running) background execution is rejected as in-flight.
            if (!ResponseOrchestrator.IsTerminalStatus(execution.Response?.Status))
            {
                throw new BadRequestException(
                    "Cannot delete an in-flight response.");
            }

            // Terminal but not yet evicted — wait for FinalizeExecutionAsync to finish (durable
            // persist + tracker eviction fire before the signal) so the durable provider is the
            // authoritative source below. Bounded so a stuck finalizer cannot hang the request.
            try
            {
                await execution.FinalizedSignal.Task.WaitAsync(TimeSpan.FromSeconds(10));
            }
            catch (TimeoutException)
            {
                _tracker.TryEvict(responseId);
            }
        }

        // Delegate deletion to provider (throws ResourceNotFoundException if not found).
        // This works whether or not the response was in the tracker — the provider
        // is the source of truth for persisted responses.
        // Read response first to capture session ID for the response header.
        var persisted = await _provider.GetResponseAsync(responseId, platformContext);
        httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = persisted.AgentSessionId;
        await _provider.DeleteResponseAsync(responseId, platformContext);

        // Clean up event stream — deleted responses should not be replayable.
        try
        {
            await _eventStreamRegistry.DeleteAsync(responseId);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Event-stream delete failed during response deletion for {ResponseId}", responseId);
        }

        var result = AgentServerResponsesModelFactory.DeleteResponseResult(id: responseId);
        _logger.LogInformation("Deleted response {ResponseId}", responseId);
        return JsonForClient(result);
    }

    /// <summary>
    /// Handles GET /responses/{responseId}/input_items — returns paginated input items.
    /// Query params: limit (1–100, default 20), order (asc/desc, default desc),
    /// after (cursor), before (cursor).
    /// </summary>
    public async Task<IResult> GetInputItemsAsync(HttpContext httpContext, string responseId)
    {
        ValidateResponseIdFormat(responseId);
        var platformContext = PlatformContext.FromRequest(httpContext.Request);
        _logger.LogInformation(
            "Getting input items for response {ResponseId}: HasUserId={HasUserId} HasCallId={HasCallId}",
            responseId, platformContext.UserIdKey is not null, platformContext.CallId is not null);

        // Read response to capture session ID for the response header.
        // Also validates existence (throws ResourceNotFoundException if not found).
        var response = await _provider.GetResponseAsync(responseId, platformContext);
        httpContext.Items[SessionIdResponseHeaderFilter.SessionIdKey] = response.AgentSessionId;

        // Parse limit (default 20, range 1–100)
        int limit = 20;
        if (httpContext.Request.Query.TryGetValue("limit", out var limitValue))
        {
            if (!int.TryParse(limitValue, out limit) || limit < 1 || limit > 100)
            {
                throw new BadRequestException(
                    "Parameter 'limit' must be an integer between 1 and 100.",
                    paramName: "limit");
            }
        }

        // Parse order (default desc)
        bool ascending = false;
        if (httpContext.Request.Query.TryGetValue("order", out var orderValue))
        {
            if (string.Equals(orderValue, "asc", StringComparison.OrdinalIgnoreCase))
            {
                ascending = true;
            }
            else if (!string.Equals(orderValue, "desc", StringComparison.OrdinalIgnoreCase))
            {
                throw new BadRequestException(
                    "Parameter 'order' must be 'asc' or 'desc'.",
                    paramName: "order");
            }
        }

        // Parse cursor params
        string? after = httpContext.Request.Query.TryGetValue("after", out var afterValue)
            ? (string?)afterValue : null;
        string? before = httpContext.Request.Query.TryGetValue("before", out var beforeValue)
            ? (string?)beforeValue : null;

        var result = await _provider.GetInputItemsAsync(
            responseId, platformContext, limit, ascending, after, before, httpContext.RequestAborted);

        return JsonForClient(result);
    }

    /// <summary>
    /// Extracts headers prefixed with <c>x-client-</c> from the request.
    /// </summary>
    private static IReadOnlyDictionary<string, string> ExtractClientHeaders(HttpRequest request)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var header in request.Headers)
        {
            if (header.Key.StartsWith("x-client-", StringComparison.OrdinalIgnoreCase))
            {
                result[header.Key] = header.Value.ToString();
            }
        }

        return result;
    }

    /// <summary>
    /// Extracts all query parameters from the request.
    /// </summary>
    private static IReadOnlyDictionary<string, StringValues> ExtractQueryParameters(HttpRequest request)
    {
        var result = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase);
        foreach (var param in request.Query)
        {
            result[param.Key] = param.Value;
        }

        return result;
    }

    private static IResult JsonForClient<T>(T payload)
    {
        var sanitized = ClientPayloadSanitizer.SanitizeForClient(payload, SharedJsonOptions.Instance);
        return Results.Json(sanitized, SharedJsonOptions.Instance, statusCode: 200);
    }
}
