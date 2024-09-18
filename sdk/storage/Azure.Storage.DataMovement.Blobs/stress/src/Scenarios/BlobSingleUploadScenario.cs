// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class BlobSingleUploadScenario : BlobUploadScenarioBase
    {
        public BlobSingleUploadScenario(
            Uri destinationBlobUri,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, tokenCredential, metrics, testRunId)
        {
        }

        public override string Name => "blobSingleUpload";

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationContainerName = ConfigurationHelper.Randomize("container-");
            string blobName = ConfigurationHelper.Randomize("blob-");
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
            StorageResource sourceResource = await ConfigurationHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

            // Create Destination Storage Resource
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_destinationBlobUri)
            {
                BlobContainerName = destinationContainerName,
                BlobName = blobName
            };
            StorageResource destinationResource = _blobsStorageResourceProvider.FromBlob(blobUriBuilder.ToUri().AbsoluteUri);

            // Start Transfer
            TransferManager transferManager = new TransferManager();
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, cancellationToken: cancellationToken);

            // Wait for transfer to finish
            await transfer.WaitForCompletionAsync(cancellationToken);

            // Verify / Assert - Download Destination Blob and verify
            BlockBlobClient blockBlobClient = new BlockBlobClient(blobUriBuilder.ToUri(), _tokenCredential);
            using MemoryStream targetStream = new MemoryStream();
            await blockBlobClient.DownloadToAsync(targetStream, cancellationToken);
            targetStream.Seek(0, SeekOrigin.Begin);

            // Assert
            Assert.AreEqual(sourceStream.Length, targetStream.Length);
            Assert.IsTrue(sourceStream.ToArray().SequenceEqual(targetStream.ToArray()));
        }
    }
}
