// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class SkuUtility
    {
        private const string AzureWebsiteSku = "WEBSITE_SKU";
        private const string DynamicSku = "Dynamic";

        private static readonly Lazy<bool> _isDynamicSku = new Lazy<bool>(() =>
        {
            string sku = Environment.GetEnvironmentVariable(AzureWebsiteSku);
            return sku != null && sku == DynamicSku;
        });

        public static bool IsDynamicSku => _isDynamicSku.Value;
    }
}
