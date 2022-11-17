// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlockBlobStorageResourceTests : DataMovementBlobTestBase
    {
        public BlockBlobStorageResourceTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            BlockBlobClient blobClient = new BlockBlobClient(uri);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
            Assert.AreEqual(blobClient.Name, storageResource.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, storageResource.CanProduceUri);
            // If no options were specified then we default to SyncCopy
            Assert.AreEqual(TransferCopyMethod.SyncCopy, storageResource.ServiceCopyMethod);
        }

        [RecordedTest]
        public void Ctor_Options()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            BlockBlobClient blobClient = new BlockBlobClient(uri);
            // Default Options
            BlockBlobStorageResourceOptions defaultOptions = new BlockBlobStorageResourceOptions();
            BlockBlobStorageResource resourceDefaultOptions = new BlockBlobStorageResource(blobClient, defaultOptions);

            // Assert
            Assert.AreEqual(uri, resourceDefaultOptions.Uri);
            Assert.AreEqual(blobClient.Name, resourceDefaultOptions.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, resourceDefaultOptions.CanProduceUri);
            // If no options were specified then we default to SyncCopy
            Assert.AreEqual(TransferCopyMethod.SyncCopy, resourceDefaultOptions.ServiceCopyMethod);

            // Arrange - Set up options specifying different async copy
            BlockBlobStorageResourceOptions optionsWithAsyncCopy = new BlockBlobStorageResourceOptions()
            {
                CopyOptions = new BlockBlobStorageResourceServiceCopyOptions()
                { CopyMethod = TransferCopyMethod.AsyncCopy },
            };
            BlockBlobStorageResource resourceSyncCopy = new BlockBlobStorageResource(blobClient, optionsWithAsyncCopy);

            // Assert
            Assert.AreEqual(uri, resourceSyncCopy.Uri);
            Assert.AreEqual(blobClient.Name, resourceSyncCopy.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, resourceSyncCopy.CanProduceUri);
            // If no options were specified then we default to SyncCopy
            Assert.AreEqual(TransferCopyMethod.AsyncCopy, resourceSyncCopy.ServiceCopyMethod);
        }

        [RecordedTest]
        public async Task ReadStreamAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync();

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync(position: 5);

            // Assert
            Assert.NotNull(result);

            byte[] dataAt5 = new byte[data.Length - 5];
            Array.Copy(data, 5, dataAt5, 0, data.Length - 5);
            TestHelper.AssertSequenceEqual(dataAt5, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act without creating the blob
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.ReadStreamAsync(),
                e =>
                {
                    Assert.AreEqual("BlobNotFound", e.ErrorCode);
                });
        }

        [RecordedTest]
        public async Task ReadStreamPartialAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            // Act
            ReadStreamStorageResourceResult result =
                await storageResource.ReadPartialStreamAsync(offset: 0, length: Constants.KB);

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }
    }
}
