// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Storage.Streams;

    /// <summary>
    /// Provides an input stream to read a given blob resource.
    /// </summary>
    internal sealed class BlobReadStream : BlobReadStreamBase, IContentTypeProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobReadStream"/> class.
        /// </summary>
        /// <param name="blob">Blob reference to read from.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        internal BlobReadStream(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base(blob, accessCondition, options, operationContext)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobReadStream"/> class.
        /// </summary>
        /// <param name="otherStream">Another BlobReadStream instance to clone.</param>
        internal BlobReadStream(BlobReadStream otherStream)
            : this(otherStream.blob, otherStream.accessCondition, otherStream.options, otherStream.operationContext)
        {
        }

        /// <summary>
        /// Gets the format of the data.
        /// </summary>
        /// <value>The format of the data.</value>
        public string ContentType
        {
            get
            {
                return this.blobProperties.ContentType;
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
            return this.ReadAsync(buffer, offset, count, CancellationToken.None).Result;
        }

        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current stream, advances the
        /// position within the stream by the number of bytes read, and monitors cancellation requests.
        /// </summary>
        /// <remarks>In the returned <see cref="Task{TElement}"/> object, the value of the integer
        /// parameter contains the total number of bytes read into the buffer. The result value can be
        /// less than the number of bytes requested if the number of bytes currently available is less
        /// than the requested number, or it can be 0 (zero) if the end of the stream has been reached.</remarks>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
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

            return await this.DispatchReadAsync(buffer, offset, count);
        }

        /// <summary>
        /// Dispatches a sync read operation that either reads from the cache or makes a call to
        /// the server.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>Number of bytes read from the stream.</returns>
        private async Task<int> DispatchReadAsync(byte[] buffer, int offset, int count)
        {
            try
            {
                this.internalBuffer.SetLength(0);
                await this.blob.DownloadRangeToStreamAsync(
                    this.internalBuffer.AsOutputStream(),
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
    }
}
