// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public partial class TransferValidator
    {
        public interface IResourceEnumerationItem
        {
            string RelativePath { get; }
            Task<Stream> OpenReadAsync(CancellationToken cancellationToken);
        }

        public delegate Task<List<IResourceEnumerationItem>> ListFilesAsync(CancellationToken cancellationToken);

        public TransferManager TransferManager { get; init; } = new(new TransferManagerOptions()
        {
            ErrorHandling = DataTransferErrorMode.ContinueOnFailure
        });

        public async Task TransferAndVerifyAsync(
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ListFilesAsync getSourceFilesAsync,
            ListFilesAsync getDestinationFilesAsync,
            int expectedItemTransferCount,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            options ??= new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            if (cancellationToken == default)
            {
                CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(30));
                cancellationToken = cts.Token;
            }

            DataTransfer transfer = await TransferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options,
                cancellationToken);
            await transfer.WaitForCompletionAsync(cancellationToken);

            await testEventsRaised.AssertContainerCompletedCheck(expectedItemTransferCount);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            List<IResourceEnumerationItem> sourceFiles = await getSourceFilesAsync(cancellationToken);
            List<IResourceEnumerationItem> destinationFiles = await getDestinationFilesAsync(cancellationToken);

            Assert.That(sourceFiles.Count, Is.EqualTo(expectedItemTransferCount));
            Assert.That(destinationFiles.Count, Is.EqualTo(expectedItemTransferCount));

            sourceFiles.Sort((left, right) => left.RelativePath.CompareTo(right.RelativePath));
            destinationFiles.Sort((left, right) => left.RelativePath.CompareTo(right.RelativePath));

            foreach (int i in Enumerable.Range(0, expectedItemTransferCount))
            {
                using Stream sourceStream = await sourceFiles[i].OpenReadAsync(cancellationToken);
                using Stream destinationStream = await destinationFiles[i].OpenReadAsync(cancellationToken);
                Assert.That(sourceStream, Is.EqualTo(destinationStream));
            }
        }

        public async Task TransferAndVerifyAsync(
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            Func<CancellationToken, Task<Stream>> openReadSourceAsync,
            Func<CancellationToken, Task<Stream>> openReadDestinationAsync,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (cancellationToken == default)
            {
                CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(10));
                cancellationToken = cts.Token;
            }

            DataTransfer transfer = await TransferManager.StartTransferAsync(
               sourceResource,
               destinationResource,
               options,
               cancellationToken);
            await transfer.WaitForCompletionAsync(cancellationToken);

            using Stream sourceStream = await openReadSourceAsync(cancellationToken);
            using Stream destinationStream = await openReadDestinationAsync(cancellationToken);
            Assert.That(sourceStream, Is.EqualTo(destinationStream));
        }
    }
}
