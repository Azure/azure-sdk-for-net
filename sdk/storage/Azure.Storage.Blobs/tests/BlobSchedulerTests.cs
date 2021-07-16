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
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobSchedulerTests : BlobTestBase
    {
        public BlobSchedulerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, RecordedTestMode.Record /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteUnspecifiedNoSubfolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobDirectoryClient client = InstrumentClient(test.Container.GetBlobDirectoryClient(dirName));

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            StorageTransferOptions transferOptions = default;
            transferOptions.MaximumConcurrency = 2;

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, transferOptions, options);

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
        public async Task UploadDirectoryAsync_RemoteUnspecifiedWithSubfolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobDirectoryClient client = InstrumentClient(test.Container.GetBlobDirectoryClient(dirName));

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            string localDirName = folder.Split('\\').Last();

            StorageTransferOptions transferOptions = default;
            transferOptions.MaximumConcurrency = 2;

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();
            options.UploadToSubdirectory = true;

            // Act
            await client.UploadAsync(folder, transferOptions, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + localDirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + localDirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + localDirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + localDirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteGivenNoSubfolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string remoteTargetDir = GetNewBlobName();
            BlobDirectoryClient client = InstrumentClient(test.Container.GetBlobDirectoryClient(dirName));

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            StorageTransferOptions transferOptions = default;
            transferOptions.MaximumConcurrency = 2;

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, remoteTargetDir, transferOptions, options);

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
        public async Task UploadDirectoryAsync_RemoteGivenWithSubfolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string remoteTargetDir = GetNewBlobName();
            BlobDirectoryClient client = InstrumentClient(test.Container.GetBlobDirectoryClient(dirName));

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            string localDirName = folder.Split('\\').Last();

            StorageTransferOptions transferOptions = default;
            transferOptions.MaximumConcurrency = 2;

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();
            options.UploadToSubdirectory = true;

            // Act
            await client.UploadAsync(folder, remoteTargetDir, transferOptions, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + localDirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + localDirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + localDirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + remoteTargetDir + "/" + localDirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        private static string CreateRandomDirectory(string parentPath)
        {
            return Directory.CreateDirectory(Path.Combine(parentPath, Path.GetRandomFileName())).FullName;
        }

        private static string CreateRandomFile(string parentPath)
        {
            using (FileStream fs = File.Create(Path.Combine(parentPath, Path.GetRandomFileName())))
            {
                return fs.Name;
            }
        }
    }
}
