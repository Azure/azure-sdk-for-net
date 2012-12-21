//-----------------------------------------------------------------------
// <copyright file="ICloudBlobBase.cs" company="Microsoft">
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

    /// <summary>
    /// An interface required for Windows Azure blob types. The <see cref="CloudBlockBlob"/> and <see cref="CloudPageBlob"/> classes implement the <see cref="ICloudBlob"/> interface.
    /// </summary>
    public partial interface ICloudBlob : IListBlobItem
    {
        /// <summary>
        /// Gets the blob item's name.
        /// </summary>
        /// <value>The blob item's name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the <see cref="CloudBlobClient"/> object that represents the Blob service.
        /// </summary>
        /// <value>A client object that specifies the Blob service endpoint.</value>
        CloudBlobClient ServiceClient { get; }

        /// <summary>
        /// Gets or sets the number of bytes to buffer when writing to a page blob stream or
        /// the block size for writing to a block blob.
        /// </summary>
        /// <value>The number of bytes to buffer or the size of a block, in bytes.</value>
        int StreamWriteSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of bytes to buffer when reading from a blob stream.
        /// </summary>
        /// <value>The minimum number of bytes to buffer.</value>
        int StreamMinimumReadSizeInBytes { get; set; }

        /// <summary>
        /// Gets the blob's system properties.
        /// </summary>
        /// <value>The blob's properties.</value>
        BlobProperties Properties { get; }

        /// <summary>
        /// Gets the user-defined metadata for the blob.
        /// </summary>
        /// <value>The blob's metadata, as a collection of name-value pairs.</value>
        IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets the date and time that the blob snapshot was taken, if this blob is a snapshot.
        /// </summary>
        /// <value>The blob's snapshot time if the blob is a snapshot; otherwise, <c>null</c>.</value>
        /// <remarks>
        /// If the blob is not a snapshot, the value of this property is <c>null</c>.
        /// </remarks>
        DateTimeOffset? SnapshotTime { get; }

        /// <summary>
        /// Gets the state of the most recent or pending copy operation.
        /// </summary>
        /// <value>A <see cref="CopyState"/> object containing the copy state, or null if no copy blob state exists for this blob.</value>
        CopyState CopyState { get; }

        /// <summary>
        /// Gets the type of the blob.
        /// </summary>
        /// <value>The type of the blob.</value>
        BlobType BlobType { get; }

        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>A shared access signature.</returns>
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy);

        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>A shared access signature.</returns>
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier);
    }
}
