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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using System.IO;
    using System.Threading;
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
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
        /// buffer to the current stream. </param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin
        /// copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.EndWrite(this.BeginWrite(buffer, offset, count, null /* callback */, null /* state */));
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from
        /// buffer to the current stream. </param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin
        /// copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An <c>IAsyncResult</c> that represents the asynchronous write, which could still be pending.</returns>
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("buffer", buffer);
            CommonUtils.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtils.AssertInBounds("count", count, 0, buffer.Length - offset);

            if (this.blobMD5 != null)
            {
                this.blobMD5.UpdateHash(buffer, offset, count);
            }

            ChainedAsyncResult<NullType> chainedResult = new ChainedAsyncResult<NullType>(callback, state);
            ChainedAsyncResult<NullType> currentChainedResult = chainedResult;

            this.currentOffset += count;
            bool dispatched = false;
            if (this.lastException == null)
            {
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
                        this.DispatchWrite(currentChainedResult);
                        dispatched = true;

                        // Do not use the IAsyncResult we are going to return more
                        // than once, as otherwise its callback will be called more
                        // than once.
                        currentChainedResult = null;
                    }
                }
            }

            if (!dispatched)
            {
                chainedResult.CompletedSynchronously = true;
                chainedResult.OnComplete(this.lastException);
            }

            return chainedResult;
        }

        /// <summary>
        /// Waits for the pending asynchronous write to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<NullType> chainedResult = (ChainedAsyncResult<NullType>)asyncResult;
            chainedResult.End();

            if (this.lastException != null)
            {
                throw this.lastException;
            }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying blob.
        /// </summary>
        public override void Flush()
        {
            if (this.lastException != null)
            {
                throw this.lastException;
            }

            this.DispatchWrite(null /* asyncResult */);
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
            base.Dispose(disposing);
            this.Commit();
        }

        /// <summary>
        /// Commits the blob. For block blobs, this means uploading the block list. For
        /// page blobs, however, it only uploads blob properties.
        /// </summary>
        private void Commit()
        {
            this.Flush();

            if (this.blockBlob != null)
            {
                if (this.blobMD5 != null)
                {
                    this.blockBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5 = null;
                }

                if (this.blockList != null)
                {
                    this.blockBlob.PutBlockList(this.blockList, this.accessCondition, this.options, this.operationContext);
                    this.blockList = null;
                }
            }
            else
            {
                if (this.blobMD5 != null)
                {
                    this.pageBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5 = null;
                    this.pageBlob.SetProperties(this.accessCondition, this.options, this.operationContext);
                }
            }
        }

        /// <summary>
        /// Dispatches a write operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        private void DispatchWrite(ChainedAsyncResult<NullType> asyncResult)
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
                this.WriteBlock(bufferToUpload, blockId, bufferMD5, asyncResult);
            }
            else
            {
                if ((bufferToUpload.Length % Constants.PageSize) != 0)
                {
                    throw new IOException(SR.InvalidPageSize);
                }

                long offset = this.currentPageOffset;
                this.currentPageOffset += bufferToUpload.Length;
                this.WritePages(bufferToUpload, offset, bufferMD5, asyncResult);
            }
        }

        /// <summary>
        /// Starts an asynchronous PutBlock operation as soon as the parallel
        /// operation semaphore becomes available.
        /// </summary>
        /// <param name="blockData">Data to be uploaded</param>
        /// <param name="blockId">Block ID</param>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        private void WriteBlock(Stream blockData, string blockId, string blockMD5, ChainedAsyncResult<NullType> asyncResult)
        {
            Interlocked.Increment(ref this.pendingWrites);
            this.noPendingWritesEvent.Reset();

            bool completedSynchronously = this.parallelOperationSemaphore.WaitAsync(calledSynchronously =>
                {
                    try
                    {
                        this.blockBlob.BeginPutBlock(
                            blockId,
                            blockData,
                            blockMD5,
                            this.accessCondition,
                            this.options,
                            this.operationContext,
                            ar =>
                            {
                                try
                                {
                                    this.blockBlob.EndPutBlock(ar);
                                }
                                catch (Exception e)
                                {
                                    this.lastException = e;
                                }

                                try
                                {
                                    if (!calledSynchronously && (asyncResult != null))
                                    {
                                        // End the async result
                                        asyncResult.CompletedSynchronously = ar.CompletedSynchronously;
                                        asyncResult.OnComplete(this.lastException);
                                    }
                                }
                                catch (Exception)
                                {
                                    // If user's callback throws an exception, we want to
                                    // ignore and continue.
                                }
                                finally
                                {
                                    if (Interlocked.Decrement(ref this.pendingWrites) == 0)
                                    {
                                        this.noPendingWritesEvent.Set();
                                    }

                                    this.parallelOperationSemaphore.Release();
                                }
                            },
                            null /* state */);
                    }
                    catch (Exception e)
                    {
                        this.lastException = e;

                        // End the async result
                        asyncResult.CompletedSynchronously = calledSynchronously;
                        asyncResult.OnComplete(e);
                    }
                });

            if (completedSynchronously && asyncResult != null)
            {
                asyncResult.CompletedSynchronously = true;
                asyncResult.OnComplete();
            }
        }

        /// <summary>
        /// Starts an asynchronous WritePages operation as soon as the parallel
        /// operation semaphore becomes available.
        /// </summary>
        /// <param name="pageData">Data to be uploaded</param>
        /// <param name="offset">Offset within the page blob</param>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        private void WritePages(Stream pageData, long offset, string contentMD5, ChainedAsyncResult<NullType> asyncResult)
        {
            Interlocked.Increment(ref this.pendingWrites);
            this.noPendingWritesEvent.Reset();

            bool completedSynchronously = this.parallelOperationSemaphore.WaitAsync(calledSynchronously =>
                {
                    try
                    {
                        this.pageBlob.BeginWritePages(
                            pageData,
                            offset,
                            contentMD5,
                            this.accessCondition,
                            this.options,
                            this.operationContext,
                            ar =>
                            {
                                try
                                {
                                    this.pageBlob.EndWritePages(ar);
                                }
                                catch (Exception e)
                                {
                                    this.lastException = e;
                                }

                                try
                                {
                                    if (!calledSynchronously && (asyncResult != null))
                                    {
                                        // End the async result
                                        asyncResult.CompletedSynchronously = ar.CompletedSynchronously;
                                        asyncResult.OnComplete(this.lastException);
                                    }
                                }
                                catch (Exception)
                                {
                                    // If user's callback throws an exception, we want to
                                    // ignore and continue.
                                }
                                finally
                                {
                                    if (Interlocked.Decrement(ref this.pendingWrites) == 0)
                                    {
                                        this.noPendingWritesEvent.Set();
                                    }

                                    this.parallelOperationSemaphore.Release();
                                }
                            },
                            null /* state */);
                    }
                    catch (Exception e)
                    {
                        this.lastException = e;

                        // End the async result
                        asyncResult.CompletedSynchronously = calledSynchronously;
                        asyncResult.OnComplete(e);
                    }
                });

            if (completedSynchronously && asyncResult != null)
            {
                asyncResult.CompletedSynchronously = true;
                asyncResult.OnComplete();
            }
        }
    }
}
