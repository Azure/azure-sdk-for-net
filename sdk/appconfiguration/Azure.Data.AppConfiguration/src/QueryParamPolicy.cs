// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class QueryParamPolicy : HttpPipelineSynchronousPolicy
    {
        private struct QueryParameterEntry
        {
            public ReadOnlyMemory<char> Name { get; set; }
            public ReadOnlyMemory<char> Value { get; set; }
            public int Index { get; set; }
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            Uri originalUri = message.Request.Uri.ToUri();
            string queryString = originalUri.Query;

            if (string.IsNullOrEmpty(queryString))
            {
                return;
            }

            ReadOnlyMemory<char> queryMemory = queryString.AsMemory();

            if (queryMemory.Span[0] == '?')
            {
                queryMemory = queryMemory.Slice(1);
            }

            var segments = new List<QueryParameterEntry>();
            int startIndex = 0;

            for (int i = 0; i < queryMemory.Length; i++)
            {
                if (queryMemory.Span[i] == '&')
                {
                    if (i > startIndex)
                    {
                        AddParameter(queryMemory.Slice(startIndex, i - startIndex), segments);
                    }
                    startIndex = i + 1;
                }
            }

            // Add the last parameter
            if (startIndex < queryMemory.Length)
            {
                AddParameter(queryMemory.Slice(startIndex), segments);
            }

            // List<T>.Sort method is not stable. See the remark section: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort
            // Sort by lowercase name, preserving relative order for duplicates
            segments.Sort((a, b) =>
            {
                var nameComparison = MemoryExtensions.CompareTo(
                    a.Name.Span,
                    b.Name.Span,
                    StringComparison.OrdinalIgnoreCase);

                if (nameComparison != 0)
                {
                    return nameComparison;
                }
                return a.Index.CompareTo(b.Index);
            });

            var sb = new StringBuilder();
            sb.Append(originalUri.Scheme);
            sb.Append("://");
            sb.Append(originalUri.Host);
            if (!originalUri.IsDefaultPort)
            {
                sb.Append(':');
                sb.Append(originalUri.Port);
            }
            sb.Append(originalUri.AbsolutePath);
            sb.Append('?');

            for (int i = 0; i < segments.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append('&');
                }

                sb.Append(segments[i].Name.ToString().ToLowerInvariant());
                sb.Append('=');
                sb.Append(segments[i].Value);
            }

            if (!string.IsNullOrEmpty(originalUri.Fragment))
            {
                sb.Append(originalUri.Fragment);
            }

            string newUrl = sb.ToString();

            if (newUrl != message.Request.Uri.ToString())
            {
                message.Request.Uri.Reset(new Uri(newUrl));
            }
        }

        private static void AddParameter(ReadOnlyMemory<char> parameter, List<QueryParameterEntry> segments)
        {
            if (parameter.IsEmpty)
            {
                return;
            }

            int equalsIndex = parameter.Span.IndexOf('=');

            ReadOnlyMemory<char> name;
            ReadOnlyMemory<char> value;

            name = equalsIndex >= 0 ? parameter.Slice(0, equalsIndex) : parameter;
            value = equalsIndex >= 0 ? parameter.Slice(equalsIndex + 1) : ReadOnlyMemory<char>.Empty;

            segments.Add(new QueryParameterEntry
            {
                Name = name,
                Value = value,
                Index = segments.Count
            });
        }
    }
}
