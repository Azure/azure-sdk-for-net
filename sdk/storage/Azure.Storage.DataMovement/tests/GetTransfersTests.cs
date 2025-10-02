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
    /// These tests aim to test the <see cref="TransferManager.GetTransfers(TransferStatus)"/>.
    /// </summary>
    public class GetTransfersTests
    {
        private static TransferStatus QueuedStatus => new TransferStatus(TransferState.Queued, false, false);
        private static TransferStatus InProgressStatus => new TransferStatus(TransferState.InProgress, false, false);
        private static TransferStatus PausedStatus => new TransferStatus(TransferState.Paused, false, false);
        private static TransferStatus SuccessfulCompletedStatus => new TransferStatus(TransferState.Completed, false, false);
        private static TransferStatus FailedCompletedStatus => new TransferStatus(TransferState.Completed, true, false);
        private static TransferStatus SkippedCompletedStatus => new TransferStatus(TransferState.Completed, true, false);
        private static TransferStatus FailedSkippedCompletedStatus => new TransferStatus(TransferState.Completed, true, false);

        private TransferManagerOptions GetDefaultManagerOptions(string checkpointerPath) =>
            new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerPath)
            };

        private void AssertListTransfersEquals(IList<TransferOperation> expected, IList<TransferOperation> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            // Sort
            IList<TransferOperation> expectedSorted = expected.OrderBy(a => a.Id).ToList();
            IList<TransferOperation> actualSorted = actual.OrderBy(a => a.Id).ToList();

            for (int i = 0; i < expectedSorted.Count; i++)
            {
                TransferOperation expectedValue = expectedSorted.ElementAt(i);
                TransferOperation actualValue = actualSorted.ElementAt(i);
                Assert.AreEqual(expectedValue.Id, actualValue.Id);
                Assert.AreEqual(expectedValue.Status, actualValue.Status);
            }
        }

        private TransferOperation GetNewTransferOperation(
            TransferStatus status = default)
        {
            return new TransferOperation(
                id: Guid.NewGuid().ToString(),
                status: status);
        }

        [Test]
        public async Task GetTransfers_Empty()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange
            await using TransferManager manager = new TransferManager(GetDefaultManagerOptions(testDirectory.DirectoryPath));

            // Act
            IList<TransferOperation> transfers = await manager.GetTransfersAsync().ToListAsync();

            // Assert
            Assert.IsEmpty(transfers);
        }

        [Test]
        public async Task GetTransfers_Populated()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<TransferOperation> storedTransfers = new List<TransferOperation>
            {
                GetNewTransferOperation(),
                GetNewTransferOperation(),
                GetNewTransferOperation(),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            await using TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            IList<TransferOperation> result = await manager.GetTransfersAsync().ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers, result);
        }

        [Test]
        [TestCase(TransferState.Queued, false, false)]
        [TestCase(TransferState.InProgress, false, false)]
        [TestCase(TransferState.Paused, false, false)]
        [TestCase(TransferState.Completed, false, false)]
        [TestCase(TransferState.Completed, true, false)]
        public async Task GetTransfers_Filtered(
            TransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<TransferOperation> storedTransfers = new List<TransferOperation>
            {
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            await using TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            TransferStatus[] status = { new TransferStatus(state, hasFailedItems, hasSkippedItems) };
            IList<TransferOperation> result = await manager.GetTransfersAsync(status).ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers.Where(d => d.Status == status.First()).ToList(), result);
        }

        [Test]
        public async Task GetTransfers_FilterMultipleStatuses()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<TransferOperation> storedTransfers = new List<TransferOperation>
            {
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
                GetNewTransferOperation(SkippedCompletedStatus)
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            await using TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act
            TransferStatus[] statuses = new TransferStatus[] {
                SuccessfulCompletedStatus,
                FailedCompletedStatus,
                SkippedCompletedStatus };
            IList<TransferOperation> result = await manager.GetTransfersAsync(statuses).ToListAsync();

            // Assert
            AssertListTransfersEquals(storedTransfers.Where(d => statuses.Contains(d.Status)).ToList(), result);
        }

        [Test]
        public async Task GetTransfers_Filtered_Empty()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange - Set up transfer manager with multiple transfers
            List<TransferOperation> storedTransfers = new List<TransferOperation>
            {
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(QueuedStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(InProgressStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(PausedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(FailedCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
                GetNewTransferOperation(SuccessfulCompletedStatus),
            };
            TransferManagerFactory factory =
                new TransferManagerFactory(GetDefaultManagerOptions(testDirectory.DirectoryPath));
            await using TransferManager manager = factory.BuildTransferManager(storedTransfers);

            // Act - With a transfer status not in the above stored transfers
            TransferStatus[] statuses = new TransferStatus[] { new TransferStatus(TransferState.Stopping, true, false) };
            IList<TransferOperation> result = await manager.GetTransfersAsync(statuses).ToListAsync();

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
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(test.DirectoryPath)
            };
            await using TransferManager manager = new TransferManager(options);

            // Act
            IList<TransferOperation> result = await manager.GetTransfersAsync().ToListAsync();
            List<string> resultIds = result.Select(t => t.Id).ToList();

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(checkpointerTransfers.OrderBy(id => id), result.Select(t => t.Id).OrderBy(id => id)));
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
            TransferProperties[] expectedResults = new TransferProperties[]
            {
                new TransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "local", SourceUri = new Uri(parentLocalUri1, "file1"), DestinationProviderId = "blob", DestinationUri = new Uri(parentRemoteUri, "file1"), IsContainer = false },
                new TransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = new Uri(parentRemoteUri, "file2/"), DestinationProviderId = "local", DestinationUri = new Uri(parentLocalUri1, "file2/"), IsContainer = false },
                new TransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = new Uri(parentRemoteUri, "file3"), DestinationProviderId = "blob", DestinationUri = new Uri(parentRemoteUri, "file3"), IsContainer = false },
                new TransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "blob", SourceUri = parentRemoteUri, DestinationProviderId = "local", DestinationUri = parentLocalUri1, IsContainer = true },
                new TransferProperties { TransferId = Guid.NewGuid().ToString(), SourceProviderId = "local", SourceUri = parentLocalUri2, DestinationProviderId = "blob", DestinationUri = parentRemoteUri, IsContainer = true },
            };

            // Add a transfer for each expected result
            foreach (TransferProperties props in expectedResults)
            {
                AddTransferFromTransferProperties(factory, test.DirectoryPath, props);
            }

            // Build TransferManager with the stored transfers
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(test.DirectoryPath)
            };
            await using TransferManager manager = new TransferManager(options);

            // Act
            IList<TransferProperties> result = await manager.GetResumableTransfersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(5, result.Count);
            foreach (TransferProperties props in result)
            {
                TransferProperties expected = expectedResults.Where(p => p.TransferId == props.TransferId).First();
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
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(test.DirectoryPath)
            };
            await using TransferManager manager = new TransferManager(options);

            // Act
            IList<TransferProperties> result = await manager.GetResumableTransfersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(transferId2, result.First().TransferId);
        }

        private void AddTransferFromTransferProperties(
            LocalTransferCheckpointerFactory factory,
            string checkpointerPath,
            TransferProperties properties)
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
                sourceCheckpointDetails: MockResourceCheckpointDetails.DefaultInstance,
                destinationCheckpointDetails: MockResourceCheckpointDetails.DefaultInstance);

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

        private void AssertTransferProperties(TransferProperties expected, TransferProperties actual)
        {
            Assert.AreEqual(expected.TransferId, actual.TransferId);
            Assert.AreEqual(expected.SourceProviderId, actual.SourceProviderId);
            Assert.AreEqual(expected.SourceUri.AbsoluteUri.TrimEnd('\\', '/'), actual.SourceUri.AbsoluteUri.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.DestinationProviderId, actual.DestinationProviderId);
            Assert.AreEqual(expected.DestinationUri.AbsoluteUri.TrimEnd('\\', '/'), actual.DestinationUri.AbsoluteUri.TrimEnd('\\', '/'));
            Assert.AreEqual(expected.IsContainer, actual.IsContainer);

            CollectionAssert.AreEqual(MockResourceCheckpointDetails.DefaultInstance.Bytes, actual.SourceCheckpointDetails);
            CollectionAssert.AreEqual(MockResourceCheckpointDetails.DefaultInstance.Bytes, actual.DestinationCheckpointDetails);
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
