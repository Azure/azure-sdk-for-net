// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter
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

            var httpurl = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpUrl);

            if (httpurl != null && Uri.TryCreate(httpurl.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
            {
                url = uri.AbsoluteUri;
                urlAuthority = uri.Authority;
                return;
            }

            var httpScheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpScheme)?.ToString();

            if (!string.IsNullOrWhiteSpace(httpScheme))
            {
                var httpHost = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpHost)?.ToString();

                if (!string.IsNullOrWhiteSpace(httpHost))
                {
                    var httpPortAndTarget = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);

                    if (httpPortAndTarget[0] != null && httpPortAndTarget[0].ToString() != "80" && httpPortAndTarget[0].ToString() != "443")
                    {
                        var IsColon = (string.IsNullOrWhiteSpace(httpPortAndTarget[0].ToString()) ? null : Colon);
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

                var netPeerName = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerName)?.ToString();

                if (!string.IsNullOrWhiteSpace(netPeerName))
                {
                    var netPeerPortAndTarget = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    var IsColon = (string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon);
                    url = $"{httpScheme}{SchemePostfix}{netPeerName}{IsColon}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                    urlAuthority = $"{netPeerName}{IsColon}{netPeerPortAndTarget[0]}";
                    return;
                }

                var netPeerIP = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerIp)?.ToString();

                if (!string.IsNullOrWhiteSpace(netPeerIP))
                {
                    var netPeerPortAndTarget = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    var IsColon = (string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon);
                    url = $"{httpScheme}{SchemePostfix}{netPeerIP}{IsColon}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                    urlAuthority = $"{netPeerIP}{IsColon}{netPeerPortAndTarget[0]}";
                    return;
                }
            }

            var host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpHost)?.ToString();

            if (!string.IsNullOrWhiteSpace(host))
            {
                var httpPortAndTarget = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);
                var IsColon = (string.IsNullOrWhiteSpace(httpPortAndTarget[0]?.ToString()) ? null : Colon);
                url = $"{host}{IsColon}{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
                urlAuthority = $"{host}{IsColon}{httpPortAndTarget[0]}";
                return;
            }

            url = string.IsNullOrWhiteSpace(url) ? null : url;
        }
        ///<summary>
        /// Gets http request url from activity tag objects.
        ///</summary>
        internal static string GetRequestUrl(this AzMonList tagObjects)
        {
            // From spec: one of the following combinations is required in case of server spans:
            // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/http.md#http-server-semantic-conventions
            // http.url
            // http.scheme, http.host, http.target
            // http.scheme, http.server_name, net.host.port, http.target
            // http.scheme, net.host.name, net.host.port, http.target
            string url = null;
            var httpUrl = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpUrl)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpUrl))
            {
                url = httpUrl;
                return url;
            }
            var httpScheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpScheme)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpScheme))
            {
                var httpTarget = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpTarget)?.ToString();
                // http.target is required in other three possible combinations
                // If not available then do not proceed.
                if (string.IsNullOrWhiteSpace(httpTarget))
                {
                    return null;
                }

                var httpHost = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpHost)?.ToString();
                if (!string.IsNullOrWhiteSpace(httpHost))
                {
                    url = $"{httpScheme}://{httpHost}{httpTarget}";
                    return url;
                }

                var httpServerName = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpServerName)?.ToString();
                string host;
                if (!string.IsNullOrWhiteSpace(httpServerName))
                {
                    host = httpServerName;
                }
                else
                {
                    host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetHostName)?.ToString();
                }
                if (!string.IsNullOrWhiteSpace(host))
                {
                    var netHostPort = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetHostPort)?.ToString();
                    if (!string.IsNullOrWhiteSpace(netHostPort))
                    {
                        if (netHostPort == "80" || netHostPort == "443")
                        {
                            url = $"{httpScheme}://{host}{httpTarget}";
                            return url;
                        }

                        url = $"{httpScheme}://{host}:{netHostPort}{httpTarget}";
                        return url;
                    }
                }
            }
            return url;
        }
    }
}
