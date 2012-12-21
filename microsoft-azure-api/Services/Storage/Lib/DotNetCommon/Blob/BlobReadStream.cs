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
    using System;
    using System.IO;
    using System.Threading;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal sealed class BlobReadStream : BlobReadStreamBase
    {
        private AsyncSemaphore parallelOperationSemaphore;

        /// <summary>
        /// Initializes a new instance of the BlobReadStrea class.
        /// </summary>
        /// <param name="blob">Blob reference to read from</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        internal BlobReadStream(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(blob, accessCondition, options, operationContext)
        {
            this.parallelOperationSemaphore = new AsyncSemaphore(1);
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get
            {
                if (!this.isLengthAvailable)
                {
                    this.blob.FetchAttributes(this.accessCondition, this.options, this.operationContext);
                    this.LockToETag();

                    this.isLengthAvailable = true;
                    
                    if (string.IsNullOrEmpty(this.blob.Properties.ContentMD5))
                    {
                        this.blobMD5 = null;
                    }
                }

                return this.blob.Properties.Length;
            }
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
            return this.EndRead(this.BeginRead(buffer, offset, count, null /* callback */, null /* state */));
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
            CommonUtils.AssertNotNull("buffer", buffer);
            CommonUtils.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtils.AssertInBounds("count", count, 0, buffer.Length - offset);

            ChainedAsyncResult<int> chainedResult = new ChainedAsyncResult<int>(callback, state);

            if (this.lastException != null)
            {
                chainedResult.OnComplete(this.lastException);
            }
            else
            {
                if (!this.isLengthAvailable)
                {
                    this.blob.BeginFetchAttributes(
                        this.accessCondition,
                        this.options,
                        this.operationContext,
                        ar =>
                        {
                            chainedResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

                            try
                            {
                                this.blob.EndFetchAttributes(ar);
                            }
                            catch (Exception e)
                            {
                                this.lastException = e;
                                chainedResult.OnComplete(this.lastException);
                                return;
                            }

                            this.LockToETag();
                            this.isLengthAvailable = true;

                            if (string.IsNullOrEmpty(this.blob.Properties.ContentMD5))
                            {
                                this.blobMD5 = null;
                            }

                            this.DispatchRead(chainedResult, buffer, offset, count);
                        },
                        null /* state */);
                }
                else
                {
                    this.DispatchRead(chainedResult, buffer, offset, count);
                }
            }

            return chainedResult;
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
            ChainedAsyncResult<int> chainedResult = (ChainedAsyncResult<int>)asyncResult;
            chainedResult.End();

            if (this.lastException != null)
            {
                throw this.lastException;
            }

            return chainedResult.Result;
        }

        /// <summary>
        /// Dispatches a read operation that either reads from the cache or makes a call to
        /// the server.
        /// </summary>
        /// <param name="chainedResult">The reference to the pending asynchronous request to finish.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <remarks>Even though this code looks like it can run in parallel, the semaphore only allows
        /// 1 active read. This is required because of caching.</remarks>
        private void DispatchRead(ChainedAsyncResult<int> chainedResult, byte[] buffer, int offset, int count)
        {
            if ((this.currentOffset == this.Length) || (count == 0))
            {
                chainedResult.Result = 0;
                chainedResult.OnComplete();
            }
            else
            {
                this.parallelOperationSemaphore.WaitAsync(calledSynchronously =>
                    {
                        try
                        {
                            // If the buffer is already consumed, dispatch another read.
                            if (this.buffer.Position == this.buffer.Length)
                            {
                                int readSize = (int)Math.Min(this.blob.StreamMinimumReadSizeInBytes, this.Length - this.currentOffset);
                                if (this.options.UseTransactionalMD5.Value)
                                {
                                    readSize = Math.Min(readSize, Constants.MaxBlockSize);
                                }

                                this.buffer.SetLength(0);
                                this.blob.BeginDownloadRangeToStream(
                                    this.buffer,
                                    this.currentOffset,
                                    readSize,
                                    this.accessCondition,
                                    this.options,
                                    this.operationContext,
                                    ar =>
                                    {
                                        try
                                        {
                                            this.blob.EndDownloadRangeToStream(ar);
                                        }
                                        catch (Exception e)
                                        {
                                            this.lastException = e;
                                        }

                                        if (this.lastException == null)
                                        {
                                            this.buffer.Seek(0, SeekOrigin.Begin);
                                            this.LockToETag();

                                            // Read as much as we can from the buffer.
                                            int result = this.buffer.Read(buffer, offset, count);
                                            this.currentOffset += result;
                                            chainedResult.Result = result;
                                            this.VerifyBlobMD5(buffer, offset, result);
                                        }

                                        // Calling this here will make reentrancy safer, as the user
                                        // does not yet know the operation has completed.
                                        this.parallelOperationSemaphore.Release();

                                        // End the async result
                                        chainedResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);
                                        chainedResult.OnComplete(this.lastException);
                                    },
                                    null /* state */);
                            }
                            else
                            {
                                // Read as much as we can from the buffer.
                                int result = this.buffer.Read(buffer, offset, count);
                                this.currentOffset += result;
                                chainedResult.Result = result;
                                this.VerifyBlobMD5(buffer, offset, result);

                                // Calling this here will make reentrancy safer, as the user
                                // does not yet know the operation has completed.
                                this.parallelOperationSemaphore.Release();

                                // End the async result
                                chainedResult.UpdateCompletedSynchronously(calledSynchronously);
                                chainedResult.OnComplete(this.lastException);
                            }
                        }
                        catch (Exception e)
                        {
                            this.lastException = e;

                            // End the async result
                            chainedResult.UpdateCompletedSynchronously(calledSynchronously);
                            chainedResult.OnComplete(this.lastException);
                        }
                    });
            }
        }
    }
}
