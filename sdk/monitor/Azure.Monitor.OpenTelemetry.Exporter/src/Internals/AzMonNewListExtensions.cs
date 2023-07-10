// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

internal static class AzMonNewListExtensions
{
    ///<summary>
    /// Gets http request url from activity tag objects.
    ///</summary>
    internal static string? GetNewSchemaRequestUrl(this AzMonList tagObjects)
    {
        try
        {
            var serverAddress = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerAddress)?.ToString();
            if (serverAddress != null)
            {
                UriBuilder uriBuilder = new()
                {
                    Scheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlScheme)?.ToString(),
                    Host = serverAddress,
                    Path = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlPath)?.ToString(),
                    Query = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlQuery)?.ToString()
                };

                if (int.TryParse(AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerPort)?.ToString(), out int port))
                {
                    uriBuilder.Port = port;
                }

                return uriBuilder.Uri.AbsoluteUri;
            }
        }
        catch
        {
            // If URI building fails, there is no need to throw an exception. Instead, we can simply return null.
        }

        return null;
    }

    ///<summary>
    /// Gets Http dependency target from activity tag objects.
    ///</summary>
    internal static string? GetNewSchemaHttpDependencyTarget(this AzMonList tagObjects)
    {
        var tagValues = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeServerAddress, SemanticConventions.AttributeServerPort);
        var serverAddress = tagValues[0]?.ToString(); // tagValues[0] => SemanticConventions.AttributeServerAddress.
        var serverPort = tagValues[1]?.ToString(); // tagValues[1] => SemanticConventions.AttributeServerPort.

        if (string.IsNullOrWhiteSpace(serverAddress))
        {
            return null;
        }

        if (int.TryParse(serverPort, out int port) && !IsDefaultPort(port))
        {
            return $"{serverAddress}:{serverPort}";
        }

        return serverAddress;
    }

    internal static string? GetNewSchemaHttpDependencyName(this AzMonList tagObjects, string? httpUrl)
    {
        if (string.IsNullOrWhiteSpace(httpUrl))
        {
            return null;
        }

        var httpMethod = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpRequestMethod)?.ToString();
        if (!string.IsNullOrWhiteSpace(httpMethod))
        {
            if (Uri.TryCreate(httpUrl!.ToString(), UriKind.Absolute, out var uri) && uri.IsAbsoluteUri)
            {
                return $"{httpMethod} {uri.AbsolutePath}";
            }
        }

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDefaultPort(int port)
    {
        return port == 0 || port == 80 || port == 443;
    }
}
