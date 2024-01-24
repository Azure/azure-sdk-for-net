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
using Azure.Storage.Blobs.Tests;
using Azure.Storage.DataMovement.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobStorageResourceContainerTests : DataMovementBlobTestBase
    {
        public BlobStorageResourceContainerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private string[] BlobNames
            => new[]
            {
                "foo",
                "bar",
                "baz",
                "foo/foo",
                "foo/bar",
                "baz/foo",
                "baz/foo/bar",
                "baz/bar/foo"
            };

        private async Task SetUpContainerForListing(BlobContainerClient container)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            IDictionary<string, string> metadata = BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        [RecordedTest]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            string directoryName = "directoryName";
            BlobContainerClient blobContainerClient = new BlobContainerClient(uri);
            BlobStorageResourceContainer storageResource =
                new BlobStorageResourceContainer(blobContainerClient, new() { BlobDirectoryPrefix = directoryName });

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
        }

        [RecordedTest]
        public async Task GetStorageResourcesAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string folderName = "foo";
            BlobStorageResourceContainer storageResourceContainer =
                new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = folderName });

            var resources = new List<StorageResource>();

            await foreach (StorageResource resource in storageResourceContainer.GetStorageResourcesAsync())
            {
                resources.Add(resource);
            }

            // Assert
            Assert.IsNotEmpty(resources);
            Assert.AreEqual(2, resources.Count);
        }

        [Test]
        public async Task GetStorageResourcesAsync_Empty()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            List<string> emptyList = new();
            TestGetBlobsContainerClient testContainer = new(uri, emptyList);

            string prefix = "foo";
            StorageResourceContainer container = new BlobStorageResourceContainer(
                testContainer, new() { BlobDirectoryPrefix = prefix });

            // Act
            var directories = new List<string>();
            var blobs = new List<string>();
            await foreach (StorageResource resource in container.GetStorageResourcesAsync())
            {
                if (resource.IsContainer)
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    directories.Add(builder.BlobName.Substring(prefix.Length + 1));
                }
                else
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    blobs.Add(builder.BlobName.Substring(prefix.Length + 1));
                }
            }

            // Assert
            Assert.IsEmpty(blobs);
            Assert.IsEmpty(directories);
        }

        [Test]
        public async Task GetStorageResourcesAsync_EmptyPrefix()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            TestGetBlobsContainerClient testContainer = new(uri, BlobNames.ToList());

            List<string> expectedBlobNames = new()
            {
                "foo",
                "bar",
                "baz",
                "foo/foo",
                "foo/bar",
                "baz/foo",
                "baz/foo/bar",
                "baz/bar/foo"
            };
            List<string> expectedDirectories = new()
            {
                "foo",
                "baz",
                "baz/foo",
                "baz/bar"
            };

            StorageResourceContainer container = new BlobStorageResourceContainer(testContainer);

            // Act
            var directories = new List<string>();
            var blobs = new List<string>();
            await foreach (StorageResource resource in container.GetStorageResourcesAsync())
            {
                if (resource.IsContainer)
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    directories.Add(builder.BlobName);
                }
                else
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    blobs.Add(builder.BlobName);
                }
            }

            // Assert
            Assert.AreEqual(expectedBlobNames, blobs);
            Assert.AreEqual(expectedDirectories, directories);
        }

        [Test]
        public async Task GetStorageResourcesAsync_SubDirectories()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            List<string> prefixFooNames = new()
            {
                "foo/blob",
                "foo/moon",
                "foo/star",
                "foo/sun",
                "foo/folder1/subdir/earth",
                "foo/folder1/subdir/rocket",
                "foo/otherfolder/hello",
            };
            List<string> expectedDirectories = new()
            {
                "folder1",
                "folder1/subdir",
                "otherfolder",
            };
            List<string> expectedBlobNames = new()
            {
                "blob",
                "moon",
                "star",
                "sun",
                "folder1/subdir/earth",
                "folder1/subdir/rocket",
                "otherfolder/hello",
            };
            TestGetBlobsContainerClient testContainer = new(uri, prefixFooNames);

            string prefix = "foo";
            StorageResourceContainer container = new BlobStorageResourceContainer(
                testContainer, new() { BlobDirectoryPrefix = prefix });

            // Act
            var directories = new List<string>();
            var blobs = new List<string>();
            await foreach (StorageResource resource in container.GetStorageResourcesAsync())
            {
                if (resource.IsContainer)
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    directories.Add(builder.BlobName.Substring(prefix.Length + 1));
                }
                else
                {
                    BlobUriBuilder builder = new BlobUriBuilder(resource.Uri);
                    blobs.Add(builder.BlobName.Substring(prefix.Length + 1));
                }
            }

            // Assert
            Assert.AreEqual(expectedBlobNames, blobs);
            Assert.AreEqual(expectedDirectories, directories);
        }

        [RecordedTest]
        public async Task GetChildStorageResourceAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = prefix });

            StorageResourceItem resource = containerResource.GetStorageResourceReference("bar");

            // Assert
            StorageResourceItemProperties properties = await resource.GetPropertiesAsync();
            Assert.IsNotNull(properties);
        }

        [Test]
        public void GetChildStorageResourceContainer()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            Mock<BlobContainerClient> mock = new(uri, new BlobClientOptions());
            mock.Setup(b => b.Uri).Returns(uri);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobStorageResourceContainer(mock.Object, new() { BlobDirectoryPrefix = prefix });

            // Act
            string childPath = "bar";
            StorageResourceContainer childContainer = containerResource.GetChildStorageResourceContainer(childPath);

            // Assert
            UriBuilder builder = new UriBuilder(containerResource.Uri);
            builder.Path = string.Join("/", builder.Path, childPath);
            Assert.AreEqual(builder.Uri, childContainer.Uri);
        }
    }
}
