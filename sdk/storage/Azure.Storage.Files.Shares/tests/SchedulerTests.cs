// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class SchedulerTests : FileTestBase
    {
        public SchedulerTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteUnspecifiedNoSubfolder()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            string dirName = GetNewFileName();
            ShareDirectoryClient client = test.Share.GetDirectoryClient(dirName);
            await client.CreateIfNotExistsAsync();

            string folder = CreateRandomDirectory(Path.GetTempPath());
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

            ShareDirectoryUploadOptions options = new ShareDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, default, options);

            List<string> paths = new();

            await RecurseShareDirectory(paths, client, "");

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(paths, openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteGivenNoSubfolder()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            string dirName = GetNewFileName();
            string remoteTargetDir = GetNewFileName();
            ShareDirectoryClient client = test.Share.GetDirectoryClient(dirName);
            await client.CreateIfNotExistsAsync();

            string folder = CreateRandomDirectory(Path.GetTempPath());
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

            ShareDirectoryUploadOptions options = new ShareDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, remoteTargetDir, default, options);

            List<string> paths = new();

            await RecurseShareDirectory(paths, client, "");

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(paths, remoteTargetDir + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, remoteTargetDir + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, remoteTargetDir + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(paths, remoteTargetDir + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            string dirName = GetNewFileName();
            ShareDirectoryClient client = test.Share.GetDirectoryClient(dirName);
            await client.CreateIfNotExistsAsync();

            string folder = CreateRandomDirectory(Path.GetTempPath());
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

            ShareDirectoryUploadOptions options = new ShareDirectoryUploadOptions();

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

        // This method is present here in the tests and as a helper within the
        // directory DownloadInternal function, might be worth refactoring this to some other location
        // (an internal method in the directory client could be ok)
        private static async Task RecurseShareDirectory(List<string> output, ShareDirectoryClient parent, string currentTree)
        {
            await foreach (ShareFileItem shareItem in parent.GetFilesAndDirectoriesAsync())
            {
                if (shareItem.IsDirectory)
                    await RecurseShareDirectory(output, parent.GetSubdirectoryClient(shareItem.Name), currentTree + shareItem.Name + "/");
                else
                    output.Add(currentTree + shareItem.Name);
            }
        }
    }
}
