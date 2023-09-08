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
        [TestCase(DataTransferStatus.None)]
        [TestCase(DataTransferStatus.Queued)]
        [TestCase(DataTransferStatus.InProgress)]
        [TestCase(DataTransferStatus.PauseInProgress)]
        [TestCase(DataTransferStatus.CancellationInProgress)]
        [TestCase(DataTransferStatus.Paused)]
        public void HasCompleted_False(DataTransferStatus status)
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
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferStatus.Completed)]
        [TestCase(DataTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(DataTransferStatus.CompletedWithFailedTransfers)]
        public void HasCompleted_True(DataTransferStatus status)
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
                status: DataTransferStatus.Completed);

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
                status: DataTransferStatus.Queued);
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
                status: DataTransferStatus.Completed);

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
                status: DataTransferStatus.Queued);
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
                status: DataTransferStatus.InProgress);

            // Act
            Task pauseTask = transfer.PauseAsync();

            Assert.AreEqual(DataTransferStatus.PauseInProgress, transfer.TransferStatus);

            // Assert
            if (!transfer._state.TrySetTransferStatus(DataTransferStatus.Paused))
            {
                Assert.Fail("Unable to set the transfer status internally to the DataTransfer.");
            }

            await pauseTask;

            Assert.AreEqual(DataTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(DataTransferStatus.Paused)]
        [TestCase(DataTransferStatus.Completed)]
        [TestCase(DataTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(DataTransferStatus.CompletedWithFailedTransfers)]
        public async Task TryPauseAsync_AlreadyPaused(DataTransferStatus status)
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
                status: DataTransferStatus.InProgress);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.PauseAsync(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "The operation was canceled.");
            }
            Assert.AreEqual(DataTransferStatus.PauseInProgress, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }
    }
}
