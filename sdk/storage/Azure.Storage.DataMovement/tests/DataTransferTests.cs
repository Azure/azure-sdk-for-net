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
                new TaskCanceledException("A task was canceled."));
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
            catch (TaskCanceledException exception)
            {
                Assert.AreEqual(exception.Message, "A task was canceled.");
            }
        }
    }
}
