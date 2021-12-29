// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
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
        /// The <see cref="BlobDirectoryCopyFromUriOptions"/>.
        /// </summary>
        internal BlobDirectoryCopyFromUriOptions _copyFromUriOptions;
        /// <summary>
        /// Gets the <see cref="BlobDirectoryCopyFromUriOptions"/>.
        /// </summary>
        public BlobDirectoryCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

        /// <summary>
        /// Creates Service Copy Directory Transfer Job
        ///
        /// TODO; better descriptions and update parameter descriptions
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceDirectoryUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobServiceCopyDirectoryTransferJob(
            string jobId,
            Uri sourceDirectoryUri,
            BlobVirtualDirectoryClient destinationClient,
            ServiceCopyMethod copyMethod,
            BlobDirectoryCopyFromUriOptions copyFromUriOptions,
            CancellationToken cancellationToken)
            : base(jobId)
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
            return Task.CompletedTask;
            //return destinationBlobClient.StartCopyFromUriAsync(SourceDirectoryUri, CopyFromUriOptions, CancellationToken);
        }
    }
}
