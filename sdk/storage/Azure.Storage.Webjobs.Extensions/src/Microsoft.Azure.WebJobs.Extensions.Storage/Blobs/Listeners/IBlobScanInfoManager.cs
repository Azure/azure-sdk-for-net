// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal interface IBlobScanInfoManager
    {
        Task<DateTime?> LoadLatestScanAsync(string storageAccountName, string containerName);
        Task UpdateLatestScanAsync(string storageAccountName, string containerName, DateTime scanInfo);
    }
}
