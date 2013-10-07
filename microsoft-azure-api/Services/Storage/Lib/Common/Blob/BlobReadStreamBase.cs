//-----------------------------------------------------------------------
// <copyright file="BlobReadStreamBase.cs" company="Microsoft">
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
    using System.Globalization;
    using System.IO;

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    internal abstract class BlobReadStreamBase : Stream
    {
        protected ICloudBlob blob;
        protected BlobProperties blobProperties;
        protected long currentOffset;
        protected MemoryStream internalBuffer;
        protected int streamMinimumReadSizeInBytes;
        protected AccessCondition accessCondition;
        protected BlobRequestOptions options;
        protected OperationContext operationContext;
        protected MD5Wrapper blobMD5;
        protected volatile Exception lastException;

        /// <summary>
        /// Initializes a new instance of the BlobReadStreamBase class.
        /// </summary>
        /// <param name="blob">Blob reference to read from</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        protected BlobReadStreamBase(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            if (options.UseTransactionalMD5.Value)
            {
                CommonUtility.AssertInBounds("StreamMinimumReadSizeInBytes", blob.StreamMinimumReadSizeInBytes, 1, Constants.MaxRangeGetContentMD5Size);
            }

            this.blob = blob;
            this.blobProperties = new BlobProperties(blob.Properties);
            this.currentOffset = 0;
            this.streamMinimumReadSizeInBytes = this.blob.StreamMinimumReadSizeInBytes;
            this.internalBuffer = new MemoryStream(this.streamMinimumReadSizeInBytes);
            this.accessCondition = accessCondition;
            this.options = options;
            this.operationContext = operationContext;
            this.blobMD5 = (this.options.DisableContentMD5Validation.Value || string.IsNullOrEmpty(this.blobProperties.ContentMD5)) ? null : new MD5Wrapper();
            this.lastException = null;
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
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
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get
            {
                return this.currentOffset;
            }

            set
            {
                this.Seek(value, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        /// <value>The length in bytes of the stream.</value>
        public override long Length
        {
            get
            {
                return this.blobProperties.Length;
            }
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type <c>SeekOrigin</c> indicating the reference
        /// point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <remarks>Seeking in a BlobReadStream disables MD5 validation.</remarks>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (this.lastException != null)
            {
                throw this.lastException;
            }

            long newOffset;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newOffset = offset;
                    break;

                case SeekOrigin.Current:
                    newOffset = this.currentOffset + offset;
                    break;

                case SeekOrigin.End:
                    newOffset = this.Length + offset;
                    break;

                default:
                    CommonUtility.ArgumentOutOfRange("origin", origin);
                    throw new ArgumentOutOfRangeException("origin");
            }

            CommonUtility.AssertInBounds("offset", newOffset, 0, this.Length);

            if (newOffset != this.currentOffset)
            {
                long bufferOffset = this.internalBuffer.Position + (newOffset - this.currentOffset);
                if ((bufferOffset >= 0) && (bufferOffset < this.internalBuffer.Length))
                {
                    this.internalBuffer.Position = bufferOffset;
                }
                else
                {
                    this.internalBuffer.SetLength(0);
                }

                this.blobMD5 = null;
                this.currentOffset = newOffset;
            }

            return this.currentOffset;
        }

        /// <summary>
        /// This operation is not supported in BlobReadStreamBase.
        /// </summary>
        /// <param name="value">Not used.</param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This operation is not supported in BlobReadStreamBase.
        /// </summary>
        /// <param name="buffer">Not used.</param>
        /// <param name="offset">Not used.</param>
        /// <param name="count">Not used.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This operation is a no-op in BlobReadStreamBase.
        /// </summary>
        public override void Flush()
        {
        }

        /// <summary>
        /// Read as much as we can from the internal buffer
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing
        /// data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>Number of bytes read from the stream.</returns>
        protected int ConsumeBuffer(byte[] buffer, int offset, int count)
        {
            int readCount = this.internalBuffer.Read(buffer, offset, count);
            this.currentOffset += readCount;
            this.VerifyBlobMD5(buffer, offset, readCount);
            return readCount;
        }

        /// <summary>
        /// Calculates the number of bytes to read from the blob.
        /// </summary>
        /// <returns>Number of bytes to read.</returns>
        protected int GetReadSize()
        {
            if (this.currentOffset < this.Length)
            {
                return (int)Math.Min(this.streamMinimumReadSizeInBytes, this.Length - this.currentOffset);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Updates the blob MD5 with newly downloaded content.
        /// </summary>
        /// <param name="buffer">The buffer to read the data from.</param>
        /// <param name="offset">The byte offset in buffer at which to begin reading data.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        protected void VerifyBlobMD5(byte[] buffer, int offset, int count)
        {
            if ((this.blobMD5 != null) && (this.lastException == null) && (count > 0))
            {
                this.blobMD5.UpdateHash(buffer, offset, count);

                if ((this.currentOffset == this.Length) &&
                    !string.IsNullOrEmpty(this.blobProperties.ContentMD5))
                {
                    string computedMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5.Dispose();
                    this.blobMD5 = null;

                    if (!computedMD5.Equals(this.blobProperties.ContentMD5))
                    {
                        this.lastException = new IOException(string.Format(
                            CultureInfo.InvariantCulture,
                            SR.BlobDataCorrupted,
                            this.blobProperties.ContentMD5,
                            computedMD5));
                    }
                }
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
                if (this.blobMD5 != null)
                {
                    this.blobMD5.Dispose();
                    this.blobMD5 = null;
                }

                if (this.internalBuffer != null)
                {
                    this.internalBuffer.Dispose();
                    this.internalBuffer = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
