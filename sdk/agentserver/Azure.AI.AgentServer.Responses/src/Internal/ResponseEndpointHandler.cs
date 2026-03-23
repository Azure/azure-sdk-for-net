// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Contains the endpoint handler methods for the Responses API.
/// </summary>
internal sealed class ResponseEndpointHandler
{
    private readonly ResponsesActivitySource _activitySource;
    private readonly ResponseOrchestrator _orchestrator;
    private readonly ResponseExecutionTracker _tracker;
    private readonly IResponsesProvider _provider;
    private readonly IResponsesCancellationSignalProvider _cancellationProvider;
    private readonly IResponsesStreamProvider _streamProvider;
    private readonly IOptions<ResponsesServerOptions> _options;
    private readonly ILogger<ResponseEndpointHandler> _logger;
    private readonly IPayloadValidator _validator;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseEndpointHandler"/>.
    /// </summary>
    public ResponseEndpointHandler(
        ResponsesActivitySource activitySource,
        ResponseOrchestrator orchestrator,
        ResponseExecutionTracker tracker,
        IResponsesProvider provider,
        IResponsesCancellationSignalProvider cancellationProvider,
        IResponsesStreamProvider streamProvider,
        IOptions<ResponsesServerOptions> options,
        ILogger<ResponseEndpointHandler> logger,
        IPayloadValidator validator)
    {
        _activitySource = activitySource;
        _orchestrator = orchestrator;
        _tracker = tracker;
        _provider = provider;
        _cancellationProvider = cancellationProvider;
        _streamProvider = streamProvider;
        _options = options;
        _logger = logger;
        _validator = validator;
    }

    /// <summary>
    /// Handles POST /responses — creates a new response and handles all 4 modes.
    /// </summary>
    public async Task<IResult> CreateResponseAsync(HttpContext httpContext)
    {
        CreateResponse request;
        JsonElement rawBody = default;
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

            // Deserialize from the buffered bytes
            request = JsonSerializer.Deserialize<CreateResponse>(bodyBytes, SharedJsonOptions.Instance)
                ?? throw new BadRequestException("Request body is required.");

            // Parse raw body for IResponseContext.RawBody — clone decouples from JsonDocument lifetime
            rawBody = JsonDocument.Parse(bodyBytes).RootElement.Clone();
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

        _logger.LogInformation(
            "Creating response: Streaming={IsStreaming} Background={IsBackground} Model={Model}",
            isStreaming, isBackground, request.Model);

        // Generate response ID with partition key hint from request
        // Priority: previous_response_id → conversation ID → fresh
        var partitionKeyHint = request.PreviousResponseId
            ?? request.GetConversationId()
            ?? "";
        var responseId = IdGenerator.NewResponseId(partitionKeyHint);

        // Start distributed tracing span — delegates all tag/baggage logic
        // to ResponsesActivitySource.StartCreateResponseActivity (virtual, overridable).
        using var activity = _activitySource.StartCreateResponseActivity(
            request, responseId, httpContext.Request.Headers);

        // Structured log scope — matches Core's HostedAgentTelemetry.StartActivity
        // for parity: ResponseId, ConversationId, Streaming appear on all log lines.
        using var logScope = _logger.BeginScope(new Dictionary<string, object?>
        {
            [ResponsesTracingConstants.LogScope.ResponseId] = responseId,
            [ResponsesTracingConstants.LogScope.ConversationId] = request.GetConversationId() ?? string.Empty,
            [ResponsesTracingConstants.LogScope.Streaming] = isStreaming,
        });

        var execution = _tracker.Create(responseId, isBackground, isStreaming, store);
        var context = new ResponseContextImpl(
            responseId,
            _provider,
            request,
            _options,
            rawBody);
        execution.Context = context;

        // Get cancellation token from provider (supports external cancel)
        var providerCt = await _cancellationProvider.GetResponseCancellationTokenAsync(responseId);

        if (isStreaming)
        {
            // Streaming (bg or non-bg): create orchestrator event stream, return SSE result.
            // CTS includes httpContext.RequestAborted for non-bg only (disconnect → cancel).
            // Do NOT use 'using' — SseResult takes ownership and disposes the CTS.
            CancellationTokenSource linkedCts;
            if (isBackground)
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

            return new SseResult(
                result.Events!, execution, linkedCts,
                SharedJsonOptions.Instance, _logger, _options.Value.SseKeepAliveInterval);
        }
        else if (isBackground)
        {
            // Background (non-streaming): run handler in background task.
            // Wait for response.created before returning — the handler's response
            // is the source of truth, not a SDK-constructed seed.
            execution.ExecutionTask = Task.Run(async () =>
            {
                using var bgLinkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                    providerCt, execution.CancellationTokenSource.Token);
                await _orchestrator.CreateAsync(request, execution, context, bgLinkedCts.Token);
            });

            // Await the handler's response.created (or a pre-created error).
            // If the handler fails before response.created, the signal faults
            // and the exception propagates to the exception filter → HTTP 500.
            // The signal delivers an independent snapshot — no re-snapshot needed.
            var handlerResponse = await execution.ResponseCreatedSignal.Task;
            return Results.Json(handlerResponse, SharedJsonOptions.Instance, statusCode: 200);
        }
        else
        {
            // Default (non-streaming, non-background): run to completion, return final response.
            // Order matters: register linked CTS first, then ClientDisconnected flag.
            // CancellationToken callbacks fire in LIFO order, so registering the flag
            // second ensures it is set before the linked CTS propagates cancellation
            // to the handler — matching the streaming path's registration order.
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                providerCt, execution.CancellationTokenSource.Token, httpContext.RequestAborted);
            httpContext.RequestAborted.Register(() => execution.ClientDisconnected = true);

