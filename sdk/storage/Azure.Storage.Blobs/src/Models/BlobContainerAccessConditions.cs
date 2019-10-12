﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob container specific access conditions.
    /// </summary>
    public struct BlobContainerAccessConditions : IEquatable<BlobContainerAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies blob container lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// Check if two BlobContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobContainerAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the BlobContainerAccessConditions.
        /// </summary>
        /// <returns>Hash code for the BlobContainerAccessConditions.</returns>
        public override int GetHashCode()
            => HttpAccessConditions.GetHashCode()
            ^ LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two BlobContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobContainerAccessConditions left, BlobContainerAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobContainerAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobContainerAccessConditions left, BlobContainerAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two BlobContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobContainerAccessConditions other)
            => HttpAccessConditions == other.HttpAccessConditions
            && LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current BlobContainerAccessConditions object
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the BlobContainerAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(BlobContainerAccessConditions)}:{nameof(HttpAccessConditions)}={HttpAccessConditions};{nameof(LeaseAccessConditions)}={LeaseAccessConditions}]";
    }
}
