// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.DataLakeStore.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.DataLakeStore.Tests.Scenario
{
    public class DataLakeStoreVirtualNetworkRuleCollectionTests : DataLakeStoreManagementTestBase
    {
        public DataLakeStoreVirtualNetworkRuleCollectionTests(bool isAsync)
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

        private async Task<SubnetResource> CreateSubnetId(ResourceGroupResource resourceGroup)
        {
            var virtualNetworkName = Recording.GenerateAssetName("VirtualNetwork_");
            var virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            var data = new VirtualNetworkData()
            {
                Location = AzureLocation.EastUS,
                AddressPrefixes =
                    {
                        "10.0.0.0/28",
                    },
            };
            var virtualNetworkLro = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, data);
            var virtualNetwork = virtualNetworkLro.Value;

            //Create a subnet
            var subnetName = Recording.GenerateAssetName("subnet_");
            var subnetData = new SubnetData()
            {
                ServiceEndpoints =
                    {
                        new ServiceEndpointProperties()
                        {
                            Service = "Microsoft.AzureActiveDirectory"
                        }
                    },
                Name = subnetName,
                AddressPrefix = "10.0.0.8/29",
            };
            var subnet = (await virtualNetwork.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData)).Value;
            return subnet;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var subnet = await CreateSubnetId(resourceGroup);
            var VirtualNetworkRuleCollection = dataLakeStoreAccount.GetDataLakeStoreVirtualNetworkRules();
            var virtualNetworkRuleName = Recording.GenerateAssetName("virtualNetworkRule");
            var content = new DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent(subnet.Id);
            var virtualNetworkRule = (await VirtualNetworkRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkRuleName, content)).Value;
            Assert.AreEqual(virtualNetworkRuleName,virtualNetworkRule.Data.Name);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var subnet = await CreateSubnetId(resourceGroup);
            var VirtualNetworkRuleCollection = dataLakeStoreAccount.GetDataLakeStoreVirtualNetworkRules();
            var virtualNetworkRuleName = Recording.GenerateAssetName("virtualNetworkRule");
            var content = new DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent(subnet.Id);
            var virtualNetworkRule1 = (await VirtualNetworkRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkRuleName, content)).Value;
            var virtualNetworkRule2 = (await VirtualNetworkRuleCollection.GetAsync(virtualNetworkRuleName)).Value;
            Assert.AreEqual(virtualNetworkRule1.Data.Name, virtualNetworkRule2.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var dataLakeStoreAccount = await CreateDataLakeStoreAccount(resourceGroup);
            var subnet = await CreateSubnetId(resourceGroup);
            var VirtualNetworkRuleCollection = dataLakeStoreAccount.GetDataLakeStoreVirtualNetworkRules();
            var virtualNetworkRuleName1 = Recording.GenerateAssetName("virtualNetworkRule");
            var virtualNetworkRuleName2 = Recording.GenerateAssetName("virtualNetworkRule");
            var content = new DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent(subnet.Id);
            _ = (await VirtualNetworkRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkRuleName1, content)).Value;
            _ = (await VirtualNetworkRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkRuleName2, content)).Value;
            var count = 0;
            await foreach (var virtualNetworkRule in VirtualNetworkRuleCollection.GetAllAsync())
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
            var subnet = await CreateSubnetId(resourceGroup);
            var VirtualNetworkRuleCollection = dataLakeStoreAccount.GetDataLakeStoreVirtualNetworkRules();
            var virtualNetworkRuleName = Recording.GenerateAssetName("virtualNetworkRule");
            var content = new DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent(subnet.Id);
            _ = await VirtualNetworkRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkRuleName, content);
            Assert.IsTrue(await VirtualNetworkRuleCollection.ExistsAsync(virtualNetworkRuleName));
            Assert.IsFalse(await VirtualNetworkRuleCollection.ExistsAsync(virtualNetworkRuleName+1));
        }
    }
}
