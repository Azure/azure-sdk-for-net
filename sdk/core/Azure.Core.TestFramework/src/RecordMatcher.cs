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
        /// <summary>
        /// Whether or not to compare bodies from the request and the recorded request during playback.
        /// </summary>
        public bool CompareBodies { get; }

        public RecordMatcher(bool compareBodies = true)
        {
            CompareBodies = compareBodies;

            if (!compareBodies)
            {
                IgnoredHeaders.Add("Content-Length");
            }
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

        /// <summary>
        /// Query parameters whose values can change between recording and playback without causing URI matching
        /// to fail. The presence or absence of the query parameter itself is still respected in matching.
        /// </summary>
        public HashSet<string> IgnoredQueryParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
        };
    }
}
