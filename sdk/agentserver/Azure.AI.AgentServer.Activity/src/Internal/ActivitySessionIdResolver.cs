// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Resolves the session ID from (in priority order):
/// 1. The <c>agent_session_id</c> query parameter
/// 2. The <c>x-agent-session-id</c> request header
/// 3. The <c>FOUNDRY_AGENT_SESSION_ID</c> environment variable
/// 4. A generated UUID
/// </summary>
/// <remarks>
/// The request header (priority 2) is accepted as a session ID source in addition to the
/// query parameter and environment variable.
/// </remarks>
internal static class ActivitySessionIdResolver
{
    private const string QueryParamName = "agent_session_id";

    /// <summary>
    /// Resolves the session ID from the request.
    /// </summary>
    internal static string Resolve(HttpRequest request)
    {
        // 1. Query parameter
        if (request.Query.TryGetValue(QueryParamName, out var queryValue))
        {
            var qp = queryValue.ToString();
            if (!string.IsNullOrEmpty(qp))
            {
                return qp;
            }
        }

        // 2. Request header
        if (request.Headers.TryGetValue(PlatformHeaders.SessionId, out var headerValue))
        {
            var hv = headerValue.ToString();
            if (!string.IsNullOrEmpty(hv))
            {
                return hv;
            }
        }

        // 3. Environment variable
        var envValue = FoundryEnvironment.SessionId;
        if (!string.IsNullOrEmpty(envValue))
        {
            return envValue;
        }

        // 4. Generate UUID
        return Guid.NewGuid().ToString();
    }
}
