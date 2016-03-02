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
    /// Reports progress on an upload.
    /// </summary>
    public class UploadProgress
    {
        
        #region Private

        private SegmentUploadProgress[] _segmentProgress;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadProgress"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        internal UploadProgress(UploadMetadata metadata)
        {
            Populate(metadata);
        }

        /// <summary>
        /// Populates the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        private void Populate(UploadMetadata metadata)
        {
            this.TotalFileLength = metadata.FileLength;
            this.TotalSegmentCount = metadata.SegmentCount;

            _segmentProgress = new SegmentUploadProgress[this.TotalSegmentCount];

            foreach (var segmentInfo in metadata.Segments)
            {
                if (segmentInfo.Status == SegmentUploadStatus.Complete)
                {
                    this.UploadedByteCount += segmentInfo.Length;
                    _segmentProgress[segmentInfo.SegmentNumber] = new SegmentUploadProgress(segmentInfo.SegmentNumber, segmentInfo.Length, segmentInfo.Length, false);
                }
                else
                {
                    _segmentProgress[segmentInfo.SegmentNumber] = new SegmentUploadProgress(segmentInfo.SegmentNumber, segmentInfo.Length, 0, false);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating the total length of the file to upload.
        /// </summary>
        /// <value>
        /// The total length of the file.
        /// </value>
        public long TotalFileLength { get; private set; }

        /// <summary>
        /// Gets a value indicating the total number of segments to upload.
        /// </summary>
        /// <value>
        /// The total segment count.
        /// </value>
        public int TotalSegmentCount { get; private set; }

        /// <summary>
        /// Gets a value indicating the number of bytes that have been uploaded so far.
        /// </summary>
        /// <value>
        /// The uploaded byte count.
        /// </value>
        public long UploadedByteCount { get; private set; }

        /// <summary>
        /// Gets the upload progress for a particular segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment to retrieve information for</param>
        /// <returns></returns>
        public SegmentUploadProgress GetSegmentProgress(int segmentNumber)
        {
            return _segmentProgress[segmentNumber];
        }

        /// <summary>
        /// Updates the progress for the given segment
        /// </summary>
        /// <param name="segmentProgress">The segment progress.</param>
        internal void SetSegmentProgress(SegmentUploadProgress segmentProgress)
        {
            lock (_segmentProgress)
            {
                var previousProgress = _segmentProgress[segmentProgress.SegmentNumber];

                //calculate how many additional bytes we have uploaded so far
                //the caveat here is that if a segment failed, we need to report it as 0 bytes uploaded (even though we did upload something; upon resume, we will reupload from scratch)
                long deltaLength = segmentProgress.IsFailed ? 0 : segmentProgress.UploadedByteCount;
                deltaLength -= previousProgress.IsFailed ? 0 : previousProgress.UploadedByteCount;

                this.UploadedByteCount += deltaLength;

                _segmentProgress[segmentProgress.SegmentNumber] = segmentProgress;
            }
        }

        #endregion

    }
}
