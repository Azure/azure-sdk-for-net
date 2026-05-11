// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [TestFixture]
    public class StorageResourceEtagManagementTests
    {
        private readonly ETag _eTag = new ETag("ETag");
        private readonly Uri _blobUri = new Uri("https://storageaccount.blob.core.windows.net/container/blob");

        [Test]
        public async Task BlockBlobMaintainsEtagForDownloads()
        {
            Mock<BlockBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new()
            {
                ResourceLength = 0,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            BlockBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task PageBlobMaintainsEtagForDownloads()
        {
            Mock<PageBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new()
            {
                ResourceLength = 0,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            PageBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task AppendBlobMaintainsEtagForDownloads()
        {
            Mock<AppendBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new()
            {
                ResourceLength = 0,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            AppendBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.GetPropertiesInternalAsync();
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task BlockBlobUsesProvidedEtag()
        {
            Mock<BlockBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties resourceProperties = new()
            {
                ResourceLength = default,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            BlockBlobStorageResource storageResource = new(mock.Object, resourceProperties);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task PageBlobUsesProvidedEtag()
        {
            Mock<PageBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties resourceProperties = new()
            {
                ResourceLength = default,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            PageBlobStorageResource storageResource = new(mock.Object, resourceProperties);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task AppendBlobUsesProvidedEtag()
        {
            Mock<AppendBlobClient> mock = new(
                _blobUri,
                new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(_blobUri);
            mock.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    BlobsModelFactory.BlobDownloadStreamingResult(Stream.Null, new BlobDownloadDetails()),
                    new MockResponse(201))));

            StorageResourceItemProperties properties = new()
            {
                ResourceLength = 0,
                ETag = _eTag,
                LastModifiedTime = DateTimeOffset.UtcNow
            };

            AppendBlobStorageResource storageResource = new(mock.Object, properties, default);
            await storageResource.ReadStreamInternalAsync();

            mock.Verify(
                b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(options => options.Conditions.IfMatch == _eTag),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task ContainerProvidesETagFromList()
        {
            // Arrange

            List<BlobType> blobTypes = new() { BlobType.Block, BlobType.Page, BlobType.Append };
            Random random = new();
            List<ETag> _eTags = Enumerable.Range(0, blobTypes.Count)
                .Select(_ => new ETag(Convert.ToBase64String(Guid.NewGuid().ToByteArray())))
                .ToList();
            List<string> names = Enumerable.Range(0, blobTypes.Count)
                .Select(_ => Guid.NewGuid().ToString())
                .ToList();
            List<BlobHierarchyItem> blobListItems = Enumerable.Range(0, blobTypes.Count)
                .Select(i => new BlobHierarchyItem(default, BlobsModelFactory.BlobItem(
                    name: names[i],
                    properties: BlobsModelFactory.BlobItemProperties(
                        accessTierInferred: false,
                        eTag: _eTags[i],
                        blobType: blobTypes[i])))).ToList();
            Mock<BlobContainerClient> mock = new(new Uri("https://storageaccount.blob.core.windows.net/container"), new BlobClientOptions())
            {
                CallBase = true
            };
            mock.Setup(c => c.GetBlobsByHierarchyAsync(
                It.IsAny<BlobTraits>(),
                It.IsAny<BlobStates>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<BlobHierarchyItem>.FromPages(new List<Page<BlobHierarchyItem>>()
                {
                    Page<BlobHierarchyItem>.FromValues(
                        blobListItems,
                        continuationToken: null,
                        response: null)
                }));

            // Act
            BlobStorageResourceContainer containerResource = new(mock.Object);
            List<StorageResource> children = await containerResource.GetStorageResourcesInternalAsync().ToEnumerableAsync();

            // Assert

            // to assert each child resource is initialized with the correct _eTag, mock the backing client
            // and assert the client is recieving the _eTag in its calls.
            Assert.AreEqual(blobTypes.Count, children.Count);
            for (int i = 0; i < blobTypes.Count; i++)
            {
                ETag expectedEtag = _eTags[i];
                BlobType blobType = blobTypes[i];
                switch (blobType)
                {
                    case BlobType.Block:
                        BlockBlobStorageResource blockChild = children[i] as BlockBlobStorageResource;
                        Mock<BlockBlobClient> blockClient = new(
                            _blobUri,
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
                            _blobUri,
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
                            _blobUri,
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
