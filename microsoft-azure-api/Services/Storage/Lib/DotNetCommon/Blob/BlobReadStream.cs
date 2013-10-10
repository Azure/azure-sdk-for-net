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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    internal sealed class BlobReadStream : BlobReadStreamBase
    {
        private volatile bool readPending = false;

        /// <summary>
        /// Initializes a new instance of the BlobReadStream class.
        /// </summary>
        /// <param name="blob">Blob reference to read from</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        internal BlobReadStream(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(blob, accessCondition, options, operationContext)
        {
        }        

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the
        /// position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer. This can be
        /// less than the number of bytes requested if that many bytes are not
        /// currently available, or zero (0) if the end of the stream has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
#if !SYNC
            return this.EndRead(this.BeginRead(buffer, offset, count, null, null));
#else
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            if (this.lastException != null)
            {
                throw this.lastException;
            }

            if ((this.currentOffset == this.Length) || (count == 0))
            {
                return 0;
            }

            int readCount = this.ConsumeBuffer(buffer, offset, count);
            if (readCount > 0)
            {
                return readCount;
            }

            return this.DispatchReadSync(buffer, offset, count);
#endif
        }

        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>An <c>IAsyncResult</c> that represents the asynchronous read, which could still be pending.</returns>
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            if (this.readPending)
            {
                throw new InvalidOperationException(SR.BlobStreamReadPending);
            }

            try
            {
                this.readPending = true;
                StorageAsyncResult<int> storageAsyncResult = new StorageAsyncResult<int>(callback, state);

                if (this.lastException != null)
                {
                    storageAsyncResult.OnComplete(this.lastException);
                    return storageAsyncResult;
                }

                if ((this.currentOffset == this.Length) || (count == 0))
                {
                    storageAsyncResult.Result = 0;
                    storageAsyncResult.OnComplete();
                    return storageAsyncResult;
                }

                int readCount = this.ConsumeBuffer(buffer, offset, count);
                if (readCount > 0)
                {
                    storageAsyncResult.Result = readCount;
                    storageAsyncResult.OnComplete();
                    return storageAsyncResult;
                }

                this.DispatchReadAsync(storageAsyncResult, buffer, offset, count);
                return storageAsyncResult;
            }
            catch (Exception)
            {
                this.readPending = false;
                throw;
            }
        }

        /// <summary>
        /// Waits for the pending asynchronous read to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>The total number of bytes read into the buffer. This can be
        /// less than the number of bytes requested if that many bytes are not
        /// currently available, or zero (0) if the end of the stream has been reached.</returns>
        public override int EndRead(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> storageAsyncResult = (StorageAsyncResult<int>)asyncResult;

            this.readPending = false;
            storageAsyncResult.End();
            
            return storageAsyncResult.Result;
        }

        /// <summary>
        /// Dispatches an async read operation that either reads from the cache or makes a call to
        /// the server.
        /// </summary>
        /// <param name="storageAsyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        private void DispatchReadAsync(StorageAsyncResult<int> storageAsyncResult, byte[] buffer, int offset, int count)
        {
            storageAsyncResult.OperationState = new ArraySegment<byte>(buffer, offset, count);
            
            try
            {
                this.internalBuffer.SetLength(0);
                this.blob.BeginDownloadRangeToStream(
                    this.internalBuffer,
                    this.currentOffset,
                    this.GetReadSize(),
                    this.accessCondition,
                    this.options,
                    this.operationContext,
                    this.DownloadRangeToStreamCallback,
                    storageAsyncResult);
            }
            catch (Exception e)
            {
                this.lastException = e;
                throw;
            }
        }

        /// <summary>
        /// Called when the asynchronous DownloadRangeToStream operation completes.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void DownloadRangeToStreamCallback(IAsyncResult ar)
        {
            StorageAsyncResult<int> storageAsyncResult = (StorageAsyncResult<int>)ar.AsyncState;
            storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

            try
            {
                this.blob.EndDownloadRangeToStream(ar);

                ArraySegment<byte> bufferSegment = (ArraySegment<byte>)storageAsyncResult.OperationState;
                this.internalBuffer.Seek(0, SeekOrigin.Begin);
                storageAsyncResult.Result = this.ConsumeBuffer(bufferSegment.Array, bufferSegment.Offset, bufferSegment.Count);
            }
            catch (Exception e)
            {
                this.lastException = e;
            }

            storageAsyncResult.OnComplete(this.lastException);
        }

#if SYNC
        /// <summary>
        /// Dispatches a sync read operation that either reads from the cache or makes a call to
        /// the server.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>Number of bytes read from the stream.</returns>
        private int DispatchReadSync(byte[] buffer, int offset, int count)
        {
            try
            {
                this.internalBuffer.SetLength(0);
                this.blob.DownloadRangeToStream(
                    this.internalBuffer,
                    this.currentOffset,
                    this.GetReadSize(),
                    this.accessCondition,
                    this.options,
                    this.operationContext);
                
                this.internalBuffer.Seek(0, SeekOrigin.Begin);
                return this.ConsumeBuffer(buffer, offset, count);
            }
            catch (Exception e)
            {
                this.lastException = e;
                throw;
            }
        }
#endif
    }
}
