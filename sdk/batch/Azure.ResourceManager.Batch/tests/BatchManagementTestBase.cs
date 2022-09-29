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
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected BatchManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected BatchManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
        #region GetStorageAccoountId
        public async Task<StorageAccountCollection> GetStorageAccountCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetStorageAccounts();
        }
        public async Task<StorageAccountResource> GetStorageAccountResource()
        {
            var storageCollection = await GetStorageAccountCollectionAsync();
            var storageName = Recording.GenerateAssetName("accountforbatch");
            var storageInput = ResourceDataHelper.GetStorageAccountData();
            var lros = await storageCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageName, storageInput);
            return lros.Value;
        }
        #endregion
    }
}
