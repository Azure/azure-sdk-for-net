// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class LeaseExtensions
    {
        internal static DataLakeLease ToDataLakeLease(this Blobs.Models.BlobLease blobLease) =>
            new DataLakeLease()
            {
                ETag = blobLease.ETag,
                LastModified = blobLease.LastModified,
                LeaseId = blobLease.LeaseId,
                LeaseTime = blobLease.LeaseTime
            };
    }
}
