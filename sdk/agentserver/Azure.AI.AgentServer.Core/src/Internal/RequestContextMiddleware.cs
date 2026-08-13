// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that captures the platform identity headers
/// (<c>x-agent-foundry-call-id</c>, <c>x-agent-user-id</c>) off the inbound
/// request and binds them into the request-scoped <see cref="FoundryAgentRequestContext"/>
/// (an <see cref="System.Threading.AsyncLocal{T}"/>) before the handler runs, so
/// outbound Foundry-bound clients can echo the call id without threading it.
/// </summary>
internal sealed class RequestContextMiddleware : IMiddleware
{
    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        FoundryAgentRequestContext? previous = FoundryAgentRequestContext.Exchange(new FoundryAgentRequestContext
        {
            CallId = NormalizeHeader(context.Request.Headers[PlatformHeaders.FoundryCallId]),
            UserId = NormalizeHeader(context.Request.Headers[PlatformHeaders.UserId]),
            SessionId = FoundryEnvironment.SessionId,
        });

        try
        {
            await next(context);
        }
        finally
        {
            // Restore the prior context so a completed request's call id/user id
            // cannot leak into work that runs afterwards on the same execution context.
            FoundryAgentRequestContext.Exchange(previous);
        }
    }

    private static string? NormalizeHeader(Microsoft.Extensions.Primitives.StringValues values)
    {
        if (values.Count == 0)
        {
            return null;
        }

        string? first = values[0];
        return string.IsNullOrWhiteSpace(first) ? null : first.Trim();
    }
}
