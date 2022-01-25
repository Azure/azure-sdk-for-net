// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Transfer Details for Blob Directory Copy
    /// </summary>
    public class BlobTransferCopyDirectoryJobDetails : StorageTransferJobDetails
    {
        /// <summary>
        /// Constructor internal.
        /// </summary>
        internal BlobTransferCopyDirectoryJobDetails() : base(){ }
        /// <summary>
        /// Source Directory Uri jobs.
        /// </summary>
        public Uri SourceDirectoryUri { get; internal set; }

        /// <summary>
        /// Destination directory for the finished copies
        /// </summary>
        public BlobVirtualDirectoryClient DestinationDirectoryClient { get; internal set; }

        /// <summary>
        /// Copy method to choose between StartCopyFromUri or SyncCopyFromUri
        /// </summary>
        public BlobServiceCopyMethod CopyMethod { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDirectoryCopyFromUriOptions"/>.
        /// </summary>
        public BlobDirectoryCopyFromUriOptions CopyFromUriOptions { get; internal set; }
    }
}
