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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Reports progress on an upload for a folder.
    /// </summary>
    public class UploadFolderProgress
    {
        
        #region Private
        private List<UploadProgress> _fileProgress;

        private ConcurrentQueue<UploadProgress> _progressBacklog;

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
            _progressBacklog = new ConcurrentQueue<UploadProgress>();

            foreach (var fileMetadata in metadata.Files)
            {
                var toAdd = new UploadProgress(fileMetadata);
                if (fileMetadata.Status == SegmentUploadStatus.Complete)
                {
                    this.UploadedByteCount += fileMetadata.FileLength;
                    this.UploadedFileCount++;
                    toAdd.UploadedByteCount = toAdd.TotalFileLength;
                    foreach(var segment in toAdd._segmentProgress)
                    {
                        segment.UploadedByteCount = segment.Length;
                    }
                }

                _fileProgress.Add(toAdd);
            }
        }

        internal Thread GetProgressTrackingThread(CancellationToken token)
        {
            return new Thread(() =>
            {
                try
                {
                    this.SetSegmentProgress(token);
                }
                catch (OperationCanceledException)
                {
                    // do nothing, since we have already cancelled.
                }
            });
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
        /// Gets the count of files that failed.
        /// </summary>
        /// <value>
        /// The failed file count.
        /// </value>
        public long FailedFileCount { get; private set; }

        /// <summary>
        /// Gets the upload progress for a particular file.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the file to retrieve information for</param>
        /// <returns></returns>
        public UploadProgress GetSegmentProgress(int segmentNumber)
        {
            return _fileProgress[segmentNumber];
        }

        internal void SetSegmentProgress(UploadProgress segmentProgress)
        {
            _progressBacklog.Enqueue(segmentProgress);
        }

        /// <summary>
        /// Updates the progress to indicate that a file failed
        /// </summary>
        internal void OnFileUploadThreadAborted(UploadMetadata failedFile)
        {
            ++this.FailedFileCount;
            
            var previousProgress = _fileProgress.Where(p => p.UploadId.Equals(failedFile.UploadId, StringComparison.InvariantCultureIgnoreCase)).First();
            foreach (var segment in previousProgress._segmentProgress)
            {
                // only fail out segments that haven't been completed.
                if (segment.Length != segment.UploadedByteCount)
                {
                    segment.IsFailed = true;
                }

                previousProgress.SetSegmentProgress(segment);
            }
            
        }

        /// <summary>
        /// Updates the progress while there is still progress to update.
        /// </summary>
        private void SetSegmentProgress(CancellationToken token)
        {
            UploadProgress segmentProgress;
            while (this.UploadedFileCount + this.FailedFileCount < this.TotalFileCount)
            {
                token.ThrowIfCancellationRequested();
                if(_progressBacklog.TryDequeue(out segmentProgress))
                {
                    token.ThrowIfCancellationRequested();
                    var previousProgress = _fileProgress.Where(p => p.UploadId.Equals(segmentProgress.UploadId, StringComparison.InvariantCultureIgnoreCase)).First();

                    long deltaLength = segmentProgress.UploadedByteCount - previousProgress.UploadedByteCount;
                    this.UploadedByteCount += deltaLength;

                    // check to see if this upload is complete and that we haven't already marked it as complete
                    if (segmentProgress.UploadedByteCount == segmentProgress.TotalFileLength && deltaLength > 0)
                    {
                        ++this.UploadedFileCount;
                    }

                    // Iterate through all the segments inside this upload we are setting to get them up-to-date
                    foreach (var segment in segmentProgress._segmentProgress)
                    {
                        token.ThrowIfCancellationRequested();
                        previousProgress.SetSegmentProgress(segment);
                    }
                }
            }
        }

        #endregion

    }
}
