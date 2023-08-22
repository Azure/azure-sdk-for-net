// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class DataTransferTests
    {
        private static string GetNewTransferId() => Guid.NewGuid().ToString();
        private static DataTransferStatus QueuedStatus => new DataTransferStatus(DataTransferStatus.TransferState.Queued, false, false);
        private static DataTransferStatus InProgressStatus => new DataTransferStatus(DataTransferStatus.TransferState.InProgress, false, false);
        private static DataTransferStatus SuccessfulCompletedStatus => new DataTransferStatus(DataTransferStatus.TransferState.Completed, false, false);

        [Test]
        public void Ctor_Default()
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            // Act
            DataTransfer transfer = new DataTransfer(id: transferId, transferManager: transferManager);

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferStatus.TransferState.None, false)]
        [TestCase(DataTransferStatus.TransferState.Queued, false)]
        [TestCase(DataTransferStatus.TransferState.InProgress, false)]
        [TestCase(DataTransferStatus.TransferState.Pausing, false)]
        [TestCase(DataTransferStatus.TransferState.Paused, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, true)]
        public void HasCompleted_False(DataTransferStatus.TransferState status, bool HasFailures)
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            // Act
            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: transferManager,
                status: new DataTransferStatus(status, HasFailures, false));

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferStatus.TransferState.Completed, false, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, false, true)]
        [TestCase(DataTransferStatus.TransferState.Completed, true, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, true, true)]
        public void HasCompleted_True(
            DataTransferStatus status,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            // Act
            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: transferManager,
                status: status);

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsTrue(transfer.HasCompleted);
        }

        [Test]
        public void EnsureCompleted()
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: transferManager,
                status: SuccessfulCompletedStatus);

            // Act
            transfer.WaitForCompletion();

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsTrue(transfer.HasCompleted);
        }

        [Test]
        public void EnsureCompleted_CancellationToken()
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: QueuedStatus);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            // Act
            TestHelper.AssertExpectedException(
                () => transfer.WaitForCompletion(cancellationTokenSource.Token),
                new OperationCanceledException("The operation was canceled."));
        }

        [Test]
        public async Task AwaitCompletion()
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: transferManager,
                status: SuccessfulCompletedStatus);

            // Act
            await transfer.WaitForCompletionAsync();

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsTrue(transfer.HasCompleted);
        }

        [Test]
        public void AwaitCompletion_CancellationToken()
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: QueuedStatus);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            Assert.CatchAsync<OperationCanceledException>(
                async () => await transfer.WaitForCompletionAsync(cancellationTokenSource.Token),
                "Expected OperationCanceledException to be thrown");
        }

        [Test]
        public async Task TryPauseAsync()
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: InProgressStatus);

            // Act
            Task pauseTask = transfer.PauseAsync();

            Assert.AreEqual(DataTransferStatus.TransferState.Pausing, transfer.TransferStatus);

            // Assert
            if (!transfer._state.TrySetTransferState(DataTransferStatus.TransferState.Paused))
            {
                Assert.Fail("Unable to set the transfer status internally to the DataTransfer.");
            }

            await pauseTask;

            Assert.AreEqual(DataTransferStatus.TransferState.Paused, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferStatus.TransferState.Paused, false, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, false, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, false, true)]
        [TestCase(DataTransferStatus.TransferState.Completed, true, false)]
        [TestCase(DataTransferStatus.TransferState.Completed, true, true)]
        public async Task TryPauseAsync_AlreadyPaused(
            DataTransferStatus status,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: status);

            Assert.AreEqual(status, transfer.TransferStatus);
            await transfer.PauseAsync();
            Assert.AreEqual(status, transfer.TransferStatus);
        }

        [Test]
        public async Task TryPauseAsync_CancellationToken()
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: InProgressStatus);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.PauseAsync(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "The operation was canceled.");
            }
            Assert.AreEqual(DataTransferStatus.TransferState.Pausing, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }
    }
}
