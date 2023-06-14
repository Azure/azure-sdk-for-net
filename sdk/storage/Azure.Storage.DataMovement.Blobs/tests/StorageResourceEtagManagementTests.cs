// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        [Test]
        public async Task BlockBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<BlockBlobClient> mock = new();
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            BlockBlobStorageResource storageResource = new(mock.Object, length: default, etag);
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task PageBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<PageBlobClient> mock = new();
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            PageBlobStorageResource storageResource = new(mock.Object, length: default, etag);
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task AppendBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<AppendBlobClient> mock = new();
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            AppendBlobStorageResource storageResource = new(mock.Object, length: default, etag);
            await storageResource.ReadStreamAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task ContainerProvidesETagFromList()
        {
            const int blobCount = 3;
            Random random = new();
            List<ETag> etags = Enumerable.Range(0, blobCount)
                .Select(_ => new ETag(Convert.ToBase64String(Guid.NewGuid().ToByteArray())))
                .ToList();
            Mock<BlobContainerClient> mock = new();
            mock.Setup(c => c.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<BlobItem>.FromPages(new List<Page<BlobItem>>()
                {
                    Page<BlobItem>.FromValues(
                        etags.Select(etag => BlobsModelFactory.BlobItemProperties(accessTierInferred: false, eTag: etag))
                            .Select(props => BlobsModelFactory.BlobItem(properties: props))
                            .ToList(),
                        continuationToken: null,
                        response: null)
                }));

            BlobStorageResourceContainer containerResource = new(mock.Object);
            List<StorageResourceBase> children = await containerResource.GetStorageResourcesAsync().ToEnumerableAsync();

            // Assert each child has the correct etag
            Assert.AreEqual(etags.Count, children.Count);
            for (int i = 0; i < children.Count; i++)
            {
                BlockBlobStorageResource child = children[i] as BlockBlobStorageResource;
                ETag expectedEtag = etags[i];
                //replace resource's client with a mock
                Mock<BlockBlobClient> bbClient = new();
                bbClient.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                        new MockResponse(201))));
                child.BlobClient = bbClient.Object;

                await child.ReadStreamAsync();

                bbClient.Verify(
                    b => b.DownloadStreamingAsync(
                        It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == expectedEtag),
                        It.IsAny<CancellationToken>()),
                    Times.Once());
                bbClient.VerifyNoOtherCalls();
            }
        }
    }
}
