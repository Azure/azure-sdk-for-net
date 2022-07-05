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
using Azure.Storage.Blobs.Experimental.Models;
using Azure.Storage.Blobs.Experimental.Tests.Shared;
using NUnit.Framework;
using Azure.Storage.Experimental;
using System.Net;
using Azure.Core;
using System.Threading;

namespace Azure.Storage.Blobs.Experimental.Tests
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

        private async Task SetUpDirectoryForListing(BlobContainerClient container)
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
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };

            BlobTransferManager blobTransferManager1 = new BlobTransferManager(managerOptions);
        }

        #region SingleUpload
        [RecordedTest]
        public async Task ScheduleUpload_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            string tempfolder = Path.GetTempPath();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempfolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(directory).ConfigureAwait(false);

                // Set up destination client
                BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = 1,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                BlobSingleUploadOptions options = new BlobSingleUploadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        bool exists = await destClient.ExistsAsync();
                        Assert.IsTrue(exists);
                        CompletedWait.Set();
                    }
                };
                // Act
                await blobTransferManager.ScheduleUploadAsync(localSourceFile, destClient, options).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(400)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }

        [RecordedTest]
        [TestCase(0, 30)]
        [TestCase(4 * Constants.MB, 300)]
        [TestCase(257 * Constants.MB, 300)]
        [TestCase(Constants.GB, 500)]
        public async Task ScheduleUpload_BlobSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            //await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlobContainerClient containerClient = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=amandadev3;AccountKey=w1FcAGMn3nvAZ+p+X7MLJZBmeBGsUoj46DooFI165FrireIfvZddHYmE0/N8CU9zwWdSY3oLceIUcigLUZizyQ==;EndpointSuffix=core.windows.net", "sample15container");

            // Set up blob to upload
            var blobName = GetNewBlobName();
            string tempfolder = Path.GetTempPath();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempfolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(parentPath: directory, size: fileSize).ConfigureAwait(false);

                // Set up destination client
                BlockBlobClient destClient = containerClient.GetBlockBlobClient(blobName);

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = 1,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                BlobSingleUploadOptions options = new BlobSingleUploadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        bool exists = await destClient.ExistsAsync();
                        Assert.IsTrue(exists);
                        CompletedWait.Set();
                    }
                };
                // Act
                await blobTransferManager.ScheduleUploadAsync(localSourceFile, destClient, options).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }

        [RecordedTest]
        [TestCase(1, 20)]
        [TestCase(4, 20)]
        [TestCase(16, 20)]
        public async Task ScheduleUpload_Concurrency(int concurrency, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            string tempfolder = Path.GetTempPath();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempfolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(parentPath: directory, size: 4 * Constants.MB).ConfigureAwait(false);

                // Set up destination client
                BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = concurrency,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                BlobSingleUploadOptions options = new BlobSingleUploadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        CompletedWait.Set();
                        bool exists = await destClient.ExistsAsync();
                        Assert.IsTrue(exists);
                    }
                };
                // Act
                await blobTransferManager.ScheduleUploadAsync(localSourceFile, destClient, options).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }

        [RecordedTest]
        [TestCase(0, 30)]
        [TestCase(4 * Constants.MB, 300)]
        [TestCase(257 * Constants.MB, 300)]
        [TestCase(Constants.GB, 500)]
        public async Task ScheduleUpload_Two(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            var blobName2 = GetNewBlobName();
            string tempfolder = Path.GetTempPath();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempfolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(parentPath: directory, size: fileSize).ConfigureAwait(false);
                string localSourceFile2 = await CreateRandomFileAsync(parentPath: directory, size: fileSize).ConfigureAwait(false);

                // Set up destination client
                BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);
                BlockBlobClient destClient2 = testContainer.Container.GetBlockBlobClient(blobName2);

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = 1,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                AutoResetEvent InProgressWait2 = new AutoResetEvent(false);
                AutoResetEvent CompletedWait2 = new AutoResetEvent(false);
                BlobSingleUploadOptions options = new BlobSingleUploadOptions();
                BlobSingleUploadOptions options2 = new BlobSingleUploadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        bool exists = await destClient.ExistsAsync();
                        Assert.IsTrue(exists);
                        CompletedWait.Set();
                    }
                };
                options2.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait2.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        bool exists = await destClient2.ExistsAsync();
                        Assert.IsTrue(exists);
                        CompletedWait2.Set();
                    }
                };
                // Act
                await blobTransferManager.ScheduleUploadAsync(localSourceFile, destClient, options).ConfigureAwait(false);
                await blobTransferManager.ScheduleUploadAsync(localSourceFile2, destClient2, options2).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
                Assert.IsTrue(InProgressWait2.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
                Assert.IsTrue(CompletedWait2.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }
        #endregion SingleUpload

        #region SingleDownload
        [RecordedTest]
        public async Task ScheduleDownload_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            string tempFolder = Path.GetTempPath();
            string tempFile = tempFolder + Recording.Random.NewGuid().ToString();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempFolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(directory).ConfigureAwait(false);

                // Set up source client
                BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(blobName);
                var data = GetRandomBuffer(4 * Constants.KB);
                Response<BlobContentInfo> response;
                using (var stream = new MemoryStream(data))
                {
                    response = await sourceClient.UploadAsync(
                        content: stream);
                };

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = 1,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                BlobSingleDownloadOptions options = new BlobSingleDownloadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        CompletedWait.Set();
                        bool exists = File.Exists(tempFile);
                        Assert.IsTrue(exists);

                        // Clean up
                        await sourceClient.DeleteAsync();
                    }
                };
                // Act
                await blobTransferManager.ScheduleDownloadAsync(sourceClient, tempFile, options).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(10)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(10)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }

        [RecordedTest]
        [TestCase(0)]
        [TestCase(4 * Constants.MB)]
        [TestCase(Constants.GB)]
        public async Task ScheduleDownload_BlobSize(long size)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up blob to upload
            var blobName = GetNewBlobName();
            string tempFolder = Path.GetTempPath();
            string tempFile = tempFolder + Recording.Random.NewGuid().ToString();
            string directoryName = GetNewBlobDirectoryName();
            try
            {
                string directory = CreateRandomDirectory(tempFolder, directoryName);
                string localSourceFile = await CreateRandomFileAsync(directory).ConfigureAwait(false);

                // Set up source client
                BlockBlobClient sourceClient = testContainer.Container.GetBlockBlobClient(blobName);
                var data = GetRandomBuffer(size);
                Response<BlobContentInfo> response;
                using (var stream = new MemoryStream(data))
                {
                    response = await sourceClient.UploadAsync(
                        content: stream);
                };

                StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                    MaximumConcurrency = 1,
                };
                BlobTransferManager blobTransferManager = new BlobTransferManager(managerOptions);

                AutoResetEvent InProgressWait = new AutoResetEvent(false);
                AutoResetEvent CompletedWait = new AutoResetEvent(false);
                BlobSingleDownloadOptions options = new BlobSingleDownloadOptions();
                options.TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                {
                    // Assert
                    if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                    {
                        InProgressWait.Set();
                    }
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        CompletedWait.Set();
                        bool exists = File.Exists(tempFile);
                        Assert.IsTrue(exists);

                        // Clean up
                        await sourceClient.DeleteAsync();
                    }
                };
                // Act
                await blobTransferManager.ScheduleDownloadAsync(sourceClient, tempFile, options).ConfigureAwait(false);

                // Assert
                Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(10)));
                Assert.IsTrue(CompletedWait.WaitOne(TimeSpan.FromSeconds(10)));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }
            }
        }
        #endregion SingleDownload

        #region DirectoryUploadTests
        [RecordedTest]
        public async Task ScheduleFolderUploadAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            await blobTransferManager.ScheduleFolderUploadAsync(folder, client).ConfigureAwait(false);

            // Assert - Check List Call
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());
            // Assert - Check destination blobs
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
        public async Task ScheduleFolderUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            BlobFolderClient destClient = testContainer.Container.GetBlobFolderClient(dirName);

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, destClient).ConfigureAwait(false);

            // Assert
            List<string> blobs = ((List<BlobItem>)await testContainer.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(1, blobs.Count());
            Assert.AreEqual(blobs.First(), dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_SingleSubdirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(3, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string openSubfolder2 = CreateRandomDirectory(folder);
            string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            string openSubfolder3 = CreateRandomDirectory(folder);
            string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            string openSubfolder4 = CreateRandomDirectory(folder);
            string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(10, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task ScheduleDirectoryUploadAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(level, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild4 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild5 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild6 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string openSubfolder2 = CreateRandomDirectory(folder);

            string openSubfolder3 = CreateRandomDirectory(folder);

            string openSubfolder4 = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(6, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild4.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild5.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild6.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ScheduleDirectoryUpload_ImmutableStorageWithVersioning()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions()
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true,
            };

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            Assert.AreEqual(4, blobs.Count());
            foreach (BlobItem blob in blobs)
            {
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.ExpiresOn, expectedImmutabilityPolicyExpiry);
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.PolicyMode, immutabilityPolicy.PolicyMode);
                Assert.IsTrue(blob.Properties.HasLegalHold);
            }

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryUploadTests

        #region DirectoryDownloadTests
        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            options.ProgressHandler = new Progress<BlobFolderUploadProgress>();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);
            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(sourceFolder).ConfigureAwait(false);
            string localDirName = sourceFolder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            AssertContentFile(openSubchild, destinationFolder + "/" + localItemsAfterDownload.First());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleSubDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainSubFolder = CreateRandomDirectory(folder);
            string sourceSubFolder = CreateRandomDirectory(mainSubFolder);
            string sourceSubChild = await CreateRandomFileAsync(sourceSubFolder).ConfigureAwait(false);

            string destinationSubfolder = CreateRandomDirectory(mainSubFolder);
            string destinationSubchild = await CreateRandomFileAsync(destinationSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            Assert.Equals(localItemsAfterDownload.First(), destinationSubchild);
            AssertContentFile(sourceSubChild, destinationSubchild);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainFolder = CreateRandomDirectory(folder);
            string souceSubFolder = CreateRandomDirectory(mainFolder);
            string openSubchild = await CreateRandomFileAsync(souceSubFolder).ConfigureAwait(false);
            string souceSubFolder2 = CreateRandomDirectory(mainFolder);
            string openSubchild2 = await CreateRandomFileAsync(souceSubFolder2).ConfigureAwait(false);
            string souceSubFolder3 = CreateRandomDirectory(mainFolder);
            string openSubchild3 = await CreateRandomFileAsync(souceSubFolder3).ConfigureAwait(false);

            string destinationFolder = CreateRandomDirectory(souceSubFolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild2);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild3);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = sourceFolder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(sourceFolder, client, false, options).ConfigureAwait(false);

            Directory.Delete(sourceFolder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            Assert.Equals(level, localItemsAfterDownload);

            // Cleanup
            Directory.Delete(sourceFolder, true);
            Directory.Delete(destinationFolder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingBlobContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);
            string dirTwoName = GetNewBlobName();
            BlobFolderClient clientTwo = test.Container.GetBlobFolderClient(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);
            // Act
            BlobTransferManager manager = new BlobTransferManager();
            await manager.ScheduleFolderUploadAsync(folder, client).ConfigureAwait(false);
            await manager.ScheduleFolderUploadAsync(folder, clientTwo).ConfigureAwait(false);
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
        #endregion DirectoryDownloadTests
    }
}
