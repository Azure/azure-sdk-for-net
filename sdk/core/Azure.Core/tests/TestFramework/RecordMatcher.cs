// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public virtual int FindMatch(Request request, IList<RecordEntry> entries, out string failureMessage)
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
            var messagePrefix = failureMessage = $"Unable to find recorded request for {request.Method} {request.UriBuilder.ToString()}";

            for (int i = 0; i < entries.Count; i++)
            {
                RecordEntry entry = entries[i];

                if (entry.RequestUri == uri && entry.RequestMethod == request.Method)
                {
                    int score = CompareHeaderDictionaries(headers, entry.RequestHeaders, out var diff);
                    if (score == 0)
                    {
                        failureMessage = null;
                        return i;
                    }
                    else if (score < bestScore)
                    {
                        bestScore = score;
                        failureMessage = $"{messagePrefix} (Best match: {diff})";
                    }
                }
            }

            if (bestScore == int.MaxValue && entries.Count == 1)
            {
                failureMessage = $"{messagePrefix} (Best match: {entries[0].RequestMethod} {entries[0].RequestUri})";
            }
            
            return -1;
        }

        private int CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders, out string diff)
        {
            List<string> deltas = new List<string>();
            var remaining = new SortedDictionary<string, string[]>(entryHeaders, entryHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                if (remaining.TryGetValue(header.Key, out string[] values))
                {
                    remaining.Remove(header.Key);
                    if (!ExcludeHeaders.Contains(header.Key) &&
                        !values.SequenceEqual(header.Value))
                    {
                        var expected = string.Join(",", header.Value);
                        var actual = string.Join(",", values);
                        deltas.Add($"{header.Key} expects <{expected}> not <{actual}>");
                    }
                }
                else
                {
                    deltas.Add($"Missing {header.Key}");
                }
            }
            foreach (KeyValuePair<string, string[]> header in remaining)
            {
                deltas.Add($"Extra {header.Key}");
            }
            diff = string.Join("; ", deltas);
            return deltas.Count;
        }
    }
}
