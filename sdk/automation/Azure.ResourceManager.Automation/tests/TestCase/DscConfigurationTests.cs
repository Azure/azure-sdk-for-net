// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;
namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class DscConfigurationTests : AutomationManagementTestBase
    {
        public DscConfigurationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DscConfigurationCollection> GetDscConfigurationCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetDscConfigurations();
        }

        [TestCase]
        public async Task dscconfigurationApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetDscConfigurationCollectionAsync();
            var name = Recording.GenerateAssetName("Dscconfiguration");
            var name2 = Recording.GenerateAssetName("Dscconfiguration");
            var name3 = Recording.GenerateAssetName("Dscconfiguration");
            var input = ResourceDataHelpers.GetDscConfigurationData(name);
            var input2 = ResourceDataHelpers.GetDscConfigurationData(name2);
            var input3 = ResourceDataHelpers.GetDscConfigurationData(name3);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DscConfigurationResource dscconfiguration = lro.Value;
            Assert.AreEqual(name, dscconfiguration.Data.Name);
            //2.Get
            DscConfigurationResource dscconfiguration2 = await dscconfiguration.GetAsync();
            ResourceDataHelpers.AssertDscConfiguration(dscconfiguration.Data, dscconfiguration2.Data);
            //3.GetAll
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input3);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            DscConfigurationResource dscconfiguration3 = await dscconfiguration.GetAsync();
            ResourceDataHelpers.AssertDscConfiguration(dscconfiguration.Data, dscconfiguration3.Data);
            //6.Delete
            await dscconfiguration.DeleteAsync(WaitUntil.Completed);
        }
    }
}
