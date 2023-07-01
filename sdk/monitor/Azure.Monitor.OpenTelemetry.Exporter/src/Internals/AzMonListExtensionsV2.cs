// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class AzMonListExtensionsV2
    {
        ///<summary>
        /// Gets http request url from activity tag objects.
        ///</summary>
        internal static string? GetV2RequestUrl(this AzMonList tagObjects)
        {
            try
            {
                UriBuilder uriBuilder = new()
                {
                    Scheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlScheme)?.ToString(),
                    Host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerAddress)?.ToString(),
                    Path = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlPath)?.ToString(),
                    Query = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeUrlQuery)?.ToString()
                };

                if (int.TryParse(AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeServerPort)?.ToString(), out int port))
                {
                    uriBuilder.Port = port;
                }

                return uriBuilder.Uri.AbsoluteUri;
            }
            catch
            {
                return null;
            }
        }
    }
}
