// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using Azure.Core;

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
            var host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerAddress)?.ToString();
            if (host != null)
            {
                var requestUrlTagObjects = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeUrlScheme, SemanticConventions.AttributeUrlPath, SemanticConventions.AttributeUrlQuery, SemanticConventions.AttributeServerPort);
                var scheme = requestUrlTagObjects[0]?.ToString();
                var path = requestUrlTagObjects[1]?.ToString();
                var queryString = requestUrlTagObjects[2]?.ToString();
                var queryStringLength = queryString?.Length;
                var isNonDefaultPort = TryGetNonDefaultPort(requestUrlTagObjects[3]?.ToString(), out string? port);
                var length = (scheme?.Length ?? 0) + (scheme?.Length > 0 ? Uri.SchemeDelimiter.Length : 0) + host.Length + (port?.Length > 0 ? 1 : 0) + (port?.Length ?? 0) + (path?.Length ?? 0) + (queryString?.Length > 0 ? 1 : 0) + (queryString?.Length ?? 0);

                var urlStringBuilder = new System.Text.StringBuilder(length)
                    .Append(scheme)
                    .Append(scheme != null ? Uri.SchemeDelimiter : null)
                    .Append(host)
                    .Append(isNonDefaultPort ? $":{port}" : null)
                    .Append(string.IsNullOrEmpty(path) ? "/" : path)
                    .Append(queryString != null ? $"?{queryString}" : null);

                return urlStringBuilder.ToString();
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryGetNonDefaultPort(string? stringport, out string? port)
    {
        port = stringport;

        if (string.IsNullOrEmpty(stringport) || stringport == "80" || stringport == "443")
        {
            return false;
        }

        return true;
    }
}
