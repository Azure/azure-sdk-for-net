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
    internal class BlobServiceCopyDirectoryTransferJob : StorageTransferJob
    {
        private Uri _sourceDirectoryUri;

        public Uri SourceDirectoryUri => _sourceDirectoryUri;

        internal BlobVirtualDirectoryClient _destinationBlobClient;

        public BlobVirtualDirectoryClient destinationBlobClient => _destinationBlobClient;

        public readonly ServiceCopyMethod _copyMethod;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        internal BlobDirectoryCopyFromUriOptions _copyFromUriOptions;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public BlobDirectoryCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<Uri> localTransferItems;
        internal Queue<Uri> sourceTransferItems;

        /// <summary>
        /// Creates Service Copy Directory Transfer Job
        ///
        /// TODO; better descriptions and update parameter descriptions
        /// </summary>
        /// <param name="sourceDirectoryUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobServiceCopyDirectoryTransferJob(
            Uri sourceDirectoryUri,
            BlobVirtualDirectoryClient destinationClient,
            ServiceCopyMethod copyMethod,
            BlobDirectoryCopyFromUriOptions copyFromUriOptions,
            CancellationToken cancellationToken)
        {
            _sourceDirectoryUri = sourceDirectoryUri;
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
            // TODO: implement download the blob and store it and upload to the destination.
            return destinationBlobClient.StartCopyFromUriAsync(SourceDirectoryUri, CopyFromUriOptions, CancellationToken);
        }
    }
}
