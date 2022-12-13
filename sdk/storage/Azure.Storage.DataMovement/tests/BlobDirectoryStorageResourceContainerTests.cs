// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Tests;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobDirectoryStorageResourceContainerTests : DataMovementBlobTestBase
    {
        public BlobDirectoryStorageResourceContainerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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
            BlobDirectoryStorageResourceContainer storageResource =
                new BlobDirectoryStorageResourceContainer(blobContainerClient, "directoryName");

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
            Assert.AreEqual(directoryName, storageResource.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, storageResource.CanProduceUri);
        }

        [RecordedTest]
        public async Task GetStorageResourcesAsync()
        {
            // Arrange
            DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string folderName = "foo";
            BlobDirectoryStorageResourceContainer storageResourceContainer =
                new BlobDirectoryStorageResourceContainer(test.Container, folderName);

            var resources = new List<StorageResourceBase>();

            await foreach (StorageResourceBase resource in storageResourceContainer.GetStorageResourcesAsync())
            {
                resources.Add(resource);
            }

            // Assert
            Assert.IsNotEmpty(resources);
            Assert.AreEqual(3, resources.Count);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32952")]
        public async Task GetChildStorageResourceAsync()
        {
            DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobDirectoryStorageResourceContainer(test.Container, prefix);

            StorageResource resource = containerResource.GetChildStorageResource("bar");

            // Assert
            StorageResourceProperties properties = await resource.GetPropertiesAsync();
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.ETag);
        }

        [RecordedTest]
        public async Task GetParentStorageResourceAsync()
        {
            DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "baz/bar";
            StorageResourceContainer containerResource =
                new BlobDirectoryStorageResourceContainer(test.Container, prefix);

            StorageResourceContainer resource = containerResource.GetParentStorageResourceContainer();

            Assert.AreEqual("baz", resource.Path);
        }

        [RecordedTest]
        public async Task GetParentStorageResourceAsync_Root()
        {
            DisposingBlobContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            string prefix = "foo";
            StorageResourceContainer containerResource =
                new BlobDirectoryStorageResourceContainer(test.Container, prefix);

            StorageResourceContainer resource = containerResource.GetParentStorageResourceContainer();

            Assert.AreEqual(resource.Uri, test.Container.Uri);
        }
    }
}
