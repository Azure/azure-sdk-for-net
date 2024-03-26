// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
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
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string,string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlockBlobStorageResourceTests : DataMovementBlobTestBase
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private AccessTier DefaultAccessTier = AccessTier.Cold;

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

        [Test]
        public async Task CopyFromStreamAsync_PropertiesDefault()
        {
            // Arrange
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.UploadAsync(It.IsAny<Stream>(), It.IsAny<BlobUploadOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, BlobUploadOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(mock.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: sourceProperties)
            };
            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                options: copyFromStreamOptions,
                completeLength: length);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.UploadAsync(
                stream,
                It.Is<BlobUploadOptions>(
                    options =>
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync_PropertiesPreserve()
        {
            // Arrange
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.UploadAsync(It.IsAny<Stream>(), It.IsAny<BlobUploadOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, BlobUploadOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(true),
                CacheControl = new(true),
                ContentDisposition = new(true),
                ContentEncoding = new(true),
                ContentLanguage = new(true),
                ContentType = new(true),
                Metadata = new(true)
            };
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(mock.Object, resourceOptions);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: sourceProperties)
            };
            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                options: copyFromStreamOptions,
                completeLength: length);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.UploadAsync(
                stream,
                It.Is<BlobUploadOptions>(
                    options =>
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync_PropertiesNoPreserve()
        {
            // Arrange
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.UploadAsync(It.IsAny<Stream>(), It.IsAny<BlobUploadOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, BlobUploadOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(false),
                CacheControl = new(false),
                ContentDisposition = new(false),
                ContentEncoding = new(false),
                ContentLanguage = new(false),
                ContentType = new(false),
                Metadata = new(false)
            };
            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(mock.Object, resourceOptions);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: sourceProperties)
            };
            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                options: copyFromStreamOptions,
                completeLength: length);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.UploadAsync(
                stream,
                It.Is<BlobUploadOptions>(
                    options =>
                        options.AccessTier == default &&
                        options.HttpHeaders.ContentType == default &&
                        options.HttpHeaders.ContentEncoding == default &&
                        options.HttpHeaders.ContentLanguage == default &&
                        options.HttpHeaders.ContentDisposition == default &&
                        options.HttpHeaders.CacheControl == default &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
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

        private async Task<Mock<BlockBlobClient>> CopyFromUriInternalPreserveAsync(
            BlockBlobStorageResourceOptions resourceOptions,
            Uri sourceUri,
            Metadata metadata)
        {
            // Arrange
            Mock<BlockBlobClient> mockSource = new(
                sourceUri,
                new BlobClientOptions());
            mockSource.Setup(b => b.Uri).Returns(sourceUri);

            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.SyncUploadFromUriAsync(It.IsAny<Uri>(), It.IsAny<BlobSyncUploadFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, BlobSyncUploadFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(mockSource.Object);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object, resourceOptions);

            // Act
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: sourceProperties)
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource: sourceResource,
                overwrite: false,
                completeLength: length,
                options: copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            return mockDestination;
        }

        private void VerifyHttpHeaders(
            Mock<BlockBlobClient> mockDestination,
            BlobStorageResourceOptions resourceOptions,
            Uri expectedUri,
            Metadata expectedMetdata)
        {
            AccessTier? expectedAccessTier = resourceOptions.AccessTier != default ? resourceOptions.AccessTier.Value : DefaultAccessTier;
            string expectedContentDisposition = resourceOptions.ContentDisposition != default ? resourceOptions.ContentDisposition.Value : DefaultContentDisposition;
            string expectedContentEncoding = resourceOptions.ContentEncoding != default ? resourceOptions.ContentEncoding.Value : DefaultContentEncoding;
            string expectedContentLanguage = resourceOptions.ContentLanguage != default ? resourceOptions.ContentLanguage.Value : DefaultContentLanguage;
            string expectedContentType = resourceOptions.ContentType != default ? resourceOptions.ContentType.Value : DefaultContentType;
            string expectedCacheControl = resourceOptions.CacheControl != default ? resourceOptions.CacheControl.Value : DefaultCacheControl;
            Metadata expectedMetadata = resourceOptions.Metadata != default ? resourceOptions.Metadata.Value : expectedMetdata;

            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                expectedUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == false &&
                        options.AccessTier == expectedAccessTier &&
                        options.HttpHeaders.ContentType == expectedContentType &&
                        options.HttpHeaders.ContentEncoding == expectedContentEncoding &&
                        options.HttpHeaders.ContentLanguage == expectedContentLanguage &&
                        options.HttpHeaders.ContentDisposition == expectedContentDisposition &&
                        options.HttpHeaders.CacheControl == expectedCacheControl &&
                        options.Metadata.SequenceEqual(expectedMetadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesDefault()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            Mock<BlockBlobClient> mockDestination = await CopyFromUriInternalPreserveAsync(
                default,
                sourceUri,
                metadata);
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == default &&
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders == default &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesPreserve()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(true),
                ContentDisposition = new(true),
                ContentEncoding = new(true),
                ContentLanguage = new(true),
                ContentType = new(true),
                CacheControl = new(true),
                Metadata = new(true)
            };
            Mock<BlockBlobClient> mockDestination = await CopyFromUriInternalPreserveAsync(
                default,
                sourceUri,
                metadata);
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == default &&
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders == default &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveContentType()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                ContentType = new(false)
            };
            Mock<BlockBlobClient> destinationMock = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            VerifyHttpHeaders(
                destinationMock,
                resourceOptions,
                sourceUri,
                metadata);
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveContentDisposition()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                ContentDisposition = new(false)
            };
            Mock<BlockBlobClient> destinationMock = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            VerifyHttpHeaders(
                destinationMock,
                resourceOptions,
                sourceUri,
                metadata);
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveContentLanguage()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                ContentLanguage= new(false)
            };
            Mock<BlockBlobClient> destinationMock = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            VerifyHttpHeaders(
                destinationMock,
                resourceOptions,
                sourceUri,
                metadata);
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveCacheControl()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                CacheControl = new(false)
            };
            Mock<BlockBlobClient> destinationMock = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            VerifyHttpHeaders(
                destinationMock,
                resourceOptions,
                sourceUri,
                metadata);
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveMetadata()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                Metadata = new(false)
            };
            Mock<BlockBlobClient> mockDestination = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == false &&
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_NoPreserveAccessTier()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(false)
            };
            Mock<BlockBlobClient> mockDestination = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == false &&
                        options.AccessTier == default &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesNoPreserve()
        {
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Metadata metadata = DataProvider.BuildMetadata();
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(false),
                CacheControl = new(false),
                ContentDisposition = new(false),
                ContentEncoding = new(false),
                ContentLanguage = new(false),
                ContentType = new(false),
                Metadata = new(false)
            };
            Mock<BlockBlobClient> mockDestination = await CopyFromUriInternalPreserveAsync(
                resourceOptions,
                sourceUri,
                metadata);
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.CopySourceBlobProperties == false &&
                        options.AccessTier == default &&
                        options.HttpHeaders.ContentType == default &&
                        options.HttpHeaders.ContentEncoding == default &&
                        options.HttpHeaders.ContentLanguage == default &&
                        options.HttpHeaders.ContentDisposition == default &&
                        options.HttpHeaders.CacheControl == default &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_SetProperties()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<BlockBlobClient> mockSource = new(
                sourceUri,
                new BlobClientOptions());
            mockSource.Setup(b => b.Uri).Returns(sourceUri);

            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            Metadata metadata = DataProvider.BuildMetadata();
            mockDestination.Setup(b => b.SyncUploadFromUriAsync(It.IsAny<Uri>(), It.IsAny<BlobSyncUploadFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, BlobSyncUploadFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(mockSource.Object);
            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(DefaultAccessTier),
                CacheControl = new(DefaultCacheControl),
                ContentDisposition = new(DefaultContentDisposition),
                ContentEncoding = new(DefaultContentEncoding),
                ContentLanguage = new(DefaultContentLanguage),
                ContentType = new(DefaultContentType),
                Metadata = new(metadata)
            };
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object, resourceOptions);

            // Act
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: default)
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource: sourceResource,
                overwrite: false,
                completeLength: length,
                options: copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                sourceUri,
                It.Is<BlobSyncUploadFromUriOptions>(
                    options =>
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
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

        [Test]
        public async Task GetPropertiesAsync_NotCached()
        {
            // Arrange
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new BlobClientOptions());

            long length = 1024;
            ETag eTag = new ETag("etag");
            string source = "https://storageaccount.file.core.windows.net/container/file2";
            Metadata metadata = DataProvider.BuildMetadata();
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobProperties(
                        lastModified: DateTime.MinValue,
                        leaseStatus: LeaseStatus.Unlocked,
                        contentLength: length,
                        eTag: eTag,
                        contentEncoding: DefaultContentEncoding,
                        contentDisposition: DefaultContentDisposition,
                        contentLanguage: DefaultContentLanguage,
                        contentType: DefaultContentType,
                        cacheControl: DefaultCacheControl,
                        copySource: new Uri(source),
                        accessTier: DefaultAccessTier.ToString(),
                        copyCompletedOn: DateTimeOffset.MinValue,
                        accessTierChangedOn: DateTimeOffset.MinValue,
                        blobType: BlobType.Block,
                        metadata: metadata,
                        tagCount: 5),
                    new MockResponse(200))));

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(mock.Object);

            // Act
            StorageResourceItemProperties result = await storageResource.GetPropertiesInternalAsync();
            AccessTier accessTierResult = (AccessTier) result.RawProperties[DataMovementConstants.ResourceProperties.AccessTier];
            string contentEncodingResult = (string) result.RawProperties[DataMovementConstants.ResourceProperties.ContentEncoding];
            string contentDispositionResult = (string) result.RawProperties[DataMovementConstants.ResourceProperties.ContentDisposition];
            string contentLanguageResult = (string) result.RawProperties[DataMovementConstants.ResourceProperties.ContentLanguage];
            string contentTypeResult = (string) result.RawProperties[DataMovementConstants.ResourceProperties.ContentType];
            string cacheControlResult = (string) result.RawProperties[DataMovementConstants.ResourceProperties.CacheControl];
            Metadata metadataResult = (Metadata) result.RawProperties[DataMovementConstants.ResourceProperties.Metadata];

            // Assert
            Assert.AreEqual(eTag, result.ETag);
            Assert.AreEqual(length, result.ResourceLength);
            Assert.AreEqual(accessTierResult, DefaultAccessTier);
            Assert.AreEqual(contentEncodingResult, DefaultContentEncoding);
            Assert.AreEqual(contentDispositionResult, DefaultContentDisposition);
            Assert.AreEqual(contentLanguageResult, DefaultContentLanguage);
            Assert.AreEqual(contentTypeResult, DefaultContentType);
            Assert.AreEqual(cacheControlResult, DefaultCacheControl);
            Assert.That(metadata, Is.EqualTo(metadataResult));
            mock.Verify(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetPropertiesAsync_Cached()
        {
            // Arrange
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new BlobClientOptions());

            long length = 1024;
            ETag eTag = new ETag("etag");
            DateTimeOffset lastModified = DateTimeOffset.UtcNow.AddHours(-1);
            Metadata metadata = DataProvider.BuildMetadata();
            Dictionary<string, object> rawProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition},
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage},
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType},
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl},
                { DataMovementConstants.ResourceProperties.Metadata, metadata },
            };

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(
                mock.Object,
                new StorageResourceItemProperties(
                    length,
                    eTag,
                    lastModified,
                    rawProperties));

            // Act
            StorageResourceItemProperties result = await storageResource.GetPropertiesInternalAsync();

            // Assert
            Assert.That(rawProperties, Is.EqualTo(result.RawProperties));
            mock.Verify(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Never());
            mock.VerifyNoOtherCalls();
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

        [Test]
        public async Task CopyFromUriAsync_DefaultMetadata()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<BlockBlobClient> mockSource = new(
                sourceUri,
                new BlobClientOptions());
            mockSource.Setup(b => b.Uri).Returns(sourceUri);
            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.SyncUploadFromUriAsync(It.IsAny<Uri>(), It.IsAny<BlobSyncUploadFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));
            mockDestination.Setup(b => b.SetMetadataAsync(It.IsAny<Metadata>(), It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow),
                    new MockResponse(200))));

            BlockBlobStorageResource sourceResource = new BlockBlobStorageResource(mockSource.Object);
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object);

            // Act
            IDictionary<string, string> sourceMetdata = DataProvider.BuildMetadata();
            Dictionary<string, object> rawProperties = new()
            {
                { DataMovementConstants.ResourceProperties.Metadata, sourceMetdata },
            };
            StorageResourceItemProperties sourceProperties = new(
                length,
                new ETag("etag"),
                DateTimeOffset.UtcNow.AddHours(-1),
                rawProperties);
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: rawProperties)
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource,
                overwrite: false,
                completeLength: length,
                options: copyFromUriOptions,
                cancellationToken: default);

            // Assert
            mockDestination.Verify(b => b.SyncUploadFromUriAsync(
                    sourceUri,
                    It.IsAny<BlobSyncUploadFromUriOptions>(),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.SetMetadataAsync(
                default,
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Never());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CompleteTransferAsync_PropertiesDefaultChunks()
        {
            // Arrange
            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int blockLength = 512;
            int completeLength = 1024;
            var data = GetRandomBuffer(completeLength);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.StageBlockAsync(It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<BlockBlobStageBlockOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlockInfo(
                        contentHash: default,
                        contentCrc64: default,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            mockDestination.Setup(b => b.CommitBlockListAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CommitBlockListOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new(){ Position = 0 },
                completeLength: completeLength);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new() { Position = blockLength },
                completeLength: completeLength);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            Dictionary<string, object> rawProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceItemProperties sourceProperties = new(
                completeLength,
                new ETag("etag"),
                DateTimeOffset.UtcNow.AddHours(-1),
                rawProperties);
            await destinationResource.CompleteTransferAsync(
                overwrite: false,
                completeTransferOptions: new() { SourceProperties = sourceProperties });

            // Assert
            mockDestination.Verify(b => b.CommitBlockListAsync(
                It.IsAny<IEnumerable<string>>(),
                It.Is<CommitBlockListOptions>(
                    options =>
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.StageBlockAsync(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<BlockBlobStageBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CompleteTransferAsync_PropertiesPreserveChunks()
        {
            // Arrange
            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int blockLength = 512;
            int completeLength = 1024;
            var data = GetRandomBuffer(completeLength);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.StageBlockAsync(It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<BlockBlobStageBlockOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlockInfo(
                        contentHash: default,
                        contentCrc64: default,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            mockDestination.Setup(b => b.CommitBlockListAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CommitBlockListOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(true),
                CacheControl = new(true),
                ContentDisposition = new(true),
                ContentEncoding = new(true),
                ContentLanguage = new(true),
                ContentType = new(true),
                Metadata = new(true)
            };
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object, resourceOptions);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new() { Position = 0 },
                completeLength: completeLength);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new() { Position = blockLength },
                completeLength: completeLength);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            Dictionary<string, object> rawProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceItemProperties sourceProperties = new(
                completeLength,
                new ETag("etag"),
                DateTimeOffset.UtcNow.AddHours(-1),
                rawProperties);
            await destinationResource.CompleteTransferAsync(
                overwrite: false,
                completeTransferOptions: new() { SourceProperties = sourceProperties });

            // Assert
            mockDestination.Verify(b => b.CommitBlockListAsync(
                It.IsAny<IEnumerable<string>>(),
                It.Is<CommitBlockListOptions>(
                    options =>
                        options.AccessTier == DefaultAccessTier &&
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.StageBlockAsync(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<BlockBlobStageBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CompleteTransferAsync_PropertiesNoPreserveChunks()
        {
            // Arrange
            Mock<BlockBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());
            int blockLength = 512;
            int completeLength = 1024;
            var data = GetRandomBuffer(completeLength);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.StageBlockAsync(It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<BlockBlobStageBlockOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlockInfo(
                        contentHash: default,
                        contentCrc64: default,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            mockDestination.Setup(b => b.CommitBlockListAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CommitBlockListOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        versionId: "version",
                        encryptionKeySha256: default,
                        encryptionScope: default,
                        blobSequenceNumber: default),
                    new MockResponse(201))));

            BlockBlobStorageResourceOptions resourceOptions = new()
            {
                AccessTier = new(false),
                CacheControl = new(false),
                ContentDisposition = new(false),
                ContentEncoding = new(false),
                ContentLanguage = new(false),
                ContentType = new(false),
                Metadata = new(false)
            };
            BlockBlobStorageResource destinationResource = new BlockBlobStorageResource(mockDestination.Object, resourceOptions);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new() { Position = 0 },
                completeLength: completeLength);
            await destinationResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: blockLength,
                overwrite: false,
                options: new() { Position = blockLength },
                completeLength: completeLength);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            Dictionary<string, object> rawProperties = new()
            {
                { DataMovementConstants.ResourceProperties.AccessTier, DefaultAccessTier },
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceItemProperties sourceProperties = new(
                completeLength,
                new ETag("etag"),
                DateTimeOffset.UtcNow.AddHours(-1),
                rawProperties);
            await destinationResource.CompleteTransferAsync(
                overwrite: false,
                completeTransferOptions: new() { SourceProperties = sourceProperties });

            // Assert
            mockDestination.Verify(b => b.CommitBlockListAsync(
                It.IsAny<IEnumerable<string>>(),
                It.Is<CommitBlockListOptions>(
                    options =>
                        options.AccessTier == default &&
                        options.HttpHeaders.ContentType == default &&
                        options.HttpHeaders.ContentEncoding == default &&
                        options.HttpHeaders.ContentLanguage == default &&
                        options.HttpHeaders.ContentDisposition == default &&
                        options.HttpHeaders.CacheControl == default &&
                        options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.StageBlockAsync(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<BlockBlobStageBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            mockDestination.VerifyNoOtherCalls();
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
