// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob container specific access conditions.
    /// </summary>
    public struct ContainerAccessConditions : IEquatable<ContainerAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies container lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is ContainerAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the ContainerAccessConditions.
        /// </summary>
        /// <returns>Hash code for the ContainerAccessConditions.</returns>
        public override int GetHashCode()
            => HttpAccessConditions.GetHashCode()
            ^ LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(ContainerAccessConditions left, ContainerAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two ContainerAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(ContainerAccessConditions left, ContainerAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ContainerAccessConditions other)
            => HttpAccessConditions == other.HttpAccessConditions
            && LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current ContainerAccessConditions object
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the ContainerAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(ContainerAccessConditions)}:{nameof(HttpAccessConditions)}={HttpAccessConditions};{nameof(LeaseAccessConditions)}={LeaseAccessConditions}]";
    }
}
