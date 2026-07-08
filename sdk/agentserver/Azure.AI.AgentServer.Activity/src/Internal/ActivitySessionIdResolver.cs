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
/// The Activity protocol adds the request header as a session ID source
/// (priority 2) compared to the Invocations protocol, which does not
/// check the header.
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

    /// <summary>
    /// Resolves the session ID when only an IActivity is available (adapter path).
    /// Falls back to environment variable or generated UUID.
    /// </summary>
    internal static string ResolveFromActivity(Microsoft.Agents.Core.Models.IActivity activity)
    {
        // Use conversation ID as session proxy if available
        var convId = activity.Conversation?.Id;
        if (!string.IsNullOrEmpty(convId))
        {
            return convId;
        }

        // Environment variable
        var envValue = FoundryEnvironment.SessionId;
        if (!string.IsNullOrEmpty(envValue))
        {
            return envValue;
        }

        // Generate UUID
        return Guid.NewGuid().ToString();
    }
}
