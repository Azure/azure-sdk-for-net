// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class BlobLogListenerTests
    {
        [Test]
        public void GetPathsForValidBlobWrites_Returns_ValidBlobWritesOnly()
        {
            StorageAnalyticsLogEntry[] entries = new[]
            {
                // This is a valid write entry with a valid path
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = StorageServiceOperationType.PutBlob,
                    RequestedObjectKey = @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt"
                },

                // This is an invalid path and will be filtered out
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = StorageServiceOperationType.PutBlob,
                    RequestedObjectKey = "/"
                },

                // This does not constitute a write and will be filtered out
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = null,
                    RequestedObjectKey = @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt"
                }
            };

            IEnumerable<BlobPath> validPaths = BlobLogListener.GetPathsForValidBlobWrites(entries);

            BlobPath singlePath = validPaths.Single();
            Assert.AreEqual("sample-container", singlePath.ContainerName);
            Assert.AreEqual(@"""0x8D199A96CB71468""/sample-blob.txt", singlePath.BlobName);
        }
    }
}
