// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
            "User-Agent",
            "Request-Id",
            "traceparent"
        };

        // Headers that don't indicate meaningful changes between updated recordings
        public HashSet<string> VolatileHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Date",
            "x-ms-date",
            "x-ms-client-request-id",
            "User-Agent",
            "Request-Id",
            "If-Match",
            "If-None-Match",
            "If-Modified-Since",
            "If-Unmodified-Since"
        };

        // Headers that don't indicate meaningful changes between updated recordings
        public HashSet<string> VolatileResponseHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Date",
            "ETag",
            "Last-Modified",
            "x-ms-request-id",
            "x-ms-correlation-request-id"
        };

        public virtual RecordEntry FindMatch(Request request, IList<RecordEntry> entries)
        {
            SortedDictionary<string, string[]> headers = new SortedDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

            foreach (HttpHeader header in request.Headers)
            {
                var gotHeader = request.Headers.TryGetValues(header.Name, out IEnumerable<string> values);
                Debug.Assert(gotHeader);
                headers[header.Name] = values.ToArray();
            }

            _sanitizer.SanitizeHeaders(headers);

            string uri = _sanitizer.SanitizeUri(request.Uri.ToString());

            int bestScore = int.MaxValue;
            RecordEntry bestScoreEntry = null;

            foreach (RecordEntry entry in entries)
            {
                int score = 0;

                if (!AreUrisSame(entry.RequestUri, uri))
                {
                    score++;
                }

                if (entry.RequestMethod != request.Method)
                {
                    score++;
                }

                score += CompareHeaderDictionaries(headers, entry.RequestHeaders, ExcludeHeaders);

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

        public virtual bool IsEquivalentRecord(RecordEntry entry, RecordEntry otherEntry) =>
            IsEquivalentRequest(entry, otherEntry) &&
            IsEquivalentResponse(entry, otherEntry);

        protected virtual bool IsEquivalentRequest(RecordEntry entry, RecordEntry otherEntry) =>
            entry.RequestMethod == otherEntry.RequestMethod &&
            IsEquivalentUri(entry.RequestUri, otherEntry.RequestUri) &&
            CompareHeaderDictionaries(entry.RequestHeaders, otherEntry.RequestHeaders, VolatileHeaders) == 0;

        private static bool AreUrisSame(string entryUri, string otherEntryUri) =>
            // Some versions of .NET behave differently when calling new Uri("...")
            // so we'll normalize the recordings (which may have been against
            // a different .NET version) to be safe
            new Uri(entryUri).ToString() == new Uri(otherEntryUri).ToString();

        protected virtual bool IsEquivalentUri(string entryUri, string otherEntryUri) =>
            AreUrisSame(entryUri, otherEntryUri);

        protected virtual bool IsEquivalentResponse(RecordEntry entry, RecordEntry otherEntry)
        {
            IEnumerable<KeyValuePair<string, string[]>> entryHeaders = entry.ResponseHeaders.Where(h => !VolatileResponseHeaders.Contains(h.Key));
            IEnumerable<KeyValuePair<string, string[]>> otherEntryHeaders = otherEntry.ResponseHeaders.Where(h => !VolatileResponseHeaders.Contains(h.Key));

            return
                entry.StatusCode == otherEntry.StatusCode &&
                entryHeaders.SequenceEqual(otherEntryHeaders, new HeaderComparer()) &&
                IsBodyEquivalent(entry, otherEntry);
        }

        protected virtual bool IsBodyEquivalent(RecordEntry record, RecordEntry otherRecord)
        {
            return (record.ResponseBody ?? Array.Empty<byte>()).AsSpan()
                .SequenceEqual((otherRecord.ResponseBody ?? Array.Empty<byte>()));
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

            if (!AreUrisSame(uri, bestScoreEntry.RequestUri))
            {
                builder.AppendLine("Uri doesn't match:");
                builder.AppendLine($"    request <{uri}>");
                builder.AppendLine($"    record  <{bestScoreEntry.RequestUri}>");
            }

            builder.AppendLine("Header differences:");

            CompareHeaderDictionaries(headers, bestScoreEntry.RequestHeaders, ExcludeHeaders, builder);

            return builder.ToString();
        }

        private string JoinHeaderValues(string[] values)
        {
            return string.Join(",", values);
        }

        private int CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders, HashSet<string> ignoredHeaders, StringBuilder descriptionBuilder = null)
        {
            int difference = 0;
            var remaining = new SortedDictionary<string, string[]>(entryHeaders, entryHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                if (remaining.TryGetValue(header.Key, out string[] values))
                {
                    remaining.Remove(header.Key);
                    if (!ignoredHeaders.Contains(header.Key) &&
                        !values.SequenceEqual(header.Value))
                    {
                        difference++;
                        descriptionBuilder?.AppendLine($"    <{header.Key}> values differ, request <{JoinHeaderValues(header.Value)}>, record <{JoinHeaderValues(values)}>");
                    }
                }
                else if (!ignoredHeaders.Contains(header.Key))
                {
                    difference++;
                    descriptionBuilder?.AppendLine($"    <{header.Key}> is absent in record, value <{JoinHeaderValues(header.Value)}>");
                }
            }

            foreach (KeyValuePair<string, string[]> header in remaining)
            {
                if (!ignoredHeaders.Contains(header.Key))
                {
                    difference++;
                    descriptionBuilder?.AppendLine($"    <{header.Key}> is absent in request, value <{JoinHeaderValues(header.Value)}>");
                }
            }

            return difference;
        }

        private class HeaderComparer : IEqualityComparer<KeyValuePair<string, string[]>>
        {
            public bool Equals(KeyValuePair<string, string[]> x, KeyValuePair<string, string[]> y)
            {
                return x.Key.Equals(y.Key, StringComparison.OrdinalIgnoreCase) &&
                       x.Value.SequenceEqual(y.Value);
            }

            public int GetHashCode(KeyValuePair<string, string[]> obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
