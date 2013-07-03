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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;

#if WINDOWS_PHONE
    using System.Threading.Tasks;
#endif

    internal sealed class BlobWriteStream : BlobWriteStreamBase
    {
        private volatile bool flushPending = false;

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
        /// <param name="createNew">Use <c>true</c> if the page blob is newly created, <c>false</c> otherwise.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        internal BlobWriteStream(CloudPageBlob pageBlob, long pageBlobSize, bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(pageBlob, pageBlobSize, createNew, accessCondition, options, operationContext)
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
            long newOffset = this.GetNewOffset(offset, origin);

            if (oldOffset != newOffset)
            {
                if (this.blobMD5 != null)
                {
                    this.blobMD5.Dispose();
                    this.blobMD5 = null;
                }

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
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            if (this.committed)
            {
                throw new InvalidOperationException(SR.BlobStreamAlreadyCommitted);
            }

            if (this.blobMD5 != null)
            {
                this.blobMD5.UpdateHash(buffer, offset, count);
            }

            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state);
            StorageAsyncResult<NullType> currentAsyncResult = storageAsyncResult;

            this.currentOffset += count;
            bool dispatched = false;
            if (this.lastException == null)
            {
                while (count > 0)
                {
                    int maxBytesToWrite = this.streamWriteSizeInBytes - (int)this.internalBuffer.Length;
                    int bytesToWrite = Math.Min(count, maxBytesToWrite);

                    this.internalBuffer.Write(buffer, offset, bytesToWrite);
                    if (this.blockMD5 != null)
                    {
                        this.blockMD5.UpdateHash(buffer, offset, bytesToWrite);
                    }

                    count -= bytesToWrite;
                    offset += bytesToWrite;

                    if (bytesToWrite == maxBytesToWrite)
                    {
                        this.DispatchWrite(currentAsyncResult);
                        dispatched = true;

                        // Do not use the IAsyncResult we are going to return more
                        // than once, as otherwise its callback will be called more
                        // than once.
                        currentAsyncResult = null;
                    }
                }
            }

            if (!dispatched)
            {
                storageAsyncResult.OnComplete(this.lastException);
            }

            return storageAsyncResult;
        }

        /// <summary>
        /// Waits for the pending asynchronous write to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult;
            storageAsyncResult.End();

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

            if (this.committed)
            {
                throw new InvalidOperationException(SR.BlobStreamAlreadyCommitted);
            }

            this.DispatchWrite(null /* asyncResult */);
            this.noPendingWritesEvent.Wait();

            if (this.lastException != null)
            {
                throw this.lastException;
            }
        }

        /// <summary>
        /// Begins an asynchronous flush operation.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the flush is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous flush request from other requests.</param>
        /// <returns>An <c>ICancellableAsyncResult</c> that represents the asynchronous flush, which could still be pending.</returns>
        public override ICancellableAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            if (this.committed)
            {
                throw new InvalidOperationException(SR.BlobStreamAlreadyCommitted);
            }

            if (this.flushPending)
            {
                // We cannot allow more than one BeginFlush at a time, because
                // RegisterWaitForSingleObject would need duplicated handles
                // of noPendingWritesEvent for each call.
                throw new InvalidOperationException(SR.BlobStreamFlushPending);
            }

            try
            {
                this.flushPending = true;
                this.DispatchWrite(null /* asyncResult */);

                StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state);
                if ((this.lastException != null) || this.noPendingWritesEvent.Wait(0))
                {
                    storageAsyncResult.OnComplete(this.lastException);
                }
                else
                {
                    RegisteredWaitHandle waitHandle = ThreadPool.RegisterWaitForSingleObject(
                        this.noPendingWritesEvent.WaitHandle,
                        this.WaitForPendingWritesCallback,
                        storageAsyncResult,
                        -1,
                        true);

                    storageAsyncResult.OperationState = waitHandle;
                    storageAsyncResult.CancelDelegate = () =>
                    {
                        waitHandle.Unregister(null /* waitObject */);
                        storageAsyncResult.OnComplete(this.lastException);
                    };
                }

                return storageAsyncResult;
            }
            catch (Exception)
            {
                this.flushPending = false;
                throw;
            }
        }

        /// <summary>
        /// Waits for the pending asynchronous flush to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndFlush(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult;

            RegisteredWaitHandle waitHandle = (RegisteredWaitHandle)storageAsyncResult.OperationState;
            if (waitHandle != null)
            {
                waitHandle.Unregister(null /* waitObject */);
            }

            this.flushPending = false;
            storageAsyncResult.End();
        }

#if WINDOWS_PHONE
        /// <summary>
        /// Returns a task that performs an asynchronous flush operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFlush, this.EndFlush, cancellationToken);
        }
