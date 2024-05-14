// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class PageBlobStorageResourceTests : DataMovementBlobTestBase
    {
        public PageBlobStorageResourceTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            PageBlobClient blobClient = new PageBlobClient(uri);
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
        }

        [RecordedTest]
        public async Task ReadStreamAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            StorageResourceReadStreamResult result = await storageResource.ReadStreamAsync();

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            StorageResourceReadStreamResult result = await storageResource.ReadStreamAsync(position: readPosition);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            StorageResourceReadStreamResult result =
                await storageResource.ReadStreamAsync(position: 0, length: Constants.KB);

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task WriteFromStreamAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length * 2,
                    options: new StorageResourceWriteToOffsetOptions() { Position = readPosition });
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
                storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Position = position }),
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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);

            // Act
            await destinationResource.CopyFromUriAsync(sourceResource, false, length);

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyFromUriAsync_OAuth()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
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
        public async Task CopyFromUriAsync_HttpAuthorization()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
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

            HttpAuthorization authorizationHeader = await sourceResource.GetCopyAuthorizationHeaderAsync();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = authorizationHeader
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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
                    Assert.IsTrue(e.Status == (int)HttpStatusCode.NotFound);
                });
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
            await destinationResource.CompleteTransferAsync(false);

            // Assert
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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
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
                completeLength: blockLength,
                options: options);

            await destinationResource.CompleteTransferAsync(false);

            // Assert
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            byte[] blockData = new byte[blockLength];
            Array.Copy(data, 0, blockData, 0, blockLength);
            TestHelper.AssertSequenceEqual(blockData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync_OAuth_Token()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
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

            // Convert TokenCredential to HttpAuthorization
            TokenCredential sourceBearerToken = Tenants.GetOAuthCredential();
            string[] scopes = new string[] { "https://storage.azure.com/.default" };
            AccessToken accessToken = await sourceBearerToken.GetTokenAsync(new TokenRequestContext(scopes), CancellationToken.None);
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = new HttpAuthorization(
                    scheme: "Bearer",
                    parameter: accessToken.Token)
            };

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                completeLength: blockLength,
                options: options);
            await destinationResource.CompleteTransferAsync(false);

            // Assert
            await destinationClient.ExistsAsync();
            BlobDownloadStreamingResult result = await destinationClient.DownloadStreamingAsync();
            Assert.NotNull(result);
            byte[] blockData = new byte[blockLength];
            Array.Copy(data, 0, blockData, 0, blockLength);
            TestHelper.AssertSequenceEqual(blockData, result.Content.AsBytes().ToArray());
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync_HttpAuthorization()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);
            PageBlobClient sourceClient = test.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = test.Container.GetPageBlobClient(GetNewBlobName());

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

            // Get Access Token
            HttpAuthorization authorizationHeader = await sourceResource.GetCopyAuthorizationHeaderAsync();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = authorizationHeader
            };

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                completeLength: blockLength,
                options: options);
            await destinationResource.CompleteTransferAsync(false);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            PageBlobStorageResource destinationResource = new PageBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriAsync(sourceResource, new HttpRange(0, Constants.KB), false, 0),
                e =>
                {
                    Assert.AreEqual(e.ErrorCode, "CannotVerifyCopySource");
                });
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            StorageResourceItemProperties result = await storageResource.GetPropertiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ResourceLength, Constants.KB);
            Assert.NotNull(result.RawProperties);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            PageBlobClient blobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            PageBlobStorageResource storageResource = new PageBlobStorageResource(blobClient);

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    completeLength: length,
                    overwrite: false);
            }

            // Act
            await storageResource.CompleteTransferAsync(false);

            // Assert
            Assert.IsTrue(await blobClient.ExistsAsync());
        }

        [RecordedTest]
        public async Task GetCopyAuthorizationHeaderAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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

            PageBlobStorageResource sourceResource = new PageBlobStorageResource(blobClient);

            // Act - Get authorization header
            HttpAuthorization authorizationHeader = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.Null(authorizationHeader);
        }

        [RecordedTest]
        public async Task GetCopyAuthorizationHeaderAsync_OAuth()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer testContainer = await GetTestContainerAsync(
                service,
                containerName,
                publicAccessType: PublicAccessType.None);
            PageBlobClient sourceClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());

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

            // Act - Get authorization header
            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.NotNull(authorization);
            Assert.NotNull(authorization.Scheme);
            Assert.NotNull(authorization.Parameter);
        }
    }
}
