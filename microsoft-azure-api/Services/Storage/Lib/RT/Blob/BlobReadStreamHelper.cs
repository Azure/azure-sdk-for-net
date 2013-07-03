// -----------------------------------------------------------------------------------------
// <copyright file="BlobReadStreamHelper.cs" company="Microsoft">
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
    using Windows.Foundation;
    using Windows.Storage.Streams;

    /// <summary>
    /// BlobReadStream class is based on Stream, but all RT APIs need to return
    /// IRandomAccessStream that cannot be easily converted from a Stream object.
    /// This class implements IRandomAccessStream and acts like a proxy between
    /// the caller and the actual Stream implementation.
    /// </summary>
    internal sealed class BlobReadStreamHelper : IRandomAccessStreamWithContentType
    {
        private BlobReadStream originalStream;
        private IInputStream originalStreamAsInputStream;

        /// <summary>
        /// Initializes a new instance of the BlobReadStreamHelper class.
        /// </summary>
        /// <param name="blob">Blob reference to read from</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        internal BlobReadStreamHelper(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.originalStream = new BlobReadStream(blob, accessCondition, options, operationContext);
            this.originalStreamAsInputStream = this.originalStream.AsInputStream();
        }

        /// <summary>
        /// Initializes a new instance of the BlobReadStreamHelper class.
        /// </summary>
        /// <param name="otherStream">An instance of BlobReadStream class that this helper should use.</param>
        private BlobReadStreamHelper(BlobReadStream otherStream)
        {
            this.originalStream = otherStream;
            this.originalStreamAsInputStream = this.originalStream.AsInputStream();
        }

        /// <summary>
        /// Gets a value that indicates whether the stream can be read from.
        /// </summary>
        public bool CanRead
        {
            get
            {
                return this.originalStream.CanRead;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the stream can be written to.
        /// </summary>
        public bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the format of the data.
        /// </summary>
        public string ContentType
        {
            get
            {
                return this.originalStream.ContentType;
            }
        }

        /// <summary>
        /// Creates a new instance of a IRandomAccessStream over the same resource as the current stream.
        /// </summary>
        /// <returns>The new stream. The initial, internal position of the stream is 0.</returns>
        public IRandomAccessStream CloneStream()
        {
            BlobReadStream clonedStream = new BlobReadStream(this.originalStream);
            return new BlobReadStreamHelper(clonedStream);
        }

        /// <summary>
        /// Returns an input stream at a specified location in a stream.
        /// </summary>
        /// <param name="position">The location in the stream at which to begin.</param>
        /// <returns>The input stream.</returns>
        public IInputStream GetInputStreamAt(ulong position)
        {
            BlobReadStream clonedStream = new BlobReadStream(this.originalStream);
            clonedStream.Seek((long)position, SeekOrigin.Begin);
            return clonedStream.AsInputStream();
        }

        /// <summary>
        /// This operation is not supported in BlobReadStreamHelper.
        /// </summary>
        /// <param name="position">Not used.</param>
        /// <returns>Not applicable.</returns>
        public IOutputStream GetOutputStreamAt(ulong position)
        {
            throw new NotSupportedException();
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
        /// Sets the position of the stream to the specified value.
        /// </summary>
        /// <param name="position">The new position of the stream.</param>
        public void Seek(ulong position)
        {
            this.originalStream.Seek((long)position, SeekOrigin.Begin);
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
        /// Releases the underlying stream.
        /// </summary>
        public void Dispose()
        {
            this.originalStream.Dispose();
        }

        /// <summary>
        /// Returns an asynchronous byte reader object.
        /// </summary>
        /// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
        /// <param name="count">The number of bytes to read that is less than or equal to the <c>Capacity</c> value.</param>
        /// <param name="options">Specifies the type of the asynchronous read operation.</param>
        /// <returns>The asynchronous operation.</returns>
        public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            return this.originalStreamAsInputStream.ReadAsync(buffer, count, options);
        }

        /// <summary>
        /// This operation is not supported in BlobReadStreamHelper.
        /// </summary>
        /// <returns>Not applicable.</returns>
        public IAsyncOperation<bool> FlushAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This operation is not supported in BlobReadStreamHelper.
        /// </summary>
        /// <param name="buffer">Not used.</param>
        /// <returns>Not applicable.</returns>
        public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
        {
            throw new NotSupportedException();
        }
    }
}
