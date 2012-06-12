//-----------------------------------------------------------------------
// <copyright file="BlobWriteStream.cs" company="Microsoft">
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
//    Contains code for the BlobWriteStream class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// The class is an append-only stream for writing into storage.
    /// </summary>
    internal class BlobWriteStream : BlobStream
    {
        /// <summary>
        /// Internal Block ID sequence number. Used in generating Block IDs.
        /// </summary>
        private long blockIdSequenceNumber = -1;

        /// <summary>
        /// The stream is writable until committed/close.
        /// </summary>
        private bool canWrite;

        /// <summary>
        /// The current position within the blob.
        /// </summary>
        private long position;

        /// <summary>
        /// The size of the blocks to use.
        /// </summary>
        private long blockSize;

        /// <summary>
        /// The list of uploaded blocks.
        /// </summary>
        private List<string> blockList;

        /// <summary>
        /// A memory stream holding the current block information.
        /// </summary>
        private SmallBlockMemoryStream blockBuffer;

        /// <summary>
        /// The hash of the current block.
        /// </summary>
        private HashAlgorithm blockHash;

        /// <summary>
        /// The ongoing blob hash.
        /// </summary>
        private HashAlgorithm blobHash;

        /// <summary>
        /// The set of options applying to the current blob.
        /// </summary>
        private BlobRequestOptions currentModifier;

        /// <summary>
        /// The access condition to apply.
        /// </summary>
        private AccessCondition accessCondition;

        /// <summary>
        /// Initializes a new instance of the BlobWriteStream class. 
        /// </summary>
        /// <param name="blob">The blob used for uploads.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">The options used for the stream.</param>
        /// <param name="blockSize">The size of the blocks to use.</param>
        internal BlobWriteStream(CloudBlockBlob blob, AccessCondition accessCondition, BlobRequestOptions options, long blockSize)
        {
            CommonUtils.AssertNotNull("blob", blob);
            CommonUtils.AssertNotNull("options", options);

            this.Blob = blob;
            this.blobHash = MD5.Create();
            ((BlobWriteStream)this).BlockSize = blockSize;
            this.blockList = new List<string>();
            this.currentModifier = options;
            this.accessCondition = accessCondition;
            this.canWrite = true;

            Random rand = new Random();
            this.blockIdSequenceNumber = (long)rand.Next() << 32;
            this.blockIdSequenceNumber += rand.Next();
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>Returns <c>true</c> if the stream supports reading; otherwise, <c>false</c>.</value>
        public override bool CanRead
        {
            get
            {
                return false;
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
                return false;
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
                return this.canWrite;
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
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.
        /// </summary>
        public override int WriteTimeout
        {
            get
            {
                return this.currentModifier.Timeout.RoundUpToMilliseconds();
            }

            set
            {
                this.currentModifier.Timeout = TimeSpan.FromMilliseconds(value);
            }
        }

        /// <summary>
        /// Gets the current length (equal to the position).
        /// </summary>
        /// <value>
        /// A long value representing the length of the stream in bytes.
        /// </value>
        /// <exception cref="T:System.NotSupportedException">
        /// A class derived from Stream does not support seeking.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// Methods were called after the stream was closed.
        /// </exception>
        public override long Length
        {
            get
            {
                return this.Position;
            }
        }

        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        /// <value>
        /// The current position within the stream.
        /// </value>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The stream does not support seeking.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// Methods were called after the stream was closed.
        /// </exception>
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
        /// Gets or sets the block size.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This is for BlockSize variable itself")]
        public override long BlockSize
        {
            get
            {
                return this.blockSize;
            }

            set
            {
                // Prevent changing to no-blocklist once a block is written
                if (this.blockList != null && this.blockList.Count != 0 && value == 0)
                {
                    throw new InvalidOperationException(SR.BlocksExistError);
                }

                if (this.blockBuffer != null && this.blockBuffer.Length >= value)
                {
                    throw new ArgumentOutOfRangeException("BlockSize", SR.BlobSizeReductonError);
                }

                if (value > Protocol.Constants.MaxBlockSize)
                {
                    throw new ArgumentOutOfRangeException("BlockSize", String.Format(CultureInfo.CurrentCulture, SR.BlockTooLargeError, Protocol.Constants.MaxBlockSize));
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("BlockSize", SR.BlocksTooSmallError);
                }

                this.blockSize = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the upload is done in blocks.
        /// </summary>
        /// <value>Returns <c>true</c> if blocks are to be used; otherwise, <c>false</c>.</value>
        private bool UseBlocks
        {
            get
            {
                return this.BlockSize != 0;
            }
        }

        /// <summary>
        /// The stream does not support reading.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values 
        ///                     between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns> The total number of bytes read into the buffer. This can be less than the number of bytes requested 
        /// if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Not supported operation as this is a write-only stream</exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// The stream does not support seeking.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type System.IO.SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="System.NotSupportedException">Not supported operation as this is a write-only stream</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// The stream does not support setting of length.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        /// <exception cref="System.NotSupportedException">Growing a stream is not possible without writing.</exception>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Write the provided data into the underlying stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">offset or count is negative.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown if blob is already committed/closed</exception>
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.EndWrite(this.BeginWrite(buffer, offset, count, null, null));
        }

        /// <summary>
        /// Copies a single byte into the stream.
        /// </summary>
        /// <param name="value">The byte of data to be written.</param>
        public override void WriteByte(byte value)
        {
            base.WriteByte(value);
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The  number of bytes to write.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous write, which could still be pending.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">offset or count is negative.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown if blob is already committed/closed</exception>
        /// <remarks>The operation will be completed synchronously if the buffer is not filled</remarks>
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            this.CheckWriteState();
            StreamUtilities.CheckBufferArguments(buffer, offset, count);

            Task<NullTaskReturn> task = null;

            if (this.UseBlocks)
            {
                task = new InvokeTaskSequenceTask(() =>
                {
                    return this.WriteBlockBlobImpl(buffer, offset, count);
                });
            }
            else
            {
                task = this.WriteNonBlockedBlobImpl(buffer, offset, count);
            }

            return task.ToAsyncResult(callback, state);
        }

        /// <summary>B
        /// Ends an asynchronous write operation.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <exception cref="ArgumentNullException">asyncResult is null</exception>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Causes any buffered data to be written to the remote storage. If the blob is not using blocks, the blob is fully committed.
        /// </summary>
        /// <exception cref="System.IO.IOException">An I/O error occurs while writing to storage.</exception>
        public override void Flush()
        {
            this.CheckWriteState();

            TaskImplHelper.ExecuteImpl(this.FlushInternal);
        }

        /// <summary>
        /// Aborts the upload of the blob. 
        /// </summary>
        public override void Abort()
        {
            this.blockList = null;
            this.blobHash = null;
            this.canWrite = false;
            this.ResetBlock();
        }

        /// <summary>
        /// Begins an asynchronous operation to commit the blob.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the commit is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous commit request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous commit, which could still be pending.</returns>
        public override IAsyncResult BeginCommit(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl(this.CommitImpl, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to commit the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <exception cref="ArgumentNullException">asyncResult is null</exception>
        public override void EndCommit(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Commits the blob on the server.
        /// </summary>
        public override void Commit()
        {
            TaskImplHelper.ExecuteImpl(this.CommitImpl);
        }

        /// <summary>
        /// Implements the disposing logic of committing the blob.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.CanWrite)
            {
                this.Commit();
                this.ResetBlock();
                this.canWrite = false;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Generates a blockID using the block's hash and a prefix.
        /// </summary>
        /// <returns>The base64 encoded blockID.</returns>
        private string GetBlockID()
        {
            this.blockIdSequenceNumber += 1;
            return Utilities.GenerateBlockIDWithHash(StreamUtilities.GetHashValue(this.blockHash), this.blockIdSequenceNumber);
        }

        /// <summary>
        /// Implements the block writing task.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The  number of bytes to write.</param>
        /// <returns>The sequence representing the uploading of the blocks.</returns>
        private TaskSequence WriteBlockBlobImpl(byte[] buffer, int offset, int count)
        {
            if (this.blockList.Count + (count / this.blockSize) > Constants.MaxBlockNumber)
            {
                throw new ArgumentOutOfRangeException("count", String.Format(CultureInfo.CurrentCulture, SR.TooManyBlocksError, Constants.MaxBlockNumber));
            }

            while (count != 0)
            {
                // Create a buffer if we don't have one
                if (this.blockBuffer == null)
                {
                    this.CreateNewBlock();
                }

                // Copy enough data to fill the buffer.
                int numCopied = (int)Math.Min(count, this.blockSize - this.blockBuffer.Length);
                this.blockBuffer.Write(buffer, offset, numCopied);

                StreamUtilities.ComputeHash(buffer, offset, numCopied, this.blockHash);
                StreamUtilities.ComputeHash(buffer, offset, numCopied, this.blobHash);

                // Advance the location
                this.position += numCopied;
                offset += numCopied;
                count -= numCopied;

                // If buffer is full, flush
                if (this.blockBuffer.Length == this.blockSize)
                {
                    var newTask = new InvokeTaskSequenceTask(this.FlushInternal);
                    yield return newTask;

                    // Make sure task completed successfully by materializing the exception
                    var result = newTask.Result;
                }
            }
        }

        /// <summary>
        /// Creates a task that writes data for a full blob.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The  number of bytes to write.</param>
        /// <returns>The (synchronous) sequence that copies the data into a buffer.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the buffer is larger than maximum blob size.</exception>
        /// <remarks>Since a non-block based blob is always fully buffered before upload, this task is a synchronous copy.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Param name is count")]
        private SynchronousTask WriteNonBlockedBlobImpl(byte[] buffer, int offset, int count)
        {
            return new SynchronousTask(() =>
            {
                if (this.blockBuffer == null)
                {
                    this.CreateNewBlock();
                }

                // Verify we don't go beyond single-upload size
                if (this.Length + count > Protocol.Constants.MaxSingleUploadBlobSize)
                {
                    throw new ArgumentOutOfRangeException("count", String.Format(CultureInfo.CurrentCulture, SR.BlobTooLargeError, Protocol.Constants.MaxSingleUploadBlobSize));
                }

                this.blockBuffer.Write(buffer, offset, count);
                this.position += count;
                StreamUtilities.ComputeHash(buffer, offset, count, this.blockHash);
                StreamUtilities.ComputeHash(buffer, offset, count, this.blobHash); // Update both, in case someone changes their mind mid-stream
            });
        }

        /// <summary>
        /// Implements the flushing sequence.
        /// </summary>
        /// <returns>The sequence of events for a flush.</returns>
        private TaskSequence FlushInternal()
        {
            // If there's nothing to flush, just return;
            if (this.blockBuffer == null)
            {
                yield break;
            }

            // Rewind the stream before upload
            this.blockBuffer.Position = 0;

            InvokeTaskSequenceTask newTask;

            if (this.UseBlocks)
            {
                newTask = new InvokeTaskSequenceTask(this.UploadBlock);
            }
            else
            {
                newTask = new InvokeTaskSequenceTask(this.UploadBlob);
            }

            yield return newTask;
            var result = newTask.Result; // Materialize the results to ensure exception propagation
        }

        /// <summary>
        /// Commits the blob by uploading any remaining data and the blocklist asynchronously. 
        /// </summary>
        /// <returns>A sequence of events required for commit.</returns>
        private TaskSequence CommitImpl()
        {
            this.CheckWriteState();

            if (this.blockBuffer != null && this.blockBuffer.Length != 0)
            {
                var task = new InvokeTaskSequenceTask(this.FlushInternal);
                yield return task;
                var result = task.Result; // Materialize the errors
            }

            // If all blocks are uploaded, commit 
            if (this.UseBlocks)
            {
                this.SetBlobMD5();

                var task = TaskImplHelper.GetRetryableAsyncTask(
                   () =>
                   {
                       // At the convenience layer we always upload uncommitted blocks
                       List<PutBlockListItem> putBlockList = new List<PutBlockListItem>();
                       foreach (var id in this.blockList)
                       {
                           putBlockList.Add(new PutBlockListItem(id, BlockSearchMode.Uncommitted));
                       }

                       return this.Blob.ToBlockBlob.UploadBlockList(putBlockList, this.accessCondition, this.currentModifier);
                   },
                   this.currentModifier.RetryPolicy);
                yield return task;
                var result = task.Result;
            }

            // Now we can set the full size.
            this.Blob.Properties.Length = this.Length;

            // Clear the internal state
            this.Abort();
        }

        /// <summary>
        /// Implements a sequence of events to upload a full blob.
        /// </summary>
        /// <returns>The sequence of events required to upload the blob.</returns>
        private TaskSequence UploadBlob()
        {
            this.SetBlobMD5();

            var task = this.Blob.ToBlockBlob.UploadFullBlobWithRetryImpl(this.blockBuffer, this.accessCondition, this.currentModifier);
            yield return task;
            var result = task.Result;

            // Reset all of the state
            this.Abort();
        }

        /// <summary>
        /// Sets the MD5 of the blob.
        /// </summary>
        private void SetBlobMD5()
        {
            var hashValue = StreamUtilities.GetHashValue(this.blobHash);

            this.Blob.Properties.ContentMD5 = hashValue;
        }

        /// <summary>
        /// Implements a sequence to upload a block.
        /// </summary>
        /// <returns>The sequence of events for upload.</returns>
        private TaskSequence UploadBlock()
        {
            // Calculate the MD5 of the buffer
            var blockID = this.GetBlockID();

            // Upload the current data as block         
            string hash = Utilities.ExtractMD5ValueFromBlockID(blockID);
            var task = this.Blob.ToBlockBlob.UploadBlockWithRetry(this.blockBuffer, blockID, hash, this.accessCondition, this.currentModifier);
            yield return task;
            var result = task.Result;

            // Add the block to the list of blocks.
            this.blockList.Add(blockID);
            this.ResetBlock();
        }

        /// <summary>
        /// Verifies that the blob is in writable state.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if stream is non-writable.</exception>
        private void CheckWriteState()
        {
            if (!this.CanWrite)
            {
                throw new ObjectDisposedException("BlobWriteStream", "Blob is in non-writable state");
            }
        }

        /// <summary>
        /// Resets the block and the block hash.
        /// </summary>
        private void ResetBlock()
        {
            if (this.blockBuffer != null)
            {
                this.blockBuffer.Dispose();
            }

            this.blockBuffer = null;
            this.blockHash = null;
        }

        /// <summary>
        /// Creates the new block and the block hash.
        /// </summary>
        private void CreateNewBlock()
        {
            this.blockBuffer = new SmallBlockMemoryStream(Constants.DefaultBufferSize);
            this.blockHash = MD5.Create();
        }
    }
}