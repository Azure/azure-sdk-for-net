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
                CheckpointStoreOptions = TransferCheckpointStoreOptions.DisableCheckpoint()
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
                CheckpointStoreOptions = TransferCheckpointStoreOptions.DisableCheckpoint()
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
            (StorageResourceItem source, StorageResourceItem destination) = MockStorageResourceItem.GetMockTransferResources(transferDirection);
            TransferManagerOptions managerOptions = new()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.DisableCheckpoint()
            };
            TransferManager transferManager = new(managerOptions);

            TransferOptions transferOptions = new();
            TestEventsRaised events = new(transferOptions);
            TransferOperation transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            await events.AssertSingleCompletedCheck();
        }

        [Test]
        public async Task BasicTransfer_Container(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection)
        {
            Uri localUri = new(@"C:\SampleContainer");
            Uri remoteUri = new("https://example.com/container1");
            Uri remoteUri2 = new("https://example.com/container2");
            int resourceCount = 3;

            StorageResourceContainer source;
            StorageResourceContainer destination;
            if (transferDirection == TransferDirection.Copy)
            {
                source = new MockStorageResourceContainer(remoteUri, resourceCount: resourceCount);
                destination = new MockStorageResourceContainer(remoteUri2);
            }
            else if (transferDirection == TransferDirection.Upload)
            {
                source = new MockStorageResourceContainer(localUri, resourceCount: resourceCount);
                destination = new MockStorageResourceContainer(remoteUri2);
            }
            else // transferType == TransferDirection.Download
            {
                source = new MockStorageResourceContainer(remoteUri, resourceCount: resourceCount);
                destination = new MockStorageResourceContainer(localUri);
            }

            TransferManagerOptions managerOptions = new()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.DisableCheckpoint()
            };
            TransferManager transferManager = new(managerOptions);

            TransferOptions transferOptions = new();
            TestEventsRaised events = new(transferOptions);
            TransferOperation transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            await events.AssertContainerCompletedCheck(resourceCount);
        }
    }
}
