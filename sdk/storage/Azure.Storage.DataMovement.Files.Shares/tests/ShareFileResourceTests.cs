// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Moq;
using Moq.Protected;
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
                Assert.That(data, Is.EqualTo(result.Content.AsBytes().ToArray()));
            }
            mock.Verify(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
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
                Assert.That(data, Is.EqualTo(result.Content.AsBytes().ToArray()));
            }
            mock.Verify(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
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
            mock.Verify(b => b.DownloadAsync(It.IsAny<ShareFileDownloadOptions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.UploadRangeAsync(It.IsAny<HttpRange>(), It.IsAny<Stream>(), It.IsAny<ShareFileUploadRangeOptions>(), It.IsAny<CancellationToken>()))
                .Callback<HttpRange, Stream, ShareFileUploadRangeOptions, CancellationToken>(
                async (range, uploadedstream, options, token) =>
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
                    new MockResponse(201))));
            mock.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(false, new MockResponse(200))));
            mock.Setup(b => b.CreateAsync(It.IsAny<long>(), It.IsAny<ShareFileHttpHeaders>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        isServerEncrypted: false,
                        filePermissionKey: "rw",
                        fileAttributes: "Archive|ReadOnly",
                        fileCreationTime: DateTimeOffset.UtcNow,
                        fileLastWriteTime: DateTimeOffset.UtcNow,
                        fileChangeTime: DateTimeOffset.UtcNow,
                        fileId: "48903841",
                        fileParentId: "93024923"),
                    new MockResponse(200))));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                completeLength: length);

            Assert.That(data, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(0, length),
                stream,
                It.IsAny<ShareFileUploadRangeOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.CreateAsync(
                length,
                It.IsAny<ShareFileHttpHeaders>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<FileSmbProperties>(),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
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
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var fileContentStream = new MemoryStream();
            mock.Setup(b => b.UploadRangeAsync(It.IsAny<HttpRange>(), It.IsAny<Stream>(), It.IsAny<ShareFileUploadRangeOptions>(), It.IsAny<CancellationToken>()))
                .Callback<HttpRange, Stream, ShareFileUploadRangeOptions, CancellationToken>(
                async (range, uploadedstream, options, token) =>
                {
                    fileContentStream.Position = position;
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

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                completeLength: length,
                options: new StorageResourceWriteToOffsetOptions() { Position = position });

            // Assert
            byte[] dataAt5 = new byte[data.Length + position];
            Array.Copy(data, 0, dataAt5, position, length);
            Assert.That(dataAt5, Is.EqualTo(fileContentStream.AsBytes().ToArray()));
            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(position, length),
                stream,
                It.IsAny<ShareFileUploadRangeOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromStreamAsync_Error()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            mock.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(true, new MockResponse(200))));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            int length = 1024;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<InvalidOperationException>(
                storageResource.CopyFromStreamInternalAsync(stream, length, false, length),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Cannot overwrite file."));
                });
            }
            mock.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.Path, Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync()
        {
            // Arrange
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"));

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
            mockDestination.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(false, new MockResponse(200))));
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<long>(), It.IsAny<ShareFileHttpHeaders>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        isServerEncrypted: false,
                        filePermissionKey: "rw",
                        fileAttributes: "Archive|ReadOnly",
                        fileCreationTime: DateTimeOffset.UtcNow,
                        fileLastWriteTime: DateTimeOffset.UtcNow,
                        fileChangeTime: DateTimeOffset.UtcNow,
                        fileId: "48903841",
                        fileParentId: "93024923"),
                    new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            int length = 1024;
            await destinationResource.CopyFromUriInternalAsync(sourceResource.Object, false, length);

            sourceResource.Verify(b => b.Uri, Times.Once());
            sourceResource.VerifyNoOtherCalls();
            mockDestination.Verify(b => b.UploadRangeFromUriAsync(
                sourceResource.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.IsAny<ShareFileUploadRangeFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.CreateAsync(
                length,
                It.IsAny<ShareFileHttpHeaders>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<FileSmbProperties>(),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_Error()
        {
            // Arrange
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"));

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(true, new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            // Act
            int length = 1024;
            await TestHelper.AssertExpectedExceptionAsync<InvalidOperationException>(
                destinationResource.CopyBlockFromUriInternalAsync(sourceResource.Object, new HttpRange(0, length), false, length),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Cannot overwrite file."));
                });

            sourceResource.VerifyNoOtherCalls();
            mockDestination.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.Path, Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync()
        {
            // Arrange
            int length = 1024;
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"));

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
            mockDestination.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(false,new MockResponse(200))));
            mockDestination.Setup(b => b.CreateAsync(It.IsAny<long>(), It.IsAny<ShareFileHttpHeaders>(), It.IsAny<Dictionary<string,string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    FilesModelFactory.StorageFileInfo(
                        eTag: new ETag("eTag"),
                        lastModified: DateTimeOffset.UtcNow,
                        isServerEncrypted: false,
                        filePermissionKey: "rw",
                        fileAttributes: "Archive|ReadOnly",
                        fileCreationTime: DateTimeOffset.UtcNow,
                        fileLastWriteTime: DateTimeOffset.UtcNow,
                        fileChangeTime: DateTimeOffset.UtcNow,
                        fileId: "48903841",
                        fileParentId: "93024923"),
                    new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            // Act
            await destinationResource.CopyBlockFromUriInternalAsync(
                sourceResource: sourceResource.Object,
                overwrite: false,
                range: new HttpRange(0, length),
                completeLength: length);

            sourceResource.Verify(b => b.Uri, Times.Once());
            sourceResource.VerifyNoOtherCalls();
            mockDestination.Verify(b => b.UploadRangeFromUriAsync(
                sourceResource.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.IsAny<ShareFileUploadRangeFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.CreateAsync(
                length,
                It.IsAny<ShareFileHttpHeaders>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<FileSmbProperties>(),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_Error()
        {
            // Arrange
            Mock<StorageResourceItem> sourceResource = new();
            sourceResource.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.file.core.windows.net/container/sourcefile"));

            Mock<ShareFileClient> mockDestination = new(
                new Uri("https://storageaccount.file.core.windows.net/container/destinationfile"),
                new ShareClientOptions());

            mockDestination.Setup(b => b.ExistsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(true, new MockResponse(200))));
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object);

            // Act
            int length = 1024;
            await TestHelper.AssertExpectedExceptionAsync<InvalidOperationException>(
                destinationResource.CopyBlockFromUriInternalAsync(sourceResource.Object, new HttpRange(0, length), false, length),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Cannot overwrite file."));
                });

            sourceResource.VerifyNoOtherCalls();
            mockDestination.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockDestination.Verify(b => b.Path, Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());

            long length = 1024;
            string source = "https://storageaccount.file.core.windows.net/container/file2";
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
                        copySource: source,
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
            StorageResourceItemProperties result = await storageResource.GetPropertiesInternalAsync();
            Mock<StorageResourceItemProperties> properties = new Mock<StorageResourceItemProperties>(result);

            // Assert
            Assert.NotNull(result);
            mock.Verify(b => b.GetPropertiesAsync(It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
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
            mock.Verify(b => b.GetPropertiesAsync(It.IsAny<ShareFileRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetCopyAuthorizationHeaderAsync()
        {
            CancellationToken cancellationToken = new();
            string expectedToken = "foo";
            AccessToken accessToken = new(expectedToken, DateTimeOffset.UtcNow);

            Mock<TokenCredential> tokenCred = new();
            tokenCred.Setup(t => t.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(Task.FromResult(accessToken)));

            ShareFileClient client = new(new Uri("https://example.file.core.windows.net/share/file"), tokenCred.Object);
            ShareFileStorageResource resource = new(client);

            // Act - Get access token
            HttpAuthorization authorization = await resource.GetCopyAuthorizationHeaderInternalAsync(cancellationToken);

            // Assert
            Assert.That(authorization.Parameter, Is.EqualTo(expectedToken));
            tokenCred.Verify(t => t.GetTokenAsync(It.IsAny<TokenRequestContext>(), cancellationToken), Times.Once());
            tokenCred.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetCopyAuthorizationHeaderAsync_NoOAuth()
        {
            ShareFileClient nonOAuthClient = new(new Uri("https://example.file.core.windows.net/share/file"));
            ShareFileStorageResource resource = new(nonOAuthClient);

            Assert.That(await resource.GetCopyAuthorizationHeaderInternalAsync(), Is.Null);
        }
    }
}
