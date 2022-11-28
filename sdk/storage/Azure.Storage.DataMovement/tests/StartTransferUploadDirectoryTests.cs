// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferUploadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        internal class VerifyUploadBlobContentInfo
        {
            public readonly string LocalPath;
            public BlobBaseClient DestinationClient;
            public SingleTransferOptions UploadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient destinationClient,
                SingleTransferOptions uploadOptions,
                AutoResetEvent completedStatusWait)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                UploadOptions = uploadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        internal class VerifyDownloadBlobContentInfo
        {
            public readonly string SourceLocalPath;
            public readonly string DestinationLocalPath;
            public SingleTransferOptions DownloadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                SingleTransferOptions downloadOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                DownloadOptions = downloadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        internal SingleTransferOptions CopySingleUploadOptions(SingleTransferOptions options)
        {
            SingleTransferOptions newOptions = new SingleTransferOptions()
            {
                MaximumTransferChunkSize = options.MaximumTransferChunkSize,
                InitialTransferSize = options.InitialTransferSize,
            };
            return newOptions;
        }

        #region Directory Block Blob
        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task UploadBlobDirectoryAndVerify(
            BlobContainerClient destinationContainer,
            string localDirectoryPath,
            List<string> files,
            string destinationPrefix = default,
            int waitTimeInSec = 10,
            TransferManagerOptions transferManagerOptions = default,
            ContainerTransferOptions options = default)
        {
            // Set transfer options
            options ??= new ContainerTransferOptions();

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            destinationPrefix ??= GetNewBlobDirectoryName();

            // Initialize BlobDataController
            TransferManager blobDataController = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(localDirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobDirectoryStorageResourceContainer(destinationContainer, destinationPrefix);

            // Set up blob to upload
            bool failure = false;
            string exceptionMessage = default;
            // Set up copy structure to verify later
            AutoResetEvent completedStatusWait = new AutoResetEvent(false);
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                {
                    completedStatusWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    // If we call Assert.Fail here it will throw an exception within the
                    // event handler and take down everything with it.
                    //Assert.Fail(args.Exception.Message);
                    failure = true;
                    exceptionMessage = args.Exception.Message;
                    completedStatusWait.Set();
                }
                return Task.CompletedTask;
            };
            await blobDataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            Assert.IsTrue(completedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
            if (failure)
            {
                Assert.Fail(exceptionMessage);
            }
            for (int i = 0; i < files.Count; i++)
            {
                // Verify Upload
                using (FileStream fileStream = File.OpenRead(files[i]))
                {
                    string blobName = $"{destinationPrefix}/{files[i]}";
                    BlockBlobClient destinationBlob = destinationContainer.GetBlockBlobClient(blobName);
                    await DownloadAndAssertAsync(fileStream, destinationBlob);
                }
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task LocalToBlockBlobDirectory_Size(long blobSize, int waitTimeInSec)
        {
            ContainerTransferOptions options = new ContainerTransferOptions();
            List<string> files = new List<string>();
            string localDirectory = CreateRandomDirectory(Path.GetTempPath());
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            try
            {
                files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
                files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));

                string openSubfolder = CreateRandomDirectory(localDirectory);
                files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
                string lockedSubfolder = CreateRandomDirectory(localDirectory);
                files.Add(await CreateRandomFileAsync(lockedSubfolder, size: blobSize));

                // Arrange
                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    localDirectory,
                    files,
                    waitTimeInSec: waitTimeInSec,
                    options: options);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(localDirectory, true);
                await test.Container.DeleteIfExistsAsync();
            }
        }
        #endregion

        #region DirectoryUploadTests
        [RecordedTest]
        public async Task Async_LocalDirectoryToBlobDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager BlobDataController = InstrumentClient(new TransferManager(managerOptions));

            await BlobDataController.StartTransferAsync(sourceResource, destinationResource);

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
        public async Task DirectoryUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource);

            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);
            string openChild = await CreateRandomFileAsync(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            // Act
            DataTransfer transfer = await dataController.StartTransferAsync(sourceResource, destinationResource, options);
            await transfer.AwaitCompletion(cancellationToken: cancellationTokenSource.Token);

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
        public async Task DirectoryUpload_SingleSubdirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

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
        public async Task DirectoryUpload_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);
            string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2);

            string openSubfolder3 = CreateRandomDirectory(folder);
            string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2);

            string openSubfolder4 = CreateRandomDirectory(folder);
            string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

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
        public async Task DirectoryUpload_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder);
                subfolderName = openSubfolder;
            }

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager BlobDataController = new TransferManager(managerOptions);

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(level, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild4 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild5 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild6 = await CreateRandomFileAsync(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);

            string openSubfolder3 = CreateRandomDirectory(folder);

            string openSubfolder4 = CreateRandomDirectory(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

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

        [RecordedTest]
        public async Task DirectoryUpload_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions controllerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(controllerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryUploadTests
    }
}
