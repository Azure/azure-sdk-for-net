// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class LargeBlobTests
    {
        private BlobServiceClient blobServiceClient;

        [SetUp]
        public void Setup()
        {
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var transport = azuriteFixture.GetTransport();
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            blobServiceClient = new BlobServiceClient(connectionString, new BlobClientOptions() { Transport = transport });
        }

        [Test]
        [LiveOnly]
        public async Task GetBlockListAsync_LongBlock()
        {
            // Arange
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(Guid.NewGuid().ToString());
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobName = Guid.NewGuid().ToString();

            var blobClient = blobContainerClient.GetBlockBlobClient(blobName);

            const long bigBlockSize = int.MaxValue + 1024L;

            var blockId0 = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            using (var stream = new Storage.Tests.Shared.PredictableStream(length: bigBlockSize))
            {
                await blobClient.StageBlockAsync(blockId0, stream);
            }
            await blobClient.CommitBlockListAsync(new string[] { blockId0 });

            // Act
            Response<BlockList> response = await blobClient.GetBlockListAsync();

            // Assert
            Assert.AreEqual(1, response.Value.CommittedBlocks.Count());
            Assert.AreEqual(blockId0, response.Value.CommittedBlocks.First().Name);
            Assert.AreEqual(bigBlockSize, response.Value.CommittedBlocks.First().SizeLong);
            Assert.Throws<OverflowException>(() => _ = response.Value.CommittedBlocks.First().Size); // if no overflow then we didn't actually test handling of long lengths
        }

        [Test]
        [LiveOnly]
        public async Task CanHandleLongBlockBufferedUpload()
        {
            // Arrange
            const long blockSize = int.MaxValue + 1024L;
            const int numBlocks = 2;
            Stream content = new Storage.Tests.Shared.PredictableStream(numBlocks * blockSize, revealsLength: false); // lack of Stream.Length forces buffered upload
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(Guid.NewGuid().ToString());
            await blobContainerClient.CreateIfNotExistsAsync();
            var blobName = Guid.NewGuid().ToString();
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            // Act
            await blobClient.UploadAsync(content, new BlobUploadOptions()
            {
                TransferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = 1,
                    MaximumTransferSize = blockSize,
                    MaximumConcurrency = 1,
                }
            });
            BlockList blockList = await blobContainerClient.GetBlockBlobClient(blobName).GetBlockListAsync();

            // Assert
            Assert.AreEqual(numBlocks * blockSize, blockList.BlobContentLength);
            Assert.AreEqual(numBlocks, blockList.CommittedBlocks.Count());
            foreach (var block in blockList.CommittedBlocks)
            {
                Assert.AreEqual(blockSize, block.SizeLong);
            }
        }

        [Test]
        [LiveOnly]
        public async Task CanHandleLongBlockBufferedUploadInParallel()
        {
            // Arrange
            const long firstBlockSize = int.MaxValue + 1024L;
            const long secondBlockSize = 1024L;
            Stream content = new Storage.Tests.Shared.PredictableStream(firstBlockSize + secondBlockSize, revealsLength: false); // lack of Stream.Length forces buffered upload
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(Guid.NewGuid().ToString());
            await blobContainerClient.CreateIfNotExistsAsync();
            var blobName = Guid.NewGuid().ToString();
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            // Act
            await blobClient.UploadAsync(content, new BlobUploadOptions()
            {
                TransferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = 1,
                    MaximumTransferSize = firstBlockSize,
                    MaximumConcurrency = 2,
                }
            });
            BlockList blockList = await blobContainerClient.GetBlockBlobClient(blobName).GetBlockListAsync();

            // Assert
            Assert.AreEqual(firstBlockSize + secondBlockSize, blockList.BlobContentLength);
            Assert.AreEqual(2, blockList.CommittedBlocks.Count());
            Assert.AreEqual(firstBlockSize, blockList.CommittedBlocks.ElementAt(0).SizeLong);
            Assert.AreEqual(secondBlockSize, blockList.CommittedBlocks.ElementAt(1).SizeLong);
        }
    }
}
