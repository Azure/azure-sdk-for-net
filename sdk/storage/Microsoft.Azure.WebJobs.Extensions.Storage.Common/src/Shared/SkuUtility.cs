// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class SkuUtility
    {
        private const string AzureWebsiteSku = "WEBSITE_SKU";
        private const string DynamicSku = "Dynamic";

        private static readonly Lazy<bool> s_isDynamicSku = new Lazy<bool>(() =>
        {
            string sku = Environment.GetEnvironmentVariable(AzureWebsiteSku);
            return sku != null && sku == DynamicSku;
        });

        private static readonly Lazy<int> s_processorCount = new Lazy<int>(() =>
        {
            int processorCount = 1;
            if (!IsDynamicSku)
            {
                processorCount = Environment.ProcessorCount;
            }
            return processorCount;
        });

        public static bool IsDynamicSku => s_isDynamicSku.Value;

        public static int ProcessorCount => s_processorCount.Value;
    }
}
