// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchManagementTestBase : ManagementRecordedTestBase<BatchManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.WestUS;

        protected BatchManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected BatchManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        public async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource rg, string storageAccountName)
        {
            var storageInput = ResourceDataHelper.GetStorageAccountData();
            var lros = await rg.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storageInput);
            return lros.Value;
        }

        public async Task<BatchAccountResource> CreateBatchAccount(ResourceGroupResource rg, string batchAccountName, ResourceIdentifier storageAccountId)
        {
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await rg.GetBatchAccounts().CreateOrUpdateAsync(WaitUntil.Completed, batchAccountName, input);
            return lro.Value;
        }
    }
}
