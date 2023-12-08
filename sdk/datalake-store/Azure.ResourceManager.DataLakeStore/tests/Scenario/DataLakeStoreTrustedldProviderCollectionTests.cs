// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.DataLakeStore.Models;

namespace Azure.ResourceManager.DataLakeStore.Tests.Scenario
{
    public class DataLakeStoreTrustedldProviderCollectionTests : DataLakeStoreManagementTestBase
    {
        public DataLakeStoreTrustedldProviderCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "DataLakeStoreRG", AzureLocation.EastUS2);
        }

        private async Task<DataLakeStoreAccountResource> CreateDataLakeStoreAccount(ResourceGroupResource resourceGroup)
        {
            var dataLakeStoreAccountCollection = resourceGroup.GetDataLakeStoreAccounts();
            var accountName = Recording.GenerateAssetName("datalake");
            var content = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            return (await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreTrustedldProviderCollection = dataLakeStoreAccount.GetDataLakeStoreTrustedIdProviders();
            var trustedIdProviderName = Recording.GenerateAssetName("trustedIdProvider");
            var content = new DataLakeStoreTrustedIdProviderCreateOrUpdateContent(new Uri("https://www.Test64684.com"));
            var dataLakeStoreTrustedldProvider = (await dataLakeStoreTrustedldProviderCollection.CreateOrUpdateAsync(WaitUntil.Completed, trustedIdProviderName, content)).Value;
            Assert.AreEqual(trustedIdProviderName, dataLakeStoreTrustedldProvider.Data.Name);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreTrustedldProviderCollection = dataLakeStoreAccount.GetDataLakeStoreTrustedIdProviders();
            var trustedIdProviderName = Recording.GenerateAssetName("trustedIdProvider");
            var content = new DataLakeStoreTrustedIdProviderCreateOrUpdateContent(new Uri("https://www.Test64684.com"));
            var dataLakeStoreTrustedldProvider1 = (await dataLakeStoreTrustedldProviderCollection.CreateOrUpdateAsync(WaitUntil.Completed, trustedIdProviderName, content)).Value;
            var dataLakeStoreTrustedldProvider2 = (await dataLakeStoreTrustedldProviderCollection.GetAsync(trustedIdProviderName)).Value;
            Assert.AreEqual(dataLakeStoreTrustedldProvider1.Data.Name, dataLakeStoreTrustedldProvider2.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreTrustedldProviderCollection = dataLakeStoreAccount.GetDataLakeStoreTrustedIdProviders();
            var trustedIdProviderName1 = Recording.GenerateAssetName("trustedIdProvider");
            var trustedIdProviderName2 = Recording.GenerateAssetName("trustedIdProvider");
            var content = new DataLakeStoreTrustedIdProviderCreateOrUpdateContent(new Uri("https://www.Test64684.com"));
            _ = await dataLakeStoreTrustedldProviderCollection.CreateOrUpdateAsync(WaitUntil.Completed, trustedIdProviderName1, content);
            _ = await dataLakeStoreTrustedldProviderCollection.CreateOrUpdateAsync(WaitUntil.Completed, trustedIdProviderName2, content);
            var count = 0;
            await foreach (var dataLakeStoreTrustedProvider in dataLakeStoreTrustedldProviderCollection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreTrustedldProviderCollection = dataLakeStoreAccount.GetDataLakeStoreTrustedIdProviders();
            var trustedIdProviderName = Recording.GenerateAssetName("trustedIdProvider");
            var content = new DataLakeStoreTrustedIdProviderCreateOrUpdateContent(new Uri("https://www.Test64684.com"));
            _ = await dataLakeStoreTrustedldProviderCollection.CreateOrUpdateAsync(WaitUntil.Completed, trustedIdProviderName, content);
            Assert.IsTrue(await dataLakeStoreTrustedldProviderCollection.ExistsAsync(trustedIdProviderName));
            Assert.IsFalse(await dataLakeStoreTrustedldProviderCollection.ExistsAsync(trustedIdProviderName + 1));
        }
    }
}
