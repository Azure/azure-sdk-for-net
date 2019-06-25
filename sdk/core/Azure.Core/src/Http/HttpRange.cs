// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core.Pipeline;

namespace Azure.Core.Http
{
    /// <summary>
    /// Defines a range of bytes within an HTTP resource, starting at an offset and
    /// ending at offset+count-1 inclusively.
    /// </summary>
    public readonly struct HttpRange : IEquatable<HttpRange>
    {
        public HttpRange(long? offset = default, long? count = default)
        {
            this.Offset = offset ?? 0;
            this.Count = count;
        }

        // An httpRange which has a zero-value offset, and a count with value CountToEnd indicates the entire resource.
        // An httpRange which has a non zero-value offset but a count with value CountToEnd indicates from the offset to the resource's end.
        internal readonly long Offset;
        internal readonly long? Count;
        private const string Unit = "bytes";
        
        /// <summary>
        /// Converts the specified range to a string adhering to the REST API specification.
        /// Does not validate parameters.
        /// </summary>
        /// <param name="offset">Offset of the range in bytes.</param>
        /// <param name="count">Size of the range in bytes. Or 0 to specify "until end."</param>
        /// <returns>String representation understood by the REST API.</returns>
        /// <remarks>For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-the-range-header-for-file-service-operations. </remarks>
        public override string ToString()
        {
            // No additional validation by design. API can validate parameter by case, and use this method.
            var endRange = "";
            if (this.Count.HasValue && this.Count != 0)
            {
                endRange = (this.Offset + this.Count.Value - 1).ToString(CultureInfo.InvariantCulture);
            }

            return FormattableString.Invariant($"{Unit}={this.Offset}-{endRange}");
        }
        public HttpHeader ToRangeHeader() => new HttpHeader("Range", ToString());

        public static bool operator==(HttpRange left, HttpRange right) => left.Equals(right);
        public static bool operator!=(HttpRange left, HttpRange right) => !(left == right);

        public bool Equals(HttpRange other)
            => this.Offset == other.Offset
            && this.Count == other.Count
            ;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HttpRange other && this.Equals(other);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => HashCodeBuilder.Combine(Offset, Count);
    }
}
