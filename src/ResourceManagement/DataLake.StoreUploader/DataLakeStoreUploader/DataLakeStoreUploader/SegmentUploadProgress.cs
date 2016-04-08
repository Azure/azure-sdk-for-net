// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents a class used for reporting upload progress on a segment.
    /// </summary>
    public class SegmentUploadProgress
    {

        /// <summary>
        /// Creates a new segment progress report.
        /// </summary>
        /// <param name="segmentNumber">The segment number the report refers to.</param>
        /// <param name="segmentLength">The segment length, in bytes.</param>
        /// <param name="uploadedByteCount">The number of bytes uploaded so far.</param>
        /// <param name="isFailed">Whether the upload operation failed.</param>
        internal SegmentUploadProgress(int segmentNumber, long segmentLength, long uploadedByteCount, bool isFailed)
        {
            this.SegmentNumber = segmentNumber;
            this.Length = segmentLength;
            this.UploadedByteCount = uploadedByteCount;
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
        /// Gets a value indicating whether the upload failed or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is failed; otherwise, <c>false</c>.
        /// </value>
        public bool IsFailed { get; private set; }

        /// <summary>
        /// Gets a value indicating the number of bytes uploaded so far for this segment.
        /// </summary>
        /// <value>
        /// The uploaded byte count.
        /// </value>
        public long UploadedByteCount { get; private set; }

    }
}
