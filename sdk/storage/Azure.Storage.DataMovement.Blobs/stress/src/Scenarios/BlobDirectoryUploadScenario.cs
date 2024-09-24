// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class BlobDirectoryUploadScenario : BlobScenarioBase
    {
        public BlobDirectoryUploadScenario(
            Uri destinationBlobUri,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, tokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.UploadDirectoryBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            // Create test local directory
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create destination blob container
            string destinationContainerName = ConfigurationHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _destinationServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();

            var blobCount = 3000;
            var blobSize = 1024 * 1024 * 1024;
            var blockSize = 4 * 1024 * 1024;
            var blockCount = blobSize / blockSize;

            // Create Local Files
            await CreateLocalFilesToUploadAsync(disposingLocalDirectory.DirectoryPath, blobCount, blobSize);

            // Create Local Source Storage Resource
            Console.Out.WriteLine($"Creating temporary file storage resource from directory: {disposingLocalDirectory.DirectoryPath}");
            StorageResource sourceResource = await ConfigurationHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

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
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, cancellationToken: cancellationToken);

            /*
            await new TransferValidator()
            {
                TransferManager = new(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath),
                TransferValidator.GetBlobLister(destinationContainerClient, default),
                expectedTransfers,
                options,
                cancellationToken);
            */
        }
    }
}
