// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob specific access conditions.
    /// </summary>
    public struct BlobAccessConditions : IEquatable<BlobAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies blob lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the BlobAccessConditions.
        /// </summary>
        public override int GetHashCode()
            => HttpAccessConditions.GetHashCode()
            ^ LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobAccessConditions left, BlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobAccessConditions left, BlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobAccessConditions other)
            => HttpAccessConditions == other.HttpAccessConditions
            && LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current BlobAccessConditions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the BlobAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(BlobAccessConditions)}:{nameof(HttpAccessConditions)}={HttpAccessConditions};{nameof(LeaseAccessConditions)}={LeaseAccessConditions}]";
    }
}
