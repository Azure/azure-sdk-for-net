// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobCopyDirectoryTransferJob : StorageTransferJob
    {
        internal BlobDirectoryClient _destinationBlobClient;

        public BlobDirectoryClient destinationBlobClient => _destinationBlobClient;

        private BlobDirectoryClient _sourceBlobClient;

        public BlobDirectoryClient sourceBlobClient => _sourceBlobClient;

        public readonly CopyMethod _copyMethod;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        internal StorageTransferOptions _transferOptions;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public StorageTransferOptions TransferOptions => _transferOptions;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<string> localTransferItems;
        internal Queue<Uri> sourceTransferItems;

        // Creates Copy Transfer Job
        public BlobCopyDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            BlobDirectoryClient destinationClient,
            CopyMethod copyMethod,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            _sourceBlobClient = sourceClient;
            _destinationBlobClient = destinationClient;
            _copyMethod = copyMethod;
            _transferOptions = transferOptions;
            CancellationToken = cancellationToken;
        }
    }
}
