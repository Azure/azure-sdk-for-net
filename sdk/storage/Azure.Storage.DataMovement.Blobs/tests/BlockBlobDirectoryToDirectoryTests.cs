// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobDirectoryToDirectoryTests :
        StartTransferBlobDirectoryCopyTestBase<BlockBlobClient, BlockBlobClient>
    {
        public BlockBlobDirectoryToDirectoryTests(
            bool async,
            object serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override Task CreateObjectInDestinationAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => CreateBlockBlobAsync(container, objectLength, objectName, contents, cancellationToken);

        protected override Task CreateObjectInSourceAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
            => CreateBlockBlobAsync(container, objectLength, objectName, contents, cancellationToken);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            BlobContainerClient containerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default)
        {
            BlockBlobStorageResourceOptions options = default;
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new BlockBlobStorageResourceOptions(GetSetValuesResourceOptions());
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    Metadata = default
                };
            }
            return new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() {
                BlobPrefix = directoryPath,
                BlobType = BlobType.Block,
                BlobOptions = options
            });
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(BlobContainerClient containerClient, string directoryPath)
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobPrefix = directoryPath, BlobType = BlobType.Block });

        protected internal override BlockBlobClient GetDestinationBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetBlockBlobClient(blobName);

        protected internal override BlockBlobClient GetSourceBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetBlockBlobClient(blobName);

        private async Task PopulateVirtualDirectoryContainer(
            BlobContainerClient containerClient,
            long objectLength)
        {
            byte[] data = GetRandomBuffer(objectLength);
            Metadata folderMetadata = new Dictionary<string, string>()
            {
                { "hdi_isfolder", "true" }
            };

            // List of files to create, directories will be created automatically
            string[] files = [
                "rootFile0",
                "rootFile1",
                "rootFile2",
                "nonEmptyDir/file0",
                "nonEmptyDir/file1",
                "nonEmptyDir/file2",
                "recursiveDir/file0",
                "recursiveDir/file1",
                "recursiveDir/nonEmptySubDir/file0",
                "recursiveDir/nonEmptySubDir/file1"
            ];
            foreach (string file in files)
            {
                using MemoryStream stream = new(data);
                BlobClient blobClient = containerClient.GetBlobClient(file);
                await blobClient.UploadAsync(stream);
            }

            // List of empty directories to be created
            string[] emptyDirs = ["emptyDir", "recursiveDir/emptySubDir"];
            foreach (string dir in emptyDirs)
            {
                BlobClient blobClient = containerClient.GetBlobClient(dir);
                await blobClient.UploadAsync(Stream.Null, new BlobUploadOptions()
                {
                    Metadata = folderMetadata
                });
            }
        }

        [RecordedTest]
        public async Task DirectoryCopyWithVirtualDirectories([Values(true, false)] bool hns)
        {
            BlobServiceClient serviceClient = SourceClientBuilder.GetServiceClientFromOauthConfig(
                hns ? Tenants.TestConfigHierarchicalNamespace : Tenants.TestConfigDefault,
                TestEnvironment.Credential);

            await using DisposingBlobContainer sourceContainer = await SourceClientBuilder.GetTestContainerAsync(serviceClient);
            await using DisposingBlobContainer destinationContainer = await DestinationClientBuilder.GetTestContainerAsync(serviceClient);

            await PopulateVirtualDirectoryContainer(sourceContainer.Container, 1024);

            TransferManager transferManager = new();
            BlobsStorageResourceProvider blobProvider = new(TestEnvironment.Credential);

            TransferOptions transferOptions = new();
            TestEventsRaised testEventsRaised = new(transferOptions);

            TransferOperation transfer = await transferManager.StartTransferAsync(
                GetSourceStorageResourceContainer(sourceContainer.Container, default),
                GetSourceStorageResourceContainer(destinationContainer.Container, default),
                transferOptions);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);

            testEventsRaised.AssertUnexpectedFailureCheck();
            await VerifyResultsAsync(
                sourceContainer.Container, string.Empty,
                destinationContainer.Container, string.Empty);
        }
    }
}
