// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class TransferValidationTests
    {
        [Test, Pairwise]
        public async Task LargeSingleFile(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(TransferOrder.Sequential, TransferOrder.Unordered)] TransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            Uri localUri = new(@"C:\Sample\test.txt");
            Uri remoteUri = new("https://example.com");
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResourceItem.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize);

            TransferManager transferManager = new();
            TransferOptions options = new();
            TestEventsRaised events = new(options);
            TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            events.AssertUnexpectedFailureCheck();
            await events.AssertSingleCompletedCheck();
        }

        [Test, Pairwise]
        public async Task LargeSingleFile_Fail_Source(
            [Values(TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(TransferOrder.Sequential, TransferOrder.Unordered)] TransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResourceItem.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize,
                sourceFailAfter: 10);

            TransferManager transferManager = new();
            TransferOptions options = new();
            TestEventsRaised events = new(options);
            TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(events.FailedEvents, Is.Not.Empty);
            Assert.That(events.FailedEvents.First().Exception.Message, Does.Contain("Intentionally failing"));
        }

        [Test, Pairwise]
        public async Task LargeSingleFile_Fail_Destination(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(TransferOrder.Sequential, TransferOrder.Unordered)] TransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResourceItem.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize,
                destinationFailAfter: 10);

            TransferManager transferManager = new();
            TransferOptions options = new();
            TestEventsRaised events = new(options);
            TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(events.FailedEvents, Is.Not.Empty);
            Assert.That(events.FailedEvents.First().Exception.Message, Does.Contain("Intentionally failing"));
        }

        [Test]
        public void InvalidTransferOptions()
        {
            StorageResourceItem srcResource = MockStorageResourceItem.MakeSourceResource(1024);
            StorageResourceItem dstResource = MockStorageResourceItem.MakeDestinationResource();
            TransferManager transferManager = new();

            TransferOptions options = new()
            {
                InitialTransferSize = 0,
            };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                await transferManager.StartTransferAsync(srcResource, dstResource, options));

            options = new()
            {
                MaximumTransferChunkSize = 0,
            };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                await transferManager.StartTransferAsync(srcResource, dstResource, options));
        }

        [TestCase(Constants.GB, 4 * Constants.MB, 4000L * Constants.MB, 50000)]
        [TestCase(500L * Constants.GB, 16 * Constants.MB, 4000L * Constants.MB, 50000)]
        [TestCase(500L * Constants.GB, 4 * Constants.MB, 4 * Constants.MB, int.MaxValue)]
        public async Task ResourceChunkSizeAndCount(long size, long chunkSize, long maxChunkSize, int maxChunkCount)
        {
            StorageResourceItem srcResource = MockStorageResourceItem.MakeSourceResource(size);
            StorageResourceItem dstResource = MockStorageResourceItem.MakeDestinationResource(
                maxSupportedChunkSize: maxChunkSize,
                maxSupportChunkCount: maxChunkCount);

            TransferManager transferManager = new();
            TransferOptions options = new()
            {
                MaximumTransferChunkSize = chunkSize
            };
            TestEventsRaised events = new(options);
            TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            events.AssertUnexpectedFailureCheck();
            await events.AssertSingleCompletedCheck();
        }

        [TestCase(500L * Constants.GB, 4 * Constants.MB, 4000L * Constants.MB, 50000)]
        public async Task ResourceChunkSizeAndCount_Error(long size, long chunkSize, long maxChunkSize, int maxChunkCount)
        {
            StorageResourceItem srcResource = MockStorageResourceItem.MakeSourceResource(size);
            StorageResourceItem dstResource = MockStorageResourceItem.MakeDestinationResource(
                maxSupportedChunkSize: maxChunkSize,
                maxSupportChunkCount: maxChunkCount);

            TransferManager transferManager = new();
            TransferOptions options = new()
            {
                MaximumTransferChunkSize = chunkSize
            };
            TestEventsRaised events = new(options);
            TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(events.FailedEvents, Is.Not.Empty);
            Assert.That(events.FailedEvents.First().Exception.Message, Does.StartWith($"Cannot transfer {size} bytes"));
        }
    }
}
