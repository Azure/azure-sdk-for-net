// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods used to manipulate URIs.
    /// </summary>
    internal static class UriExtensions
    {
        /// <summary>
        /// Append a segment to a URIs path.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="segment">The relative segment to append.</param>
        /// <returns>The combined URI.</returns>
        public static Uri AppendToPath(this Uri uri, string segment)
        {
            var builder = new UriBuilder(uri);
            var path = builder.Path;
            var seperator = (path.Length == 0 || path[path.Length - 1] != '/') ? "/" : "";
            // In URLs, the percent sign is used to encode special characters, so if the segment
            // has a percent sign in their URL path, we have to encode it before adding it to the path
            segment = segment.Replace(Constants.PercentSign, Constants.EncodedPercentSign);
            builder.Path += seperator + segment;
            return builder.Uri;
        }

        /// <summary>
        /// Get the (already encoded) query parameters on a URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>Dictionary mapping query parameters to values.</returns>
        public static IDictionary<string, string> GetQueryParameters(this Uri uri)
        {
            var parameters = new Dictionary<string, string>();
            var query = uri.Query ?? "";
            if (!string.IsNullOrEmpty(query))
            {
                if (query.StartsWith("?", true, CultureInfo.InvariantCulture))
                {
                    query = query.Substring(1);
                }
                foreach (var param in query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = param.Split(new[] { '=' }, 2);
                    var name = WebUtility.UrlDecode(parts[0]);
                    if (parts.Length == 1)
                    {
                        parameters.Add(name, default);
                    }
                    else
                    {
                        parameters.Add(name, WebUtility.UrlDecode(parts[1]));
                    }
                }
            }
            return parameters;
        }

        /// <summary>
        /// Get the account name from the domain portion of a Uri.
        /// </summary>
        /// <param name="uri">The Uri.</param>
        /// <param name="serviceSubDomain">The service subdomain used to validate that the
        /// domain is in the expected format. This should be "blob" for blobs, "file" for files,
        /// "queue" for queues, "blob" and "dfs" for datalake.</param>
        /// <returns>Account name or null if not able to be parsed.</returns>
        public static string GetAccountNameFromDomain(this Uri uri, string serviceSubDomain) =>
            GetAccountNameFromDomain(uri.Host, serviceSubDomain);

        /// <summary>
        /// Get the account name from the host.
        /// </summary>
        /// <param name="host">Host.</param>
        /// <param name="serviceSubDomain">The service subdomain used to validate that the
        /// domain is in the expected format. This should be "blob" for blobs, "file" for files,
        /// "queue" for queues, "blob" and "dfs" for datalake.</param>
        /// <returns>Account name or null if not able to be parsed.</returns>
        public static string GetAccountNameFromDomain(string host, string serviceSubDomain)
        {
            var accountEndIndex = host.IndexOf(".", StringComparison.InvariantCulture);
            if (accountEndIndex >= 0)
            {
                var serviceStartIndex = accountEndIndex + 1;
                var serviceEndIndex = host.IndexOf(".", serviceStartIndex, StringComparison.InvariantCulture);
                if (serviceEndIndex > serviceStartIndex)
                {
                    var service = host.Substring(serviceStartIndex, serviceEndIndex - serviceStartIndex);
                    if (service == serviceSubDomain)
                    {
                        return host.Substring(0, accountEndIndex);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// If path starts with a slash, remove it
        /// </summary>
        /// <param name="uri">The Uri.</param>
        /// <returns>Sanitized Uri.</returns>
        public static string GetPath(this Uri uri) =>
            (uri.AbsolutePath[0] == '/') ?
                uri.AbsolutePath.Substring(1) :
                uri.AbsolutePath;

        // See remarks at https://docs.microsoft.com/en-us/dotnet/api/system.net.ipaddress.tryparse?view=netframework-4.7.2
        /// <summary>
        /// Check to see if Uri is using IP Endpoint style.
        /// </summary>
        /// <param name="uri">The Uri.</param>
        /// <returns>True if using IP Endpoint style.</returns>
        public static bool IsHostIPEndPointStyle(this Uri uri) =>
           !string.IsNullOrEmpty(uri.Host) &&
            uri.Host.IndexOf(".", StringComparison.InvariantCulture) >= 0 &&
            IPAddress.TryParse(uri.Host, out _);

        /// <summary>
        /// Appends a query parameter to the string builder.
        /// </summary>
        /// <param name="sb">string builder instance.</param>
        /// <param name="key">query parameter key.</param>
        /// <param name="value">query parameter value.</param>
        internal static void AppendQueryParameter(this StringBuilder sb, string key, string value) =>
            sb
            .Append(sb.Length > 0 ? "&" : "")
            .Append(key)
            .Append('=')
            .Append(value);
    }
}
