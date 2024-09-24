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
    public class BlobSingleUploadScenario : BlobScenarioBase
    {
        private TransferManagerOptions _transferManagerOptions;
        private DataTransferOptions _dataTransferOptions;
        public BlobSingleUploadScenario(
            Uri destinationBlobUri,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, tokenCredential, metrics, testRunId)
        {
            _transferManagerOptions = transferManagerOptions;
            _dataTransferOptions = dataTransferOptions;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.UploadSingleBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationContainerName = ConfigurationHelper.Randomize("container");
            string blobName = ConfigurationHelper.Randomize("blob");
            var blobSize = 1024 * 1024 * 1024;
            var blockSize = 4 * 1024 * 1024;
            var blockCount = blobSize / blockSize;

            var sourceStream = new MemoryStream(blobSize);
            var random = new Random();
            var buffer = new byte[blockSize];
            random.NextBytes(buffer);
            for (int i = 0; i < blockCount; i++)
            {
                sourceStream.Write(buffer, 0, blockSize);
            }
            sourceStream.Seek(0, SeekOrigin.Begin);

            // Create Local Source Storage Resource
            Console.Out.WriteLine($"Creating temporary file storage resource from directory: {disposingLocalDirectory.DirectoryPath}");
            StorageResource sourceResource = await ConfigurationHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_destinationBlobUri)
            {
                BlobContainerName = destinationContainerName,
                BlobName = blobName
            };
            Console.Out.WriteLine($"Creating destination storage resource from blob: {blobUriBuilder.ToUri().AbsoluteUri}");
            StorageResource destinationResource = _blobsStorageResourceProvider.FromBlob(blobUriBuilder.ToUri().AbsoluteUri);

            // Start Transfer
            TransferManager transferManager = new TransferManager(_transferManagerOptions);
            Console.Out.WriteLine($"Starting transfer from {sourceResource.Uri.AbsoluteUri} to {destinationResource.Uri.AbsoluteUri}");
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                _dataTransferOptions,
                cancellationToken: cancellationToken);

            // Wait for transfer to finish
            await transfer.WaitForCompletionAsync(cancellationToken);
            Console.Out.WriteLine($"Transfer completed successfully.");

            // Verify / Assert - Download Destination Blob and verify
            BlockBlobClient blockBlobClient = new BlockBlobClient(blobUriBuilder.ToUri(), _tokenCredential);
            Console.Out.WriteLine($"Downloading blob to stream: {blockBlobClient.Uri.AbsoluteUri}");
            using Stream targetStream = await blockBlobClient.OpenReadAsync(default, cancellationToken);

            // Assert
            Console.Out.WriteLine($"Verifying source and target stream match");
            Console.Out.WriteLine($"Source Stream Length: {sourceStream.Length}");
            Console.Out.WriteLine($"Target Stream Length: {targetStream.Length}");
            Assert.AreEqual(sourceStream.Length, targetStream.Length);
            if (sourceStream.Equals(targetStream))
            {
                Console.Out.WriteLine("Source and target stream match");
            }
            else
            {
                Console.Out.WriteLine("Source and target stream do not match");
            }
            //Assert.IsTrue(sourceStream.ToArray().SequenceEqual(targetStream.ToArray()));
        }
    }
}
