﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    // TODO (kasobol-msft) this duplicates "Utility". find way to share code.
    internal static class SharedUtility
    {
        // CloudBlobDirectory has a private ctor, so we can't actually override it.
        // This overload is unit-testable
        internal static BlockBlobClient SafeGetBlockBlobReference(this BlobContainerClient container, string dir, string blobName)
        {
            if (!dir.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                dir = dir + "/";
            }
            var blob = container.GetBlockBlobClient(dir + blobName);
            return blob;
        }

        internal static int GetProcessorCount()
        {
            int processorCount = 1;
            var skuValue = Environment.GetEnvironmentVariable(Constants.AzureWebsiteSku);
            if (!string.Equals(skuValue, Constants.DynamicSku, StringComparison.OrdinalIgnoreCase))
            {
                processorCount = Environment.ProcessorCount;
            }
            return processorCount;
        }
    }
}