#endif

        /// <summary>
        /// Called when noPendingWritesEvent is signalled indicating that there are no outstanding write requests.
        /// </summary>
        /// <param name="state">An object containing information to be used by the callback method each time it executes. </param>
        /// <param name="timedOut">true if the WaitHandle timed out; false if it was signaled.</param>
        private void WaitForPendingWritesCallback(object state, bool timedOut)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)state;
            storageAsyncResult.UpdateCompletedSynchronously(false);
            storageAsyncResult.OnComplete(this.lastException);
        }

        /// <summary>
        /// Releases the blob resources used by the Stream.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.disposed = true;

                if (disposing)
                {
                    if (!this.committed)
                    {
#if SYNC
                        this.Commit();
#else
                        this.EndCommit(this.BeginCommit(null, null));
#endif
                    }
                }
            }

            base.Dispose(disposing);
        }

#if SYNC
        /// <summary>
        /// Clears all buffers for this stream, causes any buffered data to be written to the underlying blob, and commits the blob.
        /// </summary>
        public override void Commit()
        {
            this.Flush();
            this.committed = true;

            try
            {
                if (this.blockBlob != null)
                {
                    if (this.blobMD5 != null)
                    {
                        this.blockBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                    }

                    this.blockBlob.PutBlockList(
                        this.blockList,
                        this.accessCondition,
                        this.options,
                        this.operationContext);
                }
                else
                {
                    if (this.blobMD5 != null)
                    {
                        this.pageBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                        this.pageBlob.SetProperties(
                            this.accessCondition,
                            this.options,
                            this.operationContext);
                    }
                }
            }
            catch (Exception e)
            {
                this.lastException = e;
                throw;
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous commit operation.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the commit is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous commit request from other requests.</param>
        /// <returns>An <c>ICancellableAsyncResult</c> that represents the asynchronous commit, which could still be pending.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "storageAsyncResult must be returned.")]
        public override ICancellableAsyncResult BeginCommit(AsyncCallback callback, object state)
        {
            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state);
            ICancellableAsyncResult result = this.BeginFlush(this.CommitFlushCallback, storageAsyncResult);
            storageAsyncResult.CancelDelegate = result.Cancel;
            return storageAsyncResult;
        }

        /// <summary>
        /// Waits for the pending asynchronous commit to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndCommit(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult;
            storageAsyncResult.End();
        }

        /// <summary>
        /// Called when the pending flush operation completes so that we can continue with the commit.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void CommitFlushCallback(IAsyncResult ar)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)ar.AsyncState;
            storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);
            this.committed = true;

            lock (storageAsyncResult.CancellationLockerObject)
            {
                storageAsyncResult.CancelDelegate = null;
                try
                {
                    this.EndFlush(ar);

                    if (this.blockBlob != null)
                    {
                        if (this.blobMD5 != null)
                        {
                            this.blockBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                        }

                        ICancellableAsyncResult result = this.blockBlob.BeginPutBlockList(
                            this.blockList,
                            this.accessCondition,
                            this.options,
                            this.operationContext,
                            this.PutBlockListCallback,
                            storageAsyncResult);

                        storageAsyncResult.CancelDelegate = result.Cancel;
                    }
                    else
                    {
                        if (this.blobMD5 != null)
                        {
                            this.pageBlob.Properties.ContentMD5 = this.blobMD5.ComputeHash();
                            ICancellableAsyncResult result = this.pageBlob.BeginSetProperties(
                                this.accessCondition,
                                this.options,
                                this.operationContext,
                                this.SetPropertiesCallback,
                                storageAsyncResult);

                            storageAsyncResult.CancelDelegate = result.Cancel;
                        }
                        else
                        {
                            storageAsyncResult.OnComplete();
                        }
                    }

                    if (storageAsyncResult.CancelRequested)
                    {
                        storageAsyncResult.Cancel();
                    }
                }
                catch (Exception e)
                {
                    this.lastException = e;
                    storageAsyncResult.OnComplete(e);
                }
            }
        }

        /// <summary>
        /// Called when the block blob commit operation completes.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void PutBlockListCallback(IAsyncResult ar)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)ar.AsyncState;
            storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

            try
            {
                this.blockBlob.EndPutBlockList(ar);
                storageAsyncResult.OnComplete();
            }
            catch (Exception e)
            {
                this.lastException = e;
                storageAsyncResult.OnComplete(e);
            }
        }

        /// <summary>
        /// Called when the page blob commit operation completes.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void SetPropertiesCallback(IAsyncResult ar)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)ar.AsyncState;
            storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

            try
            {
                this.pageBlob.EndSetProperties(ar);
                storageAsyncResult.OnComplete();
            }
            catch (Exception e)
            {
                this.lastException = e;
                storageAsyncResult.OnComplete(e);
            }
        }

        /// <summary>
        /// Dispatches a write operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        private void DispatchWrite(StorageAsyncResult<NullType> asyncResult)
        {
            if (this.internalBuffer.Length == 0)
            {
                if (asyncResult != null)
                {
                    asyncResult.OnComplete(this.lastException);
                }

                return;
            }

            MultiBufferMemoryStream bufferToUpload = this.internalBuffer;
            this.internalBuffer = new MultiBufferMemoryStream(this.Blob.ServiceClient.BufferManager);
            bufferToUpload.Seek(0, SeekOrigin.Begin);

            string bufferMD5 = null;
            if (this.blockMD5 != null)
            {
                bufferMD5 = this.blockMD5.ComputeHash();
                this.blockMD5.Dispose();
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
                    this.lastException = new IOException(SR.InvalidPageSize);
                    throw this.lastException;
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
        /// <param name="blockMD5">MD5 hash of the data to be uploaded</param>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void WriteBlock(Stream blockData, string blockId, string blockMD5, StorageAsyncResult<NullType> asyncResult)
        {
            this.noPendingWritesEvent.Increment();
            this.parallelOperationSemaphore.WaitAsync(calledSynchronously =>
            {
                try
                {
                    ICancellableAsyncResult result = this.blockBlob.BeginPutBlock(
                        blockId,
                        blockData,
                        blockMD5,
                        this.accessCondition,
                        this.options,
                        this.operationContext,
                        this.PutBlockCallback,
                        null /* state */);

                    if (asyncResult != null)
                    {
                        // We do not need to do this inside a lock, as asyncResult is
                        // not returned to the user yet.
                        asyncResult.CancelDelegate = result.Cancel;
                    }
                }
                catch (Exception e)
                {
                    this.lastException = e;
                }
                finally
                {
                    if (asyncResult != null)
                    {
                        asyncResult.UpdateCompletedSynchronously(calledSynchronously);
                        asyncResult.OnComplete(this.lastException);
                    }
                }
            });
        }

        /// <summary>
        /// Called when the asynchronous PutBlock operation completes.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void PutBlockCallback(IAsyncResult ar)
        {
            try
            {
                this.blockBlob.EndPutBlock(ar);
            }
            catch (Exception e)
            {
                this.lastException = e;
            }

            // This must be called in a separate thread than the user's
            // callback to prevent a deadlock in case the callback is blocking.
            // If they are called in the same thread, this call must take
            // place before the user's callback.
            this.noPendingWritesEvent.Decrement();
            this.parallelOperationSemaphore.Release();
        }

        /// <summary>
        /// Starts an asynchronous WritePages operation as soon as the parallel
        /// operation semaphore becomes available.
        /// </summary>
        /// <param name="pageData">Data to be uploaded</param>
        /// <param name="offset">Offset within the page blob</param>
        /// <param name="contentMD5">MD5 hash of the data to be uploaded</param>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "If user's callback throws any exception, we want to ignore and continue.")]
        private void WritePages(Stream pageData, long offset, string contentMD5, StorageAsyncResult<NullType> asyncResult)
        {
            this.noPendingWritesEvent.Increment();
            this.parallelOperationSemaphore.WaitAsync(calledSynchronously =>
            {
                try
                {
                    ICancellableAsyncResult result = this.pageBlob.BeginWritePages(
                        pageData,
                        offset,
                        contentMD5,
                        this.accessCondition,
                        this.options,
                        this.operationContext,
                        this.WritePagesCallback,
                        null /* state */);

                    if (asyncResult != null)
                    {
                        // We do not need to do this inside a lock, as asyncResult is
                        // not returned to the user yet.
                        asyncResult.CancelDelegate = result.Cancel;
                    }
                }
                catch (Exception e)
                {
                    this.lastException = e;
                }
                finally
                {
                    if (asyncResult != null)
                    {
                        asyncResult.UpdateCompletedSynchronously(calledSynchronously);
                        asyncResult.OnComplete(this.lastException);
                    }
                }
            });
        }

        /// <summary>
        /// Called when the asynchronous WritePages operation completes.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void WritePagesCallback(IAsyncResult ar)
        {
            try
            {
                this.pageBlob.EndWritePages(ar);
            }
            catch (Exception e)
            {
                this.lastException = e;
            }

            // This must be called in a separate thread than the user's
            // callback to prevent a deadlock in case the callback is blocking.
            // If they are called in the same thread, this call must take
            // place before the user's callback.
            this.noPendingWritesEvent.Decrement();
            this.parallelOperationSemaphore.Release();
        }
    }
}
