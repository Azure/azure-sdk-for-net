// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class CopyBlobDirectoryScenarioBase : BlobScenarioBase
    {
        private int _blobCount;
        private readonly BlobServiceClient _sourceServiceClient;

        public CopyBlobDirectoryScenarioBase(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, dataTransferOptions, destinationTokenCredential, metrics, testRunId)
        {
            _sourceServiceClient = new BlobServiceClient(sourceBlobUri, sourceTokenCredential);
            _blobCount = blobCount ?? DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            string pathPrefix = TestSetupHelper.Randomize("dir");
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _sourceServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync();
            await BlobTestSetupHelper.CreateBlobsInDirectoryAsync(
                sourceContainerClient,
                blobType,
                pathPrefix,
                _blobCount,
                _blobSize,
                cancellationToken);

            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _blobServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();

            // Create Source Blob Container Storage Resource
            StorageResource sourceResource = _blobsStorageResourceProvider.FromClient(sourceContainerClient, new() { BlobDirectoryPrefix = pathPrefix });

            // Create Destination Blob Container Storage Resource
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(
                destinationContainerClient,
                new()
                {
                    BlobDirectoryPrefix = pathPrefix,
                    BlobType = new(blobType)
                });

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetBlobLister(sourceContainerClient, pathPrefix),
                TransferValidator.GetBlobLister(destinationContainerClient, pathPrefix),
                _blobCount,
                _dataTransferOptions,
                cancellationToken);
        }
    }
}
