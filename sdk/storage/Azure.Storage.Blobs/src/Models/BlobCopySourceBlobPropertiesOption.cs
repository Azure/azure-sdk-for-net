// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The copy source blob properties behavior for <see cref="BlockBlobClient.PutBlobFromUrl"/>.
    /// </summary>
    public enum BlobCopySourceBlobPropertiesOption
    {
        /// <summary>
        /// Source blob's properties will be copied to the new blob.
        /// </summary>
        Copy,

        /// <summary>
        /// Source blob's properties will be overwritten on the new blob.
        /// Note that the source blob's properties will not be changed.
        /// </summary>
        Overwrite
    }
}
