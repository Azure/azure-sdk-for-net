// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Runtime.User;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenTelemetry;

namespace Azure.AI.AgentServer.Core.Server.Middleware;

/// <summary>
/// Middleware that creates and sets up AgentRunContext for agent run endpoints (/runs and /responses).
/// Parses the request body, retrieves user information, and sets up OpenTelemetry baggage for tracing.
/// </summary>
public class AgentRunContextMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AgentRunContextMiddleware> _logger;
    private readonly IEnumerable<object>? _agentTools;

    /// <summary>
    /// Initializes a new instance of the <see cref="AgentRunContextMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    /// <param name="agentTools">Optional collection of agent tools to include in the context.</param>
    public AgentRunContextMiddleware(
        RequestDelegate next,
        ILogger<AgentRunContextMiddleware> logger,
        IEnumerable<object>? agentTools = null)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _agentTools = agentTools;
    }

    /// <summary>
    /// Invokes the middleware to create and set up agent run context.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        // Only process agent run endpoints
        if (!IsAgentRunEndpoint(httpContext.Request.Path))
        {
            await _next(httpContext).ConfigureAwait(false);
            return;
        }

        // Extract request ID from headers
        var requestId = GetRequestId(httpContext);
        if (requestId != null)
        {
            SetRequestIdInBaggage(requestId);
        }

        // Parse request body
        CreateResponseRequest request;
        IReadOnlyDictionary<string, object?> rawPayload;
        try
        {
            (request, rawPayload) = await ParseRequestBodyAsync(httpContext).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to parse request body for agent run endpoint.");
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                error = new
                {
                    message = $"Invalid JSON payload: {ex.Message}",
                    type = "invalid_request_error"
                }
            }).ConfigureAwait(false);
            return;
        }

        // Get user info from AsyncLocal (set by UserInfoContextMiddleware)
        var userInfo = AsyncLocalUserProvider.Current;

        // Get agent tools from DI or constructor
        var tools = _agentTools?.ToList() ?? new List<object>();

        // Create agent run context
        var context = new AgentRunContext(
            request,
            rawPayload,
            userInfo,
            tools);

        // Store in HttpContext.Items for endpoint access
        httpContext.Items["AgentRunContext"] = context;

        // Set up AsyncLocal storage and OpenTelemetry baggage
        await using var contextScope = AgentRunContext.Setup(context).ConfigureAwait(false);
        SetRunContextInBaggage(context);

        try
        {
            await _next(httpContext).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing agent run request.");

            if (!httpContext.Response.HasStarted)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    error = new
                    {
                        message = $"Internal server error: {ex.Message}",
                        type = "internal_error"
                    }
                }).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Determines if the request path is an agent run endpoint.
    /// </summary>
    private static bool IsAgentRunEndpoint(PathString path)
    {
        return path.StartsWithSegments("/runs") ||
               path.StartsWithSegments("/responses");
    }

    /// <summary>
    /// Extracts the request ID from the X-Request-Id header.
    /// </summary>
    private static string? GetRequestId(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue("X-Request-Id", out var value))
        {
            return value.ToString();
        }

        return null;
    }

    /// <summary>
    /// Parses the request body into a CreateResponseRequest and raw dictionary.
    /// </summary>
    private static async Task<(CreateResponseRequest Request, IReadOnlyDictionary<string, object?> RawPayload)> ParseRequestBodyAsync(
        HttpContext httpContext)
    {
        // Enable buffering to allow multiple reads of the request body
        httpContext.Request.EnableBuffering();

        var bodyStream = httpContext.Request.Body;
        bodyStream.Position = 0;

        // Read as JsonElement first
        var jsonElement = await JsonSerializer.DeserializeAsync<JsonElement>(
            bodyStream,
            cancellationToken: httpContext.RequestAborted).ConfigureAwait(false);

        // Reset stream for potential downstream reads
        bodyStream.Position = 0;

        // Deserialize to dictionary for raw payload
        var rawPayload = JsonSerializer.Deserialize<Dictionary<string, object?>>(
            jsonElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions)
            ?? new Dictionary<string, object?>();

        // Deserialize to typed request
        var request = JsonSerializer.Deserialize<CreateResponseRequest>(
            jsonElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize CreateResponseRequest.");

        return (request, rawPayload);
    }

    /// <summary>
    /// Sets the request ID in OpenTelemetry baggage.
    /// </summary>
    private static void SetRequestIdInBaggage(string requestId)
    {
        Baggage.SetBaggage("azure.ai.agentserver.x-request-id", requestId);
    }

    /// <summary>
    /// Sets agent run context information in OpenTelemetry baggage for distributed tracing.
    /// </summary>
    private static void SetRunContextInBaggage(AgentRunContext context)
    {
        Baggage.SetBaggage("azure.ai.agentserver.response_id", context.ResponseId);
        Baggage.SetBaggage("azure.ai.agentserver.conversation_id", context.ConversationId);
        Baggage.SetBaggage("azure.ai.agentserver.streaming", context.Stream.ToString());

        var agentRef = context.GetAgentIdObject();
        if (agentRef != null && !string.IsNullOrEmpty(agentRef.Name))
        {
            Baggage.SetBaggage("gen_ai.agent.name", agentRef.Name);

            if (!string.IsNullOrEmpty(agentRef.Version))
            {
                Baggage.SetBaggage("gen_ai.agent.id", $"{agentRef.Name}:{agentRef.Version}");
            }
            else
            {
                Baggage.SetBaggage("gen_ai.agent.id", agentRef.Name);
            }
        }

        Baggage.SetBaggage("gen_ai.provider.name", "AzureAI Hosted Agents");
        Baggage.SetBaggage("gen_ai.response.id", context.ResponseId);
    }
}

/// <summary>
/// Extension methods for registering agent run context middleware.
/// </summary>
public static class AgentRunContextMiddlewareExtensions
{
    /// <summary>
    /// Adds the agent run context middleware to the application pipeline.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="agentTools">Optional collection of agent tools to include in the context.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseAgentRunContext(
        this IApplicationBuilder app,
        IEnumerable<object>? agentTools = null)
    {
        return agentTools == null
            ? app.UseMiddleware<AgentRunContextMiddleware>()
            : app.UseMiddleware<AgentRunContextMiddleware>(agentTools);
    }
}
