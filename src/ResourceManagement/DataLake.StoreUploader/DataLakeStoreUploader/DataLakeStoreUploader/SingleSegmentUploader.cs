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
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents an uploader for a single segment of a larger file.
    /// </summary>
    internal class SingleSegmentUploader
    {

        #region Private

        internal const int BufferLength = 4 * 1024 * 1024;

        // 4MB is the maximum length of a single extent. So if one record is longer than this,
        // then we will fast fail, since that record will cross extent boundaries.
        internal const int MaxRecordLength = 4 * 1024 * 1024; 
        private const int MaximumBackoffWaitSeconds = 32;
        internal const int MaxBufferUploadAttemptCount = 4;

        private readonly IFrontEndAdapter _frontEnd;
        private readonly IProgress<SegmentUploadProgress> _progressTracker;
        private readonly CancellationToken _token;
        private UploadSegmentMetadata _segmentMetadata;
        private UploadMetadata _metadata;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new uploader for a single segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment.</param>
        /// <param name="uploadMetadata">The metadata for the entire upload.</param>
        /// <param name="frontEnd">A pointer to the front end.</param>
        /// <param name="progressTracker">(Optional) A tracker to report progress on this segment.</param>
        public SingleSegmentUploader(int segmentNumber, UploadMetadata uploadMetadata, IFrontEndAdapter frontEnd, IProgress<SegmentUploadProgress> progressTracker = null) :
            this(segmentNumber, uploadMetadata, frontEnd, CancellationToken.None, progressTracker)
        {
        }

        /// <summary>
        /// Creates a new uploader for a single segment.
        /// </summary>
        /// <param name="segmentNumber">The sequence number of the segment.</param>
        /// <param name="uploadMetadata">The metadata for the entire upload.</param>
        /// <param name="frontEnd">A pointer to the front end.</param>
        /// <param name="token">The cancellation token to use</param>
        /// <param name="progressTracker">(Optional) A tracker to report progress on this segment.</param>
        public SingleSegmentUploader(int segmentNumber, UploadMetadata uploadMetadata, IFrontEndAdapter frontEnd, CancellationToken token, IProgress<SegmentUploadProgress> progressTracker = null)
        {
            _metadata = uploadMetadata;
            _segmentMetadata = uploadMetadata.Segments[segmentNumber];

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

        #region Upload Operations

        /// <summary>
        /// Uploads the portion of the InputFilePath to the given TargetStreamPath, starting at the given StartOffset.
        /// The segment is further divided into equally-sized blocks which are uploaded in sequence.
        /// Each such block is attempted a certain number of times; if after that it still cannot be uploaded, the entire segment is aborted (in which case no cleanup is performed on the server).
        /// </summary>
        /// <returns></returns>
        public void Upload()
        {
            if (!File.Exists(_metadata.InputFilePath))
            {
                throw new FileNotFoundException("Unable to locate input file", _metadata.InputFilePath);
            }

            if (_token.IsCancellationRequested)
            {
                _token.ThrowIfCancellationRequested();
            }

            //open up a reader from the input file, seek to the appropriate offset
            using (var inputStream = OpenInputStream())
            {
                long endPosition = _segmentMetadata.Offset + _segmentMetadata.Length;
                if (endPosition > inputStream.Length)
                {
                    throw new InvalidOperationException("StartOffset+UploadLength is beyond the end of the input file");
                }

                UploadSegmentContents(inputStream, endPosition);

                VerifyUploadedStream();
                //any exceptions are (re)thrown to be handled by the caller; we do not handle retries or other recovery techniques here
            }
        }

        /// <summary>
        /// Verifies the uploaded stream.
        /// </summary>
        /// <exception cref="UploadFailedException"></exception>
        private void VerifyUploadedStream()
        {
            //verify that the remote stream has the length we expected.
            var retryCount = 0;
            long remoteLength = -1;
            while (retryCount < MaxBufferUploadAttemptCount)
            {
                _token.ThrowIfCancellationRequested();
                retryCount++;
                try
                {
                    remoteLength = _frontEnd.GetStreamLength(_segmentMetadata.Path);
                    break;
                }
                catch (Exception)
                {
                    _token.ThrowIfCancellationRequested();
                    if (retryCount >= MaxBufferUploadAttemptCount)
                    {
                        throw;
                    }

                    WaitForRetry(retryCount, this.UseBackOffRetryStrategy, _token);
                }
            }

            if (_segmentMetadata.Length != remoteLength)
            {
                throw new UploadFailedException(string.Format("Post-upload stream verification failed: target stream has a length of {0}, expected {1}", remoteLength, _segmentMetadata.Length));
            }
        }

        /// <summary>
        /// Uploads the segment contents.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="endPosition">The end position.</param>
        private void UploadSegmentContents(Stream inputStream, long endPosition)
        {
            long bytesCopiedSoFar = 0; // we start off with a fresh stream
            
            byte[] buffer = new byte[BufferLength];
            int residualBufferLength = 0; //the number of bytes that remained in the buffer from the last upload (bytes which were not uploaded)

            while (inputStream.Position < endPosition)
            {
                _token.ThrowIfCancellationRequested();

                //read a block of data, and keep track of how many bytes are actually read
                int bytesRead = ReadIntoBuffer(inputStream, buffer, residualBufferLength, endPosition);
                int bufferDataLength = residualBufferLength + bytesRead;

                //determine the cutoff offset for upload - everything before will be uploaded, everything after is residual; (the position of the last record in this buffer)
                int uploadCutoff = bufferDataLength;
                if (!_metadata.IsBinary)
                {
                    uploadCutoff = DetermineUploadCutoffForTextFile(buffer, bufferDataLength, inputStream);
                }

                bytesCopiedSoFar = UploadBuffer(buffer, uploadCutoff, bytesCopiedSoFar);

                residualBufferLength = bufferDataLength - uploadCutoff;
                if (residualBufferLength > 0)
                {
                    //move the remainder of the buffer to the front
                    Array.Copy(buffer, uploadCutoff, buffer, 0, residualBufferLength);
                }
            }
            
            //make sure we don't leave anything behind
            if (residualBufferLength > 0)
            {
                UploadBuffer(buffer, residualBufferLength, bytesCopiedSoFar);
            }
        }

        /// <summary>
        /// Determines the upload cutoff for text file.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bufferDataLength">Length of the buffer data.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <returns></returns>
        /// <exception cref="UploadFailedException"></exception>
        private int DetermineUploadCutoffForTextFile(byte[] buffer, int bufferDataLength, Stream inputStream)
        {
            //NOTE: we return an offset, but everywhere else below we treat it as a byte count; in order for that to work, we need to add 1 to the result of FindNewLine.
            int uploadCutoff = StringExtensions.FindNewline(buffer, bufferDataLength - 1, bufferDataLength, true) + 1;
            if (uploadCutoff <= 0 && (_metadata.SegmentCount > 1 || bufferDataLength >= MaxRecordLength))
            {
                throw new UploadFailedException(string.Format("Found a record that exceeds the maximum allowed record length around offset {0}", inputStream.Position));
            }

            //a corner case here is when the newline is 2 chars long, and the first of those lands on the last byte of the buffer. If so, let's try to find another 
            //newline inside the buffer, because we might be splitting this wrongly.
            if (uploadCutoff == buffer.Length && buffer[buffer.Length - 1] == (byte)'\r')
            {
                int newCutoff = StringExtensions.FindNewline(buffer, bufferDataLength - 2, bufferDataLength - 1, true) + 1;
                if (newCutoff > 0)
                {
                    uploadCutoff = newCutoff;
                }
            }

            return uploadCutoff;
        }

        /// <summary>
        /// Uploads the buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bytesToCopy">The bytes to copy.</param>
        /// <param name="targetStreamOffset">The target stream offset.</param>
        /// <returns></returns>
        private long UploadBuffer(byte[] buffer, int bytesToCopy, long targetStreamOffset)
        {
            //append it to the remote stream
            int attemptCount = 0;
            bool uploadCompleted = false;
            while (!uploadCompleted && attemptCount < MaxBufferUploadAttemptCount)
            {
                _token.ThrowIfCancellationRequested();
                attemptCount++;
                try
                {
                    if (targetStreamOffset == 0)
                    {
                        _frontEnd.CreateStream(_segmentMetadata.Path, true, buffer, bytesToCopy);
                    }
                    else
                    {
                        _frontEnd.AppendToStream(_segmentMetadata.Path, buffer, targetStreamOffset, bytesToCopy);
                        
                    }
                    
                    uploadCompleted = true;
                    targetStreamOffset += bytesToCopy;
                    ReportProgress(targetStreamOffset, false);
                }
                catch
                {
                    //if we tried more than the number of times we were allowed to, give up and throw the exception
                    if (attemptCount >= MaxBufferUploadAttemptCount)
                    {
                        ReportProgress(targetStreamOffset, true);
                        throw;
                    }
                    else
                    {
                        WaitForRetry(attemptCount, this.UseBackOffRetryStrategy, _token);
                    }
                }
            }

            return targetStreamOffset;
        }

        /// <summary>
        /// Reads the into buffer.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bufferOffset">The buffer offset.</param>
        /// <param name="streamEndPosition">The stream end position.</param>
        /// <returns></returns>
        private int ReadIntoBuffer(Stream inputStream, byte[] buffer, int bufferOffset, long streamEndPosition)
        {
            //read a block of data
            int bytesToRead = buffer.Length - bufferOffset;
            if (bytesToRead > streamEndPosition - inputStream.Position)
            {
                //last read may be smaller than previous reads; readjust # of bytes to read accordingly
                bytesToRead = (int)(streamEndPosition - inputStream.Position);
            }

            int remainingBytes = bytesToRead;

            while (remainingBytes > 0)
            {
                //Stream.Read may not read all the bytes we requested, so we need to retry until we filled up the entire buffer
                _token.ThrowIfCancellationRequested();
                int bytesRead = inputStream.Read(buffer, bufferOffset, remainingBytes);
                bufferOffset += bytesRead;
                remainingBytes = bytesToRead - bufferOffset;
            }

            return bytesToRead;
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
        /// Opens the input stream.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">StartOffset is beyond the end of the input file;StartOffset</exception>
        private Stream OpenInputStream()
        {
            var stream = new FileStream(_metadata.InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (_segmentMetadata.Offset >= stream.Length)
            {
                throw new ArgumentException("StartOffset is beyond the end of the input file", "StartOffset");
            }

            stream.Seek(_segmentMetadata.Offset, SeekOrigin.Begin);
            return stream;
        }

        /// <summary>
        /// Reports the progress.
        /// </summary>
        /// <param name="uploadedByteCount">The uploaded byte count.</param>
        /// <param name="isFailed">if set to <c>true</c> [is failed].</param>
        private void ReportProgress(long uploadedByteCount, bool isFailed)
        {
            if (_progressTracker == null)
            {
                return;
            }

            try
            {
                _progressTracker.Report(new SegmentUploadProgress(_segmentMetadata.SegmentNumber, _segmentMetadata.Length, uploadedByteCount, isFailed));
            }
            catch { }// don't break the upload if the progress tracker threw one our way
        }

        #endregion
    }
}
