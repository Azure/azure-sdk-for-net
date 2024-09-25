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
    public class BlobSingleDownloadScenario : BlobScenarioBase
    {
        private int _blobSize;
        public BlobSingleDownloadScenario(
            Uri sourceBlobUri,
            int blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobSize = blobSize;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSingleBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _destinationServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync();

            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();

            string blobName = TestSetupHelper.Randomize("blob");

            // Create Source Storage Resource
            BlockBlobClient sourceBlob = sourceContainerClient.GetBlockBlobClient(blobName);
            await BlobTestSetupHelper.CreateBlockBlobAsync(
                sourceContainerClient.GetBlockBlobClient(blobName),
                _blobSize,
                cancellationToken);
            StorageResource sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);

            // Create Local Destination Storage Resource
            StorageResource destinationResource = _localFilesStorageResourceProvider.FromFile(Path.Combine(disposingLocalDirectory.DirectoryPath,blobName));

            // Start Transfer
            TransferManager transferManager = new TransferManager(_transferManagerOptions);
            Console.Out.WriteLine($"Starting transfer from {sourceResource.Uri.AbsoluteUri} to {destinationResource.Uri.AbsoluteUri}");
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource as StorageResourceItem,
                destinationResource as StorageResourceItem,
                async cToken => await sourceBlob.OpenReadAsync(default, cToken),
                cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
