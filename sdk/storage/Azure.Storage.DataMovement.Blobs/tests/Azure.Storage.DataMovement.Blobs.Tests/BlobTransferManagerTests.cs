// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.DataMovement.Blobs.Tests.Shared;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobTransferManagerTests : DataMovementBlobTestBase
    {
        public BlobTransferManagerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        private async Task SetUpDirectoryForListing(BlobVirtualDirectoryClient directory)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(directory.GetBlockBlobClient(blobNames[i]));
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
        public void Ctor_Defaults()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = GetNewContainerName();
            var directoryName = GetNewBlobDirectoryName();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ContinueOnLocalFilesystemFailure = false,
                ContinueOnStorageFailure = false,
                ConcurrencyForLocalFilesystemListing = 1
            };

            BlobTransferManager blobtransferManager0 = InstrumentClient(new BlobTransferManager());
            BlobTransferManager blobTransferManager1 = InstrumentClient(new BlobTransferManager(managerOptions));
        }
        [RecordedTest]
        public async Task ScheduleUpload_SingleBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            BlobClient blob = InstrumentClient(testContainer.Container.GetBlobClient(blobName));
            string localSourceFile = CreateRandomFile(Path.GetTempFileName());

            // Set up destination client
            BlobVirtualDirectoryClient destClient = testContainer.Container.GetBlobVirtualDirectoryClient(blobName);
            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ContinueOnLocalFilesystemFailure = false,
                ContinueOnStorageFailure = false,
                ConcurrencyForLocalFilesystemListing = 1
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            blobTransferManager.ScheduleUploadDirectory(localSourceFile, destClient);

            // Assert
            List<string> blobs = ((List<BlobItem>)await testContainer.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(localSourceFile, true);
        }

        [RecordedTest]
        public async Task ScheduleUploadDirectory_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            BlobVirtualDirectoryClient destClient = testContainer.Container.GetBlobVirtualDirectoryClient(dirName);
            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ContinueOnLocalFilesystemFailure = false,
                ContinueOnStorageFailure = false,
                ConcurrencyForLocalFilesystemListing = 1
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            blobTransferManager.ScheduleUploadDirectory(folder, destClient);

            // Assert
            List<string> blobs = ((List<BlobItem>)await testContainer.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }
    }
}
