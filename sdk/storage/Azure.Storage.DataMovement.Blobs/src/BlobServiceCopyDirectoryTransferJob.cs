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
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobServiceCopyDirectoryTransferJob : TransferJobInternal
    {
        private Uri _sourceDirectoryUri;

        public Uri SourceDirectoryUri => _sourceDirectoryUri;

        internal BlobVirtualDirectoryClient _destinationDirectoryClient;

        public BlobVirtualDirectoryClient DestinationDirectoryClient => _destinationDirectoryClient;

        /// <summary>
        /// Copy method to choose between StartCopyFromUri or SyncCopyFromUri
        /// </summary>
        internal readonly BlobServiceCopyMethod CopyMethod;

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
        public BlobServiceCopyDirectoryTransferJob(
            string jobId,
            Uri sourceDirectoryUri,
            BlobVirtualDirectoryClient destinationClient,
            BlobServiceCopyMethod copyMethod,
            BlobDirectoryCopyFromUriOptions copyFromUriOptions)
            : base(jobId)
        {
            _sourceDirectoryUri = sourceDirectoryUri;
            _destinationDirectoryClient = destinationClient;
            CopyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
        }

        /// <summary>
        /// Gets sing copy job for the job scheduler
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        internal async Task<CopyFromUriOperation> GetSingleAsyncCopyTaskAsync(string blobName)
        {
            //TODO: check if the listing operation gives the full blob path name or just everything but the prefix
            BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceDirectoryUri);
            sourceUriBuilder.BlobName += $"/{blobName}";

            BlockBlobClient blockBlobClient = DestinationDirectoryClient.GetBlockBlobClient(blobName);

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                Metadata = CopyFromUriOptions.Metadata,
                Tags = CopyFromUriOptions.Tags,
                AccessTier = CopyFromUriOptions.AccessTier,
                SourceConditions = new BlobRequestConditions
                {
                    IfModifiedSince = CopyFromUriOptions?.SourceConditions?.IfModifiedSince,
                    IfUnmodifiedSince = CopyFromUriOptions?.SourceConditions?.IfUnmodifiedSince,
                },
                DestinationConditions = new BlobRequestConditions
                {
                    IfModifiedSince = CopyFromUriOptions?.SourceConditions?.IfModifiedSince,
                    IfUnmodifiedSince = CopyFromUriOptions?.SourceConditions?.IfUnmodifiedSince,
                },
                RehydratePriority = CopyFromUriOptions.RehydratePriority,
                ShouldSealDestination = CopyFromUriOptions.ShouldSealDestination,
                DestinationImmutabilityPolicy = CopyFromUriOptions.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions.LegalHold,
                SourceAuthentication = CopyFromUriOptions.SourceAuthentication,
            };

            return await blockBlobClient.StartCopyFromUriAsync(SourceDirectoryUri, blobCopyFromUriOptions).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets sing copy job for the job scheduler
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        internal async Task<Response<BlobCopyInfo>> GetSingleSyncCopyTaskAsync(string blobName)
        {
            //TODO: check if the listing operation gives the full blob path name or just everything but the prefix
            BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceDirectoryUri);
            sourceUriBuilder.BlobName += $"/{blobName}";

            BlockBlobClient blockBlobClient = DestinationDirectoryClient.GetBlockBlobClient(blobName);

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                Metadata = CopyFromUriOptions.Metadata,
                Tags = CopyFromUriOptions.Tags,
                AccessTier = CopyFromUriOptions.AccessTier,
                SourceConditions = new BlobRequestConditions
                {
                    IfModifiedSince = CopyFromUriOptions?.SourceConditions?.IfModifiedSince,
                    IfUnmodifiedSince = CopyFromUriOptions?.SourceConditions?.IfUnmodifiedSince,
                },
                DestinationConditions = new BlobRequestConditions
                {
                    IfModifiedSince = CopyFromUriOptions?.SourceConditions?.IfModifiedSince,
                    IfUnmodifiedSince = CopyFromUriOptions?.SourceConditions?.IfUnmodifiedSince,
                },
                RehydratePriority = CopyFromUriOptions.RehydratePriority,
                ShouldSealDestination = CopyFromUriOptions.ShouldSealDestination,
                DestinationImmutabilityPolicy = CopyFromUriOptions.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions.LegalHold,
                SourceAuthentication = CopyFromUriOptions.SourceAuthentication,
            };

            return await blockBlobClient.SyncCopyFromUriAsync(SourceDirectoryUri, blobCopyFromUriOptions).ConfigureAwait(false);
        }
    }
}
