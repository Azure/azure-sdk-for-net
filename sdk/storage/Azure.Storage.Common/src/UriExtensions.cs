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
    }
}
