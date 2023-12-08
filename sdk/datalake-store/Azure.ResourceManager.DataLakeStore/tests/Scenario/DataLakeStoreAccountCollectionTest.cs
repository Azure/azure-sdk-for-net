// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.DataLakeStore.Models;

namespace Azure.ResourceManager.DataLakeStore.Tests.Scenario
{
    public class DataLakeStoreAccountCollectionTest : DataLakeStoreManagementTestBase
    {
        public DataLakeStoreAccountCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "DataLakeStoreRG", AzureLocation.EastUS2);
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccountCollection = resourceGroup.GetDataLakeStoreAccounts();
            var accountName = Recording.GenerateAssetName("datalake");
            var content = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            var dataLakeStoreAccount = (await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed,accountName,content)).Value;
            Assert.AreEqual(accountName,dataLakeStoreAccount.Data.Name);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccountCollection = resourceGroup.GetDataLakeStoreAccounts();
            var accountName = Recording.GenerateAssetName("datalake");
            var content = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            var dataLakeStoreAccount1 = (await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;
            var dataLakeStoreAccount2 = (await dataLakeStoreAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(dataLakeStoreAccount1.Data.Name, dataLakeStoreAccount2.Data.Name);
            Assert.AreEqual(dataLakeStoreAccount1.Data.Location, dataLakeStoreAccount2.Data.Location);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccountCollection = resourceGroup.GetDataLakeStoreAccounts();
            var accountName1 = Recording.GenerateAssetName("datalake");
            var accountName2 = Recording.GenerateAssetName("datalake");
            var content1 = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            var content2 = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            _ = await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, content1);
            _ = await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, content2);
            var count = 0;
            await foreach (var dataLakeAccounts in dataLakeStoreAccountCollection.GetAllAsync())
            {
                count++;
            };
            Assert.AreEqual(2, count);
        }

        [RecordedTest]
        public async Task Exsit()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccountCollection = resourceGroup.GetDataLakeStoreAccounts();
            var accountName = Recording.GenerateAssetName("datalake");
            var content = new DataLakeStoreAccountCreateOrUpdateContent(AzureLocation.EastUS2);
            _ = await dataLakeStoreAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, content);
            Assert.IsTrue(await dataLakeStoreAccountCollection.ExistsAsync(accountName));
            Assert.IsFalse(await dataLakeStoreAccountCollection.ExistsAsync(accountName + 1));
        }
    }
}
