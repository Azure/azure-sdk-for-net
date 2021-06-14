// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class BlobScannerTests : BlobMovementTestBase
    {
        public BlobScannerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task ScanBlobsInContainer()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            string blobName = blob.Name;

            // Act
            IEnumerable<string> containerBlobs = await test.Container.GetBlobsByName().ToListAsync();

            // Assert
            CollectionAssert.Contains(containerBlobs, blobName);
            Assert.That(containerBlobs, Has.Exactly(1).Items);
        }

        [RecordedTest]
        public async Task ScanBlobsInAccount()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            string[] blobName = { test.Container.Name, blob.Name };

            // Act
            IEnumerable<string[]> accountBlobs = await test.Container.GetParentBlobServiceClient().GetBlobsByName().ToListAsync();

            // Assert
            CollectionAssert.Contains(accountBlobs, blobName);
        }
    }
}
