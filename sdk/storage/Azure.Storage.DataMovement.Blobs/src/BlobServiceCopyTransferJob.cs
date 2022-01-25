// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobServiceCopyTransferJob : TransferJobInternal
    {
        private Uri _sourceUri;

        /// <summary>
        /// The source Uri
        /// </summary>
        public Uri SourceUri => _sourceUri;

        internal BlobBaseClient _destinationBlobClient;

        /// <summary>
        /// The destination blob client for the copy job
        /// </summary>
        public BlobBaseClient DestinationBlobClient => _destinationBlobClient;

        /// <summary>
        /// Type of Copy to occur
        /// </summary>
        public readonly BlobServiceCopyMethod CopyMethod;

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
        /// <param name="jobId"></param>
        /// <param name="sourceUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        public BlobServiceCopyTransferJob(
            string jobId,
            Uri sourceUri,
            BlobBaseClient destinationClient,
            BlobServiceCopyMethod copyMethod,
            BlobCopyFromUriOptions copyFromUriOptions)
            : base(jobId)
        {
            _sourceUri = sourceUri;
            _destinationBlobClient = destinationClient;
            CopyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public Task StartTransferTaskAsync()
        {
            // TODO: add other Copymethod Options
            // for now only do CopyMethod.ServiceSideAsyncCopy as a stub
            return DestinationBlobClient.StartCopyFromUriAsync(SourceUri);
        }
    }
}
