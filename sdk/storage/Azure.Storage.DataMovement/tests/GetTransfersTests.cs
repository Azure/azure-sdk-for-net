// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// These tests aim to test the <see cref="TransferManager.GetTransfers(DataTransferStatus)"/>.
    /// </summary>
    public class GetTransfersTests
    {
        private static DataTransferStatus QueuedStatus => new DataTransferStatus(DataTransferState.Queued, false, false);
        private static DataTransferStatus InProgressStatus => new DataTransferStatus(DataTransferState.InProgress, false, false);
        private static DataTransferStatus PausedStatus => new DataTransferStatus(DataTransferState.Paused, false, false);
        private static DataTransferStatus SuccessfulCompletedStatus => new DataTransferStatus(DataTransferState.Completed, false, false);
        private static DataTransferStatus FailedCompletedStatus => new DataTransferStatus(DataTransferState.Completed, true, false);
        private static DataTransferStatus SkippedCompletedStatus => new DataTransferStatus(DataTransferState.Completed, true, false);
        private static DataTransferStatus FailedSkippedCompletedStatus => new DataTransferStatus(DataTransferState.Completed, true, false);

        private TransferManagerOptions GetDefaultManagerOptions(string checkpointerPath) =>
            new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerPath)
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
            DataTransferStatus status = default)
        {
            return new DataTransfer(
                id: Guid.NewGuid().ToString(),
                transferManager: new(),
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
        [TestCase(DataTransferState.Queued, false, false)]
        [TestCase(DataTransferState.InProgress, false, false)]
        [TestCase(DataTransferState.Paused, false, false)]
        [TestCase(DataTransferState.Completed, false, false)]
        [TestCase(DataTransferState.Completed, true, false)]
        public async Task GetTransfers_Filtered(
            DataTransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            DataTransferStatus status = new DataTransferStatus(state, hasFailedItems, hasSkippedItems);
            IList<DataTransfer> result = await manager.GetTransfersAsync(status).ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers.Where(d => d.TransferStatus == status).ToList(), result);
        }

        [Test]
        public async Task GetTransfers_FilterMultipleStatuses()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
                GetNewDataTransfer(SkippedCompletedStatus)
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            DataTransferStatus[] statuses = new DataTransferStatus[] {
                SuccessfulCompletedStatus,
                FailedCompletedStatus,
                SkippedCompletedStatus };
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
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(QueuedStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(InProgressStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(PausedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(FailedCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
                GetNewDataTransfer(SuccessfulCompletedStatus),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act - With a transfer status not in the above stored transfers
            DataTransferStatus[] statuses = new DataTransferStatus[] { new DataTransferStatus(DataTransferState.Stopping, true, false) };
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
                CheckpointerOptions = new TransferCheckpointStoreOptions(test.DirectoryPath)
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
            Uri parentRemoteUri = new("https://account.blob.core.windows.net/resume-test/");
            Uri parentLocalUri1 = new("file://resume-test/");
            Uri parentLocalUri2 = new(@"file:///C:\Windows\Path\");

            LocalTransferCheckpointerFactory factory = new LocalTransferCheckpointerFactory(test.DirectoryPath);

            // Build expected results first to use to populate checkpointer
            DataTransferProperties[] expectedResults = new DataTransferProperties[]
            {
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "local", SourceUri = new Uri(parentLocalUri1, "file1"), DestinationProviderId = "blob", DestinationUri = new Uri(parentRemoteUri, "file1"), IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = new Uri(parentRemoteUri, "file2/"), DestinationProviderId = "local", DestinationUri = new Uri(parentLocalUri1, "file2/"), IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = new Uri(parentRemoteUri, "file3"), DestinationProviderId = "blob", DestinationUri = new Uri(parentRemoteUri, "file3"), IsContainer = false },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = parentRemoteUri, DestinationProviderId = "local", DestinationUri = parentLocalUri1, IsContainer = true },
                new DataTransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "local", SourceUri = parentLocalUri2, DestinationProviderId = "blob", DestinationUri = parentRemoteUri, IsContainer = true },
            };

            // Add a transfer for each expected result
            foreach (DataTransferProperties props in expectedResults)
            {
                AddTransferFromDataTransferProperties(factory, test.DirectoryPath, props);
            }

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(test.DirectoryPath)
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
            factory.CreateStubJobPlanFile(test.DirectoryPath, transferId1, status: SuccessfulCompletedStatus);
            factory.CreateStubJobPartPlanFilesAsync(
                test.DirectoryPath,
                transferId1,
                3 /* jobPartCount */);

            string transferId2 = Guid.NewGuid().ToString();
            factory.CreateStubJobPlanFile(test.DirectoryPath, transferId2, status: QueuedStatus);
            factory.CreateStubJobPartPlanFilesAsync(
                test.DirectoryPath,
                transferId2,
                3 /* jobPartCount */);

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(test.DirectoryPath)
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
            // First add the job plan file for the transfer
            factory.CreateStubJobPlanFile(
                checkpointerPath,
                properties.TransferId,
                parentSourcePath: properties.SourceUri.AbsoluteUri,
                parentDestinationPath: properties.DestinationUri.AbsoluteUri,
                sourceProviderId: properties.SourceProviderId,
                destinationProviderId: properties.DestinationProviderId,
                isContainer: properties.IsContainer,
                sourceCheckpointData: MockResourceCheckpointData.DefaultInstance,
                destinationCheckpointData: MockResourceCheckpointData.DefaultInstance);

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
                        sourcePaths.Add(properties.SourceUri + $"file{i}/");
                        destinationPaths.Add(properties.DestinationUri + $"file{i}/");
                        continue;
                    }

                    sourcePaths.Add(properties.SourceUri + $"file{i}");
                    destinationPaths.Add(properties.DestinationUri + $"file{i}");
                }

                // Because type ID is null on container transfers, derive a type from provider id
                string sourceTypeId = GetTypeIdForProvider(properties.SourceProviderId);
                string destinationTypeId = GetTypeIdForProvider(properties.DestinationProviderId);
                factory.CreateStubJobPartPlanFilesAsync(
                    checkpointerPath,
                    properties.TransferId,
                    numParts, /* jobPartCount */
                    InProgressStatus,
                    sourcePaths,
                    destinationPaths);
            }
            else
            {
                factory.CreateStubJobPartPlanFilesAsync(
                    checkpointerPath,
                    properties.TransferId,
                    1, /* jobPartCount */
                    InProgressStatus,
                    new List<string> { properties.SourceUri.AbsoluteUri },
                    new List<string> { properties.DestinationUri.AbsoluteUri });
            }
        }

        private void AssertTransferProperties(DataTransferProperties expected, DataTransferProperties actual)
        {
            Assert.AreEqual(expected.TransferId, actual.TransferId);
            Assert.AreEqual(expected.SourceProviderId, actual.SourceProviderId);
            Assert.AreEqual(expected.SourceUri.AbsoluteUri.TrimEnd('\\', '/'), actual.SourceUri.AbsoluteUri.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.DestinationProviderId, actual.DestinationProviderId);
            Assert.AreEqual(expected.DestinationUri.AbsoluteUri.TrimEnd('\\', '/'), actual.DestinationUri.AbsoluteUri.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.IsContainer, actual.IsContainer);

            CollectionAssert.AreEqual(MockResourceCheckpointData.DefaultInstance.Bytes, actual.SourceCheckpointData);
            CollectionAssert.AreEqual(MockResourceCheckpointData.DefaultInstance.Bytes, actual.DestinationCheckpointData);
        }

        private string GetTypeIdForProvider(string providerId)
            => providerId switch
            {
                "blob" => "BlockBlob",
                "local" => "LocalFile",
                _ => "Unknown"
            };
    }
}
