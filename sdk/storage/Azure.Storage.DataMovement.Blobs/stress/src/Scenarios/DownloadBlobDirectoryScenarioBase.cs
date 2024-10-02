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
    public abstract class DownloadBlobDirectoryScenarioBase : BlobScenarioBase
    {
        private int _blobCount;
        public DownloadBlobDirectoryScenarioBase(
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) :
            base(destinationBlobUri, blobSize, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobCount = blobCount != default ? blobCount.Value : DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            // Create Source Blob Container
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _blobServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

            // Create Destination Test Local Directory
            string pathPrefix = TestSetupHelper.Randomize("dir");
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory(pathPrefix);

            // Create Blobs in source container
            await BlobTestSetupHelper.CreateBlobsInDirectoryAsync(
                sourceContainerClient,
                blobType,
                pathPrefix,
                _blobCount,
                _blobSize,
                cancellationToken);

            // Create Destination Local Storage Resource
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(sourceContainerClient, new() { BlobDirectoryPrefix = pathPrefix });

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager();

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetBlobLister(sourceContainerClient, pathPrefix),
                TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath),
                _blobCount,
                _dataTransferOptions,
                cancellationToken);
        }
    }
}
