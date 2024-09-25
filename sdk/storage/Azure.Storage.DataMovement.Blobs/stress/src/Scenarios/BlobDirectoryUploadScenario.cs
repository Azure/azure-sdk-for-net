// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Tests;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class BlobDirectoryUploadScenario : BlobScenarioBase
    {
        private int _blobSize;
        private int _blobCount;
        public BlobDirectoryUploadScenario(
            Uri destinationBlobUri,
            int blobSize,
            int blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobSize = blobSize;
            _blobCount = blobCount;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.UploadDirectoryBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            // Create test local directory
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create destination blob container
            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _destinationServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();

            // Create Local Files
            await TestSetupHelper.CreateLocalFilesToUploadAsync(disposingLocalDirectory.DirectoryPath, _blobCount, _blobSize);

            // Create Local Source Storage Resource
            Console.Out.WriteLine($"Creating temporary file storage resource from directory: {disposingLocalDirectory.DirectoryPath}");
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_destinationBlobUri)
            {
                BlobContainerName = destinationContainerName,
            };
            StorageResource destinationResource = _blobsStorageResourceProvider.FromContainer(blobUriBuilder.ToUri().AbsoluteUri);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager();

            // Upload
            Console.Out.WriteLine($"Starting transfer from {sourceResource.Uri.AbsoluteUri} to {destinationResource.Uri.AbsoluteUri}");

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
