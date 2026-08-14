// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Resolves the invocation ID from the <c>x-agent-invocation-id</c> request header.
/// Generates a UUID if the header is absent.
/// </summary>
internal static class InvocationIdResolver
{
    private const string InvocationIdHeader = "x-agent-invocation-id";

    /// <summary>
    /// Resolves the invocation ID from the request.
    /// </summary>
    internal static string Resolve(HttpRequest request)
    {
        if (request.Headers.TryGetValue(InvocationIdHeader, out var values))
        {
            var headerValue = values.ToString();
            if (!string.IsNullOrEmpty(headerValue))
            {
                return headerValue;
            }
        }

        return Guid.NewGuid().ToString();
    }
}
