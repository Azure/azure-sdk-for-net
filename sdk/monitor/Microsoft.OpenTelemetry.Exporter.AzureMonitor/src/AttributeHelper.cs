// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class AttributeHelper
    {
        private const string SchemePostfix = "://";
        private const string Colon = ":";

        /// <summary>
        /// This method follows OpenTelemetry specification to retrieve http URL.
        /// Reference: https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/semantic_conventions/http.md#http-client.
        /// </summary>
        /// <param name="tags">Activity Tags</param>
        /// <param name="url">URL</param>
        /// <param name="urlAuthority">Host name or IP address and the port number </param>
        internal static void GenerateUrlAndAuthority(Dictionary<string, string> tags, out string url, out string urlAuthority)
        {
            urlAuthority = null;
            if (tags.TryGetValue(SemanticConventions.AttributeHttpUrl, out url))
            {
                if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
                {
                    urlAuthority = uri.Authority;
                    return;
                }
            }

            if (tags.TryGetValue(SemanticConventions.AttributeHttpScheme, out var httpScheme))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var httpHost) && !string.IsNullOrWhiteSpace(httpHost))
                {
                    tags.TryGetValue(SemanticConventions.AttributeHttpHostPort, out var httpPort);
                    if (httpPort != null && httpPort != "80" && httpPort != "443")
                    {
                        url = $"{httpScheme}{SchemePostfix}{httpHost}{Colon}{httpPort}{httpTarget}";
                        urlAuthority = $"{httpHost}{Colon}{httpPort}";
                    }
                    else
                    {
                        url = $"{httpScheme}{SchemePostfix}{httpHost}{httpTarget}";
                        urlAuthority = $"{httpHost}";
                    }

                    return;
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerName, out var netPeerName)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out var netPeerPort))
                {
                    url = string.IsNullOrWhiteSpace(netPeerName) ? null :  $"{httpScheme}{SchemePostfix}{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPort) ? null : Colon)}{netPeerPort}{httpTarget}";
                    urlAuthority = url == null ? null : $"{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPort) ? null : Colon)}{netPeerPort}";
                    return;
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerIp, out var netPeerIP)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out netPeerPort))
                {
                    url = string.IsNullOrWhiteSpace(netPeerIP) ? null : $"{httpScheme}{SchemePostfix}{netPeerIP}{(string.IsNullOrWhiteSpace(netPeerPort) ? null : Colon)}{netPeerPort}{httpTarget}";
                    urlAuthority = url == null ? null : $"{netPeerIP}{(string.IsNullOrWhiteSpace(netPeerPort) ? null : Colon)}{netPeerPort}";
                    return;
                }
            }

            if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var host) && !string.IsNullOrWhiteSpace(host))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                tags.TryGetValue(SemanticConventions.AttributeHttpHostPort, out var httpPort);
                url = $"{host}{(string.IsNullOrWhiteSpace(httpPort) ? null : Colon)}{httpPort}{httpTarget}";
                urlAuthority = $"{host}{(string.IsNullOrWhiteSpace(httpPort) ? null : Colon)}{httpPort}";
                return;
            }

            url = string.IsNullOrWhiteSpace(url) ? null : url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetTagValue(Dictionary<string, string> tags, string attributeSemanticsKey)
        {
            if (tags != null && attributeSemanticsKey !=null && tags.TryGetValue(attributeSemanticsKey, out var value))
            {
                return value;
            }

            return null;
        }
    }
}
