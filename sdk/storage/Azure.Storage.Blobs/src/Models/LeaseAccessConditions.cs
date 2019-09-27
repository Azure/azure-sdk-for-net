// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob lease access conditions for a container or blob.
    /// </summary>
    public struct LeaseAccessConditions : IEquatable<LeaseAccessConditions>
    {
        /// <summary>
        /// Optionally limit requests to resources with an active lease
        /// matching this Id.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is LeaseAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the LeaseAccessConditions.
        /// </summary>
        /// <returns>Hash code for the LeaseAccessConditions.</returns>
        public override int GetHashCode()
            => LeaseId.GetHashCode();

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(LeaseAccessConditions left, LeaseAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two LeaseAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(LeaseAccessConditions left, LeaseAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(LeaseAccessConditions other)
            => LeaseId == other.LeaseId;

        /// <summary>
        /// Converts the value of the current HttpAccessConditions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the HttpAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(LeaseAccessConditions)}:{nameof(LeaseId)}={LeaseId}]";
    }
}
