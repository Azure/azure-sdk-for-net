//-----------------------------------------------------------------------
// <copyright file="BlobReadStream.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the BlobReadStream class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// This class represents a seekable, read-only stream on a blob.
    /// </summary>
    internal class BlobReadStream : BlobStream
    {
        /// <summary>
        /// The threshold beyond which we start a new read-Ahead.
        /// </summary>
        private const double ReadAheadThreshold = 0.25;

        /// <summary>
        /// The current position with the stream.
        /// </summary>
        private long position;

        /// <summary>
        /// The number of bytes to read forward on every request.
        /// </summary>
        private long readAheadSize;

        /// <summary>
        /// The options applied to the stream.
        /// </summary>
        private BlobRequestOptions options;

        /// <summary>
        /// The access condition applied to the stream.
        /// </summary>
        private AccessCondition accessCondition;

        /// <summary>
        /// True if the AccessCondition has been changed to match a single ETag.
        /// </summary>
        private bool setEtagCondition;

        /// <summary>
        /// The list of blocks for this blob.
        /// </summary>
        private List<ListBlockItem> blockList;

        /// <summary>
        /// The already available blocks for reading. This member is the only possible point of thread contention between the user's requests and ReadAhead async work. 
        /// At any particular time, the ReadAhead thread may be adding more items into the list. The second thread will never remove/modify an existing item within the list.
        /// </summary>
        private DownloadedBlockCollection downloadedBlocksList;

        /// <summary>
        /// A handle to the parallel download of data for ReadAhead.
        /// </summary>
        private IAsyncResult readAheadResult;

        /// <summary>
        /// Initializes a new instance of the BlobReadStream class. 
        /// </summary>
        /// <param name="blob">The blob used for downloads.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">Modifiers to be applied to the blob. After first request, the ETag is always applied.</param>
        /// <param name="readAheadInBytes">The number of bytes to read ahead.</param>
        /// <param name="verifyBlocks">Controls whether block's signatures are verified.</param>
        internal BlobReadStream(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, long readAheadInBytes, bool verifyBlocks)
        {
            CommonUtils.AssertNotNull("blob", blob);
            CommonUtils.AssertNotNull("options", options);
            CommonUtils.AssertInBounds("readAheadInBytes", readAheadInBytes, 0, Protocol.Constants.MaxBlobSize);

            this.Blob = blob;
            this.IntegrityControlVerificationEnabled = verifyBlocks;
            this.options = options;
            this.accessCondition = accessCondition;
            this.ReadAheadSize = readAheadInBytes;

            this.downloadedBlocksList = new DownloadedBlockCollection();
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>Returns <c>true</c> if the stream supports reading; otherwise, <c>false</c>.</value>
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <value>Returns <c>true</c> if the stream supports seeking; otherwise, <c>false</c>.</value>
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <value>Returns <c>true</c> if the stream supports writing; otherwise, <c>false</c>.</value>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream can time out.
        /// </summary>
        /// <value>A value that determines whether the current stream can time out.</value>
        public override bool CanTimeout
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.
        /// </summary>
        /// <value>A value, in milliseconds, that determines how long the stream will attempt to read before timing out.</value>
        public override int ReadTimeout
        {
            get
            {
                return this.options.Timeout.RoundUpToMilliseconds();
            }

            set
            {
                this.options.Timeout = TimeSpan.FromMilliseconds(value);
            }
        }

        /// <summary>
        /// Gets the length of the blob. 
        /// </summary>
        /// <remarks>May need to do a roundtrip to retrieve it.</remarks>
        public override long Length
        {
            get
            {
                if (!this.LengthAvailable)
                {
                    this.RetrieveSize();
                }

                return this.Blob.Properties.Length;
            }
        }

        /// <summary>
        /// Gets or sets the position within the stream.
        /// </summary>
        public override long Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.Seek(value, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes to read ahead. 
        /// </summary>
        public override long ReadAheadSize
        {
            get
            {
                return this.readAheadSize;
            }

            set
            {
                this.readAheadSize = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the signature of each downloaded block should be verified. 
        /// </summary>
        /// <remarks>This requires having a blocklist, having blockIDs to be in the appropriate format. This causes all reads to be rounded to the nearest block.</remarks>
        public override bool IntegrityControlVerificationEnabled { get; internal set; }

        /// <summary>
        /// Gets the number of bytes that are cached locally but not yet read by user.
        /// </summary>
        internal long BufferedDataLength
        {
            get
            {
                long start, end;
                this.downloadedBlocksList.CalculateGapLength(this.position, this.readAheadSize, out start, out end);
                return start - this.position;
            }
        }

        /// <summary>
        /// Gets a value indicating whether length is available.
        /// </summary>
        private bool LengthAvailable
        {
            get
            {
                return (!string.IsNullOrEmpty(this.Blob.Properties.ETag) && (this.Blob.Properties.Length > 0)) || this.setEtagCondition;
            }
        }

        /// <summary>
        /// Setting the length of the blob is not supported.
        /// </summary>
        /// <param name="value">The desired length.</param>
        /// <exception cref="NotSupportedException">Always thrown.</exception>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Write is not supported.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Flush is not supported on read-only stream.
        /// </summary>
        public override void Flush()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Seeks to the desired position. Any seek outside of the buffered/read-ahead data will cancel read-ahead and clear the buffered data.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type System.IO.SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="ArgumentException">Thrown if offset is invalid for SeekOrigin</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    this.CheckBounds(offset);

                    this.position = offset;
                    break;
                case SeekOrigin.Current:
                    this.CheckBounds(this.position + offset);

                    this.position += offset;
                    break;
                case SeekOrigin.End:
                    this.CheckBounds(this.Length + offset);

                    this.position = this.Length + offset;
                    break;
            }

            if (this.readAheadResult != null)
            {
                if (!this.readAheadResult.IsCompleted)
                {
                    this.readAheadResult.AsyncWaitHandle.WaitOne();
                }

                this.readAheadResult = null;
            }

            // Check any blocks that are not useful anymore
            this.downloadedBlocksList.RemoveExtraBlocks(this.position, this.readAheadSize);
            return this.position;
        }

        /// <summary>
        /// Copies the specified amount of data from internal buffers to the buffer and advances the position.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values 
        ///                     between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns> The total number of bytes read into the buffer. This can be less than the number of bytes requested 
        /// if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        /// <exception cref="System.ArgumentException">The sum of offset and count is larger than the buffer length.</exception>
        /// <exception cref="System.ArgumentNullException">The buffer parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The offset or count parameters are negative.</exception>
        /// <exception cref="System.IO.IOException">An I/O error occurs.</exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return TaskImplHelper.ExecuteImpl<int>((result) => { return this.ReadImplWrapper(buffer, offset, count, result); });
        }

        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        public override int ReadByte()
        {
            return base.ReadByte();
        }

        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that represents the asynchronous read, which could still be pending.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">
        /// Attempted an asynchronous read past the end of the stream, or a disk error occurs.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// One or more of the arguments is invalid.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// Methods were called after the stream was closed.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The current Stream implementation does not support the read operation.
        /// </exception>
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<int>((result) => this.ReadImplWrapper(buffer, offset, count, result), callback, state);
        }

        /// <summary>
        /// Ends an asynchronous read operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>
        /// The number of bytes read from the stream, between zero (0) and the number of bytes you requested. 
        /// Streams return zero (0) only at the end of the stream, otherwise, they should block until at least one byte is available.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="asyncResult"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="asyncResult"/> did not originate from a <see cref="M:System.IO.Stream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)"/> method on the current stream.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        /// The stream is closed or an internal error has occurred.
        /// </exception>
        public override int EndRead(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<int>(asyncResult);
        }

        /// <summary>
        /// Wraps the Read operation to remap any exceptions into IOException.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <param name="setResult">The action to be done upon completion to return the number of bytes read.</param>
        /// <returns>A task sequence representing the operation.</returns>
        /// <exception cref="System.ArgumentException">The sum of offset and count is larger than the buffer length.</exception>
        /// <exception cref="System.ArgumentNullException">The buffer parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The offset or count parameters are negative</exception>
        /// <exception cref="System.IO.IOException">An I/O error occurs.</exception>
        private TaskSequence ReadImplWrapper(byte[] buffer, int offset, int count, Action<int> setResult)
        {
            StreamUtilities.CheckBufferArguments(buffer, offset, count);
            try
            {
                return this.ReadImpl(buffer, offset, count, setResult);
            }
            catch (System.Exception ex)
            {
                throw new IOException("Error while reading blob", ex);
            }
        }

        /// <summary>
        /// Performs the read operation.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <param name="setResult">The action to be done upon completion to return the number of bytes read.</param>
        /// <returns>A task sequence representing the operation.</returns>
        /// <remarks>
        /// If verification is on, retrieve the blocklist.
        /// If there are downloaded blocks, read from there.
        /// Otherwise, if there's an outstanding request, wait for completion and read from there.
        /// Otherwise perform a new request.
        /// </remarks>
        private TaskSequence ReadImpl(byte[] buffer, int offset, int count, Action<int> setResult)
        {
            if (this.Blob.Properties.BlobType == BlobType.Unspecified)
            {
                this.Blob.FetchAttributes(this.accessCondition, this.options);
            }

            var origCount = count;

            // If we don't have a blocklist and need it, get it.
            if (this.Blob.Properties.BlobType == BlobType.BlockBlob && this.IntegrityControlVerificationEnabled && this.blockList == null)
            {
                var blockListTask = TaskImplHelper.GetRetryableAsyncTask<IEnumerable<ListBlockItem>>(
                    (result) =>
                    {
                        return this.Blob.ToBlockBlob.GetDownloadBlockList(
                            BlockListingFilter.Committed,
                            this.accessCondition,
                            this.options,
                            result);
                    },
                    this.options.RetryPolicy);

                yield return blockListTask;

                this.blockList = blockListTask.Result.ToList();

                // Verify we got a blocklist and it's in valid state. This will disable verification if it's invalid state
                this.VerifyBlocks();
            }

            bool readComplete = false;

            // Clear any pending read-aheads
            if (this.readAheadResult != null && this.readAheadResult.IsCompleted)
            {
                this.readAheadResult = null;
            }

            // If we have any data, read existing data
            if (this.downloadedBlocksList.Any())
            {
                readComplete = this.ReadBufferedData(buffer, ref offset, ref count);
            }

            // If we didn't complete our read and have outstanding readAhead, wait on it
            if (!readComplete && this.readAheadResult != null && !this.readAheadResult.IsCompleted)
            {
                this.readAheadResult.AsyncWaitHandle.WaitOne();
                this.readAheadResult = null;

                // We now have more data, so we can do some read
                readComplete = this.ReadBufferedData(buffer, ref offset, ref count);
            }

            long gapStart, gapEnd;
            this.downloadedBlocksList.CalculateGapLength(this.position, count + this.readAheadSize, out gapStart, out gapEnd);

            // Figure out if we need to do a server request. There are two reasons:
            // * We have satisfied the read request, but the remaining data is low enough to warrant a ReadAhead
            // * We didn't satisfy any of the read request and therefore must do it now
            if (this.CalculateIfBufferTooLow(gapStart) || !readComplete)
            {
                long startReadAhead;
                long readAheadCount;
                this.CalculateReadAheadBounds(gapStart, gapEnd, count, out startReadAhead, out readAheadCount);

                var blocksLeft = startReadAhead != -1;
                var outsideBounds = this.LengthAvailable && (this.Position >= this.Length || startReadAhead >= this.Length);

                // If we didn't find any blocks, that means there's no data left.
                // If we have length, we can ensure we are within bounds. This will prevent extra round trips
                if (!blocksLeft || outsideBounds)
                {
                    setResult(origCount - count);
                    yield break;
                }

                // If we are doing an optional read-ahead, save the async result for future use
                if (readComplete)
                {
                    // We should only have a single outstanding ReadAhed
                    if (this.readAheadResult == null)
                    {
                        this.readAheadResult = TaskImplHelper.BeginImplWithRetry(
                            () =>
                            {
                                return this.ReadAheadImpl(startReadAhead, readAheadCount);
                            },
                            this.options.RetryPolicy,
                            (result) =>
                            {
                                this.EndReadAhead(result);
                            },
                            null);
                    }
                }
                else
                {
                    var task = TaskImplHelper.GetRetryableAsyncTask(() => this.ReadAheadImpl(startReadAhead, readAheadCount), this.options.RetryPolicy);

                    yield return task;

                    var scratch = task.Result;

                    // We now have data, so we read it
                    readComplete = this.ReadBufferedData(buffer, ref offset, ref count);
                }            
            }

            setResult(origCount - count);
        }

        /// <summary>
        /// Locks download to a specific ETag.
        /// </summary>
        private void LockToEtag()
        {
            // Add the ETag
            if (this.setEtagCondition == false && !string.IsNullOrEmpty(this.Blob.Properties.ETag))
            {
                this.setEtagCondition = true;

                // If we have any existing conditions, see if they failed.
                if (this.accessCondition != null)
                {
                    if (!this.accessCondition.VerifyConditionHolds(
                        this.Blob.Properties.ETag,
                        this.Blob.Properties.LastModifiedUtc))
                    {
                        throw new StorageClientException(
                            StorageErrorCode.ConditionFailed,
                            SR.ConditionNotMatchedError,
                            System.Net.HttpStatusCode.PreconditionFailed,
                            null,
                            null);
                    }
                }

                this.accessCondition = AccessCondition.GenerateIfMatchCondition(this.Blob.Properties.ETag);
            }
        }

        /// <summary>
        /// Reads the data from the service starting at the specified location. Verifies the block's signature (if required) and adds it to the buffered data.
        /// </summary>
        /// <param name="startPosition">The starting position of the read-ahead.</param>
        /// <param name="length">The number of bytes to read ahead.</param>
        /// <returns> An TaskSequence that represents the asynchronous read action. </returns>
        private TaskSequence ReadAheadImpl(long startPosition, long length)
        {
            var webResponseTask = new InvokeTaskSequenceTask<Stream>((result) => { return this.Blob.GetStreamImpl(accessCondition, options, startPosition, length, result); });
            yield return webResponseTask;

            using (var stream = webResponseTask.Result)
            {
                this.LockToEtag();

                if (this.IntegrityControlVerificationEnabled && this.Blob.Properties.BlobType == BlobType.BlockBlob)
                {
                    long blockStartPosition = 0;
                    foreach (var block in this.blockList)
                    {
                        var blockSize = block.Size;

                        // Find the starting block
                        if (blockStartPosition < startPosition)
                        {
                            blockStartPosition += blockSize;
                            continue;
                        }

                        // Start creating blocks
                        var memoryStream = new SmallBlockMemoryStream(Constants.DefaultBufferSize);
                        var md5Check = MD5.Create();
                        int totalCopied = 0, numRead = 0;
                        do
                        {
                            byte[] buffer = new byte[Constants.DefaultBufferSize];
                            var numToRead = (int)Math.Min(buffer.Length, blockSize - totalCopied);
                            var readTask = stream.ReadAsync(buffer, 0, numToRead);
                            yield return readTask;

                            numRead = readTask.Result;

                            if (numRead != 0)
                            {
                                // Verify the content
                                StreamUtilities.ComputeHash(buffer, 0, numRead, md5Check);

                                var writeTask = memoryStream.WriteAsync(buffer, 0, numRead);
                                yield return writeTask;
                                var scratch = writeTask.Result; // Materialize any exceptions
                                totalCopied += numRead;
                            }
                        }
                        while (numRead != 0 && totalCopied < blockSize);

                        // If we read something, act on it
                        if (totalCopied != 0)
                        {
                            // Verify the hash
                            string blockNameMD5Value = Utilities.ExtractMD5ValueFromBlockID(block.Name);

                            if (blockNameMD5Value != StreamUtilities.GetHashValue(md5Check))
                            {
                                throw new InvalidDataException("Blob data corrupted (integrity check failed)");
                            }

                            memoryStream.Position = 0; // Rewind the stream to allow for reading

                            this.downloadedBlocksList.Add(new DownloadedBlock(startPosition, memoryStream));

                            startPosition += blockSize;
                            blockStartPosition += blockSize;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    var memoryStream = new SmallBlockMemoryStream(Constants.DefaultBufferSize);
                    var copyTask = new InvokeTaskSequenceTask(() => { return stream.WriteTo(memoryStream); });
                    yield return copyTask;

                    var scratch = copyTask.Result; // Materialize any errors

                    memoryStream.Position = 0; // Rewind the stream to allow for reading
                    this.downloadedBlocksList.Add(new DownloadedBlock(startPosition, memoryStream));
                }
            }
        }

        /// <summary>
        /// Ends an asynchronous read-ahead operation.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <exception cref="ArgumentNullException">asyncResult is null</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        private void EndReadAhead(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Retrieves the size of the blob.
        /// </summary>
        /// <remarks>If verification is on, it will retrieve the blocklist as well</remarks>
        private void RetrieveSize()
        {
            try
            {
                // TODO: - FetchAttributes should be an async task and so should DownloadBlockList
                this.Blob.FetchAttributes(this.accessCondition, this.options);
            }
            catch (System.Exception ex)
            {
                throw new IOException("Error while retrieving size", ex);
            }
        }

        /// <summary>
        /// Verifies if the blocks are in expected format. Disables the integrity control if they are not appropriate for validation.
        /// </summary>
        private void VerifyBlocks()
        {
            this.LockToEtag();

            if (this.blockList == null || this.blockList.Count == 0)
            {
                this.IntegrityControlVerificationEnabled = false;
                return;
            }

           if (this.blockList[0].Name.Length == Constants.V2MD5blockIdExpectedLength &&
                this.blockList[0].Name.StartsWith(Constants.V2blockPrefix))
            {
                // New V2 style Block IDs
                foreach (var block in this.blockList)
                {
                    if (block.Name.Length != Constants.V2MD5blockIdExpectedLength ||
                        !block.Name.StartsWith(Constants.V2blockPrefix))
                    {
                        this.IntegrityControlVerificationEnabled = false;
                        break;
                    }
                }
            }
           else if (this.blockList[0].Name.Length == Constants.V1MD5blockIdExpectedLength && this.blockList[0].Name.StartsWith(Constants.V1BlockPrefix))
           {
               // Old 1.3 and lower style Block IDs
               foreach (var block in this.blockList)
               {
                   if (block.Name.Length != Constants.V1MD5blockIdExpectedLength || !block.Name.StartsWith(Constants.V1BlockPrefix))
                   {
                       this.IntegrityControlVerificationEnabled = false;
                       break;
                   }
               }
           }
           else
           {
               this.IntegrityControlVerificationEnabled = false;
           }
        }

        /// <summary>
        /// Calculates the ReadAhead bounds (start and count) as required by the existing data.
        /// </summary>
        /// <param name="gapStart">The desired start position.</param>
        /// <param name="gapEnd">The end of the existing gap.</param>
        /// <param name="count">The desired number of bytes.</param>
        /// <param name="startReadAhead">The start position rounded down to the nearest block start.</param>
        /// <param name="readAheadCount">The number of bytes with readAheadSize included and rounded up to the end of the nearest block.</param>
        /// <remarks>This calculates the bounds based on the blocklist, not any existing data.</remarks>
        private void CalculateReadAheadBounds(long gapStart, long gapEnd, int count, out long startReadAhead, out long readAheadCount)
        {
            // TODO: optimizing this for page blobs
            readAheadCount = startReadAhead = -1;
            var minReadCount = Math.Min(gapEnd - gapStart, count + this.readAheadSize);

            if (this.IntegrityControlVerificationEnabled && this.Blob.Properties.BlobType == BlobType.BlockBlob)
            {
                long blockStart = 0;
                foreach (var block in this.blockList)
                {
                    long blockEnd = blockStart + block.Size;

                    // If the start hasn't been set, calculate it
                    if (startReadAhead == -1)
                    {
                        if (gapStart >= blockStart
                            && gapStart < blockEnd)
                        {
                            startReadAhead = blockStart;
                            readAheadCount = blockEnd - startReadAhead;
                        }
                    }

                    // Start is set, so calculate the end
                    if (startReadAhead != -1)
                    {
                        var desiredEnd = gapStart + minReadCount;
                        if (desiredEnd >= blockStart
                            && desiredEnd < blockEnd)
                        {
                            readAheadCount = blockEnd - startReadAhead;
                            break;
                        }
                    }

                    blockStart = blockEnd;
                }
            }
            else
            {
                startReadAhead = gapStart;
                var endReadAheadPosition = startReadAhead + minReadCount;
                readAheadCount = endReadAheadPosition - startReadAhead;
            }
        }

        /// <summary>
        /// Reads from the verified blocks as much data as is available and needed.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>True if there was any data read.</returns>
        private bool ReadBufferedData(byte[] buffer, ref int offset, ref int count)
        {
            bool readCompleated = false;
            while (count != 0 && this.downloadedBlocksList.Any())
            {
                var currentBlock = this.downloadedBlocksList.GetBlockByPosition(this.position);
                if (currentBlock == null)
                {
                    return readCompleated;
                }

                // Make sure the block's position is correct relative to global position
                currentBlock.BlockContent.Position = this.position - currentBlock.StartOffset;

                var blockRemainingSize = currentBlock.BlockContent.Length - currentBlock.BlockContent.Position;

                var numRead = currentBlock.BlockContent.Read(buffer, offset, (int)Math.Min(count, blockRemainingSize));
                readCompleated = true;
                this.position += numRead;
                offset += numRead;
                count -= numRead;

                // Check if the block is exhausted
                if (currentBlock.BlockContent.Position == currentBlock.BlockContent.Length)
                {
                    lock (this.downloadedBlocksList)
                    {
                        this.downloadedBlocksList.Remove(currentBlock.StartOffset);
                    }
                }
            }

            return readCompleated;
        }

        /// <summary>
        /// Calculates if the currently held data is less than <see cref="ReadAheadThreshold"/> percentage depleted.
        /// </summary>
        /// <param name="gapStart">The start position for any ReadAhead based on the last block.</param>
        /// <returns>True if more data is needed.</returns>
        private bool CalculateIfBufferTooLow(long gapStart)
        {
            var remainingSize = gapStart - this.position;
            return remainingSize < (ReadAheadThreshold * this.readAheadSize);
        }

        /// <summary>
        /// Verifies if the given offset is within the bounds of the stream. 
        /// </summary>
        /// <param name="offset">The offset to be checked.</param>
        /// <remarks>This may do a server round-trip if the length is not known.</remarks>
        private void CheckBounds(long offset)
        {
            if (offset < 0)
            {
                throw new ArgumentException(SR.SeekTooLowError, "offset");
            }
        }

        /// <summary>
        /// Represents a single block of data that was downloaded.
        /// </summary>
        internal class DownloadedBlock
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DownloadedBlock"/> class.
            /// </summary>
            /// <param name="startOffset">The start offset.</param>
            /// <param name="content">The content.</param>
            internal DownloadedBlock(long startOffset, Stream content)
            {
                this.StartOffset = startOffset;
                this.BlockContent = content;
            }

            /// <summary>
            /// Gets the starting location of the block.
            /// </summary>
            public long StartOffset { get; private set; }

            /// <summary>
            /// Gets the content of the block.
            /// </summary>
            public Stream BlockContent { get; private set; }
        }

        /// <summary>
        /// Encapsulates the collection of downloaded blocks and provides appropriate locking mechanism.
        /// </summary>
        internal class DownloadedBlockCollection
        {
            /// <summary>
            /// Holds the downloaded blocks.
            /// </summary>
            private SortedList<long, DownloadedBlock> downloadedBlocksList = new SortedList<long, DownloadedBlock>();

            /// <summary>
            /// Finds the block that contains the data for the <paramref name="desiredPosition"/>.
            /// </summary>
            /// <param name="desiredPosition">The position which is requested.</param>
            /// <returns>A block that contains the data for the <paramref name="desiredPosition"/> or null.</returns>
            internal DownloadedBlock GetBlockByPosition(long desiredPosition)
            {
                // Need to lock the list to make sure it's not modified while traversing
                lock (this.downloadedBlocksList)
                {
                    foreach (var kvp in this.downloadedBlocksList)
                    {
                        var block = kvp.Value;
                        if (desiredPosition >= block.StartOffset)
                        {
                            // If we are within the block, return it. Otherwise we don't have a valid block. That shouldn't happen.
                            if ((desiredPosition - block.StartOffset) < block.BlockContent.Length)
                            {
                                return block;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

                return null;
            }

            /// <summary>
            /// Removes any downloaded blocks that are outside the current bounds (position and readAheadSize).
            /// </summary>
            /// <param name="position">The position before which all blocks should be purged.</param>
            /// <param name="bufferedLength">Size of the read-ahead beyond position for blocks to be kept.</param>
            internal void RemoveExtraBlocks(long position, long bufferedLength)
            {
                if (this.downloadedBlocksList.Count != 0)
                {
                    var farPoint = position + bufferedLength;
                    lock (this.downloadedBlocksList)
                    {
                        for (int blockID = 0; blockID < this.downloadedBlocksList.Count; blockID++)
                        {
                            var block = this.downloadedBlocksList.Values[blockID];

                            // Check for a block that's already passed
                            if (position >= block.StartOffset + block.BlockContent.Length)
                            {
                                this.downloadedBlocksList.Remove(block.StartOffset);
                                blockID--;
                                continue;
                            }

                            // Remove the downloaded blocks after rewinding.
                            if (position < block.StartOffset)
                            {
                                this.downloadedBlocksList.Remove(block.StartOffset);
                                blockID--;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Calculates the length of the gap relative to <paramref name="position"/>.
            /// </summary>
            /// <param name="position">The position from which to find the gap.</param>
            /// <param name="desiredLength">Size of the desired.</param>
            /// <param name="gapStart">The gap start.</param>
            /// <param name="gapEnd">The gap end.</param>
            internal void CalculateGapLength(long position, long desiredLength, out long gapStart, out long gapEnd)
            {
                var readAheadStartPosition = position;

                if (this.Any())
                {
                    gapStart = gapEnd = -1;
                    DownloadedBlock block = null;
                    lock (this.downloadedBlocksList)
                    {
                        // Walk all blocks and find the next gap starting 
                        foreach (var kvp in this.downloadedBlocksList)
                        {
                            // If we aren't beyond a block, we need to read from there. 
                            block = kvp.Value;
                            if (gapStart == -1 && readAheadStartPosition < block.StartOffset)
                            {
                                gapStart = readAheadStartPosition;
                                gapEnd = block.StartOffset - 1;
                                break;
                            }

                            readAheadStartPosition = block.StartOffset + block.BlockContent.Length;
                        }
                    }

                    // If we walked the whole list and didn't find a gap, we are close to the end.
                    if (gapStart == -1)
                    {
                        gapStart = block.StartOffset + block.BlockContent.Length;
                        gapEnd = gapStart + desiredLength;
                    }
                }
                else
                {
                    gapStart = position;
                    gapEnd = position + desiredLength;
                }

                System.Diagnostics.Debug.Assert(gapStart != -1, "Ensure that the gap bounds are not negative.");
                System.Diagnostics.Debug.Assert(gapEnd != -1, "Ensure that the gap bounds are not negative.");
            }

            /// <summary>
            /// Tells if there are any blocks available.
            /// </summary>
            /// <returns>Returns <c>true</c> if there are any blocks; otherwise, <c>false</c>.</returns>
            internal bool Any()
            {
                return this.downloadedBlocksList.Count != 0;
            }

            /// <summary>
            /// Adds the specified downloaded block.
            /// </summary>
            /// <param name="downloadedBlock">The downloaded block.</param>
            internal void Add(DownloadedBlock downloadedBlock)
            {
                lock (this.downloadedBlocksList)
                {
                    this.downloadedBlocksList.Add(downloadedBlock.StartOffset, downloadedBlock);
                }
            }

            /// <summary>
            /// Removes the specified block based on the startOffset key.
            /// </summary>
            /// <param name="key">The key for the block.</param>
            internal void Remove(long key)
            {
                lock (this.downloadedBlocksList)
                {
                    this.downloadedBlocksList.Remove(key);
                }
            }
        }
    }
}