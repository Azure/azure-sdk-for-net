// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class QueryParamPolicy : HttpPipelineSynchronousPolicy
    {
        private class QueryParameterEntry
        {
            public string LowerName { get; set; }
            public string Value { get; set; }
            public int Index { get; set; }
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            try
            {
                Uri originalUri = message.Request.Uri.ToUri();
                string queryString = originalUri.Query;

                // If no query string, nothing to normalize
                if (string.IsNullOrEmpty(queryString))
                {
                    return;
                }

                // Remove leading '?'
                if (queryString.StartsWith("?"))
                {
                    queryString = queryString.Substring(1);
                }

                List<QueryParameterEntry> segments = new List<QueryParameterEntry>();
                NameValueCollection paramsCollection = HttpUtility.ParseQueryString(queryString);
                // URL encoded characters are decoded and multiple occurrences of the same query string parameter are listed as a single entry with a comma separating each value.
                // See the remark section: https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.parsequerystring
                foreach (var key in paramsCollection.AllKeys)
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        var values = paramsCollection.GetValues(key);
                        foreach (var val in values)
                        {
                            segments.Add(new QueryParameterEntry
                            {
                                LowerName = key.ToLower(),
                                Value = val == null ? string.Empty : Uri.EscapeDataString(val),
                                Index = segments.Count
                            });
                        }
                    }
                }

                // List<T>.Sort method is not stable. See the remark section: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort
                // Sort by lowercase name, preserving relative order for duplicates
                segments.Sort((a, b) =>
                {
                    var nameComparison = string.Compare(a.LowerName, b.LowerName, StringComparison.Ordinal);
                    if (nameComparison != 0)
                        return nameComparison;
                    return a.Index.CompareTo(b.Index); // stability for duplicates
                });

                var normalizedQuery = string.Join("&", segments.Select(e => $"{e.LowerName}={e.Value}"));

                var newUrl = $"{originalUri.Scheme}://{originalUri.Host}{originalUri.AbsolutePath}{(normalizedQuery.Length > 0 ? "?" + normalizedQuery : "")}{originalUri.Fragment}";

                if (newUrl != message.Request.Uri.ToString())
                {
                    message.Request.Uri.Reset(new Uri(newUrl));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"QueryParamPolicy failed to normalize the request query parameters: {ex}");
            }
        }
    }
}
