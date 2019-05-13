// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Globalization;
using Azure.Storage.Common;

#if BlobSDK
namespace Azure.Storage.Blobs
{
#elif QueueSDK
namespace Azure.Storage.Queues 
{
#elif FileSDK
namespace Azure.Storage.Files
{
#endif

    /// <summary>
    /// Defines a range of bytes within an HTTP resource, starting at an offset and
    /// ending at offset+count-1 inclusively.
    /// </summary>
    public struct HttpRange : System.IEquatable<HttpRange>
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

        /// <summary>
        /// Converts the specified range to a string adhering to the REST API specification.
        /// Does not validate parameters.
        /// </summary>
        /// <param name="offset">Offset of the range in bytes.</param>
        /// <param name="count">Size of the range in bytes. Or 0 to specify "until end."</param>
        /// <returns>String representation understood by the REST API.</returns>
        /// <remarks>For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-the-range-header-for-file-service-operations. </remarks>
        internal string ToRange()
        {
            // No additional validation by design. API can validate parameter by case, and use this method.
            var endRange = "";
            if (this.Count.HasValue && this.Count != 0)
            {
                endRange = (this.Offset + this.Count.Value - 1).ToString(CultureInfo.InvariantCulture);
            }

            return StringExtensions.Invariant($"bytes={this.Offset}-{endRange}");
        }

        public override bool Equals(object obj) =>
            obj is HttpRange other && this.Equals(other);

        public override int GetHashCode()
            => this.Offset.GetHashCode()
            ^ this.Count.GetHashCode()
            ;

        public static bool operator ==(HttpRange left, HttpRange right) => left.Equals(right);

        public static bool operator !=(HttpRange left, HttpRange right) => !(left == right);

        public bool Equals(HttpRange other)
            => this.Offset == other.Offset
            && this.Count == other.Count
            ;
    }
}
