// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [TestFixture]
    public class StorageResourceEtagManagementTests
    {
        [Test]
        public async Task BlockBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<BlockBlobClient> mock = new();
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    new BlobProperties(),
                    new MockResponse(200).WithHeader(Constants.HeaderNames.ETag, etag.ToString()))));
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            BlockBlobStorageResource storageResource = new(mock.Object);
            await storageResource.GetPropertiesAsync();
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task PageBlobBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<PageBlobClient> mock = new();
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    new BlobProperties(),
                    new MockResponse(200).WithHeader(Constants.HeaderNames.ETag, etag.ToString()))));
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            PageBlobStorageResource storageResource = new(mock.Object);
            await storageResource.GetPropertiesAsync();
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task AppendBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<AppendBlobClient> mock = new();
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    new BlobProperties(),
                    new MockResponse(200).WithHeader(Constants.HeaderNames.ETag, etag.ToString()))));
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            AppendBlobStorageResource storageResource = new(mock.Object);
            await storageResource.GetPropertiesAsync();
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.GetPropertiesAsync(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }
    }
}
