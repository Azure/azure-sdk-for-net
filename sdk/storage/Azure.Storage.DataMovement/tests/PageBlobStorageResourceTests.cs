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
    public class PageBlobStorageResourceTests : DataMovementBlobTestBase
    {
        public PageBlobStorageResourceTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            PageBlobClient blobClient = new PageBlobClient(uri);
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

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
            PageBlobClient blobClient = new PageBlobClient(uri);
            // Default Options
            PageBlobStorageResourceOptions defaultOptions = new PageBlobStorageResourceOptions();
            PageBlobStorageResource resourceDefaultOptions = new PageBlobStorageResource(blobClient, defaultOptions);

            // Assert
            Assert.AreEqual(uri, resourceDefaultOptions.Uri);
            Assert.AreEqual(blobClient.Name, resourceDefaultOptions.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, resourceDefaultOptions.CanProduceUri);
            Assert.AreEqual(TransferCopyMethod.None, resourceDefaultOptions.ServiceCopyMethod);

            // Arrange - Set up options specifying different async copy
            PageBlobStorageResourceOptions optionsWithAsyncCopy = new PageBlobStorageResourceOptions()
            {
                CopyMethod = TransferCopyMethod.AsyncCopy,
            };
            PageBlobStorageResource resourceSyncCopy = new PageBlobStorageResource(blobClient, optionsWithAsyncCopy);

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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            var length = Constants.KB;
            await blobClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }

            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            int readPosition = 512;
            var length = Constants.KB;
            await blobClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }

            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            // Act
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync(position: readPosition);

            // Assert
            Assert.NotNull(result);

            byte[] copiedData = new byte[data.Length - readPosition];
            Array.Copy(data, readPosition, copiedData, 0, data.Length - readPosition);
            TestHelper.AssertSequenceEqual(copiedData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            var length = Constants.KB;
            await blobClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);
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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            long readPosition = Constants.KB;
            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            await blobClient.CreateAsync(length * 2);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadPagesAsync(stream, offset: 0);
            }

            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    position: readPosition,
                    completeLength: length*2);
            }

            BlobDownloadStreamingResult result = await blobClient.DownloadStreamingAsync(
                new BlobDownloadOptions()
                {
                    Range = new HttpRange(readPosition, length)
                });
            // Assert
            Assert.NotNull(result);

            byte[] copiedData = new byte[data.Length];
            Array.Copy(data, 0, copiedData, 0, data.Length);
            TestHelper.AssertSequenceEqual(copiedData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task WriteFromStreamAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            // Act without creating a correct offset
            int position = 5;
            int length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.WriteFromStreamAsync(
                    stream: stream,
                    overwrite: false,
                    position: position,
                    streamLength: length),
                e =>
                {
                    Assert.AreEqual(e.ErrorCode, "InvalidHeaderValue");
                });
            }
        }

        [RecordedTest]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await sourceClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }
            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(
                destinationClient,
                new PageBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy
                });

            // Act
            await destinationResource.CopyFromUriAsync(sourceResource, false, length);
            ;

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
                publicAccessType: PublicAccessType.None);

            PageBlobClient sourceClient = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            PageBlobClient destinationClient = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            var length = Constants.KB;
            await sourceClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);
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
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            long length = Constants.KB;

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);

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
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            await sourceClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                completeLength: blockLength);

            // Commit the block
            await destinationResource.CompleteTransferAsync();

            // Assert
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            byte[] blockData = new byte[blockLength];
            Array.Copy(data, 0, blockData, 0, blockLength);
            TestHelper.AssertSequenceEqual(blockData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task CopyBlockFromUriAsync_OAuth()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            await sourceClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }
            await destinationClient.CreateIfNotExistsAsync(blockLength);

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);
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
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriAsync(sourceResource, new HttpRange(0, Constants.KB), false),
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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await blobClient.CreateAsync(length);
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadPagesAsync(
                    content: stream,
                    offset: 0);
            }

            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

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
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.WriteFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    completeLength: length,
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
