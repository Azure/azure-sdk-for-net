// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class TransferValidationTests : DataMovementTestBase
    {
        public TransferValidationTests(bool async) : base(async, default)
        {
        }

        [Test, Pairwise]
        public async Task LargeSingleFile(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(DataTransferOrder.Sequential, DataTransferOrder.Unordered)] DataTransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            Uri localUri = new(@"C:\Sample\test.txt");
            Uri remoteUri = new("https://example.com");
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResource.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize);

            TransferManager transferManager = new();
            DataTransferOptions options = new();
            TestEventsRaised events = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(10));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            events.AssertUnexpectedFailureCheck();
            await events.AssertSingleCompletedCheck();
        }

        [Test, Pairwise]
        public async Task LargeSingleFile_Fail_Source(
            [Values(TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(DataTransferOrder.Sequential, DataTransferOrder.Unordered)] DataTransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResource.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize,
                sourceFailAfter: 10);

            TransferManager transferManager = new();
            DataTransferOptions options = new();
            TestEventsRaised events = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(10));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(events.FailedEvents, Is.Not.Empty);
            Assert.That(events.FailedEvents[0].Exception.Message, Does.Contain("Intentionally failing"));
        }

        [Test, Pairwise]
        public async Task LargeSingleFile_Fail_Destination(
            [Values(TransferDirection.Copy, TransferDirection.Upload, TransferDirection.Download)] TransferDirection transferDirection,
            [Values(DataTransferOrder.Sequential, DataTransferOrder.Unordered)] DataTransferOrder transferOrder)
        {
            long fileSize = 4L * Constants.GB;
            (StorageResourceItem srcResource, StorageResourceItem dstResource) = MockStorageResource.GetMockTransferResources(
                transferDirection,
                transferOrder,
                fileSize,
                destinationFailAfter: 10);

            TransferManager transferManager = new();
            DataTransferOptions options = new();
            TestEventsRaised events = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

            CancellationTokenSource tokenSource = new(TimeSpan.FromSeconds(10));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(events.FailedEvents, Is.Not.Empty);
            Assert.That(events.FailedEvents[0].Exception.Message, Does.Contain("Intentionally failing"));
        }
    }
}
