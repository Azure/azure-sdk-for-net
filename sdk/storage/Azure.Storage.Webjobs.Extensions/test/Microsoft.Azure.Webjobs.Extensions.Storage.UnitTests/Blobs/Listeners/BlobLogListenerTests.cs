// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Listeners
{
    public class BlobLogListenerTests
    {
        [Fact]
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
            Assert.Equal("sample-container", singlePath.ContainerName);
            Assert.Equal(@"""0x8D199A96CB71468""/sample-blob.txt", singlePath.BlobName);
        }
    }
}
