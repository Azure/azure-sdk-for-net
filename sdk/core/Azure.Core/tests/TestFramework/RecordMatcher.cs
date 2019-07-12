﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Azure.Core.Http;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class RecordMatcher
    {
        private readonly RecordedTestSanitizer _sanitizer;

        public RecordMatcher(RecordedTestSanitizer sanitizer)
        {
            _sanitizer = sanitizer;
        }

        public HashSet<string> ExcludeHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Date",
            "x-ms-date",
            "x-ms-client-request-id",
            "User-Agent"
        };

        public virtual RecordEntry FindMatch(Request request, IList<RecordEntry> entries)
        {
            SortedDictionary<string, string[]> headers = new SortedDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

            foreach (var header in request.Headers)
            {
                var gotHeader = request.Headers.TryGetValues(header.Name, out IEnumerable<string> values);
                Debug.Assert(gotHeader);
                headers[header.Name] = values.ToArray();
            }

            _sanitizer.SanitizeHeaders(headers);

            string uri = _sanitizer.SanitizeUri(request.UriBuilder.ToString());

            int bestScore = int.MaxValue;
            RecordEntry bestScoreEntry = null;

            foreach (RecordEntry entry in entries)
            {
                int score = 0;
                if (entry.RequestUri != uri)
                {
                    score++;
                }

                if (entry.RequestMethod != request.Method)
                {
                    score++;
                }

                score += CompareHeaderDictionaries(headers, entry.RequestHeaders);

                if (score == 0)
                {
                    return entry;
                }

                if (score < bestScore)
                {
                    bestScoreEntry = entry;
                    bestScore = score;
                }
            }


            throw new InvalidOperationException(GenerateException(request.Method, uri, headers, bestScoreEntry));
        }

        private string GenerateException(RequestMethod requestMethod, string uri, SortedDictionary<string, string[]> headers, RecordEntry bestScoreEntry)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Unable to find a record for the request {requestMethod} {uri}");

            if (bestScoreEntry == null)
            {
                builder.AppendLine("No records to match.");
                return builder.ToString();
            }

            if (requestMethod != bestScoreEntry.RequestMethod)
            {
                builder.AppendLine($"Method doesn't match, request <{requestMethod}> record <{bestScoreEntry.RequestMethod}>");
            }

            if (uri != bestScoreEntry.RequestUri)
            {
                builder.AppendLine("Uri doesn't match:");
                builder.AppendLine($"    request <{uri}>");
                builder.AppendLine($"    record  <{bestScoreEntry.RequestUri}>");
            }

            builder.AppendLine("Header differences:");

            var entryHeaders = new SortedDictionary<string, string[]>(bestScoreEntry.RequestHeaders, bestScoreEntry.RequestHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                if (entryHeaders.TryGetValue(header.Key, out string[] values))
                {
                    entryHeaders.Remove(header.Key);
                    if (!ExcludeHeaders.Contains(header.Key) &&
                        !values.SequenceEqual(header.Value))
                    {
                        builder.AppendLine($"    <{header.Key}> values differ, request <{JoinHeaderValues(header.Value)}>, record <{JoinHeaderValues(values)}>");

                    }
                }
                else
                {
                    builder.AppendLine($"    <{header.Key}> is absent in record, value <{JoinHeaderValues(header.Value)}>");
                }
            }

            foreach (KeyValuePair<string, string[]> header in entryHeaders)
            {
                builder.AppendLine($"    <{header.Key}> is absent in request, value <{JoinHeaderValues(header.Value)}>");

            }

            return builder.ToString();
        }

        private string JoinHeaderValues(string[] values)
        {
            return string.Join(",", values);
        }

        private int CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders)
        {
            int difference = 0;
            var remaining = new SortedDictionary<string, string[]>(entryHeaders, entryHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                if (remaining.TryGetValue(header.Key, out string[] values))
                {
                    remaining.Remove(header.Key);
                    if (!ExcludeHeaders.Contains(header.Key) &&
                        !values.SequenceEqual(header.Value))
                    {
                        difference++;
                    }
                }
                else
                {
                    difference++;
                }
            }
            difference += remaining.Count;
            return difference;
        }
    }
}
