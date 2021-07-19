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
    internal class BlobServiceCopyTransferJob : StorageTransferJob
    {
        internal BlobBaseClient _destinationBlobClient;

        public BlobBaseClient destinationBlobClient => _destinationBlobClient;

        private BlobBaseClient _sourceBlobClient;

        public BlobBaseClient sourceBlobClient => _sourceBlobClient;

        public readonly ServiceCopyMethod _copyMethod;

        internal BlobCopyFromUriOptions _copyFromUriOptions;
        /// <summary>
        /// Gets the <see cref="BlobCopyFromUriOptions"/>.
        /// </summary>
        public BlobCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

        /// <summary>
        /// Creates Single Copy Transfer Job
        ///
        /// TODO: better description and param descriptions.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobServiceCopyTransferJob(
            BlobBaseClient sourceClient,
            BlobBaseClient destinationClient,
            ServiceCopyMethod copyMethod,
            BlobCopyFromUriOptions copyFromUriOptions,
            CancellationToken cancellationToken)
        {
            _sourceBlobClient = sourceClient;
            _destinationBlobClient = destinationClient;
            _copyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task StartTransferTaskAsync()
        {
            // TODO: add other Copymethod Options
            // for now only do CopyMethod.ServiceSideAsyncCopy as a stub
            return destinationBlobClient.StartCopyFromUriAsync(sourceBlobClient.Uri, cancellationToken: CancellationToken);
        }
    }
}
