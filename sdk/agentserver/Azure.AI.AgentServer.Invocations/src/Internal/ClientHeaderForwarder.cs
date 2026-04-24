// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Extracts <c>x-client-*</c> headers and all query parameters from an HTTP request.
/// </summary>
internal static class ClientHeaderForwarder
{
    private const string ClientHeaderPrefix = PlatformHeaders.ClientHeaderPrefix;

    /// <summary>
    /// Extracts all <c>x-client-*</c> headers from the request into a read-only dictionary.
    /// </summary>
    internal static IReadOnlyDictionary<string, string> ExtractClientHeaders(HttpRequest request)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var header in request.Headers)
        {
            if (header.Key.StartsWith(ClientHeaderPrefix, StringComparison.OrdinalIgnoreCase))
            {
                result[header.Key] = header.Value.ToString();
            }
        }

        return result;
    }

    /// <summary>
    /// Extracts all query parameters from the request into a read-only dictionary.
    /// </summary>
    internal static IReadOnlyDictionary<string, StringValues> ExtractQueryParameters(HttpRequest request)
    {
        var result = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase);

        foreach (var entry in request.Query)
        {
            result[entry.Key] = entry.Value;
        }

        return result;
    }
}
