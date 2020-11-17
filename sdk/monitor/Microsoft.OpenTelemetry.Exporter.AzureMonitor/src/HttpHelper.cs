// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using OpenTelemetry.Trace;

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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetUrl(this AzMonList tagObjects)
        {
            var httpurl = tagObjects.GetTagValue(SemanticConventions.AttributeHttpUrl);

            if (httpurl != null && Uri.TryCreate(httpurl.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
            {
                return uri.AbsoluteUri;
            }

            string url = null;

            var httpScheme = tagObjects.GetTagValue(SemanticConventions.AttributeHttpScheme);

            if (httpScheme != null)
            {
                var httpHost = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost);

                if (httpHost != null)
                {
                    var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);

                    if (httpPortAndTarget[0] != null && httpPortAndTarget[0].ToString() != "80" && httpPortAndTarget[0].ToString() != "443")
                    {
                        url = $"{httpScheme}://{httpHost}:{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
                    }
                    else
                    {
                        url = $"{httpScheme}://{httpHost}{httpPortAndTarget[1]}";
                    }

                    return url;
                }

                var netPeerName = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerName);

                if (netPeerName != null)
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    return string.IsNullOrWhiteSpace(netPeerName?.ToString()) ? null : $"{httpScheme}{SchemePostfix}{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                }

                var netPeerIP = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerIp);

                if (netPeerIP != null)
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    return string.IsNullOrWhiteSpace(netPeerIP?.ToString()) ? null : $"{httpScheme}{SchemePostfix}{netPeerIP}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                }
            }

            var host = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost);

            if (host != null)
            {
                var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);
                url = $"{host}{(string.IsNullOrWhiteSpace(httpPortAndTarget[0]?.ToString()) ? null : ":")}{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
            }

            return string.IsNullOrWhiteSpace(url) ? null : url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetHttpStatusCode(this AzMonList tagObjects)
        {
            _ = tagObjects.GetTagValue(SemanticConventions.AttributeHttpStatusCode);
            var status = tagObjects.GetTagValue(SemanticConventions.AttributeHttpStatusCode)?.ToString();
            return status ?? "0";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMessagingUrl(this AzMonList tagObjects)
        {
            return tagObjects.GetTagValue(SemanticConventions.AttributeMessagingUrl)?.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GetSuccessFromHttpStatusCode(string statusCode)
        {
            return statusCode == "200" || statusCode == "Ok";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetHost(this AzMonList tagObjects)
        {
            return tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost)?.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetTagValue(this AzMonList tagObjects, string tagName)
        {
            for (int i = 0; i < tagObjects.Length; i++)
            {
                if (tagObjects[i].Key == tagName)
                {
                    return tagObjects[i].Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object[] GetTagValues(this AzMonList tagObjects, params string[] tagNames)
        {
            int? length = tagNames?.Count();
            if (length == null || length == 0)
            {
                return null;
            }

            object[] values = new object[(int)length];

            for (int i = 0; i < tagObjects.Length; i++)
            {
                var index = Array.IndexOf(tagNames, tagObjects[i].Key);
                if (index >= 0)
                {
                    values[index] = tagObjects[i].Value;
                    length--;

                    if (length == 0)
                    {
                        break;
                    }
                }
            }

            return values;
        }
    }
}
