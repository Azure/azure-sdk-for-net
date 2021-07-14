// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobCopyTransferJob : StorageTransferJob
    {
        internal BlobBaseClient _destinationBlobClient;

        public BlobBaseClient destinationBlobClient => _destinationBlobClient;

        private BlobBaseClient _sourceBlobClient;

        public BlobBaseClient sourceBlobClient => _sourceBlobClient;

        public readonly CopyMethod _copyMethod;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        internal StorageTransferOptions _transferOptions;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public StorageTransferOptions TransferOptions => _transferOptions;

        // Creates Copy Transfer Job
        public BlobCopyTransferJob(
            BlobBaseClient sourceClient,
            BlobBaseClient destinationClient,
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

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task CreateTransferTaskAsync()
        {
            // TODO: add other Copymethod Options
            // for now only do CopyMethod.ServiceSideAsyncCopy as a stub
            return destinationBlobClient.StartCopyFromUriAsync(sourceBlobClient.Uri, cancellationToken: CancellationToken);
        }
    }
}
