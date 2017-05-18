// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents a class used for reporting transfer progress on a segment.
    /// </summary>
    public class SegmentTransferProgress
    {

        /// <summary>
        /// Creates a new segment progress report.
        /// </summary>
        /// <param name="segmentNumber">The segment number the report refers to.</param>
        /// <param name="segmentLength">The segment length, in bytes.</param>
        /// <param name="transferredByteCount">The number of bytes transferred so far.</param>
        /// <param name="isFailed">Whether the transfer operation failed.</param>
        internal SegmentTransferProgress(int segmentNumber, long segmentLength, long transferredByteCount, bool isFailed)
        {
            this.SegmentNumber = segmentNumber;
            this.Length = segmentLength;
            this.TransferredByteCount = transferredByteCount;
            this.IsFailed = isFailed;
        }

        /// <summary>
        /// Gets a value indicating the segment number this progress report refers to.
        /// </summary>
        /// <value>
        /// The segment number.
        /// </value>
        public int SegmentNumber { get; private set; }

        /// <summary>
        /// Gets a value indicating the segment length, in bytes.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public long Length { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the transfer failed or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is failed; otherwise, <c>false</c>.
        /// </value>
        public bool IsFailed { get; internal set; }

        /// <summary>
        /// Gets a value indicating the number of bytes transferred so far for this segment.
        /// </summary>
        /// <value>
        /// The transferred byte count.
        /// </value>
        public long TransferredByteCount { get; internal set; }

    }
}
