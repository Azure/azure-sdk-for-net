//-----------------------------------------------------------------------
// <copyright file="BlobWriteStreamBase.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    internal abstract class BlobWriteStreamBase : Stream
    {
        protected CloudBlockBlob blockBlob;
        protected CloudPageBlob pageBlob;
        protected long pageBlobSize;
        protected bool newPageBlob;
        protected long currentOffset;
        protected long currentPageOffset;
        protected MemoryStream buffer;
        protected List<string> blockList;
        protected string blockIdPrefix;
        protected AccessCondition accessCondition;
        protected BlobRequestOptions options;
        protected OperationContext operationContext;
        protected int pendingWrites;
        protected ManualResetEvent noPendingWritesEvent;
        protected MD5Wrapper blobMD5;
        protected MD5Wrapper blockMD5;
        protected AsyncSemaphore parallelOperationSemaphore;
        protected Exception lastException;

        /// <summary>
        /// Initializes a new instance of the BlobWriteStreamBase class.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        private BlobWriteStreamBase(CloudBlobClient serviceClient, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : base()
        {
            this.currentOffset = 0;
            this.accessCondition = accessCondition;
            this.options = options;
            this.operationContext = operationContext;
            this.pendingWrites = 0;
            this.noPendingWritesEvent = new ManualResetEvent(true);
            this.blobMD5 = options.StoreBlobContentMD5.Value ? new MD5Wrapper() : null;
            this.blockMD5 = options.UseTransactionalMD5.Value ? new MD5Wrapper() : null;
            this.parallelOperationSemaphore = new AsyncSemaphore(serviceClient.ParallelOperationThreadCount);
            this.lastException = null;
        }

        /// <summary>
        /// Initializes a new instance of the BlobWriteStreamBase class for a block blob.
        /// </summary>
        /// <param name="blockBlob">Blob reference to write to.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        protected BlobWriteStreamBase(CloudBlockBlob blockBlob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : this(blockBlob.ServiceClient, accessCondition, options, operationContext)
        {
            this.blockBlob = blockBlob;
            this.blockList = new List<string>();
            this.blockIdPrefix = new Random().Next().ToString("X8") + "-";
            this.buffer = new MemoryStream(this.Blob.StreamWriteSizeInBytes);
        }

        /// <summary>
        /// Initializes a new instance of the BlobWriteStreamBase class for a page blob.
        /// </summary>
        /// <param name="pageBlob">Blob reference to write to.</param>
        /// <param name="pageBlobSize">Size of the page blob.</param>
        /// <param name="createNew">Use <c>true</c> if the page blob is newly created, <c>false</c> otherwise.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        protected BlobWriteStreamBase(CloudPageBlob pageBlob, long pageBlobSize, bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
            : this(pageBlob.ServiceClient, accessCondition, options, operationContext)
        {
            this.currentPageOffset = 0;
            this.pageBlob = pageBlob;
            this.pageBlobSize = pageBlobSize;
            this.newPageBlob = createNew;
            this.buffer = new MemoryStream(this.Blob.StreamWriteSizeInBytes);
        }

        protected ICloudBlob Blob
        {
            get
            {
                return (ICloudBlob)this.blockBlob ?? (ICloudBlob)this.pageBlob;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get
            {
                return this.pageBlob != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get
            {
                if (this.pageBlob != null)
                {
                    return this.pageBlobSize;
                }
                else
                {
                    throw new NotSupportedException();
                }
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
        /// This operation is not supported in BlobWriteStreamBase.
        /// </summary>
        /// <param name="buffer">Not used.</param>
        /// <param name="offset">Not used.</param>
        /// <param name="count">Not used.</param>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
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
            if (!this.CanSeek)
            {
                throw new NotSupportedException();
            }

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

            if ((newOffset % Constants.PageSize) != 0)
            {
                CommonUtils.ArgumentOutOfRange("offset", offset);
            }

            return newOffset;
        }

        /// <summary>
        /// This operation is not supported in BlobWriteStreamBase.
        /// </summary>
        /// <param name="value">Not used.</param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Generates a new block ID to be used for PutBlock.
        /// </summary>
        /// <returns>Base64 encoded block ID</returns>
        protected string GetCurrentBlockId()
        {
            string blockIdSuffix = this.blockList.Count.ToString("D6");
            byte[] blockIdInBytes = Encoding.UTF8.GetBytes(this.blockIdPrefix + blockIdSuffix);
            return Convert.ToBase64String(blockIdInBytes);
        }
    }
}
