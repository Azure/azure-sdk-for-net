// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.StorageCache.Tests
{
    public class StorageCacheManagementTestEnvironment : TestEnvironment
    {
        public string vnetName => GetRecordedVariable("vnet_name");
        public string storageAccountName => GetRecordedVariable("storage_account_name");
    }
}
