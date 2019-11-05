// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

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
        /// <param name="serviceSubDomains">Required. The service subdomains used to validate that the
        /// domain is in the expected format. This should be "blob" for blobs, "file" for files,
        /// "queue" for queues, "blob" and "dfs" for datalake.</param>
        /// <returns>Account name</returns>
        public static string GetAccountNameFromDomain(this Uri uri, params string[] serviceSubDomains)
        {
            var accountEndIndex = uri.Host.IndexOf(".", StringComparison.InvariantCulture);
            if (accountEndIndex >= 0)
            {
                var serviceStartIndex = accountEndIndex + 1;
                var serviceEndIndex = uri.Host.IndexOf(".", serviceStartIndex, StringComparison.InvariantCulture);
                if (serviceEndIndex > serviceStartIndex)
                {
                    var service = uri.Host.Substring(serviceStartIndex, serviceEndIndex - serviceStartIndex);
                    foreach (string subDomain in serviceSubDomains)
                    {
                        if (service == subDomain)
                        {
                            return uri.Host.Substring(0, accountEndIndex);
                        }
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// If path starts with a slash, remove it
        /// </summary>
        /// <param name="uri">The Uri.</param>
        /// <returns>Sanitized Uri.</returns>
        public static string GetSanitizedPath(this Uri uri) =>
            (uri.AbsolutePath[0] == '/')
            ? uri.AbsolutePath.Substring(1)
            : uri.AbsolutePath;

        // TODO See remarks at https://docs.microsoft.com/en-us/dotnet/api/system.net.ipaddress.tryparse?view=netframework-4.7.2
        /// <summary>
        /// Check to see if Uri is using IP Endpoint style.
        /// </summary>
        /// <param name="uri">The Uri.</param>
        /// <returns>True if using IP Endpoint style.</returns>
        public static bool IsHostIPEndPointStyle(this Uri uri) =>
           !string.IsNullOrEmpty(uri.Host) && IPAddress.TryParse(uri.Host, out _);
    }
}
