// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Http
{
    public class TemporalRequestOptions : ConditionalRequestOptions, IEquatable<TemporalRequestOptions>
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

        /// <summary>
        /// Determines whether this instance and a specified object, which must
        /// also be a TemporalRequestOptions object, have the same value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is TemporalRequestOptions other && Equals(other);
        }

        /// <summary>
        /// Get a hash code for the TemporalRequestOptions.
        /// </summary>
        /// <returns>Hash code for the TemporalRequestOptions.</returns>
        public override int GetHashCode()
            => IfModifiedSince.GetHashCode()
            ^ IfUnmodifiedSince.GetHashCode()
            ^ IfMatch.GetHashCode()
            ^ IfNoneMatch.GetHashCode();

        /// <summary>
        /// Check if two TemporalRequestOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(TemporalRequestOptions other)
        {
            if (other == null)
            {
                return false;
            }

            return IfMatch == other.IfMatch
                && IfModifiedSince == other.IfModifiedSince
                && IfNoneMatch == other.IfNoneMatch
                && IfUnmodifiedSince == other.IfUnmodifiedSince;
        }
    }
}
