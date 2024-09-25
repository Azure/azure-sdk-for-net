// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    public class DisabledCheckpointerTests : DataMovementTestBase
    {
        public DisabledCheckpointerTests(bool async)
            : base(async)
        {
        }

        [Test]
        public async Task TransferManager_GetTransfers()
        {
            TransferManagerOptions managerOptions = new()
            {
                CheckpointerOptions = TransferCheckpointStoreOptions.Disabled()
            };
            TransferManager transferManager = new(managerOptions);

            var transfers = await transferManager.GetTransfersAsync().ToListAsync();
            Assert.That(transfers, Is.Empty);

            var resumable = await transferManager.GetResumableTransfersAsync().ToListAsync();
            Assert.That(resumable, Is.Empty);
        }

        [Test]
        public void TransferManager_Resume()
        {
            TransferManagerOptions managerOptions = new()
            {
                CheckpointerOptions = TransferCheckpointStoreOptions.Disabled()
            };
            TransferManager transferManager = new(managerOptions);

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await transferManager.ResumeTransferAsync(Guid.NewGuid().ToString()));
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await transferManager.ResumeAllTransfersAsync());
        }

        [Test]
        public async Task BasicTransfer_Single(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection)
        {
            (StorageResourceItem source, StorageResourceItem destination) = MockStorageResource.GetMockTransferResources(transferDirection);
            TransferManagerOptions managerOptions = new()
            {
                CheckpointerOptions = TransferCheckpointStoreOptions.Disabled()
            };
            TransferManager transferManager = new(managerOptions);

            DataTransferOptions transferOptions = new();
            TestEventsRaised events = new(transferOptions);
            DataTransfer transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(10));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            events.AssertUnexpectedFailureCheck();
            await events.AssertSingleCompletedCheck();
        }
    }
}
