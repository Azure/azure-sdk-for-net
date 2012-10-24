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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    internal abstract class BlobReadStreamBase : Stream
    {
        protected ICloudBlob blob;
        protected bool isLengthAvailable;
        protected long currentOffset;
        protected MemoryStream buffer;
        protected AccessCondition accessCondition;
        private bool lockedToETag;
        protected BlobRequestOptions options;
        protected OperationContext operationContext;
        protected MD5Wrapper blobMD5;
        protected Exception lastException;

        /// <summary>
        /// Initializes a new instance of the BlobReadStreamBase class.
        /// </summary>
        /// <param name="blob">Blob reference to read from</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        protected BlobReadStreamBase(ICloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.blob = blob;
            this.isLengthAvailable = false;
            this.currentOffset = 0;
            this.buffer = new MemoryStream();
            this.accessCondition = accessCondition;
            this.lockedToETag = false;
            this.options = options;
            this.operationContext = operationContext;
            this.blobMD5 = options.DisableContentMD5Validation.Value ? null : new MD5Wrapper();
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
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type <c>SeekOrigin</c> indicating the reference
        /// point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
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
                    CommonUtils.ArgumentOutOfRange("origin", origin);
                    throw new ArgumentOutOfRangeException();
            }

            CommonUtils.AssertInBounds("offset", newOffset, 0, this.Length);

            if (newOffset != this.currentOffset)
            {
                this.blobMD5 = null;
                this.buffer.SetLength(0);
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
        /// This operation is not supported in BlobReadStreamBase.
        /// </summary>
        public override void Flush()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Locks all further read operations to the current ETag value.
        /// Therefore, if someone else writes to the blob while we are reading,
        /// all our operations will start failing with condition mismatch error.
        /// </summary>
        protected void LockToETag()
        {
            if (!this.lockedToETag)
            {
                AccessCondition accessCondition = AccessCondition.GenerateIfMatchCondition(this.blob.Properties.ETag);
                if (this.accessCondition != null)
                {
                    accessCondition.LeaseId = this.accessCondition.LeaseId;
                }

                this.accessCondition = accessCondition;
                this.lockedToETag = true;
            }
        }

        /// <summary>
        /// Updates the blob MD5 with newly downloaded content.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        protected void VerifyBlobMD5(byte[] buffer, int offset, int count)
        {
            if ((this.blobMD5 != null) && (this.lastException == null))
            {
                this.blobMD5.UpdateHash(buffer, offset, count);

                if ((this.currentOffset == this.Length) &&
                    !string.IsNullOrEmpty(this.blob.Properties.ContentMD5))
                {
                    string computedMD5 = this.blobMD5.ComputeHash();
                    this.blobMD5 = null;
                    if (!computedMD5.Equals(this.blob.Properties.ContentMD5))
                    {
                        this.lastException = new IOException(string.Format(
                            SR.BlobDataCorrupted,
                            this.blob.Properties.ContentMD5,
                            computedMD5));
                    }
                }
            }
        }
    }
}
