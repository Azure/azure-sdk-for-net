//-----------------------------------------------------------------------
// <copyright file="BlobWriteStreamHelper.cs" company="Microsoft">
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
    using Windows.Foundation;
    using Windows.Storage.Streams;

    /// <summary>
    /// BlobWriteStream class is based on Stream, but all RT APIs need to return
    /// IRandomAccessStream that cannot be easily converted from a Stream object.
    /// This class implements IRandomAccessStream and acts like a proxy between
    /// the caller and the actual Stream implementation.
    /// </summary>
    internal class BlobWriteStreamHelper : ICloudBlobStream
    {
        private BlobWriteStream originalStream;
        private IOutputStream originalStreamAsOutputStream;

        /// <summary>
        /// Initializes a new instance of the BlobWriteStreamHelper class for a block blob.
        /// </summary>
        /// <param name="blockBlob">Blob reference to write to.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        internal BlobWriteStreamHelper(CloudBlockBlob blockBlob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.originalStream = new BlobWriteStream(blockBlob, accessCondition, options, operationContext);
            this.originalStreamAsOutputStream = this.originalStream.AsOutputStream();
        }

        /// <summary>
        /// Initializes a new instance of the BlobWriteStreamHelper class for a page blob.
        /// </summary>
        /// <param name="pageBlob">Blob reference to write to.</param>
        /// <param name="pageBlobSize">Size of the page blob.</param>
        /// <param name="createNew">Use <c>true</c> if the page blob is newly created, <c>false</c> otherwise.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        internal BlobWriteStreamHelper(CloudPageBlob pageBlob, long pageBlobSize, bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.originalStream = new BlobWriteStream(pageBlob, pageBlobSize, createNew, accessCondition, options, operationContext);
            this.originalStreamAsOutputStream = this.originalStream.AsOutputStream();
        }

        /// <summary>
        /// Gets a value that indicates whether the stream can be read from.
        /// </summary>
        public bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the stream can be written to.
        /// </summary>
        public bool CanWrite
        {
            get
            {
                return this.originalStream.CanWrite;
            }
        }

        /// <summary>
        /// Gets the byte offset of the stream.
        /// </summary>
        public ulong Position
        {
            get
            {
                return (ulong)this.originalStream.Position;
            }
        }

        /// <summary>
        /// Gets or sets the size of the random access stream.
        /// </summary>
        public ulong Size
        {
            get
            {
                return (ulong)this.originalStream.Length;
            }

            set
            {
                this.originalStream.SetLength((long)value);
            }
        }

        /// <summary>
        /// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying blob, and commits the blob.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction CommitAsync()
        {
            return this.originalStream.CommitAsync().AsAsyncAction();
        }

        /// <summary>
        /// Returns an asynchronous byte reader object.
        /// </summary>
        /// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <param name="options">Specifies the type of the asynchronous read operation.</param>
        /// <returns>The asynchronous operation. </returns>
        public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Flushes data asynchronously in a sequential stream.
        /// </summary>
        /// <returns>The stream flush operation. </returns>
        public IAsyncOperation<bool> FlushAsync()
        {
            return this.originalStreamAsOutputStream.FlushAsync();
        }

        /// <summary>
        /// Writes data asynchronously in a sequential stream. 
        /// </summary>
        /// <param name="buffer">The buffer into which the asynchronous writer operation writes.</param>
        /// <returns>The byte writer operation.</returns>
        public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
        {
            return this.originalStreamAsOutputStream.WriteAsync(buffer);
        }

        /// <summary>
        /// Releases the blob resources used by the stream.
        /// </summary>
        public void Dispose()
        {
            if (this.originalStream != null)
            {
                this.originalStream.Dispose();
                this.originalStream = null;
            }
        }

        /// <summary>
        /// Creates a new instance of a IRandomAccessStream over the same resource as the current stream.
        /// </summary>
        /// <returns>The new stream.</returns>
        public IRandomAccessStream CloneStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an input stream at a specified location in a stream.
        /// </summary>
        /// <param name="position">The location in the stream at which to begin.</param>
        /// <returns>The input stream.</returns>
        public IInputStream GetInputStreamAt(ulong position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an output stream at a specified location in a stream.
        /// </summary>
        /// <param name="position">The location in the output stream at which to begin.</param>
        /// <returns>The output stream.</returns>
        public IOutputStream GetOutputStreamAt(ulong position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the position of the stream to the specified value.
        /// </summary>
        /// <param name="position">The new position of the stream.</param>
        public void Seek(ulong position)
        {
            this.originalStream.Seek((long)position, SeekOrigin.Begin);
        }
    }
}
