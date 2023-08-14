// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// These tests aim to test the <see cref="TransferManager.GetTransfers(StorageTransferStatus)"/>.
    /// </summary>
    public class GetTransfersTests
    {
        private TransferManagerOptions GetDefaultManagerOptions(string checkpointerPath) =>
            new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerPath)
            };

        private void AssertListTransfersEquals(IList<DataTransfer> expected, IList<DataTransfer> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            // Sort
            IList<DataTransfer> expectedSorted = expected.OrderBy(a => a.Id).ToList();
            IList<DataTransfer> actualSorted = actual.OrderBy(a => a.Id).ToList();

            for (int i = 0; i < expectedSorted.Count; i++)
            {
                DataTransfer expectedValue = expectedSorted.ElementAt(i);
                DataTransfer actualValue = actualSorted.ElementAt(i);
                Assert.AreEqual(expectedValue.Id, actualValue.Id);
                Assert.AreEqual(expectedValue.TransferStatus, actualValue.TransferStatus);
            }
        }

        private DataTransfer GetNewDataTransfer(
            StorageTransferStatus status = StorageTransferStatus.Queued)
        {
            return new DataTransfer(
                id: Guid.NewGuid().ToString(),
                status: status);
        }

        [Test]
        public async Task GetTransfers_Empty()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange
            TransferManager manager = new TransferManager(GetDefaultManagerOptions(testDirectory.DirectoryPath));

            // Act
            IList<DataTransfer> transfers = await manager.GetTransfersAsync().ToListAsync();

            // Assert
            Assert.IsEmpty(transfers);
        }

        [Test]
        public async Task GetTransfers_Populated()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(),
                GetNewDataTransfer(),
                GetNewDataTransfer(),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            IList<DataTransfer> result = await manager.GetTransfersAsync().ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers, result);
        }

        [Test]
        [TestCase(StorageTransferStatus.Queued)]
        [TestCase(StorageTransferStatus.InProgress)]
        [TestCase(StorageTransferStatus.Paused)]
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public async Task GetTransfers_Filtered(StorageTransferStatus status)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.Completed),
                GetNewDataTransfer(StorageTransferStatus.Completed),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            StorageTransferStatus[] statuses = new StorageTransferStatus[] { status };
            IList<DataTransfer> result = await manager.GetTransfersAsync(statuses).ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers.Where( d => d.TransferStatus == status).ToList(), result);
        }

        [Test]
        public async Task GetTransfers_FilterMultipleStatuses()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.Completed),
                GetNewDataTransfer(StorageTransferStatus.Completed),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithSkippedTransfers)
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            StorageTransferStatus[] statuses = new StorageTransferStatus[] {
                StorageTransferStatus.Completed,
                StorageTransferStatus.CompletedWithFailedTransfers,
                StorageTransferStatus.CompletedWithSkippedTransfers };
            IList<DataTransfer> result = await manager.GetTransfersAsync(statuses).ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers.Where(d => statuses.Contains(d.TransferStatus)).ToList(), result);
        }

        [Test]
        public async Task GetTransfers_Filtered_Empty()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.Queued),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.InProgress),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.Paused),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                GetNewDataTransfer(StorageTransferStatus.Completed),
                GetNewDataTransfer(StorageTransferStatus.Completed),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act - With a transfer status not in the above stored transfers
            StorageTransferStatus[] statuses = new StorageTransferStatus[] { StorageTransferStatus.CancellationInProgress };
            IList<DataTransfer> result = await manager.GetTransfersAsync(statuses).ToListAsync();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetTransfers_LocalCheckpointer()
        {
            // Arrange
            // Build Local Checkpointer with already existing transfers that are stored
            // Arrange - populate checkpointer directory with existing jobs
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            int transferCount = 5;
            LocalTransferCheckpointerFactory factory = new LocalTransferCheckpointerFactory(test.DirectoryPath);
            LocalTransferCheckpointer checkpointer = factory.BuildCheckpointer(transferCount);
            List<string> checkpointerTransfers = await checkpointer.GetStoredTransfersAsync();

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(test.DirectoryPath)
            };
            TransferManager manager = new TransferManager(options);

            // Act
            IList<DataTransfer> result = await manager.GetTransfersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(checkpointerTransfers, result.Select(d => d.Id).ToList());
        }

        [Test]
        public async Task GetResumableTransfers_LocalCheckpointer()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string parentRemotePath = "https://account.blob.core.windows.net/resume-test/";
            string parentLocalPath1 = "/resume-test/";
            string parentLocalPath2 = @"C:\Windows\Path\";

            LocalTransferCheckpointerFactory factory = new LocalTransferCheckpointerFactory(test.DirectoryPath);

            // Build expected results first to use to populate checkpointer
            DataTransferProperties[] expectedResults = new DataTransferProperties[]
            {
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceScheme = "LocalFile", SourcePath = parentLocalPath1 + "file1", DestinationScheme = "BlockBlob", DestinationPath = parentRemotePath + "file1", IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceScheme = "BlockBlob", SourcePath = parentRemotePath + "file2/", DestinationScheme = "LocalFile", DestinationPath = parentLocalPath1 + "file2/", IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceScheme = "BlockBlob", SourcePath = parentRemotePath + "file3", DestinationScheme = "BlockBlob", DestinationPath = parentRemotePath + "file3", IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceScheme = "BlockBlob", SourcePath = parentRemotePath, DestinationScheme = "LocalFile", DestinationPath = parentLocalPath1, IsContainer = true },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceScheme = "LocalFile", SourcePath = parentLocalPath2, DestinationScheme = "AppendBlob", DestinationPath = parentRemotePath, IsContainer = true },
            };

            // Add a transfer for each expected result
            foreach (DataTransferProperties props in expectedResults)
            {
                AddTransferFromDataTransferProperties(factory, test.DirectoryPath, props);
            }

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(test.DirectoryPath)
            };
            TransferManager manager = new TransferManager(options);

            // Act
            IList<DataTransferProperties> result = await manager.GetResumableTransfersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(5, result.Count);
            foreach (DataTransferProperties props in result)
            {
                DataTransferProperties expected = expectedResults.Where(p => p.TransferId == props.TransferId).First();
                AssertTransferProperties(expected, props);
            }
        }

        [Test]
        public async Task GetResumableTransfers_IgnoresCompleted()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            LocalTransferCheckpointerFactory factory = new LocalTransferCheckpointerFactory(test.DirectoryPath);

            string transferId1 = Guid.NewGuid().ToString();
            factory.CreateStubJobPartPlanFilesAsync(
                test.DirectoryPath,
                transferId1,
                3 /* jobPartCount */,
                StorageTransferStatus.Completed);

            string transferId2 = Guid.NewGuid().ToString();
            factory.CreateStubJobPartPlanFilesAsync(
                test.DirectoryPath,
                transferId2,
                3 /* jobPartCount */,
                StorageTransferStatus.Queued);

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(test.DirectoryPath)
            };
            TransferManager manager = new TransferManager(options);

            // Act
            IList<DataTransferProperties> result = await manager.GetResumableTransfersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(transferId2, result.First().TransferId);
        }

        private void AddTransferFromDataTransferProperties(
            LocalTransferCheckpointerFactory factory,
            string checkpointerPath,
            DataTransferProperties properties)
        {
            if (properties.IsContainer)
            {
                int numParts = 3;
                List<string> sourcePaths = new List<string>();
                List<string> destinationPaths = new List<string>();
                for (int i = 0; i < numParts; i++)
                {
                    // Put extra slash on end of last part for testing
                    if (i == numParts - 1)
                    {
                        sourcePaths.Add(properties.SourcePath + $"file{i}/");
                        destinationPaths.Add(properties.DestinationPath + $"file{i}/");
                        continue;
                    }

                    sourcePaths.Add(properties.SourcePath + $"file{i}");
                    destinationPaths.Add(properties.DestinationPath + $"file{i}");
                }

                factory.CreateStubJobPartPlanFilesAsync(
                    checkpointerPath,
                    properties.TransferId,
                    numParts, /* jobPartCount */
                    StorageTransferStatus.InProgress,
                    sourcePaths,
                    destinationPaths,
                    sourceResourceId: properties.SourceScheme,
                    destinationResourceId: properties.DestinationScheme);
            }
            else
            {
                factory.CreateStubJobPartPlanFilesAsync(
                    checkpointerPath,
                    properties.TransferId,
                    1, /* jobPartCount */
                    StorageTransferStatus.InProgress,
                    new List<string> { properties.SourcePath },
                    new List<string> { properties.DestinationPath },
                    sourceResourceId: properties.SourceScheme,
                    destinationResourceId: properties.DestinationScheme);
            }
        }

        private void AssertTransferProperties(DataTransferProperties expected, DataTransferProperties actual)
        {
            Assert.AreEqual(expected.TransferId, actual.TransferId);
            Assert.AreEqual(expected.SourceScheme, actual.SourceScheme);
            Assert.AreEqual(expected.SourcePath.TrimEnd('\\', '/'), actual.SourcePath.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.DestinationScheme, actual.DestinationScheme);
            Assert.AreEqual(expected.DestinationPath.TrimEnd('\\', '/'), actual.DestinationPath.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.IsContainer, actual.IsContainer);
        }
    }
}
