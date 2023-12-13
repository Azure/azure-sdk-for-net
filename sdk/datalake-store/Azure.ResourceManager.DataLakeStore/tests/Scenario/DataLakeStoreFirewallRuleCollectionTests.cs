// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.DataLakeStore.Models;
using System.Net;

namespace Azure.ResourceManager.DataLakeStore.Tests.Scenario
{
    public class DataLakeStoreFirewallRuleCollectionTests : DataLakeStoreManagementTestBase
    {
        public DataLakeStoreFirewallRuleCollectionTests(bool isAsync)
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
            var dataLakeStoreAcount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreFirewallRuleCollection = dataLakeStoreAcount.GetDataLakeStoreFirewallRules();
            var firewallRuleName = Recording.GenerateAssetName("firewallrule");
            var content = new DataLakeStoreFirewallRuleCreateOrUpdateContent(IPAddress.Parse("192.168.0.1"), IPAddress.Parse("192.168.0.255"));
            var dataLakeStoreFirewallRule = (await dataLakeStoreFirewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, content)).Value;
            Assert.AreEqual(firewallRuleName,dataLakeStoreFirewallRule.Data.Name);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAcount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreFirewallRuleCollection = dataLakeStoreAcount.GetDataLakeStoreFirewallRules();
            var firewallRuleName = Recording.GenerateAssetName("firewallrule");
            var content = new DataLakeStoreFirewallRuleCreateOrUpdateContent(IPAddress.Parse("192.168.0.1"), IPAddress.Parse("192.168.0.255"));
            var dataLakeStoreFirewallRule1 = (await dataLakeStoreFirewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, content)).Value;
            var dataLakeStoreFirewallRule2 = (await dataLakeStoreFirewallRuleCollection.GetAsync(firewallRuleName)).Value;
            Assert.AreEqual(dataLakeStoreFirewallRule1.Data.Name,dataLakeStoreFirewallRule2.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAcount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreFirewallRuleCollection = dataLakeStoreAcount.GetDataLakeStoreFirewallRules();
            var firewallRuleName1 = Recording.GenerateAssetName("firewallrule");
            var firewallRuleName2 = Recording.GenerateAssetName("firewallrule");
            var content1 = new DataLakeStoreFirewallRuleCreateOrUpdateContent(IPAddress.Parse("192.168.0.1"), IPAddress.Parse("192.168.0.255"));
            var content2 = new DataLakeStoreFirewallRuleCreateOrUpdateContent(IPAddress.Parse("192.168.0.1"), IPAddress.Parse("192.168.0.255"));
            _ = await dataLakeStoreFirewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName1, content1);
            _ = await dataLakeStoreFirewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName2, content2);
            var count = 0;
            await foreach (var dataLakeStoreFirewallRule in dataLakeStoreFirewallRuleCollection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAcount = await CreateDataLakeStoreAccount(resourceGroup);
            var dataLakeStoreFirewallRuleCollection = dataLakeStoreAcount.GetDataLakeStoreFirewallRules();
            var firewallRuleName = Recording.GenerateAssetName("firewallrule");
            var content = new DataLakeStoreFirewallRuleCreateOrUpdateContent(IPAddress.Parse("192.168.0.1"), IPAddress.Parse("192.168.0.255"));
            _ = await dataLakeStoreFirewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, content);
            Assert.IsTrue(await dataLakeStoreFirewallRuleCollection.ExistsAsync(firewallRuleName));
            Assert.IsFalse(await dataLakeStoreFirewallRuleCollection.ExistsAsync(firewallRuleName + 1));
        }
    }
}
