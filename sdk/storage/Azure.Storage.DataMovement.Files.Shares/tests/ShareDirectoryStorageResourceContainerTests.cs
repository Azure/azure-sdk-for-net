// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class ShareDirectoryStorageResourceContainerTests
    {
        private async IAsyncEnumerable<T> ToAsyncEnumerable<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                // returning async enumerable must be an async method
                // so we need something to await
                yield return await Task.FromResult(item);
            }
        }

        [Test]
        public async Task GetStorageResourcesCallsPathScannerCorrectly()
        {
            // Given clients
            Mock<ShareDirectoryClient> mainClient = new();
            List<Mock<ShareFileClient>> expectedFiles = Enumerable.Range(0, 10)
                .Select(i => new Mock<ShareFileClient>())
                .ToList();

            // And a mock path scanner
            Mock<PathScanner> pathScanner = new();
            pathScanner.Setup(p => p.ScanFilesAsync(mainClient.Object, It.IsAny<CancellationToken>()))
                .Returns<ShareDirectoryClient, CancellationToken>(
                    (dir, cancellationToken) => ToAsyncEnumerable(expectedFiles.Select(m => m.Object)));

            // Setup StorageResourceContainer
            ShareDirectoryStorageResourceContainer resource = new(mainClient.Object, default)
            {
                PathScanner = pathScanner.Object
            };

            // Verify StorageResourceContainer correctly invokes path scanner and returns the given files 
            List<ShareFileClient> results = new();
            await foreach (StorageResource res in resource.GetStorageResourcesInternal())
            {
                Assert.That(res, Is.TypeOf(typeof(ShareFileStorageResourceItem)));
                results.Add((res as ShareFileStorageResourceItem).ShareFileClient);
            }
            Assert.That(results, Is.EquivalentTo(expectedFiles.Select(mock => mock.Object)));
        }
    }
}
