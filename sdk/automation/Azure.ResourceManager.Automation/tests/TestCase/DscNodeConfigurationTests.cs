// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class DscNodeConfigurationTests : AutomationManagementTestBase
    {
        public DscNodeConfigurationTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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

        private async Task<DscNodeConfigurationCollection> GetDscNodeConfigurationCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetDscNodeConfigurations();
        }

        [TestCase]
        public async Task dscnodeconfigurationApiTests()
        {
            //0.prepare
            var dscCollection = await GetDscConfigurationCollectionAsync();
            var configurationName = Recording.GenerateAssetName("dscconfiguration");
            var dscinput = ResourceDataHelpers.GetDscConfigurationData(configurationName);
            var dsclro = await dscCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, dscinput);
            //1.CreateOrUpdate
            var collection = await GetDscNodeConfigurationCollectionAsync();
            var name = Recording.GenerateAssetName(".dscnodeconfiguration");
            var name2 = Recording.GenerateAssetName(".dscnodeconfiguration");
            var name3 = Recording.GenerateAssetName(".dscnodeconfiguration");
            var input = ResourceDataHelpers.GetDscNodeConfigurationData(configurationName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName+name, input);
            //2.Get
            DscNodeConfigurationResource dscconfiguration2 = (await collection.GetAsync(name)).Value;
            Assert.AreEqual(name, dscconfiguration2.Data.Name);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName + name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName + name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName + name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            DscNodeConfigurationResource dscconfiguration3 = (await dscconfiguration2.GetAsync()).Value;
            ResourceDataHelpers.AssertDscNodeConfiguration(dscconfiguration2.Data, dscconfiguration3.Data);
            //6.Delete
            await dscconfiguration2.DeleteAsync(WaitUntil.Completed);
        }
    }
}
