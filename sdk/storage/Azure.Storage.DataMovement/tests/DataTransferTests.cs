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
        private static DataTransferStatus QueuedStatus => new DataTransferStatus(DataTransferState.Queued, false, false);
        private static DataTransferStatus InProgressStatus => new DataTransferStatus(DataTransferState.InProgress, false, false);
        private static DataTransferStatus SuccessfulCompletedStatus => new DataTransferStatus(DataTransferState.Completed, false, false);

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
        [TestCase(DataTransferState.None, false)]
        [TestCase(DataTransferState.Queued, false)]
        [TestCase(DataTransferState.InProgress, false)]
        [TestCase(DataTransferState.Pausing, false)]
        [TestCase(DataTransferState.Paused, false)]
        [TestCase(DataTransferState.Stopping, false)]
        [TestCase(DataTransferState.Stopping, true)]
        public void HasCompleted_False(DataTransferState status, bool hasFailedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();
            TransferManager transferManager = new();

            // Act
            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: transferManager,
                status: new DataTransferStatus(status, hasFailedItems, false));

            // Assert
            Assert.AreEqual(transferId, transfer.Id);
            Assert.AreEqual(transferManager, transfer.TransferManager);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferState.Completed, false, false)]
        [TestCase(DataTransferState.Completed, false, true)]
        [TestCase(DataTransferState.Completed, true, false)]
        [TestCase(DataTransferState.Completed, true, true)]
        public void HasCompleted_True(
            DataTransferState state,
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
                status: new DataTransferStatus(state, hasFailedItems, hasSkippedItems));

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

            Assert.AreEqual(DataTransferState.Pausing, transfer.TransferStatus.State);

            // Assert
            if (!transfer._state.TrySetTransferState(DataTransferState.Paused))
            {
                Assert.Fail("Unable to set the transfer status internally to the DataTransfer.");
            }

            await pauseTask;

            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferState.Paused, false, false)]
        [TestCase(DataTransferState.Completed, false, false)]
        [TestCase(DataTransferState.Completed, false, true)]
        [TestCase(DataTransferState.Completed, true, false)]
        [TestCase(DataTransferState.Completed, true, true)]
        public async Task TryPauseAsync_AlreadyPaused(
            DataTransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransferStatus originalStatus = new DataTransferStatus(state, hasFailedItems, hasSkippedItems);

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: originalStatus);

            Assert.AreEqual(originalStatus, transfer.TransferStatus);
            await transfer.PauseAsync();
            Assert.AreEqual(originalStatus, transfer.TransferStatus);
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
            Assert.AreEqual(DataTransferState.Pausing, transfer.TransferStatus.State);
            Assert.IsFalse(transfer.HasCompleted);
        }
    }
}
