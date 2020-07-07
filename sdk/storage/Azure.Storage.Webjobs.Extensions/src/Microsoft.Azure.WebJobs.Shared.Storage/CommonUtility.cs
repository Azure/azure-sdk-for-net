// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Storage
{
    internal static class CommonUtility
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
