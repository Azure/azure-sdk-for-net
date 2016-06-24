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
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Downloads a local file in parallel by splitting it into several segments, according to the given metadata.
    /// </summary>
    internal class MultipleSegmentDownloader
    {

        #region Private

        internal const int MaxDownloadAttemptCount = 4;
        private readonly UploadMetadata _metadata;
        private readonly IFrontEndAdapter _frontEnd;
        private readonly int _maxThreadCount;
        private readonly IProgress<SegmentUploadProgress> _progressTracker;
        private readonly CancellationToken _token;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new MultipleSegmentDownloader.
        /// </summary>
        /// <param name="downloadMetadata">The metadata that keeps track of the file download.</param>
        /// <param name="maxThreadCount">The maximum number of threads to use. Note that in some cases, this number may not be reached.</param>
        /// <param name="frontEnd">A pointer to the Front End interface to perform the download to.</param>
        /// <param name="progressTracker">(Optional)A tracker that reports progress on each segment.</param>
        public MultipleSegmentDownloader(UploadMetadata downloadMetadata, int maxThreadCount, IFrontEndAdapter frontEnd, IProgress<SegmentUploadProgress> progressTracker = null) :
            this(downloadMetadata, maxThreadCount, frontEnd, CancellationToken.None, progressTracker)
        {
        }

        /// <summary>
        /// Creates a new MultipleSegmentDownloader.
        /// </summary>
        /// <param name="downloadMetadata">The metadata that keeps track of the file download.</param>
        /// <param name="maxThreadCount">The maximum number of threads to use. Note that in some cases, this number may not be reached.</param>
        /// <param name="frontEnd">A pointer to the Front End interface to perform the download to.</param>
        /// <param name="token">The cancellation token to use.</param>
        /// <param name="progressTracker">(Optional)A tracker that reports progress on each segment.</param>
        public MultipleSegmentDownloader(UploadMetadata downloadMetadata, int maxThreadCount, IFrontEndAdapter frontEnd, CancellationToken token, IProgress<SegmentUploadProgress> progressTracker = null)
        {
            _metadata = downloadMetadata;
            _maxThreadCount = maxThreadCount;
            _frontEnd = frontEnd;
            _progressTracker = progressTracker;
            _token = token;

            this.UseSegmentBlockBackOffRetryStrategy = true;
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to use a back-off (exponenential) in case of individual block failures.
        /// The MultipleSegmentDownloader does not use this directly; it passes it on to SingleSegmentDownloader.
        /// </summary>
        internal bool UseSegmentBlockBackOffRetryStrategy { get; set; }

        #endregion

        #region Download logic

        /// <summary>
        /// Executes the download of the segments in the file that were not already downloaded (i.e., those that are in a 'Pending' state).
        /// </summary>
        /// <returns></returns>
        public void Download()
        {
            var pendingSegments = GetPendingSegmentsToDownload(_metadata);
            var exceptions = new ConcurrentQueue<Exception>();

            int threadCount = Math.Min(pendingSegments.Count, _maxThreadCount);
            var threads = new List<Thread>(threadCount);

            //start a bunch of new threads that pull from the pendingSegments and then wait for them to finish
            for (int i = 0; i < threadCount; i++)
            {
                var t = new Thread(() => { ProcessPendingSegments(pendingSegments, exceptions); });
                t.Start();
                threads.Add(t);
            }

            foreach (var t in threads)
            {
                t.Join();
            }


            // aggregate any exceptions and throw them back at our caller
            if (exceptions.Count > 0 && !_token.IsCancellationRequested)
            {
                throw new AggregateException("One or more segments could not be downloaded. Review the Download Metadata to determine which segments failed", exceptions);
            }

            // Finally, throw the cancellation exception if the task was actually cancelled.
            _token.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// Processes the pending segments.
        /// </summary>
        /// <param name="pendingSegments">The pending segments.</param>
        /// <param name="exceptions">The exceptions.</param>
        private void ProcessPendingSegments(Queue<SegmentQueueItem> pendingSegments, ConcurrentQueue<Exception> exceptions)
        {
            while (pendingSegments.Count > 0)
            {
                if (_token.IsCancellationRequested)
                {
                    break;
                }

                //get the next item to process
                SegmentQueueItem toProcess;
                lock (pendingSegments)
                {
                    if (pendingSegments.Count == 0)
                    {
                        break;
                    }
                    toProcess = pendingSegments.Dequeue();
                }

                try
                {
                    //execute it
                    DownloadSegment(toProcess.SegmentNumber, _metadata);
                }
                catch(Exception ex)
                {
                    if (toProcess.AttemptCount + 1 < MaxDownloadAttemptCount)
                    {
                        //re-enqueue at the end, but with an incremented attempt count
                        lock (pendingSegments)
                        {
                            pendingSegments.Enqueue(new SegmentQueueItem(toProcess.SegmentNumber, toProcess.AttemptCount + 1));
                        }
                    }
                    else
                    {
                        //keep track of the last exception for each segment and report it back
                        lock (exceptions)
                        {
                            exceptions.Enqueue(ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Downloads the segment.
        /// </summary>
        /// <param name="segmentNumber">The segment number.</param>
        /// <param name="metadata">The metadata.</param>
        private void DownloadSegment(int segmentNumber, UploadMetadata metadata)
        {
            //mark the segment as 'InProgress' in the metadata
            UpdateSegmentMetadataStatus(metadata, segmentNumber, SegmentUploadStatus.InProgress);

            var segmentDownloader = new SingleSegmentDownloader(segmentNumber, metadata, _frontEnd, _token, _progressTracker);
            segmentDownloader.UseBackOffRetryStrategy = this.UseSegmentBlockBackOffRetryStrategy;

            try
            {
                segmentDownloader.Download();
                
                //if we reach this point, the download was successful; mark it as such 
                UpdateSegmentMetadataStatus(metadata, segmentNumber, SegmentUploadStatus.Complete);
            }
            catch
            {
                //something horrible happened, mark the segment as failed and throw the original exception (the caller will handle it)
                UpdateSegmentMetadataStatus(metadata, segmentNumber, SegmentUploadStatus.Failed);
                throw;
            }
        }

        /// <summary>
        /// Gets the pending segments to download.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        private static Queue<SegmentQueueItem> GetPendingSegmentsToDownload(UploadMetadata metadata)
        {
            var result = new Queue<SegmentQueueItem>();
            foreach (var segment in metadata.Segments.Where(segment => segment.Status == SegmentUploadStatus.Pending))
            {
                result.Enqueue(new SegmentQueueItem(segment.SegmentNumber, 0));
            }
            return result;
        }

        /// <summary>
        /// Updates the segment metadata status.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="segmentNumber">The segment number.</param>
        /// <param name="newStatus">The new status.</param>
        private static void UpdateSegmentMetadataStatus(UploadMetadata metadata, int segmentNumber, SegmentUploadStatus newStatus)
        {
            metadata.Segments[segmentNumber].Status = newStatus;
            try
            {
                metadata.Save();
            }
            catch { } //no need to crash the program if were unable to save the metadata; it is what's in memory that's important
        }

        #endregion

        #region SegmentQueueItem

        /// <summary>
        /// Represents a tuple that pairs a segment number with the number of times it was attempted for download
        /// </summary>
        [DebuggerDisplay("Segment = {SegmentNumber}, Attempts = {AttemptCount}")]
        private class SegmentQueueItem
        {
            public SegmentQueueItem(int segmentNumber, int attemptCount)
            {
                this.SegmentNumber = segmentNumber;
                this.AttemptCount = attemptCount;
            }

            public int SegmentNumber { get; private set; }

            public int AttemptCount { get; private set; }
        }

        #endregion

    }
}
