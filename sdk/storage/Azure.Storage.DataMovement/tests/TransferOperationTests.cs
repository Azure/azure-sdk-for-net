// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class TransferOperationTests
    {
        private static string GetNewTransferId() => Guid.NewGuid().ToString();
        private static TransferStatus QueuedStatus => new TransferStatus(TransferState.Queued, false, false);
        private static TransferStatus InProgressStatus => new TransferStatus(TransferState.InProgress, false, false);
        private static TransferStatus SuccessfulCompletedStatus => new TransferStatus(TransferState.Completed, false, false);

        [Test]
        public void Ctor_Default()
        {
            // Arrange
            string transferId = GetNewTransferId();

            // Act
            TransferOperation transfer = new TransferOperation(
                id: transferId);

            // Assert
            Assert.That(transfer.Id, Is.EqualTo(transferId));
            Assert.That(transfer.HasCompleted, Is.False);
        }

        [Test]
        [TestCase(TransferState.None, false)]
        [TestCase(TransferState.Queued, false)]
        [TestCase(TransferState.InProgress, false)]
        [TestCase(TransferState.Pausing, false)]
        [TestCase(TransferState.Paused, false)]
        [TestCase(TransferState.Stopping, false)]
        [TestCase(TransferState.Stopping, true)]
        public void HasCompleted_False(TransferState status, bool hasFailedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();

            // Act
            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: new TransferStatus(status, hasFailedItems, false));

            // Assert
            Assert.That(transfer.Id, Is.EqualTo(transferId));
            Assert.That(transfer.HasCompleted, Is.False);
        }

        [Test]
        [TestCase(TransferState.Completed, false, false)]
        [TestCase(TransferState.Completed, false, true)]
        [TestCase(TransferState.Completed, true, false)]
        [TestCase(TransferState.Completed, true, true)]
        public void HasCompleted_True(
            TransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();

            // Act
            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: new TransferStatus(state, hasFailedItems, hasSkippedItems));

            // Assert
            Assert.That(transfer.Id, Is.EqualTo(transferId));
            Assert.That(transfer.HasCompleted, Is.True);
        }

        [Test]
        public async Task AwaitCompletion()
        {
            // Arrange
            string transferId = GetNewTransferId();

            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: SuccessfulCompletedStatus);

            // Act
            await transfer.WaitForCompletionAsync();

            // Assert
            Assert.That(transfer.Id, Is.EqualTo(transferId));
            Assert.That(transfer.HasCompleted, Is.True);
        }

        [Test]
        public void AwaitCompletion_CancellationToken()
        {
            // Arrange
            string transferId = GetNewTransferId();

            TransferOperation transfer = new TransferOperation(
                id: transferId,
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

            await using TransferManager transferManager = new TransferManager();
            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: InProgressStatus)
            {
                TransferManager = transferManager
            };

            // Act
            Task pauseTask = transfer.PauseAsync();

            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Pausing));

            // Assert
            Assert.That(transfer._state.SetTransferState(TransferState.Paused), Is.True);

            await pauseTask;

            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Paused));
            Assert.That(transfer.HasCompleted, Is.False);
        }

        [Test]
        [TestCase(TransferState.Paused, false, false)]
        [TestCase(TransferState.Completed, false, false)]
        [TestCase(TransferState.Completed, false, true)]
        [TestCase(TransferState.Completed, true, false)]
        [TestCase(TransferState.Completed, true, true)]
        public async Task TryPauseAsync_AlreadyPaused(
            TransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
        {
            // Arrange
            string transferId = GetNewTransferId();

            TransferStatus originalStatus = new TransferStatus(state, hasFailedItems, hasSkippedItems);

            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: originalStatus);

            Assert.That(transfer.Status, Is.EqualTo(originalStatus));
            await transfer.PauseAsync();
            Assert.That(transfer.Status, Is.EqualTo(originalStatus));
        }

        [Test]
        public async Task TryPauseAsync_CancellationToken()
        {
            // Arrange
            string transferId = GetNewTransferId();

            TransferOperation transfer = new TransferOperation(
                id: transferId,
                status: InProgressStatus);
            transfer.TransferManager = new TransferManager();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.PauseAsync(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Assert.That(exception.Message, Is.EqualTo("The operation was canceled."));
            }
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Pausing));
            Assert.That(transfer.HasCompleted, Is.False);
        }
    }
}
