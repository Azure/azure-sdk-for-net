// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    static class Utility
    {
        // CloudBlobDirectory has a private ctor, so we can't actually override it. 
        // This overload is unit-testable 
        internal static CloudBlockBlob SafeGetBlockBlobReference(this CloudBlobDirectory dir, string blobName)
        {
            var container = dir.Container;
            var prefix = dir.Prefix; // already ends in /
            var blob = container.GetBlockBlobReference(prefix + blobName);
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