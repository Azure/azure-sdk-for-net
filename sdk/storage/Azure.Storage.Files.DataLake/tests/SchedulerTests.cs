// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class SchedulerTests : PathTestBase
    {
        public SchedulerTests
            (bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteUnspecifiedNoSubfolder()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            string dirName = GetNewFileName();
            DataLakeDirectoryClient client = test.FileSystem.GetDirectoryClient(dirName);

            string folder = CreateRandomDirectory(System.IO.Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            Func<byte[]> data = () => GetRandomBuffer(Constants.KB);

            File.WriteAllBytes(openChild, data());
            File.WriteAllBytes(lockedChild, data());

            File.WriteAllBytes(openSubchild, data());
            File.WriteAllBytes(lockedSubchild, data());

            DataLakeDirectoryUploadOptions options = new DataLakeDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, default, options);

            List<string> paths = ((List<PathItem>)await test.FileSystem.GetPathsAsync(recursive: true).ToListAsync())
                .Select((PathItem path) => path.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(paths, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteGivenNoSubfolder()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            string dirName = GetNewFileName();
            string remoteTargetDir = GetNewFileName();
            DataLakeDirectoryClient client = test.FileSystem.GetDirectoryClient(dirName);

            string folder = CreateRandomDirectory(System.IO.Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            Func<byte[]> data = () => GetRandomBuffer(Constants.KB);

            File.WriteAllBytes(openChild, data());
            File.WriteAllBytes(lockedChild, data());

            File.WriteAllBytes(openSubchild, data());
            File.WriteAllBytes(lockedSubchild, data());

            DataLakeDirectoryUploadOptions options = new DataLakeDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, remoteTargetDir, default, options);

            List<string> paths = ((List<PathItem>)await test.FileSystem.GetPathsAsync(recursive: true).ToListAsync())
                .Select((PathItem path) => path.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(paths, dirName + "/" + remoteTargetDir + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + remoteTargetDir + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + remoteTargetDir + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, dirName + "/" + remoteTargetDir + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            string dirName = GetNewFileName();
            DataLakeDirectoryClient client = test.FileSystem.GetDirectoryClient(dirName);

            string folder = CreateRandomDirectory(System.IO.Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            Func<byte[]> data = () => GetRandomBuffer(Constants.KB);

            File.WriteAllBytes(openChild, data());
            File.WriteAllBytes(lockedChild, data());

            File.WriteAllBytes(openSubchild, data());
            File.WriteAllBytes(lockedSubchild, data());

            DataLakeDirectoryUploadOptions options = new DataLakeDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, default, options);

            Directory.Delete(folder, true);

            await client.DownloadAsync(folder);

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
    }
}
