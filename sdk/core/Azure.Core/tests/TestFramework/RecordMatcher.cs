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
            "x-ms-client-request-id",
            "User-Agent"
        };

        public virtual int FindMatch(Request request, IList<RecordEntry> entries)
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

            for (int i = 0; i < entries.Count; i++)
            {
                RecordEntry entry = entries[i];

                if (entry.RequestUri == uri &&
                    entry.RequestMethod == request.Method &&
                    CompareHeaderDictionaries(headers, entry.RequestHeaders))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool CompareHeaderDictionaries(SortedDictionary<string, string[]> headers, SortedDictionary<string, string[]> entryHeaders)
        {
            if (headers.Count != entryHeaders.Count)
            {
                return false;
            }

            foreach (KeyValuePair<string, string[]> header in headers)
            {
                if (ExcludeHeaders.Contains(header.Key))
                {
                    continue;
                }
                if (!entryHeaders.TryGetValue(header.Key, out string[] values) ||
                    !values.SequenceEqual(header.Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
