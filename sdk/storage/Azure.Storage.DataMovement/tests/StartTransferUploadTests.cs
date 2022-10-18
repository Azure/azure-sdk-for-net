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
using Azure.Storage.Blobs.DataMovement;
using NUnit.Framework;
using Azure.Storage.DataMovement;
using System.Net;
using Azure.Core;
using System.Threading;
using Azure.Storage.Test;
using System.Drawing;
using Castle.Core.Internal;
using Microsoft.CodeAnalysis;
using NUnit.Framework.Internal;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadTests : DataMovementBlobTestBase
    {
        public StartTransferUploadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        #region SingleUpload

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
        private async Task UploadBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            DataControllerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (blobNames.IsNullOrEmpty())
            {
                blobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    blobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, blobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options.IsNullOrEmpty())
            {
                options ??= new List<SingleTransferOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new SingleTransferOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                BlobDataController BlobDataController = new BlobDataController(transferManagerOptions);

                // Set up blob to upload
                for (int i = 0; i < blobCount; i++)
                {
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                    using (FileStream fileStream = File.Create(localSourceFile))
                    {
                        await originalStream.CopyToAsync(fileStream);
                    }

                    // Set up destination client
                    BlockBlobClient destClient = container.GetBlockBlobClient(blobNames[i]);
                    StorageResource destinationResource = new BlockBlobStorageResource(destClient);

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatusEventHandler += async (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            bool exists = await destClient.ExistsAsync();
                            Assert.IsTrue(exists);
                            completedStatusWait.Set();
                        }
                    };
                    options[i].TransferFailedEventHandler += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        completedStatusWait));

                    // Act
                    StorageResource sourceResource = LocalStorageResourceFactory.GetFile(localSourceFile);
                    await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]).ConfigureAwait(false);
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

                    // Verify Upload
                    using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < blobCount; i++)
                {
                    if (File.Exists(uploadedBlobInfo[i].LocalPath))
                    {
                        File.Delete(uploadedBlobInfo[i].LocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task ScheduleUpload_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            ;

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadBlobsAndVerify(
                testContainer.Container,
                size,
                waitTimeInSec,
                blobCount: optionsList.Count,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task ScheduleUpload_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatusEventHandler += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailedEventHandler += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task ScheduleUpload_BlobSize(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            options.TransferStatusEventHandler += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailedEventHandler += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await UploadBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        public async Task ScheduleUpload_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            List<string> blobNames = new List<string>() { blobName };

            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task ScheduleUpload_Multiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount).ConfigureAwait(false);
        }
        #endregion SingleUpload

        #region DirectoryUploadTests
        [RecordedTest]
        public async Task StartTransferAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            await BlobDataController.StartTransferAsync(sourceResource, destinationResource).ConfigureAwait(false);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource).ConfigureAwait(false);

            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            ContainerTransferOptions options = new ContainerTransferOptions();

            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            ContainerTransferOptions options = new ContainerTransferOptions();
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

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

            ContainerTransferOptions options = new ContainerTransferOptions();
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            ContainerTransferOptions options = new ContainerTransferOptions();
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

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

            ContainerTransferOptions options = new ContainerTransferOptions();
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

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

            ContainerTransferOptions options = new ContainerTransferOptions()
            {
            };

            // Act
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            ContainerTransferOptions options = new ContainerTransferOptions();
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            DataControllerOptions managerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            DataControllerOptions controllerOptions = new DataControllerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(controllerOptions));
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options).ConfigureAwait(false);

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
