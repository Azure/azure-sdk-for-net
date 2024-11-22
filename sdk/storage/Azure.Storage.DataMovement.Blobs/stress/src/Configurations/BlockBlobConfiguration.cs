// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseBlobs;

using BaseBlobs::Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    /// <summary>
    /// The set of configurations when creating a block blob.
    /// </summary>
    internal class BlockBlobConfiguration
    {
        /// <summary>
        /// The value to use for <see cref="BlobClientOptions" /> when configuring a <see cref="BlockBlobClient" />.
        /// </summary>
        public BlobClientOptions options = new BlobClientOptions();
    }
}
