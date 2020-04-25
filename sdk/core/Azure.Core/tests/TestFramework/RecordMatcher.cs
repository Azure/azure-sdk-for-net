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

        // Headers that are normalized by HttpClient
        private HashSet<string> _normalizedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Accept",
            "Content-Type"
        };

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

                score += CompareHeaderDictionaries(headers, entry.Request.Headers, ExcludeHeaders);

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
            CompareHeaderDictionaries(entry.Request.Headers, otherEntry.Request.Headers, VolatileHeaders) == 0;

        private static bool AreUrisSame(string entryUri, string otherEntryUri) =>
            // Some versions of .NET behave differently when calling new Uri("...")
            // so we'll normalize the recordings (which may have been against
            // a different .NET version) to be safe
            new Uri(entryUri).ToString() == new Uri(otherEntryUri).ToString();

        protected virtual bool IsEquivalentUri(string entryUri, string otherEntryUri) =>
            AreUrisSame(entryUri, otherEntryUri);

        protected virtual bool IsEquivalentResponse(RecordEntry entry, RecordEntry otherEntry)
        {
            IEnumerable<KeyValuePair<string, string[]>> entryHeaders = entry.Response.Headers.Where(h => !VolatileResponseHeaders.Contains(h.Key));
            IEnumerable<KeyValuePair<string, string[]>> otherEntryHeaders = otherEntry.Response.Headers.Where(h => !VolatileResponseHeaders.Contains(h.Key));

            return
                entry.StatusCode == otherEntry.StatusCode &&
                entryHeaders.SequenceEqual(otherEntryHeaders, new HeaderComparer()) &&
                IsBodyEquivalent(entry, otherEntry);
        }

        protected virtual bool IsBodyEquivalent(RecordEntry record, RecordEntry otherRecord)
        {
            return (record.Response.Body ?? Array.Empty<byte>()).AsSpan()
                .SequenceEqual((otherRecord.Response.Body ?? Array.Empty<byte>()));
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

            CompareHeaderDictionaries(headers, bestScoreEntry.Request.Headers, ExcludeHeaders, builder);

            return builder.ToString();
        }

        private string JoinHeaderValues(string[] values)
        {
            return string.Join(",", values);
        }

        private string[] RenormalizeSemicolons(string[] values)
        {
            string[] outputs = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                outputs[i] = string.Join("; ", values[i].Split(';').Select(part => part.Trim()));
            }

            return outputs;
        }

        private int CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders, HashSet<string> ignoredHeaders, StringBuilder descriptionBuilder = null)
        {
            int difference = 0;
            var remaining = new SortedDictionary<string, string[]>(entryHeaders, entryHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                var requestHeaderValues = header.Value;
                var headerName = header.Key;

                if (remaining.TryGetValue(headerName, out string[] entryHeaderValues))
                {
                    // Content-Type, Accept headers are normalized by HttpClient, re-normalize them before comparing
                    if (_normalizedHeaders.Contains(headerName))
                    {
                        requestHeaderValues = RenormalizeSemicolons(requestHeaderValues);
                        entryHeaderValues = RenormalizeSemicolons(entryHeaderValues);
                    }

                    remaining.Remove(headerName);
                    if (!ignoredHeaders.Contains(headerName) &&
                        !entryHeaderValues.SequenceEqual(requestHeaderValues))
                    {
                        difference++;
                        descriptionBuilder?.AppendLine($"    <{headerName}> values differ, request <{JoinHeaderValues(requestHeaderValues)}>, record <{JoinHeaderValues(entryHeaderValues)}>");
                    }
                }
                else if (!ignoredHeaders.Contains(headerName))
                {
                    difference++;
                    descriptionBuilder?.AppendLine($"    <{headerName}> is absent in record, value <{JoinHeaderValues(requestHeaderValues)}>");
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
