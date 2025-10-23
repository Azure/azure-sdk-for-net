// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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

                if (string.IsNullOrEmpty(queryString))
                {
                    return;
                }

                if (queryString.StartsWith("?"))
                {
                    queryString = queryString.Substring(1);
                }

                var segments = new List<QueryParameterEntry>();
                foreach (string entry in queryString.Split('&'))
                {
                    if (string.IsNullOrEmpty(entry))
                    {
                        continue;
                    }
                    // Use char[] overload for .NET Standard 2.0 compatibility
                    // The Split(char, int) overload is only available in .NET Standard 2.1+
                    string[] parts = entry.Split(new[] { '=' }, 2);
                    string name = parts[0];
                    string value = parts.Length > 1 ? parts[1] : string.Empty;
                    segments.Add(new QueryParameterEntry
                    {
                        LowerName = name.ToLower(),
                        Value = value,
                        Index = segments.Count
                    });
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

                string normalizedQuery = "?" + string.Join("&", segments.Select(e => $"{e.LowerName}={e.Value}"));

                string newUrl = $"{originalUri.Scheme}://{originalUri.Host}{originalUri.AbsolutePath}{normalizedQuery}{originalUri.Fragment}";

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
