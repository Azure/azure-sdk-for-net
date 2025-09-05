// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobStorageResourceContainerTests : DataMovementBlobTestBase
    {
        public BlobStorageResourceContainerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private async Task SetUpContainerForListing(BlobContainerClient container)
        {
            string[] blobNames =
            [
                "foo",
                "bar",
                "baz",
                "foo/foo",
                "foo/bar",
                "baz/foo",
                "baz/foo/bar",
                "baz/bar/foo"
            ];

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
                new BlobStorageResourceContainer(blobContainerClient, new() { BlobPrefix = directoryName });

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
        }

        [RecordedTest]
        public async Task GetStorageResourcesAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string folderName = "foo";
            BlobStorageResourceContainer storageResourceContainer =
                new BlobStorageResourceContainer(test.Container, new() { BlobPrefix = folderName });

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
            Dictionary<string, List<(string, bool)>> blobHierarchy = new()
            {
                { "foo/", []},
            };
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            TestGetBlobsContainerClient testContainer = new(uri, blobHierarchy);

            string prefix = "foo";
            StorageResourceContainer container = new BlobStorageResourceContainer(
                testContainer, new() { BlobPrefix = prefix });

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
            Dictionary<string, List<(string Path, bool IsPrefix)>> blobHierarchy = new()
            {
                { string.Empty, [("baz/", true), ("foo/", true), ("bar", false)]},
                { "foo/", [("foo/bar", false), ("foo/foo", false)]},
                { "baz/", [("baz/bar/", true), ("baz/foo/", true)]},
                { "baz/foo/", [("baz/foo/bar", false)]},
                { "baz/bar/", [("baz/bar/foo", false)]},
            };

            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            TestGetBlobsContainerClient testContainer = new(uri, blobHierarchy);

            List<string> expectedBlobNames =
            [
                "bar",
                "foo/bar",
                "foo/foo",
                "baz/bar/foo",
                "baz/foo/bar",
            ];
            List<string> expectedDirectories =
            [
                "baz",
                "foo",
                "baz/bar",
                "baz/foo",
            ];

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
            Dictionary<string, List<(string Path, bool IsPrefix)>> blobHierarchy = new()
            {
                { "foo/", [("foo/folder1/", true), ("foo/otherfolder/", true), ("foo/blob", false), ("foo/moon", false), ("foo/star", false), ("foo/sun", false)]},
                { "foo/folder1/", [("foo/folder1/subdir/", true)]},
                { "foo/otherfolder/", [("foo/otherfolder/hello", false)]},
                { "foo/folder1/subdir/", [("foo/folder1/subdir/earth", false), ("foo/folder1/subdir/rocket", false)]},
            };
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/container");
            TestGetBlobsContainerClient testContainer = new(uri, blobHierarchy);

            List<string> expectedDirectories = new()
            {
                "folder1",
                "otherfolder",
                "folder1/subdir",
            };
            List<string> expectedBlobNames = new()
            {
                "blob",
                "moon",
                "star",
                "sun",
                "otherfolder/hello",
                "folder1/subdir/earth",
                "folder1/subdir/rocket",
            };

            string prefix = "foo";
            StorageResourceContainer container = new BlobStorageResourceContainer(
                testContainer, new() { BlobPrefix = prefix });

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
        public async Task GetStorageResourceReferenceAsync_Default()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobStorageResourceContainer(test.Container, new() { BlobPrefix = prefix });

            StorageResourceItem resource = containerResource.GetStorageResourceReference("bar", default);

            // Assert
            StorageResourceItemProperties properties = await resource.GetPropertiesAsync();
            Assert.IsNotNull(properties);
            Assert.AreEqual(DataMovementBlobConstants.ResourceId.BlockBlob, resource.ResourceId);
        }

        [RecordedTest]
        [TestCase(DataMovementBlobConstants.ResourceId.BlockBlob)]
        [TestCase(DataMovementBlobConstants.ResourceId.PageBlob)]
        [TestCase(DataMovementBlobConstants.ResourceId.AppendBlob)]
        public async Task GetStorageResourceReferenceAsync_BlobType(string blobResourceId)
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobStorageResourceContainer(test.Container, new() { BlobPrefix = prefix });

            StorageResourceItem resource = containerResource.GetStorageResourceReference("bar", blobResourceId);

            // Assert
            StorageResourceItemProperties properties = await resource.GetPropertiesAsync();
            Assert.IsNotNull(properties);
            Assert.AreEqual(blobResourceId, resource.ResourceId);
        }

        [Test]
        public void GetStorageResourceReference_Encoding()
        {
            string[] prefixes = ["prefix", "pre=fix", "prefix with space"];
            string[] tests =
            [
                "path=true@&#%",
                "path%3Dtest%26",
                "with space",
                "sub=dir/path=true@&#%",
                "sub%3Ddir/path=true@&#%",
                "sub dir/path=true@&#%"
            ];

            string containerPath = "https://account.blob.core.windows.net/container";
            BlobContainerClient containerClient = new(new Uri(containerPath));

            foreach (string prefix in prefixes)
            {
                BlobStorageResourceContainer containerResource = new(containerClient, new()
                {
                    BlobPrefix = prefix,
                });
                foreach (string test in tests)
                {
                    StorageResourceItem resource = containerResource.GetStorageResourceReference(test, default);

                    string combined = string.Join("/", containerPath, Uri.EscapeDataString(prefix), Uri.EscapeDataString(test).Replace("%2F", "/"));
                    Assert.That(resource.Uri.AbsoluteUri, Is.EqualTo(combined));
                }
            }
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
                new BlobStorageResourceContainer(mock.Object, new() { BlobPrefix = prefix });

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
