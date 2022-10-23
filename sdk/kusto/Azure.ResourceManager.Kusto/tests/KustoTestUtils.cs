// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto.Tests
{
    public static class KustoTestUtils
    {
        public static AzureLocation Location = AzureLocation.WestUS2;

        public static readonly KustoSku Sku1 = new(KustoSkuName.StandardD13V2, 2, KustoSkuTier.Standard);
        public static readonly KustoSku Sku2 = new(KustoSkuName.StandardD14V2, 2, KustoSkuTier.Standard);

        public static readonly TimeSpan HotCachePeriod1 = TimeSpan.FromDays(2);
        public static readonly TimeSpan HotCachePeriod2 = TimeSpan.FromDays(3);
        public static readonly TimeSpan SoftDeletePeriod1 = TimeSpan.FromDays(4);
        public static readonly TimeSpan SoftDeletePeriod2 = TimeSpan.FromDays(6);
    }
}
