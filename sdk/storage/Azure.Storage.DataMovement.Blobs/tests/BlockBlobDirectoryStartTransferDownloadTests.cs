// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using NUnit.Framework;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using System.Linq;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobDirectoryStartTransferDownloadTests
        : BlobDirectoryStartTransferDownloadTestBase
    {
        public BlockBlobDirectoryStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override async Task CreateBlobClientAsync(
            BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default)
        {
            BlockBlobClient blockBlobClient = container.GetBlockBlobClient(blobName);
            if (contents != default)
            {
                await blockBlobClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override BlobType GetBlobType()
            => BlobType.Block;

        [Test]
        public async Task DownloadTransferTest()
        {
            BlobServiceClient service = ClientBuilder.GetServiceClient_OAuth(TestEnvironment.Credential);
            BlobContainerClient container = service.GetBlobContainerClient("test-download-1");
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            await container.CreateIfNotExistsAsync();
            Random random = new();
            foreach (int i in Enumerable.Range(0, 5))
            {
                byte[] data = new byte[1048576];
                random.NextBytes(data);
                await container.UploadBlobAsync($"blob{i}", new BinaryData(data));
            }

            BlobsStorageResourceProvider blobProvider = new();
            LocalFilesStorageResourceProvider localProvider = new();

            TransferManager transferManager = new();
            DataTransferOptions options = new()
            {
                InitialTransferSize = 8192,
                MaximumTransferChunkSize = 8192,
            };
            TestEventsRaised testEvents = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(
                blobProvider.FromClient(container),
                localProvider.FromDirectory(testDirectory.DirectoryPath),
                options);

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cts.Token);
            testEvents.AssertUnexpectedFailureCheck();

            await foreach (BlobItem blob in container.GetBlobsAsync())
            {
                string localPath = Path.Combine(testDirectory.DirectoryPath, blob.Name);
                var response = await container.GetBlobClient(blob.Name).DownloadContentAsync();
                byte[] expected = response.Value.Content.ToArray();
                byte[] actual = File.ReadAllBytes(localPath);

                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
