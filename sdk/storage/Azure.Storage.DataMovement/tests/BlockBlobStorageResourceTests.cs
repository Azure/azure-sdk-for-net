// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
            Assert.AreEqual(TransferCopyMethod.None, resourceDefaultOptions.ServiceCopyMethod);

            // Arrange - Set up options specifying different async copy
            BlockBlobStorageResourceOptions optionsWithAsyncCopy = new BlockBlobStorageResourceOptions()
            {
                CopyMethod = TransferCopyMethod.AsyncCopy,
            };
            BlockBlobStorageResource resourceSyncCopy = new BlockBlobStorageResource(blobClient, optionsWithAsyncCopy);

            // Assert
            Assert.AreEqual(uri, resourceSyncCopy.Uri);
            Assert.AreEqual(blobClient.Name, resourceSyncCopy.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, resourceSyncCopy.CanProduceUri);
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
                await blobClient.UploadAsync(content: stream);
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

            int position = 5;
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync(position: position);

            // Assert
            Assert.NotNull(result);

            byte[] dataAt5 = new byte[data.Length - position];
            Array.Copy(data, position, dataAt5, 0, data.Length - position);
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
        public async Task ReadStreamAsync_Partial()
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
                await storageResource.ReadStreamAsync(position: 0, length: Constants.KB);

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task WriteFromStreamAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    completeLength: length,
                    overwrite: false);
            }

            BlobDownloadStreamingResult result = await blobClient.DownloadStreamingAsync();
            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task WriteFromStreamAsync_Position()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            int position = 5;
            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    position: position);
            }
            await storageResource.CompleteTransferAsync();

            BlobDownloadStreamingResult result = await blobClient.DownloadStreamingAsync();
            // Assert
            Assert.NotNull(result);

            byte[] dataAt5 = new byte[data.Length];
            Array.Copy(data, 0, dataAt5, 0, length);
            TestHelper.AssertSequenceEqual(dataAt5, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task WriteFromStreamAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act without creating the blob
            int position = 0;
            int length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    position: position);
            }
            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    position: position),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Cannot Stage Block to the specific offset"));
                });
            }
        }

        [RecordedTest]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Act
            await destinationResource.CopyFromUriAsync(sourceResource, false, length);

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task CopyFromUriAsync_OAuth()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.BlobContainer);

            BlockBlobClient sourceClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destinationClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);
            string sourceBearerToken = await GetAuthToken();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = new HttpAuthorization(
                    scheme: "Bearer",
                    parameter: sourceBearerToken)
            };

            // Act
            await destinationResource.CopyFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                completeLength: length,
                options: options);

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyFromUriAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyFromUriAsync(sourceResource: sourceResource, overwrite: false, completeLength: length),
                e =>
                {
                    Assert.IsTrue(e.Message.StartsWith("The specified blob does not exist."));
                });
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(4 * Constants.KB);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength));

            // Commit the block
            await destinationResource.CompleteTransferAsync();

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            byte[] blockData = new byte[blockLength];
            Array.Copy(data, 0, blockData, 0, blockLength);
            TestHelper.AssertSequenceEqual(blockData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync_OAuth()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(4 * Constants.KB);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);
            string sourceBearerToken = await GetAuthToken();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = new HttpAuthorization(
                    scheme: "Bearer",
                    parameter: sourceBearerToken)
            };

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                options: options);
            await destinationResource.CompleteTransferAsync();

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            byte[] blockData = new byte[blockLength];
            Array.Copy(data, 0, blockData, 0, blockLength);
            TestHelper.AssertSequenceEqual(blockData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriAsync(sourceResource, new HttpRange(0, Constants.KB), overwrite: false),
                e =>
                {
                    Assert.AreEqual(e.ErrorCode, "CannotVerifyCopySource");
                });
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
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
            StorageResourceProperties result = await storageResource.GetPropertiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ContentLength, Constants.KB);
            Assert.NotNull(result.ETag);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.GetPropertiesAsync(),
                e =>
                {
                    Assert.AreEqual(e.ErrorCode, "BlobNotFound");
                });
        }

        [RecordedTest]
        public async Task CompleteTransferAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    position: 0);
            }

            // Act
            await storageResource.CompleteTransferAsync();

            // Assert
            Assert.IsTrue(await blobClient.ExistsAsync());
        }
    }
}
