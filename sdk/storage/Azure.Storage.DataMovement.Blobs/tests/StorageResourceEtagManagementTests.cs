// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [TestFixture]
    public class StorageResourceEtagManagementTests
    {
        private const string ETag = "ETag";

        [Test]
        public async Task BlockBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new(0, etag, DateTimeOffset.UtcNow ,default);

            BlockBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task PageBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<PageBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new(0, etag, DateTimeOffset.UtcNow ,default);

            PageBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task AppendBlobMaintainsEtagForDownloads()
        {
            ETag etag = new ETag("foo");
            Mock<AppendBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new(0, etag, DateTimeOffset.UtcNow ,default);

            AppendBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.GetPropertiesInternalAsync();
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task BlockBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<BlockBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties resourceProperties = new(
                resourceLength: default,
                eTag: etag,
                lastModifiedTime: DateTimeOffset.UtcNow,
                properties: default);

            BlockBlobStorageResource storageResource = new(mock.Object, resourceProperties);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task PageBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<PageBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties resourceProperties = new(
                resourceLength: default,
                eTag: etag,
                lastModifiedTime: DateTimeOffset.UtcNow,
                properties: default);

            PageBlobStorageResource storageResource = new(mock.Object, resourceProperties);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task AppendBlobUsesProvidedEtag()
        {
            ETag etag = new ETag("foo");
            Mock<AppendBlobClient> mock = new(
                new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                new BlobClientOptions());
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new(0, etag, DateTimeOffset.UtcNow ,default);

            AppendBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == etag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task ContainerProvidesETagFromList()
        {
            // Arrange

            List<BlobType> blobTypes = new() { BlobType.Block, BlobType.Page, BlobType.Append };
            Random random = new();
            List<ETag> etags = Enumerable.Range(0, blobTypes.Count)
                .Select(_ => new ETag(Convert.ToBase64String(Guid.NewGuid().ToByteArray())))
                .ToList();
            List<string> names = Enumerable.Range(0, blobTypes.Count)
                .Select(_ => Guid.NewGuid().ToString())
                .ToList();
            List<BlobItem> blobListItems = Enumerable.Range(0, blobTypes.Count)
                .Select(i => BlobsModelFactory.BlobItem(
                    name: names[i],
                    properties: BlobsModelFactory.BlobItemProperties(
                        accessTierInferred: false,
                        eTag: etags[i],
                        blobType: blobTypes[i]))).ToList();
            Mock<BlobContainerClient> mock = new(new Uri("https://storageaccount.blob.core.windows.net/container"), new BlobClientOptions())
            {
                CallBase = true
            };
            mock.Setup(c => c.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<BlobItem>.FromPages(new List<Page<BlobItem>>()
                {
                    Page<BlobItem>.FromValues(
                        blobListItems,
                        continuationToken: null,
                        response: null)
                }));

            // Act
            BlobStorageResourceContainer containerResource = new(mock.Object);
            List<StorageResource> children = await containerResource.GetStorageResourcesInternalAsync().ToEnumerableAsync();

            // Assert

            // to assert each child resource is initialized with the correct etag, mock the backing client
            // and assert the client is recieving the etag in its calls.
            Assert.AreEqual(blobTypes.Count, children.Count);
            for (int i = 0; i < blobTypes.Count; i++)
            {
                ETag expectedEtag = etags[i];
                BlobType blobType = blobTypes[i];
                switch (blobType)
                {
                    case BlobType.Block:
                        BlockBlobStorageResource blockChild = children[i] as BlockBlobStorageResource;
                        Mock<BlockBlobClient> blockClient = new(
                            new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                            new BlobClientOptions());
                        blockClient.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                            .Returns(Task.FromResult(Response.FromValue(
                                BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                                new MockResponse(201))));
                        blockChild.BlobClient = blockClient.Object;

                        await blockChild.ReadStreamInternalAsync();

                        blockClient.Verify(
                            b => b.DownloadStreamingAsync(
                                It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == expectedEtag),
                                It.IsAny<CancellationToken>()),
                            Times.Once());
                        break;

                    case BlobType.Page:
                        PageBlobStorageResource pageChild = children[i] as PageBlobStorageResource;
                        Mock<PageBlobClient> pageClient = new(
                            new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                            new BlobClientOptions());
                        pageClient.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                            .Returns(Task.FromResult(Response.FromValue(
                                BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                                new MockResponse(201))));
                        pageChild.BlobClient = pageClient.Object;

                        await pageChild.ReadStreamInternalAsync();

                        pageClient.Verify(
                            b => b.DownloadStreamingAsync(
                                It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == expectedEtag),
                                It.IsAny<CancellationToken>()),
                            Times.Once());
                        break;

                    case BlobType.Append:
                        AppendBlobStorageResource appendChild = children[i] as AppendBlobStorageResource;
                        Mock<AppendBlobClient> appendClient = new(
                            new Uri("https://storageaccount.blob.core.windows.net/container/blob"),
                            new BlobClientOptions());
                        appendClient.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                            .Returns(Task.FromResult(Response.FromValue(
                                BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                                new MockResponse(201))));
                        appendChild.BlobClient = appendClient.Object;

                        await appendChild.ReadStreamInternalAsync();

                        appendClient.Verify(
                            b => b.DownloadStreamingAsync(
                                It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == expectedEtag),
                                It.IsAny<CancellationToken>()),
                            Times.Once());
                        break;
                }
            }
        }
    }
}
