// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Job Details for a single service copy job
    /// </summary>
    public class BlobTransferCopyJobDetails : StorageTransferJobDetails
    {
        /// <summary>
        /// The source Uri
        /// </summary>
        public Uri sourceUri { get; internal set; }

        /// <summary>
        /// The destination blob client for the copy job
        /// </summary>
        public BlobBaseClient destinationBlobClient { get; internal set; }

        /// <summary>
        /// Type of Copy to occur
        /// </summary>
        public BlobServiceCopyMethod CopyMethod { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobCopyFromUriOptions"/>.
        /// </summary>
        public BlobCopyFromUriOptions CopyFromUriOptions { get; internal set; }
    }
}
