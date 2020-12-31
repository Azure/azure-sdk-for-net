// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents a downloader for a single segment of a larger file.
    /// </summary>
    internal class SingleSegmentDownloader
    {

        #region Private

        internal const decimal BufferLength = 32 * 1024 * 1024; // 32MB
        private const int MaximumBackoffWaitSeconds = 32;
        internal const int MaxBufferDownloadAttemptCount = 8;

        private readonly IFrontEndAdapter _frontEnd;
        private readonly IProgress<SegmentTransferProgress> _progressTracker;
        private readonly CancellationToken _token;
        private TransferSegmentMetadata _segmentMetadata;
        private TransferMetadata _metadata;
        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new downloader for a single segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment.</param>
        /// <param name="downloadMetadata">The metadata for the entire download.</param>
        /// <param name="frontEnd">A pointer to the front end.</param>
        /// <param name="progressTracker">(Optional) A tracker to report progress on this segment.</param>
        public SingleSegmentDownloader(int segmentNumber, TransferMetadata downloadMetadata, IFrontEndAdapter frontEnd, IProgress<SegmentTransferProgress> progressTracker = null) :
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
        public SingleSegmentDownloader(int segmentNumber, TransferMetadata downloadMetadata, IFrontEndAdapter frontEnd, CancellationToken token, IProgress<SegmentTransferProgress> progressTracker = null)
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
            if (_token.IsCancellationRequested)
            {
                _token.ThrowIfCancellationRequested();
            }

            // download the data
            //any exceptions are (re)thrown to be handled by the caller; we do not handle retries or other recovery techniques here
            // NOTE: We don't validate the download contents for each individual segment because all segments are being downloaded,
            // in parallel, into the same stream. We cannot confirm the size of the data downloaded here. Instead we do it once at the end.
            DownloadSegmentContents();
        }

        /// <summary>
        /// Verifies the downloaded stream.
        /// </summary>
        /// <exception cref="TransferFailedException"></exception>
        internal void VerifyDownloadedStream()
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
                catch (Exception e)
                {
                    _token.ThrowIfCancellationRequested();
                    if (retryCount >= MaxBufferDownloadAttemptCount)
                    {
                        TracingHelper.LogError(e);
                        
                        throw e;
                    }

                    var waitTime = WaitForRetry(retryCount, this.UseBackOffRetryStrategy, _token);
                    TracingHelper.LogInfo("VerifyDownloadedStream: GetStreamLength at path:{0} failed on try: {1} with exception: {2}. Wait time in ms before retry: {3}",
                        _segmentMetadata.Path,
                        retryCount,
                        e,
                        waitTime);
                    
                }
            }

            if (_segmentMetadata.Length != remoteLength)
            {
                var ex = new TransferFailedException(string.Format("Post-download stream verification failed: target stream has a length of {0}, expected {1}", remoteLength, _segmentMetadata.Length));
                TracingHelper.LogError(ex);

                throw ex;
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

            // for multi-segment files we append "inprogress" to indicate that the file is not yet ready for use. 
            // This also protects the user from unintentionally using the file after a failed download.
            var streamName = _metadata.SegmentCount > 1 ? string.Format("{0}.inprogress", _metadata.TargetStreamPath) : _metadata.TargetStreamPath;
            using (var outputStream = new FileStream(streamName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                outputStream.Seek(curOffset, SeekOrigin.Begin);
                for (int i = 0; i < numRequests; i++)
                {
                    _token.ThrowIfCancellationRequested();
                    int attemptCount = 0;
                    int partialDataAttempts = 0;
                    bool downloadCompleted = false;
                    long dataReceived = 0;
                    bool modifyLengthAndOffset = false;
                    while (!downloadCompleted && attemptCount < MaxBufferDownloadAttemptCount)
                    {
                        _token.ThrowIfCancellationRequested();
                        try
                        {
                            long lengthToDownload = (long)BufferLength;

                            // in the case where we got less than the expected amount of data,
                            // only download the rest of the data from the previous request
                            // instead of a new full buffer.
                            if (modifyLengthAndOffset)
                            {
                                lengthToDownload -= dataReceived;
                            }

                            // test to make sure that the remaining length is larger than the max size, 
                            // otherwise just download the remaining length.
                            if (lengthRemaining - lengthToDownload < 0)
                            {
                                lengthToDownload = lengthRemaining;
                            }

                            using (var readStream = _frontEnd.ReadStream(_metadata.InputFilePath, curOffset, lengthToDownload, _metadata.IsDownload))
                            {
                                readStream.CopyTo(outputStream, (int)lengthToDownload);
                            }

                            var lengthReturned = outputStream.Position - curOffset;
                            
                            // if we got more data than we asked for something went wrong and we should retry, since we can't trust the extra data
                            if(lengthReturned > lengthToDownload)
                            {
                                var ex = new TransferFailedException(string.Format("{4}: Did not download the expected amount of data in the request. Expected: {0}. Actual: {1}. From offset: {2} in remote file: {3}", lengthToDownload, outputStream.Position - curOffset, curOffset, _metadata.InputFilePath, DateTime.Now.ToString()));
                                TracingHelper.LogError(ex);

                                throw ex;
                            }

                            // we need to validate how many bytes have actually been copied to the read stream
                            if (lengthReturned < lengthToDownload)
                            {
                                partialDataAttempts++;
                                lengthRemaining -= lengthReturned;
                                curOffset += lengthReturned;
                                localOffset += lengthReturned;
                                modifyLengthAndOffset = true;
                                dataReceived += lengthReturned;
                                ReportProgress(localOffset, false);

                                // we will wait before the next iteration, since something went wrong and we did not receive enough data.
                                // this could be a throttling issue or an issue with the service itself. Either way, waiting should help
                                // reduce the liklihood of additional failures.
                                if(partialDataAttempts >= MaxBufferDownloadAttemptCount)
                                {
                                    var ex = new TransferFailedException(string.Format("Failed to retrieve the requested data after {0} attempts for file {1}. This usually indicates repeated server-side throttling due to exceeding account bandwidth.", MaxBufferDownloadAttemptCount, _segmentMetadata.Path));
                                    TracingHelper.LogError(ex);

                                    throw ex;
                                }

                                var waitTime = WaitForRetry(partialDataAttempts, this.UseBackOffRetryStrategy, _token);
                                TracingHelper.LogInfo("DownloadSegmentContents: ReadStream at path:{0} returned: {1} bytes. Expected: {2} bytes. Attempt: {3}. Wait time in ms before retry: {4}",
                                    _metadata.InputFilePath,
                                    lengthReturned,
                                    lengthToDownload,
                                    partialDataAttempts,
                                    waitTime);
                            }
                            else
                            {
                                downloadCompleted = true;
                                lengthRemaining -= lengthToDownload;
                                curOffset += lengthToDownload;
                                localOffset += lengthToDownload;
                                ReportProgress(localOffset, false);
                            }
                        }
                        catch (Exception ex)
                        {
                            // update counts and reset for internal attempts
                            attemptCount++;
                            partialDataAttempts = 0;

                            //if we tried more than the number of times we were allowed to, give up and throw the exception
                            if (attemptCount >= MaxBufferDownloadAttemptCount)
                            {
                                ReportProgress(localOffset, true);
                                TracingHelper.LogError(ex);

                                throw ex;
                            }
                            else
                            {
                                var waitTime = WaitForRetry(attemptCount, this.UseBackOffRetryStrategy, _token);
                                TracingHelper.LogInfo("DownloadSegmentContents: ReadStream at path:{0} failed on try: {1} with exception: {2}. Wait time in ms before retry: {3}",
                                    _metadata.InputFilePath,
                                    attemptCount,
                                    ex,
                                    waitTime);

                                // forcibly put the stream back to where it should be based on where we think we are in the download.
                                outputStream.Seek(curOffset, SeekOrigin.Begin);
                            }
                        }
                    }
                }

                // full validation of the segment.
                if(outputStream.Position - _segmentMetadata.Offset != _segmentMetadata.Length)
                {
                    var ex = new TransferFailedException(string.Format("Post-download stream segment verification failed for file {2}: target stream has a length of {0}, expected {1}. This usually indicates repeated server-side throttling due to exceeding account bandwidth.", outputStream.Position - _segmentMetadata.Offset, _segmentMetadata.Length, _segmentMetadata.Path));
                    TracingHelper.LogError(ex);

                    throw ex;
                }
            }
        }

        /// <summary>
        /// Waits for retry.
        /// </summary>
        /// <param name="attemptCount">The attempt count.</param>
        internal static int WaitForRetry(int attemptCount, bool useBackOffRetryStrategy, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (!useBackOffRetryStrategy)
            {
                //no need to wait
                return -1;
            }

            int intervalMs = Math.Min(MaximumBackoffWaitSeconds, (int)Math.Pow(2, attemptCount)) * 1000;

            // add up to 10% to the sleep to allow for randomness in the retry so that thread contention is unlikely
            var randomMS = new Random();
            intervalMs += randomMS.Next((int)Math.Ceiling(intervalMs * .1));
            Thread.Sleep(TimeSpan.FromMilliseconds(intervalMs));
            return intervalMs;
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
                _progressTracker.Report(new SegmentTransferProgress(_segmentMetadata.SegmentNumber, _segmentMetadata.Length, downloadedByteCount, isFailed));
            }
            catch { }// don't break the download if the progress tracker threw one our way
        }

        #endregion
    }
}
