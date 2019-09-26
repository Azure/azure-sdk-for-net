// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies append blob specific access conditions.
    /// </summary>
    public struct AppendBlobAccessConditions : IEquatable<AppendBlobAccessConditions>
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
        /// IfAppendPositionEqual ensures that the AppendBlock operation
        /// succeeds only if the append position is equal to a value.
        /// </summary>
        public long? IfAppendPositionEqual { get; set; }

        /// <summary>
        /// IfMaxSizeLessThanOrEqual ensures that the AppendBlock operation
        /// succeeds only if the append blob's size is less than or equal to
        /// a value.
        /// </summary>
        public long? IfMaxSizeLessThanOrEqual { get; set; }

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is AppendBlobAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the AppendBlobAccessConditions.
        /// </summary>
        /// <returns>Hash code for the AppendBlobAccessConditions.</returns>
        public override int GetHashCode()
            => HttpAccessConditions.GetHashCode()
            ^ IfAppendPositionEqual.GetHashCode()
            ^ IfMaxSizeLessThanOrEqual.GetHashCode()
            ^ LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(AppendBlobAccessConditions left, AppendBlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(AppendBlobAccessConditions left, AppendBlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(AppendBlobAccessConditions other)
            => HttpAccessConditions == other.HttpAccessConditions
            && IfAppendPositionEqual == other.IfAppendPositionEqual
            && IfMaxSizeLessThanOrEqual == other.IfMaxSizeLessThanOrEqual
            && LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current AppendBlobAccessConditions
        /// object to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the AppendBlobAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(AppendBlobAccessConditions)}:{nameof(HttpAccessConditions)}={HttpAccessConditions};{nameof(LeaseAccessConditions)}={LeaseAccessConditions};{nameof(IfAppendPositionEqual)}={IfAppendPositionEqual};{nameof(IfMaxSizeLessThanOrEqual)}={IfMaxSizeLessThanOrEqual}]";
    }
}
