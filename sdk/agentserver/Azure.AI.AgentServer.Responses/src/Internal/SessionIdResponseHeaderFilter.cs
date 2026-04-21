// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Endpoint filter that sets the <c>x-agent-session-id</c> response header on every
/// protocol endpoint response (success and error). The handler stores the resolved
/// session ID in <see cref="HttpContext.Items"/> under <see cref="SessionIdKey"/>;
/// if absent, falls back to <see cref="FoundryEnvironment.SessionId"/>.
/// </summary>
internal sealed class SessionIdResponseHeaderFilter : IEndpointFilter
{
    /// <summary>
    /// Key used to store/retrieve the resolved session ID in <see cref="HttpContext.Items"/>.
    /// </summary>
    internal const string SessionIdKey = "AgentServer.ResolvedSessionId";

    private const string SessionIdHeader = "x-agent-session-id";

    /// <inheritdoc/>
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var result = await next(context);

        // Resolve session ID: handler-stored value → environment variable.
        var sessionId = context.HttpContext.Items.TryGetValue(SessionIdKey, out var stored)
            && stored is string s
            && !string.IsNullOrEmpty(s)
            ? s
            : FoundryEnvironment.SessionId;

        if (!string.IsNullOrEmpty(sessionId))
        {
            context.HttpContext.Response.Headers[SessionIdHeader] = sessionId;
        }

        return result;
    }
}
