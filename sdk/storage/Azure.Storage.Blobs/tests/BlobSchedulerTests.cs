// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobSchedulerTests : BlobTestBase
    {
        public BlobSchedulerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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
            BlobDirectoryClient client = test.Container.GetBlobDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, default, options);

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
            string remoteTargetDir = GetNewBlobName();
            BlobDirectoryClient client = test.Container.GetBlobDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, remoteTargetDir, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobDirectoryClient client = test.Container.GetBlobDirectoryClient(dirName);

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
            await client.UploadAsync(folder, default, options);

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
        public async Task CopyDirectoryAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string destName = GetNewBlobName();
            BlobDirectoryClient source = test.Container.GetBlobDirectoryClient(GetNewBlobName());
            BlobDirectoryClient dest = test.Container.GetBlobDirectoryClient(destName);

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
            await source.UploadAsync(folder, default, options);

            await dest.SyncCopyFromUriAsync(source.Uri, new BlobDirectoryCopyFromUriOptions()
            {
                SourceConditions = new BlobDirectoryRequestConditions(),
                DestinationConditions = new BlobDirectoryRequestConditions()
            }, default);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync(prefix: destName).ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, destName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, destName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, destName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, destName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobDirectoryClient client = test.Container.GetBlobDirectoryClient(dirName);

            string dirTwoName = GetNewBlobName();
            BlobDirectoryClient clientTwo = test.Container.GetBlobDirectoryClient(dirTwoName);

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
    }
}
