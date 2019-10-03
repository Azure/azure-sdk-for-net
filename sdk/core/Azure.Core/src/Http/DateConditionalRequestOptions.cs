// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Http
{
    public class DateConditionalRequestOptions : ConditionalRequestOptions
    {
        /// <summary>
        /// Optionally limit requests to resources that have only been
        /// modified since this point in time.
        /// </summary>
        public DateTimeOffset? IfModifiedSince { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that have remained
        /// unmodified
        /// </summary>
        public DateTimeOffset? IfUnmodifiedSince { get; set; }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only to
        /// resources that have been modified since the specified date.
        /// </summary>
        public virtual void SetIfModifiedSinceCondition(DateTimeOffset dateTime)
        {
            IfModifiedSince = dateTime;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only to
        /// resources that have not been modified since the specified date.
        /// </summary>
        public virtual void SetIfUnmodifiedSinceCondition(DateTimeOffset dateTime)
        {
            IfUnmodifiedSince = dateTime;
        }
    }
}
