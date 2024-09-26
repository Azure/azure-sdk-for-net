// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class BlobSingleUploadScenario : BlobScenarioBase
    {
        private int _blobSize;
        public BlobSingleUploadScenario(
            Uri destinationBlobUri,
            int blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobSize = blobSize;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.UploadSingleBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _destinationServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();
            string blobName = TestSetupHelper.Randomize("blob");

            // Create Local Source Storage Resource
            Console.Out.WriteLine($"Creating temporary file storage resource from directory: {disposingLocalDirectory.DirectoryPath}");
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(
                disposingLocalDirectory.DirectoryPath,
                fileName: blobName,
                fileSize: _blobSize,
                cancellationToken: cancellationToken);

            // Create Destination Storage Resource
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_destinationBlobUri)
            {
                BlobContainerName = destinationContainerName,
                BlobName = blobName
            };
            BlockBlobClient destinationBlob = destinationContainerClient.GetBlockBlobClient(blobName);
            Console.Out.WriteLine($"Creating destination storage resource from blob: {blobUriBuilder.ToUri().AbsoluteUri}");
            StorageResource destinationResource = _blobsStorageResourceProvider.FromBlob(blobUriBuilder.ToUri().AbsoluteUri);

            // Start Transfer
            Console.Out.WriteLine($"Creating transferManager");
            TransferManager transferManager = new TransferManager(_transferManagerOptions);
            Console.Out.WriteLine($"Starting transfer from {sourceResource.Uri.AbsoluteUri} to {destinationResource.Uri.AbsoluteUri}");
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
                async cToken => await destinationBlob.OpenReadAsync(default, cToken),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
