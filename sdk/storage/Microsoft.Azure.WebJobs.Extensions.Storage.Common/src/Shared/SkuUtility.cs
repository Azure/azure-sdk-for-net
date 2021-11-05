// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class SkuUtility
    {
        private const string AzureWebsiteSku = "WEBSITE_SKU";
        private const string DynamicSku = "Dynamic";

        private static readonly Lazy<bool> s_isDynamicSku = new Lazy<bool>(() => ReadIsDynamicSku());
        private static readonly Lazy<int> s_processorCount = new Lazy<int>(() => GetProcessorCount(IsDynamicSku));

        private static bool ReadIsDynamicSku()
        {
            string sku = Environment.GetEnvironmentVariable(AzureWebsiteSku);
            return string.Equals(sku, DynamicSku, StringComparison.OrdinalIgnoreCase);
        }

        private static int GetProcessorCount(bool isDynamicSku)
        {
            int processorCount = 1;
            if (!isDynamicSku)
            {
                processorCount = Environment.ProcessorCount;
            }
            return processorCount;
        }

        public static bool IsDynamicSku => s_isDynamicSku.Value;

        public static int ProcessorCount => s_processorCount.Value;
    }
}
