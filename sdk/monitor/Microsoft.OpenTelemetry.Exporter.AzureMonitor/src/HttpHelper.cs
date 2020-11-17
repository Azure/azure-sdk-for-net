// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal static class HttpHelper
    {
        private const string SchemePostfix = "://";
        private const string Colon = ":";

        /// <summary>
        /// This method follows OpenTelemetry specification to retrieve http URL.
        /// Reference: https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/semantic_conventions/http.md#http-client.
        /// </summary>
        /// <param name="tagObjects">Activity Tags</param>
        /// <param name="url">URL</param>
        /// <param name="urlAuthority">Host name or IP address and the port number </param>
        internal static void GenerateUrlAndAuthority(this AzMonList tagObjects, out string url, out string urlAuthority)
        {
            urlAuthority = null;
            url = null;

            var httpurl = tagObjects.GetTagValue(SemanticConventions.AttributeHttpUrl);

            if (httpurl != null && Uri.TryCreate(httpurl.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
            {
                url = uri.AbsoluteUri;
                urlAuthority = uri.Authority;
                return;
            }

            var httpScheme = tagObjects.GetTagValue(SemanticConventions.AttributeHttpScheme)?.ToString();

            if (!string.IsNullOrWhiteSpace(httpScheme))
            {
                var httpHost = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost)?.ToString();

                if (!string.IsNullOrWhiteSpace(httpHost))
                {
                    var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);

                    if (httpPortAndTarget[0] != null && httpPortAndTarget[0].ToString() != "80" && httpPortAndTarget[0].ToString() != "443")
                    {
                        var IsColon = (string.IsNullOrWhiteSpace(httpPortAndTarget[0]?.ToString()) ? null : Colon);
                        url = $"{httpScheme}://{httpHost}{IsColon}{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
                        urlAuthority = $"{httpHost}{IsColon}{httpPortAndTarget[0]}";
                    }
                    else
                    {
                        url = $"{httpScheme}://{httpHost}{httpPortAndTarget[1]}";
                        urlAuthority = $"{httpHost}";
                    }

                    return;
                }

                var netPeerName = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerName)?.ToString();

                if (!string.IsNullOrWhiteSpace(netPeerName))
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    url = $"{httpScheme}{SchemePostfix}{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                    urlAuthority = $"{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}";
                    return;
                }

                var netPeerIP = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerIp)?.ToString();

                if (!string.IsNullOrWhiteSpace(netPeerIP))
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    var IsColon = (string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon);
                    url = $"{httpScheme}{SchemePostfix}{netPeerIP}{IsColon}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                    urlAuthority = $"{netPeerIP}{IsColon}{netPeerPortAndTarget[0]}";
                    return;
                }
            }

            var host = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost)?.ToString();

            if (!string.IsNullOrWhiteSpace(host))
            {
                var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);
                var IsColon = (string.IsNullOrWhiteSpace(httpPortAndTarget[0]?.ToString()) ? null : Colon);
                url = $"{host}{IsColon}{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
                urlAuthority = $"{host}{IsColon}{httpPortAndTarget[0]}";
                return;
            }

            url = string.IsNullOrWhiteSpace(url) ? null : url;
        }
    }
}
