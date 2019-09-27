// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies page blob specific access conditions.
    /// </summary>
    public struct PageBlobAccessConditions : IEquatable<PageBlobAccessConditions>
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
        /// IfSequenceNumberLessThan ensures that the page blob operation
        /// succeeds only if the blob's sequence number is less than a value.
        /// </summary>
        public long? IfSequenceNumberLessThan { get; set; }

        /// <summary>
        /// IfSequenceNumberLessThanOrEqual ensures that the page blob
        /// operation succeeds only if the blob's sequence number is less than
        /// or equal to a value.
        /// </summary>
        public long? IfSequenceNumberLessThanOrEqual { get; set; }

        /// <summary>
        /// IfSequenceNumberEqual ensures that the page blob operation
        /// succeeds only if the blob's sequence number is equal to a value.
        /// </summary>
        public long? IfSequenceNumberEqual { get; set; }

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is PageBlobAccessConditions other && Equals(other);

        /// <summary>
        /// Get a hash code for the PageBlobAccessConditions.
        /// </summary>
        /// <returns>Hash code for the PageBlobAccessConditions.</returns>
        public override int GetHashCode()
            => HttpAccessConditions.GetHashCode()
            ^ IfSequenceNumberEqual.GetHashCode()
            ^ IfSequenceNumberLessThan.GetHashCode()
            ^ IfSequenceNumberLessThanOrEqual.GetHashCode()
            ^ LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(PageBlobAccessConditions left, PageBlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(PageBlobAccessConditions left, PageBlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(PageBlobAccessConditions other)
            => HttpAccessConditions == other.HttpAccessConditions
            && IfSequenceNumberEqual == other.IfSequenceNumberEqual
            && IfSequenceNumberLessThan == other.IfSequenceNumberLessThan
            && IfSequenceNumberLessThanOrEqual == other.IfSequenceNumberLessThanOrEqual
            && LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current PageBlobAccessConditions object
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the PageBlobAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(PageBlobAccessConditions)}:{nameof(HttpAccessConditions)}={HttpAccessConditions};{nameof(LeaseAccessConditions)}={LeaseAccessConditions};{nameof(IfSequenceNumberLessThan)}={IfSequenceNumberLessThan};{nameof(IfSequenceNumberLessThanOrEqual)}={IfSequenceNumberLessThanOrEqual};{nameof(IfSequenceNumberEqual)}={IfSequenceNumberEqual}]";
    }
}
