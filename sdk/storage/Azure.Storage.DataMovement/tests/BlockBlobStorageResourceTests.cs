// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.IO;
using System.Linq;
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
    public class BlockBlobStorageResourceTests : DataMovementBlobTestBase
    {
        public BlockBlobStorageResourceTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            BlockBlobClient blobClient = new BlockBlobClient(uri);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Assert
            Assert.AreEqual(uri, storageResource.Uri.AbsoluteUri);
        }

        [RecordedTest]
        public async Task ReadStreamAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(content: stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

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
            StorageResourceReadStreamResult result = await storageResource.ReadStreamAsync(position: position);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
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
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);
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
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            int position = 5;
            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Position = position });
            }
            await storageResource.CompleteTransferAsync(false);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            // Act without creating the blob
            int length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: 0);
            }
            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: 0),
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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
        public async Task CopyFromUriAsync_OAuth()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

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
        public async Task CopyFromUriAsync_HttpAuthorization()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

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
            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = authorization
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
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
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
                range: new HttpRange(0, blockLength),
                completeLength: length);

            // Commit the block
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
        public async Task CopyBlockFromUriAsync_OAuth()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
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
                completeLength: length,
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
        public async Task CopyBlockFromUriAsync_OAuth_Token()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

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
                completeLength: length,
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
            BlockBlobClient sourceClient = test.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = test.Container.GetBlockBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = authorization
            };

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                completeLength: length,
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
            BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobClient destinationClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriAsync(sourceResource, new HttpRange(0, Constants.KB), overwrite: false, completeLength: Constants.KB),
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
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: 0);
            }

            // Act
            await storageResource.CompleteTransferAsync(false);

            // Assert
            Assert.IsTrue(await blobClient.ExistsAsync());
        }

        [RecordedTest]
        public async Task CompleteTransferAsync_Overwrite()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            // Create block blob to overwrite
            long length = Constants.KB;
            var data = GetRandomBuffer(length);

            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(stream);
            }

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(blobClient);

            bool overwrite = true;
            var newData = GetRandomBuffer(length);
            using (var stream = new MemoryStream(newData))
            {
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: overwrite,
                    completeLength: 0);
            }

            // Act
            await storageResource.CompleteTransferAsync(overwrite);

            // Assert
            Assert.IsTrue(await blobClient.ExistsAsync());
        }

        [RecordedTest]
        public async Task GetCopyAuthorizationHeaderAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(blobClient);

            // Act - Get access token
            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.Null(authorization);
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
            BlockBlobClient blobClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());

            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.UploadAsync(
                    content: stream);
            }

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(blobClient);

            // Act - Get access token
            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.NotNull(authorization);
            Assert.NotNull(authorization.Scheme);
            Assert.NotNull(authorization.Parameter);
        }
    }
}
