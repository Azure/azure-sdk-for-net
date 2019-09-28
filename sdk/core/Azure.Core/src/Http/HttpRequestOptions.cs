// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Http
{
    /// <summary>
    /// Specifies standard HTTP request options.
    /// </summary>
    public struct HttpRequestOptions : IEquatable<HttpRequestOptions>
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
        /// Optionally limit requests to resources that have a matching ETag.
        /// </summary>
        public ETag? IfMatch { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that do not match the ETag.
        /// </summary>
        public ETag? IfNoneMatch { get; set; }

        /// <summary>
        /// Check if two HttpRequestOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is HttpRequestOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the HttpRequestOptions.
        /// </summary>
        /// <returns>Hash code for the HttpRequestOptions.</returns>
        public override int GetHashCode()
            => IfModifiedSince.GetHashCode()
            ^ IfUnmodifiedSince.GetHashCode()
            ^ IfMatch.GetHashCode()
            ^ IfNoneMatch.GetHashCode()
            ;

        /// <summary>
        /// Check if two HttpRequestOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(HttpRequestOptions left, HttpRequestOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two HttpRequestOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(HttpRequestOptions left, HttpRequestOptions right) => !(left == right);

        /// <summary>
        /// Check if two HttpRequestOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(HttpRequestOptions other)
            => IfMatch == other.IfMatch
            && IfModifiedSince == other.IfModifiedSince
            && IfNoneMatch == other.IfNoneMatch
            && IfUnmodifiedSince == other.IfUnmodifiedSince
            ;

        /// <summary>
        /// Converts the value of the current HttpRequestOptions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the HttpRequestOptions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(HttpRequestOptions)}:{nameof(IfModifiedSince)}={IfModifiedSince};{nameof(IfUnmodifiedSince)}={IfUnmodifiedSince};{nameof(IfMatch)}={IfMatch};{nameof(IfNoneMatch)}={IfNoneMatch}]";
    }
}
