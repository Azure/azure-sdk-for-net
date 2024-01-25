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
    public class AppendBlobStorageResourceTests : DataMovementBlobTestBase
    {
        public AppendBlobStorageResourceTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            AppendBlobClient blobClient = new AppendBlobClient(uri);
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
        }

        [RecordedTest]
        public async Task ReadStreamAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            int readPosition = 512;
            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);
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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            long readPosition = Constants.KB;
            long length = Constants.KB;
            var data = GetRandomBuffer(length);
            await blobClient.CreateAsync();
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Position = readPosition - 1 });
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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

            await blobClient.CreateAsync();
            // Act but with a blob already created.
            int position = 0;
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
                    options: new StorageResourceWriteToOffsetOptions(){ Position = position }),
                e =>
                {
                    Assert.AreEqual(e.ErrorCode, "BlobAlreadyExists");
                });
            }
        }

        [RecordedTest]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await sourceClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Act;
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

            AppendBlobClient sourceClient = test.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            var length = Constants.KB;
            await sourceClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);
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
                options: options,
                completeLength: length);

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

            AppendBlobClient sourceClient = test.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            var length = Constants.KB;
            await sourceClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);
            HttpAuthorization authorizationHeader = await sourceResource.GetCopyAuthorizationHeaderAsync();
            StorageResourceCopyFromUriOptions options = new StorageResourceCopyFromUriOptions()
            {
                SourceAuthentication = authorizationHeader
            };

            // Act
            await destinationResource.CopyFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                options: options,
                completeLength: length);

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
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyFromUriAsync(sourceResource: sourceResource, overwrite:false, completeLength: length),
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
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            await sourceClient.CreateIfNotExistsAsync();
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Act
            await destinationResource.CopyBlockFromUriAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, blockLength),
                completeLength: length);

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
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);
            AppendBlobClient sourceClient = test.Container.GetAppendBlobClient(GetNewBlobName());
            await sourceClient.CreateIfNotExistsAsync();
            AppendBlobClient destinationClient = test.Container.GetAppendBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);
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
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            await sourceClient.CreateIfNotExistsAsync();
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Convert TokenCredential to HttpAuthorization
            TokenCredential tokenCredential = Tenants.GetOAuthCredential();
            string[] scopes = new string[] { "https://storage.azure.com/.default" };
            AccessToken accessToken = await tokenCredential.GetTokenAsync(new TokenRequestContext(scopes), CancellationToken.None);
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
            AppendBlobClient sourceClient = test.Container.GetAppendBlobClient(GetNewBlobName());
            await sourceClient.CreateIfNotExistsAsync();
            AppendBlobClient destinationClient = test.Container.GetAppendBlobClient(GetNewBlobName());

            var length = 4 * Constants.KB;
            var data = GetRandomBuffer(length);
            var blockLength = Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Convert TokenCredential to HttpAuthorization
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
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            // Cannot copy from append blob to append blob
            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(destinationClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriAsync(sourceResource, new HttpRange(0, Constants.KB), false, Constants.KB),
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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await storageResource.CopyFromStreamAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length);
            }

            // Act
            await storageResource.CompleteTransferAsync(false);

            // Assert
            Assert.IsTrue(await blobClient.ExistsAsync());
        }

        [RecordedTest]
        public async Task CompleteTransferAsync_Error()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            AppendBlobStorageResource storageResource = new AppendBlobStorageResource(blobClient);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.GetPropertiesAsync(),
                e =>
                {
                    Assert.AreEqual("BlobNotFound", e.ErrorCode);
                });
        }

        [RecordedTest]
        public async Task GetCopyAuthorizationHeaderAsync()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(blobClient);

            // Act - Get access token
            HttpAuthorization httpAuthorization = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.Null(httpAuthorization);
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
            AppendBlobClient blobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await blobClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await blobClient.AppendBlockAsync(stream);
            }

            AppendBlobStorageResource sourceResource = new AppendBlobStorageResource(blobClient);

            // Act - Get options
            HttpAuthorization authorization = await sourceResource.GetCopyAuthorizationHeaderAsync();

            // Assert
            Assert.NotNull(authorization);
            Assert.NotNull(authorization.Scheme);
            Assert.NotNull(authorization.Parameter);
        }
    }
}
