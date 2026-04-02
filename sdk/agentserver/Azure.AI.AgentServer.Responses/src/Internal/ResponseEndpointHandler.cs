// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Validators;
using Microsoft.AspNetCore.Http;
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
    private readonly ResponsesStreamProvider _streamProvider;
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
        ResponsesProvider provider,
        ResponsesCancellationSignalProvider cancellationProvider,
        ResponsesStreamProvider streamProvider,
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

            // Deserialize from the buffered bytes
            request = JsonSerializer.Deserialize<CreateResponse>(bodyBytes, SharedJsonOptions.Instance)
                ?? throw new BadRequestException("Request body is required.");

            // Capture raw bytes for ResponseContext.RawBody
            rawBody = BinaryData.FromBytes(bodyBytes);
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

        // S-047: Use x-agent-response-id header as the response ID if present,
        // giving platform/middletier services full control over ID generation.
        // Otherwise, generate one with partition key colocation.
        string responseId;
        if (httpContext.Request.Headers.TryGetValue(AgentResponseIdHeader, out var agentResponseIdValue)
            && !string.IsNullOrEmpty(agentResponseIdValue.ToString()))
        {
            responseId = agentResponseIdValue.ToString();
        }
        else
        {
            var partitionKeyHint = request.PreviousResponseId
                ?? request.GetConversationId()
                ?? "";
            responseId = IdGenerator.NewResponseId(partitionKeyHint);
        }

        // S-048: Resolve session ID — request payload → environment variable → generated UUID.
        // Stamp on the request so the orchestrator can propagate it to the ResponseObject.
        if (string.IsNullOrEmpty(request.AgentSessionId))
        {
            request.AgentSessionId = !string.IsNullOrEmpty(FoundryEnvironment.SessionId)
                ? FoundryEnvironment.SessionId
                : Guid.NewGuid().ToString();
        }

        // Start distributed tracing span — delegates all tag/baggage logic
        // to ResponsesActivitySource.StartCreateResponseActivity (virtual, overridable).
        // Do NOT use 'using' — for streaming, SseResult takes ownership and disposes
        // the activity when the SSE stream completes so the span covers the full
        // streaming duration. For non-streaming, disposed in the finally block below.
        var activity = _activitySource.StartCreateResponseActivity(
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

        // Extract x-client-* headers and query parameters for ResponseContext
        var clientHeaders = ExtractClientHeaders(httpContext.Request);
        var queryParameters = ExtractQueryParameters(httpContext.Request);
        var isolation = IsolationContext.FromRequest(httpContext.Request);

        var context = new ResponseContextImpl(
            responseId,
            _provider,
            request,
            _options,
            rawBody,
            clientHeaders,
            queryParameters,
            isolation);
        execution.Context = context;

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

                // SseResult takes ownership of linkedCts and activity — it will
                // dispose both when the SSE stream completes, ensuring the tracing
                // span covers the full streaming duration.
                var sseResult = new SseResult(
                    result.Events!, execution, linkedCts, activity,
                    SharedJsonOptions.Instance, _logger, FoundryEnvironment.SseKeepAliveInterval);

                // Ownership transferred — prevent the catch/finally from disposing.
                linkedCts = null;
                activity = null;
                return sseResult;
            }
            catch
            {
                // If CreateAsync or SseResult construction fails, we still own
                // the resources — dispose them before re-throwing.
                linkedCts?.Dispose();
                activity?.Dispose();
                throw;
            }
        }
        else if (isBackground)
        {
            try
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
            finally
            {
                activity?.Dispose();
            }
        }
        else
        {
            try
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
            finally
            {
                activity?.Dispose();
            }
        }
    }

    /// <summary>
    /// Handles GET /responses/{responseId} — returns current response state or SSE replay.
    /// Uses <c>?stream=true</c> query parameter to trigger SSE replay, else delegates
    /// guard logic and snapshot to <see cref="ResponseOrchestrator.GetAsync"/>.
    /// </summary>
    public async Task<IResult> GetResponseAsync(HttpContext httpContext, string responseId)
    {
        var isolation = IsolationContext.FromRequest(httpContext.Request);

        // SSE replay trigger: ?stream=true query parameter (FR-005)
        if (httpContext.Request.Query.TryGetValue("stream", out var streamValue)
            && string.Equals(streamValue, "true", StringComparison.OrdinalIgnoreCase))
        {
            // Apply B2 guards: SSE replay requires background + streaming + store.
            if (_tracker.TryGet(responseId, out var execution) && execution is not null)
            {
                // In-flight: mode flags are available on the execution.
                if (!execution.Store)
                {
                    throw new ResourceNotFoundException($"Response '{responseId}' not found.");
                }

                // Guard: SSE replay requires background + streaming (B2, FR-013)
                if (!execution.IsBackground || !execution.IsStreaming)
                {
                    throw new BadRequestException(
                        "SSE replay is only available for background streaming responses.");
                }
            }
            else
            {
                // Not in-flight: verify the response exists in the provider before
                // attempting replay. Provider throws ResourceNotFoundException (404)
                // for unknown IDs and BadRequestException (400) for deleted responses.
                // This also covers store=false (never persisted → 404).
                await _provider.GetResponseAsync(responseId, isolation);

                // TODO: B2 requires checking that the response was created with
                // background=true AND stream=true. After the execution leaves the
                // tracker, mode flags are not persisted on the Response model.
                // The stream provider may still have events for non-bg responses
                // within the EventStreamTtl window. A full fix requires storing
                // mode flags in the provider or stream provider abstract class.
            }

            // In-flight and passed guards OR not-in-flight and exists in provider —
            // delegate to the stream provider. A pluggable ResponsesStreamProvider
            // backed by persistent storage (Redis, Kafka, etc.) can replay events
            // even after the in-flight execution is gone.

            // Parse starting_after query parameter (FR-016)
            long? startingAfter = null;
            if (httpContext.Request.Query.TryGetValue("starting_after", out var startingAfterValue)
                && long.TryParse(startingAfterValue, out var parsedValue))
            {
                startingAfter = parsedValue;
            }

            return new SseReplayResult(
                _streamProvider, responseId, SharedJsonOptions.Instance, _logger,
                FoundryEnvironment.SseKeepAliveInterval, startingAfter);
        }

        // Delegate guard logic and snapshot to orchestrator
        var response = await _orchestrator.GetAsync(responseId, isolation);
        return Results.Json(response, SharedJsonOptions.Instance, statusCode: 200);
    }
    /// <summary>
    /// Handles POST /responses/{responseId}/cancel — delegates to orchestrator.
    /// </summary>
    public async Task<IResult> CancelResponseAsync(HttpContext httpContext, string responseId)
    {
        var isolation = IsolationContext.FromRequest(httpContext.Request);
        var response = await _orchestrator.CancelAsync(responseId, isolation);
        return Results.Json(response, SharedJsonOptions.Instance, statusCode: 200);
    }

    /// <summary>
    /// Handles DELETE /responses/{responseId} — deletes a stored response.
    /// Guards: not-found (404), in-flight (400), store=false (404).
    /// </summary>
    public async Task<IResult> DeleteResponseAsync(HttpContext httpContext, string responseId)
    {
        var isolation = IsolationContext.FromRequest(httpContext.Request);

        // Guard: if response is in-flight, check for store=false and in-progress guards
        if (_tracker.TryGet(responseId, out var execution) && execution is not null)
        {
            if (!execution.Store)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // B16: non-background in-flight responses are not findable
            if (!execution.IsBackground && execution.CompletedAt is null)
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }

            // In-flight guard: background response with no terminal state cannot be deleted
            if (execution.CompletedAt is null)
            {
                throw new BadRequestException(
                    "Response is currently in progress and cannot be deleted.");
            }

            _tracker.TryRemove(responseId);
        }

        // Delegate deletion to provider (throws ResourceNotFoundException if not found).
        // This works whether or not the response was in the tracker — the provider
        // is the source of truth for persisted responses.
        await _provider.DeleteResponseAsync(responseId, isolation);

        var result = AzureAIAgentServerResponsesModelFactory.DeleteResponseResult(id: responseId);
        return Results.Json(result, SharedJsonOptions.Instance, statusCode: 200);
    }

    /// <summary>
    /// Handles GET /responses/{responseId}/input_items — returns paginated input items.
    /// Query params: limit (1–100, default 20), order (asc/desc, default desc),
    /// after (cursor), before (cursor).
    /// </summary>
    public async Task<IResult> GetInputItemsAsync(HttpContext httpContext, string responseId)
    {
        var isolation = IsolationContext.FromRequest(httpContext.Request);
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
            responseId, isolation, limit, ascending, after, before, httpContext.RequestAborted);

        return Results.Json(result, SharedJsonOptions.Instance, statusCode: 200);
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
}
