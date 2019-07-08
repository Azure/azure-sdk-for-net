// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Reports progress on a transfer.
    /// </summary>
    public class TransferProgress
    {
        
        #region Private

        internal SegmentTransferProgress[] _segmentProgress;
        private readonly IProgress<TransferProgress> _progressTracker;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferProgress" /> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="progressTracker">The progress tracker.</param>
        internal TransferProgress(TransferMetadata metadata, IProgress<TransferProgress> progressTracker = null)
        {
            _progressTracker = progressTracker;
            Populate(metadata);
        }

        /// <summary>
        /// Populates the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        private void Populate(TransferMetadata metadata)
        {
            this.TotalFileLength = metadata.FileLength;
            this.TotalSegmentCount = metadata.SegmentCount;
            this.TransferId = metadata.TransferId;
            _segmentProgress = new SegmentTransferProgress[this.TotalSegmentCount];

            foreach (var segmentInfo in metadata.Segments)
            {
                if (segmentInfo.Status == SegmentTransferStatus.Complete)
                {
                    this.TransferredByteCount += segmentInfo.Length;
                    _segmentProgress[segmentInfo.SegmentNumber] = new SegmentTransferProgress(segmentInfo.SegmentNumber, segmentInfo.Length, segmentInfo.Length, false);
                }
                else
                {
                    _segmentProgress[segmentInfo.SegmentNumber] = new SegmentTransferProgress(segmentInfo.SegmentNumber, segmentInfo.Length, 0, false);
                }
            }
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
        /// Gets a value indicating the total number of segments to transfer.
        /// </summary>
        /// <value>
        /// The total segment count.
        /// </value>
        public int TotalSegmentCount { get; private set; }

        /// <summary>
        /// Gets a value indicating the number of bytes that have been transferred so far.
        /// </summary>
        /// <value>
        /// The transferred byte count.
        /// </value>
        public long TransferredByteCount { get; internal set; }

        /// <summary>
        /// Gets or sets the transfer identifier, which is used by folder transfer to find each
        /// individual file transfer when updating progress.
        /// </summary>
        /// <value>
        /// The transfer identifier.
        /// </value>
        internal string TransferId { get; set; }

        /// <summary>
        /// Gets the transfer progress for a particular segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment to retrieve information for</param>
        /// <returns></returns>
        public SegmentTransferProgress GetSegmentProgress(int segmentNumber)
        {
            return _segmentProgress[segmentNumber];
        }

        /// <summary>
        /// Updates the progress for the given segment
        /// </summary>
        /// <param name="segmentProgress">The segment progress.</param>
        internal void SetSegmentProgress(SegmentTransferProgress segmentProgress)
        {
            lock (_segmentProgress)
            {
                var previousProgress = _segmentProgress[segmentProgress.SegmentNumber];

                //calculate how many additional bytes we have transferred so far
                //the caveat here is that if a segment failed, we need to report it as 0 bytes transferred (even though we did upload something; upon resume, we will reupload from scratch)
                long deltaLength = segmentProgress.IsFailed ? 0 : segmentProgress.TransferredByteCount;
                deltaLength -= previousProgress.IsFailed ? 0 : previousProgress.TransferredByteCount;

                this.TransferredByteCount += deltaLength;

                _segmentProgress[segmentProgress.SegmentNumber] = segmentProgress;

                if(_progressTracker != null)
                {
                    try
                    {
                        _progressTracker.Report(this);
                    }
                    catch
                    {
                        // don't break the transfer if the progress tracker threw one our way
                    }
                }
            }
        }

        #endregion

    }
}
