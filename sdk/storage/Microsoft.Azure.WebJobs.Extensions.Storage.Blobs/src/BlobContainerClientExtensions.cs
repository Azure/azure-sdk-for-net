// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobContainerClientExtensions
    {
        internal static BlockBlobClient SafeGetBlockBlobReference(this BlobContainerClient container, string dir, string blobName)
        {
            if (!dir.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                dir = dir + "/";
            }
            var blob = container.GetBlockBlobClient(dir + blobName);
            return blob;
        }
    }
}
