// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
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
    private const string SessionIdResponseHeader = PlatformHeaders.SessionId;

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
        var isolation = IsolationContext.FromRequest(request);

        // Construct context
        var context = new InvocationContext(invocationId, sessionId, clientHeaders, queryParams, isolation);

        // Start tracing span
        using var activity = _activitySource.StartInvocationActivity(context, request.Headers);

        // Structured log scope
        using var logScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["InvocationId"] = invocationId,
            ["SessionId"] = sessionId,
        });

        _logger.LogInformation(
            "Handling invocation {InvocationId}: HasUserIsolationKey={HasUserIsolationKey} HasChatIsolationKey={HasChatIsolationKey}",
            invocationId, isolation.UserIsolationKey is not null, isolation.ChatIsolationKey is not null);

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
        var context = BuildContext(httpContext, invocationId);
        _logger.LogInformation(
            "Getting invocation {InvocationId}: HasUserIsolationKey={HasUserIsolationKey} HasChatIsolationKey={HasChatIsolationKey}",
            invocationId, context.Isolation.UserIsolationKey is not null, context.Isolation.ChatIsolationKey is not null);
        InjectSessionIdHeader(httpContext.Response, context.SessionId);
        await handler.GetAsync(invocationId, httpContext.Request, httpContext.Response, context, httpContext.RequestAborted);
    }

    /// <summary>
    /// Handles <c>POST /invocations/{invocationId}/cancel</c>.
    /// </summary>
    internal async Task HandleCancelAsync(HttpContext httpContext, string invocationId, InvocationHandler handler)
    {
        var context = BuildContext(httpContext, invocationId);
        _logger.LogInformation(
            "Cancelling invocation {InvocationId}: HasUserIsolationKey={HasUserIsolationKey} HasChatIsolationKey={HasChatIsolationKey}",
            invocationId, context.Isolation.UserIsolationKey is not null, context.Isolation.ChatIsolationKey is not null);
        InjectSessionIdHeader(httpContext.Response, context.SessionId);
        await handler.CancelAsync(invocationId, httpContext.Request, httpContext.Response, context, httpContext.RequestAborted);
    }

    /// <summary>
    /// Handles <c>GET /invocations/docs/openapi.json</c>.
    /// </summary>
    internal async Task HandleGetOpenApiAsync(HttpContext httpContext, InvocationHandler handler)
    {
        // OpenAPI docs endpoint — inject session ID from env var only (no invocation context).
        var sessionId = FoundryEnvironment.SessionId;
        if (!string.IsNullOrEmpty(sessionId))
        {
            httpContext.Response.Headers[SessionIdResponseHeader] = sessionId;
        }

        await handler.GetOpenApiAsync(httpContext.Request, httpContext.Response, httpContext.RequestAborted);
    }

    /// <summary>
    /// Builds an <see cref="InvocationContext"/> from the HTTP request.
    /// Used by GET and Cancel endpoints where the invocation ID comes from
    /// the route rather than a header.
    /// <para>
    /// Unlike POST /invocations, the GET and Cancel endpoints do not accept
    /// <c>agent_session_id</c> as a query parameter. The session ID is resolved
    /// from the environment variable only, falling back to a generated UUID.
    /// </para>
    /// </summary>
    private static InvocationContext BuildContext(HttpContext httpContext, string invocationId)
    {
        var request = httpContext.Request;

        // GET and Cancel do not support the agent_session_id query parameter.
        // Resolve session ID from env var only, falling back to a generated UUID.
        var sessionId = !string.IsNullOrEmpty(Core.FoundryEnvironment.SessionId)
            ? Core.FoundryEnvironment.SessionId
            : Guid.NewGuid().ToString();

        var clientHeaders = ClientHeaderForwarder.ExtractClientHeaders(request);
        var queryParams = ClientHeaderForwarder.ExtractQueryParameters(request);
        var isolation = IsolationContext.FromRequest(request);
        return new InvocationContext(invocationId, sessionId, clientHeaders, queryParams, isolation);
    }

    /// <summary>
    /// Injects the <c>x-agent-session-id</c> response header. Called before the
    /// handler writes the response body so the header is present on all responses.
    /// </summary>
    private static void InjectSessionIdHeader(HttpResponse response, string sessionId)
    {
        if (!string.IsNullOrEmpty(sessionId))
        {
            response.Headers[SessionIdResponseHeader] = sessionId;
        }
    }
}
