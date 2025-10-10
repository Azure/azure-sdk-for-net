// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.AppConfiguration
{
    internal class QueryParamPolicy : HttpPipelineSynchronousPolicy
    {
        public override void OnSendingRequest(HttpMessage message)
        {
            try
            {
                string originalUrl = message.Request.Uri.ToString();
                string queryString = message.Request.Uri.Query;

                // If no query string, nothing to normalize
                if (string.IsNullOrEmpty(queryString))
                {
                    return;
                }

                // Remove leading '?' if present
                if (queryString.StartsWith("?"))
                {
                    queryString = queryString.Substring(1);
                }

                // Separate out any hash fragment so we can keep it verbatim
                int hashIndex = originalUrl.IndexOf('#');
                string beforeHash = hashIndex >= 0 ? originalUrl.Substring(0, hashIndex) : originalUrl;
                string hashFrag = hashIndex >= 0 ? originalUrl.Substring(hashIndex) : "";

                string baseUrl = beforeHash.Substring(0, beforeHash.IndexOf('?'));

                // We don't use HttpUtility.ParseQueryString as it will process the values
                // https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.parsequerystring
                IEnumerable<string> segments = queryString.Split('&').Where(s => s.Length > 0);

                List<QueryParameterEntry> entries = segments.Select((seg, i) =>
                {
                    int eq = seg.IndexOf('=');
                    string rawName = eq == -1 ? seg : seg.Substring(0, eq);
                    string value = eq == -1 ? null : seg.Substring(eq + 1);
                    return new QueryParameterEntry
                    {
                        RawName = rawName,
                        LowerName = rawName.ToLowerInvariant(),
                        Value = value,
                        Index = i
                    };
                }).ToList();

                // Sort by lowercase name, preserving relative order for duplicates
                entries.Sort((a, b) =>
                {
                    var nameComparison = string.Compare(a.LowerName, b.LowerName, StringComparison.Ordinal);
                    if (nameComparison != 0)
                        return nameComparison;
                    return a.Index.CompareTo(b.Index); // stability for duplicates
                });

                var normalizedQuery = string.Join("&", entries.Select(e =>
                    e.Value != null ? $"{e.LowerName}={e.Value}" : e.LowerName));

                var newUrl = $"{baseUrl}{(normalizedQuery.Length > 0 ? "?" + normalizedQuery : "")}{hashFrag}";

                // Only update if changed (optional, but nice to avoid surprising downstream logic)
                if (newUrl != originalUrl)
                {
                    message.Request.Uri.Reset(new Uri(newUrl));
                }
            }
            catch
            {
                // If anything goes wrong, fall back to sending the original request
            }
        }

        private class QueryParameterEntry
        {
            public string RawName { get; set; }
            public string LowerName { get; set; }
            public string Value { get; set; }
            public int Index { get; set; }
        }
    }
}
