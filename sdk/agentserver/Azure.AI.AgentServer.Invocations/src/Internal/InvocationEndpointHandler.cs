// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Orchestrates invocation request processing: resolves IDs, extracts headers/params,
/// starts tracing span, constructs <see cref="InvocationContext"/>, calls the handler,
/// and injects response headers.
/// </summary>
internal sealed class InvocationEndpointHandler
{
    private const string InvocationIdResponseHeader = "x-agent-invocation-id";
    private const string SessionIdResponseHeader = "x-agent-session-id";

    private readonly InvocationsActivitySource _activitySource;
    private readonly ILogger<InvocationEndpointHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="InvocationEndpointHandler"/>.
    /// </summary>
    public InvocationEndpointHandler(
        InvocationsActivitySource activitySource,
        ILogger<InvocationEndpointHandler> logger)
    {
        _activitySource = activitySource;
        _logger = logger;
    }

    /// <summary>
    /// Handles <c>POST /invocations</c>.
    /// </summary>
    internal async Task HandleInvokeAsync(HttpContext httpContext, InvocationHandler handler)
    {
        var request = httpContext.Request;
        var response = httpContext.Response;

        // Resolve IDs
        var invocationId = InvocationIdResolver.Resolve(request);
        var sessionId = SessionIdResolver.Resolve(request);

        // Extract headers and query params
        var clientHeaders = ClientHeaderForwarder.ExtractClientHeaders(request);
        var queryParams = ClientHeaderForwarder.ExtractQueryParameters(request);

        // Construct context
        var context = new InvocationContext(invocationId, sessionId, clientHeaders, queryParams);

        // Start tracing span
        using var activity = _activitySource.StartInvocationActivity(context, request.Headers);

        // Structured log scope
        using var logScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["InvocationId"] = invocationId,
            ["SessionId"] = sessionId,
        });

        try
        {
            // Inject response headers before handler writes body
            response.OnStarting(() =>
            {
                response.Headers[InvocationIdResponseHeader] = invocationId;
                response.Headers[SessionIdResponseHeader] = sessionId;
                return Task.CompletedTask;
            });

            await handler.HandleAsync(request, response, context, httpContext.RequestAborted);
        }
        catch (Exception ex)
        {
            InvocationsExceptionFilter.RecordException(activity, ex);
            throw;
        }
    }

    /// <summary>
    /// Handles <c>GET /invocations/{invocationId}</c>.
    /// </summary>
    internal async Task HandleGetAsync(HttpContext httpContext, string invocationId, InvocationHandler handler)
    {
        await handler.GetAsync(invocationId, httpContext.Request, httpContext.Response, httpContext.RequestAborted);
    }

    /// <summary>
    /// Handles <c>POST /invocations/{invocationId}/cancel</c>.
    /// </summary>
    internal async Task HandleCancelAsync(HttpContext httpContext, string invocationId, InvocationHandler handler)
    {
        await handler.CancelAsync(invocationId, httpContext.Request, httpContext.Response, httpContext.RequestAborted);
    }

    /// <summary>
    /// Handles <c>GET /invocations/docs/openapi.json</c>.
    /// </summary>
    internal async Task HandleGetOpenApiAsync(HttpContext httpContext, InvocationHandler handler)
    {
        await handler.GetOpenApiAsync(httpContext.Request, httpContext.Response, httpContext.RequestAborted);
    }
}
