﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareFileResourceTests
    {
        private const string DefaultContentType = "text/plain";
        private readonly string[] DefaultContentEncoding = new[] { "gzip", "compress" };
        private readonly string[] DefaultContentLanguage = new[] { "en-US", "en-CA" };
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private const string DefaultFilePermissionKey = "key";
        private const NtfsFileAttributes DefaultFileAttributes = NtfsFileAttributes.Archive | NtfsFileAttributes.ReadOnly;
        private readonly DateTimeOffset DefaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset DefaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset DefaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        private readonly Dictionary<string,string> DefaultFileMetadata = new(StringComparer.OrdinalIgnoreCase)
        {
            { "fkey", "fvalue" },
            { "fi", "le" },
            { "fCapital", "fletter" },
            { "FUPPER", "fcase" }
        };
        private readonly Dictionary<string, string> DefaultDirectoryMetadata = new(StringComparer.OrdinalIgnoreCase)
        {
            { "dkey", "dvalue" },
            { "dir", "ectory" },
            { "dCapital", "dletter" },
            { "DUPPER", "dcase" }
        };

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

        private async Task<Mock<ShareFileClient>> CopyFromStreamPreserveProperties_Internal(
            Stream stream,
            int length,
            ShareFileStorageResourceOptions resourceOptions,
            Dictionary<string, object> sourceProperties)
        {
            // Arrange
            Mock<ShareFileClient> mock = new(
                new Uri("https://storageaccount.file.core.windows.net/container/file"),
                new ShareClientOptions());
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
                        fileCreationTime: DefaultFileCreatedOn,
                        fileLastWriteTime: DefaultFileLastWrittenOn,
                        fileChangeTime: DefaultFileChangedOn,
                        fileId: "48903841",
                        fileParentId: "93024923"),
                    new MockResponse(200))));

            // Act
            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object, resourceOptions);

            await storageResource.CopyFromStreamInternalAsync(
                stream: stream,
                streamLength: length,
                overwrite: false,
                completeLength: length,
                options: new()
                {
                    SourceProperties = new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties)
                });

            return mock;
        }

        [Test]
        public async Task CopyFromStreamAsync_PropertiesDefault()
        {
            // Arrange
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);

            // Act
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            Mock<ShareFileClient> mock = await CopyFromStreamPreserveProperties_Internal(
                stream: stream,
                length: length,
                resourceOptions: default,
                sourceProperties: sourceProperties);

            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(0, length),
                stream,
                It.Is<ShareFileUploadRangeOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Now),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
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
        public async Task CopyFromStreamAsync_PropertiesPreserve()
        {
            // Arrange
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);

            // Act
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            Mock<ShareFileClient> mock = await CopyFromStreamPreserveProperties_Internal(
                stream: stream,
                length: length,
                resourceOptions: new ShareFileStorageResourceOptions()
                {
                    ContentType = new(true),
                    ContentDisposition = new(true),
                    ContentEncoding = new(true),
                    ContentLanguage = new(true),
                    CacheControl = new(true),
                    FileAttributes = new(true),
                    FilePermissionKey = default,
                    FileCreatedOn = new(true),
                    FileLastWrittenOn = new(true),
                    FileChangedOn = new(true),
                    FileMetadata = new(true)
                },
                sourceProperties: sourceProperties);

            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(0, length),
                stream,
                It.Is<ShareFileUploadRangeOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
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
        public async Task CopyFromStreamAsync_PropertiesNoPreserve()
        {
            // Arrange
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);

            // Act
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            Mock<ShareFileClient> mock = await CopyFromStreamPreserveProperties_Internal(
                stream: stream,
                length: length,
                resourceOptions: new ShareFileStorageResourceOptions()
                {
                    ContentType = new(false),
                    ContentDisposition = new(false),
                    ContentEncoding = new(false),
                    ContentLanguage = new(false),
                    CacheControl = new(false),
                    FileAttributes = new(false),
                    FilePermissionKey = default,
                    FileCreatedOn = new(false),
                    FileLastWrittenOn = new(false),
                    FileChangedOn = new(false),
                    FileMetadata = new(false)
                },
                sourceProperties: sourceProperties);

            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(0, length),
                stream,
                It.Is<ShareFileUploadRangeOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Now),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == default &&
                    headers.ContentDisposition == default &&
                    headers.ContentEncoding == default &&
                    headers.ContentType == default),
                default,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == default &&
                    properties.FileLastWrittenOn == default &&
                    properties.FileChangedOn == default),
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
        public async Task CopyFromStreamAsync_SetProperties()
        {
            // Arrange
            int length = 1024;
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);

            // Act
            Mock<ShareFileClient> mock = await CopyFromStreamPreserveProperties_Internal(
                stream: stream,
                length: length,
                resourceOptions: new ShareFileStorageResourceOptions()
                {
                    ContentType = new(DefaultContentType),
                    ContentDisposition = new(DefaultContentDisposition),
                    ContentEncoding = new(DefaultContentEncoding),
                    ContentLanguage = new(DefaultContentLanguage),
                    CacheControl = new(DefaultCacheControl),
                    FileAttributes = new(DefaultFileAttributes),
                    FilePermissionKey = default,
                    FileCreatedOn = new(DefaultFileCreatedOn),
                    FileLastWrittenOn = new(DefaultFileLastWrittenOn),
                    FileChangedOn = new(DefaultFileChangedOn),
                    FileMetadata = new(DefaultFileMetadata)
                },
                sourceProperties: default);

            mock.Verify(b => b.UploadRangeAsync(
                new HttpRange(0, length),
                stream,
                It.Is<ShareFileUploadRangeOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
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

        private async Task<Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>>> CopyFromUriAsyncPreserveProperties_Internal(
            int length,
            ShareFileStorageResourceOptions resourceOptions,
            StorageResourceItemProperties sourceProperties)
        {
            // Arrange
            Mock<StorageResourceItem> mockSource = new();
            mockSource.Setup(b => b.Uri)
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
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object, resourceOptions);

            await destinationResource.CopyFromUriInternalAsync(
                mockSource.Object,
                false,
                length,
                new StorageResourceCopyFromUriOptions()
                {
                    SourceProperties = sourceProperties
                });

            mockSource.Verify(b => b.Uri, Times.Once());
            mockSource.VerifyNoOtherCalls();

            return new Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>>(mockSource, mockDestination);
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesDefault()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyFromUriAsyncPreserveProperties_Internal(
                    length,
                    default,
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesPreserve()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(true),
                        ContentDisposition = new(true),
                        ContentEncoding = new(true),
                        ContentLanguage = new(true),
                        CacheControl = new(true),
                        FileAttributes = new(true),
                        FilePermissionKey = default,
                        FileCreatedOn = new(true),
                        FileLastWrittenOn = new(true),
                        FileChangedOn = new(true),
                        FileMetadata = new(true)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_PropertiesNoPreserve()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(false),
                        ContentDisposition = new(false),
                        ContentEncoding = new(false),
                        ContentLanguage = new(false),
                        CacheControl = new(false),
                        FileAttributes = new(false),
                        FilePermissionKey = default,
                        FileCreatedOn = new(false),
                        FileLastWrittenOn = new(false),
                        FileChangedOn = new(false),
                        FileMetadata = new(false)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == default &&
                    headers.ContentDisposition == default &&
                    headers.ContentEncoding == default &&
                    headers.ContentType == default),
                default,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == default &&
                    properties.FileLastWrittenOn == default &&
                    properties.FileChangedOn == default),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Now),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyFromUriAsync_SetProperties()
        {
            // Arrange
            int length = 1024;

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(DefaultContentType),
                        ContentDisposition = new(DefaultContentDisposition),
                        ContentEncoding = new(DefaultContentEncoding),
                        ContentLanguage = new(DefaultContentLanguage),
                        CacheControl = new(DefaultCacheControl),
                        FileAttributes = new(DefaultFileAttributes),
                        FilePermissionKey = default,
                        FileCreatedOn = new(DefaultFileCreatedOn),
                        FileLastWrittenOn = new(DefaultFileLastWrittenOn),
                        FileChangedOn = new(DefaultFileChangedOn),
                        FileMetadata = new(DefaultFileMetadata)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        default));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
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

        private async Task<Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>>> CopyBlockFromUriAsyncPreserveProperties_Internal(
            int length,
            ShareFileStorageResourceOptions resourceOptions,
            StorageResourceItemProperties sourceProperties)
        {
            // Arrange
            Mock<StorageResourceItem> mockSource = new();
            mockSource.Setup(b => b.Uri)
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
            ShareFileStorageResource destinationResource = new ShareFileStorageResource(mockDestination.Object, resourceOptions);

            await destinationResource.CopyBlockFromUriInternalAsync(
                mockSource.Object,
                new HttpRange(0, length),
                false,
                length,
                new StorageResourceCopyFromUriOptions()
                {
                    SourceProperties = sourceProperties
                });

            mockSource.Verify(b => b.Uri, Times.Once());
            mockSource.VerifyNoOtherCalls();

            return new Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>>(mockSource, mockDestination);
        }

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesDefault()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyBlockFromUriAsyncPreserveProperties_Internal(
                    length,
                    default,
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Assert
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesPreserve()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyBlockFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(true),
                        ContentDisposition = new(true),
                        ContentEncoding = new(true),
                        ContentLanguage = new(true),
                        CacheControl = new(true),
                        FileAttributes = new(true),
                        FilePermissionKey = default,
                        FileCreatedOn = new(true),
                        FileLastWrittenOn = new(true),
                        FileChangedOn = new(true),
                        FileMetadata = new(true)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_PropertiesNoPreserve()
        {
            // Arrange
            int length = 1024;
            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.FileAttributes, DefaultFileAttributes },
                { DataMovementConstants.ResourceProperties.FilePermissionKey, DefaultFilePermissionKey },
                { DataMovementConstants.ResourceProperties.CreationTime, DefaultFileCreatedOn },
                { DataMovementConstants.ResourceProperties.ChangedOnTime, DefaultFileChangedOn },
                { DataMovementConstants.ResourceProperties.Metadata, DefaultFileMetadata }
            };

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyBlockFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(false),
                        ContentDisposition = new(false),
                        ContentEncoding = new(false),
                        ContentLanguage = new(false),
                        CacheControl = new(false),
                        FileAttributes = new(false),
                        FilePermissionKey = default,
                        FileCreatedOn = new(false),
                        FileLastWrittenOn = new(false),
                        FileChangedOn = new(false),
                        FileMetadata = new(false)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        sourceProperties));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == default &&
                    headers.ContentDisposition == default &&
                    headers.ContentLanguage == default &&
                    headers.ContentEncoding == default &&
                    headers.ContentType == default),
                default,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == default &&
                    properties.FileLastWrittenOn == default &&
                    properties.FileChangedOn == default),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Now),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CopyBlockFromUriAsync_SetProperties()
        {
            // Arrange
            int length = 1024;

            // Act
            Tuple<Mock<StorageResourceItem>, Mock<ShareFileClient>> mockTuple =
                await CopyBlockFromUriAsyncPreserveProperties_Internal(
                    length,
                    resourceOptions: new ShareFileStorageResourceOptions()
                    {
                        ContentType = new(DefaultContentType),
                        ContentDisposition = new(DefaultContentDisposition),
                        ContentEncoding = new(DefaultContentEncoding),
                        ContentLanguage = new(DefaultContentLanguage),
                        CacheControl = new(DefaultCacheControl),
                        FileAttributes = new(DefaultFileAttributes),
                        FilePermissionKey = default,
                        FileCreatedOn = new(DefaultFileCreatedOn),
                        FileLastWrittenOn = new(DefaultFileLastWrittenOn),
                        FileChangedOn = new(DefaultFileChangedOn),
                        FileMetadata = new(DefaultFileMetadata)
                    },
                    new StorageResourceItemProperties(
                        length,
                        new ETag("eTag"),
                        DefaultFileLastWrittenOn,
                        default));

            // Verify
            mockTuple.Item2.Verify(b => b.CreateAsync(
                length,
                It.Is<ShareFileHttpHeaders>(headers =>
                    headers.CacheControl == DefaultCacheControl &&
                    headers.ContentDisposition == DefaultContentDisposition &&
                    headers.ContentEncoding == DefaultContentEncoding &&
                    headers.ContentType == DefaultContentType),
                DefaultFileMetadata,
                It.Is<FileSmbProperties>(properties =>
                    properties.FileCreatedOn == DefaultFileCreatedOn &&
                    properties.FileLastWrittenOn == DefaultFileLastWrittenOn &&
                    properties.FileChangedOn == DefaultFileChangedOn),
                It.IsAny<string>(),
                It.IsAny<ShareFileRequestConditions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.UploadRangeFromUriAsync(
                mockTuple.Item1.Object.Uri,
                new HttpRange(0, length),
                new HttpRange(0, length),
                It.Is<ShareFileUploadRangeFromUriOptions>(options =>
                    options.FileLastWrittenMode == FileLastWrittenMode.Preserve),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.Verify(b => b.ExistsAsync(
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockTuple.Item2.VerifyNoOtherCalls();
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
                        metadata: DefaultFileMetadata,
                        contentLength: length,
                        contentType: DefaultContentType,
                        eTag: new ETag("etag"),
                        contentHash: default,
                        contentEncoding: DefaultContentEncoding,
                        cacheControl: DefaultCacheControl,
                        contentDisposition: DefaultContentDisposition,
                        contentLanguage: DefaultContentLanguage,
                        copyCompletedOn: DateTimeOffset.MinValue,
                        copyStatusDescription: default,
                        copyId: default,
                        copyProgress: default,
                        copySource: source,
                        copyStatus: CopyStatus.Success,
                        isServerEncrypted: false,
                        fileAttributes: DefaultFileAttributes,
                        fileCreationTime: DefaultFileCreatedOn,
                        fileLastWriteTime: DefaultFileLastWrittenOn,
                        fileChangeTime: DefaultFileChangedOn,
                        filePermissionKey: DefaultFilePermissionKey,
                        fileId: default,
                        fileParentId: default),
                    new MockResponse(200))));

            ShareFileStorageResource storageResource = new ShareFileStorageResource(mock.Object);

            // Act
            StorageResourceItemProperties result = await storageResource.GetPropertiesInternalAsync();
            Mock<StorageResourceItemProperties> properties = new Mock<StorageResourceItemProperties>(result);

            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.ContentType, out object contentTypeObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object contentEncodingObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object contentLanguageObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.ContentDisposition, out object contentDispositionObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object cacheControlObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.FileAttributes, out object fileAttributesObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadataObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.CreationTime, out object createdOnObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.ChangedOnTime, out object changedOnObject);
            result.RawProperties.TryGetValue(DataMovementConstants.ResourceProperties.FilePermissionKey, out object permissionKeyObject);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(length, result.ResourceLength);
            Assert.AreEqual(DefaultFileMetadata, (Metadata) metadataObject);
            Assert.AreEqual(DefaultCacheControl, (string) cacheControlObject);
            Assert.AreEqual(DefaultContentDisposition, (string) contentDispositionObject);
            Assert.AreEqual(DefaultContentEncoding, (string[]) contentEncodingObject);
            Assert.AreEqual(DefaultContentLanguage, (string[]) contentLanguageObject);
            Assert.AreEqual(DefaultContentType, (string) contentTypeObject);
            Assert.AreEqual(DefaultFileAttributes, (NtfsFileAttributes) fileAttributesObject);
            Assert.AreEqual(DefaultFileCreatedOn, (DateTimeOffset) createdOnObject);
            Assert.AreEqual(DefaultFileLastWrittenOn, result.LastModifiedTime);
            Assert.AreEqual(DefaultFileChangedOn, (DateTimeOffset) changedOnObject);
            Assert.AreEqual(DefaultFilePermissionKey, (string) permissionKeyObject);

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
