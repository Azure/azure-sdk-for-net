// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    /// <summary>
    /// Specifies HTTP options for conditional requests based on modification time.
    /// </summary>
    public class RequestConditions : MatchConditions
    {
        /// <summary>
        /// Optionally limit requests to resources that have only been
        /// modified since this point in time.
        /// </summary>
        public DateTimeOffset? IfModifiedSince { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that have remained
        /// unmodified.
        /// </summary>
        public DateTimeOffset? IfUnmodifiedSince { get; set; }
    }
}
