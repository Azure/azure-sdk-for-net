// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Http
{
    /// <summary>
    /// Specifies HTTP options for conditional requests.
    /// </summary>
    public class ConditionalRequestOptions : IEquatable<ConditionalRequestOptions>
    {
        private const string IfMatchHeader = "If-Match";
        private const string IfNoneMatchHeader = "If-None-Match";

        /// <summary>
        /// Optionally limit requests to resources that have a matching ETag.
        /// </summary>
        public ETag? IfMatch { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that do not match the ETag.
        /// </summary>
        public ETag? IfNoneMatch { get; set; }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource has changed.
        /// </summary>
        /// <param name="etag">The version of the resource to compare to.</param>
        public virtual void SetIfModifiedCondition(ETag etag)
        {
            IfNoneMatch = etag;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource has not changed.
        /// </summary>
        public virtual void SetIfUnmodifiedCondition(ETag etag)
        {
            IfMatch = etag;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource is present.
        /// </summary>
        public virtual void SetIfPresentCondition()
        {
            IfMatch = new ETag("*");
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource is not present.
        /// </summary>
        public virtual void SetIfAbsentCondition()
        {
            IfNoneMatch = new ETag("*");
        }

        public virtual void ApplyHeaders(Request request)
        {
            if (IfMatch.HasValue)
            {
                string value = IfMatch.ToString();
                value = value == "*" ? value : $"\"{value}\"";
                request.Headers.Add(IfMatchHeader, value);
            }

            if (IfNoneMatch.HasValue)
            {
                string value = IfNoneMatch.ToString();
                value = value == "*" ? value : $"\"{value}\"";
                request.Headers.Add(IfNoneMatchHeader, value);
            }
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must
        /// also be a ConditionalRequestOptions object, have the same value.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>true if obj is a ConditionalRequestOptions and its value is
        /// the same as this instance; otherwise, false. If obj is null, the
        /// method returns false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is ConditionalRequestOptions other && Equals(other);
        }

        /// <summary>
        /// Get a hash code for the ConditionalRequestOptions.
        /// </summary>
        /// <returns>Hash code for the ConditionalRequestOptions.</returns>
        public override int GetHashCode()
            => IfMatch.GetHashCode() ^ IfNoneMatch.GetHashCode();

        /// <summary>
        /// Check if two ConditionalRequestOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ConditionalRequestOptions other)
        {
            if (other == null)
            {
                return false;
            }

            return IfMatch == other.IfMatch && IfNoneMatch == other.IfNoneMatch;
        }
    }
}
