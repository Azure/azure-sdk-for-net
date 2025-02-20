// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Defines a range of bytes within an HTTP resource, starting at an offset and
    /// ending at offset+count-1 inclusively.
    /// </summary>
    public readonly struct HttpRange : IEquatable<HttpRange>
    {
        // We only support using the "bytes" unit.
        private const string Unit = "bytes";

        /// <summary>
        /// Gets the starting offset of the <see cref="HttpRange"/>.
        /// </summary>
        public long Offset { get; }

        /// <summary>
        /// Gets the size of the <see cref="HttpRange"/>.  null means the range
        /// extends all the way to the end.
        /// </summary>
        public long? Length { get; }

        /// <summary>
        /// Creates an instance of HttpRange.
        /// </summary>
        /// <param name="offset">The starting offset of the <see cref="HttpRange"/>. Defaults to 0.</param>
        /// <param name="length">The length of the range. null means to the end.</param>
        public HttpRange(long offset = 0, long? length = default)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (length.HasValue && length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Converts the specified range to a string.
        /// </summary>
        /// <returns>String representation of the range.</returns>
        /// <remarks>For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-the-range-header-for-file-service-operations. </remarks>
        public override string ToString()
        {
            // No additional validation by design. API can validate parameter by case, and use this method.
            if (Length.HasValue && Length != 0)
            {
                var endRange = Offset + Length.Value - 1;
#if NET6_0_OR_GREATER
                return string.Create(CultureInfo.InvariantCulture, $"{Unit}={Offset}-{endRange}");
#else
                return FormattableString.Invariant($"{Unit}={Offset}-{endRange}");
#endif
            }

#if NET6_0_OR_GREATER
            return string.Create(CultureInfo.InvariantCulture, $"{Unit}={Offset}-");
#else
            return FormattableString.Invariant($"{Unit}={Offset}-");
#endif
        }

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(HttpRange left, HttpRange right) => left.Equals(right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(HttpRange left, HttpRange right) => !(left == right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(HttpRange other) => Offset == other.Offset && Length == other.Length;

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is HttpRange other && Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="HttpRange"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="HttpRange"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => HashCodeBuilder.Combine(Offset, Length);
    }
}
