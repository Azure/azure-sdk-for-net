// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
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
            var requestUrlTagObjects = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeUrlScheme, SemanticConventions.AttributeServerAddress, SemanticConventions.AttributeServerPort, SemanticConventions.AttributeUrlPath, SemanticConventions.AttributeUrlQuery);

            var scheme = requestUrlTagObjects[0]?.ToString() ?? string.Empty; // requestUrlTagObjects[0] => SemanticConventions.AttributeUrlScheme.
            var host = requestUrlTagObjects[1]?.ToString() ?? string.Empty; // requestUrlTagObjects[1] => SemanticConventions.AttributeServerAddress.
            var port = requestUrlTagObjects[2]?.ToString(); // requestUrlTagObjects[2] => SemanticConventions.AttributeServerPort.
            port = port != null ? port = $":{port}" : string.Empty;
            var path = requestUrlTagObjects[3]?.ToString() ?? string.Empty; // requestUrlTagObjects[3] => SemanticConventions.AttributeUrlPath.
            var queryString = requestUrlTagObjects[4]?.ToString() ?? string.Empty; // requestUrlTagObjects[4] => SemanticConventions.AttributeUrlQuery.

            var length = scheme.Length + Uri.SchemeDelimiter.Length + host.Length + port.Length + path.Length + queryString.Length;

            var urlStringBuilder = new System.Text.StringBuilder(length)
                .Append(scheme)
                .Append(Uri.SchemeDelimiter)
                .Append(host)
                .Append(port)
                .Append(path)
                .Append(queryString);

            return urlStringBuilder.ToString();
        }
        catch
        {
            // If URI building fails, there is no need to throw an exception. Instead, we can simply return null.
        }

        return null;
    }

    ///<summary>
    /// Gets messaging url from activity tag objects.
    ///</summary>
    internal static (string? MessagingUrl, string? SourceOrTarget) GetMessagingUrlAndSourceOrTarget(this AzMonList tagObjects, ActivityKind activityKind)
    {
        string? messagingUrl = null;
        string? sourceOrTarget = null;

        try
        {
            var host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerAddress)?.ToString()
                        ?? AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerName)?.ToString();
            if (!string.IsNullOrEmpty(host))
            {
                object?[] messagingTagObjects;

                messagingTagObjects = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeNetworkProtocolName, SemanticConventions.AttributeMessagingDestinationName);
                var protocolName = messagingTagObjects[0]?.ToString() ?? string.Empty; // messagingTagObjects[0] => SemanticConventions.AttributeNetworkProtocolName.
                var destinationName = messagingTagObjects[1]?.ToString() ?? string.Empty; // messagingTagObjects[1] => SemanticConventions.AttributeMessagingDestinationName.

                if (destinationName.Length > 0)
                {
                    destinationName = $"/{destinationName}";
                }

                sourceOrTarget = $"{host}{destinationName}";

                var length = protocolName.Length + (protocolName?.Length > 0 ? Uri.SchemeDelimiter.Length : 0) + host!.Length + destinationName.Length;

                var messagingStringBuilder = new System.Text.StringBuilder(length)
                    .Append(protocolName)
                    .Append(string.IsNullOrEmpty(protocolName) ? null : Uri.SchemeDelimiter)
                    .Append(host)
                    .Append(destinationName);

                messagingUrl = messagingStringBuilder.ToString();
            }
        }
        catch
        {
            // If Messaging Url building fails, there is no need to throw an exception. Instead, we can simply return null.
        }

        return (MessagingUrl: messagingUrl, SourceOrTarget: sourceOrTarget);
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

    ///<summary>
    /// Gets dependency target from activity tag objects.
    ///</summary>
    internal static string? GetNewSchemaDependencyTarget(this AzMonList tagObjects, OperationType type)
    {
        switch (type)
        {
            case OperationType.Http:
                return tagObjects.GetNewSchemaHttpDependencyTarget();
            case OperationType.Db:
                return tagObjects.GetDbDependencyTargetAndName(type.HasFlag(OperationType.V2)).DbTarget;
            default:
                return null;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDefaultPort(int port)
    {
        return port == 0 || port == 80 || port == 443;
    }
}
