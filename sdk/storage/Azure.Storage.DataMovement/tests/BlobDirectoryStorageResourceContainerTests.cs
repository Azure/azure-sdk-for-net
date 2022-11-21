// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class BlobDirectoryStorageResourceContainerTests
        : DataMovementBlobTestBase
    {
        public BlobDirectoryStorageResourceContainerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
           : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public void Ctor_PublicUri()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.blob.core.windows.net/");
            BlobContainerClient blobContainerClient = new BlobContainerClient(uri);
            BlobDirectoryStorageResourceContainer storageResource =
                new BlobDirectoryStorageResourceContainer(blobContainerClient, "directoryName");

            // Assert
            Assert.AreEqual(uri, storageResource.Uri);
            Assert.AreEqual(blobContainerClient.Name, storageResource.Path);
            Assert.AreEqual(ProduceUriType.ProducesUri, storageResource.CanProduceUri);
        }
    }
}
