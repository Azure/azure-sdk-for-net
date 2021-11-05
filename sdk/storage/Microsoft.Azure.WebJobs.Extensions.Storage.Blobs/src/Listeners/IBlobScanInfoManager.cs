// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal interface IBlobScanInfoManager
    {
        Task<DateTime?> LoadLatestScanAsync(string storageAccountName, string containerName);
        Task UpdateLatestScanAsync(string storageAccountName, string containerName, DateTime scanInfo);
    }
}
