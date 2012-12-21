// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal sealed class BlobWriteStream : BlobWriteStreamBase
    {
        /// <summary>
        /// Initializes a new instance of the BlobWriteStream class for a block blob.
        /// </summary>
        /// <param name="blockBlob">Blob reference to write to.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        internal BlobWriteStream(CloudBlockBlob blockBlob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(blockBlob, accessCondition, options, operationContext)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlobWriteStream class for a page blob.
        /// </summary>
        /// <param name="pageBlob">Blob reference to write to.</param>
        /// <param name="pageBlobSize">Size of the page blob.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        internal BlobWriteStream(CloudPageBlob pageBlob, long pageBlobSize, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(pageBlob, pageBlobSize, accessCondition, options, operationContext)
        {
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type <c>SeekOrigin</c> indicating the reference
        /// point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            long oldOffset = this.currentOffset;
            long newOffset = base.Seek(offset, origin);

            if (oldOffset != newOffset)
            {
                this.blobMD5 = null;
                this.Flush();
            }

            this.currentOffset = newOffset;
            this.currentPageOffset = newOffset;
            return this.currentOffset;
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current
        /// position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from
        /// buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin
        /// copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.WriteAsync(buffer, offset, count).Wait();
        }

        /// <summary>
        /// Asynchronously writes a sequence of bytes to the current stream, advances the current
        /// position within this stream by the number of bytes written, and monitors cancellation requests.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from
        /// buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin
        /// copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            CommonUtils.AssertNotNull("buffer", buffer);
            CommonUtils.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtils.AssertInBounds("count", count, 0, buffer.Length - offset);

            if (this.lastException != null)
            {
                throw this.lastException;
            }

            if (this.blobMD5 != null)
            {
                this.blobMD5.UpdateHash(buffer, offset, count);
            }

            this.currentOffset += count;
            while (count > 0)
            {
                int maxBytesToWrite = this.Blob.StreamWriteSizeInBytes - (int)this.buffer.Length;
                int bytesToWrite = Math.Min(count, maxBytesToWrite);

                this.buffer.Write(buffer, offset, bytesToWrite);
                if (this.blockMD5 != null)
                {
                    this.blockMD5.UpdateHash(buffer, offset, bytesToWrite);
                }

                count -= bytesToWrite;
                offset += bytesToWrite;

                if (bytesToWrite == maxBytesToWrite)
                {
                    await this.DispatchWriteAsync();
                }
            }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying blob.
        /// </summary>
        public override void Flush()
        {
            this.FlushAsync().Wait();
        }

        /// <summary>
        /// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            if (this.lastException != null)
            {
                throw this.lastException;
            }

            await this.DispatchWriteAsync();
            this.noPendingWritesEvent.WaitOne();

            if (this.lastException != null)
            {
                throw this.lastException;
            }
        }

        /// <summary>
        /// Releases the blob resources used by the Stream.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.CommitAsync().Wait();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Asynchronously commits the blob. For block blobs, this means uploading the block list. For
        /// page blobs, however, it only uploads blob properties.
        /// </summary>
        /// <returns>A task that represents the asynchronous commit operation.</returns>
        private async Task CommitAsync()
        {
            await this.FlushAsync();

            if (this.blockBlob != null)
            {
                if (this.blobMD5 != null)
                {
                    this.blockBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5 = null;
                }

                if (this.blockList != null)
                {
                    await this.blockBlob.PutBlockListAsync(this.blockList, this.accessCondition, this.options, this.operationContext);
                    this.blockList = null;
                }
            }
            else
            {
                if (this.blobMD5 != null)
                {
                    this.pageBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5 = null;
                    await this.pageBlob.SetPropertiesAsync(this.accessCondition, this.options, this.operationContext);
                }
            }
        }

        /// <summary>
        /// Asynchronously dispatches a write operation.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        private async Task DispatchWriteAsync()
        {
            if (this.buffer.Length == 0)
            {
                return;
            }

            MemoryStream bufferToUpload = this.buffer;
            this.buffer = new MemoryStream(this.Blob.StreamWriteSizeInBytes);
            bufferToUpload.Seek(0, SeekOrigin.Begin);

            string bufferMD5 = null;
            if (this.blockMD5 != null)
            {
                bufferMD5 = this.blockMD5.ComputeHash();
                this.blockMD5 = new MD5Wrapper();
            }

            if (this.blockBlob != null)
            {
                string blockId = this.GetCurrentBlockId();
                this.blockList.Add(blockId);
                await this.WriteBlockAsync(bufferToUpload, blockId, bufferMD5);
            }
            else
            {
                if ((bufferToUpload.Length % Constants.PageSize) != 0)
                {
                    throw new IOException(SR.InvalidPageSize);
                }

                long offset = this.currentPageOffset;
                this.currentPageOffset += bufferToUpload.Length;
                await this.WritePagesAsync(bufferToUpload, offset, bufferMD5);
            }
        }

#pragma warning disable 4014
        /// <summary>
        /// Starts an asynchronous PutBlock operation as soon as the parallel
        /// operation semaphore becomes available.
        /// </summary>
        /// <param name="blockData">Data to be uploaded</param>
        /// <param name="blockId">Block ID</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <remarks>Warning CS4014 is disabled here, since we intentionally do not
        /// await PutBlockAsync call.</remarks>
        private async Task WriteBlockAsync(Stream blockData, string blockId, string blockMD5)
        {
            Interlocked.Increment(ref this.pendingWrites);
            this.noPendingWritesEvent.Reset();

            await this.parallelOperationSemaphore.WaitAsync();
            this.blockBlob.PutBlockAsync(blockId, blockData.AsInputStream(), blockMD5, this.accessCondition, this.options, this.operationContext).AsTask().ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        this.lastException = task.Exception;
                    }

                    if (Interlocked.Decrement(ref this.pendingWrites) == 0)
                    {
                        this.noPendingWritesEvent.Set();
                    }

                    this.parallelOperationSemaphore.Release();
                });
        }

        /// <summary>
        /// Starts an asynchronous WritePages operation as soon as the parallel
        /// operation semaphore becomes available.
        /// </summary>
        /// <param name="pageData">Data to be uploaded</param>
        /// <param name="offset">Offset within the page blob</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <remarks>Warning CS4014 is disabled here, since we intentionally do not
        /// await WritePagesAsync call.</remarks>
        private async Task WritePagesAsync(Stream pageData, long offset, string contentMD5)
        {
            Interlocked.Increment(ref this.pendingWrites);
            this.noPendingWritesEvent.Reset();

            await this.parallelOperationSemaphore.WaitAsync();
            this.pageBlob.WritePagesAsync(pageData.AsInputStream(), offset, contentMD5, this.accessCondition, this.options, this.operationContext).AsTask().ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        this.lastException = task.Exception;
                    }

                    if (Interlocked.Decrement(ref this.pendingWrites) == 0)
                    {
                        this.noPendingWritesEvent.Set();
                    }

                    this.parallelOperationSemaphore.Release();
                });
        }
#pragma warning restore 4014
    }
}
