// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Reports progress on an transfer for a folder.
    /// </summary>
    public class TransferFolderProgress
    {
        
        #region Private
        private List<TransferProgress> _fileProgress;

        private ConcurrentQueue<TransferProgress> _progressBacklog;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferFolderProgress"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        internal TransferFolderProgress(TransferFolderMetadata metadata)
        {
            Populate(metadata);
        }

        /// <summary>
        /// Populates the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        private void Populate(TransferFolderMetadata metadata)
        {
            this.TotalFileLength = metadata.TotalFileBytes;
            this.TotalFileCount = metadata.FileCount;
            _fileProgress = new List<TransferProgress>(this.TotalFileCount);
            _progressBacklog = new ConcurrentQueue<TransferProgress>();

            foreach (var fileMetadata in metadata.Files)
            {
                var toAdd = new TransferProgress(fileMetadata);
                if (fileMetadata.Status == SegmentTransferStatus.Complete)
                {
                    this.TransferredByteCount += fileMetadata.FileLength;
                    this.TransferredFileCount++;
                    toAdd.TransferredByteCount = toAdd.TotalFileLength;
                    foreach(var segment in toAdd._segmentProgress)
                    {
                        segment.TransferredByteCount = segment.Length;
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
        /// Gets a value indicating the total length of the file to transfer.
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
        /// Gets a value indicating the number of bytes that have been transferred so far.
        /// </summary>
        /// <value>
        /// The transferred byte count.
        /// </value>
        public long TransferredByteCount { get; private set; }

        /// <summary>
        /// Gets the transferred file count.
        /// </summary>
        /// <value>
        /// The transferred file count.
        /// </value>
        public long TransferredFileCount { get; private set; }

        /// <summary>
        /// Gets the count of files that failed.
        /// </summary>
        /// <value>
        /// The failed file count.
        /// </value>
        public long FailedFileCount { get; private set; }

        /// <summary>
        /// Gets the transfer progress for a particular file.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the file to retrieve information for</param>
        /// <returns></returns>
        public TransferProgress GetSegmentProgress(int segmentNumber)
        {
            return _fileProgress[segmentNumber];
        }

        internal void SetSegmentProgress(TransferProgress segmentProgress)
        {
            _progressBacklog.Enqueue(segmentProgress);
        }

        /// <summary>
        /// Updates the progress to indicate that a file failed
        /// </summary>
        internal void OnFileTransferThreadAborted(TransferMetadata failedFile)
        {
            ++this.FailedFileCount;
            
            var previousProgress = _fileProgress.Where(p => p.TransferId.Equals(failedFile.TransferId, StringComparison.OrdinalIgnoreCase)).First();
            foreach (var segment in previousProgress._segmentProgress)
            {
                // only fail out segments that haven't been completed.
                if (segment.Length != segment.TransferredByteCount)
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
            TransferProgress segmentProgress;
            while (this.TransferredFileCount + this.FailedFileCount < this.TotalFileCount)
            {
                token.ThrowIfCancellationRequested();
                if(_progressBacklog.TryDequeue(out segmentProgress))
                {
                    token.ThrowIfCancellationRequested();
                    var previousProgress = _fileProgress.Where(p => p.TransferId.Equals(segmentProgress.TransferId, StringComparison.OrdinalIgnoreCase)).First();

                    long deltaLength = segmentProgress.TransferredByteCount - previousProgress.TransferredByteCount;
                    this.TransferredByteCount += deltaLength;

                    // check to see if this transfer is complete and that we haven't already marked it as complete
                    if (segmentProgress.TransferredByteCount == segmentProgress.TotalFileLength && deltaLength > 0)
                    {
                        ++this.TransferredFileCount;
                    }

                    // Iterate through all the segments inside this transfer we are setting to get them up-to-date
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
