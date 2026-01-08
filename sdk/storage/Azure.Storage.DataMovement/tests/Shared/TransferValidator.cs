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
            ErrorMode = TransferErrorMode.ContinueOnFailure
        });

        public async Task TransferAndVerifyAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            ListFilesAsync getSourceFilesAsync,
            ListFilesAsync getDestinationFilesAsync,
            int expectedItemTransferCount,
            TransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            options ??= new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            if (cancellationToken == default)
            {
                using CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(60));
                cancellationToken = cts.Token;
            }

            TransferOperation transfer = await TransferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options,
                cancellationToken);
            await transfer.WaitForCompletionAsync(cancellationToken);

            await testEventsRaised.AssertContainerCompletedCheck(expectedItemTransferCount);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);

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
            StorageResource sourceResource,
            StorageResource destinationResource,
            Func<CancellationToken, Task<Stream>> openReadSourceAsync,
            Func<CancellationToken, Task<Stream>> openReadDestinationAsync,
            TransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (cancellationToken == default)
            {
                using CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(10));
                cancellationToken = cts.Token;
            }

            TransferOperation transfer = await TransferManager.StartTransferAsync(
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
