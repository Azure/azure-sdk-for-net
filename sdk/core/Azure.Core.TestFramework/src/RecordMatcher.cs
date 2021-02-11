// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Azure.Core.TestFramework
{
    public class RecordMatcher
    {
        // Headers that are normalized by HttpClient
        private HashSet<string> _normalizedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Accept",
            "Content-Type"
        };

        private bool _compareBodies;

        public RecordMatcher(bool compareBodies = true)
        {
            _compareBodies = compareBodies;
        }

        /// <summary>
        /// Request headers whose values can change between recording and playback without causing request matching
        /// to fail. The presence or absence of the header itself is still respected in matching.
        /// </summary>
        public HashSet<string> IgnoredHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Date",
            "x-ms-date",
            "x-ms-client-request-id",
            "User-Agent",
            "Request-Id",
            "traceparent"
        };

        /// <summary>
        /// Legacy header exclusion set that will disregard any headers listed here when matching. Headers listed here are not matched for value,
        /// or for presence or absence of the header key. For that reason, IgnoredHeaders should be used instead as this will ensure that the header's
        /// presence or absence from the request is considered when matching.
        /// This property is only included only for backwards compat.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HashSet<string> LegacyExcludedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
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

        /// <summary>
        /// Query parameters whose values can change between recording and playback without causing URI matching
        /// to fail. The presence or absence of the query parameter itself is still respected in matching.
        /// </summary>
        public HashSet<string> IgnoredQueryParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
        };

        private const string IgnoredValue = "Ignored";

        public virtual RecordEntry FindMatch(RecordEntry request, IList<RecordEntry> entries)
        {
            int bestScore = int.MaxValue;
            RecordEntry bestScoreEntry = null;

            foreach (RecordEntry entry in entries)
            {
                int score = 0;

                var uri = request.RequestUri;
                var recordRequestUri = entry.RequestUri;
                if (entry.IsTrack1Recording)
                {
                    //there's no domain name for request uri in track 1 record, so add it from request uri
                    int len = 8; //length of "https://"
                    int domainEndingIndex = uri.IndexOf('/', len);
                    if (domainEndingIndex > 0)
                    {
                        recordRequestUri = uri.Substring(0, domainEndingIndex) + recordRequestUri;
                    }
                }

                if (!AreUrisSame(recordRequestUri, uri))
                {
                    score++;
                }

                if (entry.RequestMethod != request.RequestMethod)
                {
                    score++;
                }

                //we only check Uri + RequestMethod for track1 record
                if (!entry.IsTrack1Recording)
                {
                    score += CompareHeaderDictionaries(request.Request.Headers, entry.Request.Headers, IgnoredHeaders);
                    score += CompareBodies(request.Request.Body, entry.Request.Body);
                }

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

            throw new TestRecordingMismatchException(GenerateException(request, bestScoreEntry));
        }

        private int CompareBodies(byte[] requestBody, byte[] responseBody, StringBuilder descriptionBuilder = null)
        {
            if (!_compareBodies)
            {
                return 0;
            }

            if (requestBody == null && responseBody == null)
            {
                return 0;
            }

            if (requestBody == null)
            {
                descriptionBuilder?.AppendLine("Request has body but response doesn't");
                return 1;
            }

            if (responseBody == null)
            {
                descriptionBuilder?.AppendLine("Response has body but request doesn't");
                return 1;
            }

            if (!requestBody.SequenceEqual(responseBody))
            {
                if (descriptionBuilder != null)
                {
                    var minLength = Math.Min(requestBody.Length, responseBody.Length);
                    int i;
                    for (i = 0; i < minLength - 1; i++)
                    {
                        if (requestBody[i] != responseBody[i])
                        {
                            break;
                        }
                    }
                    descriptionBuilder.AppendLine($"Request and response bodies do not match at index {i}:");
                    var before = Math.Max(0, i - 10);
                    var afterRequest = Math.Min(i + 20, requestBody.Length);
                    var afterResponse = Math.Min(i + 20, responseBody.Length);
                    descriptionBuilder.AppendLine($"     request: \"{Encoding.UTF8.GetString(requestBody, before, afterRequest - before)}\"");
                    descriptionBuilder.AppendLine($"     record:  \"{Encoding.UTF8.GetString(responseBody, before, afterResponse - before)}\"");
                }
                return 1;
            }

            return 0;
        }

        public virtual bool IsEquivalentRecord(RecordEntry entry, RecordEntry otherEntry) =>
            IsEquivalentRequest(entry, otherEntry) &&
            IsEquivalentResponse(entry, otherEntry);

        protected virtual bool IsEquivalentRequest(RecordEntry entry, RecordEntry otherEntry) =>
            entry.RequestMethod == otherEntry.RequestMethod &&
            IsEquivalentUri(entry.RequestUri, otherEntry.RequestUri) &&
            CompareHeaderDictionaries(entry.Request.Headers, otherEntry.Request.Headers, VolatileHeaders) == 0;

        private bool AreUrisSame(string entryUri, string otherEntryUri) =>
            NormalizeUri(entryUri) == NormalizeUri(otherEntryUri);

        private string NormalizeUri(string uriToNormalize)
        {
            var req = new RequestUriBuilder();
            var uri = new Uri(uriToNormalize);
            req.Reset(uri);
            req.Query = "";
            NameValueCollection queryParams = HttpUtility.ParseQueryString(uri.Query);
            foreach (string param in queryParams)
            {
                req.AppendQuery(
                    param,
                    IgnoredQueryParameters.Contains(param) ? IgnoredValue : queryParams[param]);
            }
            return req.ToUri().ToString();
        }

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

        private string GenerateException(RecordEntry request, RecordEntry bestScoreEntry)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Unable to find a record for the request {request.RequestMethod} {request.RequestUri}");

            if (bestScoreEntry == null)
            {
                builder.AppendLine("No records to match.");
                return builder.ToString();
            }

            if (request.RequestMethod != bestScoreEntry.RequestMethod)
            {
                builder.AppendLine($"Method doesn't match, request <{request.RequestMethod}> record <{bestScoreEntry.RequestMethod}>");
            }

            if (!AreUrisSame(request.RequestUri, bestScoreEntry.RequestUri))
            {
                builder.AppendLine("Uri doesn't match:");
                builder.AppendLine($"    request <{request.RequestUri}>");
                builder.AppendLine($"    record  <{bestScoreEntry.RequestUri}>");
            }

            builder.AppendLine("Header differences:");

            CompareHeaderDictionaries(request.Request.Headers, bestScoreEntry.Request.Headers, IgnoredHeaders, builder);

            builder.AppendLine("Body differences:");

            CompareBodies(request.Request.Body, bestScoreEntry.Request.Body, builder);

            return builder.ToString();
        }

        private string JoinHeaderValues(string[] values)
        {
            return string.Join(",", values);
        }

        private string[] RenormalizeContentHeaders(string[] values)
        {
            return new[] { string.Join(", ",
                values.Select(value =>
                    string.Join("; ", value.Split(';').Select(part => part.Trim())))) };
        }

        private int CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders, HashSet<string> ignoredHeaders, StringBuilder descriptionBuilder = null)
        {
            int difference = 0;
            var remaining = new SortedDictionary<string, string[]>(entryHeaders, entryHeaders.Comparer);
            foreach (KeyValuePair<string, string[]> header in headers)
            {
                var requestHeaderValues = header.Value;
                var headerName = header.Key;

                if (LegacyExcludedHeaders.Contains(headerName))
                {
                    continue;
                }

                if (remaining.TryGetValue(headerName, out string[] entryHeaderValues))
                {
                    if (ignoredHeaders.Contains(headerName))
                    {
                        remaining.Remove(headerName);
                        continue;
                    }

                    // Content-Type, Accept headers are normalized by HttpClient, re-normalize them before comparing
                    if (_normalizedHeaders.Contains(headerName))
                    {
                        requestHeaderValues = RenormalizeContentHeaders(requestHeaderValues);
                        entryHeaderValues = RenormalizeContentHeaders(entryHeaderValues);
                    }

                    remaining.Remove(headerName);
                    if (!entryHeaderValues.SequenceEqual(requestHeaderValues))
                    {
                        difference++;
                        descriptionBuilder?.AppendLine($"    <{headerName}> values differ, request <{JoinHeaderValues(requestHeaderValues)}>, record <{JoinHeaderValues(entryHeaderValues)}>");
                    }
                }
                else
                {
                    difference++;
                    descriptionBuilder?.AppendLine($"    <{headerName}> is absent in record, value <{JoinHeaderValues(requestHeaderValues)}>");
                }
            }

            foreach (KeyValuePair<string, string[]> header in remaining)
            {
                if (!LegacyExcludedHeaders.Contains(header.Key))
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
