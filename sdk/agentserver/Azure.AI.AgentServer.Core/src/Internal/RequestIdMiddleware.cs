// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that sets the <c>x-request-id</c> response header on every HTTP response.
/// The value is resolved in priority order:
/// <list type="number">
///   <item>Current OTEL trace ID (<see cref="Activity.Current"/>?.TraceId).</item>
///   <item>Incoming <c>x-request-id</c> request header (client-provided correlation ID).</item>
///   <item>A new <see cref="Guid"/> as fallback.</item>
/// </list>
/// The resolved value is also stored in <see cref="HttpContext.Items"/> under
/// <see cref="RequestIdKey"/> for use by downstream filters (e.g., error body enrichment).
/// </summary>
internal sealed class RequestIdMiddleware : IMiddleware
{
    /// <summary>
    /// Key used to store/retrieve the resolved request ID in <see cref="HttpContext.Items"/>.
    /// </summary>
    internal const string RequestIdKey = PlatformHeaders.RequestIdItemKey;

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var requestId = ResolveRequestId(context);

        context.Items[RequestIdKey] = requestId;

        context.Response.OnStarting(state =>
        {
            var ctx = (HttpContext)state;
            ctx.Response.Headers[PlatformHeaders.RequestId] = (string)ctx.Items[RequestIdKey]!;
            return Task.CompletedTask;
        }, context);

        await next(context);
    }

    private static string ResolveRequestId(HttpContext context)
    {
        // Priority 1: OTEL trace ID from current activity
        var activity = Activity.Current;
        if (activity is not null)
        {
            var traceId = activity.TraceId.ToString();
            if (!string.IsNullOrEmpty(traceId) && traceId != "00000000000000000000000000000000")
            {
                return traceId;
            }
        }

        // Priority 2: Incoming x-request-id header
        if (context.Request.Headers.TryGetValue(PlatformHeaders.RequestId, out var incomingValues))
        {
            var incoming = incomingValues.ToString();
            if (!string.IsNullOrEmpty(incoming))
            {
                return incoming;
            }
        }

        // Priority 3: New GUID
        return Guid.NewGuid().ToString("N");
    }
}
