// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.ApplicationInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.TestCase
{
    public class LinkedStorageAccountTests : ApplicationInsightsManagementTestBase
    {
        public LinkedStorageAccountTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ComponentLinkedStorageAccountCollection> GetLinkedStorageAccountCollectionAsync()
        {
            var name = Recording.GenerateAssetName("component");
            var resourceGroup = await CreateResourceGroupAsync();
            var componentCollection = resourceGroup.GetApplicationInsightsComponents();
            var input = ResourceDataHelpers.GetComponentData(DefaultLocation);
            var lro = await componentCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ApplicationInsightsComponentResource component = lro.Value;
            return component.GetComponentLinkedStorageAccounts();
        }

        [TestCase]
        public async Task LinkedApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetLinkedStorageAccountCollectionAsync();
            var input = ResourceDataHelpers.GetStorageAccountData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, StorageType.ServiceProfiler, input);
            ComponentLinkedStorageAccountResource account = lro.Value;
            Assert.AreEqual("serviceprofiler", account.Data.Name);
            //2.Get
            ComponentLinkedStorageAccountResource account2 = await account.GetAsync();
            ResourceDataHelpers.AssertLinkedStorageAccountData(account.Data, account2.Data);
            //3.Exists
            Assert.IsTrue(await collection.ExistsAsync("serviceprofiler"));
            //Assert.IsFalse(await collection.ExistsAsync("serviceprofilea"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //4.Get
            ComponentLinkedStorageAccountResource account3 = await account.GetAsync();
            ResourceDataHelpers.AssertLinkedStorageAccountData(account.Data, account3.Data);
            //5.Delete
            await account.DeleteAsync(WaitUntil.Completed);
        }
    }
}
