// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Resolves the session ID from (in priority order):
/// 1. The <c>agent_session_id</c> query parameter
/// 2. The <c>FOUNDRY_AGENT_SESSION_ID</c> environment variable
/// 3. A generated UUID
/// </summary>
internal static class SessionIdResolver
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

        // 2. Environment variable
        var envValue = FoundryEnvironment.SessionId;
        if (!string.IsNullOrEmpty(envValue))
        {
            return envValue;
        }

        // 3. Generate UUID
        return Guid.NewGuid().ToString();
    }
}
