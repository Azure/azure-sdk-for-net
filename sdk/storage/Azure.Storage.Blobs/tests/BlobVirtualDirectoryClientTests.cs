// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobVirtualDirectoryClientTests : BlobTestBase
    {
        public BlobVirtualDirectoryClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
                : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        // TODO: Resolve issues with threading causing failures in test playback
        //      (maybe should be resolved in base TransferSchduler, with tests for
        //      threading behavior in its own tests)

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteUnspecified()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteGiven()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            string localDirName = folder.Split('\\').Last();

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, options);

            Directory.Delete(folder, true);

            await client.DownloadAsync(folder, options: new BlobDirectoryDownloadOptions()
            {
                DirectoryRequestConditions = new BlobDirectoryRequestConditions()
            });

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openChild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedChild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedSubchild);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.DownloadAsync(folder, options: new BlobDirectoryDownloadOptions()
            {
                DirectoryRequestConditions = new BlobDirectoryRequestConditions()
            });

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.

        /*
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);
            string dirTwoName = GetNewBlobName();
            BlobVirtualDirectoryClient clientTwo = test.Container.GetBlobVirtualDirectoryClient(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);
            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();
            // Act
            StorageTransferManager manager = new StorageTransferManager();
            await manager.ScheduleUploadDirectoryAsync(folder, client, options);
            await manager.ScheduleUploadDirectoryAsync(folder, clientTwo, options);
            await manager.StartTransfersAsync();
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });
            // Cleanup
            Directory.Delete(folder, true);
        }
        */
    }
}
