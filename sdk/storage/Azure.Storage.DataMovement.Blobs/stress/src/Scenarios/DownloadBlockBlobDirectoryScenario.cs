// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class DownloadBlockBlobDirectoryScenario : BlobScenarioBase
    {
        private int _blobSize;
        private int _blobCount;
        public DownloadBlockBlobDirectoryScenario(
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) :
            base(destinationBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobSize = blobSize != default ? blobSize.Value : DataMovementBlobStressConstants.DefaultObjectSize;
            _blobCount = blobCount != default ? blobCount.Value : DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadDirectoryBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            // Create Source Blob Container
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _destinationServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

            // Create Destination Test Local Directory
            string pathPrefix = TestSetupHelper.Randomize("dir");
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory(pathPrefix);

            // Create Blobs in source container
            await BlobTestSetupHelper.CreateDirectoryBlockBlobsAsync(
                sourceContainerClient,
                pathPrefix,
                _blobCount,
                _blobSize,
                cancellationToken);

            // Create Destination Local Storage Resource
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(sourceContainerClient);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager();

            // Upload
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
