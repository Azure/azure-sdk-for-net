// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Tests;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class UploadBlobDirectoryScenarioBase : BlobScenarioBase
    {
        private int _blobCount;
        public UploadBlobDirectoryScenarioBase(
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobCount = blobCount != default ? blobCount.Value : DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            // Create test local directory
            string pathPrefix = TestSetupHelper.Randomize("dir");
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory(pathPrefix);

            // Create destination blob container
            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _blobServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();

            // Create Local Files
            await TestSetupHelper.CreateLocalFilesToUploadAsync(
                disposingLocalDirectory.DirectoryPath,
                _blobCount,
                _blobSize);

            // Create Local Source Storage Resource
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(
                destinationContainerClient,
                new()
                {
                    BlobDirectoryPrefix = pathPrefix,
                    BlobType = new(blobType)
                });

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager();

            // Upload
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath),
                TransferValidator.GetBlobLister(destinationContainerClient, default),
                _blobCount,
                _dataTransferOptions,
                cancellationToken);
        }
    }
}
