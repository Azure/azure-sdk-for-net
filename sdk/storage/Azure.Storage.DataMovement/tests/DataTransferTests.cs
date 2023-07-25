﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        [TestCase(StorageTransferStatus.None)]
        [TestCase(StorageTransferStatus.Queued)]
        [TestCase(StorageTransferStatus.InProgress)]
        [TestCase(StorageTransferStatus.PauseInProgress)]
        [TestCase(StorageTransferStatus.CancellationInProgress)]
        [TestCase(StorageTransferStatus.Paused)]
        public void HasCompleted_False(StorageTransferStatus status)
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
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public void HasCompleted_True(StorageTransferStatus status)
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
                status: StorageTransferStatus.Completed);

            // Act
            transfer.EnsureCompleted();

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
                status: StorageTransferStatus.Queued);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            // Act
            TestHelper.AssertExpectedException(
                () => transfer.EnsureCompleted(cancellationTokenSource.Token),
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
                status: StorageTransferStatus.Completed);

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
                status: StorageTransferStatus.Queued);
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
                status: StorageTransferStatus.InProgress);

            // Act
            Task pauseTask = transfer.PauseIfRunningAsync();

            Assert.AreEqual(StorageTransferStatus.PauseInProgress, transfer.TransferStatus);

            // Assert
            if (!transfer._state.TrySetTransferStatus(StorageTransferStatus.Paused))
            {
                Assert.Fail("Unable to set the transfer status internally to the DataTransfer.");
            }

            await pauseTask;

            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(StorageTransferStatus.Paused)]
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public async Task TryPauseAsync_AlreadyPaused(StorageTransferStatus status)
        {
            // Arrange
            string transferId = GetNewTransferId();

            DataTransfer transfer = new DataTransfer(
                id: transferId,
                transferManager: new(),
                status: status);

            Assert.AreEqual(status, transfer.TransferStatus);
            await transfer.PauseIfRunningAsync();
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
                status: StorageTransferStatus.InProgress);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.PauseIfRunningAsync(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "The operation was canceled.");
            }
            Assert.AreEqual(StorageTransferStatus.PauseInProgress, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }
    }
}
