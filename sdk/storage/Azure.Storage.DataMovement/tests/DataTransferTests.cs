// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class DataTransferTests
    {
        [Test]
        public void Ctor_Default()
        {
            DataTransfer transfer = new DataTransfer();

            Assert.IsNotEmpty(transfer.Id);
            Assert.IsNotEmpty(transfer.Id);
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
            DataTransfer transfer = new DataTransfer(status);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public void HasCompleted_True(StorageTransferStatus status)
        {
            DataTransfer transfer = new DataTransfer(status);
            Assert.IsTrue(transfer.HasCompleted);
        }

        [Test]
        public void EnsureCompleted()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.Completed);
            transfer.EnsureCompleted();
        }

        [Test]
        public void EnsureCompleted_CancellationToken()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.Queued);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            TestHelper.AssertExpectedException(
                () => transfer.EnsureCompleted(cancellationTokenSource.Token),
                new OperationCanceledException("The operation was canceled."));
        }

        [Test]
        public async Task AwaitCompletion()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.Completed);
            await transfer.AwaitCompletion();
        }

        [Test]
        public async Task AwaitCompletion_CancellationToken()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.Queued);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.AwaitCompletion(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "The operation was canceled.");
            }
        }

        [Test]
        public async Task TryPauseAsync()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.InProgress);

            Task<bool> pauseTask = transfer.TryPauseAsync();

            Assert.AreEqual(StorageTransferStatus.PauseInProgress, transfer.TransferStatus);

            if (!transfer._state.TrySetTransferStatus(StorageTransferStatus.Paused))
            {
                Assert.Fail("Unable to set the transfer status internally to the DataTransfer.");
            }

            bool pauseResult = await pauseTask;

            Assert.IsTrue(pauseResult);
            Assert.IsFalse(transfer.HasCompleted);
        }

        [Test]
        [TestCase(StorageTransferStatus.Paused)]
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithSkippedTransfers)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public async Task TryPauseAsync_AlreadyPaused(StorageTransferStatus status)
        {
            DataTransfer transfer = new DataTransfer(status);

            bool pauseResult = await transfer.TryPauseAsync();

            Assert.IsFalse(pauseResult);
        }

        [Test]
        public async Task TryPauseAsync_CancellationToken()
        {
            DataTransfer transfer = new DataTransfer(StorageTransferStatus.InProgress);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

            try
            {
                await transfer.TryPauseAsync(cancellationTokenSource.Token);
            }
            catch (TaskCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "A task was canceled.");
            }
            Assert.AreEqual(StorageTransferStatus.PauseInProgress, transfer.TransferStatus);
            Assert.IsFalse(transfer.HasCompleted);
        }
    }
}
