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
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents a downloader for a single segment of a larger file.
    /// </summary>
    internal class SingleSegmentDownloader
    {

        #region Private

        internal const decimal BufferLength = 16 * 1024 * 1024; // 16MB
        private const int MaximumBackoffWaitSeconds = 32;
        internal const int MaxBufferDownloadAttemptCount = 4;

        private readonly IFrontEndAdapter _frontEnd;
        private readonly IProgress<SegmentUploadProgress> _progressTracker;
        private readonly CancellationToken _token;
        private UploadSegmentMetadata _segmentMetadata;
        private UploadMetadata _metadata;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new downloader for a single segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment.</param>
        /// <param name="downloadMetadata">The metadata for the entire download.</param>
        /// <param name="frontEnd">A pointer to the front end.</param>
        /// <param name="progressTracker">(Optional) A tracker to report progress on this segment.</param>
        public SingleSegmentDownloader(int segmentNumber, UploadMetadata downloadMetadata, IFrontEndAdapter frontEnd, IProgress<SegmentUploadProgress> progressTracker = null) :
            this(segmentNumber, downloadMetadata, frontEnd, CancellationToken.None, progressTracker)
        {
        }

        /// <summary>
        /// Creates a new downloader for a single segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment.</param>
        /// <param name="downloadMetadata">The metadata for the entire download.</param>
        /// <param name="frontEnd">A pointer to the front end.</param>
        /// <param name="token">The cancellation token to use</param>
        /// <param name="progressTracker">(Optional) A tracker to report progress on this segment.</param>
        public SingleSegmentDownloader(int segmentNumber, UploadMetadata downloadMetadata, IFrontEndAdapter frontEnd, CancellationToken token, IProgress<SegmentUploadProgress> progressTracker = null)
        {
            _metadata = downloadMetadata;
            _segmentMetadata = downloadMetadata.Segments[segmentNumber];

            _frontEnd = frontEnd;
            _progressTracker = progressTracker;
            _token = token;
            this.UseBackOffRetryStrategy = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to use a back-off (exponenential) in case of individual block failures.
        /// If set to 'false' every retry is handled immediately; otherwise an amount of time is waited between retries, as a function of power of 2.
        /// </summary>
        internal bool UseBackOffRetryStrategy { get; set; }

        #endregion

        #region Download Operations

        /// <summary>
        /// Downloads the portion of the InputFilePath to the given TargetStreamPath, starting at the given StartOffset.
        /// The segment is further divided into equally-sized blocks which are downloaded in sequence.
        /// Each such block is attempted a certain number of times; if after that it still cannot be downloaded, the entire segment is aborted (in which case no cleanup is performed on the server).
        /// </summary>
        /// <returns></returns>
        public void Download()
        {
            if (!_frontEnd.StreamExists(_metadata.InputFilePath, !_metadata.IsDownload))
            {
                throw new FileNotFoundException("Unable to locate input file", _metadata.InputFilePath);
            }

            if (_token.IsCancellationRequested)
            {
                _token.ThrowIfCancellationRequested();
            }

            //open a file stream (truncate it if it already exists) for the target segment
            // we always truncate here because overwrite validation should have already been done.
            // always create the directory as well
            Directory.CreateDirectory(Path.GetDirectoryName(_segmentMetadata.Path));
            
            // download the data
            DownloadSegmentContents();

            VerifyDownloadedStream();
            //any exceptions are (re)thrown to be handled by the caller; we do not handle retries or other recovery techniques here
        }

        /// <summary>
        /// Verifies the downloaded stream.
        /// </summary>
        /// <exception cref="UploadFailedException"></exception>
        private void VerifyDownloadedStream()
        {
            //verify that the remote stream has the length we expected.
            var retryCount = 0;
            long remoteLength = -1;
            while (retryCount < MaxBufferDownloadAttemptCount)
            {
                _token.ThrowIfCancellationRequested();
                retryCount++;
                try
                {
                    remoteLength = _frontEnd.GetStreamLength(_segmentMetadata.Path, _metadata.IsDownload);
                    break;
                }
                catch (Exception)
                {
                    _token.ThrowIfCancellationRequested();
                    if (retryCount >= MaxBufferDownloadAttemptCount)
                    {
                        throw;
                    }

                    WaitForRetry(retryCount, this.UseBackOffRetryStrategy, _token);
                }
            }

            if (_segmentMetadata.Length != remoteLength)
            {
                throw new UploadFailedException(string.Format("Post-download stream verification failed: target stream has a length of {0}, expected {1}", remoteLength, _segmentMetadata.Length));
            }
        }

        /// <summary>
        /// Downloads the segment contents.
        /// </summary>
        private void DownloadSegmentContents()
        {
            // set the current offset in the stream we are reading to the offset
            // that this segment starts at.
            long curOffset = _segmentMetadata.Offset;

            // set the offset of the local file that we are creating to the beginning of the local stream.
            // this value will be used to ensure that we are always reporting the right progress and that,
            // in the event of faiure, we reset the local stream to the proper location.
            long localOffset = 0;

            // determine the number of requests made based on length of file divded by 32MB max size requests
            var numRequests = Math.Ceiling(_segmentMetadata.Length / BufferLength);
            // set the length remaining to ensure that only the exact number of bytes is ultimately downloaded
            // for this segment.
            var lengthRemaining = _segmentMetadata.Length;
            using (var outputStream = new FileStream(_segmentMetadata.Path, FileMode.Create))
            {
                for (int i = 0; i < numRequests; i++)
                {
                    _token.ThrowIfCancellationRequested();
                    int attemptCount = 0;
                    bool downloadCompleted = false;
                    while (!downloadCompleted && attemptCount < MaxBufferDownloadAttemptCount)
                    {
                        _token.ThrowIfCancellationRequested();
                        attemptCount++;
                        try
                        {
                            // test to make sure that the remaining length is larger than the max size, otherwise just download the remaining length
                            long lengthToDownload = (long)BufferLength;
                            if (lengthRemaining - lengthToDownload < 0)
                            {
                                lengthToDownload = lengthRemaining;
                            }

                            using (var readStream = _frontEnd.ReadStream(_metadata.InputFilePath, curOffset, lengthToDownload, _metadata.IsDownload))
                            {
                                readStream.CopyTo(outputStream);
                            }

                            downloadCompleted = true;
                            lengthRemaining -= lengthToDownload;
                            curOffset += lengthToDownload;
                            localOffset += lengthToDownload;
                            ReportProgress(localOffset, false);
                        }
                        catch (Exception ex)
                        {
                            //if we tried more than the number of times we were allowed to, give up and throw the exception
                            if (attemptCount >= MaxBufferDownloadAttemptCount)
                            {
                                ReportProgress(localOffset, true);
                                throw ex;
                            }
                            else
                            {
                                WaitForRetry(attemptCount, this.UseBackOffRetryStrategy, _token);
                                
                                // forcibly put the stream back to where it should be based on where we think we are in the download.
                                outputStream.Seek(localOffset, SeekOrigin.Begin); 
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Waits for retry.
        /// </summary>
        /// <param name="attemptCount">The attempt count.</param>
        internal static void WaitForRetry(int attemptCount, bool useBackOffRetryStrategy, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (!useBackOffRetryStrategy)
            {
                //no need to wait
                return;
            }

            int intervalSeconds = Math.Max(MaximumBackoffWaitSeconds, (int)Math.Pow(2, attemptCount));
            Thread.Sleep(TimeSpan.FromSeconds(intervalSeconds));
        }

        /// <summary>
        /// Reports the progress.
        /// </summary>
        /// <param name="downloadedByteCount">The downloaded byte count.</param>
        /// <param name="isFailed">if set to <c>true</c> [is failed].</param>
        private void ReportProgress(long downloadedByteCount, bool isFailed)
        {
            if (_progressTracker == null)
            {
                return;
            }

            try
            {
                _progressTracker.Report(new SegmentUploadProgress(_segmentMetadata.SegmentNumber, _segmentMetadata.Length, downloadedByteCount, isFailed));
            }
            catch { }// don't break the download if the progress tracker threw one our way
        }

        #endregion
    }
}
