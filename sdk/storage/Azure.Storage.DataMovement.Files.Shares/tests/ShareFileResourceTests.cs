// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareFileResourceTests
    {
        public static byte[] GetRandomBuffer(long size, Random random = null)
        {
            random ??= new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        [Test]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            ShareFileClient fileClient = new ShareFileClient(uri);
            ShareFileStorageResource storageResource = new(fileClient);

            // Assert
            Assert.AreEqual(uri, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        public async Task ReadStreamAsync()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
            int length = 1024;
            string contentRange = "bytes 0-1024/1024";
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                mock.Setup(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileDownloadInfo(
                        content: stream,
                        contentLength: length,
                        contentRange: contentRange),
                    new MockResponse(201))));

                ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

                // Act
                StorageResourceReadStreamResult result = await storageResource.ReadStreamInternalAsync();

                // Assert
                Assert.NotNull(result);
                TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
            }
        }

        [Test]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
            int position = 5;
            int length = 1024;
            string contentRange = "bytes 0-1024/1024";
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                mock.Setup(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileDownloadInfo(
                        content: stream,
                        contentLength: length,
                        contentRange: contentRange),
                    new MockResponse(201))));

                ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

                // Act
                StorageResourceReadStreamResult result = await storageResource.ReadStreamInternalAsync();

                // Assert
                Assert.NotNull(result);
                byte[] dataAt5 = new byte[data.Length - position];
                Array.Copy(data, position, dataAt5, 0, data.Length - position);
                TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
            }
        }

        [Test]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            mock.Setup(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The specified resource does not exist.", errorCode: "ResourceNotFound", default));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act without creating the blob
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.ReadStreamInternalAsync(),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });
        }

        [Test]
        public async Task CopyFromStreamAsync()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
            int length = 1024;
            string contentRange = "bytes 0-1024/1024";
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                using var fileContentStream = new MemoryStream();
                mock.Setup(b => b.UploadAsync(It.IsAny<Stream>(), It.IsAny<ShareFileUploadOptions>(), It.IsAny<CancellationToken>()))
                    .Callback<Stream, ShareFileUploadOptions, CancellationToken>(
                    async (uploadedstream, options, token) =>
                    {
                        await uploadedstream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                        fileContentStream.Position = 0;
                    })
                    .Returns(Task.FromResult(Response.FromValue(
                        ShareModelFactory.ShareFileUploadInfo(
                            eTag: new ETag("eTag"),
                            lastModified: DateTimeOffset.UtcNow,
                            contentHash: default,
                            isServerEncrypted: false),
                        new MockResponse(200))));

                mock.Setup(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileDownloadInfo(
                        content: fileContentStream,
                        contentLength: length,
                        contentRange: contentRange),
                    new MockResponse(201))));

                ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

                // Act
                await storageResource.CopyFromStreamInternalAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length);

                // Assert
                ShareFileDownloadInfo result = await mock.Object.DownloadAsync();

                Assert.NotNull(result);
                TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
            }
        }

        [Test]
        public async Task CopyFromStreamAsync_Position()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
            int position = 5;
            int length = 1024;
            string contentRange = "bytes 0-1029/1029";
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                using var fileContentStream = new MemoryStream();
                mock.Setup(b => b.UploadRangeAsync(It.IsAny<HttpRange>(), It.IsAny<Stream>(), It.IsAny<ShareFileUploadRangeOptions>(), It.IsAny<CancellationToken>()))
                    .Callback<HttpRange, Stream, ShareFileUploadRangeOptions, CancellationToken>(
                    async (range, uploadedstream, options, token) =>
                    {
                        fileContentStream.Position = 5;
                        await uploadedstream.CopyToAsync(fileContentStream).ConfigureAwait(false);
                        fileContentStream.Position = 0;
                    })
                    .Returns(Task.FromResult(Response.FromValue(
                        ShareModelFactory.ShareFileUploadInfo(
                            eTag: new ETag("eTag"),
                            lastModified: DateTimeOffset.UtcNow,
                            contentHash: default,
                            isServerEncrypted: false),
                        new MockResponse(200))));

                mock.Setup(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileDownloadInfo(
                        content: fileContentStream,
                        contentLength: length + position,
                        contentRange: contentRange),
                    new MockResponse(201))));

                ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

                // Act
                await storageResource.CopyFromStreamInternalAsync(
                    stream: stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Position = position });

                // Assert
                ShareFileDownloadInfo result = await mock.Object.DownloadAsync();
                Assert.NotNull(result);

                byte[] dataAt5 = new byte[data.Length + position];
                Array.Copy(data, 0, dataAt5, 5, length);
                TestHelper.AssertSequenceEqual(dataAt5, result.Content.AsBytes().ToArray());
            }
        }

        [Test]
        public async Task CopyFromStreamAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            mock.Setup(b => b.UploadAsync(It.IsAny<Stream>(), It.IsAny<ShareFileUploadOptions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The specified resource does not exist.", errorCode: "ResourceNotFound", default));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            int length = 1024;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.CopyFromStreamInternalAsync(stream, length, false, length),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });
            }
        }

        [Test]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            Mock<ShareFileClient> mockSource = new(
                new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"),
                new ShareClientOptions());
            ShareFileStorageResource sourceResource = new ShareFileStorageResource(mockSource.Object);

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.UploadRangeFromUriAsync(It.IsAny<Uri>(), It.IsAny<HttpRange>(), It.IsAny<HttpRange>(), It.IsAny<ShareFileUploadRangeFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    ShareModelFactory.ShareFileUploadInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        isServerEncrypted: false),
                    new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            int length = 1024;
            await destinationResource.CopyFromUriInternalAsync(sourceResource, false, length);
        }

        [Test]
        public async Task CopyFromUriAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mockSource = new(
                new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"),
                new ShareClientOptions());
            ShareFileStorageResource sourceResource = new ShareFileStorageResource(mockSource.Object);

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.UploadRangeFromUriAsync(It.IsAny<Uri>(), It.IsAny<HttpRange>(), It.IsAny<HttpRange>(), It.IsAny<ShareFileUploadRangeFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The specified resource does not exist.", errorCode: "ResourceNotFound", default));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            // Act
            int length = 1024;
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyFromUriInternalAsync(sourceResource, false, length),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });
        }

        [Test]
        public async Task CopyBlockFromUriAsync()
        {
            // Arrange
            Mock<ShareFileClient> mockSource = new(
                new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"),
                new ShareClientOptions());
            ShareFileStorageResource sourceResource = new ShareFileStorageResource(mockSource.Object);

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.UploadRangeFromUriAsync(It.IsAny<Uri>(), It.IsAny<HttpRange>(), It.IsAny<HttpRange>(), It.IsAny<ShareFileUploadRangeFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    ShareModelFactory.ShareFileUploadInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        contentHash: default,
                        isServerEncrypted: false),
                    new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            int length = 1024;
            await destinationResource.CopyFromUriInternalAsync(sourceResource, false, length);

            // Act
            await destinationResource.CopyBlockFromUriInternalAsync(
                sourceResource: sourceResource,
                overwrite: false,
                range: new HttpRange(0, length),
                completeLength: length);
        }

        [Test]
        public async Task CopyBlockFromUriAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mockSource = new(
                new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"),
                new ShareClientOptions());
            ShareFileStorageResource sourceResource = new ShareFileStorageResource(mockSource.Object);

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.UploadRangeFromUriAsync(It.IsAny<Uri>(), It.IsAny<HttpRange>(), It.IsAny<HttpRange>(), It.IsAny<ShareFileUploadRangeFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The specified resource does not exist.", errorCode: "ResourceNotFound", default));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            // Act
            int length = 1024;
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationResource.CopyBlockFromUriInternalAsync(sourceResource, new HttpRange(0, length), false, length),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            long length = 1024;
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileProperties(
                        lastModified: DateTime.MinValue,
                        metadata: default,
                        contentLength: length,
                        contentType: default,
                        eTag: new ETag("etag"),
                        contentHash: default,
                        contentEncoding: default,
                        cacheControl: default,
                        contentDisposition: default,
                        contentLanguage: default,
                        copyCompletedOn: DateTimeOffset.MinValue,
                        copyStatusDescription: default,
                        copyId: default,
                        copyProgress: default,
                        copySource: "https://storageaccount.file.core.windows.net/container/file2",
                        copyStatus: CopyStatus.Success,
                        isServerEncrypted: false,
                        fileAttributes: default,
                        fileCreationTime: DateTimeOffset.MinValue,
                        fileLastWriteTime: DateTimeOffset.MinValue,
                        fileChangeTime: DateTimeOffset.MinValue,
                        filePermissionKey: default,
                        fileId: default,
                        fileParentId: default),
                    new MockResponse(200))));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            StorageResourceProperties result = await storageResource.GetPropertiesInternalAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The specified resource does not exist.", errorCode: "ResourceNotFound", default));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act without creating the blob
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.GetPropertiesInternalAsync(),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });
        }
    }
}
