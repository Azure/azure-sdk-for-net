// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using BaseBlobs::Azure.Storage.Sas;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class AppendBlobStorageResourceTests : DataMovementBlobTestBase
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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

        [Test]
        public async Task CopyFromStreamAsync_PropertiesDefault()
        {
            // Arrange
            Mock<AppendBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mock.Setup(b => b.AppendBlockAsync(It.IsAny<Stream>(), It.IsAny<AppendBlobAppendBlockOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, AppendBlobAppendBlockOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));

            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mock.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromStreamInternalAsync(
                stream,
                length,
                false,
                length,
                copyFromStreamOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.AppendBlockAsync(
                stream,
                It.IsAny<AppendBlobAppendBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync_PropertiesPreserve()
        {
            // Arrange
            Mock<AppendBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mock.Setup(b => b.AppendBlockAsync(It.IsAny<Stream>(), It.IsAny<AppendBlobAppendBlockOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, AppendBlobAppendBlockOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mock.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromStreamInternalAsync(
                stream,
                length,
                false,
                length,
                copyFromStreamOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.AppendBlockAsync(
                stream,
                It.IsAny<AppendBlobAppendBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync_PropertiesNoPreserve()
        {
            // Arrange
            Mock<AppendBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mock.Setup(b => b.AppendBlockAsync(It.IsAny<Stream>(), It.IsAny<AppendBlobAppendBlockOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, AppendBlobAppendBlockOptions, CancellationToken>(
                async (stream, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));

            AppendBlobStorageResourceOptions resourceOptions = new()
            {
                CacheControl = default,
                ContentDisposition = default,
                ContentLanguage = default,
                ContentEncoding = default,
                ContentType = default,
                Metadata = default
            };
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mock.Object, resourceOptions);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceWriteToOffsetOptions copyFromStreamOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromStreamInternalAsync(
                stream,
                length,
                false,
                length,
                copyFromStreamOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options => options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.AppendBlockAsync(
                stream,
                It.IsAny<AppendBlobAppendBlockOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [RecordedTest]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient sourceClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            AppendBlobClient destinationClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());

            var length = Constants.KB;
            await sourceClient.CreateAsync();
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await sourceClient.AppendBlockAsync(stream);
            }

            sourceClient = InstrumentClient(new AppendBlobClient(
                sourceClient.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                GetOptions()));

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
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(
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
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(
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

        [Test]
        public async Task CopyFromUriAsync_PropertiesDefault()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource.Object,
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesPreserve()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource.Object,
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesNoPreserve()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResourceOptions resourceOptions = new()
            {
                CacheControl = default,
                ContentDisposition = default,
                ContentLanguage = default,
                ContentEncoding = default,
                ContentType = default,
                Metadata = default
            };
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object, resourceOptions);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyFromUriInternalAsync(
                sourceResource.Object,
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options => options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [RecordedTest]
        public async Task CopyFromUriAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
                    Assert.IsTrue(e.Status == (int)HttpStatusCode.Unauthorized);
                });
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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

            sourceClient = InstrumentClient(new AppendBlobClient(
                sourceClient.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                GetOptions()));
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
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
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
            TokenCredential tokenCredential = TestEnvironment.Credential;
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
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(
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

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesDefault()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyBlockFromUriInternalAsync(
                sourceResource.Object,
                new HttpRange(0, length),
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesPreserve()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyBlockFromUriInternalAsync(
                sourceResource.Object,
                new HttpRange(0, length),
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options =>
                        options.HttpHeaders.ContentType == DefaultContentType &&
                        options.HttpHeaders.ContentEncoding == DefaultContentEncoding &&
                        options.HttpHeaders.ContentLanguage == DefaultContentLanguage &&
                        options.HttpHeaders.ContentDisposition == DefaultContentDisposition &&
                        options.HttpHeaders.CacheControl == DefaultCacheControl &&
                        options.Metadata.SequenceEqual(metadata)),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesNoPreserve()
        {
            // Arrange
            Uri sourceUri = new Uri("https://storageaccount.blob.core.windows.net/container/source");
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(sourceUri);

            Mock<AppendBlobClient> mockDestination = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/destination"),
                new BlobClientOptions());

            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<AppendBlobCreateOptions>(), It.IsAny<CancellationToken>()))
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
            mockDestination.Setup(b => b.AppendBlockFromUriAsync(It.IsAny<Uri>(), It.IsAny<AppendBlobAppendBlockFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Callback<Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken>(
                async (uri, options, token) =>
                {
                    await stream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                    fileContentStream.Position = 0;
                })
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobAppendInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        contentCrc64: default,
                        blobAppendOffset: "0",
                        blobCommittedBlockCount: 1,
                        isServerEncrypted: false,
                        encryptionKeySha256: default,
                        encryptionScope: default),
                    new MockResponse(201))));
            AppendBlobStorageResourceOptions resourceOptions = new()
            {
                CacheControl = default,
                ContentDisposition = default,
                ContentLanguage = default,
                ContentEncoding = default,
                ContentType = default,
                Metadata = default
            };
            AppendBlobStorageResource destinationResource = new AppendBlobStorageResource(mockDestination.Object, resourceOptions);

            // Act
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata }
            };
            StorageResourceCopyFromUriOptions copyFromUriOptions = new()
            {
                SourceProperties = new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = new("ETag"),
                    LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                    RawProperties = sourceProperties
                }
            };
            await destinationResource.CopyBlockFromUriInternalAsync(
                sourceResource.Object,
                new HttpRange(0, length),
                false,
                length,
                copyFromUriOptions);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mockDestination.Verify(b => b.CreateAsync(
                It.Is<AppendBlobCreateOptions>(
                    options => options.Metadata == default),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.AppendBlockFromUriAsync(
                sourceUri,
                It.IsAny<AppendBlobAppendBlockFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [RecordedTest]
        public async Task CopyBlockFromUriAsync_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
                        accessTier: default,
                        copyCompletedOn: DateTimeOffset.MinValue,
                        accessTierChangedOn: DateTimeOffset.MinValue,
                        blobType: BlobType.Block,
                        metadata: metadata,
                        tagCount: 5),
                    new MockResponse(200))));

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(mock.Object);

            // Act
            StorageResourceItemProperties result = await storageResource.GetPropertiesInternalAsync();
            string contentEncodingResult = (string)result.RawProperties[DataMovementConstants.ResourceProperties.ContentEncoding];
            string contentDispositionResult = (string)result.RawProperties[DataMovementConstants.ResourceProperties.ContentDisposition];
            string contentLanguageResult = (string)result.RawProperties[DataMovementConstants.ResourceProperties.ContentLanguage];
            string contentTypeResult = (string)result.RawProperties[DataMovementConstants.ResourceProperties.ContentType];
            string cacheControlResult = (string)result.RawProperties[DataMovementConstants.ResourceProperties.CacheControl];
            Metadata metadataResult = (Metadata)result.RawProperties[DataMovementConstants.ResourceProperties.Metadata];

            // Assert
            Assert.AreEqual(eTag, result.ETag);
            Assert.AreEqual(length, result.ResourceLength);
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
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition},
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage},
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType},
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl},
                { DataMovementConstants.ResourceProperties.Metadata, metadata },
            };

            BlockBlobStorageResource storageResource = new BlockBlobStorageResource(
                mock.Object,
                new StorageResourceItemProperties()
                {
                    ResourceLength = length,
                    ETag = eTag,
                    LastModifiedTime = lastModified,
                    RawProperties = rawProperties
                });

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            BlobServiceClient service = GetServiceClient_OAuth();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(
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