            await _orchestrator.CreateAsync(request, execution, context, linkedCts.Token);

            return Results.Json(execution.Response!.Snapshot(), SharedJsonOptions.Instance, statusCode: 200);
        }
    }

    /// <summary>
    /// Handles GET /responses/{responseId} — returns current response state or SSE replay.
    /// Uses <c>?stream=true</c> query parameter to trigger SSE replay, else delegates
    /// guard logic and snapshot to <see cref="ResponseOrchestrator.GetAsync"/>.
    /// </summary>
    public async Task<IResult> GetResponseAsync(HttpContext httpContext, string responseId)
    {
        // SSE replay trigger: ?stream=true query parameter (FR-005)
        // Must check before delegating to orchestrator because replay requires
        // access to the execution for bg+streaming guard and the HTTP response for SSE.
        if (httpContext.Request.Query.TryGetValue("stream", out var streamValue)
            && string.Equals(streamValue, "true", StringComparison.OrdinalIgnoreCase))
        {
            if (!_tracker.TryGet(responseId, out var execution) || execution is null)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // Guard: SSE replay requires background + streaming (FR-013)
            if (!execution.IsBackground || !execution.IsStreaming)
            {
                throw new BadRequestException(
                    "SSE replay is only available for background streaming responses.");
            }

            // Parse starting_after query parameter (FR-016)
            long? startingAfter = null;
            if (httpContext.Request.Query.TryGetValue("starting_after", out var startingAfterValue)
                && long.TryParse(startingAfterValue, out var parsedValue))
            {
                startingAfter = parsedValue;
            }

            return new SseReplayResult(
                _streamProvider, responseId, SharedJsonOptions.Instance, _logger,
                _options.Value.SseKeepAliveInterval, startingAfter);
        }

        // Delegate guard logic and snapshot to orchestrator
        var response = await _orchestrator.GetAsync(responseId);
        return Results.Json(response, SharedJsonOptions.Instance, statusCode: 200);
    }
    /// <summary>
    /// Handles POST /responses/{responseId}/cancel — delegates to orchestrator.
    /// </summary>
    public async Task<IResult> CancelResponseAsync(HttpContext httpContext, string responseId)
    {
        var response = await _orchestrator.CancelAsync(responseId);
        return Results.Json(response, SharedJsonOptions.Instance, statusCode: 200);
    }

    /// <summary>
    /// Handles DELETE /responses/{responseId} — deletes a stored response.
    /// Guards: not-found (404), in-flight (400), store=false (404).
    /// </summary>
    public async Task<IResult> DeleteResponseAsync(HttpContext httpContext, string responseId)
    {
        // Guard: check execution tracker for in-flight status
        if (_tracker.TryGet(responseId, out var execution) && execution is not null)
        {
            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // In-flight guard: response with no terminal state cannot be deleted
            if (execution.CompletedAt is null)
            {
                throw new BadRequestException(
                    "Response is currently in progress and cannot be deleted.");
            }
        }

        // Delegate deletion to provider (throws ResourceNotFoundException if not found)
        await _provider.DeleteResponseAsync(responseId);

        // Remove from tracker as well
        _tracker.TryRemove(responseId);

        var result = new DeleteResponseResult(responseId);
        return Results.Json(result, SharedJsonOptions.Instance, statusCode: 200);
    }

    /// <summary>
    /// Handles GET /responses/{responseId}/input_items — returns paginated input items.
    /// Query params: limit (1–100, default 20), order (asc/desc, default desc),
    /// after (cursor), before (cursor).
    /// </summary>
    public async Task<IResult> GetInputItemsAsync(HttpContext httpContext, string responseId)
    {
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
            responseId, limit, ascending, after, before, httpContext.RequestAborted);

        return Results.Json(result, SharedJsonOptions.Instance, statusCode: 200);
    }
}
