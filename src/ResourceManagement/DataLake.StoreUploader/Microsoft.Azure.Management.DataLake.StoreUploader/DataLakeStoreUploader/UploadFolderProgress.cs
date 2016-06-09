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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Reports progress on an upload for a folder.
    /// </summary>
    public class UploadFolderProgress
    {
        
        #region Private

        private List<UploadProgress> _fileProgress;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFolderProgress"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        internal UploadFolderProgress(UploadFolderMetadata metadata)
        {
            Populate(metadata);
        }

        /// <summary>
        /// Populates the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        private void Populate(UploadFolderMetadata metadata)
        {
            this.TotalFileLength = metadata.TotalFileBytes;
            this.TotalFileCount = metadata.FileCount;
            _fileProgress = new List<UploadProgress>(this.TotalFileCount);

            foreach (var fileMetadata in metadata.Files)
            {
                if (fileMetadata.Status == SegmentUploadStatus.Complete)
                {
                    this.UploadedByteCount += fileMetadata.FileLength;
                    this.UploadedFileCount++;
                }

                _fileProgress.Add(new UploadProgress(fileMetadata));
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
        /// Gets the total file count.
        /// </summary>
        /// <value>
        /// The total file count.
        /// </value>
        public int TotalFileCount { get; private set; }

        /// <summary>
        /// Gets a value indicating the number of bytes that have been uploaded so far.
        /// </summary>
        /// <value>
        /// The uploaded byte count.
        /// </value>
        public long UploadedByteCount { get; private set; }

        /// <summary>
        /// Gets the uploaded file count.
        /// </summary>
        /// <value>
        /// The uploaded file count.
        /// </value>
        public long UploadedFileCount { get; private set; }

        /// <summary>
        /// Gets the upload progress for a particular file.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the file to retrieve information for</param>
        /// <returns></returns>
        public UploadProgress GetSegmentProgress(int segmentNumber)
        {
            return _fileProgress[segmentNumber];
        }

        /// <summary>
        /// Updates the progress for the given segment
        /// </summary>
        /// <param name="segmentProgress">The segment progress.</param>
        internal void SetSegmentProgress(UploadProgress segmentProgress)
        {
            lock (_fileProgress)
            {
                var previousProgress = _fileProgress.Where(p => p.UploadId.Equals(segmentProgress.UploadId, StringComparison.InvariantCultureIgnoreCase)).First();
                
                long deltaLength = segmentProgress.UploadedByteCount - previousProgress.UploadedByteCount;
                this.UploadedByteCount += deltaLength;

                // check to see if this upload is complete and that we haven't already marked it as complete
                if(segmentProgress.UploadedByteCount == segmentProgress.TotalFileLength && deltaLength > 0)
                {
                    this.UploadedFileCount++;
                }

                // Iterate through all the segments inside this upload we are setting to get them up-to-date
                foreach (var segment in segmentProgress._segmentProgress)
                {
                    previousProgress.SetSegmentProgress(segment);
                }
            }
        }

        #endregion

    }
}
