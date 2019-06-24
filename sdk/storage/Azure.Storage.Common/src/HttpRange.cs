// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.ComponentModel;
using System.Globalization;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Defines a range of bytes within an HTTP resource, starting at an offset
    /// and ending at offset+count-1 inclusively.
    /// </summary>
    public readonly struct HttpRange : System.IEquatable<HttpRange>
    {
        internal readonly long Offset;
        internal readonly long? Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRange"/> struct.
        /// </summary>
        /// <param name="offset">The starting offset.</param>
        /// <param name="count">The length of the range.</param>
        public HttpRange(long? offset = default, long? count = default)
        {
            this.Offset = offset ?? 0;
            this.Count = count;
        }

        /// <summary>
        /// Converts the specified range to a string.
        /// <returns>String representation of the range.</returns>
        /// <remarks>For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-the-range-header-for-file-service-operations. </remarks>
        public override string ToString()
        {
            // No additional validation by design. API can validate parameter by case, and use this method.
            var endRange = "";
            if (this.Count.HasValue && this.Count != 0)
            {
                endRange = (this.Offset + this.Count.Value - 1).ToString(CultureInfo.InvariantCulture);
            }

            return StringExtensions.Invariant($"bytes={this.Offset}-{endRange}");
        }

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is HttpRange other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="HttpRange"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="HttpRange"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            this.Offset.GetHashCode() ^ this.Count.GetHashCode();

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(HttpRange left, HttpRange right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(HttpRange left, HttpRange right) =>
            !(left == right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(HttpRange other) =>
            this.Offset == other.Offset &&
            this.Count == other.Count;
    }
}
