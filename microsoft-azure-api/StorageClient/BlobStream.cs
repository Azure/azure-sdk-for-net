//-----------------------------------------------------------------------
// <copyright file="BlobStream.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the BlobStream class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents a stream for reading and writing to a blob.
    /// </summary>
    public abstract class BlobStream : Stream
    {
        /// <summary>
        /// Gets a reference to the blob on which the stream is opened.
        /// </summary>
        /// <value>The blob this stream accesses.</value>
        public CloudBlob Blob { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the signature of each block should be verified.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if integrity control verification is enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IntegrityControlVerificationEnabled
        {
            get
            {
                return true;
            }

            internal set
            {
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes to read ahead.
        /// </summary>
        /// <value>The number of bytes to read ahead.</value>
        /// <remarks>
        /// This operation is not currently supported.
        /// </remarks>
        public virtual long ReadAheadSize
        {
            get { throw new NotSupportedException(); }
             set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets or sets the block size.
        /// </summary>
        /// <value>The size of the block.</value>
        /// <remarks>
        /// This operation is not currently supported.
        /// </remarks>
        public virtual long BlockSize
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Aborts the operation to write to the blob. 
        /// </summary>
        public virtual void Abort()
        {
        }

        /// <summary>
        /// Begins an asynchronous operation to commit a blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        /// <remarks>
        /// This operation is not currently supported.
        /// </remarks>
        public virtual IAsyncResult BeginCommit(AsyncCallback callback, object state)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Ends an asynchronous operation to commit the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <exception cref="ArgumentNullException">asyncResult is null</exception>
        /// <remarks>
        /// This operation is not currently supported.
        /// </remarks>
        public virtual void EndCommit(IAsyncResult asyncResult)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Commits the blob.
        /// </summary>
        /// <remarks>
        /// This operation is not currently supported.
        /// </remarks>
        public virtual void Commit()
        {
            throw new NotSupportedException();
        }        
    }
}
